using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using SuperAdmin.datamodel;

namespace SuperAdmin.WebUI.Areas.AdminArea.Models
{
    [Serializable]
    [DataContract]
    public class MemberViewModel
    {
        /// <summary>
        /// 会员列表
        /// </summary>
        [DataMember]
        public List<MemberInfoModel> memberlist { get; set; }
    }
}