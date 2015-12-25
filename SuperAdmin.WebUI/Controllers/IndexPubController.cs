using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperAdmin.WebUI.Models;

namespace SuperAdmin.WebUI.Controllers
{
    public class IndexPubController : Controller
    {
        //首页公共项目组件
        // GET: /IndexPub/

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 首页左侧菜单
        /// </summary>
        /// <returns></returns>

        public ActionResult Menu()
        {
            SessionLoginModel model = Session[AppContext.SESSION_LOGIN_NAME] as SessionLoginModel;
            MenuViewModel models = new MenuViewModel();
            models.firstlist = model.UserMenus.Where(p => p.FatherID == 0).ToList();
            models.sublist = model.UserMenus.Where(p=>p.FatherID!=0).ToList();
            return View(models);
        }
        /// <summary>
        /// 管理员通知
        /// </summary>
        /// <returns></returns>
        public ActionResult Notification()
        {
            return View();
        }
        /// <summary>
        /// 管理员日程
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminTask()
        {
            return View();
        }
        /// <summary>
        /// 管理员消息
        /// </summary>
        /// <returns></returns>
        public ActionResult Message()
        {
            return View();
        }

    }
}
