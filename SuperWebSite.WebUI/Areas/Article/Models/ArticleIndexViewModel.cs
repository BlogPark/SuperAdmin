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
    public class ArticleIndexViewModel
    {
        /// <summary>
        /// 分类信息
        /// </summary>
        [DataMember]
        public List<ArtCategoryModel> catelist { get; set; }
        /// <summary>
        /// 文章信息
        /// </summary>
        [DataMember]
        public Dictionary<int, List<ArticlesModel>> articles { get; set; }
    }
}