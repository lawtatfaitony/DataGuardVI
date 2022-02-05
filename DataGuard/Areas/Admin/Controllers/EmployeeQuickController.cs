using AttendanceBussiness;
using AttendanceBussiness.DbFirst;
using AttendanceBussiness.Public;
using Common;
using DataGuard.Context;
using LanguageResource;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using static AttendanceBussiness.ShiftBusiness;

namespace DataGuard.Areas.Admin.Controllers
{
    public partial class EmployeeController : BaseController
    {
        [HttpGet]
        public ActionResult EmployeeQuickHeader(string EmployeeId, int Step)
        {

            switch (Step)
            {
                case 1:
                    ViewBag._BG_EmployeeQuickAdd = "bg-secondary-gradient text-white";
                    ViewBag._TX_EmployeeQuickAdd = "text-white";
                    ViewBag._BG_QuickReco = "";
                    ViewBag._TX_QuickReco = "";
                    ViewBag._BG_QuickAddOganization = "";
                    ViewBag._TX_QuickAddOganization = "";
                    ViewBag._BG_QuickAddIdNumber = "";
                    ViewBag._TX_QuickAddIdNumber = "";
                    break;
                case 2:
                    ViewBag._BG_EmployeeQuickAdd = "";
                    ViewBag._TX_EmployeeQuickAdd = "";
                    ViewBag._BG_QuickReco = "bg-secondary-gradient text-white";
                    ViewBag._TX_QuickReco = "text-white";
                    ViewBag._BG_QuickAddOganization = "";
                    ViewBag._TX_QuickAddOganization = "";
                    ViewBag._BG_QuickAddIdNumber = "";
                    ViewBag._TX_QuickAddIdNumber = "";
                    break;
                case 3:
                    ViewBag._BG_EmployeeQuickAdd = "";
                    ViewBag._TX_EmployeeQuickAdd = "";
                    ViewBag._BG_QuickReco = "";
                    ViewBag._TX_QuickReco = "";
                    ViewBag._BG_QuickAddOganization = "bg-secondary-gradient text-white";
                    ViewBag._TX_QuickAddOganization = "text-white";
                    ViewBag._BG_QuickAddIdNumber = "";
                    ViewBag._TX_QuickAddIdNumber = "";
                    break;
                case 4:
                    ViewBag._BG_EmployeeQuickAdd = "";
                    ViewBag._TX_EmployeeQuickAdd = "";
                    ViewBag._BG_QuickReco = "";
                    ViewBag._TX_QuickReco = "";
                    ViewBag._BG_QuickAddOganization = "";
                    ViewBag._TX_QuickAddOganization = "";
                    ViewBag._BG_QuickAddIdNumber = "bg-secondary-gradient text-white";
                    ViewBag._TX_QuickAddIdNumber = "text-white";
                    break;
            }
            return View();
        }

        [HttpGet]
        public ActionResult EmployeeQuickAdd(string EmployeeId, string Message, int Step = 1)
        {
            if (!string.IsNullOrEmpty(Message))
            {
                ViewBag.Message = Message;
            }
            EmployeeStep1 employeeStep1 = new EmployeeStep1
            {
                CompanyName=string.Empty,
                EmployeeId = string.Empty,
                FirstName = string.Empty,
                LastName = string.Empty,
                CnName = string.Empty,
                PhoneNumber = string.Empty,
                Email = string.Empty,
                EnrollmentDate = DateTime.Now,
                MainComId = WebCookie.MainComId,
                OperatedUserName = User.Identity.Name
            };
            using (DataBaseContext dataBaseContext = new DataBaseContext())
            {
                if (string.IsNullOrEmpty(EmployeeId) || EmployeeId.Trim() == "0")
                {
                    ViewBag.Operation = Lang.GeneralUI_Create;
                    MainCom mainCom = dataBaseContext.MainCom.FirstOrDefault();
                    employeeStep1.CompanyName = mainCom?.CompanyName??string.Empty;
                    return View(employeeStep1);
                }
                else
                {
                    Employee employee = dataBaseContext.Employee.Find(EmployeeId);
                    if (employee != null)
                    {
                        ViewBag.EmployeeId = employee.EmployeeId;
                        employeeStep1 = new EmployeeStep1
                        {
                            EmployeeId = employee.EmployeeId,
                            FirstName = employee.FirstName,
                            LastName = employee.LastName,
                            CnName = employee.CnName,
                            Gender = employee.Gender,
                            Birthday = employee.Birthday,
                            PhoneNumber = employee.PhoneNumber,
                            Email = employee.Email,
                            EnrollmentDate = employee.EnrollmentDate.Date,
                            //----------------------------------------------
                            The3rdPartyEmployeeId = employee.The3rdPartyEmployeeId,
                            UserId = employee.UserId,
                            ParentUserId = employee.ParentUserId,
                            MainComId = employee.MainComId,
                            CompanyName = employee.CompanyName,
                            LeaveDate = employee.LeaveDate,
                            Remarks = employee.Remarks,
                            OperatedUserName = employee.OperatedUserName,
                            CreatedDate = employee.CreatedDate,
                            OperatedDate = employee.OperatedDate,
                            IsBlock = employee.IsBlock,

                        };
                        ViewBag.Operation = Lang.GeneralUI_Update;
                        return View(employeeStep1);
                    }
                    else
                    {
                        return View(employeeStep1);
                    }
                }
            }
        }

