using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperAdmin.DataBLL;
using SuperAdmin.datamodel;
using SuperAdmin.WebUI.Areas.AdminMenu.Models;

namespace SuperAdmin.WebUI.Areas.AdminMenu.Controllers
{
    public class SysMenuController : Controller
    {
        //系统菜单管理
        // GET: /AdminMenu/SysMenu/
        private SysMenuAndUserBll bll = new SysMenuAndUserBll();
        public ActionResult Index()
        {
            List<SysAdminMenuModel> models = bll.GetAllSysMenu();
            SysMenuIndexViewModel vm = new SysMenuIndexViewModel();
            vm.MenuLists = models;
            vm.SingleMenu = new SysAdminMenuModel();
            return View(vm);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Update(SysAdminMenuModel SingleMenu)
        {
            if (SingleMenu != null)
            {
                SingleMenu.FatherName = SingleMenu.FatherID == 0 ? "" : SingleMenu.FatherName;
                int rowcount = bll.AddAndUpdateData(SingleMenu);
            }
            return RedirectToAction("Index", "SysMenu");
        }

    }
}
