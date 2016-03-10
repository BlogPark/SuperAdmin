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
    public class SplitTagModel
    {
        [DataMember]
        public long TagID { get; set; }
        [DataMember]
        public string TagName { get; set; }
        [DataMember]
        public int RepeatTime { get; set; }
        [DataMember]
        public int hot { get; set; }
    }
}