        [HttpPost]
        public ActionResult EmployeeQuickAdd([Bind(Include = "EmployeeId,FirstName,LastName,CnName,Gender,Birthday,PhoneNumber,Email,EnrollmentDate,The3rdPartyEmployeeId,UserId,ParentUserId,MainComId,CompanyName,LeaveDate,Remarks,OperatedUserName,CreatedDate,OperatedDate,IsBlock")] EmployeeStep1 employeeStep1)
        {
            ResponseModal responseModal = new ResponseModal { meta = new MetaModal { Success = true, Message = "", ErrorCode = -1 }, data = null }; //ErrorCode = -1 //SUCCESS

            string FullName = employeeStep1.FullName.Trim();
            if (Session["RepeatFullName"] != null)
            {
                if (Session["RepeatFullName"].ToString() == FullName)
                {
                    responseModal.meta.Success = false;
                    responseModal.meta.ErrorCode = 0;
                    responseModal.meta.Message = string.Format("{0} {1}", Lang.GeneralUI_Repeated, FullName);
                    return Json(responseModal);
                }
            }
            if (string.IsNullOrEmpty(FullName) || FullName.Length <= 1)
            {
                responseModal.meta.Success = false;
                responseModal.meta.ErrorCode = 0;
                responseModal.meta.Message = string.Format("{0} {1} {2} {3} ({4})", Lang.Employee_CnName2, Lang.GeneralUI_OR, Lang.Employee_LastName, Lang.GeneralUI_Required, FullName);
                return Json(responseModal);
            }
            if (!string.IsNullOrEmpty(employeeStep1.Email))
            {
                if (!CommonBase.IsValidEmail(employeeStep1.Email.Trim()))
                {
                    responseModal.meta.Success = false;
                    responseModal.meta.ErrorCode = 0;
                    responseModal.meta.Message = string.Format("{0} - {1}", Lang.EmployeeQuickAdd_EmailIsNotValidOrBlank, Lang.GeneralUI_Optional);
                    return Json(responseModal);
                }
            }
            DateTime _EnrollmentDateTime;
            bool TryParseEnrollmentDatetime = DateTime.TryParse(string.Format("{0:yyyy-MM-dd}", employeeStep1.EnrollmentDate), out _EnrollmentDateTime);

            if (!TryParseEnrollmentDatetime)
            {
                responseModal.meta.Success = false;
                responseModal.meta.ErrorCode = 0;
                responseModal.meta.Message = string.Format("{0} - {1} {2}", Lang.EmployeeQuickAdd_EnrollmentDateTimeIsInvalid, Lang.GeneralUI_Optional, _EnrollmentDateTime);
                return Json(responseModal);
            }
            else
            {
                employeeStep1.LeaveDate = _EnrollmentDateTime;
            }
            using (DataBaseContext dataBaseContext = new DataBaseContext())
            {
                Employee employee = new Employee();
                if (!string.IsNullOrEmpty(employeeStep1.EmployeeId))
                {
                    employee = dataBaseContext.Employee.Find(employeeStep1.EmployeeId);
                }
                else
                {
                    employee = null;
                }
                //---------------------------------------------------
                if (employee != null)
                {
                    ViewBag.Operation = Lang.GeneralUI_Update;

                    employee.FirstName = employeeStep1.FirstName;
                    employee.LastName = employeeStep1.LastName;
                    employee.CnName = employeeStep1.CnName;
                    employee.PhoneNumber = employee.PhoneNumber;
                    employee.Email = employee.Email;
                    employee.EnrollmentDate = employee.EnrollmentDate.Date;

                    employee.OperatedUserName = User.Identity.Name;
                    employee.OperatedDate = DateTime.Now;
                    try
                    {
                        Thread.Sleep(1000);

                        dbContext.Employee.Update(employee);
                        int result = dbContext.SaveChanges();
                        if (result > 0)
                        {
                            Session["RepeatFullName"] = employee.FullName;
                            responseModal.meta.Success = true;
                            responseModal.meta.ErrorCode = -1;
                            responseModal.meta.Message = Lang.EmployeeDetails_UpdateSuccess + "Id:" + employee.EmployeeId;
                            responseModal.data = employee;
                            return Json(responseModal);
                        }
                        else
                        {
                            responseModal.meta.Success = false;
                            responseModal.meta.ErrorCode = 0;
                            responseModal.meta.Message = Lang.EmployeeDetails_UpdateFailure + " Id:" + employee.EmployeeId;
                            responseModal.data = null;
                            return Json(responseModal);
                        }
                    }
                    catch (Exception ex)
                    {
                        Thread.Sleep(1000);

                        responseModal.meta.Success = false;
                        responseModal.meta.ErrorCode = 0;
                        responseModal.meta.Message = Lang.EmployeeDetails_UpdateFailure + ":" + ex.Message;
                        responseModal.data = null;
                        return Json(responseModal);
                    }
                }
                else
                {
                    employee = new Employee
                    {
                        EmployeeId = dbContext.GetTableIdentityID("E", "Employee", 4),
                        FirstName = employeeStep1.FirstName,
                        LastName = employeeStep1.LastName,
                        CnName = employeeStep1.CnName,
                        Gender = employeeStep1.Gender,
                        Birthday = employeeStep1.Birthday,
                        PhoneNumber = employeeStep1.PhoneNumber,
                        Email = employeeStep1.Email,
                        EnrollmentDate = employeeStep1.EnrollmentDate,
                        The3rdPartyEmployeeId = employeeStep1.The3rdPartyEmployeeId,
                        UserId = employeeStep1.UserId,
                        ParentUserId = employeeStep1.ParentUserId,
                        MainComId = employeeStep1.MainComId,
                        CompanyName = employeeStep1.CompanyName,
                        LeaveDate = employeeStep1.LeaveDate,
                        Remarks = employeeStep1.Remarks,
                        OperatedUserName = employeeStep1.OperatedUserName,
                        CreatedDate = employeeStep1.CreatedDate,
                        OperatedDate = employeeStep1.OperatedDate,
                        IsBlock = employeeStep1.IsBlock
                    };

                    this.dbContext.Employee.Add(employee);
                    int result = this.dbContext.SaveChanges();

                    Thread.Sleep(1000);

                    if (result > 0)
                    {
                        Session["RepeatFullName"] = employee.FullName;
                        responseModal.meta.Success = true;
                        responseModal.meta.ErrorCode = -1;
                        responseModal.meta.Message = Lang.EmployeeDetails_AddNewSuccess + " " + employee.EmployeeId;
                        responseModal.data = employee;
                    }
                    else
                    {
                        responseModal.meta.Success = false;
                        responseModal.meta.ErrorCode = 0;
                        responseModal.meta.Message = string.Format("{0}  {1} : {2}", Lang.GeneralUI_Fail, Lang.EmployeeDetails_TerminalDeviceIdSyncResultFail, result);
                    }
                    return Json(responseModal);
                }
            }
        } 

