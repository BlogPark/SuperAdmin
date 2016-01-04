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

        /// <summary>
        /// 系统用户组
        /// </summary>
        /// <returns></returns>
        public ActionResult SysAdminGroup()
        {
            List<SysAdminUserGroupModel> list = bll.GetAllAdminGroup();
            SysAdminGroupViewModel model = new SysAdminGroupViewModel();
            model.AdminGroupLists = list;
            model.AdminGroup = new SysAdminUserGroupModel();
            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Auadmingroup(SysAdminUserGroupModel AdminGroup)
        {
            if (AdminGroup != null)
            {
                int rowcount = bll.AddAndUpdateAdminGroup(AdminGroup);
            }
            return RedirectToAction("SysAdminGroup", "SysMenu", new { area = "AdminMenu" });
        }

        /// <summary>
        /// 系统菜单和权限
        /// </summary>
        /// <returns></returns>
        public ActionResult GroupAndMenu()
        {
            SysUserMenuViewModel model = new SysUserMenuViewModel();
            model.AdminUser = bll.GetAllAdminGroup();
            model.Menus = bll.GetAllUserMenu();
            return View(model);
        }

        [ValidateInput(false)]
        public ActionResult AddPermissions(int gid)
        {
            List<SysAdminMenuModel> AllMenuList = bll.GetAllMenuWithPermission(gid);
            AddPermissionsViewModel model = new AddPermissionsViewModel();
            model.FirstMenuLists = AllMenuList.Where(p => p.FatherID == 0).ToList();
            model.SecondMenuLists = AllMenuList.Where(p=>p.FatherID!=0).ToList();
            model.ButtonMenuLists = AllMenuList.Where(p => p.MenuType == 2).ToList();
            return View(model);
        }



        /// <summary>
        /// 得到组名称下无权限菜单
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult getmenulist(int gid)
        {
            #region 注释块
            //            {
            //    '主菜单1' : {name: '主菜单1', type: 'folder',id:"1",additionalParameters:{'children' : {
            //        '二级菜单1' : {name: '二级菜单1',id:"11", type: 'item'},
            //        '二级菜单2' : {name: '二级菜单2',id:"12", type: 'item'},
            //        '二级菜单3' : {name: '二级菜单3',id:"13", type: 'item'},
            //        '二级菜单4' : {name: '二级菜单4',id:"14", type: 'item'},
            //        '二级菜单5' : {name: '二级菜单5',id:"15", type: 'item'},
            //        '二级菜单6' : {name: '二级菜单6',id:"16", type: 'item'},
            //        '二级菜单7' : {name: '二级菜单7',id:"17", type: 'item'}
            //    }}},
            //    '主菜单2' : {'name': '主菜单2', 'type': 'folder','id':"2",'additionalParameters':{'children' : {
            //        '二级菜单8' : {name: '二级菜单8',id:"21", type: 'item','additionalParameters':{"item-selected":true}},
            //        '二级菜单9' : {name: '二级菜单9',id:"22", type: 'item','additionalParameters':{"item-selected":true}},
            //        '二级菜单10' : {name: '二级菜单10',id:"23", type: 'item','additionalParameters':{"item-selected":"true"}},
            //        '二级菜单11' : {name: '二级菜单11',id:"24", type: 'item','additionalParameters':{"item-selected":"true"}},
            //        '二级菜单12' : {name: '二级菜单12',id:"25", type: 'item','additionalParameters':{"item-selected":"true"}},
            //        '二级菜单13' : {name: '二级菜单13',id:"26", type: 'item','additionalParameters':{"item-selected":"true"}},
            //        '二级菜单14' : {name: '二级菜单14',id:"27", type: 'item','additionalParameters':{"item-selected":"true"}}
            //    }}},
            //    'departments' : {name: '主菜单',id:"3", type: 'item'},
            //    'benefits' : {name: '主菜单',id:"4", type: 'item'}
            //}
            #endregion
            string str = "{";
            List<SysAdminMenuModel> menulist = bll.GetOtherMenuByGroup(gid);
            var first = menulist.Where(p => p.FatherID == 0 && p.MenuType == 1).ToList();           
            string s = "";
            foreach (SysAdminMenuModel item in first)
            {
                s += "'"+item.MenuName+"' : {name: '"+item.MenuName+"', type: 'folder',id:'"+item.ID+"',additionalParameters:{'children' : {";
                string s1 = "";
                var seclist = menulist.Where(p => p.FatherID ==item.ID && p.MenuType == 1).ToList();
                foreach (SysAdminMenuModel subitem in seclist)
                {
                    s1 += " '" + subitem.MenuName + "' : {name: '" + subitem.MenuName + "',id:'" + subitem.ID + "',fatherid:'" + subitem.FatherID + "',fathername:'" + subitem.FatherName + "', type: 'item'},";
                }
                s += s1.TrimEnd(',') + " }}},";
            }
            str += s.TrimEnd(',') + "}";
            return Json(str);
        }
    }
}
