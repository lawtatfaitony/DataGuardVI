using DataGuard.Context;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;



namespace DataGuard
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Database.SetInitializer<ApplicationDbContext>(new DataGuardInitializer());  
            //Database.SetInitializer<ApplicationDbContext>(null);   //不包括種子數據
            // 當出現錯誤： 支持“EFDBContext”上下文的模型已在数据库创建后发生更改。请考虑使用 Code First 迁移更新数据库
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());

        }
    }
}
