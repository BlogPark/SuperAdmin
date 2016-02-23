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
    public class SysNoticeController : Controller
    {
        //系统公告管理页面
        // GET: /AdminArea/SysNotice/
        SysNoticeMessageBll bll = new SysNoticeMessageBll();
        public ActionResult Index()
        {
            SysnoticeIndexViewModel model = new SysnoticeIndexViewModel();
            model.modellist = bll.GetAllSysNotice();
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult addnotice(SysNoticeMessageModel addmodel)
        {
            if (addmodel == null)
            {
                return RedirectToAction("Index", "SysNotice", new { area = "AdminArea" });
            }
            SessionLoginModel user = Session[AppContext.SESSION_LOGIN_NAME] as SessionLoginModel;
            if (user == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            addmodel.LaunchPeopleID = user.User.ID;
            addmodel.LaunchPeopleName = user.User.UserName;
            addmodel.NoticeStatus = 1;
            int id = bll.AddSysNotice(addmodel);
            return RedirectToAction("Index", "SysNotice", new { area = "AdminArea" });
        }

        [HttpPost]
        public ActionResult delenotice(int id)
        {
            if (id == 0)
            {
                return Json("0");
            }
            bool success = bll.UpdateSysNoticeStatus(id, 0);
            if (success)
            {
                return Json("1");
            }
            else { return Json("0"); }
        }
    }
}
