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
    public  class WebSiteCommentsModel
    {
        #region 原始字段
        /// <summary>
        /// 自增主键
        /// </summary>       
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 对象ID
        /// </summary>       
        [DataMember]
        public long ObjectID { get; set; }
        /// <summary>
        /// 对象类型（1 文章 2 商品）
        /// </summary>       
        [DataMember]
        public int ObjectType { get; set; }
        /// <summary>
        /// 对象名称
        /// </summary>       
        [DataMember]
        public string ObjectName { get; set; }
        /// <summary>
        /// 会员ID
        /// </summary>       
        [DataMember]
        public int MemberID { get; set; }
        /// <summary>
        /// 会员名称
        /// </summary>       
        [DataMember]
        public string MemberName { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>       
        [DataMember]
        public string ComCentent { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>       
        [DataMember]
        public DateTime Addtime { get; set; }
        /// <summary>
        /// 评论状态（1 激活 0 删除）
        /// </summary>       
        [DataMember]
        public int ComStatus { get; set; }

        #endregion

        #region 扩展字段
        /// <summary>
        /// 状态名称
        /// </summary>
        [DataMember]
        public string ComStatusName { get; set; }
        #endregion
    }
}