        [HttpGet]
        public ActionResult EmployeeQuickReco(string EmployeeId, int Step = 2)
        {
            EmployeeStep2 employeeStep2 = new EmployeeStep2();

            if (string.IsNullOrEmpty(EmployeeId) || EmployeeId == "0")
            {
                return RedirectToAction("EmployeeQuickAdd", "Employee", new { Step = 1, Message = Lang.EmployeeQuick_Message });
            }
            else
            {
                using (DataBaseContext dataBaseContext = new DataBaseContext())
                {
                    Employee employee = dataBaseContext.Employee.Find(EmployeeId);

                    if (employee != null)
                    {
                        ViewBag.EmployeeId = employee.EmployeeId;
                        ViewBag.MainComId = employee.MainComId;
                        employeeStep2 = new EmployeeStep2
                        {
                            EmployeeId = employee.EmployeeId,
                            FullName = employee.FullName,
                            AccessCardId = employee.AccessCardId,
                            FingerPrint = employee.FingerPrint
                        };
                        var uploadItems = dataBaseContext.UploadItem.Where(c => c.TargetTalbeKeyId.Contains(EmployeeId)).OrderByDescending(c => c.OperatedDate).OrderByDescending(c => c.RankOrder).Take(3);
                        int i = 0;
                        foreach (var item in uploadItems)
                        {
                            i++;
                            switch (i)
                            {
                                case 1:
                                    employeeStep2.UserIcon1 = item.Url;
                                    break;
                                case 2:
                                    employeeStep2.UserIcon2 = item.Url;
                                    break;
                                case 3:
                                    employeeStep2.UserIcon3 = item.Url;
                                    break;
                            }
                        }
                        return View(employeeStep2);
                    }
                    else
                    {
                        return RedirectToAction("EmployeeQuickAdd", "Employee", new { Step = 1, Message = Lang.EmployeeQuick_Message });
                    }
                }

            }
        }

