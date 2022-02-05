using System;
using System.IO;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using AttApiViewModal;
using AttendanceBussiness;
using AttendanceBussiness.DbFirst;
using AttendanceBussiness.EmployBusiness;
using AttendanceBussiness.EntriesBusiness;
using AttendanceBussiness.LeaveBusiness;
using AttendanceBussiness.Public;
using AttEnumCode;
using Common;
using DataGuard.Areas.Admin.ModelView;
using DataGuard.Context;
using DataGuard.Utilities;
using LanguageResource;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json; 
using X.PagedList;
using static AttendanceBussiness.ShiftBusiness;
using System.Web.Management;

namespace DataGuard.Areas.Admin.Controllers
{
    public partial class EmployeeController : BaseController
    {
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
        private ApplicationUserManager _userManager;
        // GET: Admin/Employee
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "SystemAdmin,Admin,LRO,MainComOprerator")]
        public ActionResult SelectEmployeeListJson(string searchString)
        {
            string CurrentMainComId = WebCookie.MainComId;

            var employeeLists = from s in dbContext.Employee.Where(c => c.MainComId == CurrentMainComId && c.IsBlock == false).Select(s => new { s.EmployeeId, Name = string.Format("{0} {1} {2}", s.CnName, s.LastName, s.FirstName) })
                                select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                employeeLists = employeeLists.Where(s => s.Name.Contains(searchString)
                                       || s.EmployeeId.Contains(searchString));
            }

            return Json(employeeLists, JsonRequestBehavior.AllowGet);
        }
        [Authorize(Roles = "SystemAdmin,Admin,LRO,MainComOprerator")]
        public ActionResult SelectDepartmentListJson(string searchString)
        { 
            var departmentLists = from s in dbContext.Department.Select(s => new { s.DepartmentId, s.DepartmentName })
                                select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                departmentLists = departmentLists.Where(s => s.DepartmentName.Contains(searchString)
                                       || s.DepartmentName.Contains(searchString));
            }

            return Json(departmentLists, JsonRequestBehavior.AllowGet);
        }
        [Authorize(Roles = "SystemAdmin,Admin,LRO,MainComOprerator")]
        public ActionResult SelectUserListJson(string searchString)
        {
            string CurrentMainComId = WebCookie.MainComId;

            var userLists = from s in dbContext.AspNetUsers.Where(c => c.MainComId == CurrentMainComId).Select(s => new { UserId = s.Id, Name = string.Format("{0} | {1} | {2}", s.UserName, s.Email, s.PhoneNumber) })
                            select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                userLists = userLists.Where(s => s.Name.Contains(searchString)
                                       || s.UserId.Contains(searchString));
            }

            return Json(userLists, JsonRequestBehavior.AllowGet);
        }
        [Authorize(Roles = "SystemAdmin,Admin,LRO")]
        public ActionResult EmployeeList(string EmployeeId, string contractorId, string siteId, string departmentId, string positionId, string jobId, string currentFilter, string searchString, int? page)
        {
            ContractorIdDropDownList(contractorId);
            SiteIdDropDownList(siteId);
            DepartmentIdDropDownList(departmentId);
            PositionIdDropDownList(IndustryId, positionId);
            IndustryIdDropDownList(IndustryId, jobId);
            JobIdDropDownList(IndustryId, jobId);
            //---------------------------------------------------------------------
            string CurrentUserMainId = dbContext.AspNetUsers.Find(User.Identity.GetUserId()).MainComId;

            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = Server.UrlDecode(searchString);
                searchString = searchString.Trim();
                ViewBag.CurrentFilter = searchString.Trim();
                page = 1;
            }
            else
            {
                searchString = currentFilter;
                ViewBag.CurrentFilter = searchString;
            }

            var employeeLists = from s in dbContext.Employee
                                select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                employeeLists = employeeLists.Where(s => s.FirstName.Contains(searchString)
                                       || s.LastName.Contains(searchString)
                                       || s.CnName.Contains(searchString)
                                       || s.Email.Contains(searchString)
                                       || s.PhoneNumber.Contains(searchString)
                                       || s.ContractorName.Contains(searchString)
                                       || s.SiteName.Contains(searchString)
                                       || s.DepartmentName.Contains(searchString)
                                       || s.JobName.Contains(searchString)
                                       || s.PhoneNumber.Contains(searchString)
                                       || s.EmployeeId.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(contractorId))
            {
                employeeLists = employeeLists.Where(s => s.ContractorId == contractorId);

            }
            if (!String.IsNullOrEmpty(siteId))
            {
                employeeLists = employeeLists.Where(s => s.SiteId == siteId);
            }
            if (!String.IsNullOrEmpty(departmentId))
            {
                employeeLists = employeeLists.Where(s => s.DepartmentId == departmentId);
            }
            if (!String.IsNullOrEmpty(positionId))
            {
                employeeLists = employeeLists.Where(s => s.PositionId == positionId);
            }
            if (!String.IsNullOrEmpty(jobId))
            {
                employeeLists = employeeLists.Where(s => s.PositionId == jobId);
            }
            employeeLists.OrderByDescending(s => s.EnrollmentDate).ThenByDescending(c => c.OperatedDate);
             
            int pageSize = 25;
            int pageNumber = (page ?? 1);
            return View(employeeLists.ToPagedList(pageNumber, pageSize));
        }
        
        [OutputCache(Duration = 60, VaryByParam = "sortOrder,searchString,occurDateTimeRange,currentFilter,page")]
       
        [Authorize(Roles = "SystemAdmin,Admin,MainComOperator,ThirdPartyserviceContractorAdmin,ThirdPartyserviceContractorOperator,LRO")]
        [HttpGet]
        public ActionResult AttendanceLog(string sortOrder, string searchString, string occurDateTimeRange, string currentFilter, int? page)
        {
            DateTime dt = DateTime.Now;
            DateTimeRangeObj dateTimeRangeObj = new DateTimeRangeObj();
            if (!string.IsNullOrEmpty(occurDateTimeRange))
            {
                occurDateTimeRange = this.Server.UrlDecode(occurDateTimeRange);
                dateTimeRangeObj = CommonBase.DateTimeRangeParse(occurDateTimeRange);
                ViewBag.CurrentOccurDateTimeRange = string.Format("{0:yyyy-MM-ddTHH:mm}-{1:yyyy-MM-ddTHH:mm}", dateTimeRangeObj.Start, dateTimeRangeObj.End);
            }
            else
            {
                dateTimeRangeObj.Start = dt.AddDays(-1);
                dateTimeRangeObj.End = dt;
                ViewBag.CurrentOccurDateTimeRange = string.Format("{0:yyyy-MM-ddTHH:mm}-{1:yyyy-MM-ddTHH:mm}", dateTimeRangeObj.Start, dateTimeRangeObj.End);
            }
            DateTimeOffset offsetStart = new DateTimeOffset(dateTimeRangeObj.Start);
            DateTimeOffset offsetEnd = new DateTimeOffset(dateTimeRangeObj.End);
            long offsetStartL = offsetStart.ToUnixTimeMilliseconds();
            long offsetEndL = offsetEnd.ToUnixTimeMilliseconds();

            ViewBag.CurrentSort = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
             

            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = Server.UrlDecode(searchString);
                searchString = searchString.Trim();
                ViewBag.CurrentFilter = searchString.Trim();
                page = 1;
            } 
             
            using (DataBaseContext dataBaseContext = new DataBaseContext())
            {
                var attendanceLog = from s in dbContext.AttendanceLog.AsNoTracking().Select(c => new {
                    c.AttendanceLogId,
                    c.OccurDateTime

                }).Where(c => c.OccurDateTime > offsetStartL && c.OccurDateTime < offsetEndL)
                                    select s;
                  
                attendanceLog = attendanceLog.Where(s => s.OccurDateTime > offsetStartL && s.OccurDateTime < offsetEndL);
                 
                switch (sortOrder)
                {
                    case "Date":
                        attendanceLog = attendanceLog.OrderBy(s => s.OccurDateTime);
                        break;
                    case "date_desc":
                        attendanceLog = attendanceLog.OrderByDescending(s => s.OccurDateTime);
                        break;
                    default:
                        attendanceLog = attendanceLog.OrderByDescending(s => s.OccurDateTime);
                        break;
                }

                List<AttendanceView> attendanceViewList = new List<AttendanceView>();
                foreach (var item in attendanceLog)
                {
                    var att = dataBaseContext.AttendanceLog.Find(item.AttendanceLogId);
                    AttendanceView attendanceView = new AttendanceView
                    {
                        AttendanceLogId = att.AttendanceLogId,
                        Mode = att.Mode,
                        DeviceId = att.DeviceId,
                        DeviceName = att.DeviceName,
                        DeviceEntryMode = att.DeviceEntryMode,
                        EmployeeId = att.EmployeeId,
                        AccesscardId = att.AccesscardId,
                        CnName = att.CnName,
                        OccurDateTime = att.OccurDateTime,
                        CatchPictureFileName = att.CatchPictureFileName,
                        CompanyName = att.CompanyName,
                        ContractorId = att.ContractorId,
                        ContractorName = att.ContractorName,
                        SiteId = att.SiteId,
                        SiteName = att.SiteName,
                        DepartmentId = att.DepartmentId,
                        DepartmentName = att.DepartmentName,
                        JobId = att.JobId,
                        JobName = att.JobName,
                        PositionId = att.PositionId,
                        PositionTitle = att.PositionTitle,
                        CratedDateTime = att.CratedDateTime,
                        FacialArea = att.FacialArea,
                        FacialAvatar = att.FacialAvatar,
                        LatitudeAndLongitude = att.LatitudeAndLongitude
                    };
                    attendanceViewList.Add(attendanceView);
                }
                if (!string.IsNullOrEmpty(searchString))
                {
                    attendanceViewList = attendanceViewList.Where(s => s.AttendanceLogId.ToString().Contains(searchString)
                                            || s.DeviceName.Contains(searchString)
                                            || s.DeviceId.Contains(searchString)
                                            || s.CnName.Contains(searchString)
                                            || s.AccesscardId.Contains(searchString)
                                            || s.ContractorName.Contains(searchString)
                                            || s.ContractorId.Contains(searchString)
                                            || s.SiteId.Contains(searchString)
                                            || s.SiteName.Contains(searchString)
                                            || s.DepartmentId.Contains(searchString)
                                            || s.DepartmentName.Contains(searchString)
                                            || s.PositionId.Contains(searchString)
                                            || s.PositionTitle.Contains(searchString)
                                            || s.JobName.Contains(searchString)
                                            || s.EmployeeId.Contains(searchString)).ToList();
                }

                int pageSize = 100;
                int pageNumber = (page ?? 1);

                return View(attendanceViewList.ToPagedList(pageNumber, pageSize));
            }
        }
      
        [HttpGet]
        public ActionResult AttendanceLogChkDataRecruitment(long id)
        {
            ModalDialog modalDialog = new ModalDialog
            {
                MsgCode = "0",
                Message = Lang.AttendanceLog_NoDataRecruitment //AttendanceLog_ExistDataRecruitment
            };
            AttendanceLog attendanceLog = dbContext.AttendanceLog.Find(id);
            string HmacHash = attendanceLog.HmacHash;
            attendanceLog.HmacHash = string.Empty;
            string EncryptString = JsonConvert.SerializeObject(attendanceLog);
            string HmacHashCompare = CommonBase.HMACSHA1Encode(EncryptString, attendanceLog.AttendanceLogId.ToString());
            if (HmacHash != HmacHashCompare)
            {
                modalDialog.MsgCode = "1";
                modalDialog.Message = Lang.AttendanceLog_ExistDataRecruitment;
            }
            return Json(modalDialog, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AttendanceLogJson(long AttendanceLogId)
        {
            AttendanceLog attendanceLog = dbContext.AttendanceLog.Find(AttendanceLogId);
            string EncryptString = CommonBase.GetProperties(attendanceLog);
            string HmacHash = attendanceLog.HmacHash;
            attendanceLog.HmacHash = string.Empty;
            string HmacHashCompare = CommonBase.HMACSHA1Encode(EncryptString, attendanceLog.AttendanceLogId.ToString());
            attendanceLog.HmacHash = HmacHashCompare + " || Old = " + HmacHash + " | " + EncryptString;
            return Json(attendanceLog, JsonRequestBehavior.AllowGet);
        }
        public bool TerminalDeviceIdSync(string EmployeeId, string DeviceId, int SearchMode)
        {
            try
            {
                Employee employee = this.dbContext.Employee.Find(EmployeeId); 
                Device device = this.dbContext.Device.Find(DeviceId);
                DeviceUser deviceUser = new DeviceUser();
                
                if (!string.IsNullOrEmpty(employee.UserIconOfEmployee.UserIcon1))
                {
                    string userIconPositivePath = this.Server.MapPath(Common.PictureSuffix.ReturnSizePicUrl(employee.UserIconOfEmployee.UserIcon1, Common.PictureSize.s600X600));
                    if (System.IO.File.Exists(userIconPositivePath))
                    {
                        deviceUser.UserIconPositive = CommonBase.ImgToBase64String(userIconPositivePath);
                        deviceUser.UserIconPositiveIsUpdate = false;
                    }
                    else
                    {
                        deviceUser.UserIconPositive = string.Empty;
                    }
                }
                if (!string.IsNullOrEmpty(employee.UserIconOfEmployee.UserIcon2))
                {
                    string userIconSidePath = this.Server.MapPath(Common.PictureSuffix.ReturnSizePicUrl(employee.UserIconOfEmployee.UserIcon2, Common.PictureSize.s600X600));
                    if (System.IO.File.Exists(userIconSidePath))
                    {
                        deviceUser.UserIconSide = CommonBase.ImgToBase64String(userIconSidePath);
                        deviceUser.UserIconSideIsUpdate = false;
                    }
                    else
                    {
                        deviceUser.UserIconSide = string.Empty;
                    }
                }

                if (!string.IsNullOrEmpty(employee.UserIconOfEmployee.UserIcon3))
                {
                    string userIconTopViewPath = this.Server.MapPath(Common.PictureSuffix.ReturnSizePicUrl(employee.UserIconOfEmployee.UserIcon3, Common.PictureSize.s600X600));
                    if(System.IO.File.Exists(userIconTopViewPath))
                    {
                        deviceUser.UserIconTopView = CommonBase.ImgToBase64String(userIconTopViewPath);
                        deviceUser.UserIconTopViewIsUpdate = false;
                    }else
                    {
                        deviceUser.UserIconTopView = string.Empty; 
                    } 
                }
                  
                deviceUser.SearchMode = SearchMode;
                deviceUser.Id = dbContext.GetTableIdentityID("DE", "DeviceUser", 4);
                deviceUser.EmployeeId = employee.EmployeeId;
                deviceUser.EmployName = employee.FullName;
                deviceUser.DeviceId = device.DeviceId;
                deviceUser.DeviceName = device.DeviceName;
                deviceUser.DevidceUserProfileId = string.Empty;
                deviceUser.UserId = employee.EmployeeId;
                deviceUser.AccessCardId = employee.AccessCardId;
                DateTime dt = DateTime.Now;
                deviceUser.CreatedDate = dt;
                deviceUser.UpdatedDate = dt;
                deviceUser.CreatedIsCompleted = false;
                var getUserDevice = dbContext.DeviceUser.Where(s => (s.EmployeeId.Contains(EmployeeId) || s.UserId.Contains(EmployeeId)) && s.DeviceId.Contains(DeviceId)).ToList();

                if (getUserDevice.Count == 0)
                {
                    dbContext.DeviceUser.Add(deviceUser);
                    bool result = dbContext.SaveChanges()> 0 ;

                    return result;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        [HttpGet]
        [Authorize(Roles = "SystemAdmin,Admin,MainComOprerator")]
        public ActionResult EmployeeDetails(string AssociateUserid, string UserName, string EmployeeId)
        {
            bool IsUpdateStatus = !string.IsNullOrEmpty(EmployeeId) ? true : false;
            ViewBag.IsUpdateStatus = IsUpdateStatus;
            string CurrentUserId = User.Identity.GetUserId();
            var CurrentUser = dbContext.AspNetUsers.Find(CurrentUserId);
            string CurrentUserMainId = CurrentUser.MainComId;
            ViewBag.MainComId = CurrentUserMainId;
            MainCom mainCom = dbContext.MainCom.Find(CurrentUserMainId);

            if (mainCom != null)
            {
                ViewBag.CompanyName = mainCom.CompanyName;
            }

            ViewBag.DisplayMainComId = "hide";

            if (UserManager.IsInRole(CurrentUserId, "SystemAdmin"))
            {
                ViewBag.MainComIdEditable = "";
            }
            else
            {
                ViewBag.MainComIdEditable = "readonly";
            }

            ViewBag.UserName = !string.IsNullOrEmpty(UserName) ? UserName : "";

            //---------------------------------------------------------------------------

            if (!string.IsNullOrEmpty(AssociateUserid))
            {
                var s = dbContext.AspNetUsers.Find(AssociateUserid);
                if (s != null)
                {
                    ViewBag.CurrentAssociateUserid = s.Id;

                    ViewBag.UserIdEditable = "readonly";
                    //----------------------------------
                    var e = dbContext.Employee.Where(c => c.UserId.Contains(AssociateUserid)).FirstOrDefault();

                    if (e != null)
                    {
                        this.ContractorIdDropDownList( e.ContractorId);
                        SiteIdDropDownList(e.SiteId);
                        DepartmentIdDropDownList(e.DepartmentId);
                        PositionIdDropDownList(mainCom.IndustryId, e.PositionId);
                        JobIdDropDownList(mainCom.IndustryId, e.JobId);
                        return View(e);
                    }
                }
            }

            if (string.IsNullOrEmpty(EmployeeId))
            {
                ViewBag.CurrentEmployeeId = CommonBase.getQuarterDateTime().ToString("yyyyMMddHHmmss");

                ViewBag.UserIdEditable = "readonly";
                //------------------------------------------------------
                ContractorIdDropDownList(null);
                SiteIdDropDownList(null);
                DepartmentIdDropDownList(null);
                PositionIdDropDownList(mainCom.IndustryId, null);
                JobIdDropDownList(mainCom.IndustryId, null);
                IndustryIdDropDownList(mainCom.IndustryId, null);
                //-------------------------------------------------------- 
                Employee employee = new Employee();
                employee.MainComId = CurrentUserMainId;
                employee.CompanyName = ViewBag.CompanyName;
                employee.Birthday = DateTime.Now;
                employee.EnrollmentDate = DateTime.Now;
                employee.LeaveDate = DateTime.Now;
                employee.ParentUserId = "0";
                employee.CreatedDate = DateTime.Now;
                employee.OperatedDate = DateTime.Now;
                employee.Gender = (int)Genders.Female;

                GendersDropDownList();

                employee.IsBlock = false;
                employee.UserId = "0";

                return View(employee);
            }
            else
            {
                ViewBag.CurrentEmployeeId = EmployeeId;
                ViewBag.TempEmployeeId = EmployeeId;
                Employee employee = this.dbContext.Employee.Find(EmployeeId);

                ContractorIdDropDownList(employee.ContractorId);
                SiteIdDropDownList(employee.SiteId);
                DepartmentIdDropDownList(employee.DepartmentId);
                PositionIdDropDownList(mainCom.IndustryId, employee.PositionId);

                JobIdDropDownList(mainCom.IndustryId, employee.JobId);
                GendersDropDownList(employee.Gender);

                return View(employee);
            }
        }

        [Authorize(Roles = "SystemAdmin,Admin,MainComOprerator")]
        [HttpPost]
        public ActionResult EmployeeDetails(string TempEmployeeId, string AssociateUserid, [Bind(Include = "EmployeeId,The3rdPartyEmployeeId,UserId,ParentUserId,UserIcon,FirstName,LastName,CnName,Gender,Birthday,PhoneNumber,Email,MainComId,ContractorId,SiteId,DepartmentId,PositionId,JobId,AccessCardId,EnrollmentDate,LeaveDate,Remarks,OperatedUserName,CreatedDate,OperatedDate,IsBlock")] Employee employee)
        {
            ViewBag.CurrentEmployeeId = TempEmployeeId;
            ModalDialog modalDialog = new ModalDialog();
            if (string.IsNullOrEmpty(employee.DepartmentId))
            {
                modalDialog.MsgCode = "-1";
                modalDialog.Message = Lang.EmployeeDetails_DepartmentId_Required;
                return Json(modalDialog);
            }
            employee.CompanyName = Organization.GetMainComCompanyName( employee.MainComId);
            employee.ContractorName = Organization.GetContractorName( employee.ContractorId);
            employee.SiteName = Organization.GetSiteName( employee.SiteId);
            employee.DepartmentName = Organization.GetDepartmentName(employee.DepartmentId);
            employee.PositionTitle = Organization.GetPositionTitle( employee.PositionId);
            employee.JobName = Organization.GetJobName( employee.JobId);

            if (string.IsNullOrEmpty(employee.EmployeeId))
            {
                employee.EmployeeId = dbContext.GetTableIdentityID("E", "Employee", 4);
                employee.OperatedUserName = User.Identity.Name;
                employee.CreatedDate = DateTime.Now;
                if (string.IsNullOrEmpty(employee.UserIcon))
                {
                    if (employee.Gender == (int)Genders.Female)
                    {
                        employee.UserIcon = "~/Content/Images/user_female40x40.gif";
                    }
                    else
                    {
                        employee.UserIcon = "~/Content/Images/user_male40x40.gif";
                    }
                }
                //--------------------------------------------------------------------------------------------------------------------------
                this.dbContext.Employee.Add(employee);
                int result = this.dbContext.SaveChanges();

                modalDialog.MsgCode = employee.EmployeeId;
                modalDialog.Message = Lang.EmployeeDetails_AddNewSuccess + " " + employee.EmployeeId;

                //DeviceUser
                if (result > 0)
                {
                    AdditionalForUpload.AlterTempTargetTalbeKeyID(this.dbContext, ViewBag.CurrentEmployeeId, employee.EmployeeId);

                    bool deviceUserAdd = TerminalDeviceIdSync(employee.EmployeeId, "AccuId001", 0);

                    modalDialog.MsgCode = employee.EmployeeId;
                    modalDialog.Message = string.Format("{0}  {1} : {2}", Lang.EmployeeDetails_AddNewSuccess, Lang.EmployeeDetails_TerminalDeviceIdSyncResultOK, employee.EmployeeId);
                }
                else
                {
                    modalDialog.MsgCode = "0";
                    modalDialog.Message = string.Format("{0}  {1} : {2}", Lang.GeneralUI_Fail, Lang.EmployeeDetails_TerminalDeviceIdSyncResultFail, result);
                }
                return Json(modalDialog);
            }
            else
            {
                ViewBag.CurrentEmployeeId = employee.EmployeeId;
                if (ModelState.IsValid)
                {
                    try
                    {
                        employee.OperatedUserName = User.Identity.Name;
                        employee.OperatedDate = DateTime.Now;

                        dbContext.Employee.Update(employee);
                        int result = dbContext.SaveChanges();

                        modalDialog.MsgCode = employee.EmployeeId;
                        modalDialog.Message = Lang.EmployeeDetails_UpdateSuccess + "Id:" + employee.EmployeeId;
                        return Json(modalDialog);
                    }
                    catch (Exception ex)
                    {

                        modalDialog.MsgCode = "0";
                        modalDialog.Message = Lang.EmployeeDetails_UpdateFailure + ":" + ex.Message;
                        return Json(modalDialog);
                    }
                }
                else
                {
                    modalDialog.MsgCode = "0";
                    modalDialog.Message = Lang.EmployeeDetails_UpdateFailure;

                    return Json(modalDialog);
                }
            }
        }
         
        private void GendersDropDownList(int Gender = 3)
        {
            SelectListItem item1 = new SelectListItem { Text = Lang.Genders_MALE, Value = "1" };
            SelectListItem item2 = new SelectListItem { Text = Lang.Genders_FEMALE, Value = "2" };
            SelectListItem item3 = new SelectListItem { Text = Lang.Genders_UNKOWN, Value = "3" };
            switch (Gender)
            {
                case 1:
                    item1.Selected = true;
                    break;
                case 2:
                    item2.Selected = true;
                    break;
                default:
                    item3.Selected = true;
                    break;
            }
            List<SelectListItem> selectListItems = new List<SelectListItem> { item1, item2, item3 };

            var GetSelectList = new SelectList(selectListItems, "Value", "Text", selectListItems);
            ViewBag.GenderList = GetSelectList;
        }

        [HttpGet]
        public ActionResult ApplyLeaveAddNew()
        {
            string UserId = User.Identity.GetUserId();
            string MainComId = WebCookie.MainComId;
            ViewBag.MainComId = MainComId;

            ViewBag.LeaveDateTimeRange = string.Format("{0:yyyy-MM-ddT09:00}-{0:yyyy-MM-ddT17:00}", DateTime.Now.AddDays(1));
            this.LeaveTypeDropDownList(null);
            this.LeavePaidTypeDropDownList(null);
            return View("ApplyLeave");
        }

        [HttpPost]
        [Authorize(Roles = "SystemAdmin,Admin,MainComOperator")]
        [ValidateAntiForgeryToken]
        public JsonResult ApplyLeaveAddNew([Bind(Include = "LeaveId,EmployeeId,LeaveType,LeavePaidType,LeaveDateTimeRange,MainComId,Reason")]LeaveView leaveView)
        {
            string ResonAppend = "";
            leaveView.ApplovedBy = "0";
            leaveView.IsApproved = false;
            leaveView.CreatedDate = DateTime.Now;
            ResponseModal responseModal = new ResponseModal { meta = new MetaModal { Success = false, Message = "", ErrorCode = -1 }, data = null };
            MetaModal metaModal = new MetaModal
            {
                Success = false,
                Message = "",
                ErrorCode = -1
            };
            string MainComId = WebCookie.MainComId;
            if (MainComId != leaveView.MainComId)
            {
                metaModal = new MetaModal
                {
                    Success = false,
                    Message = string.Format("{0}|{1}", Lang.GeneralUI_DbFail, "MainComId Not Match"),
                    ErrorCode = 10000
                };
                responseModal.meta = metaModal;
                return Json(responseModal, JsonRequestBehavior.AllowGet);
            }
            //LeaveDateTimeRange
            DateTime dt = DateTime.Now;
            long StartDateTime = dt.Ticks;
            long EndDateTime = dt.Ticks;
            if (!string.IsNullOrEmpty(leaveView.LeaveDateTimeRange))
            {
                leaveView.LeaveDateTimeRange = this.Server.UrlDecode(leaveView.LeaveDateTimeRange);
                DateTimeRangeObj dateTimeRangeObj = new DateTimeRangeObj();
                dateTimeRangeObj = CommonBase.DateTimeRangeParse(leaveView.LeaveDateTimeRange);
                dateTimeRangeObj.Start = DateTimePubBusiness.SetZeroSecond(dateTimeRangeObj.Start);
                dateTimeRangeObj.End = DateTimePubBusiness.SetZeroSecond(dateTimeRangeObj.End);

                StartDateTime = dateTimeRangeObj.Start.Ticks;
                EndDateTime = dateTimeRangeObj.End.Ticks;

                leaveView.TotalDays = DateTimePubBusiness.GetWorkDays(leaveView.LeaveDateTimeRange);
                // Match To Shift
                var employeeDateRangeSchedules = dbContext.Schedule.Where(c => c.ScheduleDate >= dateTimeRangeObj.Start.Date && c.ScheduleDate >= dateTimeRangeObj.End.Date && c.EmployeeId == leaveView.EmployeeId);
                if (employeeDateRangeSchedules.Count() < 1)
                {
                    metaModal = new MetaModal
                    {
                        Success = false,
                        Message = string.Format("{1} | {0} = {2}", Lang.GeneralUI_ReturnErrorCode, Lang.ErrorCode1001, 1001),
                        ErrorCode = 1001
                    };
                    responseModal.meta = metaModal;
                    return Json(responseModal, JsonRequestBehavior.AllowGet);
                }
                Schedule scheduleStarTime = employeeDateRangeSchedules.First<Schedule>();
                Schedule scheduleEndTime = employeeDateRangeSchedules.OrderByDescending(c => c.WorkEnd).First();
                if (scheduleStarTime.WorkStart > dateTimeRangeObj.Start.TimeOfDay || scheduleEndTime.WorkStart > dateTimeRangeObj.End.TimeOfDay && leaveView.TotalDays >= 1)
                {
                    DateTime dt_start = new DateTime(dateTimeRangeObj.Start.Year, dateTimeRangeObj.Start.Month, dateTimeRangeObj.Start.Day, scheduleStarTime.WorkStart.Hours, scheduleStarTime.WorkStart.Minutes, 0);
                    DateTime dt_end = new DateTime(dateTimeRangeObj.End.Year, dateTimeRangeObj.End.Month, dateTimeRangeObj.End.Day, scheduleEndTime.WorkEnd.Hours, scheduleEndTime.WorkEnd.Minutes, 0);
                    if (dt_start > dt_end)
                        dt_end.AddDays(1);

                    string LeaveDateTimeRange = string.Format("{0:yyyy-MM-ddTHH:mm}-{1:yyyy-MM-ddTHH:mm}", dt_start, dt_end);
                    metaModal = new MetaModal
                    {
                        Success = false,
                        Message = string.Format("{0}|{1} ErrorCode:{2}", Lang.ErrorCode1006, LeaveDateTimeRange, 10006),
                        ErrorCode = 10006
                    };

                    ReturnLeaveDateTimeRange returnLeaveDateTimeRange = new ReturnLeaveDateTimeRange
                    {
                        LeaveDateTimeRange = LeaveDateTimeRange
                    };
                    responseModal = new ResponseModal
                    {
                        meta = metaModal,
                        data = (object)returnLeaveDateTimeRange
                    };
                    Thread.Sleep(100);
                    return Json(responseModal, JsonRequestBehavior.AllowGet);
                }
                ViewBag.LeaveDateTimeRange = string.Format("{0:yyyy-MM-ddTHH:mm}-{1:yyyy-MM-ddTHH:mm}", new DateTime(StartDateTime), new DateTime(EndDateTime));

                // Reson Append
                if (dateTimeRangeObj.Start < DateTime.Now)
                {
                    ResonAppend = Lang.ApplyLeaveAddNew_ResonAppend;
                }
            }
            else
            {
                ViewBag.LeaveDateTimeRange = string.Format("{0:yyyy-MM-ddTHH:mm}-{0:yyyy-MM-ddTHH:mm}", dt);
            }
            int EmployeeLeaveDateTimeRangeCount = dbContext.Leave.Where(c => c.LeaveStartDate.Year == new DateTime(StartDateTime).Year && c.LeaveStartDate.Month == new DateTime(StartDateTime).Month && c.LeaveStartDate.Day >= new DateTime(StartDateTime).Day
                                                                             && c.LeaveEndDate.Year == new DateTime(EndDateTime).Year && c.LeaveEndDate.Month == new DateTime(EndDateTime).Month && c.LeaveEndDate.Day <= new DateTime(EndDateTime).Day
                                                                             && c.EmployeeId == leaveView.EmployeeId).Count();
            if (EmployeeLeaveDateTimeRangeCount > 0)
            {
                metaModal = new MetaModal
                {
                    Success = false,
                    Message = string.Format("{0} ({1})", Lang.ErrorCode10002, 10002),
                    ErrorCode = 10002
                };
                responseModal.meta = metaModal;
                Thread.Sleep(100);
                return Json(responseModal, JsonRequestBehavior.AllowGet);
            }
            if (string.IsNullOrEmpty(leaveView.Reason))
            {
                metaModal = new MetaModal
                {
                    Success = false,
                    Message = string.Format("{0} ({1})", Lang.LeaveView_Reason_Required, 10002),
                    ErrorCode = 10002
                };
                responseModal.meta = metaModal;
                return Json(responseModal, JsonRequestBehavior.AllowGet);
            }

            leaveView.LeaveId = dbContext.GetTableIdentityID("L", "Leave", 6);

            int intLeaveType = (int)leaveView.LeaveType;
            int intLeavePaidType = (int)leaveView.LeavePaidType;

            Employee employee = dbContext.Employee.Find(leaveView.EmployeeId);
            if (employee == null)
            {
                metaModal = new MetaModal
                {
                    Success = false,
                    Message = string.Format("{0} ({1})", Lang.Employee_ThisEmployeeIdIsNotExist, 10003),
                    ErrorCode = 10002
                };
                responseModal.meta = metaModal;
                Thread.Sleep(100);
                return Json(responseModal, JsonRequestBehavior.AllowGet);
            }
            leaveView.EmployeeName = employee.FullName;

            Leave leave = new Leave()
            {
                LeaveId = leaveView.LeaveId,
                LeaveType = intLeaveType,
                EmployeeId = leaveView.EmployeeId,
                EmployeeName = leaveView.EmployeeName,
                LeaveStartDate = new DateTime(StartDateTime),
                LeaveEndDate = new DateTime(EndDateTime),
                MainComId = MainComId,
                TotalDays = leaveView.TotalDays,
                Reason = string.Format("{0} {1}", leaveView.Reason, ResonAppend),
                IsApproved = false,
                ApplovedBy = leaveView.ApplovedBy,
                OperatedUserName = User.Identity.GetUserName(),
                CreatedDate = DateTime.Now,
                LeavePaidType = intLeavePaidType
            };
            int result = 0;
            try
            {
                dbContext.Leave.Add(leave);
                result = dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                metaModal = new MetaModal
                {
                    Success = false,
                    Message = string.Format("{0} {1} ({2})", Lang.ErrorCode10004, e.Message, 10004),
                    ErrorCode = 10004
                };
                responseModal.meta = metaModal;
                Thread.Sleep(100);
                return Json(metaModal, JsonRequestBehavior.AllowGet);
            }

            if (result > 0)
            {
                metaModal = new MetaModal
                {
                    Success = true,
                    Message = string.Format("{0} {4} | {1} | {2} |({3})", Lang.GeneralUI_Success, leaveView.EmployeeName, leaveView.LeaveId, -1, ResonAppend),
                    ErrorCode = -1
                };
                responseModal.meta = metaModal;
                Thread.Sleep(100);
                return Json(responseModal, JsonRequestBehavior.AllowGet);
            }
            else
            {
                metaModal = new MetaModal
                {
                    Success = false,
                    Message = string.Format("{0} | {1} | ({2})", Lang.GeneralUI_ServerError, -1, 10005),
                    ErrorCode = 10005
                };
                responseModal.meta = metaModal;
                Thread.Sleep(100);
                return Json(responseModal, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        [Authorize(Roles = "SystemAdmin,Admin,MainComOperator,LRO")]
        public ActionResult LeaveListPane(int Take)
        {
            string MainComId = WebCookie.MainComId;
            ViewBag.MainComId = MainComId; 
            List<LeaveBusinessView> leaveBusinessViewList;
            leaveBusinessViewList = LeaveBusiness.GetLeaveListPane(dbContext, MainComId, Take);
            return View(leaveBusinessViewList);
        }

        [HttpGet]
        [Authorize(Roles = "SystemAdmin,Admin,MainComOperator,LRO")]
        public ActionResult LeaveApprovalList(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ApprovedModeDropDownList(ApprovedMode.True);
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
             
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = Server.UrlDecode(searchString);
                searchString = searchString.Trim();
                ViewBag.CurrentFilter = searchString.Trim();
                page = 1;
            }
            else
            {
                searchString = currentFilter;
                ViewBag.CurrentFilter = searchString;
            }

            var leaves = from s in dbContext.Leave.AsNoTracking().OrderByDescending(c => c.CreatedDate)
                         select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                leaves = leaves.Where(s => s.LeaveId.Contains(searchString)
                                        || s.EmployeeName.Contains(searchString)
                                        || s.Reason.Contains(searchString)
                                        || s.ApprovedRemarks.Contains(searchString)
                                        || s.ApplovedBy.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Date":
                    leaves = leaves.OrderBy(s => s.CreatedDate);
                    break;
                case "date_desc":
                    leaves = leaves.OrderByDescending(s => s.CreatedDate);
                    break;
                default:
                    leaves = leaves.OrderByDescending(s => s.CreatedDate);
                    break;
            }
            int pageSize = 100;
            int pageNumber = (page ?? 1);
            LeaveListApprovedView leaveListApprovedView = new LeaveListApprovedView
            {
                LeaveApprovedModal = { },
                LeaveList = leaves.ToPagedList(pageNumber, pageSize)
            };
            return View(leaveListApprovedView);
        }

        [HttpPost]
        [Authorize(Roles = "SystemAdmin,Admin,MainComOperator")]
        [ValidateAntiForgeryToken]
        public JsonResult ApprovedLeave([Bind(Include = "LeaveId,EmployeeId,EmployeeName,IsApproved,ApprovedRemarks")]LeaveApproved leaveApproved)
        {

            ModalDialog modalDialog = new ModalDialog();
            string employeeId = leaveApproved.EmployeeId;
            if (string.IsNullOrEmpty(leaveApproved.EmployeeName) || string.IsNullOrEmpty(leaveApproved.EmployeeId))
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.ApprovedLeave_RequiredEmployee;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            Employee employee = dbContext.Employee.Find(employeeId);
            if (employee == null)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.Employee_ThisEmployeeIdIsNotExist;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }

            Leave leave = dbContext.Leave.Find(leaveApproved.LeaveId);
            if (leave == null)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.Leave_ThisLeaveIdIsNotExist;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            else
            {
                leave.IsApproved = bool.Parse(leaveApproved.IsApproved.ToString());
                leave.ApprovedRemarks = leaveApproved.ApprovedRemarks.Trim();
                leave.ApplovedBy = User.Identity.GetUserName();
                dbContext.Leave.Update(leave);
                int result = dbContext.SaveChanges();
                if (result > 0)
                {
                    modalDialog.MsgCode = leaveApproved.LeaveId;
                    modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_Success, leaveApproved.LeaveId);
                }
                else
                {
                    modalDialog.MsgCode = "0";
                    modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_ServerError, -1);
                }
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        [Authorize(Roles = "SystemAdmin,Admin,MainComOperator")]
        public JsonResult LeaveApproval(string Id)
        {
            ModalDialog modalDialog = new ModalDialog();
            string UserId = User.Identity.GetUserId();
            string UserName = User.Identity.GetUserName();
            Leave leave = dbContext.Leave.Find(Id);
            leave.IsApproved = true;
            leave.ApplovedBy = UserName;
            try
            {
                dbContext.Leave.Update(leave);
                int result = dbContext.SaveChanges();
                if (result > 0)
                {
                    modalDialog.MsgCode = leave.LeaveId;
                    modalDialog.Message = string.Format("{0} | {1} | {2}", Lang.GeneralUI_Success, leave.EmployeeName, leave.LeaveId);
                    return Json(modalDialog, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    modalDialog.MsgCode = "0";
                    modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_DbFail, -1);
                    return Json(modalDialog, JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_ServerError, -1);
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        [Authorize(Roles = "SystemAdmin,Admin,MainComOperator")]
        public ActionResult ArchiveApprove()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "SystemAdmin,Admin,MainComOperator")]
        public JsonResult ArchiveApprove([Bind(Include = "EmployeeId,LeaveDate")]ArchiveApprove archiveApprove)
        {
            ResponseModal responseModal = new ResponseModal { meta = new MetaModal { Success = true, Message = "intialize", ErrorCode = -1 }, data = null }; //ErrorCode = -1 //SUCCESS

            using (DataBaseContext dataBaseContext = new DataBaseContext())
            {
                Employee employee = dataBaseContext.Employee.Find(archiveApprove.EmployeeId);

                if (employee != null)
                {
                    employee.LeaveDate = archiveApprove.LeaveDate;
                    if (employee.IsArchive)
                    {
                        dataBaseContext.Employee.Update(employee);
                        dataBaseContext.SaveChanges();

                        responseModal.meta.Success = true;
                        responseModal.meta.ErrorCode = -1;
                        responseModal.meta.Message = string.Format("{2} {0} {1}", Lang.GeneralUI_OK, employee.FullName, Lang.GeneralUI_Success);
                        return Json(responseModal);
                    }
                    else
                    {
                        responseModal.meta.Success = false;
                        responseModal.meta.ErrorCode = 0;
                        responseModal.meta.Message = Lang.Employee_LeaveDateUnreasonable;
                    }
                }
                else
                {
                    responseModal.meta.Success = false;
                    responseModal.meta.ErrorCode = 0;
                    responseModal.meta.Message = Lang.GeneralUI_NotExistRecord;
                }
                return Json(responseModal, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        [Authorize(Roles = "SystemAdmin,Admin,MainComOperator")]
        public ActionResult BanApprove()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "SystemAdmin,Admin,MainComOperator")]
        public ActionResult BanApprove(string EmployeeId, bool IsBlock)
        {
            ResponseModal responseModal = new ResponseModal { meta = new MetaModal { Success = true, Message = "intialize", ErrorCode = -1 }, data = null }; //ErrorCode = -1 //SUCCESS
            if (string.IsNullOrEmpty(EmployeeId))
            {
                responseModal.meta.Success = false;
                responseModal.meta.ErrorCode = 0;
                responseModal.meta.Message = "Illegal Id";
                return Json(responseModal);
            }
            using (DataBaseContext dataBaseContext = new DataBaseContext())
            {
                Employee employee = dataBaseContext.Employee.Find(EmployeeId);
                bool RawIsblock = employee.IsBlock;
                if (employee != null)
                {
                    employee.IsBlock = IsBlock;
                    dataBaseContext.Employee.Update(employee);
                    dataBaseContext.SaveChanges();

                    responseModal.meta.Success = true;
                    responseModal.meta.ErrorCode = -1;

                    if (RawIsblock)
                    {
                        responseModal.meta.Message = string.Format("{2} {0} {1} [{3}]", Lang.GeneralUI_OK, employee.FullName, Lang.GeneralUI_Success, Lang.BanApprove_ReturnIsBlockStatus);
                    }
                    else
                    {
                        responseModal.meta.Message = string.Format("{2} {0} {1} [{3}]", Lang.GeneralUI_OK, employee.FullName, Lang.GeneralUI_Success, Lang.BanApprove_ReturnIsUnBlockStatus);
                    }

                    return Json(responseModal);
                }
                else
                {
                    responseModal.meta.Success = false;
                    responseModal.meta.ErrorCode = 0;
                    responseModal.meta.Message = Lang.GeneralUI_NotExistRecord;
                }
                return Json(responseModal, JsonRequestBehavior.AllowGet);
            }
        }
         
    }

    public class ReturnLeaveDateTimeRange
    {
        public string LeaveDateTimeRange;
    }
}