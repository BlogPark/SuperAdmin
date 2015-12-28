﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using SuperAdmin.datamodel;

namespace SuperAdmin.WebUI.Areas.AdminMenu.Models
{
    [Serializable]
    [DataContract]
    public class SysAdminGroupViewModel
    {
        /// <summary>
        /// 用户组信息
        /// </summary>
        [DataMember]
        public List<SysAdminUserGroupModel> AdminGroupLists { get; set; }
        /// <summary>
        /// 用户组
        /// </summary>
        [DataMember]
        public SysAdminUserGroupModel AdminGroup { get; set; }
    }
}