        [HttpPost]
        public ActionResult EmployeeQuickReco([Bind(Include = "EmployeeId,UserIcon1,UserIcon2,UserIcon3,AccessCardId,FingerPrint")] EmployeeStep2 employeeStep2)
        {
            ResponseModal responseModal = new ResponseModal { meta = new MetaModal { Success = true, Message = "", ErrorCode = -1 }, data = null };
            responseModal.meta = new MetaModal
            {
                Success = true,
                Message = "OK",
                ErrorCode = -1 //SUCCESS
            };
            string EmployeeId = employeeStep2.EmployeeId;

            if (string.IsNullOrEmpty(EmployeeId))
            {
                responseModal.meta = new MetaModal
                {
                    Success = false,
                    Message = Lang.EmployeeQuickReco_NoEmployeeId,
                    ErrorCode = 0 //FAIL
                };
                return Json(responseModal);
            }

            if (!string.IsNullOrEmpty(employeeStep2.AccessCardId))
            {
                using (DataBaseContext dataBaseContext = new DataBaseContext())
                {
                    Employee employee_accessCardId = dataBaseContext.Employee.Where(c => c.AccessCardId.Contains(employeeStep2.AccessCardId) && c.IsBlock == false).FirstOrDefault();
                    if (employee_accessCardId != null)
                    {
                        responseModal.meta = new MetaModal
                        {
                            Success = false,
                            Message = string.Format(Lang.EmployeeQuickReco_AccessCardIdOccupied, employeeStep2.AccessCardId, employee_accessCardId.FullName, employee_accessCardId.EmployeeId),
                            ErrorCode = 0 //FAIL
                        };
                        return Json(responseModal);
                    }
                }
            }
            string UserIcon1 = !string.IsNullOrEmpty(employeeStep2.UserIcon1) ? employeeStep2.UserIcon1.Trim() : string.Empty;
            string UserIcon2 = !string.IsNullOrEmpty(employeeStep2.UserIcon2) ? employeeStep2.UserIcon2.Trim() : string.Empty;
            string UserIcon3 = !string.IsNullOrEmpty(employeeStep2.UserIcon3) ? employeeStep2.UserIcon3.Trim() : string.Empty;

            string AccessCardId = !string.IsNullOrEmpty(employeeStep2.AccessCardId) ? employeeStep2.AccessCardId.Trim() : string.Empty;
            string FingerPrint = !string.IsNullOrEmpty(employeeStep2.FingerPrint) ? employeeStep2.FingerPrint.Trim() : string.Empty;
         
            if (string.IsNullOrEmpty(UserIcon1) && string.IsNullOrEmpty(UserIcon2) && string.IsNullOrEmpty(UserIcon3) && string.IsNullOrEmpty(FingerPrint) && string.IsNullOrEmpty(FingerPrint))
            {
                responseModal.meta = new MetaModal
                {
                    Success = false,
                    Message = Lang.EmployeeQuickReco_IsAllBlank,
                    ErrorCode = 0 //FAIL
                };
                return Json(responseModal);
            }
            else
            {
                using (DataBaseContext dataBaseContext = new DataBaseContext())
                {
                    Employee employee = dataBaseContext.Employee.Find(EmployeeId);

                    if (employee != null)
                    {
                        ViewBag.EmployeeId = employee.EmployeeId;
                        ViewBag.MainComId = employee.MainComId;

                        if (!string.IsNullOrEmpty(UserIcon3))
                            employee.UserIcon = UserIcon3;
                        if (!string.IsNullOrEmpty(UserIcon2))
                            employee.UserIcon = UserIcon2;
                        if (!string.IsNullOrEmpty(UserIcon1))
                            employee.UserIcon = UserIcon1;

                        employee.AccessCardId = AccessCardId;
                        employee.FingerPrint = FingerPrint;

                        try
                        {
                            dbContext.Employee.Update(employee);
                            int result = dbContext.SaveChanges();
                            if (result > 0)
                            {
                                responseModal.meta.Success = true;
                                responseModal.meta.ErrorCode = -1;
                                responseModal.meta.Message = string.Format("{0} ID : {1} click to {2} ", Lang.EmployeeDetails_UpdateSuccess, employee.EmployeeId, Lang.GeneralUI_Next);
                                responseModal.data = employee;
                                Thread.Sleep(50);
                                return Json(responseModal);
                            }
                            else
                            {
                                responseModal.meta.Success = false;
                                responseModal.meta.ErrorCode = 0;
                                responseModal.meta.Message = Lang.EmployeeDetails_UpdateFailure + " Id:" + employee.EmployeeId;
                                responseModal.data = null;
                                Thread.Sleep(50);
                                return Json(responseModal);
                            }
                        }
                        catch (Exception ex)
                        {
                            Thread.Sleep(50);

                            responseModal.meta.Success = false;
                            responseModal.meta.ErrorCode = 0;
                            responseModal.meta.Message = Lang.EmployeeDetails_UpdateFailure + ":" + ex.Message;
                            responseModal.data = null;
                            return Json(responseModal);
                        }
                    }
                    else
                    {
                        responseModal.meta = new MetaModal
                        {
                            Success = false,
                            Message = Lang.EmployeeQuickReco_NoEmployeeId,
                            ErrorCode = 0 //FAIL
                        };
                        return Json(responseModal);
                    }
                }

            }
        }

