using System.Web.Mvc;

namespace SuperAdmin.WebUI.Areas.SysAdvertisement
{
    public class SysAdvertisementAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SysAdvertisement";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "SysAdvertisement_default",
                "SysAdvertisement/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
