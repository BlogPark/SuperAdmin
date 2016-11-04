using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using SuperAdmin.datamodel;

namespace SuperWebSite.WebUI.Areas.Article.Models
{
    [Serializable]
    [DataContract]
    public class ArticleDetailViewModel
    {
        [DataMember]
        public ArticlesModel Article { get; set; }
        [DataMember]
        public List<WebSiteCommentsModel> comments { get; set; }
        [DataMember]
        public List<ArticlesModel> RecommendArticle { get; set; }
        [DataMember]
        public List<ArticlesModel> RecommendArticlebuttom { get; set; }
    }
}