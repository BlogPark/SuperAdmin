using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperAdmin.DataBLL;
using SuperAdmin.WebUI.Areas.AdminArea.Models;

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

    }
}
