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
    public class SiteMsgController : Controller
    {
        //系统消息管理页面
        // GET: /AdminArea/SiteMsg/
        AdminSiteNewsBll bll = new AdminSiteNewsBll();
        public ActionResult Index()
        {
            SessionLoginModel user = Session[AppContext.SESSION_LOGIN_NAME] as SessionLoginModel;
            if (user == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            SiteMsgIndexViewModel model = new SiteMsgIndexViewModel();
            model.msglist = bll.GetTop3ModelListByUserID(user.User.ID);
            return View(model);
        }
        /// <summary>
        /// 查看消息页面
        /// </summary>
        /// <param name="nid"></param>
        /// <returns></returns>
        public ActionResult NewsView(int nid)
        {
            if (nid == 0)
            {
                return RedirectToAction("Index", "SiteMsg", new { area = "AdminArea" });
            }
            bll.UpdateStatus(nid, 2);//更新该消息为已读
            NewViewPagViewModel model = new NewViewPagViewModel();
            model.sitenewmodel = bll.GetModel(nid);
            return View(model);
        }
        /// <summary>
        /// 发布新消息
        /// </summary>
        /// <param name="newmodel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult publishnews(AdminSiteNewsModel newmodel)
        {
            if (newmodel == null)
            {
                return RedirectToAction("Index", "SiteMsg", new { area = "AdminArea" });
            }
            SessionLoginModel user = Session[AppContext.SESSION_LOGIN_NAME] as SessionLoginModel;
            if (user == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            newmodel.SStatus = 1;
            newmodel.SendUserName = user.User.UserName;
            newmodel.SendUserID = user.User.ID;
            int newid = bll.AddAdminSiteNew(newmodel);
            return RedirectToAction("Index", "SiteMsg", new { area = "AdminArea" });
        }
    }
}
