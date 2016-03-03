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
    public class WebSiteImageModel
    {
        #region 原始字段
        /// <summary>
        /// 主键自增
        /// </summary>       
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 图片名称
        /// </summary>       
        [DataMember]
        public string PicName { get; set; }
        /// <summary>
        /// 图片标签
        /// </summary>       
        [DataMember]
        public string PicTags { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>       
        [DataMember]
        public string PicUrl { get; set; }
        /// <summary>
        /// 图片宽度
        /// </summary>       
        [DataMember]
        public int PicWidth { get; set; }
        /// <summary>
        /// 图片高度
        /// </summary>       
        [DataMember]
        public int PicHeight { get; set; }
        /// <summary>
        /// 图片状态
        /// </summary>       
        [DataMember]
        public int PicStatus { get; set; }
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
        /// 添加时间
        /// </summary>       
        [DataMember]
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 分类ID
        /// </summary>       
        [DataMember]
        public int PicCateID { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>       
        [DataMember]
        public string PicCateName { get; set; } 
        #endregion

        #region 扩展字段
        /// <summary>
        /// 状态名称
        /// </summary>
        [DataMember]
        public string PicStatusName { get; set; }
        /// <summary>
        /// 带域名图片地址
        /// </summary>
        [DataMember]
        public string PicUrlStr { get; set; }
        #endregion
    }
}
