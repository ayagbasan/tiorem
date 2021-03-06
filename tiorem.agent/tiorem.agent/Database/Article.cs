//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace tiorem.agent.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Article
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Article()
        {
            this.ArticleTag = new HashSet<ArticleTag>();
        }
    
        public long Id { get; set; }
        public int SourceId { get; set; }
        public int CategoryId { get; set; }
        public string ArticleUrl { get; set; }
        public string SourceUrl { get; set; }
        public string Title { get; set; }
        public string SharingTitle { get; set; }
        public string Body { get; set; }
        public Nullable<System.DateTime> PubDate { get; set; }
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
        public Nullable<int> ApprovedUserId { get; set; }
        public Nullable<System.DateTime> ApprovedAt { get; set; }
        public System.DateTime InsertedAt { get; set; }
    
        public virtual CatalogueCategory CatalogueCategory { get; set; }
        public virtual CatalogueSource CatalogueSource { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArticleTag> ArticleTag { get; set; }
    }
}
