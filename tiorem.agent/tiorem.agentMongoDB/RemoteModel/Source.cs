using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tiorem.agent.Model
{
    /* 
  Licensed under the Apache License, Version 2.0

  http://www.apache.org/licenses/LICENSE-2.0
  */
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    namespace Xml2CSharp
    {
        [XmlRoot(ElementName = "source")]
        public class Source
        {
            [XmlElement(ElementName = "sourceId")]
            public int SourceId { get; set; }
            [XmlElement(ElementName = "sourceName")]
            public string SourceName { get; set; }
            [XmlElement(ElementName = "sourceDescription")]
            public List<string> SourceDescription { get; set; }
            [XmlElement(ElementName = "sourceImageUrl")]
            public string SourceImageUrl { get; set; }
            [XmlElement(ElementName = "sourceUrl")]
            public string SourceUrl { get; set; }
            [XmlElement(ElementName = "followers")]
            public int Followers { get; set; }
            [XmlElement(ElementName = "new")]
            public string New { get; set; }
            [XmlElement(ElementName = "sourceBackground")]
            public string SourceBackground { get; set; }
            [XmlElement(ElementName = "followed")]
            public string Followed { get; set; }
            [XmlElement(ElementName = "hideSourceLogo")]
            public string HideSourceLogo { get; set; }
            [XmlElement(ElementName = "leaveMargin")]
            public string LeaveMargin { get; set; }
            [XmlElement(ElementName = "verified")]
            public string Verified { get; set; }
        }

        [XmlRoot(ElementName = "sources")]
        public class Sources
        {
            [XmlElement(ElementName = "source")]
            public List<Source> Source { get; set; }
        }

        [XmlRoot(ElementName = "subCategory")]
        public class SubCategory
        {
            [XmlElement(ElementName = "subCategoryId")]
            public string SubCategoryId { get; set; }
            [XmlElement(ElementName = "subCategoryName")]
            public string SubCategoryName { get; set; }
            [XmlElement(ElementName = "subCategoryImageUrl")]
            public string SubCategoryImageUrl { get; set; }
            [XmlElement(ElementName = "sources")]
            public List<Sources> Sources { get; set; }
        }

        [XmlRoot(ElementName = "subCategories")]
        public class SubCategories
        {
            [XmlElement(ElementName = "subCategory")]
            public List<SubCategory> SubCategory { get; set; }
        }

        [XmlRoot(ElementName = "category")]
        public class Category
        {
            [XmlElement(ElementName = "categoryId")]
            public string CategoryId { get; set; }
            [XmlElement(ElementName = "categoryName")]
            public string CategoryName { get; set; }
            [XmlElement(ElementName = "categoryImageUrl")]
            public string CategoryImageUrl { get; set; }
            [XmlElement(ElementName = "categoryDateAdded")]
            public string CategoryDateAdded { get; set; }
            [XmlElement(ElementName = "categoryHasNewSources")]
            public string CategoryHasNewSources { get; set; }
            [XmlElement(ElementName = "categoryBackground")]
            public string CategoryBackground { get; set; }
            [XmlElement(ElementName = "subCategories")]
            public List<SubCategories> SubCategories { get; set; }
        }

        [XmlRoot(ElementName = "categories")]
        public class Categories
        {
            [XmlElement(ElementName = "category")]
            public List<Category> Category { get; set; }
        }

        [XmlRoot(ElementName = "xml")]
        public class XmlSource
        {
            [XmlElement(ElementName = "newSourcesId")]
            public string NewSourcesId { get; set; }
            [XmlElement(ElementName = "minNumberOfFollows")]
            public string MinNumberOfFollows { get; set; }
            [XmlElement(ElementName = "showTutorial")]
            public string ShowTutorial { get; set; }
            [XmlElement(ElementName = "showMySources")]
            public string ShowMySources { get; set; }
            [XmlElement(ElementName = "mySourcesCatId")]
            public string MySourcesCatId { get; set; }
            [XmlElement(ElementName = "mySourcesCatImageURL")]
            public string MySourcesCatImageURL { get; set; }
            [XmlElement(ElementName = "mySourcesCatName")]
            public string MySourcesCatName { get; set; }
            [XmlElement(ElementName = "mySourcesCatBackground")]
            public string MySourcesCatBackground { get; set; }
            [XmlElement(ElementName = "categories")]
            public List<Categories> Categories { get; set; }
            [XmlAttribute(AttributeName = "encoding")]
            public string Encoding { get; set; }
        }

    }

}
