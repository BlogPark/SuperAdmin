using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using SuperAdmin.datamodel;

namespace SuperAdmin.WebUI.Areas.AdminArea.Models
{
    [Serializable]
    [DataContract]
    public class ArticleCategoryViewModel
    {
        [DataMember]
        public List<ArtCategoryModel> list { get; set; }
        [DataMember]
        public ArtCategoryModel addmodel { get; set; }
    }
}