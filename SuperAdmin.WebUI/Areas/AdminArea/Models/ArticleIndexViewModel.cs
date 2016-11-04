using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using SuperAdmin.datamodel;
using Webdiyer.WebControls.Mvc;

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
        public PagedList<ArticlesModel> articlelist { get; set; }
        /// <summary>
        /// 查询实体
        /// </summary>
        [DataMember]
        public ArticlesModel seachmodel { get; set; }
        /// <summary>
        /// 当前页数
        /// </summary>
        [DataMember]
        public int currentpage { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        [DataMember]
        public int totalcount { get; set; }
        /// <summary>
        /// 页容量
        /// </summary>
        [DataMember]
        public int pagesize { get; set; }
    }
}