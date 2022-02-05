using AttendanceBussiness.DbFirst;
using AttendanceBussiness.Public;
using DataGuard.App_Start;
using DataGuard.Context;
using DataGuard.Identity.Models;
using DataGuard.Models;
using LanguageResource;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using X.PagedList;

namespace DataGuard.Areas.Admin.Controllers
{
    [AccessAuthorize(Roles = "SystemAdmin")]
    public class UserController : Controller
    {
        private DataGuard.Context.ApplicationDbContext dbContext = new DataGuard.Context.ApplicationDbContext();
        private DataBaseContext dbContextContext = new DataBaseContext();

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

        // GET: Admin/User
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        //[Authorize(Roles = "SystemAdmin")]
        public ActionResult UserList(string UserId, string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var UserList1 = from s in dbContext.Users
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                UserList1 = UserList1.Where(s => s.UserName.Contains(searchString)
                                       || s.Email.Contains(searchString)
                                       || s.PhoneNumber.Contains(searchString)
                                       || s.Id.Contains(searchString));
            }
            else
            {
                UserList1.Where(s => s.Id == UserId);
            }
             
            UserList1 = UserList1.OrderBy(s => s.UserName);
            List<ApplicationUser> applicationUserslist = new List<ApplicationUser>();
            foreach (var item in UserList1)
            {
                applicationUserslist.Add(item);
            }

            int pageSize = 50;
            int pageNumber = (page ?? 1);
            return View(applicationUserslist.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult UserRolesAssignedList(string id, string UserName)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = UserManager.FindById(id);
            ViewBag.UserId = id;
            PopulateAssignedRoleData(user);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        public JsonResult UserRolesAssignedList(string UserId, string[] selectedRoles)  //UserRolesAssignedUpdate
        {
            ModalDialog modalDialog = new ModalDialog();
            modalDialog.MsgCode = "1";
            modalDialog.Message = Lang.User_UserRolesAssignedUpdate_UpdateRolesSuccess;

            if (UserId == null)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.User_UserRolesAssignedUpdate_UpdateRolesFail;
                return Json(modalDialog);
            }

            UpdateUserRoles(selectedRoles, UserId);
            modalDialog.MsgCode = UserId;
            dbContext.SaveChanges();
            return Json(modalDialog);
        }
        private void PopulateAssignedRoleData(ApplicationUser applicationUser)
        {
            var allRoles = dbContext.AspNetRoles.OrderBy(s => s.Name);

            var UserRoles = new HashSet<string>(dbContext.Database.SqlQuery<string>("select RoleId from AspNetUserRoles where UserID='" + applicationUser.Id + "'").ToList<string>());
            var viewModel = new List<AssignedRoles>();
            foreach (var item in allRoles)
            {
                viewModel.Add(new AssignedRoles
                {
                    UserId = applicationUser.Id.ToString(),
                    RoleId = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Assigned = UserRoles.Contains(item.Id)
                });
            }
            ViewBag.UserRoles = viewModel;
        }
        public void UpdateUserRoles(string[] selectedRoles, string UserId)
        {
            if (selectedRoles == null)
            {
                return;
            }
            var selectedRolesHashSet = new HashSet<string>(selectedRoles);
            var UserRoles = new HashSet<string>(dbContext.Database.SqlQuery<string>("select RoleId from AspNetUserRoles where UserID='" + UserId + "'").ToList<string>());
            foreach (var Role in dbContext.Roles)
            {
                if (selectedRolesHashSet.Contains(Role.Id.ToString()))
                {
                    if (!UserRoles.Contains(Role.Id.ToString()))
                    {
                        ViewBag.Result = dbContext.AddUserToRole(UserManager, UserId, Role.Name);
                    }
                }
                else
                {
                    if (UserRoles.Contains(Role.Id.ToString()))
                    {
                        dbContext.RemoveFromRole(UserManager, UserId, Role.Name);
                    }
                }
            }
        }

        [HttpGet]
        [Authorize(Roles = "SystemAdmin,Admin,MainComOprerator,ThirdPartyserviceContractorAdmin,ThirdPartyserviceContractorOperator")]
        public ActionResult UserRegister()
        {
            string CreateNewUserId = dbContextContext.GetTableIdentityID("6", "AspNetUsers", 4);
            ViewBag.CurrentCreateNewUserId = CreateNewUserId;
            return View();
        }
        [HttpPost]
        [AccessAuthorize(Roles = "SystemAdmin")]
        public ActionResult UserRegister(RegisterUserViewModel model, string NewUserId)
        {
            ModalDialog modalDialog = new ModalDialog
            {
                MsgCode = "1",
                Message = Lang.UserRegister_RegistedSuccess
            };
            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.PhoneNumber) || string.IsNullOrEmpty(model.UserName))
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.UserRegister_EmailPhoneNumberUserName_Required;
                return Json(modalDialog);
            }
            if (!Common.CommonBase.IsValidEmail(model.Email))
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.AspNetUser_Email_IsNotValid;
                return Json(modalDialog);
            }
            if (!Common.CommonBase.IsNumber(model.PhoneNumber))
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.AspNetUser_PhoneNumber_IsNotValid;
                return Json(modalDialog);
            }
            if (!Common.CommonBase.IsDigitAndLetter(model.UserName, 5, 30))
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.AspNetUser_UserName_IsNotValid;
                return Json(modalDialog);
            }

            string CurrentUserId = User.Identity.GetUserId();
            var CurrentUser = UserManager.FindById(CurrentUserId);
            string MainComId = CurrentUser.MainComId;
            string IndustryId = CurrentUser.IndustryId;

            var NewUser = new ApplicationUser { Id = NewUserId, MainComId = MainComId, IndustryId = IndustryId, Email = model.Email, EmailConfirmed = false, PhoneNumber = model.PhoneNumber, PhoneNumberConfirmed = false, LockoutEnabled = false, UserName = model.UserName };
            try
            {
                var identityResult = UserManager.Create(NewUser, model.Password);
                if (identityResult.Succeeded)
                {
                    modalDialog.MsgCode = NewUser.Id;
                    ViewBag.NewUserId = NewUser.Id;
                    return Json(modalDialog);
                }
                else
                {
                    modalDialog.MsgCode = "0";
                    modalDialog.Message = Lang.UserRegister_MayBeInputIllegalData;
                    return Json(modalDialog);
                }
            }
            catch
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.UserRegister_RegistedFailure;
                return Json(modalDialog);
            }
        }
    }
}