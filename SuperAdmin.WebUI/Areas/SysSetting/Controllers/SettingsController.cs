using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperAdmin.Common;
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
                string pinyin = PinYinConverter.Get(User.UserName.Trim());
                User.PinYin = pinyin;
                User.FirstPinYin = string.IsNullOrWhiteSpace(pinyin) ? "A" : pinyin.Substring(0,1);
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
                string pinyin = PinYinConverter.Get(UpdateUser.UserName.Trim());
                UpdateUser.PinYin = pinyin;
                UpdateUser.FirstPinYin = string.IsNullOrWhiteSpace(pinyin) ? "A" : pinyin.Substring(0, 1);
                int rowcount = bll.UpdateSysAdminUser(UpdateUser);
            }
            return RedirectToAction("AdminUser", "Settings", new { area = "SysSetting" });
        }
        [HttpPost]
        public JsonResult DelAdminUser(int id)
        {
            int rowcount = bll.DelSysAdminUser(id);
            if (rowcount > 0)
            {
                return Json("1");
            }
            else
            {
                return Json("0");
            }
        }
        /// <summary>
        /// 系统配置项
        /// </summary>
        /// <returns></returns>
        public ActionResult SysConfigs()
        {
            SysConfigsViewModel model = new SysConfigsViewModel();
            model.Allconfigs = bll.GetAllConfigs();
            model.FatherConfigs = bll.GetFirstConfigs();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddSysConfigs(SysAdminConfigsModel AConfig)
        {
            if (AConfig != null)
            {
                int rowcount = bll.AddConfigInfo(AConfig);
            }
            return RedirectToAction("SysConfigs", "Settings", new { area = "SysSetting" });
        }
         [HttpPost]
        public ActionResult UpdateConfigs(SysAdminConfigsModel UConfig)
        {
            if (UConfig != null)
            {
                int rowcount = bll.UpdateConfigs(UConfig);
            }
            return RedirectToAction("SysConfigs", "Settings", new { area = "SysSetting" });
        }
         [HttpPost]
        public ActionResult DelConfigs(int id)
        {
            int rowcount = bll.DelConfig(id);
            if (rowcount > 0)
                return Json("1");
            else
                return Json("0");
        }
    }
}
