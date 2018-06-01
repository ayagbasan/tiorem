/* 
 Licensed under the Apache License, Version 2.0

 http://www.apache.org/licenses/LICENSE-2.0
 */
using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Xml2CSharp
{
    [XmlRoot(ElementName = "script")]
    public class Script
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "article")]
    public class Article
    {
        [XmlElement(ElementName = "sourceId")]
        public Int64 SourceId { get; set; }
        [XmlElement(ElementName = "sourceName")]
        public string SourceName { get; set; }
        [XmlElement(ElementName = "sourceImageUrl")]
        public string SourceImageUrl { get; set; }
        [XmlElement(ElementName = "sourceUrl")]
        public string SourceUrl { get; set; }
        [XmlElement(ElementName = "twitterId")]
        public string TwitterId { get; set; }
        [XmlElement(ElementName = "twitterScreenName")]
        public string TwitterScreenName { get; set; }
        [XmlElement(ElementName = "hideSourceLogo")]
        public string HideSourceLogo { get; set; }
        [XmlElement(ElementName = "hideInsideSourceLogo")]
        public string HideInsideSourceLogo { get; set; }
        [XmlElement(ElementName = "articleId")]
        public Int64? ArticleId { get; set; }
        [XmlElement(ElementName = "articleUrl")]
        public string ArticleUrl { get; set; }
        [XmlElement(ElementName = "articleTitle")]
        public string ArticleTitle { get; set; }
        [XmlElement(ElementName = "articleSharingTitle")]
        public string ArticleSharingTitle { get; set; }
        [XmlElement(ElementName = "forceOpenAsArticle")]
        public string ForceOpenAsArticle { get; set; }
        [XmlElement(ElementName = "articleBody")]
        public string ArticleBody { get; set; }
        [XmlElement(ElementName = "articlePubDate")]
        public string ArticlePubDate { get; set; }
        [XmlElement(ElementName = "articleDetailedDate")]
        public string ArticleDetailedDate { get; set; }
        [XmlElement(ElementName = "articleBreaking")]
        public string ArticleBreaking { get; set; }
        [XmlElement(ElementName = "articleHits")]
        public string ArticleHits { get; set; }
        [XmlElement(ElementName = "articleTweetId")]
        public string ArticleTweetId { get; set; }
        [XmlElement(ElementName = "articleVideoUrl")]
        public string ArticleVideoUrl { get; set; }
        [XmlElement(ElementName = "articleImageUrl")]
        public string ArticleImageUrl { get; set; }
        [XmlElement(ElementName = "youtubeBaseURL")]
        public string YoutubeBaseURL { get; set; }
        [XmlElement(ElementName = "autoPlayVideo")]
        public string AutoPlayVideo { get; set; }
        [XmlElement(ElementName = "favorited")]
        public string Favorited { get; set; }
        [XmlElement(ElementName = "articleComments")]
        public string ArticleComments { get; set; }
        [XmlElement(ElementName = "showComments")]
        public string ShowComments { get; set; }
        [XmlElement(ElementName = "showViews")]
        public string ShowViews { get; set; }
        [XmlElement(ElementName = "social")]
        public string Social { get; set; }
        [XmlElement(ElementName = "alignment")]
        public string Alignment { get; set; }
        [XmlElement(ElementName = "sharingScreen")]
        public string SharingScreen { get; set; }
        [XmlElement(ElementName = "twitterSignature")]
        public string TwitterSignature { get; set; }
        [XmlElement(ElementName = "sharingSignature")]
        public string SharingSignature { get; set; }
        [XmlElement(ElementName = "whatsappSignature")]
        public string WhatsappSignature { get; set; }
        [XmlElement(ElementName = "moreSocialNetworksSignature")]
        public string MoreSocialNetworksSignature { get; set; }
        [XmlElement(ElementName = "shareWhatsAppInsideApp")]
        public string ShareWhatsAppInsideApp { get; set; }
        [XmlElement(ElementName = "instaSignature")]
        public string InstaSignature { get; set; }
        [XmlElement(ElementName = "tweetLength")]
        public string TweetLength { get; set; }
        [XmlElement(ElementName = "tweetLinkLength")]
        public string TweetLinkLength { get; set; }
        [XmlElement(ElementName = "showCopyLink")]
        public string ShowCopyLink { get; set; }
        [XmlElement(ElementName = "srcNameWhenShare")]
        public string SrcNameWhenShare { get; set; }
        [XmlElement(ElementName = "promoted")]
        public string Promoted { get; set; }
        [XmlElement(ElementName = "canShare")]
        public string CanShare { get; set; }
        [XmlElement(ElementName = "canComment")]
        public string CanComment { get; set; }
        [XmlElement(ElementName = "canFavorite")]
        public string CanFavorite { get; set; }
        [XmlElement(ElementName = "sharingUrl")]
        public string SharingUrl { get; set; }
        [XmlElement(ElementName = "flag")]
        public string Flag { get; set; }
        [XmlElement(ElementName = "rtlMark")]
        public string RtlMark { get; set; }
        [XmlElement(ElementName = "trackArticle")]
        public string TrackArticle { get; set; }
        [XmlElement(ElementName = "clickableSource")]
        public string ClickableSource { get; set; }
        [XmlElement(ElementName = "sourceArticlesUrl")]
        public string SourceArticlesUrl { get; set; }
        [XmlElement(ElementName = "imageHeight")]
        public string ImageHeight { get; set; }
        [XmlElement(ElementName = "showGPlus")]
        public string ShowGPlus { get; set; }
        [XmlElement(ElementName = "useBottomSheet")]
        public string UseBottomSheet { get; set; }
        [XmlElement(ElementName = "showFloatingAction")]
        public string ShowFloatingAction { get; set; }
        [XmlElement(ElementName = "promotedOpenInSafari")]
        public string PromotedOpenInSafari { get; set; }
        [XmlElement(ElementName = "openInSFSafari")]
        public string OpenInSFSafari { get; set; }
        [XmlElement(ElementName = "sfSafariOpenReaderView")]
        public string SfSafariOpenReaderView { get; set; }
        [XmlElement(ElementName = "pcw")]
        public string Pcw { get; set; }
        [XmlElement(ElementName = "dim")]
        public string Dim { get; set; }
        [XmlElement(ElementName = "moreFromThisSource")]
        public string MoreFromThisSource { get; set; }
        [XmlElement(ElementName = "showBottomBar")]
        public string ShowBottomBar { get; set; }
        [XmlElement(ElementName = "commentMaxChars")]
        public string CommentMaxChars { get; set; }
    }

    [XmlRoot(ElementName = "articles")]
    public class Articles
    {
        [XmlElement(ElementName = "article")]
        public List<Article> Article { get; set; }
    }

    [XmlRoot(ElementName = "xml")]
    public class XmlArticle
    {
         
    
        
        [XmlElement(ElementName = "defaultPageTitle")]
        public string DefaultPageTitle { get; set; }
        [XmlElement(ElementName = "defaultPageUrl")]
        public string DefaultPageUrl { get; set; }
        [XmlElement(ElementName = "articles")]
        public Articles Articles { get; set; }
       
    }

}
