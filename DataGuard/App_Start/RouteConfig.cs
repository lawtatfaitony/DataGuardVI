using System.Web.Mvc;
using System.Web.Routing;

namespace DataGuard
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{Language}/{controller}/{action}/{id}",
                constraints: new { Language = "zh-HK|zh-CN|en-US|hk|cn|en|HK|CN|EN" },
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, Language = "CN" }   //   constraints: new { Language = "zh-HK|zh-CN|en-US" }, 
            );

        }
    }
}
