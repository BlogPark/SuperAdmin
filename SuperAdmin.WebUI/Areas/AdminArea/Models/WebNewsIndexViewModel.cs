using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using SuperAdmin.datamodel;

namespace SuperAdmin.WebUI.Areas.AdminArea.Models
{
    /// <summary>
    /// 网站新闻管理页面Model
    /// </summary>
    [Serializable]
    [DataContract]
    public class WebNewsIndexViewModel
    {
        /// <summary>
        /// 新闻列表
        /// </summary>
        [DataMember]
        public List<WebNewsModel> list { get; set; }
        /// <summary>
        /// 新增网站新闻
        /// </summary>
        [DataMember]
        public WebNewsModel addmodel { get; set; }
    }
}