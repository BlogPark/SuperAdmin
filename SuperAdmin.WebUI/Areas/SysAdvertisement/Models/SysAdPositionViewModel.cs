using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using SuperAdmin.datamodel;

namespace SuperAdmin.WebUI.Areas.SysAdvertisement.Models
{
    /// <summary>
    /// 系统广告位置
    /// </summary>
    [Serializable]
    [DataContract]
    public class SysAdPositionViewModel
    {
        /// <summary>
        /// 位置信息
        /// </summary>
        [DataMember]
        public List<SystemAdPositionModel> positions { get; set; }
        /// <summary>
        /// 添加位置信息
        /// </summary>
        [DataMember]
        public SystemAdPositionModel addposition { get; set; }
        /// <summary>
        /// 修改位置信息
        /// </summary>
        [DataMember]
        public SystemAdPositionModel updateposition { get; set; }
        /// <summary>
        /// 系统平台集合
        /// </summary>
        [DataMember]
        public List<SystemAdSiteModel> syssite { get; set; }
    }
}