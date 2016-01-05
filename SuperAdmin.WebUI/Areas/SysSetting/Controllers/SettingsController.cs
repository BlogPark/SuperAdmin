using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperAdmin.WebUI.Areas.SysSetting.Controllers
{
    public class SettingsController : Controller
    {
        //系统基础设置
        // GET: /SysSetting/Settings/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminUser()
        {
            return View();
        }
    }
}
