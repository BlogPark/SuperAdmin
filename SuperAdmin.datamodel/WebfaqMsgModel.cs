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
    public class WebfaqMsgModel
    {
        #region 原有字段
        /// <summary>
        /// 主键自增
        /// </summary>
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [DataMember]
        public string FTitle { get; set; }
        /// <summary>
        /// 答案
        /// </summary>
        [DataMember]
        public string FAnswerContent { get; set; }
        /// <summary>
        /// 状态（1 显示 0 隐藏）
        /// </summary>
        [DataMember]
        public int FStatus { get; set; }
        /// <summary>
        /// 回答人ID   
        /// </summary>
        [DataMember]
        public int FAnswerId { get; set; }
        /// <summary>
        /// 回答人名称
        /// </summary>
        [DataMember]
        public string FAnswerName { get; set; }
        /// <summary>
        /// 回答时间
        /// </summary>
        [DataMember]
        public DateTime FAnswerTime { get; set; }

        #endregion
        /// <summary>
        /// 状态值名称
        /// </summary>
        [DataMember]
        public string FStatusName { get; set; }
    }
}
