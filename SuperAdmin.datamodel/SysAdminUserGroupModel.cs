using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SuperAdmin.datamodel
{
    /// <summary>
    /// 系统用户组
    /// </summary>
    [DataContract]
    public class SysAdminUserGroupModel
    {

        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 组名称
        /// </summary>
        [DataMember]
        public string GroupName { get; set; }
        /// <summary>
        /// 组说明
        /// </summary>
        [DataMember]
        public string GroupAlt { get; set; }
        /// <summary>
        /// 组状态 (1 启用 0 禁用)
        /// </summary>
        [DataMember]
        public int GroupStatus { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        [DataMember]
        public DateTime Addtime { get; set; }

    }
}
