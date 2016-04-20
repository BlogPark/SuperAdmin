using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SuperAdmin.datamodel
{
    /// <summary>
    /// 产品分类
    /// </summary>
    [Serializable]
    [DataContract]
    public class ProductCategoryModel
    {
        #region 原始字段
        /// <summary>
        /// 自增主键
        /// </summary>       
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>       
        [DataMember]
        public string CateName { get; set; }
        /// <summary>
        /// 状态
        /// </summary>       
        [DataMember]
        public int CateStatus { get; set; }
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
        /// 分类简介
        /// </summary>       
        [DataMember]
        public string CateDescription { get; set; }
        #endregion
        /// <summary>
        /// 状态名称
        /// </summary>
        [DataMember]
        public string CateStatusName { get; set; }
    }
}
