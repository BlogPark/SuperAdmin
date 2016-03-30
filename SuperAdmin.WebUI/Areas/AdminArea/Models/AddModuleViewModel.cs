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
    public class AddModuleViewModel
    {
        /// <summary>
        /// 添加信息
        /// </summary>
        [DataMember]
        public WebModuleModel addmodel { get; set; }
        /// <summary>
        /// 查询图片的条件
        /// </summary>
        [DataMember]
        public WebSiteImageModel websiteimg { get; set; }
        /// <summary>
        /// 网站图片分类
        /// </summary>
        [DataMember]
        public List<PicCategoryModel> picCategory { get; set; }
    }
}