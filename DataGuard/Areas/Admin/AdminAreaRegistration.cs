using System.Web.Mvc;

namespace DataGuard.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {

            //context.MapRoute(
            //    "Admin_default",
            //    "{Language}/Admin/{controller}/{action}/{id}",
            //    new { Language = UrlParameter.Optional, action = "Index", id = UrlParameter.Optional },
            //    new { Language = "zh-HK|zh-CN|en-US|hk|cn|en|HK|CN|EN" }
            //);

            //context.MapRoute(
            //    "Admin_default",
            //    "{Language}/Admin/{controller}/{action}/{id}",
            //    new { Language = new { Language = "zh-HK|zh-CN|en-US|hk|cn|en|HK|CN|EN" }, action = "Index", id = UrlParameter.Optional }
            //);

            context.MapRoute(
                "Admin_default",
                "{Language}/Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }, constraints: new { Language = "zh-HK|zh-CN|en-US|hk|cn|en|HK|CN|EN" }
            );
        }
    }
}