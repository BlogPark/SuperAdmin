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
    public  class ArticleTagsModel
    {
        /// <summary>
        /// 关键词ID
        /// </summary>
        [DataMember]
        public int TagID { get; set; }
        /// <summary>
        /// 关键词名称
        /// </summary>
        [DataMember]
        public string TagName { get; set; }
        /// <summary>
        /// 关键词热度
        /// </summary>
        [DataMember]
        public int Hot { get; set; }
    }
}
