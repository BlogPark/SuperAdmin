using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SuperAdmin.datamodel
{
    /// <summary>
    /// 产品规格属性表
    /// </summary>
    [Serializable]
    [DataContract]
    public class ProductSpecModel
    {
        #region 原始字段
        /// <summary>
        /// 自增主键
        /// </summary>       
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>       
        [DataMember]
        public string SpecName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>       
        [DataMember]
        public string SpecDecription { get; set; }
        /// <summary>
        /// 类型(1 规格 2 属性)
        /// </summary>       
        [DataMember]
        public int SpecType { get; set; }
        /// <summary>
        /// 状态(1 激活 0 删除)
        /// </summary>       
        [DataMember]
        public int SpecStatus { get; set; }
        /// <summary>
        /// 添加人ID
        /// </summary>       
        [DataMember]
        public int AdduserID { get; set; }
        /// <summary>
        /// 添加人名称
        /// </summary>       
        [DataMember]
        public string AdduserName { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>       
        [DataMember]
        public DateTime AddTime { get; set; }
        #endregion
        /// <summary>
        /// 状态名称
        /// </summary>
        [DataMember]
        public string SpecStatusName { get; set; }
    }
}
