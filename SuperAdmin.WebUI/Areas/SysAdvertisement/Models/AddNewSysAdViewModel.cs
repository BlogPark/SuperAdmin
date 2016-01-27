using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using SuperAdmin.datamodel;

namespace SuperAdmin.WebUI.Areas.SysAdvertisement.Models
{
    /// <summary>
    /// 广告信息页面Model
    /// </summary>
    [Serializable]
    [DataContract]
    public class AddNewSysAdViewModel
    {
        /// <summary>
        /// 广告信息
        /// </summary>
        [DataMember]
        public SystemAdModel sysad { get; set; }
        /// <summary>
        /// 系统平台集合
        /// </summary>
        [DataMember]
        public List<SystemAdSiteModel> syssite { get; set; }
    }
}