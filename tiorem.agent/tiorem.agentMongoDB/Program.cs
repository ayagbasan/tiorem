using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using tiorem.agent.Model.Xml2CSharp;
using tiorem.agentMongoDB.Model;
using Xml2CSharp;

namespace tiorem.agentMongoDB
{
    static class Program
    {
        static string sourcesUrl = "https://nabizapp.com/app/v1.3/android_all_categories.php";
        static string urlPattern = "https://nabizapp.com/app/v1.3/android_articles_by_source.php?source_id={0}";
        static AYMKLogger logger;

        static void Main()
        {
            logger = new AYMKLogger(Application.StartupPath);
            logger.logFileCreate(DateTime.Now);
            logger.addLog("Agent started");
            ReadArticles();

        }
        static void InsertSources()
        {
            List<CatalogueSource> catalogueSources = new List<CatalogueSource>();

            string xmlStr;
            using (var wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                xmlStr = wc.DownloadString(sourcesUrl);
            }

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlStr);

            XmlSource response = null;
            XmlSerializer serializer = new XmlSerializer(typeof(XmlSource));
            using (XmlReader reader = new XmlNodeReader(xmlDoc))
            {
                response = (XmlSource)serializer.Deserialize(reader);
            }


            if (response != null)
            {
                CatalogueSource catalogueSource = null;
                foreach (var categories in response.Categories)
                {
                    foreach (var category in categories.Category)
                    {
                        foreach (var subCategories in category.SubCategories)
                        {
                            foreach (var subCategory in subCategories.SubCategory)
                            {
                                foreach (var sources in subCategory.Sources)
                                {
                                    foreach (var source in sources.Source)
                                    {
                                        catalogueSource = new CatalogueSource();

                                        catalogueSource.Active = true;
                                        catalogueSource.Description = source.SourceDescription.Count > 1 ? source.SourceDescription[0] : "";
                                        catalogueSource.Followers = source.Followers;
                                        catalogueSource.Id = source.SourceId;
                                        catalogueSource.ImageUrl = source.SourceImageUrl;
                                        catalogueSource.Name = source.SourceName;
                                        catalogueSource.SourceUrl = source.SourceImageUrl;


                                        catalogueSources.Add(catalogueSource);
                                    }
                                }
                            }
                        }
                    }
                }


                MongoRepo<CatalogueSource> repo = new MongoRepo<CatalogueSource>(MongoDbCollections.CatalogueSource);
                Tuple<HttpWebResponse, string> result = repo.Insert(catalogueSources);
            }
        }


        static void ReadArticles()
        {

            string xmlContent;
            DateTime now = DateTime.Now;
            DateTime prevMinute = now.AddMinutes(-60);
            MongoRepo<CatalogueSource> repoSource = new MongoRepo<CatalogueSource>(MongoDbCollections.CatalogueSource);
            Tuple<HttpWebResponse, List<CatalogueSource>> result = repoSource.GetAll();

            if (result.Item1.StatusCode == HttpStatusCode.OK)
            {
                using (var wc = new WebClient())
                {
                    wc.Encoding = Encoding.UTF8;
                    var xmlDoc = new XmlDocument();

                    int index = 0;
                    foreach (var source in result.Item2)
                    {
                        Console.WriteLine(string.Format("{0} -> {1} fetching...",index,source.Name));

                        if (index > 20) break;

                        try
                        {
                            xmlContent = wc.DownloadString(string.Format(urlPattern, source.Id));
                            xmlDoc.LoadXml(xmlContent);
                            XmlArticle response = null;
                            XmlSerializer serializer = new XmlSerializer(typeof(XmlArticle));
                            using (XmlReader reader = new XmlNodeReader(xmlDoc))
                            {
                                try
                                {
                                    response = (XmlArticle)serializer.Deserialize(reader);


                                    List<Model.Article> newArticles = new List<Model.Article>();
                                    Model.Article newArticle = null;

                                    foreach (var item in response.Articles.Article)
                                    {
                                        if (!item.ArticleId.HasValue)
                                            continue;

                                        DateTime pubDate = Convert.ToDateTime(item.ArticlePubDate);

                                        try
                                        {                                             
                                            newArticle = new Model.Article();
                                            newArticle.Active = true;
                                            newArticle.Approved = false;
                                            newArticle.Body = item.ArticleBody;
                                            newArticle.DetailedDate = item.ArticleDetailedDate;
                                            newArticle.Id = item.ArticleId.Value;
                                            newArticle.ImageUrl = item.ArticleImageUrl;
                                            newArticle.InsertedAt = now;
                                            newArticle.PubDate = pubDate;
                                            newArticle.SharingTitle = item.ArticleSharingTitle;
                                            newArticle.SourceId = source.Id;
                                            newArticle.SourceUrl = item.SourceImageUrl;
                                            newArticle.ArticleUrl = item.ArticleUrl;
                                            newArticle.Title = item.ArticleTitle;
                                            newArticle.TweetId = item.TwitterId;
                                            newArticle.VideoUrl = item.ArticleVideoUrl;
                                            newArticle.Approved = false;
                                            newArticle.CategoryId = 1;
                                            newArticle.FavoriteHits = 0;
                                            newArticle.Hits = 0;
                                            newArticle.LikeHits = 0;
                                            newArticle.UnlikeHits = 0;


                                            newArticles.Add(newArticle);

                                        }
                                        catch (Exception ex)
                                        {
                                            logger.addLog(item.ArticleId + logger.s + "Not Converted Local Format" + logger.s + ex.ToString());

                                        }
                                    }

                                    try
                                    {

                                        MongoRepo<Model.Article> repoArticle = new MongoRepo<Model.Article>(MongoDbCollections.Article);
                                        Tuple<HttpWebResponse, string> resultArticle = repoArticle.Put(newArticles);

                                        logger.addLog("SUCCESSFULLY" + logger.s + resultArticle.Item2 + logger.s + source.Name, true);

                                        Console.WriteLine(string.Format("\t{0} completed. Items: {1} Result: {2}", source.Name, newArticles.Count, resultArticle.Item2));

                                    }
                                    catch (Exception ex)
                                    {
                                        logger.addLog(source.Name + logger.s + "Not Saved to Database" + logger.s + ex.ToString());
                                    }
                                }
                                catch (Exception ex)
                                {
                                    logger.addLog(source.Name + logger.s + "Not Deserialize" + logger.s + ex.ToString());
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                            logger.addLog(source.Name + logger.s + "Not Downloaded" + logger.s + ex.ToString());
                        }

                        index++;
                    }


                }
            }

         


            logger.addLog("Excuted comleted");
            logger.addLog("Agent closed");

        }

   

        


    }
}
