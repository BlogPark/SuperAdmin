using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SuperWebSite.WebUI.Models
{
    [Serializable]
    [DataContract]
    public class PageArticleIntroViewModel
    {
        /// <summary>
        /// 分类信息
        /// </summary>
        [DataMember]
        public Dictionary<int, string> Categories { get; set; }
        /// <summary>
        /// 总数
        /// </summary>
        [DataMember]
        public int Count { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        [DataMember]
        public bool IsVisible { get; set; }
    }
}