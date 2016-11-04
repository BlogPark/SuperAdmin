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
    public class SysNoticeMessageModel
    {
        #region 原表字段
        /// <summary>
        /// ID
        /// </summary>       
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 公告标题
        /// </summary>       
        [DataMember]
        public string NoticeTitle { get; set; }
        /// <summary>
        /// 公告类型(1后台 2 前端 )
        /// </summary>       
        [DataMember]
        public int NoticeType { get; set; }
        /// <summary>
        /// 添加人ID
        /// </summary>       
        [DataMember]
        public int LaunchPeopleID { get; set; }
        /// <summary>
        /// 添加人名字
        /// </summary>       
        [DataMember]
        public string LaunchPeopleName { get; set; }
        /// <summary>
        /// 公告内容
        /// </summary>       
        [DataMember]
        public string NoticeContent { get; set; }
        /// <summary>
        /// 发起时间
        /// </summary>       
        [DataMember]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 失效时间
        /// </summary>       
        [DataMember]
        public DateTime LoseTime { get; set; }
        /// <summary>
        /// 排序
        /// </summary>       
        [DataMember]
        public int Sort { get; set; }
        /// <summary>
        /// 公告状态(0 删除 1 发表)
        /// </summary>       
        [DataMember]
        public int NoticeStatus { get; set; }
        #endregion
        /// <summary>
        /// 状态名称
        /// </summary>
        [DataMember]
        public string NoticeStatusName { get; set; }
    }
}
