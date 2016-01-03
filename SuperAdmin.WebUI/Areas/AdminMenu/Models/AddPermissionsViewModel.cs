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
        /// 所有菜单
        /// </summary>
        [DataMember]
        public List<SysAdminMenuModel> MenuLists { get; set; }
        /// <summary>
        /// 所有权限菜单
        /// </summary>
        [DataMember]
        public List<SysAdminGrouprMenuModel> AllPermissionMenu { get; set; }
    }
}