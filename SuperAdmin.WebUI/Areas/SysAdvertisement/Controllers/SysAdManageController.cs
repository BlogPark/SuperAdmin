using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperAdmin.WebUI.Areas.SysAdvertisement.Models;
using SuperAdmin.DataBLL;
using SuperAdmin.datamodel;

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
            model.AddAdinfo=new SystemAdModel();
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
    }
}
