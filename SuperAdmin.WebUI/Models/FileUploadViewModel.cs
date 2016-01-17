using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SuperAdmin.WebUI.Models
{
    [Serializable]
    [DataContract]
    public class FileUploadViewModel
    {
        [Required]
        [DataMember]
        public HttpPostedFileBase File { get; set; }

        [DataMember]
        public string FilePath { get; set; }

        [DataMember]
        public int Width { get; set; }

        [DataMember]
        public int Height { get; set; }

    }
}