using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperAdmin.Common;
using SuperAdmin.datamodel;
using SuperAdmin.WebUI.Models;

namespace SuperAdmin.WebUI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
       
        public ActionResult Index()
        {
             SessionLoginModel user = Session[AppContext.SESSION_LOGIN_NAME] as SessionLoginModel;
            if (user == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            ServiceInfoModel server = new ServiceInfoModel();
            server.ServerName=System.Net.Dns.GetHostName();
            server.ServerIPAdd = System.Net.Dns.Resolve(server.ServerName).AddressList[0].ToString();
            server.ServerSysversion = System.Environment.OSVersion.Version.ToString();
            server.ServerRAMCapacity = "";
            server.RAMCount = System.Environment.WorkingSet;
            server.ServerLocalTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            server.ServerSysversion = "";
            HomeIndexViewModel model = new HomeIndexViewModel();
            model.LocalUser = user.User;
            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UploadFiles()
        {
            int filecount = Request.Files.Count;
            if (filecount > 0)
            {
                var file = Request.Files[0];
                //上传配置
                int size = 2048;           //文件大小限制,单位MB                  //文件大小限制，单位MB 
                string[] filetype = AppContext.ImgType.Split(',');         //文件允许格式
                string path = AppContext.UploadPath.TrimEnd('\\') + "\\";     //文件上传路径             
                UploadFileModel uploadImage = UploadHelper.LocalUpLoadForSingle(file, path, filetype, size, "");
                if (uploadImage.status == "success")
                {
                    return Json(new { status = true, filename = uploadImage.filename, imgwidth = uploadImage.width, imgheight = uploadImage.height, urlpath = AppContext.Imgdomain + uploadImage.filepath, path = uploadImage.filepath });
                }
                else
                {
                    return Json(new { status = false, meg = uploadImage.message });
                }
            }
            else
            {
                return Json(new { status = false, meg = "未获得文件" });
            }
        }
        /// <summary>
        /// 上传并生成套图
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UploadSuitFiles()
        {
            int filecount = Request.Files.Count;
            if (filecount > 0)
            {
                var file = Request.Files[0];
                //上传配置
                int size = 2048;           //文件大小限制,单位MB                  //文件大小限制，单位MB 
                string[] filetype = AppContext.ImgType.Split(',');         //文件允许格式
                string path = AppContext.UploadPath.TrimEnd('\\') + "\\";     //文件上传路径             
                string picjson = "";
                UploadFileModel uploadImage = UploadHelper.UpLoadForSaveSuitjpg(file, path, filetype, out picjson, size,true);
                if (uploadImage.status == "success")
                {
                    return Json(new { status = true, filename = uploadImage.filename, imgwidth = uploadImage.width, imgheight = uploadImage.height, urlpath = AppContext.Imgdomain + uploadImage.filepath, path = uploadImage.filepath,picjson=picjson });
                }
                else
                {
                    return Json(new { status = false, meg = uploadImage.message });
                }
            }
            else
            {
                return Json(new { status = false, meg = "未获得文件" });
            }
        }
       
    }
}
