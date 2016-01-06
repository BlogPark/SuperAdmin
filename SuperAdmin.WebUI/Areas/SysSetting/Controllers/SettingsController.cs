using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperAdmin.DataBLL;
using SuperAdmin.datamodel;
using SuperAdmin.WebUI.Areas.SysSetting.Models;

namespace SuperAdmin.WebUI.Areas.SysSetting.Controllers
{
    public class SettingsController : Controller
    {
        //系统基础设置
        // GET: /SysSetting/Settings/
        private SystemSettingsBll bll = new SystemSettingsBll();
        private SysMenuAndUserBll mbll = new SysMenuAndUserBll();
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 系统用户管理页面
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminUser()
        {
            AdminUserViewModel model = new AdminUserViewModel();
            model.UserLists = bll.GetAllSysAdminUser();
            model.Groups = mbll.GetAllAdminGroup();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddAdminUser(SysAdminUserModel User)
        {
            if (User != null)
            {
                User.HeaderImg = "/img/avatars/avatar3.jpg";
                User.UserPwd = "0000";
                User.GName = User.GName.Trim();
                int rowcount = bll.AddNewSysAdminUser(User);
            }
            return RedirectToAction("AdminUser", "Settings", new { area = "SysSetting" });
        }
        [HttpPost]
        public ActionResult UpdAdminUser(SysAdminUserModel UpdateUser)
        {
            if (UpdateUser != null)
            {
                UpdateUser.GName = UpdateUser.GName.Trim();
                int rowcount = bll.UpdateSysAdminUser(UpdateUser);
            }
            return RedirectToAction("AdminUser", "Settings", new { area = "SysSetting" });
        }


    }
}
