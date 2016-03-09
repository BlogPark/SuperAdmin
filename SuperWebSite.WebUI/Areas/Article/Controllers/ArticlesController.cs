using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperAdmin.DataBLL;
using SuperAdmin.datamodel;
using SuperWebSite.WebUI.Areas.Article.Models;

namespace SuperWebSite.WebUI.Areas.Article.Controllers
{
    public class ArticlesController : Controller
    {
        //系统资讯部分
        // GET: /Article/Articles/
        FArticleOperateBll bll = new FArticleOperateBll();
        private int PageSize = 20;
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
            ViewBag.Title = "吃货礼仪_健康养生_热点新闻";
            ViewBag.Keywords = "健康,养生,温润,美食,烹饪,美味";
            ViewBag.Description = "告诉你怎么吃健康，看看人家都怎么吃，怎么吃才最时尚、最健康，我是吃货我骄傲";
            return View(model);
        }

        /// <summary>
        /// 文章分类页面
        /// </summary>
        /// <param name="cateid"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        [OutputCache(Duration = 1800, VaryByParam = "*")]
        public ActionResult catepage(int cateid,int p=1)
        {
            ArticleCateViewModel model = new ArticleCateViewModel();
            int pagecount = 0;
            int recordcount = 0;
            List<ArticlesModel> articles = bll.GetArticlesByCategoryID(cateid, p, PageSize, out pagecount, out recordcount);
            ArtCategoryModel catemodel = bll.GetArticleCategoryByID(cateid);
            model.page = p;
            model.pagecount = pagecount;
            model.recordcount = recordcount;
            model.CateID = cateid;
            model.CateName = catemodel.CName;
            model.Articles = articles;
            model.pageparam = "p";
            model.PageSize = PageSize;
            return View(model);
        }
    }
}
