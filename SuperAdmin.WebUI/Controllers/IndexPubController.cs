using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperAdmin.DataBLL;
using SuperAdmin.WebUI.Models;
using SuperAdmin.Common;
using SuperAdmin.datamodel;
using System.IO;

namespace SuperAdmin.WebUI.Controllers
{
    public class IndexPubController : Controller
    {
        //首页公共项目组件
        // GET: /IndexPub/
        private SysMenuAndUserBll bll = new SysMenuAndUserBll();
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 首页左侧菜单
        /// </summary>
        /// <returns></returns>
        public ActionResult Menu()
        {
            SessionLoginModel model = Session[AppContext.SESSION_LOGIN_NAME] as SessionLoginModel;
            string idstr = "";
            idstr = string.Join(",", model.UserMenus.Where(p => p.MenuType == 1).Select(p => p.FatherID).Distinct());
            MenuViewModel models = new MenuViewModel();
            models.firstlist = bll.GetSysMenuByIds(idstr.TrimEnd(','));
            models.sublist = model.UserMenus.Where(p => p.FatherID != 0).ToList();
            return View(models);
        }
        /// <summary>
        /// 管理员通知
        /// </summary>
        /// <returns></returns>
        public ActionResult Notification()
        {
            return View();
        }
        /// <summary>
        /// 管理员日程
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminTask()
        {
            return View();
        }
        /// <summary>
        /// 管理员消息
        /// </summary>
        /// <returns></returns>
        public ActionResult Message()
        {
            return View();
        }
        /// <summary>
        /// 管理员信息
        /// </summary>
        /// <returns></returns>
        public ActionResult UserInfo()
        {
            SessionLoginModel model = Session[AppContext.SESSION_LOGIN_NAME] as SessionLoginModel;
            return View(model.User);
        }

        public ActionResult LoginOut()
        {
            Session.Clear();// Session[AppContext.SESSION_LOGIN_NAME] = null;
            return RedirectToAction("Index", "Login", new { returnurl = "" });
        }
        [HttpGet]
        public ActionResult AjaxUploadArticlePices()
        {
            FileUploadViewModel model = new FileUploadViewModel();
            return View(model);
        }
        /// <summary>
        /// 异步上传图片接口
        /// 增加对宽度和比例的限制
        /// 比例限制在 参数的上下0.5范围内浮动，不在此范围的为不合格
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AjaxUploadArticlePices(FileUploadViewModel model)
        {
            //string state = "fail";  //状态

            int c = Request.Files.Count;
            ////上传配置
            //int size = 2048;           //文件大小限制,单位MB                  //文件大小限制，单位MB 
            string msg = "/Areas/Admin/Content/images/actives/1.jpg";

            using (MemoryStream uploadedFile = new MemoryStream())
            {
                model.File.InputStream.CopyTo(uploadedFile);
                //uploadService.UploadFile(uploadedFile, model.File.ContentType)
                //return View();
            }
            //var fi = file;
            //if (Request.Files.Count > 0)
            //{
            //    //return Json(new { status = "1" }, "text/html");
            //    //return Content("ssssssssss"); 
            //    ViewBag.msg = "ssssssssssssssssss";
            //    return Json("1");
            //}
            //else
            //{

            //return Json(new { status = "-1" }, "text/html");
            //    //return Content("eeeeeeee");
            //    ViewBag.msg = "eeeeeeeeeeeeeeeeeee";
            //    return Json("0");
            //}
            //string url = "";        //网络路径
            //string picpath = "";    //相对路径
            //int width = 0;          //宽度
            //int height = 0;         //高度
            //string articlePicStr = "";
            //var uploadImage = BaseUpLoad.LocalUpLoadForSavejpg(uploadFile, path, filetype, out articlePicStr, size, true, true);
            //if (uploadImage != null && uploadImage.State == "success" && uploadImage.Image.Count > 0)
            //{
            //    state = "SUCCESS";
            //    string imageUrl = uploadImage.Image[0].Path;
            //    picpath = "/media" + imageUrl;
            //    url = AppConf.dna_picUrl.TrimEnd('/') + picpath;
            //    width = uploadImage.Image[0].Width;
            //    height = uploadImage.Image[0].Height;
            //}
            //return Json(new { result = "success" });
         
            //return Content(msg, "application/json");
            model.Height = 10;
            model.Width = 100;
            model.FilePath = "sssssssssssss";
            return View(model);

        }
    }
}
