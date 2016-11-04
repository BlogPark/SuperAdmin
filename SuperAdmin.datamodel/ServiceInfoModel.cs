using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SuperAdmin.datamodel
{
    /// <summary>
    /// 服务器信息
    /// </summary>
    [Serializable]
    [DataContract]
    public class ServiceInfoModel
    {
        /// <summary>
        /// 服务器名称
        /// </summary>
        [DataMember]
        public string ServerName { get; set; }
        /// <summary>
        /// 服务器IP地址
        /// </summary>
        [DataMember]
        public string ServerIPAdd { get; set; }
        /// <summary>
        /// 服务器端口
        /// </summary>
        [DataMember]
        public string ServerPort { get; set; }
        /// <summary>
        /// 服务器IIS版本
        /// </summary>
        [DataMember]
        public string ServerIISversion { get; set; }
        /// <summary>
        /// 本文件所在文件夹
        /// </summary>
        [DataMember]
        public string LocalFloder { get; set; }
        /// <summary>
        /// 服务器操作系统
        /// </summary>
        [DataMember]
        public string ServerSysversion { get; set; }
        /// <summary>
        /// .NET Framework 版本
        /// </summary>
        [DataMember]
        public string ServerNetversion { get; set; }
        /// <summary>
        /// 服务器当前时间
        /// </summary>
        [DataMember]
        public string ServerLocalTime { get; set; }
        /// <summary>
        /// 服务器IE版本
        /// </summary>
        [DataMember]
        public string ServerIEversion { get; set; }
        /// <summary>
        /// 当前Session数量
        /// </summary>
        [DataMember]
        public int ServerSessionCount { get; set; }
        /// <summary>
        /// 当前服务器内存容量
        /// </summary>
        [DataMember]
        public string ServerRAMCapacity { get; set; }
        /// <summary>
        /// 当前程序占用内存量
        /// </summary>
        [DataMember]
        public long RAMCount { get; set; }
    }
}
