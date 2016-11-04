using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SuperAdmin.datamodel
{
    /// <summary>
    /// 产品属性表
    /// </summary>
    [Serializable]
    [DataContract]
    public class ProductAttributesModel
    {
        #region 原始字段
        /// <summary>
        /// 自增主键
        /// </summary>       
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 产品ID
        /// </summary>       
        [DataMember]
        public int ProductID { get; set; }
        /// <summary>
        /// 产品属性名
        /// </summary>       
        [DataMember]
        public string ProductAttrKey { get; set; }
        /// <summary>
        /// 产品属性值
        /// </summary>       
        [DataMember]
        public string ProductAttrValue { get; set; }
        /// <summary>
        /// 状态（1 启用 0 禁用）
        /// </summary>       
        [DataMember]
        public int AttrStatus { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>       
        [DataMember]
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 是否重要
        /// </summary>       
        [DataMember]
        public int IsImportent { get; set; }
        /// <summary>
        /// 产品属性描述
        /// </summary>       
        [DataMember]
        public string ProductAttrDescript { get; set; } 
        #endregion
    }

    [Serializable]
    [DataContract]
    public class ProductSimpleAttr
    {
        /// <summary>
        /// 属性名
        /// </summary>
        [DataMember]
        public string AttrKey { get; set; }
        /// <summary>
        /// 属性值
        /// </summary>
        [DataMember]
        public string AttrValue { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [DataMember]
        public string descript { get; set; }
    }
}
