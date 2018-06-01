using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tiorem.agent.Database.Model
{ 

    [BsonIgnoreExtraElements]
    public class TioremArticle
    {
        public static string collectionName = "Article";

        [BsonId]
        public long Id { get; set; }
        [BsonElement("SourceId")]
        public int SourceId { get; set; }
        [BsonElement("CategoryId")]
        public int CategoryId { get; set; }
        [BsonElement("ArticleUrl")]
        public string ArticleUrl { get; set; }
        [BsonElement("SourceUrl")]
        public string SourceUrl { get; set; }
        [BsonElement("Title")]
        public string Title { get; set; }
        [BsonElement("SharingTitle")]
        public string SharingTitle { get; set; }
        [BsonElement("Body")]
        public string Body { get; set; }
        [BsonElement("PubDate")]
        public DateTime PubDate { get; set; }
        [BsonElement("DetailedDate")]
        public string DetailedDate { get; set; }
        [BsonElement("TweetId")]
        public string TweetId { get; set; }
        [BsonElement("VideoUrl")]
        public string VideoUrl { get; set; }
        [BsonElement("ImageUrl")]
        public string ImageUrl { get; set; }
        [BsonElement("FavoriteHits")]
        public int FavoriteHits { get; set; }
        [BsonElement("Hits")]
        public int Hits { get; set; }
        [BsonElement("LikeHits")]
        public int LikeHits { get; set; }
        [BsonElement("UnlikeHits")]
        public int UnlikeHits { get; set; }
        [BsonElement("Active")]
        public bool Active { get; set; }
        [BsonElement("Approved")]
        public bool Approved { get; set; }
        [BsonElement("InsertedAt")]
        public DateTime InsertedAt { get; set; }
       

    }
}
