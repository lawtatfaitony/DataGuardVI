using AttendanceBussiness;
using AttendanceBussiness.DbFirst;
using AttendanceBussiness.Public;
using Common;
using DataGuard.App_Start;
using DataGuard.Context;
using LanguageResource;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X.PagedList;
using Industry = AttendanceBussiness.DbFirst.Industry;

namespace DataGuard.Areas.Admin.Controllers
{
    public class FoundationDataController : BaseController
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
       
        [HttpPost]
        public JsonResult IndustryEditDetails([Bind(Include = "IndustryId,KeyName,ZhCn,ZhHk,EnUs")]LangView langView)
        {
            ModalDialog modalDialog = new ModalDialog();
            Industry industry = dbContext.Industry.Find(langView.IndustryId.Trim());
            string keyType = "ModalView_PropertyName";

            bool IsViolateRule = false;
            string IncludeIndustryId = langView.KeyName.Split('_')[0];
            var industries = dbContext.Industry;
            foreach (var item in industries)
            {
                if (IncludeIndustryId == item.IndustryId)
                {
                    IsViolateRule = true;
                }
            }
            if (langView.KeyName.Contains(langView.IndustryId) == true || IsViolateRule == true)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.Language_ViolateRule;
                return Json(modalDialog);
            }

            if (industry == null)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.Industry_NotExistIndustryId;
                return Json(modalDialog);
            }
            string IndustryIdKeyName = string.Format("{0}_{1}", langView.IndustryId, langView.KeyName);

            Language language = dbContext.Language.Find(langView.KeyName);
            if (language == null)
            {
                keyType = language.KeyType;
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.Language_NotExistKeyName;
                return Json(modalDialog);
            }
            Language IndustryIdlanguage = dbContext.Language.Find(IndustryIdKeyName);
            if (IndustryIdlanguage != null && language != null)
            {
                keyType = language.KeyType;
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.FoundationData_ExistIndustryIdKeyName;
                return Json(modalDialog);
            }
            else
            {
                Language languageIndutryAddNew = new Language
                {
                    KeyName = IndustryIdKeyName
                    ,
                    KeyType = keyType
                    ,
                    ZhCn = langView.ZhCn
                    ,
                    ZhHk = langView.ZhHk
                    ,
                    EnUs = langView.EnUs
                    ,
                    IndustryIdArr = langView.IndustryId
                    ,
                    MainComIdArr = string.Empty
                    ,
                    Remark = string.Format("{0}_{1}", "Industry", langView.KeyName)
                };

                dbContext.Language.Add(languageIndutryAddNew);
                int result = dbContext.SaveChanges();
                if (result > 0)
                {
                    char[] MyChar = { ',', ' ' };
                    string IndustryIdArr = string.IsNullOrEmpty(language.IndustryIdArr) ? string.Empty : language.IndustryIdArr.TrimStart(MyChar).TrimEnd(MyChar);
                    string IndustryId = langView.IndustryId.Trim();
                    IndustryIdArr = string.Format("{0},{1}", IndustryIdArr, IndustryId);
                    IndustryIdArr = IndustryIdArr.TrimStart(MyChar).TrimEnd(MyChar);

                    //update array
                    language.IndustryIdArr = IndustryIdArr;
                    dbContext.Language.Update(language);
                    int result_updOrigin = dbContext.SaveChanges();
                    if (result_updOrigin < 1)
                    {
                        modalDialog.MsgCode = "0";
                        modalDialog.Message = Lang.IndustryEditDetails_IndustryIdArrStatus;
                        return Json(modalDialog);
                    }
                    //---------------------------------------------------
                    modalDialog.MsgCode = "1";
                    modalDialog.Message = Lang.GeneralUI_Success;
                    return Json(modalDialog);
                }
                else
                {
                    modalDialog.MsgCode = "-1";
                    modalDialog.Message = Lang.GeneralUI_ServerError;
                    return Json(modalDialog);
                }
            }
        }
      

        public ActionResult DepartmentList(string searchString, string currentFilter, string sortOrder, int? page)
        {
            string IndustryId = WebCookie.IndustryId;

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

            //Industries format : KeyName_IndustryId
            var departments = from s in dbContext.Department
                              select s; 
            if (!String.IsNullOrEmpty(searchString))
            {
                departments = departments.Where(s => s.DepartmentName.Contains(searchString)
                                       || s.EnDepartmentName.Contains(searchString)
                                       || s.DepartmentAbbrName.Contains(searchString));
            }
             
            switch (sortOrder)
            {
                case "Date":
                    departments = departments.OrderBy(s => s.DepartmentId);
                    break;
                case "date_desc":
                    departments = departments.OrderByDescending(s => s.DepartmentId);
                    break;
                default:
                    departments = departments.OrderByDescending(s => s.DepartmentId);
                    break;
            }
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            DepartmentListView departmentListView = new DepartmentListView
            {
                DepartmentNew = new DepartmentNew(),
                DepartmentList = departments.ToPagedList(pageNumber, pageSize)
            };
            return View(departmentListView);
        }

        [HttpGet]
        public JsonResult DepartmentDetails(string DepartmentId)
        {
            Department department = dbContext.Department.Find(DepartmentId);
            return Json(department, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult DepartmentDetails([Bind(Include = "DepartmentId,DepartmentName,EnDepartmentName,DepartmentAbbrName")]DepartmentNew departmentView)
        {
            ModalDialog modalDialog = new ModalDialog();
            string DepartmentId = departmentView.DepartmentId;
            if (string.IsNullOrEmpty(departmentView.DepartmentName))
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.DepartmentDetails_NeedDepartmentName;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            Department department = dbContext.Department.Find(DepartmentId);
            if (department == null)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.Department_NotExistRecord;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            else
            {
                department.DepartmentName = departmentView.DepartmentName;
                department.EnDepartmentName = departmentView.EnDepartmentName;
                department.DepartmentAbbrName = departmentView.DepartmentAbbrName;

                dbContext.Department.Update(department);
                int result = dbContext.SaveChanges();
                if (result > 0)
                {
                    modalDialog.MsgCode = DepartmentId;
                    modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_Success, DepartmentId);
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
        public JsonResult DeleteDepartment(string DepartmentId)
        {
            ModalDialog modalDialog = new ModalDialog();
            Department department = dbContext.Department.Find(DepartmentId);

            if (department == null)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.Department_NotExistRecord;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            var employees = dbContext.Employee.Where(e => e.DepartmentId.Contains(DepartmentId));
            if (employees.Count() > 0)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.DeleteDepartment_EmployeeExistRecord;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            dbContext.Department.Remove(department);
            int result = dbContext.SaveChanges();
            if (result > 0)
            {
                modalDialog.MsgCode = "1";
                modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_Success, 1);
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            else
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_ServerError, 0);
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult DepartmentAddNew([Bind(Include = "DepartmentId,DepartmentName,EnDepartmentName,DepartmentAbbrName")]DepartmentNew departmentView)
        {
            ModalDialog modalDialog = new ModalDialog();

            MainCom mainCom = dbContext.MainCom.Find(WebCookie.MainComId);
            if (mainCom == null)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.DepartmentAddNew_NotExistMainCom + " Login First";
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }

            int departmentNameCount = dbContext.Department.Where(c => c.DepartmentName.Contains(departmentView.DepartmentName) || c.EnDepartmentName.Contains(departmentView.DepartmentName)).Count();
            if (departmentNameCount > 0)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.DepartmentAddNew_ExistTheSameDepartmentName;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }

            Department department = new Department()
            {
                DepartmentId = dbContext.GetTableIdentityID("D", "Department", 3),
                DepartmentName = departmentView.DepartmentName.Trim(),
                EnDepartmentName = departmentView.EnDepartmentName.Trim(),
                DepartmentAbbrName = departmentView.DepartmentAbbrName.Trim(), 
                CompanyName = mainCom.CompanyName,
                IndustryId = mainCom.IndustryId
            };

            dbContext.Department.Add(department);
            int result = dbContext.SaveChanges();
            if (result > 0)
            {
                modalDialog.MsgCode = department.DepartmentId;
                modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_Success, department.DepartmentId);
            }
            else
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_ServerError, -1);
            }
            return Json(modalDialog, JsonRequestBehavior.AllowGet); 
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------
        [HttpGet]
        [Authorize(Roles = "SystemAdmin,Admin")]
        public ActionResult JobList(string searchString, string IndustryId, string currentFilter, string sortOrder, int? page)
        {
            string UserId = User.Identity.GetUserId(); 
            string CookieIndustryId = WebCookie.IndustryId;

            bool Role_SystemAdmin = UserManager.IsInRole(UserId, "SystemAdmin");
            if (Role_SystemAdmin)
            {
                this.IndustryIdDropDownList(string.Empty, null);
            }
            else
            {
                this.IndustryIdDropDownList(CookieIndustryId, null);
            }

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

            var jobs = from s in dbContext.Job
                       select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                jobs = jobs.Where(s => s.JobName.Contains(searchString)
                                       || s.EnJobName.Contains(searchString)
                                       || s.JobId.Contains(searchString)
                                       || s.The3rdJobId.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(IndustryId))
            {
                jobs = jobs.Where(s => s.IndustryId.Contains(IndustryId));
            }

            switch (sortOrder)
            {
                case "Date":
                    jobs = jobs.OrderBy(s => s.JobId);
                    break;
                case "date_desc":
                    jobs = jobs.OrderByDescending(s => s.JobId);
                    break;
                default:
                    jobs = jobs.OrderByDescending(s => s.JobId);
                    break;
            }
            int pageSize = 50;
            int pageNumber = (page ?? 1);
            JobListView jobListView = new JobListView
            {
                JobNew = new Job(),
                JobList = jobs.ToPagedList(pageNumber, pageSize)
            };
            return View(jobListView);
        }
        [HttpGet]
        public JsonResult JobDetails(string JobId)
        {
            Job job = dbContext.Job.Find(JobId);
            return Json(job, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize(Roles = "SystemAdmin")]
        [ValidateAntiForgeryToken]
        public JsonResult JobDetails([Bind(Include = "JobId,JobName,EnJobName,IndustryId")]Job jobView)
        {
            string UserId = User.Identity.GetUserId();
            
            ModalDialog modalDialog = new ModalDialog();
            string JobId = jobView.JobId;
            if (string.IsNullOrEmpty(jobView.JobName))
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.JobDetails_NeedJobName;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            string industryId = jobView.IndustryId;
            if (string.IsNullOrEmpty(industryId))
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.IndustryDetails_NeedIndustryName;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }

            Industry industry = dbContext.Industry.Find(industryId);
            string IndustryName = industry == null ? string.Empty : industry.IndustryName;

            Job job = dbContext.Job.Find(JobId);
            if (job == null)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.Job_NotExistRecord;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            else
            {
                job.The3rdJobId = JobId;
                job.JobName = jobView.JobName;
                job.EnJobName = jobView.EnJobName;
                job.IndustryId = industryId;
                job.IndustryName = IndustryName; 
                dbContext.Job.Update(job);
                int result = dbContext.SaveChanges();
                if (result > 0)
                {
                    modalDialog.MsgCode = JobId;
                    modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_Success, JobId);
                }
                else
                {
                    modalDialog.MsgCode = "0";
                    modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_ServerError, -1);
                }
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [Authorize(Roles = "SystemAdmin")]
        [ValidateAntiForgeryToken]
        public JsonResult JobAddNew([Bind(Include = "JobId,JobName,EnJobName,IndustryId")]Job JobView)
        {
            string UserId = User.Identity.GetUserId(); 
            ModalDialog modalDialog = new ModalDialog();

            int jobcount = dbContext.Job.Where(c => c.JobName.Contains(JobView.JobName) || c.EnJobName.Contains(JobView.JobName)).Count();
            if (jobcount > 0)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.JobAddNew_ExistTheSameJobName;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            Industry industry = dbContext.Industry.Find(JobView.IndustryId);
            if (industry == null)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.Industry_PlsSelectIndustry;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            string IndustryName = industry.IndustryName;
            string IndustryId = industry.IndustryId;

            string JobId = dbContext.GetTableIdentityID("J", "Job", 3);
            Job job = new Job()
            {
                JobId = JobId,
                The3rdJobId = JobId,
                JobName = JobView.JobName,
                EnJobName = JobView.EnJobName,
                IndustryId = IndustryId,
                IndustryName = IndustryName
            };
            dbContext.Job.Add(job);
            int result = dbContext.SaveChanges();
            if (result > 0)
            {
                modalDialog.MsgCode = JobId;
                modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_Success, JobId);
            }
            else
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_ServerError, -1);
            }
            return Json(modalDialog, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Authorize(Roles = "SystemAdmin")]
        public JsonResult DeleteJob(string JobId)
        {
            ModalDialog modalDialog = new ModalDialog();
            Job job = dbContext.Job.Find(JobId);

            if (job == null)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.Job_NotExistRecord;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            var employees = dbContext.Employee.Where(e => e.JobId.Contains(JobId)).Select(s => s.CnName);
            int empCount = employees.Count();
            if (empCount > 0)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = string.Format("{0} rows = {1} name = {2}", Lang.DelPosition_EmployeeExistRecord, empCount, string.Join(",", employees));
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            dbContext.Job.Remove(job);
            int result = dbContext.SaveChanges();
            if (result > 0)
            {
                modalDialog.MsgCode = JobId;
                modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_Success, JobId);
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            else
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_ServerError, 0);
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------
        [HttpGet]
        [Authorize(Roles = "SystemAdmin,Admin")]
        public ActionResult PositionList(string searchString, string IndustryId, string currentFilter, string sortOrder, int? page)
        {
            string UserId = User.Identity.GetUserId(); 
            string CookieIndustryId = WebCookie.IndustryId;

            this.IndustryIdDropDownList(string.Empty, null);

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

            var positions = from s in dbContext.Position
                            select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                positions = positions.Where(s => s.PositionTitle.Contains(searchString)
                                       || s.EnPositionTitle.Contains(searchString)
                                       || s.PositionId.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(IndustryId))
            {
                positions = positions.Where(s => s.IndustryId.Contains(IndustryId));
            }

            switch (sortOrder)
            {
                case "Date":
                    positions = positions.OrderBy(s => s.PositionId);
                    break;
                case "date_desc":
                    positions = positions.OrderByDescending(s => s.PositionId);
                    break;
                default:
                    positions = positions.OrderByDescending(s => s.PositionId);
                    break;
            }
            int pageSize = 50;
            int pageNumber = (page ?? 1);
            PositionListView positionListView = new PositionListView
            {
                PositionNew = new Position(),
                PositionList = positions.ToPagedList(pageNumber, pageSize)
            };
            return View(positionListView);
        }

        [HttpGet]
        public JsonResult PositionDetails(string PositionId)
        {
            Position position = dbContext.Position.Find(PositionId);
            return Json(position, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [Authorize(Roles = "SystemAdmin")]
        [ValidateAntiForgeryToken]
        public JsonResult PositionDetails([Bind(Include = "PositionId,IndustryId,PositionTitle,EnPositionTitle")]Position positionView)
        {
            ModalDialog modalDialog = new ModalDialog();
            string PositionId = positionView.PositionId;
            if (string.IsNullOrEmpty(positionView.PositionTitle))
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.JobDetails_NeedJobName;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            string industryId = positionView.IndustryId;
            if (string.IsNullOrEmpty(industryId))
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.IndustryDetails_NeedIndustryName;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }

            Industry industry = dbContext.Industry.Find(industryId);
            string IndustryName = industry == null ? string.Empty : industry.IndustryName;

            Position position = dbContext.Position.Find(PositionId);
            if (position == null)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.GeneralUI_NotExistRecord;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            else
            {
                position.PositionTitle = positionView.PositionTitle;
                position.EnPositionTitle = positionView.EnPositionTitle;
                position.IndustryId = industryId;
                dbContext.Position.Update(position);
                int result = dbContext.SaveChanges();
                if (result > 0)
                {
                    modalDialog.MsgCode = PositionId;
                    modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_Success, PositionId);
                }
                else
                {
                    modalDialog.MsgCode = "0";
                    modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_ServerError, -1);
                }
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [Authorize(Roles = "SystemAdmin")]
        [ValidateAntiForgeryToken]
        public JsonResult PositionAddNew([Bind(Include = "PositionId,IndustryId,PositionTitle,EnPositionTitle")]Position positionView)
        {
            string UserId = User.Identity.GetUserId();
          
            ModalDialog modalDialog = new ModalDialog();

            int PositionCount = dbContext.Position.Where(c => c.PositionTitle.Contains(positionView.PositionTitle) || c.EnPositionTitle.Contains(positionView.PositionTitle)).Count();
            if (PositionCount > 0)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.PositionAddNew_ExistTheSamePositionTitle;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            Industry industry = dbContext.Industry.Find(positionView.IndustryId);
            if (industry == null)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.Industry_PlsSelectIndustry;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            string IndustryName = industry.IndustryName;
            string IndustryId = industry.IndustryId;
            string PositionId = dbContext.GetTableIdentityID("P", "Position", 3);

            Position position = new Position()
            {
                PositionId = PositionId,
                IndustryId = IndustryId,
                IndustryName = IndustryName,
                PositionTitle = positionView.PositionTitle,
                EnPositionTitle = positionView.EnPositionTitle,
                CreatedDate = DateTime.Now
            };
            dbContext.Position.Add(position);
            int result = dbContext.SaveChanges();
            if (result > 0)
            {
                modalDialog.MsgCode = PositionId;
                modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_Success, PositionId);
            }
            else
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_ServerError, -1);
            }
            return Json(modalDialog, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Authorize(Roles = "SystemAdmin,Admin,MainComOprerator")]
        public JsonResult DeletePosition(string PositionId)
        {
            ModalDialog modalDialog = new ModalDialog();
            Position position = dbContext.Position.Find(PositionId);

            if (position == null)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.Site_NotExistRecord;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            var employees = dbContext.Employee.Where(e => e.PositionId.Contains(PositionId)).Select(s => s.CnName);
            int empCount = employees.Count();
            if (empCount > 0)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = string.Format("{0} rows = {1} name = {2}", Lang.DelPosition_EmployeeExistRecord, empCount, string.Join(",", employees));
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            dbContext.Position.Remove(position);
            int result = dbContext.SaveChanges();
            if (result > 0)
            {
                modalDialog.MsgCode = PositionId;
                modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_Success, PositionId);
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            else
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_ServerError, 0);
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }

        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        #region Contractor
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------
        [HttpGet]
        [Authorize(Roles = "SystemAdmin,Admin")]
        public ActionResult ContractorList(string searchString, string IndustryId, string currentFilter, string sortOrder, int? page)
        {
            string UserId = User.Identity.GetUserId(); 
            string CookieIndustryId = WebCookie.IndustryId;

            bool Role_SystemAdmin = UserManager.IsInRole(UserId, "SystemAdmin");
            if (Role_SystemAdmin)
            {
                this.IndustryIdDropDownList(string.Empty, null);
            }
            else
            {
                this.IndustryIdDropDownList(CookieIndustryId, null);
            }

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

            var contractors = from s in dbContext.Contractor
                              select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                contractors = contractors.Where(s => s.CompanyName.Contains(searchString)
                                       || s.ContactName.Contains(searchString)
                                       || s.ContractorNo.Contains(searchString)
                                       || s.IndustryName.Contains(searchString)
                                       || s.ContractorName.Contains(searchString));
            }
             
            switch (sortOrder)
            {
                case "Date":
                    contractors = contractors.OrderBy(s => s.ServiceStartDate);
                    break;
                case "date_desc":
                    contractors = contractors.OrderByDescending(s => s.ServiceStartDate);
                    break;
                default:
                    contractors = contractors.OrderByDescending(s => s.ServiceStartDate);
                    break;
            }
            int pageSize = 50;
            int pageNumber = (page ?? 1);
            ContractorListView contractorListView = new ContractorListView
            {
                ContractorNew = new ContractorNew(),
                ContractorList = contractors.ToPagedList(pageNumber, pageSize)
            };
            return View(contractorListView);
        }

        [HttpGet]
        public JsonResult ContractorDetails(string ContractorId)
        {
            Contractor contractor = dbContext.Contractor.Find(ContractorId);
            ContractorNew contractorNew = new ContractorNew
            {
                SetServiceDateRange = contractor.ServiceDateRange,
                ContractorId = contractor.ContractorId,
                ContractorName = contractor.ContractorName,
                CompanyName = contractor.CompanyName,
                ContractorNo = contractor.ContractorNo,
                IndustryId = contractor.IndustryId,
                ContactName = contractor.ContactName,
                ContactPhone = contractor.ContactPhone,
                CompanyTel = contractor.CompanyTel,
                CompanyFax = contractor.CompanyFax,
                CompanyAddress = contractor.CompanyAddress,
                ServiceStartDate = contractor.ServiceStartDate,
                ServiceEndDate = contractor.ServiceEndDate,
                OperatedDate = contractor.OperatedDate,
            };
            return Json(contractorNew, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [Authorize(Roles = "SystemAdmin,Admin")]
        [ValidateAntiForgeryToken]
        public JsonResult ContractorDetails([Bind(Include = "ContractorId,ContractorName,CompanyName,ContractorNo,IndustryId,ContactName,ContactPhone,CompanyTel,CompanyFax,SetServiceDateRange,CompanyAddress")]ContractorNew contractorView)
        {
            ModalDialog modalDialog = new ModalDialog();
            string ContractorId = contractorView.ContractorId;
            if (!string.IsNullOrEmpty(contractorView.ServiceDateRange))
            {
                contractorView.SetServiceDateRange = this.Server.UrlDecode(contractorView.SetServiceDateRange);
            }
            DateTimeRangeObj dateTimeRangeObj = new DateTimeRangeObj();
            dateTimeRangeObj = CommonBase.DateTimeRangeParse(contractorView.SetServiceDateRange);

            if (dateTimeRangeObj.Start == dateTimeRangeObj.End)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.ContractorAddNew_SetServiceDateRangeErr + "\n" + contractorView.SetServiceDateRange;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }

            if (string.IsNullOrEmpty(contractorView.ContractorName))
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.Contractor_NeedContractorName;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            string industryId = contractorView.IndustryId;
            if (string.IsNullOrEmpty(industryId))
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.IndustryDetails_NeedIndustryName;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }

            Industry industry = dbContext.Industry.Find(industryId);
            string IndustryName = industry == null ? string.Empty : industry.IndustryName;

            Contractor contractor = dbContext.Contractor.Find(ContractorId);
            if (contractor == null)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.GeneralUI_NotExistRecord;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            else
            {
                contractor.ContractorName = contractorView.ContractorName;
                contractor.ContractorNo = contractorView.ContractorNo;
                contractor.IndustryId = industryId;
                contractor.IndustryName = IndustryName;
                contractor.CompanyName = contractorView.CompanyName;
                contractor.ContactName = contractorView.ContactName;
                contractor.ContactPhone = contractorView.ContactPhone;
                contractor.CompanyTel = contractorView.CompanyTel;
                contractor.CompanyFax = contractorView.CompanyFax;
                contractor.ServiceStartDate = dateTimeRangeObj.Start;
                contractor.ServiceEndDate = dateTimeRangeObj.End;
                contractor.CompanyAddress = contractorView.CompanyAddress;
                contractor.OperatedDate = DateTime.Now;
                contractor.OperatedUserName = User.Identity.GetUserName();

                dbContext.Contractor.Update(contractor);
                int result = dbContext.SaveChanges();
                if (result > 0)
                {
                    modalDialog.MsgCode = ContractorId;
                    modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_Success, ContractorId);
                }
                else
                {
                    modalDialog.MsgCode = "0";
                    modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_ServerError, -1);
                }
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [Authorize(Roles = "SystemAdmin,Admin")]
        [ValidateAntiForgeryToken]
        public JsonResult ContractorAddNew([Bind(Include = "ContractorId,ContractorName,CompanyName,ContractorNo,IndustryId,ContactName,ContactPhone,CompanyTel,CompanyFax,SetServiceDateRange,CompanyAddress")]ContractorNew contractorNew)
        {
            string UserId = User.Identity.GetUserId(); 

            ModalDialog modalDialog = new ModalDialog();

            if (!string.IsNullOrEmpty(contractorNew.ServiceDateRange))
            {
                contractorNew.SetServiceDateRange = this.Server.UrlDecode(contractorNew.SetServiceDateRange);
            }
            DateTimeRangeObj dateTimeRangeObj = new DateTimeRangeObj();
            dateTimeRangeObj = CommonBase.DateTimeRangeParse(contractorNew.SetServiceDateRange);

            if (dateTimeRangeObj.Start == dateTimeRangeObj.End)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.ContractorAddNew_SetServiceDateRangeErr + "\n" + contractorNew.SetServiceDateRange;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }

            int ContractorCount = dbContext.Contractor.Where(c => c.ContractorName.Contains(contractorNew.ContractorNo) || c.ContractorNo.Contains(contractorNew.ContractorNo)).Count();
            if (ContractorCount > 0)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.GeneralUI_ExitRecord;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            Industry industry = dbContext.Industry.Find(contractorNew.IndustryId);
            if (industry == null)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.Industry_PlsSelectIndustry;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            string IndustryName = industry.IndustryName;
            string IndustryId = industry.IndustryId;
            string ContractorId = dbContext.GetTableIdentityID("CN", "Contractor", 5);

            Contractor contractor = new Contractor()
            {
                ContractorId = ContractorId,
                IndustryId = IndustryId,
                IndustryName = IndustryName,
                ContractorName = contractorNew.ContractorName,
                CompanyName = contractorNew.CompanyName,
                ContractorNo = contractorNew.ContractorNo,
                ContactName = contractorNew.ContactName,
                ContactPhone = contractorNew.ContactPhone,
                CompanyTel = contractorNew.CompanyTel,
                CompanyFax = contractorNew.CompanyFax,
                CompanyNameLogo = "",
                ServiceStartDate = dateTimeRangeObj.Start,
                ServiceEndDate = dateTimeRangeObj.End,
                CompanyAddress = contractorNew.CompanyAddress,
                OperatedUserName = User.Identity.Name,
                OperatedDate = DateTime.Now
            };
            dbContext.Contractor.Add(contractor);
            int result = dbContext.SaveChanges();
            if (result > 0)
            {
                modalDialog.MsgCode = ContractorId;
                modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_Success, ContractorId);
            }
            else
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_ServerError, -1);
            }
            return Json(modalDialog, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Authorize(Roles = "SystemAdmin,Admin,MainComOprerator")]
        public JsonResult DeleteContractor(string ContractorId)
        {
            ModalDialog modalDialog = new ModalDialog();
            Contractor contractor = dbContext.Contractor.Find(ContractorId);

            if (contractor == null)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.Site_NotExistRecord;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            var employees = dbContext.Employee.Where(e => e.PositionId.Contains(ContractorId)).Select(s => s.CnName);
            int empCount = employees.Count();
            if (empCount > 0)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = string.Format("{0} rows = {1} name = {2}", Lang.DelContractor_EmployeeExistRecord, empCount, string.Join(",", employees));
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            dbContext.Contractor.Remove(contractor);
            int result = dbContext.SaveChanges();
            if (result > 0)
            {
                modalDialog.MsgCode = ContractorId;
                modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_Success, ContractorId);
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            else
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_ServerError, 0);
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion Contractor

        //----------------------------------------------------------------------------------------------------------------------------------------
        [HttpGet]
        [Authorize(Roles = "SystemAdmin,Admin")]
        public ActionResult HolidayList(string searchString, string HolidayDateRange, string currentFilter, string sortOrder, int? page)
        {
            string UserId = User.Identity.GetUserId();  
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            this.StatutoryHolidayDropDownList(null);
            this.HolidayPaidTypeDropDownList(null);
            this.OnDutyPaidRatioDropDownList("1.0");
            this.HolidayIsWholeDayTypeDropDownList(ShiftBusiness.HolidayIsWholeDayType.WHOLE_DAY);
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


            DateTime dt = DateTime.Now;
            long HolidayStart = dt.Ticks;
            long HolidayEnd = dt.Ticks;
            if (!string.IsNullOrEmpty(HolidayDateRange))
            {
                HolidayDateRange = this.Server.UrlDecode(HolidayDateRange);
                DateTimeRangeObj dateTimeRangeObj = new DateTimeRangeObj();
                dateTimeRangeObj = CommonBase.DateTimeRangeParse(HolidayDateRange);
                HolidayStart = DateTimePubBusiness.SetZeroSecond(dateTimeRangeObj.Start).Ticks;
                HolidayEnd = DateTimePubBusiness.SetZeroSecond(dateTimeRangeObj.End).Ticks;

                ViewBag.HolidayDateRange = string.Format("{0:yyyy-MM-dd}-{1:yyyy-MM-dd}", new DateTime(HolidayStart), new DateTime(HolidayEnd));
            }
            else
            {
                ViewBag.HolidayDateRange = string.Format("{0:yyyy-MM-dd}-{0:yyyy-MM-dd}", dt);
            }

            ViewBag.CurrentFilter = searchString;

            var holidays = from s in dbContext.Holiday
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                holidays = holidays.Where(s => s.HolidayId.Contains(searchString)
                                       || s.HolidayCnName.Contains(searchString)
                                       || s.HolidayEnName.Contains(searchString));
            }
            if (HolidayStart != HolidayEnd)
            {
                holidays = holidays.Where(s => s.HolidayDate >= new DateTime(HolidayStart) && s.HolidayDate <= new DateTime(HolidayEnd));
            }
            switch (sortOrder)
            {
                case "Date":
                    holidays = holidays.OrderBy(s => s.HolidayDate);
                    break;
                case "date_desc":
                    holidays = holidays.OrderByDescending(s => s.HolidayDate);
                    break;
                default:
                    holidays = holidays.OrderByDescending(s => s.HolidayDate);
                    break;
            }
            int pageSize = 50;
            int pageNumber = (page ?? 1);
            HolidayListView holidayListView = new HolidayListView
            {
                HolidayNew = new Holiday { HolidayCnName = "" },
                HolidayList = holidays.ToPagedList(pageNumber, pageSize)
            };
            return View(holidayListView);
        }

        [HttpPost]
        [Authorize(Roles = "SystemAdmin,Admin,MainComOprerator")]
        [ValidateAntiForgeryToken]
        public JsonResult HolidayAddNew([Bind(Include = "HolidayId,HolidayCnName,HolidayEnName,HolidayDate,HolidayIsWholeDayType,StatutoryHolidayMode,HolidayPaidType,OnDutyPaidRatio")]HolidayView holidayView)
        {
            ModalDialog modalDialog = new ModalDialog();

            int HolidayCount = dbContext.Holiday.Where(c => c.HolidayDate == holidayView.HolidayDate).Count();
            int[] i = new int[] { 1, 2, 3 };
            if (!i.Contains((int)holidayView.HolidayIsWholeDayType))
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.HolidayAddNew_HolidayIsWholeDayType_Select;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            if (HolidayCount > 0)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.HolidayAddNew_ExistTheSameHolidayDate;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }

            if ((int)holidayView.HolidayPaidType == 1)
            {
                holidayView.HolidayPaidTypeName = Lang.HolidayPaidType_PAID_HOLIDAY;
            }
            else
            {
                holidayView.HolidayPaidTypeName = Lang.HolidayPaidType_UNPAID_HOLIDAY;
            }

            if (holidayView.HolidayPaidType == ShiftBusiness.HolidayPaidType.UNPAID_LEAVE && holidayView.OnDutyPaidRatio != 0)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.HolidayPaidType_UNPAIDAndOnDutyPaidRatioTips;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            if (holidayView.HolidayPaidType == ShiftBusiness.HolidayPaidType.PAID_LEAVE && holidayView.OnDutyPaidRatio == 0)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.HolidayPaidType_PAIDOnDutyPaidRatioTips;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            holidayView.HolidayId = dbContext.GetTableIdentityID("H", "Holiday", 3);
            bool HolidayPaidType = holidayView.StatutoryHolidayMode == ShiftBusiness.StatutoryHoliday.IS_STATUTORY ? true : false;

            Holiday holiday = new Holiday()
            {
                HolidayId = holidayView.HolidayId,
                HolidayCnName = holidayView.HolidayCnName,
                HolidayEnName = holidayView.HolidayEnName,
                HolidayDate = holidayView.HolidayDate,
                IsWholeDay = (int)holidayView.HolidayIsWholeDayType,
                StatutoryHoliday = HolidayPaidType,
                HolidayPaidType = (int)holidayView.HolidayPaidType,
                HolidayPaidTypeName = holidayView.HolidayPaidTypeName,
                OnDutyPaidRatio = holidayView.OnDutyPaidRatio
            };

            dbContext.Holiday.Add(holiday);
            int result = dbContext.SaveChanges();
            if (result > 0)
            {
                modalDialog.MsgCode = holidayView.HolidayId;
                modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_Success, holidayView.HolidayId);
            }
            else
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_ServerError, -1);
            }
            return Json(modalDialog, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Authorize(Roles = "SystemAdmin,Admin,MainComOprerator")]
        public JsonResult DeleteHoliday(string HolidayId)
        {
            ModalDialog modalDialog = new ModalDialog();
            Holiday holiday = dbContext.Holiday.Find(HolidayId);

            if (holiday == null)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.Holiday_NotExistRecord;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }

            dbContext.Holiday.Remove(holiday);
            int result = dbContext.SaveChanges();
            if (result > 0)
            {
                modalDialog.MsgCode = HolidayId;
                modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_Success, HolidayId);
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            else
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_ServerError, 0);
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        [HttpGet]
        [Authorize(Roles = "SystemAdmin,Admin")]
        public ActionResult SiteList(string searchString, string currentFilter, string sortOrder, int? page)
        {
            string UserId = User.Identity.GetUserId(); 
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


            var sites = from s in dbContext.Site
                        select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                sites = sites.Where(s => s.SiteId.Contains(searchString)
                                       || s.SiteName.Contains(searchString)
                                       || s.SiteAddress.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Date":
                    sites = sites.OrderBy(s => s.SiteId);
                    break;
                case "date_desc":
                    sites = sites.OrderByDescending(s => s.SiteId);
                    break;
                default:
                    sites = sites.OrderByDescending(s => s.SiteId);
                    break;
            }
            int pageSize = 50;
            int pageNumber = (page ?? 1);
            SiteListView siteListView = new SiteListView
            {
                SiteNew = new Site { SiteId = "", SiteName = "" },
                SiteList = sites.ToPagedList(pageNumber, pageSize)
            };
            return View(siteListView);
        }

        [HttpPost]
        [Authorize(Roles = "SystemAdmin,Admin,MainComOprerator,MainComOperator")]
        [ValidateAntiForgeryToken]
        public JsonResult SiteAddNew([Bind(Include = "SiteId,SiteName,SiteAddress")]SiteView siteView)
        {
            ModalDialog modalDialog = new ModalDialog();
           
            int SiteNameCount = dbContext.Site.Where(c => c.SiteName == siteView.SiteName).Count();
            if (SiteNameCount > 0)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.SiteNameAddNew_ExistTheSameSiteName;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            if (siteView.SiteName.Length < 2)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.SiteView_SiteName_Required;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }

            siteView.SiteId = dbContext.GetTableIdentityID("S", "Site", 4);
            Site site = new Site()
            {
                SiteId = siteView.SiteId,
                SiteName = siteView.SiteName,
                SiteAddress = siteView.SiteAddress
            };
            try
            {
                dbContext.Site.Add(site);
                int result = dbContext.SaveChanges();
                if (result > 0)
                {
                    modalDialog.MsgCode = siteView.SiteId;
                    modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_Success, siteView.SiteId);
                }
                else
                {
                    modalDialog.MsgCode = "0";
                    modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_ServerError, -1);
                }
            }
            catch
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.GeneralUI_ServerError;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }

            return Json(modalDialog, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Authorize(Roles = "SystemAdmin")]
        public JsonResult DeleteSite(string SiteId)
        {
            ModalDialog modalDialog = new ModalDialog();
            Site site = dbContext.Site.Find(SiteId);

            if (site == null)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.Job_NotExistRecord;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            var employees = dbContext.Employee.Where(e => e.SiteId.Contains(SiteId)).Select(s => s.CnName);
            int empCount = employees.Count();
            if (empCount > 0)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = string.Format("{0} rows = {1} name = {2}", Lang.DelPosition_EmployeeExistRecord, empCount, string.Join(",", employees));
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            try
            {
                dbContext.Site.Remove(site);
                int result = dbContext.SaveChanges();
                if (result > 0)
                {
                    modalDialog.MsgCode = SiteId;
                    modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_Success, SiteId);
                    return Json(modalDialog, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    modalDialog.MsgCode = "0";
                    modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_ServerError, 0);
                    return Json(modalDialog, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = string.Format("{0}-{1}", Lang.GeneralUI_ServerError, e.Message);
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpGet]
        public JsonResult SiteDetails(string SiteId)
        {
            Site site = dbContext.Site.Find(SiteId);
            return Json(site, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [Authorize(Roles = "SystemAdmin")]
        [ValidateAntiForgeryToken]
        public JsonResult SiteDetails([Bind(Include = "SiteId,SiteName,SiteAddress")]SiteView siteView)
        {
            ModalDialog modalDialog = new ModalDialog();
            string SiteId = siteView.SiteId.Trim();

            if (string.IsNullOrEmpty(siteView.SiteName))
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.SiteView_SiteName_Required;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }

            if (string.IsNullOrEmpty(SiteId))
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.Site_SiteId;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }


            Site site = dbContext.Site.Find(SiteId);
            if (site == null)
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.Site_NotExistRecord;
                return Json(modalDialog, JsonRequestBehavior.AllowGet);
            }
            else
            {
                site.SiteName = siteView.SiteName;
                site.SiteAddress = siteView.SiteAddress;
                try
                {
                    dbContext.Site.Update(site);
                    int result = dbContext.SaveChanges();
                    if (result > 0)
                    {
                        modalDialog.MsgCode = SiteId;
                        modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_Success, SiteId);
                    }
                    else
                    {
                        modalDialog.MsgCode = "0";
                        modalDialog.Message = string.Format("{0} | {1}", Lang.GeneralUI_ServerError, -1);
                    }
                    return Json(modalDialog, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    modalDialog.MsgCode = "0";
                    modalDialog.Message = string.Format("{0}-{1}", Lang.GeneralUI_ServerError, e.Message);
                    return Json(modalDialog, JsonRequestBehavior.AllowGet);
                }
            }
        }



    }
}