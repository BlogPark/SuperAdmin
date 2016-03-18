using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using SuperAdmin.Common;
using SuperAdmin.DataBLL;
using SuperAdmin.datamodel;
using SuperAdmin.WebUI.Areas.AdminArea.Models;
using SuperAdmin.WebUI.Controllers;
using SuperAdmin.WebUI.Models;
using Webdiyer.WebControls.Mvc;

namespace SuperAdmin.WebUI.Areas.AdminArea.Controllers
{
    public class ArticleController : Controller
    {
        //系统文章管理控制器
        // GET: /AdminArea/Article/
        // string content = "<p><img alt='英国演员Henry Cavill出席第88届奥斯卡颁奖典礼'  src='http://www.yoka.com/dna/pics/ba1dabb9/2/d359b35a5e19e1ee5a1.jpg'><i>英国演员Henry Cavill出席第88届奥斯卡颁奖典礼</i> </p>";
        //string newcount=  GetContentPic(content);
        ArticleOperateBll bll = new ArticleOperateBll();
        ArtCategoryBll catebll = new ArtCategoryBll();
        WebSplitWords sp = new WebSplitWords();
        private readonly int PageSize = 20;
        public ActionResult Index(ArticlesModel seachmodel, int page = 1)
        {
            this.ViewData["seachmodel.ArtCID"] = GetCategoriesListItem();
            this.ViewData["seachmodel.ArtStatus"] = GetStatusListItem(10);
            ArticleIndexViewModel model = new ArticleIndexViewModel();
            int totalrowCount, pageCount;
            seachmodel.page = page;
            seachmodel.pageSize = PageSize;
             List<ArticlesModel> article=bll.GetArticleDataBypage(seachmodel,out totalrowCount,out pageCount);
             PagedList<ArticlesModel> pageList = null;
             if (article != null)
             {
                 pageList = new PagedList<ArticlesModel>(article, page, PageSize, totalrowCount);
             }
             model.articlelist = pageList;
            model.seachmodel = seachmodel;
            model.pagesize = PageSize;
            model.totalcount = totalrowCount;
            model.currentpage = page;
            return View(model);
        }
        /// <summary>
        /// 添加文章信息
        /// </summary>
        /// <returns></returns>
        public ActionResult AddArticle()
        {
            AddArticleViewModel model = new AddArticleViewModel();
            model.typelist = GetTypeDic();
            model.categorylist = catebll.GetALLModel();
            return View(model);
        }
        /// <summary>
        /// 添加文章
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddArticle(ArticlesModel article)
        {
            SessionLoginModel user = Session[AppContext.SESSION_LOGIN_NAME] as SessionLoginModel;
            if (user == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            article.MemberID = 1;
            article.MemberName = "会员A";
            article.AddTime = DateTime.Now;
            article.ArtCommentCount = 0;
            article.ArtFavoriteCount = 0;
            article.ArtHitCount = 0;
            article.ArtIsAlbum = 0;
            article.ArtPublishTime = DateTime.Now;
            article.ArtStatus = 10;
            article.ArtContent = GetContentPic(article.ArtContent);
            int aid = bll.AddArticle(article);
            return RedirectToAction("Index", "Article", new { area = "AdminArea" });
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
                else
                {
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
        public ActionResult DelArticle(int aid, string reason)
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
        /// <summary>
        /// 文章类型
        /// </summary>
        /// <returns></returns>
        public ActionResult ArticleCategory()
        {
            ArticleCategoryViewModel model = new ArticleCategoryViewModel();
            model.list = catebll.GetALLModel();
            return View(model);
        }
        /// <summary>
        /// 添加分类
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult addarticlecate(ArtCategoryModel addmodel)
        {
            SessionLoginModel user = Session[AppContext.SESSION_LOGIN_NAME] as SessionLoginModel;
            if (user == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            addmodel.AddUserID = user.User.ID;
            addmodel.AddUserName = user.User.UserName;
            addmodel.CStatus = 1;
            addmodel.AddTime = DateTime.Now;
            int rowid = catebll.AddArtCategory(addmodel);
            return RedirectToAction("ArticleCategory", "Article", new { area = "AdminArea" });
        }
        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult delarticlecate(int id)
        {
            if (id > 0)
            {
                bool success = catebll.UpdateArtCategoryStatus(id, 0);
                if (success)
                {
                    return Json("1");
                }
                else { return Json("0"); }
            }
            return Json("0");
        }
        /// <summary>
        /// 分析客户发表的内容，处理内容中图片
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        private string GetContentPic(string content)
        {
            string newcontent = content;
            //分析内容  得到图片列表
            List<string> piclist = new List<string>();
            string regImg = @"<\s*img[^>]*>";
            MatchCollection matches = Regex.Matches(content, regImg, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Multiline);
            if (matches != null && matches.Count > 0)
            {
                for (var i = 0; i < matches.Count; i++)
                {
                    string srcImg = @"src\s*=[^>]*(jpeg|jpg|gif|png|bmp).";
                    MatchCollection matchesrcs = Regex.Matches(matches[i].Value, srcImg, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Multiline);
                    if (matchesrcs != null && matchesrcs.Count > 0)
                    {
                        Regex regEx = new Regex("(['\"]|src|=|\\s)+", RegexOptions.IgnoreCase);
                        string src = regEx.Replace(matchesrcs[0].Value, "");
                        //校验网络路径是不是http://开始
                        if (src.ToLower().Substring(0, 7) == "http://")
                            piclist.Add(src);
                    }
                }
            }
            //分析图片 下载非本站的图片
            foreach (string item in piclist)
            {
                //如果不包含yoka.com的域名
                if (!item.Contains("yoka.com"))
                {
                    UploadFileModel uploadInfo = UploadHelper.UploadForUrl(item, AppContext.UploadPath.TrimEnd('\\'), new string[] { ".jpeg", ".jpg", ".gif", ".png", ".bmp" }, 10000, 240, 85);
                    if (uploadInfo != null && uploadInfo.status == "success")
                    {
                        newcontent = newcontent.Replace(item, AppContext.Imgdomain + uploadInfo.filepath);
                    }
                }
            }
            return newcontent;
        }
        /// <summary>
        /// 分词方法
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult spliteword(string title, string content)
        {
            List<SplitTagModel> list = new List<SplitTagModel>();
            string newcontent = title + " " + content;
            if (!string.IsNullOrWhiteSpace(newcontent))
            {
                string liststr = sp.DisplaySegment(newcontent);
                list = sp.AnalyticalTagJson(liststr).Where(m => m.hot > 0).OrderByDescending(m => m.RepeatTime).Take(10).ToList();
            }
            return Json(list);
        }
        /// <summary>
        /// 得到类型字典
        /// </summary>
        /// <returns></returns>
        private Dictionary<int, string> GetTypeDic()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1, "原创文章");
            dic.Add(2, "原创图集");
            dic.Add(3, "广告软文");
            dic.Add(4, "引用文章");
            dic.Add(5, "引用图集");
            return dic;
        }
        /// <summary>
        /// 获取分类列表
        /// </summary>
        /// <returns></returns>
        private List<SelectListItem> GetCategoriesListItem(long defval = 0)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "请选择", Value = "0", Selected = defval == 0 ? true : false });
            var classList = catebll.GetALLModel(1);

            if (classList != null && classList.Count() > 0)
            {
                foreach (var item in classList)
                {
                    string strName = item.CName;
                    int cateid = item.ID;

                    items.Add(new SelectListItem { Text = strName, Value = cateid.ToString(), Selected = defval == item.ID });
                }
            }
            return items;
        }
        /// <summary>
        /// 得到状态列表
        /// </summary>
        /// <param name="defval"></param>
        /// <returns></returns>
        private List<SelectListItem> GetStatusListItem(int defval = 1)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "未审", Value = "10", Selected = defval == 10 });
            items.Add(new SelectListItem { Text = "审核", Value = "20", Selected = defval == 20 });
            items.Add(new SelectListItem { Text = "删除", Value = "30", Selected = defval == 30 });  
            return items;
        }
        /// <summary>
        /// 得到一篇文章的Model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetArticleContent(int id)
        {
            ArticlesModel article = new ArticlesModel();
            if (id > 0)
            {
                article = bll.GetSingleArticleByID(id);
            }
            return Json(article);
        }
    }
}
