using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SuperAdmin.WebUI.Areas.SysAdvertisement.Models
{
    [Serializable]
    [DataContract]
    public class AddNewSysAdViewModel
    {
        [DataMember]
        [Required]
        public HttpPostedFileBase File { get; set; }
    }
}