using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperAdmin.WebUI.Areas.AdminArea.Models;
using SuperAdmin.DataBLL;
using SuperAdmin.datamodel;
using SuperAdmin.WebUI.Models;
using SuperAdmin.WebUI.Controllers;

namespace SuperAdmin.WebUI.Areas.AdminArea.Controllers
{
    public class FrontSettingController : Controller
    {
        //
        // GET: /AdminArea/FrontSetting/
        SystemSettingsBll bll = new SystemSettingsBll();
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 编辑网站基础信息
        /// </summary>
        /// <returns></returns>
        public ActionResult BaseData()
        {
            WebSettingViewModel model = new WebSettingViewModel();
            model.settings = bll.GetWebSetting();
            ViewBag.PageTitle = "编辑基础信息";
            return View(model);
        }
        /// <summary>
        /// 前端基本设置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult BaseData(WebSettingViewModel model)
        {
            if (model.settings != null)
            {
                int rowcount = bll.UpdateWebSetting(model.settings);
            }
            model.settings = bll.GetWebSetting();
            
            return View(model);
        }
        /// <summary>
        ///  前端模块管理
        /// </summary>
        /// <returns></returns>
        public ActionResult WebModules()
        {
            WebModuleViewModel model = new WebModuleViewModel();
            model.list = bll.GetAllWebModules();
            ViewBag.PageTitle = "网站模块管理";
            return View(model);
        }
        /// <summary>
        /// 添加网页位置
        /// </summary>
        /// <returns></returns>
        public ActionResult AddModule()
        {
            return View();
        }
        /// <summary>
        /// 添加网页位置
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddModule(WebModuleModel addmodel)
        {
            if (addmodel != null)
            {
                SessionLoginModel user = Session[AppContext.SESSION_LOGIN_NAME] as SessionLoginModel;
                addmodel.AddUserID = user.User.ID;
                addmodel.AddUserName = user.User.UserName;
                int rowcount = bll.AddWebModule(addmodel);
            }
            return RedirectToAction("WebModules", "FrontSetting", new { area = "AdminArea" });
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdModule(WebModuleModel updatemodel)
        {
            if (updatemodel != null)
            {
                int rowcount = bll.UpdateWebModule(updatemodel);
            }
            return RedirectToAction("WebModules", "FrontSetting", new { area = "AdminArea" });
        }
        /// <summary>
        /// 前端菜单管理
        /// </summary>
        /// <returns></returns>
        public ActionResult WebMenu()
        {
            WebMenuViewModel model = new WebMenuViewModel();
            model.fatherlist = bll.GetAllFirstWebMenu();
            model.list = bll.GetAllWebMenusList();
            ViewBag.PageTitle = "网站菜单管理";
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddMenu(WebMenusModel addmenu)
        {
            SessionLoginModel user = Session[AppContext.SESSION_LOGIN_NAME] as SessionLoginModel;
            if (addmenu != null)
            {
                addmenu.AddUserID = user.User.ID;
                addmenu.AddUserName = user.User.UserName;
                int rowcount = bll.AddWebMenu(addmenu);
            }
            return RedirectToAction("WebMenu", "FrontSetting", new { area = "AdminArea" });
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdMenu(WebMenusModel updatemenu)
        {
            if (updatemenu != null)
            {
                int rowcount = bll.UpdateWebMenu(updatemenu);
            }
            return RedirectToAction("WebMenu", "FrontSetting", new { area = "AdminArea" });
        }
    }
}
