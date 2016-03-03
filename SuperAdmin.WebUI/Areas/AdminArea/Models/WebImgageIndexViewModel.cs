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
    public class WebImgageIndexViewModel
    {
        [DataMember]
        public List<WebSiteImageModel> list { get; set; }
        [DataMember]
        public WebSiteImageModel addmodel { get; set; }
        [DataMember]
        public WebSiteImageModel updmodel { get; set; }
        [DataMember]
        public List<PicCategoryModel> categories { get; set; }
    }
}