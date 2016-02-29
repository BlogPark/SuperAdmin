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
    public class AddArticleViewModel
    {
        /// <summary>
        /// 文章主体
        /// </summary>
        [DataMember]
        public ArticlesModel article { get; set; }
        /// <summary>
        /// 分类信息
        /// </summary>
        [DataMember]
        public List<ArtCategoryModel> categorylist { get; set; }
        /// <summary>
        /// 类型ID
        /// </summary>
        [DataMember]
        public Dictionary<int, string> typelist { get; set; }
    }
}