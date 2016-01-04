using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using SuperAdmin.datamodel;

namespace SuperAdmin.WebUI.Areas.AdminMenu.Models
{
    [Serializable]
    [DataContract]
    public class AddPermissionsViewModel
    {
        /// <summary>
        /// 所有一级菜单
        /// </summary>
        [DataMember]
        public List<SysAdminMenuModel> FirstMenuLists { get; set; }
        /// <summary>
        /// 所有二级菜单
        /// </summary>
        [DataMember]
        public List<SysAdminMenuModel> SecondMenuLists { get; set; }
        /// <summary>
        /// 所有菜单按钮
        /// </summary>
        [DataMember]
        public List<SysAdminMenuModel> ButtonMenuLists { get; set; }
        /// <summary>
        /// 所有权限菜单
        /// </summary>
        [DataMember]
        public List<SysAdminGrouprMenuModel> AllPermissionMenu { get; set; }
    }
}