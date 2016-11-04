using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using SuperAdmin.datamodel;

namespace SuperWebSite.WebUI.Models
{
    /// <summary>
    /// 系统菜单信息
    /// </summary>
    [Serializable]
    [DataContract]
    public class PageNavViewModel
    {
        /// <summary>
        /// 网站基本信息
        /// </summary>
        [DataMember]
        public WebSettingsModel webbasedata { get; set; }
        /// <summary>
        /// 网站一级菜单信息
        /// </summary>
        [DataMember]
        public List<WebMenusModel> webfirstmenus { get; set; }
        /// <summary>
        /// 网站二级菜单信息
        /// </summary>
        [DataMember]
        public List<WebMenusModel> websubmenus { get; set; }
        /// <summary>
        /// 是否显示主导航栏
        /// </summary>
        [DataMember]
        public bool IsShowMainMav { get; set; }
    }
}