using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using SuperAdmin.datamodel;

namespace SuperAdmin.WebUI.Areas.AdminArea.Models
{
    /// <summary>
    /// 文章管理页面
    /// </summary>
    [Serializable]
    [DataContract]
    public class ArticleIndexViewModel
    {
        /// <summary>
        /// 文章列表
        /// </summary>
        [DataMember]
        public List<ArticlesModel> articlelist { get; set; }
    }
}