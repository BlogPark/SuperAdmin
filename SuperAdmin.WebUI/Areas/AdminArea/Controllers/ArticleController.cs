using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperAdmin.DataBLL;
using SuperAdmin.datamodel;
using SuperAdmin.WebUI.Areas.AdminArea.Models;
using SuperAdmin.WebUI.Controllers;
using SuperAdmin.WebUI.Models;

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
        /// <summary>
        /// 审核反审文章
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CheckArticle(int aid)
        {
            if (aid > 0)
            {
                SessionLoginModel user = Session[AppContext.SESSION_LOGIN_NAME] as SessionLoginModel;
                ArticlesModel model = new ArticlesModel();
                model.CheckUserID = user.User.ID;
                model.CheckUserName = user.User.UserName;
                model.ID = aid;
                int rowcount = bll.UpdateArticleStatus(model);
                if (rowcount > 0)
                {
                    return Json("1");
                }
                else {
                    return Json("0");
                }
            }
            return Json("0");
        }
        /// <summary>
        /// 反审(删除)文章
        /// </summary>
        /// <param name="aid"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DelArticle(int aid,string reason)
        {
            if (aid > 0)
            {
                SessionLoginModel user = Session[AppContext.SESSION_LOGIN_NAME] as SessionLoginModel;
                ArticlesModel model = new ArticlesModel();
                model.CheckUserID = user.User.ID;
                model.CheckUserName = user.User.UserName;
                model.ID = aid;
                model.AntitrialReasons = reason;
                int rowcount = bll.AntiTrialArticle(model);
                if (rowcount > 0)
                {
                    return Json("1");
                }
                else
                {
                    return Json("0");
                }
            }
            return Json("0");
        }
    }
}