        [HttpGet]
        public ActionResult QuickAddOganization(string EmployeeId, int Step = 3)
        {
            EmployeeStep3 employeeStep3 = new EmployeeStep3();
            string MainId = WebCookie.MainComId;
            string IndustryId = WebCookie.IndustryId;
            if (string.IsNullOrEmpty(EmployeeId) || EmployeeId == "0")
            {
                return RedirectToAction("EmployeeQuickAdd", "Employee", new { Step = 1, Message = Lang.EmployeeQuick_Message });
            }
            else
            {
                using (DataBaseContext dataBaseContext = new DataBaseContext())
                {
                    Employee employee = dataBaseContext.Employee.Find(EmployeeId);

                    if (employee != null)
                    {
                        ViewBag.EmployeeId = employee.EmployeeId;
                        ViewBag.MainComId = employee.MainComId;

                        ContractorIdDropDownList(employee.ContractorId);
                        SiteIdDropDownList(employee.SiteId);
                        DepartmentIdDropDownList(employee.DepartmentId);
                        PositionIdDropDownList(IndustryId, employee.PositionId);
                        JobIdDropDownList(IndustryId, employee.JobId);
                        employeeStep3 = new EmployeeStep3
                        {
                            EmployeeId = employee.EmployeeId,
                            FullName = employee.FullName,
                            ContractorId = employee.ContractorId,
                            SiteId = employee.SiteId,
                            DepartmentId = employee.DepartmentId,
                            JobId = employee.JobId,
                            PositionId = employee.PositionId
                        };

                        return View(employeeStep3);
                    }
                    else
                    {
                        return RedirectToAction("EmployeeQuickAdd", "Employee", new { Step = 1 });
                    }
                }
            }
        }
        [HttpPost]
        public ActionResult QuickAddOganization([Bind(Include = "EmployeeId,ContractorId,SiteId,DepartmentId,JobId,PositionId")] EmployeeStep3 employeeStep3)
        {
            ResponseModal responseModal = new ResponseModal { meta = new MetaModal { Success = true, Message = "", ErrorCode = -1 }, data = null };

            string EmployeeId = employeeStep3.EmployeeId;

            if (string.IsNullOrEmpty(EmployeeId))
            {
                responseModal.meta = new MetaModal
                {
                    Success = false,
                    Message = Lang.EmployeeQuickReco_NoEmployeeId,
                    ErrorCode = 0 //FAIL
                };
                return Json(responseModal);
            }
            string CompanyName = Organization.GetMainComCompanyName( WebCookie.MainComId);
            string ContractorName = Organization.GetContractorName(employeeStep3.ContractorId);
            string SiteName = Organization.GetSiteName(employeeStep3.SiteId);
            string DepartmentName = Organization.GetDepartmentName(employeeStep3.DepartmentId);
            string PositionTitle = Organization.GetPositionTitle(employeeStep3.PositionId);
            string JobName = Organization.GetJobName(employeeStep3.JobId);

            if (string.IsNullOrEmpty(ContractorName) && string.IsNullOrEmpty(SiteName) && string.IsNullOrEmpty(DepartmentName) && string.IsNullOrEmpty(PositionTitle) && string.IsNullOrEmpty(JobName))
            {
                responseModal.meta = new MetaModal
                {
                    Success = false,
                    Message = Lang.EmployeeQuickReco_IsAllBlank,
                    ErrorCode = 0 //FAIL
                };
                return Json(responseModal);
            }
            else
            {
                using (DataBaseContext dataBaseContext = new DataBaseContext())
                {
                    Employee employee = dataBaseContext.Employee.Find(EmployeeId);

                    if (employee != null)
                    {
                        ViewBag.EmployeeId = employee.EmployeeId;
                        ViewBag.MainComId = employee.MainComId;

                        if (!string.IsNullOrEmpty(CompanyName))
                            employee.CompanyName = CompanyName;


                        if (!string.IsNullOrEmpty(employeeStep3.ContractorId))
                            employee.ContractorId = employeeStep3.ContractorId;
                        if (!string.IsNullOrEmpty(ContractorName))
                            employee.ContractorName = ContractorName;

                        if (!string.IsNullOrEmpty(employeeStep3.SiteId))
                            employee.SiteId = employeeStep3.SiteId;
                        if (!string.IsNullOrEmpty(SiteName))
                            employee.SiteName = SiteName;

                        if (!string.IsNullOrEmpty(employeeStep3.DepartmentId))
                            employee.DepartmentId = employeeStep3.DepartmentId;
                        if (!string.IsNullOrEmpty(DepartmentName))
                            employee.DepartmentName = DepartmentName;

                        if (!string.IsNullOrEmpty(employeeStep3.JobId))
                            employee.JobId = employeeStep3.JobId;
                        if (!string.IsNullOrEmpty(JobName))
                            employee.JobName = JobName;
                        if (!string.IsNullOrEmpty(employeeStep3.PositionId))
                            employee.PositionId = employeeStep3.PositionId;
                        if (!string.IsNullOrEmpty(PositionTitle))
                            employee.PositionTitle = PositionTitle;

                        try
                        {
                            dbContext.Employee.Update(employee);
                            int result = dbContext.SaveChanges();
                            if (result > 0)
                            {
                                responseModal.meta.Success = true;
                                responseModal.meta.ErrorCode = -1;
                                responseModal.meta.Message = string.Format("{0} ID : {1} click to {2} ", Lang.EmployeeDetails_UpdateSuccess, employee.EmployeeId, Lang.GeneralUI_Next);
                                responseModal.data = employee;

                                Thread.Sleep(1000);
                                return Json(responseModal);
                            }
                            else
                            {
                                responseModal.meta.Success = false;
                                responseModal.meta.ErrorCode = 0;
                                responseModal.meta.Message = Lang.EmployeeDetails_UpdateFailure + " Id:" + employee.EmployeeId;
                                responseModal.data = null;
                                return Json(responseModal);
                            }
                        }
                        catch (Exception ex)
                        {
                            Thread.Sleep(1000);

                            responseModal.meta.Success = false;
                            responseModal.meta.ErrorCode = 0;
                            responseModal.meta.Message = Lang.EmployeeDetails_UpdateFailure + ":" + ex.Message;
                            responseModal.data = null;
                            return Json(responseModal);
                        }
                    }
                    else
                    {
                        responseModal.meta = new MetaModal
                        {
                            Success = false,
                            Message = Lang.EmployeeQuickReco_NoEmployeeId,
                            ErrorCode = 0 //FAIL
                        };
                        return Json(responseModal);
                    }
                }

            }
        }

