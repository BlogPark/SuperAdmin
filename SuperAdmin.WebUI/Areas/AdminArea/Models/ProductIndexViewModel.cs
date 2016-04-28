using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using SuperAdmin.datamodel;
using Webdiyer.WebControls.Mvc;

namespace SuperAdmin.WebUI.Areas.AdminArea.Models
{
    [Serializable]
    [DataContract]
    public class ProductIndexViewModel
    {
        [DataMember]
        public PagedList<ProductInfoModel> productlist { get; set; }
        /// <summary>
        /// 查询条件
        /// </summary>
        [DataMember]
        public ProductInfoModel product { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        [DataMember]
        public int totalcount { get; set; }
        /// <summary>
        /// 当前页数
        /// </summary>
        [DataMember]
        public int currentpage { get; set; }
        /// <summary>
        /// 页容量
        /// </summary>
        [DataMember]
        public int pagesize { get; set; }
        /// <summary>
        /// 分类列表
        /// </summary>
        [DataMember]
        public List<ProductCategoryModel> catelist { get; set; }
    }
}