using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using SuperAdmin.datamodel;

namespace SuperAdmin.WebUI.Areas.SysSetting.Models
{
    /// <summary>
    /// 系统配置项页面
    /// </summary>
    [Serializable]
    [DataContract]
    public class SysConfigsViewModel
    {
        /// <summary>
        /// 全部配置项
        /// </summary>
        [DataMember]
        public List<SysAdminConfigsModel> Allconfigs { get; set; }
        /// <summary>
        /// 配置项
        /// </summary>
        [DataMember]
        public SysAdminConfigsModel AConfig { get; set; }
        /// <summary>
        /// 修改配置项
        /// </summary>
        [DataMember]
        public SysAdminConfigsModel UConfig { get; set; }
        /// <summary>
        /// 父级配置项
        /// </summary>
        [DataMember]
        public List<SysAdminConfigsModel> FatherConfigs { get; set; }
    }
}