using System.Diagnostics;
using System.ServiceProcess;
using AttendanceBussiness.Attendance;
using AttendanceBussiness.DbFirst;
using Common;
using DataGuard.App_Start;
using LanguageResource;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataGuard.Areas.Admin.Controllers
{
    public class DashbordController : AdminBaseController
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        private DataGuard.Context.ApplicationDbContext db = new DataGuard.Context.ApplicationDbContext();
        // GET: Admin/Dashbord
        [AccessAuthorize(Roles = "SystemAdmin,Admin,MainComOperator,Employee,ThirdPartyserviceContractorAdmin ,ThirdPartyserviceContractorOperator,Guest,LRO")]
        public ActionResult Index()
        {
            string UserId = User.Identity.GetUserId();

            ViewBag.Title = Lang.Dashbord_Index_Title;
            return View();
        }
        public ActionResult Index2()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LeftMenu()
        {
            ViewBag.Language = LangUtilities.LanguageCode;
            if (Request.IsAuthenticated)
            {
                var roleManager = this.HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
                string UserId = User.Identity.GetUserId();
                //Role :: Admin MainComOprerator  /SystemAdmin  /ThirdPartyserviceContractorAdmin  /ThirdPartyserviceContractorOperator  /Emplyee  /LRO  /Guest

                bool Role_SystemAdmin = UserManager.IsInRole(UserId, "SystemAdmin");

                ViewBag.Role_SystemAdmin = Role_SystemAdmin;

                bool Role_Admin = UserManager.IsInRole(UserId, "Admin");
                ViewBag.Role_Admin = Role_Admin;

                bool Role_MainComOprerator = UserManager.IsInRole(UserId, "MainComOprerator");
                ViewBag.Role_MainComOprerator = Role_MainComOprerator;

                bool Role_ThirdPartyserviceContractorAdmin = UserManager.IsInRole(UserId, "ThirdPartyserviceContractorAdmin");
                ViewBag.Role_ThirdPartyserviceContractorAdmin = Role_ThirdPartyserviceContractorAdmin;

                bool Role_ThirdPartyserviceContractorOperator = UserManager.IsInRole(UserId, "ThirdPartyserviceContractorOperator");
                ViewBag.Role_ThirdPartyserviceContractorOperator = Role_ThirdPartyserviceContractorOperator;

                bool Role_Employee = UserManager.IsInRole(UserId, "Employee");
                ViewBag.Role_Employee = Role_Employee;

                bool Role_LRO = UserManager.IsInRole(UserId, "LRO");
                ViewBag.Role_LRO = Role_LRO;

                bool Role_Guest = UserManager.IsInRole(UserId, "Guest");
                ViewBag.Role_Guest = Role_Guest;
            }
            else
            {

                ViewBag.Role_SystemAdmin = false;

                ViewBag.Role_Admin = false;

                ViewBag.Role_MainComOprerator = false;

                ViewBag.Role_ThirdPartyserviceContractorAdmin = false;

                ViewBag.Role_ThirdPartyserviceContractorOperator = false;

                ViewBag.Role_Employee = false;

                ViewBag.Role_LRO = false;

                ViewBag.Role_Guest = false;
            }

            return View();
        }

        /// <summary>
        /// SystemAdmin,Admin,MainComOperator,Employee,ThirdPartyserviceContractorAdmin ,ThirdPartyserviceContractorOperator,Guest,LRO
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [OutputCache(Duration = 300)]
        [AccessAuthorize(Roles = "Admin")]
        public ActionResult TestRole()
        {
            return View();
        }
        public ActionResult DynamicLiveRoom()
        {
            CommonBase.OperateDateLoger(string.Format("[{0:yyyy:MM:dd HH:mm:ss fff}] [DynamicLiveRoom][START]", DateTime.Now));
            AttendanceLiveRoomInitialize attendanceLiveRoomInitialize = new AttendanceLiveRoomInitialize();
            attendanceLiveRoomInitialize.ToInstance();
            CommonBase.OperateDateLoger(string.Format("[{0:yyyy:MM:dd HH:mm:ss fff}] [DynamicLiveRoom][END]", DateTime.Now));
            return View(attendanceLiveRoomInitialize);
        }
          
        [AccessAuthorize(Roles = "SystemAdmin")]
        public ActionResult RestartIIS()
        {
            ServiceController sc = new ServiceController("iisadmin");
            if (sc.Status == ServiceControllerStatus.Running)
            {
                sc.Stop();//停止
            }
            
            sc.Start();//启动

            Process.Start("iisreset");//重启 
             
            return Content("<span class='h1'>RESTART BEGIN</span>");
        }

    }
}