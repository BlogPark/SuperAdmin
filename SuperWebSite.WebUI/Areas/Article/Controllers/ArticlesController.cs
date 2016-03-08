using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperAdmin.DataBLL;
using SuperWebSite.WebUI.Areas.Article.Models;

namespace SuperWebSite.WebUI.Areas.Article.Controllers
{
    public class ArticlesController : Controller
    {
        //系统资讯部分
        // GET: /Article/Articles/
        FArticleOperateBll bll = new FArticleOperateBll();
        /// <summary>
        /// 文章资讯首页
        /// </summary>
        /// <returns></returns>
        [OutputCache(Duration = 1200, VaryByParam = "*")]
        public ActionResult Index()
        {
            Response.Cache.SetOmitVaryStar(true);
            ArticleIndexViewModel model = new ArticleIndexViewModel();
            model.catelist = bll.GetAllCategory();
            model.articles = bll.GetCategoryAndArticles();
            return View(model);
        }

    }
}
