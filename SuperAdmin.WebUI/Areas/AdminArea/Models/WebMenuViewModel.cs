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
    public class WebMenuViewModel
    {
        /// <summary>
        /// 列表
        /// </summary>
        [DataMember]
        public List<WebMenusModel> list { get; set; }

        [DataMember]
        public WebMenusModel addmenu { get; set; }

        [DataMember]
        public WebMenusModel updatemenu { get; set; }

        [DataMember]
        public List<WebMenusModel> fatherlist { get; set; }
    }
}