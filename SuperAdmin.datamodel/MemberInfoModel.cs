using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SuperAdmin.datamodel
{
    /// <summary>
    /// 会员信息
    /// </summary>
    [Serializable]
    [DataContract]
    public  class MemberInfoModel
    {
        #region 原表字段
        /// <summary>
        /// 自增主键
        /// </summary>       
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 会员名
        /// </summary>       
        [DataMember]
        public string MemberName { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>       
        [DataMember]
        public string MPassword { get; set; }
        /// <summary>
        /// 性别
        /// </summary>       
        [DataMember]
        public string Mgender { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>       
        [DataMember]
        public string MEmail { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>       
        [DataMember]
        public DateTime MRegisterTime { get; set; }
        /// <summary>
        /// 会员状态（100 等待审核 200 审核通过 300 账户停用）
        /// </summary>       
        [DataMember]
        public int MStatus { get; set; }
        /// <summary>
        /// 审核人ID
        /// </summary>       
        [DataMember]
        public int CheckUserID { get; set; }
        /// <summary>
        /// 审核人名字
        /// </summary>       
        [DataMember]
        public string CheckUserName { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>       
        [DataMember]
        public DateTime CheckTime { get; set; }
        /// <summary>
        /// 头像
        /// </summary>       
        [DataMember]
        public string HeadImg { get; set; }
        /// <summary>
        /// 联系信息
        /// </summary>       
        [DataMember]
        public string ContactMsg { get; set; }
        /// <summary>
        /// 会员等级(1 普通 2 银牌 3 金牌 4 至尊VIP)
        /// </summary>       
        [DataMember]
        public int MGrade { get; set; }
        /// <summary>
        /// 上次登录时间
        /// </summary>       
        [DataMember]
        public DateTime LastLoginTime { get; set; }
        /// <summary>
        /// 上次登录IP
        /// </summary>       
        [DataMember]
        public string LastLoginIP { get; set; }
        /// <summary>
        /// 证件照
        /// </summary>       
        [DataMember]
        public string Paperworkpic { get; set; }
        /// <summary>
        /// 证件照
        /// </summary>       
        [DataMember]
        public string PaperworkImg { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>       
        [DataMember]
        public string TruethName { get; set; } 
        #endregion

        #region 扩展字段
        /// <summary>
        /// 状态名称
        /// </summary>
        [DataMember]
        public string MstatusName { get; set; }
        /// <summary>
        /// 会员等级名称
        /// </summary>
        [DataMember]
        public string MGradeName { get; set; }
        #endregion
    }
}
