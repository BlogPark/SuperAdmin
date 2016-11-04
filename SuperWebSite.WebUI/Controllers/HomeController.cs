using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperWebSite.WebUI.Controllers
{
    public class HomeController : Controller
    {
        //首页相关信息
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }


    }
}
