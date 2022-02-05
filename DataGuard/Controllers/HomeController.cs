using LanguageResource;
using System.Web.Mvc;

namespace DataGuard.Controllers
{
    public class HomeController : Controller
    { 
        public ActionResult Index()
        {  

            ViewBag.Language = LangUtilities.LanguageCode;
            return View();
        }
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Language = LangUtilities.LanguageCode;
            ViewBag.Message = "About us";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Language = LangUtilities.LanguageCode;
            ViewBag.Message = "Contact us.";

            return View();
        }
        public ActionResult MainCom()
        {
            ViewBag.Language = LangUtilities.LanguageCode;
            return View();
        }

    }
}