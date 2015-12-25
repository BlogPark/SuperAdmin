using System.Web;
using System.Web.Mvc;
using SuperAdmin.WebUI.Filters;

namespace SuperAdmin.WebUI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LoginSysAttribute());
        }
    }
}