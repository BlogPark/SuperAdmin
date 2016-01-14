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
    public class UploadFileModel
    {
        [DataMember]
        public string error { get; set; }
        [DataMember]
        public List<string> errorkeys { get; set; }
        [DataMember]
        public List<string> initialPreview { get; set; }
        [DataMember]
        public List<InitialPreviewConfig> initialPreviewConfig { get; set; }
        [DataMember]
        public bool append { get; set; }
    }
    [Serializable]
    [DataContract]
    public class InitialPreviewConfig
    {
        [DataMember]
        public string caption { get; set; }
        [DataMember]
        public string width { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string key { get; set; }
        [DataMember]
        public string extra { get; set; }
    }
}
