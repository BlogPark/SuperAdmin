using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperAdmin.WebUI.Areas.SysAdvertisement.Controllers
{
    public class SysAdManageController : Controller
    {
        //
        // GET: /SysAdvertisement/SysAdManage/

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 系统广告
        /// </summary>
        /// <returns></returns>
        public ActionResult SysAdInfo()
        {
            return View();
        }
    }
}
