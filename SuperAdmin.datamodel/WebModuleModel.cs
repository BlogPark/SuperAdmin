using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SuperAdmin.datamodel
{
    /// <summary>
    /// 前端模块管理
    /// </summary>
    [Serializable]
    [DataContract]
    public class WebModuleModel
    {
        /// <summary>
        /// ID
        /// </summary>       
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 模块名称
        /// </summary>       
        [DataMember]
        public string ModuleName { get; set; }
        /// <summary>
        /// 模块描述
        /// </summary>       
        [DataMember]
        public string ModuleDescription { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>       
        [DataMember]
        public int ModuleWidth { get; set; }
        /// <summary>
        /// 高度
        /// </summary>       
        [DataMember]
        public int ModuleHeight { get; set; }
        /// <summary>
        /// 状态(1 显示 0 隐藏)
        /// </summary>       
        [DataMember]
        public int ModuleStatus { get; set; }
        /// <summary>
        /// 添加人ID
        /// </summary>       
        [DataMember]
        public int AddUserID { get; set; }
        /// <summary>
        /// 添加人名字
        /// </summary>       
        [DataMember]
        public string AddUserName { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>       
        [DataMember]
        public DateTime AddTime { get; set; }
    }
}
