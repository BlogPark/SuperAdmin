using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperAdmin.datamodel;
using SuperAdmin.DataBLL;
using SuperAdmin.WebUI.Areas.AdminArea.Models;
using SuperAdmin.WebUI.Models;
using SuperAdmin.WebUI.Controllers;

namespace SuperAdmin.WebUI.Areas.AdminArea.Controllers
{
    public class MemberOperaController : Controller
    {
        //后台管理会员页面
        // GET: /AdminArea/MemberOpera/
        MemberOperaBll bll = new MemberOperaBll();
        public ActionResult Index()
        {
            MemberViewModel model = new MemberViewModel();
            model.memberlist = bll.GetAllMemberInfo();
            return View(model);
        }
        /// <summary>
        /// 审核会员
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult checkmember(int mid)
        {
            if (mid > 0)
            {
                SessionLoginModel user = Session[AppContext.SESSION_LOGIN_NAME] as SessionLoginModel;
                MemberInfoModel model = new MemberInfoModel();
                model.ID = mid;
                model.CheckUserID = user.User.ID;
                model.CheckUserName = user.User.UserName;
                int rowcount = bll.CheckMemberStatus(model);
                if (rowcount > 0)
                {
                    return Json("1");
                }
                else
                {
                    return Json("0");
                }
            }
            return Json("0");
        }
        /// <summary>
        /// 禁用会员
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult delmember(int mid)
        {
            if (mid > 0)
            {                
                int rowcount = bll.DelMember(mid);
                if (rowcount > 0)
                {
                    return Json("1");
                }
                else
                {
                    return Json("0");
                }
            }
            return Json("0");
        }
    }
}
