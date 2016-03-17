using System.Web.Mvc;

namespace SuperWebSite.WebUI.Areas.Article
{
    public class ArticleAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Article";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            //分类页面路由
            context.MapRoute(
               "Article_detail",
               "Article/d{aid}.html",
               new { action = "ArticleDetail", controller = "Articles", aid = 1, id = UrlParameter.Optional }
           );
            context.MapRoute(
               "Article_category_p",
               "Article/c{cateid}_{p}",
               new { action = "catepage", controller = "Articles", cateid = 1, p = 1, id = UrlParameter.Optional }
           );
            context.MapRoute(
               "Article_category",
               "Article/c{cateid}",
               new { action = "catepage", controller = "Articles", cateid = 1, id = UrlParameter.Optional }
           );

            context.MapRoute(
               "Article_index",
               "Article",
               new { action = "Index", controller = "Articles", id = UrlParameter.Optional }
           );
            context.MapRoute(
                "Article_default",
                "Article/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
