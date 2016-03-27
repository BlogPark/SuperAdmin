using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperAdmin.DataBLL;
using SuperAdmin.WebUI.Models;
using SuperAdmin.Common;
using SuperAdmin.datamodel;
using System.Json;
using Newtonsoft.Json;
using System.IO;
using System.Web.Script.Serialization;
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
        public ActionResult Menu(string currentpage)
        {
            SessionLoginModel model = Session[AppContext.SESSION_LOGIN_NAME] as SessionLoginModel;
            string idstr = "";
            idstr = string.Join(",", model.UserMenus.Where(p => p.MenuType == 1).Select(p => p.FatherID).Distinct());
            MenuViewModel models = new MenuViewModel();
            models.firstlist = bll.GetSysMenuByIds(idstr.TrimEnd(','));
            models.sublist = model.UserMenus.Where(p => p.FatherID != 0).ToList();
            models.Currentpage = currentpage;
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
            SessionLoginModel user = Session[AppContext.SESSION_LOGIN_NAME] as SessionLoginModel;
            partMessageViewModel model = new partMessageViewModel();
            AdminSiteNewsBll bll = new AdminSiteNewsBll();
            List<AdminSiteNewsModel> list = bll.GetTop3ModelListByUserID(user.User.ID);
            model.newmsglist = list.Where(m => m.SStatus == 1).ToList();
            model.newcount = model.newmsglist.Count;
            model.oldmsglist = list.Where(m => m.SStatus == 2).ToList();
            return View(model);
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

        public ActionResult mytest()
        {
            return View();
        }

    }
}
