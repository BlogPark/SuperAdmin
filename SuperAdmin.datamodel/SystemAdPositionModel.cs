using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SuperAdmin.datamodel
{
    /// <summary>
    /// 系统位置
    /// </summary>
    [Serializable]
    [DataContract]
    public class SystemAdPositionModel
    {
        /// <summary>
        /// 自增主键
        /// </summary>       
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 位置名称
        /// </summary>       
        [DataMember]
        public string PName { get; set; }
        /// <summary>
        /// 所属站点ID
        /// </summary>       
        [DataMember]
        public int AdSiteID { get; set; }
        /// <summary>
        /// 所属站点名称
        /// </summary>       
        [DataMember]
        public string AdSiteName { get; set; }
        /// <summary>
        /// 位置宽度
        /// </summary>       
        [DataMember]
        public int PWidth { get; set; }
        /// <summary>
        /// 位置高度
        /// </summary>       
        [DataMember]
        public int PHeight { get; set; }
        /// <summary>
        /// 位置类型（1 首页 2 子页 3 固定位置）
        /// </summary>       
        [DataMember]
        public int PType { get; set; }
        /// <summary>
        /// 状态值（1 激活 0 禁用）
        /// </summary>
        [DataMember]
        public int PStatus { get; set; }
    }
}
