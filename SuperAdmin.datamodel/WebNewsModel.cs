using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SuperAdmin.datamodel
{
    [Serializable]
    [DataContract]
    public class WebNewsModel
    {
        #region 原表字段
        /// <summary>
        /// 主键ID
        /// </summary>       
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>       
        [DataMember]
        public string NTitle { get; set; }
        /// <summary>
        /// 新闻内容
        /// </summary>       
        [DataMember]
        public string NContent { get; set; }
        /// <summary>
        /// 状态(0 新建 1 已发布 2 已删除)
        /// </summary>       
        [DataMember]
        public int NStatus { get; set; }
        /// <summary>
        /// 添加人ID
        /// </summary>       
        [DataMember]
        public int NAddUser { get; set; }
        /// <summary>
        /// 添加人名称
        /// </summary>       
        [DataMember]
        public string NAddUserName { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>       
        [DataMember]
        public DateTime NAddTime { get; set; } 
        #endregion
        #region 扩展字段
        /// <summary>
        /// 状态名称
        /// </summary>
        [DataMember]
        public string StatusName { get; set; }
        #endregion
    }
}
