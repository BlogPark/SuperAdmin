using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperAdmin.Common;
using SuperAdmin.datamodel;

namespace SuperAdmin.WebUI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

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
    }
}
