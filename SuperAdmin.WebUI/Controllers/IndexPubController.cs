using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View();
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
