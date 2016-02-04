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
    public class WebModuleViewModel
    {
        /// <summary>
        /// 列表
        /// </summary>
        [DataMember]
        public List<WebModuleModel> list { get; set; }
        /// <summary>
        /// 添加MOdel
        /// </summary>
        [DataMember]
        public WebModuleModel addmodel { get; set; }       
        /// <summary>
        /// 修改MOdel
        /// </summary>
        [DataMember]
        public WebModuleModel updatemodel { get; set; }
    }
}