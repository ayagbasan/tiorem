using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tiorem.agent.Database.Model
{
    public class TioremSource
    {
        public static string collectionName = "CatalogueSource";

        [BsonId]
        public int Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Description")]
        public string Description { get; set; }
        [BsonElement("ImageUrl")]
        public string ImageUrl { get; set; }
        [BsonElement("SourceUrl")]
        public string SourceUrl { get; set; }
        [BsonElement("Followers")]
        public Nullable<int> Followers { get; set; }
        [BsonElement("Active")]
        public bool Active { get; set; }
    }
}
