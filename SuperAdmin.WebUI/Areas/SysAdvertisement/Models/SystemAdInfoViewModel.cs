using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using SuperAdmin.datamodel;

namespace SuperAdmin.WebUI.Areas.SysAdvertisement.Models
{
    /// <summary>
    /// 系统广告内容
    /// </summary>
    [Serializable]
    [DataContract]
    public class SystemAdInfoViewModel
    {
        /// <summary>
        /// 全部广告内容
        /// </summary>
        [DataMember]
        public List<SystemAdModel> Adlists { get; set; }
        /// <summary>
        /// 添加广告信息
        /// </summary>
        [DataMember]
        public SystemAdModel AddAdinfo { get; set; }
        /// <summary>
        /// 修改广告信息
        /// </summary>
        [DataMember]
        public SystemAdModel UpdAdinfo { get; set; }
    }
}