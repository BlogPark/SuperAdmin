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
    public class webfaqindexViewModel
    {
        /// <summary>
        /// 全部数据
        /// </summary>
        public List<WebfaqMsgModel> list { get; set; }
        /// <summary>
        /// 发布信息
        /// </summary>
        public WebfaqMsgModel addmodel { get; set; }
        /// <summary>
        /// 修改信息
        /// </summary>
        public WebfaqMsgModel updmodel { get; set; }
    }
}