        [HttpGet]
        public ActionResult QuickAddIdNumber(string EmployeeId, int Step = 4)
        {
            EmployeeStep4 employeeStep4 = new EmployeeStep4();

            if (string.IsNullOrEmpty(EmployeeId) || EmployeeId == "0")
            {
                return RedirectToAction("EmployeeQuickAdd", "Employee", new { Step = 1, Message = Lang.EmployeeQuick_Message });
            }
            else
            {
                using (DataBaseContext dataBaseContext = new DataBaseContext())
                {
                    Employee employee = dataBaseContext.Employee.Find(EmployeeId);

                    if (employee != null)
                    {
                        ViewBag.EmployeeId = employee.EmployeeId;
                        ViewBag.MainComId = employee.MainComId;
                        employeeStep4 = new EmployeeStep4
                        {
                            FullName = string.Format("{0} {1} {2}", employee.CnName, employee.LastName, employee.FirstName).Trim(),
                            Gender = (Genders)employee.Gender,
                            IdNumber = employee.IdNumber,
                            Birthday = employee.Birthday
                        };
                        GendersDropDownList(employee.Gender);
                        return View(employeeStep4);
                    }
                    else
                    {
                        return RedirectToAction("EmployeeQuickAdd", "Employee", new { Step = 1, Message = Lang.EmployeeQuick_Message });
                    }
                }

            }
        }

