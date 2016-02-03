using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperAdmin.DataBLL;
using SuperAdmin.WebUI.Areas.AdminArea.Models;

namespace SuperAdmin.WebUI.Areas.AdminArea.Controllers
{
    public class ArticleController : Controller
    {
        //系统文章管理控制器
        // GET: /AdminArea/Article/
        ArticleOperateBll bll = new ArticleOperateBll();
        public ActionResult Index()
        {
            ArticleIndexViewModel model = new ArticleIndexViewModel();
            model.articlelist=bll.GetAllArticles();
            return View(model);
        }
        /// <summary>
        /// 添加文章信息
        /// </summary>
        /// <returns></returns>
        public ActionResult AddArticle()
        {
            return View();
        }
    }
}
