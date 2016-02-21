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
    public class sendmsgViewModel
    {
        /// <summary>
        /// 添加信息
        /// </summary>
        [DataMember]
        public AdminSiteNewsModel newmodel { get; set; }
        /// <summary>
        /// 系统用户
        /// </summary>
        [DataMember]
        public List<SysAdminUserModel> systemusers { get; set; }
        /// <summary>
        /// 拼音group
        /// </summary>
        [DataMember]
        public List<string> pingroup { get; set; }
    }
}