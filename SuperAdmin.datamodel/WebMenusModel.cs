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
    public class WebMenusModel
    {
        /// <summary>
        /// ID
        /// </summary>       
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>       
        [DataMember]
        public string MenuName { get; set; }
        /// <summary>
        /// 上级ID
        /// </summary>       
        [DataMember]
        public int FatherID { get; set; }
        /// <summary>
        /// 上级菜单名称
        /// </summary>
        [DataMember]
        public string FatherName { get; set; }
        /// <summary>
        /// 菜单描述
        /// </summary>       
        [DataMember]
        public string MenuAlt { get; set; }
        /// <summary>
        /// 链接地址
        /// </summary>       
        [DataMember]
        public string LinkUrl { get; set; }
        /// <summary>
        /// 状态(1 激活 0 隐藏)
        /// </summary>       
        [DataMember]
        public int MenuStatus { get; set; }
        /// <summary>
        /// 排序
        /// </summary>       
        [DataMember]
        public int SortIndex { get; set; }
        /// <summary>
        /// 控制器名称
        /// </summary>       
        [DataMember]
        public string ControllerName { get; set; }
        /// <summary>
        /// Action名称
        /// </summary>       
        [DataMember]
        public string ActionName { get; set; }
        /// <summary>
        /// 分区名称
        /// </summary>       
        [DataMember]
        public string AreaName { get; set; }
        /// <summary>
        /// 添加人ID
        /// </summary>       
        [DataMember]
        public int AddUserID { get; set; }
        /// <summary>
        /// 添加人名称
        /// </summary>       
        [DataMember]
        public string AddUserName { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>       
        [DataMember]
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 菜单图标
        /// </summary>       
        [DataMember]
        public string MenuIcon { get; set; }
        /// <summary>
        /// 引用图片
        /// </summary>       
        [DataMember]
        public string QuoteImage { get; set; }
        /// <summary>
        /// 引用文字
        /// </summary>       
        [DataMember]
        public string QuoteText { get; set; }
    }
}
