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
    public class webfaqController : Controller
    {
        //系统常见问题管理类
        // GET: /AdminArea/webfaq/
        WebfaqMsgBll bll = new WebfaqMsgBll();
        public ActionResult Index()
        {
            webfaqindexViewModel model = new webfaqindexViewModel();
            model.list = bll.GetAllDataModel();
            ViewBag.PageTitle = "留言管理";
            return View(model);
        }
        /// <summary>
        /// 新增信息
        /// </summary>
        /// <param name="addmodel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Addnewdata(WebfaqMsgModel addmodel)
        {
            if (addmodel != null)
            {
                SessionLoginModel user = Session[AppContext.SESSION_LOGIN_NAME] as SessionLoginModel;
                if (user == null)
                {
                    return RedirectToAction("Index", "Login", new { area = "" });
                }
                if (!string.IsNullOrWhiteSpace(addmodel.FAnswerContent))
                {
                    addmodel.FAnswerId = user.User.ID;
                    addmodel.FAnswerName = user.User.UserName;
                    addmodel.FAnswerTime = DateTime.Now;
                }
                addmodel.FStatus = 1;
                int id = bll.AddWebfaqMsg(addmodel);
            }
            return RedirectToAction("Index", "webfaq", new { area = "AdminArea" });
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="updmodel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Updatedata(WebfaqMsgModel updmodel)
        {
            if (updmodel != null)
            {
                SessionLoginModel user = Session[AppContext.SESSION_LOGIN_NAME] as SessionLoginModel;
                if (user == null)
                {
                    return RedirectToAction("Index", "Login", new { area = "" });
                }
                if (!string.IsNullOrWhiteSpace(updmodel.FAnswerContent))
                {
                    updmodel.FAnswerId = user.User.ID;
                    updmodel.FAnswerName = user.User.UserName;
                    updmodel.FAnswerTime = DateTime.Now;
                }
                bool success = bll.UpdateWebfaqMsg(updmodel);
            }
            return RedirectToAction("Index", "webfaq", new { area = "AdminArea" });
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult deletedata(int id)
        {
            if (id > 0)
            {
                bool success = bll.DeleteWebfaqMsg(id, 0);
                if (success)
                    return Json("1");
                else
                    return Json("0");
            }
            return Json("0");
        }
    }
}
