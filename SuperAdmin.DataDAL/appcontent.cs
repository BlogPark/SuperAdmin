using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperAdmin.DataDAL
{
    public class appcontent
    {
        /// <summary>
        /// 图片上传路径
        /// </summary>
        public static string UploadPath = System.Configuration.ConfigurationManager.AppSettings["uploadpath"];
        /// <summary>
        /// 存放图片的域名称
        /// </summary>
        public static string Imgdomain = System.Configuration.ConfigurationManager.AppSettings["imgdomain"];
        /// <summary>
        /// 允许上传文件类型
        /// </summary>
        public static string ImgType = System.Configuration.ConfigurationManager.AppSettings["imgtype"];
        /// <summary>
        /// 默认空图
        /// </summary>
        public static string DefaultEmptyImg = System.Configuration.ConfigurationManager.AppSettings["defaultemptyimg"];
    }
}
