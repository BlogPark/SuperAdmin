using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SuperAdmin.datamodel
{
    /// <summary>
    /// 系统广告排期
    /// </summary>
    [Serializable]
    [DataContract]
    public class SystemAdScheduleModel
    {
        #region 原表字段
        /// <summary>
        /// ID
        /// </summary>       
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 排期名称
        /// </summary>       
        [DataMember]
        public string ScheduleName { get; set; }
        /// <summary>
        /// 站点ID
        /// </summary>       
        [DataMember]
        public int AdSiteID { get; set; }
        /// <summary>
        /// 位置ID
        /// </summary>       
        [DataMember]
        public int AdPID { get; set; }
        /// <summary>
        /// 广告ID
        /// </summary>       
        [DataMember]
        public int AdID { get; set; }
        /// <summary>
        /// 所属区域
        /// </summary>       
        [DataMember]
        public string AreaName { get; set; }
        /// <summary>
        /// 控制器名称
        /// </summary>       
        [DataMember]
        public string ControllerName { get; set; }
        /// <summary>
        /// 方法名称
        /// </summary>       
        [DataMember]
        public string ActionName { get; set; }
        /// <summary>
        /// 特定字符串
        /// </summary>       
        [DataMember]
        public string GivenID { get; set; }
        /// <summary>
        /// 广告中间间隔数目
        /// </summary>       
        [DataMember]
        public int IntervalNum { get; set; }
        /// <summary>
        /// 排期开始时间
        /// </summary>       
        [DataMember]
        public DateTime StarTime { get; set; }
        /// <summary>
        /// 排期结束时间
        /// </summary>       
        [DataMember]
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>       
        [DataMember]
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 添加人ID
        /// </summary>       
        [DataMember]
        public int AddUserID { get; set; }
        /// <summary>
        /// 添加人名字
        /// </summary>       
        [DataMember]
        public string AddUserName { get; set; }
        /// <summary>
        /// 客户姓名
        /// </summary>
        [DataMember]
        public string ClientName { get; set; }
        /// <summary>
        /// 客户邮箱
        /// </summary>
        [DataMember]
        public string ClientEmail { get; set; }
        /// <summary>
        /// 客户联系方式
        /// </summary>
        [DataMember]
        public string ClientPhone { get; set; }
        /// <summary>
        /// 状态（0 未审核 1 已审核 2 已作废）
        /// </summary>
        [DataMember]
        public int SeStatus { get; set; } 
        #endregion

        #region 扩展字段
        /// <summary>
        /// 状态名称
        /// </summary>
        [DataMember]
        public string SeStatusName { get; set; }
        /// <summary>
        /// 平台名称
        /// </summary>
        [DataMember]
        public string SiteName { get; set; }
        /// <summary>
        /// 位置名称
        /// </summary>
        [DataMember]
        public string PositionName { get; set; }
        /// <summary>
        /// 广告标题
        /// </summary>
        [DataMember]
        public string AdTitle { get; set; }
        #endregion
    }
}
