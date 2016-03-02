using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperAdmin.WebUI.Areas.AdminArea.Models;

namespace SuperAdmin.WebUI.Areas.AdminArea.Controllers
{
    public class WebImgageController : Controller
    {
        //
        // GET: /AdminArea/WebImgage/

        public ActionResult Index()
        {
            WebImgageIndexViewModel model = new WebImgageIndexViewModel();
            return View(model);
        }

    }
}
