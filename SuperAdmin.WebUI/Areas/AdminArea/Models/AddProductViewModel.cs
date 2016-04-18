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
    public class AddProductViewModel
    {
        /// <summary>
        /// 添加信息
        /// </summary>
        [DataMember]
        public ProductInfoModel product { get; set; }
        /// <summary>
        /// 产品分类信息
        /// </summary>
        [DataMember]
        public List<ProductCategoryModel> categories { get; set; }
    }
}