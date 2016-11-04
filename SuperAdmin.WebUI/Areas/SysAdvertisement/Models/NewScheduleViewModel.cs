using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using SuperAdmin.datamodel;

namespace SuperAdmin.WebUI.Areas.SysAdvertisement.Models
{
    [Serializable]
    [DataContract]
    public class NewScheduleViewModel
    {
        /// <summary>
        /// 添加排期
        /// </summary>
        [DataMember]
        public SystemAdScheduleModel addmodel { get; set; }
        /// <summary>
        /// 平台信息
        /// </summary>
        public List<SystemAdSiteModel> sites { get; set; }
    }
}