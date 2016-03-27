using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using SuperAdmin.datamodel;

namespace SuperAdmin.WebUI.Models
{
    [DataContract]
    public class MenuViewModel
    {
        [DataMember]
        public List<SysAdminMenuModel> firstlist { get; set; }

        [DataMember]
        public List<SysAdminMenuModel> sublist { get; set; }

        [DataMember]
        public string Currentpage { get; set; }



    }
}