using System.Web.Mvc;

namespace DataGuard.App_Start
{
    public class AccessAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //判断是否跳过授权过滤器
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return;
            }
            ////TODO：授权校验

            //No permission redirect to a denied page.
            base.OnAuthorization(filterContext);
            if (filterContext.Result is HttpUnauthorizedResult)
            {
                string LanguageCode = LanguageResource.LangUtilities.LanguageCode;
                filterContext.Result = new RedirectResult(string.Format("~/{0}/Account/AcessDenied", LanguageCode));
            }
        }

    }
}