using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using SuperAdmin.datamodel;

namespace SuperAdmin.WebUI.Models
{
    [Serializable]
    [DataContract]
    public class HomeIndexViewModel
    {
        /// <summary>
        /// 服务器信息
        /// </summary>
        [DataMember]
        public ServiceInfoModel LocalServer { get; set; }
        /// <summary>
        /// 登录用户信息
        /// </summary>
        [DataMember]
        public SysAdminUserModel LocalUser { get; set; }
    }
}