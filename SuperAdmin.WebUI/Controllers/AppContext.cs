using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperAdmin.WebUI.Controllers
{
    public class AppContext
    {
        /// <summary>
        /// 存储用户信息的session名称
        /// </summary>
        public static readonly string SESSION_LOGIN_NAME = "SESSION_LOGIN_NAME";
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
    }
}