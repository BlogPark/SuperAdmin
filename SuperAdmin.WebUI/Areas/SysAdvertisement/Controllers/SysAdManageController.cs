using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperAdmin.WebUI.Areas.SysAdvertisement.Models;
using SuperAdmin.DataBLL;
using SuperAdmin.datamodel;
using SuperAdmin.WebUI.Models;
using SuperAdmin.WebUI.Controllers;

namespace SuperAdmin.WebUI.Areas.SysAdvertisement.Controllers
{
    public class SysAdManageController : Controller
    {
        //
        // GET: /SysAdvertisement/SysAdManage/
        private SysAdManagerBll bll = new SysAdManagerBll();
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 系统广告
        /// </summary>
        /// <returns></returns>
        public ActionResult SysAdInfo()
        {
            SystemAdInfoViewModel model = new SystemAdInfoViewModel();
            model.Adlists = bll.GetAllSystemAd();
            model.AddAdinfo = new SystemAdModel();
            model.UpdAdinfo = new SystemAdModel();
            return View(model);
        }
        /// <summary>
        /// 添加系统广告
        /// </summary>
        /// <returns></returns>
        public ActionResult AddSysAd()
        {
            AddNewSysAdViewModel model = new AddNewSysAdViewModel();
            model.syssite = bll.GetAllSysSites();
            return View(model);
        }
        /// <summary>
        /// 添加系统广告信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddSysAd(AddNewSysAdViewModel model)
        {
            if (model.sysad == null)
            {
                model.syssite = bll.GetAllSysSites();
                return View(model);
            }
            SessionLoginModel user = Session[AppContext.SESSION_LOGIN_NAME] as SessionLoginModel;
            SystemAdModel s = model.sysad;
            s.AdAddTime = DateTime.Now;
            s.AddUserID = user.User.ID;
            s.AddUserName = user.User.UserName;
            s.AdStatus = 1;
            int rowcount = bll.AddNewSystemAd(s);
            if (rowcount > 0)
            {
                return RedirectToAction("SysAdInfo", "SysAdManage", new { area = "SysAdvertisement" });
            }
            else
            {
                model.syssite = bll.GetAllSysSites();
                return View(model);
            }
        }
        /// <summary>
        /// 修改广告信息
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateAdInfo(int aid)
        {
            UpdateAdViewModel model = new UpdateAdViewModel();
            model.sysad = bll.GetSingleSystemAd(aid);
            model.syssite = bll.GetAllSysSites();
            return View(model);
        }
        /// <summary>
        /// 修改广告信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateAdInfo(UpdateAdViewModel model)
        {
            if (model.sysad != null)
            {
                int rowcount = bll.UpdateSystemAd(model.sysad);
            }
            return RedirectToAction("SysAdInfo", "SysAdManage", new { area = "SysAdvertisement" });
        }
        /// <summary>
        /// 删除一条信息
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteAdInfo(int aid)
        {
            if (aid > 0)
            {
                int rowcount = bll.DeleteSystemAd(aid);
                if (rowcount > 0)
                {
                    return Json("1");
                }
                else { return Json("0"); }
            }
            return Json("0");
        }
    }
}
