﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using SuperAdmin.datamodel;

namespace SuperAdmin.WebUI.Models
{
    [DataContract]
    public class SessionLoginModel
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        [DataMember]
        public SysAdminUserModel User { get; set; }
        /// <summary>
        /// 用户菜单信息
        /// </summary>
        [DataMember]
        public List<SysAdminMenuModel> UserMenus { get; set; }
    }
}