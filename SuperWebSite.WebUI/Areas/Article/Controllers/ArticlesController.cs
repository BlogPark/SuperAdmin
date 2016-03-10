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
            List<ArticlesModel> article = new List<ArticlesModel>();
            foreach (var item in model.articles)
            {
                article.AddRange(item.Value);
            }
            string catestr = ""; int k = 0;
            foreach (var item in model.catelist)
            {
                if (k > 2)
                    continue;
                catestr += item.CName + "_";
                k++;
            }
            ViewBag.Title = catestr.TrimEnd('_');
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
        public ActionResult catepage(int cateid, int p = 1)
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

        private string getmetainfo(List<ArticlesModel> article, out string decription, out string keyword)
        {
            string title = "";
            decription = keyword = "";           
            var cutSummary = article.Where(w => w.ArtSummary.Length < 400 && w.ArtSummary.Length > 100);
            if (cutSummary != null && cutSummary.Count() > 0)
            {
                decription = cutSummary.OrderByDescending(o => o.ID).FirstOrDefault().ArtSummary;
                if (!string.IsNullOrEmpty(decription))
                {
                    if (decription.Length > 160)
                        decription = decription.Substring(0, 160);
                }
            }
            return title;
        }

        /// <summary>
        /// 文章明细页面
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        [OutputCache(Duration=1800,VaryByParam="*")]
        public ActionResult ArticleDetail(int aid)
        {
            ArticleDetailViewModel model = new ArticleDetailViewModel();

            return View(model);
        }
    }
}
