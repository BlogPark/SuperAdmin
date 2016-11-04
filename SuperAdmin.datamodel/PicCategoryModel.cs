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
    public class PicCategoryModel
    {
        /// <summary>
        /// ID
        /// </summary>       
        [DataMember]
        public int ID { get; set; }
        /// <summary>
        /// PiccName
        /// </summary>       
        [DataMember]
        public string PiccName { get; set; }
        /// <summary>
        /// PiccStatus
        /// </summary>       
        [DataMember]
        public int PiccStatus { get; set; }
        /// <summary>
        /// Addtime
        /// </summary>       
        [DataMember]
        public DateTime Addtime { get; set; }
        /// <summary>
        /// AddUserID
        /// </summary>       
        [DataMember]
        public int AddUserID { get; set; }
    }
}
