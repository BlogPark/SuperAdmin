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
            string[] catelist = { "1", "2", "3", "4" };
            ArticleCateViewModel model = new ArticleCateViewModel();
            int pagecount = 0;
            int recordcount = 0;
            List<ArticlesModel> articles = bll.GetArticlesByCategoryID(cateid, p, PageSize, out pagecount, out recordcount);
            string ids = "";
            string tagstr = "";
            string categorystr = string.Join(",", catelist.Where(m => m != cateid.ToString()).ToList());
            foreach (var item in articles)
            {
                ids += item.ID + ",";
                tagstr += item.ArtTags;
            }
            ArtCategoryModel catemodel = bll.GetArticleCategoryByID(cateid);
            model.RecommendArticle = bll.GetRecommendArticle(categorystr.TrimEnd(','), ids.TrimEnd(','),13);
            model.page = p;
            model.pagecount = pagecount;
            model.recordcount = recordcount;
            model.CateID = cateid;
            model.CateName = catemodel.CName;
            model.Articles = articles;
            model.pageparam = "p";
            model.PageSize = PageSize;
            model.HotTagsList = splittag(tagstr.TrimEnd(','));
            string deciption, keywords;
            string title = getmetainfo(articles, out deciption, out keywords);
            ViewBag.Title = catemodel.CName + (p == 1 ? "" : "_" + p.ToString() + "页");
            ViewBag.Keywords = keywords;
            ViewBag.Description = deciption;
            return View(model);
        }

        private string getmetainfo(List<ArticlesModel> article, out string decription, out string keyword)
        {
            string title = "";
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (var item in article)
            {
                if (!string.IsNullOrWhiteSpace(item.ArtTags))
                {
                    string[] tags = item.ArtTags.TrimEnd(',').Split(',');
                    foreach (var subitem in tags)
                    {
                        string[] tag = subitem.Split('|');
                        if (dic.ContainsKey(tag[1]))
                        {
                            int repet = dic[tag[1]];
                            repet = repet + 1;
                            dic[tag[1]] = repet;
                        }
                        else
                        {
                            dic.Add(tag[1], 1);
                        }
                    }
                }
            }
            decription = keyword = "";
            if (dic.Any())
            {
                var result = (from p in dic
                              orderby p.Value descending
                              select p.Key).ToList().Take(20).ToList();
                keyword = string.Join(",", result);
            }
            else
            {
                keyword = string.Join("", article.Take(8).Select(m => m.ArtTitle).ToList());
            }
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

        public List<ArticleTagsModel> splittag(string tagstr)
        {
            List<ArticleTagsModel> list = new List<ArticleTagsModel>();
            if (!string.IsNullOrWhiteSpace(tagstr))
            {
                string[] tags = tagstr.TrimEnd(',').Split(',');
                foreach (var item in tags)
                {
                    string[] tag = item.Split('|');
                    var result = list.Where(m => m.TagName == tag[1]).ToList();
                    if (result.Count > 0)
                    {
                        int count = result[0].Hot + 1;
                        result[0].Hot = count;
                    }
                    else
                    {
                        ArticleTagsModel model = new ArticleTagsModel();
                        model.TagID = Convert.ToInt32(tag[0]);
                        model.TagName = tag[1];
                        model.Hot = 1;
                        list.Add(model);
                    }
                }
                if (list.Count > 0)
                {
                    list = list.OrderByDescending(m => m.Hot).ToList().Take(20).ToList();
                }
            }
            return list;
        }
        /// <summary>
        /// 文章明细页面
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        [OutputCache(Duration = 1800, VaryByParam = "*")]
        public ActionResult ArticleDetail(int aid)
        {
            ArticleDetailViewModel model = new ArticleDetailViewModel();
            model.Article = bll.GetArticleModel(aid);
            model.comments = bll.GetCommentsByArticleID(aid);
            model.RecommendArticlebuttom = bll.GetRecommendArticle(model.Article.ArtCID.ToString(), model.Article.ID.ToString()).Take(6).ToList();
            model.RecommendArticle = bll.GetRecommendArticle(model.Article.ArtCID.ToString(), model.Article.ID.ToString()).Skip(6).Take(5).ToList();
            ViewBag.Title = model.Article.ArtTitle;
            ViewBag.Keywords = model.Article.ArtTags + model.Article.ArtUserTags;
            ViewBag.Description = model.Article.ArtSummary;
            return View(model);
        }
    }
}
