using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace System
{
    public static class sysstaticclass
    {
        /// <summary>
        /// 去掉字符串中的HTML标签
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RexReplace(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return "";
            }
            Regex nr7 = new Regex(@"<[\s\S]*?>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            str = nr7.Replace(str, "");
            return str;
        }
    }
}
