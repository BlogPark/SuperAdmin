using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using SuperAdmin.datamodel;

namespace SuperAdmin.WebUI.Areas.AdminArea.Models
{
    [Serializable]
    [DataContract]
    public class SiteMsgIndexViewModel
    {
        /// <summary>
        /// 消息列表
        /// </summary>
        [DataMember]
        public List<AdminSiteNewsModel> msglist { get; set; }
    }
}