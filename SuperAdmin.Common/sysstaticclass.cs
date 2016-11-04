using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace System
{
    /// <summary>
    /// 系统扩展方法类
    /// </summary>
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
        /// <summary>
        /// 计算时间和当前时间的差异
        /// </summary>
        /// <param name="localtime"></param>
        /// <returns></returns>
        public static string DateDiffString(this DateTime localtime)
        {
            string str = localtime.ToString("yyyy-MM-dd HH:mm:ss");
            TimeSpan span = DateTime.Now - localtime;
            if (span.TotalDays > 365)
            {
                str = "一年前";
            }
            else if (span.TotalDays > 60)
            {
                str = "两个月前";
            }
            else if (span.TotalDays > 30)
            {
                str = "一个月前";
            }
            else if (span.TotalDays > 14)
            {
                str = "两周前";
            }
            else if (span.TotalDays > 7)
            {
                str = "一周前";
            }
            else if (span.TotalDays > 1)
            {
                str = string.Format("{0}天前",
                (int)Math.Floor(span.TotalDays));
            }
            else if (span.TotalHours > 1)
            {
                str = string.Format("{0}小时前", (int)Math.Floor(span.TotalHours));
            }
            else if (span.TotalMinutes > 1)
            {
                str = string.Format("{0}分钟前", (int)Math.Floor(span.TotalMinutes));
            }
            return str;
        }
    }
}
