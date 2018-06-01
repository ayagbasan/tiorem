using System;
using System.Collections.Generic;

namespace tiorem.agentMongoDB.Model
{

    public partial class Article
    {

        public long Id { get; set; }
        public int SourceId { get; set; }
        public int CategoryId { get; set; }
        public string ArticleUrl { get; set; }
        public string SourceUrl { get; set; }
        public string Title { get; set; }
        public string SharingTitle { get; set; }
        public string Body { get; set; }
        public DateTime PubDate { get; set; }
        public string DetailedDate { get; set; }
        public string TweetId { get; set; }
        public string VideoUrl { get; set; }
        public string ImageUrl { get; set; }
        public int FavoriteHits { get; set; }
        public int Hits { get; set; }
        public int LikeHits { get; set; }
        public int UnlikeHits { get; set; }
        public bool Active { get; set; }
        public bool Approved { get; set; }
        public int ApprovedUserId { get; set; }
        public DateTime ApprovedAt { get; set; }
        public System.DateTime InsertedAt { get; set; }
        public CatalogueCategory Category { get; set; }
        public CatalogueSource Source { get; set; }
        public List<CatalogueTag> Tags { get; set; }
    }
}
