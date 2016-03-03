using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperWebSite.WebUI.Areas.Article.Controllers
{
    public class ArticlesController : Controller
    {
        //系统资讯部分
        // GET: /Article/Articles/

        public ActionResult Index()
        {
            return View();
        }

    }
}
