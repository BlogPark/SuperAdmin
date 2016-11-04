using System.Web.Mvc;

namespace SuperAdmin.WebUI.Areas.SysSetting
{
    public class SysSettingAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SysSetting";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "SysSetting_default",
                "SysSetting/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
