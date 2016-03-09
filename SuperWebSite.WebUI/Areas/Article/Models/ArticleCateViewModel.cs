using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using SuperAdmin.datamodel;

namespace SuperWebSite.WebUI.Areas.Article.Models
{
    [Serializable]
    [DataContract]
    public class ArticleCateViewModel
    {
        [DataMember]
        public int CateID { get; set; }

        [DataMember]
        public string CateName { get; set; }

        [DataMember]
        public List<ArticlesModel> Articles { get; set; }

        [DataMember]
        public int page { get; set; }

        [DataMember]
        public int pagecount { get; set; }

        [DataMember]
        public int recordcount { get; set; }

        [DataMember]
        public string pageparam { get; set; }

        [DataMember]
        public int PageSize { get; set; }
    }
}