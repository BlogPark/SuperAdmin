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
using System.Runtime.Serialization.Json;
using System.Text;

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
        //[HttpGet]
        //public ActionResult AjaxUploadArticlePices()
        //{
        //    FileUploadViewModel model = new FileUploadViewModel();
        //    return PartialView(model);
        //}
        /// <summary>
        /// 异步上传图片接口
        /// 增加对宽度和比例的限制
        /// 比例限制在 参数的上下0.5范围内浮动，不在此范围的为不合格
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AjaxUploadArticlePices()
        {
            //string state = "fail";  //状态

            int c = Request.Files.Count;
            ////上传配置
            //int size = 2048;           //文件大小限制,单位MB                  //文件大小限制，单位MB 
            string msg = "/Areas/Admin/Content/images/actives/1.jpg";


            return Json(new { filename="ssssss"});
        }
        public static string JsonSerializer<T>(T t)
        {

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));

            MemoryStream ms = new MemoryStream();

            ser.WriteObject(ms, t);

            string jsonString = Encoding.UTF8.GetString(ms.ToArray());

            ms.Close();

            return jsonString;

        }
    }
}
