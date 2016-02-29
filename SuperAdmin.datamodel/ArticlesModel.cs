using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SuperAdmin.datamodel
{
    /// <summary>
    /// 文章信息
    /// </summary>
    [Serializable]
    [DataContract]
    public class ArticlesModel
    {
        #region 原表字段
        /// <summary>
        /// ID
        /// </summary>       
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 文章标题
        /// </summary>       
        [DataMember]
        public string ArtTitle { get; set; }
        /// <summary>
        /// 会员ID
        /// </summary>       
        [DataMember]
        public int MemberID { get; set; }
        /// <summary>
        /// 会员名字
        /// </summary>       
        [DataMember]
        public string MemberName { get; set; }
        /// <summary>
        /// 文章主图
        /// </summary>       
        [DataMember]
        public string ArtPic { get; set; }
        /// <summary>
        /// 主图宽度
        /// </summary>       
        [DataMember]
        public int ArtPicWidth { get; set; }
        /// <summary>
        /// 主图高度
        /// </summary>       
        [DataMember]
        public int ArtPicHeight { get; set; }
        /// <summary>
        /// 文章摘要
        /// </summary>       
        [DataMember]
        public string ArtSummary { get; set; }
        /// <summary>
        /// 文章内容
        /// </summary>       
        [DataMember]
        public string ArtContent { get; set; }
        /// <summary>
        /// 文章关键词
        /// </summary>       
        [DataMember]
        public string ArtTags { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>       
        [DataMember]
        public DateTime ArtPublishTime { get; set; }
        /// <summary>
        /// 文章状态(10 待审 20 已审 30 反审)
        /// </summary>       
        [DataMember]
        public int ArtStatus { get; set; }
        /// <summary>
        /// 文章类型(1 原创文章 2 原创图集 3 广告软文 4 引用文章 5 引用图集)
        /// </summary>       
        [DataMember]
        public int ArtType { get; set; }
        /// <summary>
        /// 收藏数量
        /// </summary>       
        [DataMember]
        public int ArtFavoriteCount { get; set; }
        /// <summary>
        /// 评论数量
        /// </summary>       
        [DataMember]
        public int ArtCommentCount { get; set; }
        /// <summary>
        /// 点击数量
        /// </summary>       
        [DataMember]
        public int ArtHitCount { get; set; }
        /// <summary>
        /// 文章图集内容
        /// </summary>       
        [DataMember]
        public string ArtAlbumJson { get; set; }
        /// <summary>
        /// 文章外链
        /// </summary>       
        [DataMember]
        public string ArtOuterchain { get; set; }
        /// <summary>
        /// 文章来源
        /// </summary>       
        [DataMember]
        public string ArtFrom { get; set; }
        /// <summary>
        /// 来源URL
        /// </summary>       
        [DataMember]
        public string ArtFromUrl { get; set; }
        /// <summary>
        /// 反审原因
        /// </summary>       
        [DataMember]
        public string AntitrialReasons { get; set; }
        /// <summary>
        /// 审核人
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
        /// 添加时间
        /// </summary>       
        [DataMember]
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 分类ID
        /// </summary>       
        [DataMember]
        public int ArtCID { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>       
        [DataMember]
        public string ArtCName { get; set; }
        /// <summary>
        /// 用户关键词
        /// </summary>
        [DataMember]
        public string ArtUserTags { get; set; }
        /// <summary>
        /// 是否图集
        /// </summary>
        [DataMember]
        public int ArtIsAlbum { get; set; }
        /// <summary>
        /// 是否置顶
        /// </summary>
        [DataMember]
        public int ArtIsTop { get; set; }
        #endregion

        #region 扩展字段
        /// <summary>
        /// 状态名称
        /// </summary>
        [DataMember]
        public string ArtStatusName { get; set; }
        /// <summary>
        /// 文章状态
        /// </summary>
        [DataMember]
        public string ArtTypeName { get; set; }
        #endregion
    }
}
