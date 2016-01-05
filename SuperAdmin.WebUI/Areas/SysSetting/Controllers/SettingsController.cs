using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperAdmin.DataBLL;
using SuperAdmin.datamodel;

namespace SuperAdmin.WebUI.Areas.SysSetting.Controllers
{
    public class SettingsController : Controller
    {
        //系统基础设置
        // GET: /SysSetting/Settings/
        private SystemSettingsBll bll = new SystemSettingsBll();
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 系统用户管理页面
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminUser()
        {
            return View();
        }
    }
}
