﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SuperAdmin.datamodel
{
    /// <summary>
    ///系统菜单
    /// </summary>
    [DataContract]
    public class SysAdminMenuModel
    {
        #region 原有字段
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        [DataMember]
        public string MenuName { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        [DataMember]
        public int FatherID { get; set; }
        /// <summary>
        /// 菜单备注
        /// </summary>
        [DataMember]
        public string MenuAlt { get; set; }
        /// <summary>
        /// 父级名称
        /// </summary>
        [DataMember]
        public string FatherName { get; set; }
        /// <summary>
        /// 菜单链接地址
        /// </summary>
        [DataMember]
        public string LinkUrl { get; set; }
        /// <summary>
        /// 菜单状态
        /// </summary>
        [DataMember]
        public int MenuStatus { get; set; }
        /// <summary>
        /// 排序位置
        /// </summary>
        [DataMember]
        public int SortIndex { get; set; }
        /// <summary>
        /// 菜单类型（1 菜单 2 按钮）
        /// </summary>
        [DataMember]
        public int MenuType { get; set; }
        /// <summary>
        /// 控制器名称
        /// </summary>
        [DataMember]
        public string ControllerName { get; set; }
        /// <summary>
        /// 方法名
        /// </summary>
        [DataMember]
        public string ActionName { get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        [DataMember]
        public string AreaName { get; set; }

        #endregion
    }
}