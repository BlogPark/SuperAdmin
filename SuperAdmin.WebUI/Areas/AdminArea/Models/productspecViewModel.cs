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
    public class productspecViewModel
    {
        /// <summary>
        /// 页面数据
        /// </summary>
        [DataMember]
        public List<ProductSpecModel> list { get; set; }

        [DataMember]
        public ProductSpecModel addmodel { get; set; }
        
        [DataMember]
        public ProductSpecModel updmodel { get; set; }
    }
}