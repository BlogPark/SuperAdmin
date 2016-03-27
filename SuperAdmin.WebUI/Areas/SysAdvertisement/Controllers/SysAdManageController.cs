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
            ViewBag.PageTitle = "广告信息";
            return View(model);
        }
        #region 系统广告信息
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
        #endregion

        /// <summary>
        /// 系统广告位置
        /// </summary>
        /// <returns></returns>
        public ActionResult SysAdPosition()
        {
            SysAdPositionViewModel model = new SysAdPositionViewModel();
            model.syssite = bll.GetAllSysSites();
            model.positions = bll.GetAllAdPosition();
            ViewBag.PageTitle = "广告位置";
            return View(model);
        }
        #region 系统广告位置
        [HttpPost]
        public ActionResult AddPosition(SystemAdPositionModel addposition)
        {
            if (addposition != null)
            {
                addposition.PStatus = 1;
                int rowcount = bll.AddSysAdPosition(addposition);
            }
            return RedirectToAction("SysAdPosition", "SysAdManage", new { area = "SysAdvertisement" });
        }
        [HttpPost]
        public ActionResult UpdatePosition(SystemAdPositionModel updateposition)
        {
            if (updateposition != null)
            {
                updateposition.AdSiteName = updateposition.AdSiteName.Replace("\r", "").Replace("\n", "").Trim();
                int rowcount = bll.UpdateSysAdPosition(updateposition);
            }
            return RedirectToAction("SysAdPosition", "SysAdManage", new { area = "SysAdvertisement" });
        }
        [HttpPost]
        public ActionResult DeletePosition(int pid)
        {
            if (pid > 0)
            {
                int rowcount = bll.UpdateAdPositionStatus(pid,0);
                if (rowcount > 0)
                {
                    return Json("1");
                }
                else
                {
                    return Json("0");
                }
            }
            return View("0");
        }
        #endregion

        public ActionResult SysAdSchedule()
        {
            SysAdScheduleViewModel model = new SysAdScheduleViewModel();
            model.schedules = bll.GetAllSchedule();
            ViewBag.PageTitle = "广告排期";
            return View(model);
        }
        #region 系统广告排期设置
        /// <summary>
        /// 添加页面
        /// </summary>
        /// <returns></returns>
        public ActionResult AddSysSchedule()
        {
            NewScheduleViewModel model = new NewScheduleViewModel();
            model.sites = bll.GetAllSysSites();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddSysSchedule(NewScheduleViewModel model)
        {
            SessionLoginModel user = Session[AppContext.SESSION_LOGIN_NAME] as SessionLoginModel;
            SystemAdScheduleModel modes = model.addmodel;
            if (modes != null)
            {
                modes.AddUserID = user.User.ID;
                modes.AddUserName = user.User.UserName;
                int rowcount = bll.AddSchedule(modes);
            }
            return RedirectToAction("SysAdSchedule", "SysAdManage", new { area = "SysAdvertisement" });
        }
        /// <summary>
        /// 修改页面
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        public ActionResult UpdateSysSchedule(int sid)
        {
            UpdScheduleViewModel model = new UpdScheduleViewModel();
            model.sites = bll.GetAllSysSites();
            model.updmodel = bll.GetSingleScheduleByID(sid);
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateSysSchedule(UpdScheduleViewModel model)
        {
            if (model.updmodel != null)
            {
                int rowcount = bll.UpdateSchedule(model.updmodel);
            }
            return RedirectToAction("SysAdSchedule", "SysAdManage", new { area = "SysAdvertisement" });
        }
        [HttpPost]
        public ActionResult delesysschedule(int sid)
        {
            if(sid>0)
            {
                int rowcount = bll.UpdateScheduleStatus(sid, 0);
                if (rowcount > 0)
                {
                    return Json("1");
                }
                else { return Json("0"); }
            }
            return Json("0");
        }
        #endregion
        [HttpPost]
        public ActionResult GetJsonSysAd(int siteid)
        {
            SystemAdModel model = new SystemAdModel();
            model.AdSiteID = siteid;
            List<SystemAdModel> list = bll.GetSystemAdByWhereStr(model);
            return Json(list);
        }
        [HttpPost]
        public ActionResult GetJsonSysPosition(int siteid)
        {
            SystemAdPositionModel model = new SystemAdPositionModel();
            model.AdSiteID = siteid;
            List<SystemAdPositionModel> list = bll.GetAllAdPositionByWhereStr(model);
            return Json(list);
        }
    }
}
