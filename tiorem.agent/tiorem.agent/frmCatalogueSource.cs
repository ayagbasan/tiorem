using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using tiorem.agent.Model.Xml2CSharp;
using System.Linq;
using tiorem.agent.Database;
using tiorem.agent.Database.Model;
using System.IO;
using Newtonsoft.Json;

namespace tiorem.agent
{
    public partial class frmCatalogueSource : Form
    {
        List<CatalogueSource> catalogueSources;

        public frmCatalogueSource()
        {
            InitializeComponent();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {

            catalogueSources = new List<CatalogueSource>();
            Repository<TioremSource> repoTiorem = new Repository<TioremSource>();
            var m_strFilePath = txtURL.Text;
            string xmlStr;
            using (var wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                xmlStr = wc.DownloadString(m_strFilePath);
            }

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlStr);

            Xml response = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Xml));
            using (XmlReader reader = new XmlNodeReader(xmlDoc))
            {
                response = (Xml)serializer.Deserialize(reader);
            }


            if(response!=null)
            {
                List<CatalogueSource> catalogueSources = new List<CatalogueSource>();
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

                                        //repoTiorem.Insert(catalogueSource);
                                    }
                                }
                            }
                        }
                    }
                }


                gridRemote.DataSource = catalogueSources.OrderBy(p=>p.Name);
                gridRemote.Refresh();




                //using (TIOREMEntities context = new TIOREMEntities())
                //{
                //    context.CatalogueSource.AddRange(catalogueSources);
                //    context.SaveChanges();
                //}

                saveData(catalogueSources);
            }







        }


        void saveData (List<CatalogueSource> data)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.mlab.com/api/1/databases/tiorem/collections/CatalogueSource?apiKey=SmUMfyNUqrOpSvfko7pFiKWoRqxhk0eT");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(data);

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }
    }
}
