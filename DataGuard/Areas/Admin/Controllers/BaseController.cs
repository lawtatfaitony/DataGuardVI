using AttendanceBussiness;
using AttendanceBussiness.DbFirst;
using AttendanceBussiness.Public;
using AttendanceBussiness.ScheduleBusiness;
using AttEnumCode;
using DataGuard.Areas.Admin.ModelView;
using DataGuard.Context;
using DataGuard.Utilities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using static AttendanceBussiness.ShiftBusiness;

namespace DataGuard.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        private string _MainComId;
        private string _IndustryId;
        public string MainComId
        {
            get
            {
                string MainComId = !string.IsNullOrEmpty(WebCookie.MainComId) ? WebCookie.MainComId : dbContext.AspNetUsers.Find(User.Identity.GetUserId()).MainComId;
                return MainComId;
            }
            set
            {
                _MainComId = value;
            }
        }
        public string IndustryId
        {
            get
            {
                return WebCookie.IndustryId;
            }
            set
            {
                WebCookie.IndustryId = value;
                _IndustryId = value;
            }
        }

        public AttendanceBussiness.DbFirst.DataBaseContext dbContext = new AttendanceBussiness.DbFirst.DataBaseContext();

        #region OGANIZATION DROPDOWNLIST
        public void ContractorIdDropDownList(object selectedContractorId = null)
        {
            var ContractorQuery = dbContext.Contractor;

            ViewBag.ContractorId = new SelectList(ContractorQuery, "ContractorId", "ContractorName", selectedContractorId);
        }
        public void SiteIdDropDownList(object selectedSiteId = null)
        {
            var SiteQuery = dbContext.Site;

            ViewBag.SiteId = new SelectList(SiteQuery, "SiteId", "SiteName", selectedSiteId);
        }

        public void DepartmentIdDropDownList(object selectedDepartmentId = null)
        {
           
            var DepartmentQuery = Organization.GetDepartmentSwitchLangList().ToList();

            ViewBag.DepartmentId = new SelectList(DepartmentQuery, "DepartmentId", "DepartmentName", selectedDepartmentId);
        }

        public void PositionIdDropDownList(string IndustryId, object selectedPositionId = null)
        {
            var PositionQuery = dbContext.Position.Where(c => c.IndustryId.Contains(IndustryId));

            ViewBag.PositionId = new SelectList(PositionQuery, "PositionId", "PositionTitle", selectedPositionId);
        }

        public void JobIdDropDownList(string IndustryId, object selectedJobId = null)
        {
            var JobQuery = dbContext.Job.Where(c => c.IndustryId.Contains(IndustryId));

            ViewBag.JobId = new SelectList(JobQuery, "JobId", "JobName", selectedJobId);
        }

        public void IndustryIdDropDownList(string IndustryId, object selectedIndustryId = null)
        {
            var IndustryQuery = dbContext.Industry.Where(c => c.IndustryId.Contains(IndustryId)).ToList();

            ViewBag.IndustryId = new SelectList(IndustryQuery, "IndustryId", "IndustryName", selectedIndustryId);
        }
        #endregion OGANRIZATION DROPDOWNLIST

        #region OGANIZATION JSON RESULT
        public JsonResult GetContractorJSON()
        {
            var ContractorQuery = dbContext.Contractor;
            return Json(ContractorQuery, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSiteJSON()
        {
            var SiteQuery = dbContext.Site;
            return Json(SiteQuery, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDepartmentJSON()
        {
            var DepartmentQuery = dbContext.Department;
            return Json(DepartmentQuery, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPositionJSON()
        {
            var PositionQuery = dbContext.Position;
            return Json(PositionQuery, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetJobJSON()
        {
            var JobQuery = dbContext.Job;
            return Json(JobQuery, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetIndustryJSON()
        {
            var IndustryQuery = dbContext.Industry;
            return Json(IndustryQuery, JsonRequestBehavior.AllowGet);
        }
        #endregion OGANIZATION JSON RESULT

        public void ShiftDepartmentArrCheckBox(string ShiftId)
        {
            List<AssignedDepartment> assignedDepartments = ScheduleUtilize.ShiftDepartmentChkLst(dbContext, ShiftId);
            ViewBag.AssignedDepartments = assignedDepartments;
        }
        public void StatutoryHolidayDropDownList(object selectedStatutoryHoliday = null)
        {
            var StatutoryHolidayQuery = EnumHelper.GetSelectList<StatutoryHoliday>();
            var StatutoryHolidayListDown = new SelectList(StatutoryHolidayQuery, "Value", "Text", selectedStatutoryHoliday);
            ViewBag.StatutoryHoliday = StatutoryHolidayListDown;
        }
        public void ApprovedModeDropDownList(object selectedApprovedMode = null)
        {
            var ApprovedModeQuery = EnumHelper.GetSelectList<ApprovedMode>();
            ApprovedModeQuery.Where(c => c.Value != ApprovedMode.False.ToString());

            var ApprovedModeListDown = new SelectList(ApprovedModeQuery, "Value", "Text", selectedApprovedMode);
            ViewBag.ApprovedMode = ApprovedModeListDown.ToList();
            ViewBag.IsApproved = ApprovedModeListDown.ToList();
        }
        public void LeaveTypeDropDownList(object selectedLeaveType = null)
        {
            var LeaveTypeQuery = EnumHelper.GetSelectList<LeaveType>();
            var LeaveTypeListDown = new SelectList(LeaveTypeQuery, "Value", "Text", selectedLeaveType);
            ViewBag.LeaveType = LeaveTypeListDown.ToList();
        }
        public void LeavePaidTypeDropDownList(object selectedLeavePaidType = null)
        {
            var LeavePaidTypeQuery = EnumHelper.GetSelectList<LeavePaidType>();
            var LeavePaidTypeListDown = new SelectList(LeavePaidTypeQuery, "Value", "Text", selectedLeavePaidType);
            ViewBag.LeavePaidType = LeavePaidTypeListDown;
        }
        public void HolidayPaidTypeDropDownList(object selectedHolidayPaidType = null)
        {
            var HolidayPaidTypeQuery = EnumHelper.GetSelectList<HolidayPaidType>();
            var HolidayPaidTypeListDown = new SelectList(HolidayPaidTypeQuery, "Value", "Text", selectedHolidayPaidType);
            ViewBag.HolidayPaidType = HolidayPaidTypeListDown;
        }
        public void HolidayIsWholeDayTypeDropDownList(object selectedHolidayIsWholeDayType = null)
        {
            var HolidayIsWholeDayTypeQuery = EnumHelper.GetSelectList<HolidayIsWholeDayType>();
            var HolidayIsWholeDayTypeListDown = new SelectList(HolidayIsWholeDayTypeQuery, "Value", "Text", selectedHolidayIsWholeDayType);
            ViewBag.HolidayIsWholeDayType = HolidayIsWholeDayTypeListDown;
        }
        /// <summary>
        /// On Duty PaidRatio
        /// </summary>
        /// <param name="selectedValue">1.0</param>
        public void OnDutyPaidRatioDropDownList(string selectedValue)
        {
            if (string.IsNullOrEmpty(selectedValue))
            {
                selectedValue = string.Empty;
            }

            List<SelectListItem> selectLists = new List<SelectListItem>();
            for (int i = 10; i <= 30; i++)
            {
                string Text1 = string.Format("{0}%", i * 10);
                float V1 = (float)i / 10;
                string Value1 = string.Format("{0:f1}", V1);
                bool Selected1 = false;
                if (Text1 == "100%" && string.IsNullOrEmpty(selectedValue))
                {
                    Selected1 = true;
                }
                if (selectedValue.Trim() == Value1)
                {
                    Selected1 = true;
                }
                SelectListItem selectListItem = new SelectListItem { Text = Text1, Value = Value1, Selected = Selected1 };
                selectLists.Add(selectListItem);
            }
            selectLists.Insert(0, new SelectListItem { Text = "0%", Value = "0" });
            var OnDutyPaidRatioListDown = new SelectList(selectLists, "Value", "Text");
            ViewBag.OnDutyPaidRatio = OnDutyPaidRatioListDown;
        }

        public JsonResult GetStatementPanel()
        {
            string MainComId = WebCookie.MainComId;
            string IndustryId = WebCookie.IndustryId;
            MainCom mainCom = dbContext.MainCom.Find(MainComId);
            DateTime dateTime = DateTime.Now;
            long ticks = dateTime.Ticks;
            StatementPanel statementPanel = new StatementPanel();
            statementPanel.CurrentLeaveApproval = dbContext.Leave.Where(c => c.LeaveStartDate.Ticks > DateTime.Now.Ticks && c.IsApproved == true && c.ApplovedBy.Trim() != "0" && c.MainComId.Contains(MainComId)).Count();
            statementPanel.CurrentLeaveWaitForApproval = dbContext.Leave.Where(c => c.IsApproved == false && c.ApplovedBy.Trim() == "0" && c.MainComId.Contains(MainComId)).Count();
            statementPanel.CurrentTotalShift = dbContext.Shift.Where(c => c.AppliedStartDate.Ticks < ticks && c.AppliedEndDate.Ticks > ticks && c.IsApproved == true).Count();
            statementPanel.CurrentTotalMainCom = dbContext.MainCom.Count(); //cloud
            statementPanel.CurrentTotalContractor = dbContext.Contractor.Count();
            statementPanel.CurrentTotalEmployee = dbContext.Employee.Where(c => c.IsBlock == false).Count();
            statementPanel.CurrentPeopleIsBlock = dbContext.Employee.Where(c => c.IsBlock == true).Count();
            statementPanel.CurrentTotalIndustry = dbContext.Industry.Count(); //cloud
            statementPanel.CurrentTotalJob = dbContext.Job.Count() == 0 ? 0 : dbContext.Job.Where(c => c.IndustryId == IndustryId).Count();
            statementPanel.CurrentTotalPosition = dbContext.Position.Count() == 0 ? 0 : dbContext.Position.Where(c => c.IndustryId == IndustryId).Count();
            statementPanel.CurrentTotalSite = dbContext.Site.Count() == 0 ? 0 : dbContext.Site.Count();
            statementPanel.CurrentTotalDepartment = dbContext.Department.Count() ;
            return Json(statementPanel, JsonRequestBehavior.AllowGet);
        }
         

        [HttpGet]
        public ActionResult ResponseModal(ResponseModal responseModal)
        {
            return View(responseModal);
        }

        /// <summary>
        /// List转SelectListItem
        /// </summary>
        /// <typeparam name="T">Model对象</typeparam>
        /// <param name="t">集合</param>
        /// <param name="text">显示值-属性名</param>
        /// <param name="value">显示值-属性名</param>
        /// <param name="empId"></param>
        /// <returns></returns>
        public List<SelectListItem> CreateEnumSelect(List<EnumItem> list, string selectValue)
        {
            List<SelectListItem> selList = new List<SelectListItem>();
            foreach (var item in list)
            { 
                selList.Add(new SelectListItem
                { 
                    Text = item.Text,
                    Value = item.Value,
                    Selected = item.Value == selectValue 
                });
            }
            return selList;
        }
    }
}