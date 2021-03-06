﻿using System;
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
        /// 产品状态(1 已发布2 已下架3 已删除)
        /// </summary>       
        [DataMember]
        public int ProductStatus { get; set; }
        /// <summary>
        /// 产品状态名称(1 已发布2 已下架3 已删除)
        /// </summary>       
        [DataMember]
        public string ProductStatusName { get; set; }
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
        /// <summary>
        /// 产品副图
        /// </summary>
        [DataMember]
        public string ProductSmallPic { get; set; }
        /// <summary>
        /// 是否推荐
        /// </summary>
        [DataMember]
        public int _IsCommend=10;

        public int IsCommend
        {
            get { return _IsCommend; }
            set { _IsCommend = value; }
        }
        /// <summary>
        /// 是否推荐
        /// </summary>
        [DataMember]
        public string IsCommendName { get; set; }
        #endregion

        /// <summary>
        /// 产品属性列表
        /// </summary>
        [DataMember]
        public List<ProductSimpleAttr> AttrLists { get; set; }
        /// <summary>
        /// 页容量
        /// </summary>
        [DataMember]
        public int PageSize { get; set; }
        /// <summary>
        /// 页索引
        /// </summary>
        [DataMember]
        public int PageIndex { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        [DataMember]
        public DateTime? begintime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        [DataMember]
        public DateTime? endtime { get; set; }
        /// <summary>
        /// 产品幅图列表
        /// </summary>
        [DataMember]
        public List<string> prosmallpic { get; set; }
    }
}
