using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperAdmin.DataBLL;
using SuperAdmin.WebUI.Models;
using SuperAdmin.datamodel;

namespace SuperAdmin.WebUI.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        private SysMenuAndUserBll bll = new SysMenuAndUserBll();
        [HttpGet]
        public ActionResult Index(string returnurl)
        {
            LoginViewModel model = new LoginViewModel();
            model.returnurl = returnurl;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            SysAdminUserModel user = new SysAdminUserModel();
            user.LoginName = model.LoginId;
            user.UserPwd = model.Pass;
            SysAdminUserModel result = bll.GetUserForLogin(user);
            if (result.LoginResult.StartsWith("0"))
            {
                model.loginresult = result.LoginResult.Substring(1);
            }
            else
            {
                List<SysAdminMenuModel> usermenu = bll.GetUserAttributeMenu(result);
                result.UserPwd = "";
                SessionLoginModel sessionmodel = new SessionLoginModel();
                sessionmodel.User = result;
                sessionmodel.UserMenus = usermenu;
                Session[AppContext.SESSION_LOGIN_NAME] = sessionmodel;
                if (!string.IsNullOrWhiteSpace(model.returnurl))
                {
                    return Redirect(model.returnurl);
                }
                else
                {
                    return RedirectToAction("Index", "Home", new { area = "" });
                }              
            }
            return View(model);
        }

    }
}
