using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SuperAdmin.datamodel
{
    /// <summary>
    /// 文章分类
    /// </summary>
    [Serializable]
    [DataContract]
    public class ArtCategoryModel
    {
        #region 原表字段
        /// <summary>
        /// ID
        /// </summary>       
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>       
        [DataMember]
        public string CName { get; set; }
        /// <summary>
        /// 状态
        /// </summary>       
        [DataMember]
        public int CStatus { get; set; }
        /// <summary>
        /// 添加人ID
        /// </summary>       
        [DataMember]
        public int AddUserID { get; set; }
        /// <summary>
        /// AddUserName
        /// </summary>       
        [DataMember]
        public string AddUserName { get; set; }
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
        public string CStatusName { get; set; }
    }
}
