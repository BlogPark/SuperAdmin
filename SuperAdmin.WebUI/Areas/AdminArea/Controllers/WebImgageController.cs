using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperAdmin.DataBLL;
using SuperAdmin.datamodel;
using SuperAdmin.WebUI.Areas.AdminArea.Models;
using SuperAdmin.WebUI.Controllers;
using SuperAdmin.WebUI.Models;

namespace SuperAdmin.WebUI.Areas.AdminArea.Controllers
{
    public class WebImgageController : Controller
    {
        //
        // GET: /AdminArea/WebImgage/
        WebSiteImageBll bll = new WebSiteImageBll();
        public ActionResult Index()
        {
            WebImgageIndexViewModel model = new WebImgageIndexViewModel();
            model.list = bll.GetAllModel();
            model.categories = bll.GetPicCategoryModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddPic(WebSiteImageModel addmodel)
        {
            if (addmodel != null)
            {
                SessionLoginModel user = Session[AppContext.SESSION_LOGIN_NAME] as SessionLoginModel;
                if (user == null)
                {
                    return RedirectToAction("Index", "Login", new { area = "" });
                }
                addmodel.AddTime = DateTime.Now;
                addmodel.AddUserID = user.User.ID;
                addmodel.AddUserName = user.User.UserName;
                int rowid = bll.AddWebSiteImage(addmodel);
            }
            return RedirectToAction("Index", "WebImgage", new { area = "AdminArea" });
        }
        [HttpPost]
        public ActionResult Updpic(WebSiteImageModel updmodel)
        {
            if (updmodel != null)
            {
                SessionLoginModel user = Session[AppContext.SESSION_LOGIN_NAME] as SessionLoginModel;
                if (user == null)
                {
                    return RedirectToAction("Index", "Login", new { area = "" });
                }
                //updmodel.AddTime = DateTime.Now;
                //updmodel.AddUserID = user.User.ID;
                //updmodel.AddUserName = user.User.UserName;
                bool success = bll.UpdateWebSiteImage(updmodel);
            }
            return RedirectToAction("Index", "WebImgage", new { area = "AdminArea" });
        }

        [HttpPost]
        public ActionResult delete(int id)
        {
            if (id > 0)
            {
                bool success = bll.UpdateWebSiteImageStatus(id,0);
                if (success)
                    return Json("1");
            }
            return Json("0");
        }
    }
}
