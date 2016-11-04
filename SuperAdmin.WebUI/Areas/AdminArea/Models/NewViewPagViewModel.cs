using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using SuperAdmin.datamodel;

namespace SuperAdmin.WebUI.Areas.AdminArea.Models
{
    /// <summary>
    /// 消息查看页面
    /// </summary>
    [Serializable]
    [DataContract]
    public class NewViewPagViewModel
    {
        /// <summary>
        /// 单个消息Model
        /// </summary>
        [DataMember]
        public AdminSiteNewsModel sitenewmodel { get; set; }
        /// <summary>
        /// 回复信息
        /// </summary>
        [DataMember]
        public AdminSiteNewsModel newmodel { get; set; }
    }
}