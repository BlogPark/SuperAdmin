using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperAdmin.DataBLL;
using SuperAdmin.WebUI.Areas.AdminArea.Models;

namespace SuperAdmin.WebUI.Areas.AdminArea.Controllers
{
    public class webfaqController : Controller
    {
        //系统常见问题管理类
        // GET: /AdminArea/webfaq/
        WebfaqMsgBll bll = new WebfaqMsgBll();
        public ActionResult Index()
        {
            webfaqindexViewModel model = new webfaqindexViewModel();
            model.list = bll.GetAllDataModel();
            return View(model);
        }

    }
}
