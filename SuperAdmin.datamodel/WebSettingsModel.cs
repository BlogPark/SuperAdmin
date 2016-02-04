using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SuperAdmin.datamodel
{
    [Serializable]
    [DataContract]
    public class WebSettingsModel
    {
        #region 原有字段
        /// <summary>
        /// ID
        /// </summary>       
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 网站标题
        /// </summary>       
        [DataMember]
        public string WebName { get; set; }
        /// <summary>
        /// 网站默认描述
        /// </summary>       
        [DataMember]
        public string WebDescription { get; set; }
        /// <summary>
        /// 网站类型描述
        /// </summary>       
        [DataMember]
        public string WebType { get; set; }
        /// <summary>
        /// 网站图标备注
        /// </summary>       
        [DataMember]
        public string WebLogoAlt { get; set; }
        /// <summary>
        /// 网站Logo图片
        /// </summary>       
        [DataMember]
        public string WebLogo { get; set; }
        /// <summary>
        /// 网站备案号
        /// </summary>       
        [DataMember]
        public string WebPutonrecord { get; set; }
        /// <summary>
        /// 网站默认关键词
        /// </summary>       
        [DataMember]
        public string WebDefaultKey { get; set; }
        /// <summary>
        /// 网站联系地址
        /// </summary>       
        [DataMember]
        public string WebAddress { get; set; }
        /// <summary>
        /// 网站联系传真
        /// </summary>       
        [DataMember]
        public string WebFax { get; set; }
        /// <summary>
        /// 网站联系电话
        /// </summary>       
        [DataMember]
        public string WebMobile { get; set; }
        /// <summary>
        /// 网站联系固定电话
        /// </summary>       
        [DataMember]
        public string WebPhone { get; set; }
        /// <summary>
        /// 网站联系邮箱
        /// </summary>       
        [DataMember]
        public string WebEmail { get; set; }
        /// <summary>
        /// 网站关于我们描述
        /// </summary>       
        [DataMember]
        public string WebAboutUs { get; set; } 
        #endregion
    }
}
