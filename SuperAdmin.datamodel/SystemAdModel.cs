using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SuperAdmin.datamodel
{
    /// <summary>
    /// 系统广告
    /// </summary>
    [Serializable]
    [DataContract]
    public class SystemAdModel
    {
        /// <summary>
        /// 主键自增
        /// </summary>       
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 广告标题
        /// </summary>       
        [DataMember]
        public string AdTitle { get; set; }
        /// <summary>
        /// 广告类型(1 图片广告 2  图文广告)
        /// </summary>       
        [DataMember]
        public int AdType { get; set; }
        /// <summary>
        /// 广告宽度
        /// </summary>       
        [DataMember]
        public int AdWidth { get; set; }
        /// <summary>
        /// 广告区域高度
        /// </summary>       
        [DataMember]
        public int AdHeight { get; set; }
        /// <summary>
        /// 广告描述
        /// </summary>       
        [DataMember]
        public string AdSummary { get; set; }
        /// <summary>
        /// 广告图片
        /// </summary>       
        [DataMember]
        public string AdPic { get; set; }
        /// <summary>
        /// 广告区背景图
        /// </summary>       
        [DataMember]
        public string AdBackgroundPic { get; set; }
        /// <summary>
        /// 链接目标地址
        /// </summary>       
        [DataMember]
        public string AdLinkUrl { get; set; }
        /// <summary>
        /// 广告区源代码
        /// </summary>       
        [DataMember]
        public string AdSourceCode { get; set; }
        /// <summary>
        /// 广告区备注
        /// </summary>       
        [DataMember]
        public string AdRemark { get; set; }
        /// <summary>
        /// 广告区状态(0 禁用 1 启用)
        /// </summary>       
        [DataMember]
        public int AdStatus { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>       
        [DataMember]
        public DateTime AdAddTime { get; set; }
        /// <summary>
        /// 平台ID
        /// </summary>       
        [DataMember]
        public int AdSiteID { get; set; }
        /// <summary>
        /// 平台名称
        /// </summary>       
        [DataMember]
        public string AdSiteName { get; set; }
        /// <summary>
        /// 添加人
        /// </summary>       
        [DataMember]
        public int AddUserID { get; set; }
        /// <summary>
        /// 添加人名字
        /// </summary>       
        [DataMember]
        public string AddUserName { get; set; }
        /// <summary>
        /// 状态名称
        /// </summary>
        [DataMember]
        public string AdStatusName { get;set;}
    }
    /// <summary>
    /// 系统站点
    /// </summary>
    [Serializable]
    [DataContract]
    public class SystemAdSiteModel 
    {
        /// <summary>
        /// 站点Id
        /// </summary>       
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 站点名称
        /// </summary>       
        [DataMember]
        public string AdSiteName { get; set; }
        /// <summary>
        /// 状态值（0 禁用 1 启用）
        /// </summary>       
        [DataMember]
        public int AdSiteState { get; set; }
    }
}
