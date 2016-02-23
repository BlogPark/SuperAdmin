using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using SuperAdmin.datamodel;

namespace SuperAdmin.WebUI.Areas.AdminArea.Models
{
    /// <summary>
    /// 系统公告页面Model
    /// </summary>
    [Serializable]
    [DataContract]
    public class SysnoticeIndexViewModel
    {
        [DataMember]
        public List<SysNoticeMessageModel> modellist { get; set; }
        [DataMember]
        public SysNoticeMessageModel addmodel { get; set; }
    }
}