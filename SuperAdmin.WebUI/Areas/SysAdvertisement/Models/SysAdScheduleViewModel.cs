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
    public class SysAdScheduleViewModel
    {
        /// <summary>
        /// 系统排期列表
        /// </summary>
        [DataMember]
        public List<SystemAdScheduleModel> schedules { get; set; }
    }
}