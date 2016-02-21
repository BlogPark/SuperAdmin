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
        SystemSettingsBll userbll = new SystemSettingsBll();
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
        /// <summary>
        /// 发布消息页面
        /// </summary>
        /// <returns></returns>
        public ActionResult sendmsg()
        {
            sendmsgViewModel model = new sendmsgViewModel();
            SessionLoginModel user = Session[AppContext.SESSION_LOGIN_NAME] as SessionLoginModel;
            if (user == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            List<SysAdminUserModel> users = userbll.GetAllSysAdminUser().Where(p => p.UserStatus == 1 && p.ID != user.User.ID).ToList();
            model.systemusers = users;
            var result = from m in users
                         orderby m.FirstPinYin
                         group m by m.FirstPinYin into g
                         select g.Key;
            model.pingroup = result.ToList();
            return View(model);
        }

        /// <summary>
        /// 设置紧急
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult setUrgent(int id)
        {
            if (id < 1)
                return Json("0");
            bool success = bll.SetUrgent(id, 1);
            if (success)
            {
                return Json("1");
            }
            else
            {
                return Json("0");
            }
        }
        /// <summary>
        /// 设置置顶
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult settop(int id)
        {
            if (id < 1)
                return Json("0");
            bool success = bll.SetIsTop(id, 1);
            if (success)
            {
                return Json("1");
            }
            else
            {
                return Json("0");
            }
        }
    }
}
