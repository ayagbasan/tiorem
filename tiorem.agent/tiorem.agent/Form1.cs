using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using tiorem.agent.Database;
using tiorem.agent.Properties;
using Xml2CSharp;

namespace tiorem.agent
{
    public partial class Form1 : Form
    {
        static string logPath = Application.StartupPath + "\\log";
        static string logfilePattern = logPath + "\\log_{0:yyyyMMddHHmm}.txt";
        static string logAppfile = logPath + "\\logApp.txt";
        string logFileName = string.Empty;
        string urlPattern = "https://nabizapp.com/app/v1.3/android_articles_by_source.php?source_id={0}";
        string logSeperator = "\t\t";
        static ReaderWriterLockSlim _readWriteLock = new ReaderWriterLockSlim();

        bool isThreadRunning = false;

        Thread thread = null;

        public Form1()
        {
            InitializeComponent();
            if (!Directory.Exists(logPath))
                Directory.CreateDirectory(logPath);
            if (!File.Exists(logAppfile))
                File.Create(logAppfile).Close();

            CheckForIllegalCrossThreadCalls = false;
        }


        void execute()
        {
            if (thread != null)
            {
                if (!isThreadRunning)
                {
                    isThreadRunning = true;
                    pictureBox1.Image = Resources.if_recycle_1054994;
                    lblStatus.Text = "Running...";
                    string xmlContent;
                    DateTime now = DateTime.Now;
                    DateTime prevMinute = now.AddMinutes(-60);

                    lblLastRun.Text = now.ToString("dd.MM.yyyy HH:mm:ss");
                    lblNextRun.Text = now.AddMilliseconds(myTimer.Interval).ToString("dd.MM.yyyy HH:mm:ss");
                    logFileCreate(now);

                    using (TIOREMEntities context = new TIOREMEntities())
                    {
                        try
                        {
                            List<CatalogueSource> sources = context.CatalogueSource.Where(p => p.Active).ToList();
                            List<long> latestLocalArticlesId = context.Article.Select(p => p.Id).ToList();

                            using (var wc = new WebClient())
                            {
                                wc.Encoding = Encoding.UTF8;
                                var xmlDoc = new XmlDocument();


                                foreach (var source in sources)
                                {
                                    try
                                    {
                                        xmlContent = wc.DownloadString(string.Format(urlPattern, source.Id));
                                        xmlDoc.LoadXml(xmlContent);
                                        Xml response = null;
                                        XmlSerializer serializer = new XmlSerializer(typeof(Xml));
                                        using (XmlReader reader = new XmlNodeReader(xmlDoc))
                                        {
                                            try
                                            {
                                                response = (Xml)serializer.Deserialize(reader);


                                                List<Database.Article> newArticles = new List<Database.Article>();
                                                Database.Article newArticle = null;

                                                foreach (var item in response.Articles.Article)
                                                {
                                                    if (item.ArticleId.HasValue)
                                                    {
                                                        DateTime pubDate = Convert.ToDateTime(item.ArticlePubDate);
                                                        if (latestLocalArticlesId.IndexOf(item.ArticleId.Value) == -1)
                                                        {
                                                            try
                                                            {

                                                                newArticle = new Database.Article();
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
                                                                logger(item.ArticleId + logSeperator + "Not Converted Local Format" + logSeperator + ex.ToString());

                                                            }
                                                        }
                                                    }
                                                }


                                                try
                                                {
                                                    context.Article.AddRange(newArticles);
                                                    context.SaveChanges();
                                                    logger("SUCCESSFULLY"+ logSeperator + string.Format("{0:00} items",newArticles.Count)  + logSeperator + source.Name , true);
                                                }
                                                catch (Exception ex)
                                                {
                                                    logger(source.Name + logSeperator + "Not Saved to Database" + logSeperator + ex.ToString());
                                                }
                                            }
                                            catch (Exception ex)
                                            {

                                                logger(source.Name + logSeperator + "Not Deserialize" + logSeperator + ex.ToString());
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                        logger(source.Name + logSeperator + "Not Downloaded" + logSeperator + ex.ToString());
                                    }

                                }


                            }
                        }
                        catch (Exception ex)
                        {
                            logger("DATABASE ERROR\t" + ex.ToString());
                        }
                    }

                    lblDuration.Text = ((int)(DateTime.Now.Subtract(now).TotalSeconds)).ToString() + " sn";
                    lblStatus.Text = "Waiting next run...";
                    isThreadRunning = false;
                    pictureBox1.Image = Resources.if_check_1055094;
                    loggerApp("Excuted comleted");
                }
                else
                {
                    loggerApp("Thread is running");
                }
            }
            else
            {
                loggerApp("Thread not set");
            }
        }

        void logger(string msg, bool isError = true)
        {
            // Set Status to Locked
            _readWriteLock.EnterWriteLock();
            try
            {
                // Append text to the file
                string preTag = DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + logSeperator + (isError ? "INFO" : "ERROR") + logSeperator;
                using (StreamWriter sw = File.AppendText(logFileName))
                {
                    sw.WriteLine(preTag + msg);
                    sw.Close();
                }
            }
            finally
            {
                // Release lock
                _readWriteLock.ExitWriteLock();
            }
        }

        void loggerApp(string msg, bool isError = true)
        {
            
            // Set Status to Locked
            _readWriteLock.EnterWriteLock();
            try
            {
                // Append text to the file
                string preTag = DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + logSeperator + (isError ? "INFO" : "ERROR") + logSeperator;
                using (StreamWriter sw = File.AppendText(logAppfile))
                {
                    sw.WriteLine(preTag + msg);
                    sw.Close();
                }
            }
            finally
            {
                // Release lock
                _readWriteLock.ExitWriteLock();
            }
        }

        void logFileCreate(DateTime date)
        {
            if (!Directory.Exists(logPath))
                Directory.CreateDirectory(logPath);

            logFileName = string.Format(logfilePattern, date);
            if (!File.Exists(logFileName))
                File.Create(logFileName).Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            myTimer.Enabled = true;
            myTimer.Start();
            loggerApp("Timer started");
            btnStart.Enabled = !myTimer.Enabled;
            btnStopTimer.Enabled = myTimer.Enabled;


        }

        private void btnStopTimer_Click(object sender, EventArgs e)
        {
            myTimer.Stop();
            myTimer.Enabled = false;
            thread.Abort();
            thread = null;
            btnStart.Enabled = !myTimer.Enabled;
            btnStopTimer.Enabled = myTimer.Enabled;
            loggerApp("Timer stopped");

        }

        private void btnManuel_Click(object sender, EventArgs e)
        {
            if (!isThreadRunning)
            {
                thread = new Thread(new ThreadStart(execute));
                thread.Start();
                loggerApp("Manuel Excuted started");
            }
            else
            {
                loggerApp("Thread is runnig.");
            }
        }

        private void btnOpenLogFolder_Click(object sender, EventArgs e)
        {
            Process.Start(logPath);
        }

        private void myTimer_Tick(object sender, EventArgs e)
        {
            loggerApp("Excuted started");
            myTimer.Interval = 1000 * 60 * (int)periode.Value;

            thread = new Thread(new ThreadStart(execute));
            thread.Start();

        }
    }
}