        [HttpPost]
        public ActionResult QuickAddIdNumber([Bind(Include = "EmployeeId,Gender,IdNumber,Birthday")] EmployeeStep4 employeeStep4)
        {
            ResponseModal responseModal = new ResponseModal { meta = new MetaModal { Success = true, Message = "", ErrorCode = -1 }, data = null };

            string EmployeeId = employeeStep4.EmployeeId;

            if (string.IsNullOrEmpty(EmployeeId))
            {
                responseModal.meta = new MetaModal
                {
                    Success = false,
                    Message = Lang.EmployeeQuickReco_NoEmployeeId,
                    ErrorCode = 0 //FAIL
                };
                return Json(responseModal);
            }
            if (string.IsNullOrEmpty(employeeStep4.IdNumber) && employeeStep4.Gender == Genders.Unkown && employeeStep4.Birthday.Year < 2015)
            {
                responseModal.meta = new MetaModal
                {
                    Success = false,
                    Message = Lang.QuickAddIdNumber_IsBlank,
                    ErrorCode = 0 //FAIL
                };
                return Json(responseModal);
            }
            else
            {
                using (DataBaseContext dataBaseContext = new DataBaseContext())
                {
                    Employee employee = dataBaseContext.Employee.Find(EmployeeId);

                    if (employee != null)
                    {
                        ViewBag.EmployeeId = employee.EmployeeId;
                        ViewBag.MainComId = employee.MainComId;

                        employee.Gender = (int)employeeStep4.Gender;
                        employee.IdNumber = employeeStep4.IdNumber;
                        employee.Birthday = employeeStep4.Birthday;

                        try
                        {
                            dbContext.Employee.Update(employee);
                            int result = dbContext.SaveChanges();
                            if (result > 0)
                            {
                                responseModal.meta.Success = true;
                                responseModal.meta.ErrorCode = -1;
                                responseModal.meta.Message = string.Format("{0} ID : {1}", Lang.EmployeeDetails_UpdateSuccess, employee.EmployeeId);
                                responseModal.data = employee;

                                Thread.Sleep(500);
                                return Json(responseModal);
                            }
                            else
                            {
                                responseModal.meta.Success = false;
                                responseModal.meta.ErrorCode = 0;
                                responseModal.meta.Message = Lang.EmployeeDetails_UpdateFailure + " Id:" + employee.EmployeeId;
                                responseModal.data = employee;
                                return Json(responseModal);
                            }
                        }
                        catch (Exception ex)
                        {

                            responseModal.meta.Success = false;
                            responseModal.meta.ErrorCode = 0;
                            responseModal.meta.Message = Lang.EmployeeDetails_UpdateFailure + ":" + ex.Message;
                            responseModal.data = null;
                            Thread.Sleep(1000);
                            return Json(responseModal);
                        }
                    }
                    else
                    {
                        return RedirectToAction("EmployeeQuickAdd", "Employee", new { Step = 1, Message = Lang.EmployeeQuick_Message });
                    }
                }

            }
        }
    }
}