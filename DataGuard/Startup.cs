using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DataGuard.Startup))]
namespace DataGuard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //https://stackoverflow.com/questions/33455346/userid-not-found-error-in-aspnet-identity-at-generateuseridentityasync-method
            ConfigureAuth(app);
        }

    }
}
