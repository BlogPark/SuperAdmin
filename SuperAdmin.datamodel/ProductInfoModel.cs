using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SuperAdmin.datamodel
{
    /// <summary>
    /// 产品Model
    /// </summary>
    [Serializable]
    [DataContract]
    public class ProductInfoModel
    {
        #region 原始字段
        /// <summary>
        /// 自增ID
        /// </summary>       
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>       
        [DataMember]
        public string ProductName { get; set; }
        /// <summary>
        /// 产品规格ID
        /// </summary>       
        [DataMember]
        public int ProductSpecID { get; set; }
        /// <summary>
        /// 产品规格名称
        /// </summary>       
        [DataMember]
        public string ProductSpecName { get; set; }
        /// <summary>
        /// 产品属性列表
        /// </summary>       
        [DataMember]
        public string ProductAttributeIDs { get; set; }
        /// <summary>
        /// 产品成本价格
        /// </summary>       
        [DataMember]
        public decimal ProductCostPrice { get; set; }
        /// <summary>
        /// 产品标准价格
        /// </summary>       
        [DataMember]
        public decimal ProductStandardPrice { get; set; }
        /// <summary>
        /// 产品售卖价格
        /// </summary>       
        [DataMember]
        public decimal ProductSalePrice { get; set; }
        /// <summary>
        /// 产品描述
        /// </summary>       
        [DataMember]
        public string ProductDescription { get; set; }
        /// <summary>
        /// 产品大图
        /// </summary>       
        [DataMember]
        public string ProductCoverImg { get; set; }
        /// <summary>
        /// 产品状态
        /// </summary>       
        [DataMember]
        public int ProductStatus { get; set; }
        /// <summary>
        /// 添加人ID
        /// </summary>       
        [DataMember]
        public int AddUserID { get; set; }
        /// <summary>
        /// 添加人名称
        /// </summary>       
        [DataMember]
        public string AddUserName { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>       
        [DataMember]
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 产品分类ID
        /// </summary>       
        [DataMember]
        public int ProductCateID { get; set; }
        /// <summary>
        /// 产品分类名称
        /// </summary>       
        [DataMember]
        public string ProductCateName { get; set; }
        /// <summary>
        /// 产品详细描述
        /// </summary>
        [DataMember]
        public string ProductContent { get; set; }
        #endregion

        /// <summary>
        /// 产品属性列表
        /// </summary>
        [DataMember]
        public List<ProductSimpleAttr> AttrLists { get; set; }
    }
}
