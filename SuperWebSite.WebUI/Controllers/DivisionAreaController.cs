using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperAdmin.DataBLL;
using SuperAdmin.datamodel;
using SuperWebSite.WebUI.Models;

namespace SuperWebSite.WebUI.Controllers
{
    public class DivisionAreaController : Controller
    {
        //公共区域控制器
        // GET: /DivisionArea/
        SystemSettingsBll bll = new SystemSettingsBll();
        FDivisionAreaBll fbll = new FDivisionAreaBll();
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 最顶部长条
        /// </summary>
        /// <returns></returns>
        public ActionResult PageTop()
        {
            return View();
        }
        /// <summary>
        /// 网站导航
        /// </summary>
        /// <returns></returns>
        public ActionResult PageNav()
        {
            PageNavViewModel model = new PageNavViewModel();
            SysAdminConfigsModel configmodel = bll.GetSingleSysAdminConfigsModel(3);//ID 写死
            List<WebMenusModel> allmenu= bll.GetAllWebMenusList(1);
            model.webfirstmenus = allmenu.Where(m => m.FatherID == 0).ToList();
            model.websubmenus = allmenu.Where(m => m.FatherID != 0).ToList();
            model.webbasedata = bll.GetWebSetting();
            model.IsShowMainMav = Convert.ToInt32(configmodel.ConfigValue) > 0;
            return View(model);
        }
        /// <summary>
        /// 文章网站副导航
        /// </summary>
        /// <returns></returns>
        public ActionResult PageArticleIntro()
        {
            PageArticleIntroViewModel model = new PageArticleIntroViewModel();
            model.Categories = fbll.GetAllArtCategory();
            model.Count = model.Categories.Count;
            var module = fbll.GetModuleMsgByName("文章二级导航");
            if (model == null)
            {
                model.IsVisible = true;
            }
            else if (module.ModuleStatus == 1)
            {
                model.IsVisible = true;
            }
            else {
                model.IsVisible = false;
            }
            return View(model);
        }
        /// <summary>
        /// 网站Footer
        /// </summary>
        /// <returns></returns>
        public ActionResult pageFooter()
        {
            return View();
        }
        /// <summary>
        /// 网页的最底层Footer
        /// </summary>
        /// <returns></returns>
        public ActionResult PageSubFooter()
        {
            return View();
        }
        /// <summary>
        /// 网页底端footer以上部分
        /// </summary>
        /// <returns></returns>
        public ActionResult PageSectionPart()
        {
            return View();
        }
        /// <summary>
        /// 公用footer
        /// </summary>
        /// <returns></returns>
        public ActionResult DefaultFooter()
        {
            return View();
        }
    }
}
