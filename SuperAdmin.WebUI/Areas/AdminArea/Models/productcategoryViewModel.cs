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
    public class productcategoryViewModel
    {
        /// <summary>
        /// 分类列表
        /// </summary>
        [DataMember]
        public List<ProductCategoryModel> catelists { get; set; }
    }
}