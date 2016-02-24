using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperAdmin.WebUI.Areas.AdminArea.Models;
using SuperAdmin.DataBLL;
using SuperAdmin.datamodel;
using SuperAdmin.WebUI.Models;
using SuperAdmin.WebUI.Controllers;
using SuperAdmin.Common;
namespace SuperAdmin.WebUI.Areas.AdminArea.Controllers
{
    public class WebNewsController : Controller
    {
        //网站新闻管理
        // GET: /AdminArea/WebNews/
        WebNewsBll bll = new WebNewsBll();
        public ActionResult Index()
        {
            WebSplitWords sp = new WebSplitWords();
            string ss = sp.DoSegmentToJsonstr("安稳中国张成航");
            WebNewsIndexViewModel model = new WebNewsIndexViewModel();
            model.list = bll.GetAllModelList();
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult addnews(WebNewsModel addmodel)
        {
            if (addmodel == null)
            {
               return RedirectToAction("Index");
            }
            SessionLoginModel user = Session[AppContext.SESSION_LOGIN_NAME] as SessionLoginModel;
            if (user == null)
            {
                return RedirectToAction("Index", "Login", new { area=""});
            }
            addmodel.NAddUser = user.User.ID;
            addmodel.NAddUserName = user.User.UserName;
            int rowcount = bll.AddWebNews(addmodel);
            return RedirectToAction("Index");
        }
        /// <summary>
        /// 审核一条信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult verify(int id)
        {
            if (id < 1)
            {
                return Json("0");
            }
            bool issuccess = bll.UpdateWebnewsStatus(id,1);
            if (issuccess)
                return Json("1");
            else
                return Json("0");
        }
        /// <summary>
        /// 删除一条信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult delete(int id)
        {
            if (id < 1)
            {
                return Json("0");
            }
            bool issuccess = bll.UpdateWebnewsStatus(id, 2);
            if (issuccess)
                return Json("1");
            else
                return Json("0");
        }
    }
}
