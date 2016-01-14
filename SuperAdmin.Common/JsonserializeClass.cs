using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SuperAdmin.Common
{
    public  class JsonserializeClass
    {
        public static string ModelToString<T>(T t)
        {
            string jsonString = string.Empty;
            jsonString = JsonConvert.SerializeObject(t);
            return jsonString;
        }
    }
}
