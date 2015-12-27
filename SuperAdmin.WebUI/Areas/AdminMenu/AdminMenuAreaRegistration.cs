using System.Web.Mvc;

namespace SuperAdmin.WebUI.Areas.AdminMenu
{
    public class AdminMenuAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AdminMenu";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AdminMenu_default",
                "AdminMenu/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
