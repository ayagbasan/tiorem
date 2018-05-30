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

namespace tiorem.agent
{
    public partial class frmCatalogueSource : Form
    {
        public frmCatalogueSource()
        {
            InitializeComponent();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
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
            }







        }
    }
}
