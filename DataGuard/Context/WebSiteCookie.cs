using LanguageResource;
using System;
using System.Configuration;
using System.Web;

namespace DataGuard.Context
{
    public class WebCookie
    {
        private static HttpResponse Response
        {
            get
            {
                return HttpContext.Current.Response;
            }
        }
        private static HttpRequest Request
        {
            get
            {
                return HttpContext.Current.Request;
            }
        }
        //define a Cookie set
        private static HttpCookie CK
        {
            get
            {
                return Request.Cookies["CK"] as HttpCookie;
            }
            set
            {
                if (Request.Cookies["CK"] != null)
                {
                    Request.Cookies.Remove("CK");
                }
                Response.Cookies.Add(value);
            }
        }
        //New Cookie 
        private static HttpCookie newCK
        {
            get
            {
                HttpCookie httpCookie = new HttpCookie("CK");
                httpCookie.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
                httpCookie.Expires = DateTime.Now.AddYears(1);
                return httpCookie;
            }
        }
        //Remove Cookie set
        public static void RemoveCK()
        {
            if (CK == null)
                Response.Cookies.Remove("CK");
            else
                Response.Cookies["CK"].Expires = DateTime.Now.AddDays(-1);
        }
        //创建一个Cookie，判断用户登录状态 
        public static bool LoginOk
        {
            get
            {
                return CK == null ? false : bool.Parse(CK.Values["LoginOk"]);
            }
            set
            {
                HttpCookie httpCookie = CK == null ? newCK : CK;
                httpCookie.Values["LoginOk"] = value.ToString();
                CK = httpCookie;
            }
        }

        public static string MainComId
        {
            get
            { 
                return "STARON";
            }
            set
            {
                HttpCookie ck_MainComId = new HttpCookie("MainComId", "STARON");
                ck_MainComId.Expires = DateTime.Now.AddYears(3);
                Response.Cookies.Add(ck_MainComId);
            }
        }

        public static string IndustryId
        {
            get
            {
                if (Request.Cookies["IndustryId"] == null)
                {
                    return string.Empty;
                }

                return Request.Cookies["IndustryId"].Value;
            }
            set
            {
                //HttpCookie ck_IndustryId = new HttpCookie("IndustryId", value);
                //ck_IndustryId.Expires = DateTime.Now.AddYears(3);
                //Response.Cookies.Add(ck_IndustryId); 

                HttpCookie ck_IndustryId = new HttpCookie("IndustryId", value);
                ck_IndustryId.Expires = DateTime.Now.AddYears(3);
                Response.AppendCookie(ck_IndustryId);
            }
        }

        public static string Language
        {
            get
            {
                return LangUtilities.LanguageCode;
            }
            set
            {
                HttpCookie ck_Language = new HttpCookie("Language", value);
                HttpContext.Current.Session["Language"] = value;
                HttpContext.Current.Response.Cookies.Add(ck_Language);
                Response.Cookies["Language"].Expires = DateTime.Now.AddYears(3);
            }
        }

    }
}