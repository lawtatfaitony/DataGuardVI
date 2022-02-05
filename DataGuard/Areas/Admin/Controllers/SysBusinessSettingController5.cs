using AttendanceBussiness;
using Common;
using DataGuard.Context;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Web.Mvc;
using X.PagedList;
using static AttendanceBussiness.ShiftBusiness;

namespace DataGuard.Areas.Admin.Controllers
{
    public partial class SysBusinessSettingController : BaseController
    {
        // GET: Admin/SysBusinessSetting
        [Authorize(Roles = "Admin,MainComOprerator,SystemAdmin")]
        public ActionResult ShiftList(string shiftListDateRange, string departmentId, string shiftBusinessMode, string shiftAppliedMode, string approvedMode, string sortOrder, string searchString, string currentFilter, int? page)
        {
            string MainComId = !string.IsNullOrEmpty(WebCookie.MainComId) ? WebCookie.MainComId : dbContext.AspNetUsers.Find(User.Identity.GetUserId()).MainComId;

            ViewBag.CurrentDepartmentId = string.IsNullOrEmpty(departmentId) ? null : departmentId;
            DepartmentIdDropDownList(departmentId);

            ViewBag.CurrentShiftBusinessMode = string.IsNullOrEmpty(shiftBusinessMode) ? null : shiftBusinessMode;
            ShiftBusinessModeDropDownList(shiftBusinessMode);

            ViewBag.CurrentShiftAppliedMode = string.IsNullOrEmpty(shiftAppliedMode) ? null : shiftAppliedMode;
            ShiftAppliedModeDropDownList(shiftAppliedMode);

            ViewBag.CurrentApprovedMode = string.IsNullOrEmpty(approvedMode) ? null : approvedMode;
            ApprovedModeDropDownList(approvedMode);

            //DateRange
            DateTime dt = DateTime.Now;
            long appliedStartDate = dt.Ticks;
            long appliedEndDate = dt.Ticks;
            if (!string.IsNullOrEmpty(shiftListDateRange))
            {
                shiftListDateRange = this.Server.UrlDecode(shiftListDateRange);
                DateTimeRangeObj dateTimeRangeObj = new DateTimeRangeObj();
                dateTimeRangeObj = CommonBase.DateTimeRangeParse(shiftListDateRange);
                appliedStartDate = DateTimePubBusiness.SetZeroSecond(dateTimeRangeObj.Start).Ticks;
                appliedEndDate = DateTimePubBusiness.SetZeroSecond(dateTimeRangeObj.End).Ticks;
                ViewBag.CurrentShiftDateRange = string.Format("{0:yyyy-MM-ddTHH:mm}-{1:yyyy-MM-ddTHH:mm}", new DateTime(appliedStartDate), new DateTime(appliedEndDate));
            }
            else
            {
                ViewBag.CurrentShiftDateRange = string.Format("{0:yyyy-MM-ddTHH:mm}-{1:yyyy-MM-ddTHH:mm}", dt, dt);
                appliedEndDate = appliedStartDate;
            }

            //----------------------------------------------------------------------------
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            string CurrentUserMainId = dbContext.AspNetUsers.Find(User.Identity.GetUserId()).MainComId;
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var shiftList = from s in dbContext.Shift
                            select s;

            //string shiftListJsonPath = Server.MapPath("/Upload/JsonData/");
            //string shiftJsonFileName = "ShiftList.json";
            //string shiftListJsonContent = JsonConvert.SerializeObject(shiftList.ToList());
            //CommonBase.SaveDataJson(shiftListJsonContent, shiftListJsonPath, shiftJsonFileName);

            if (!String.IsNullOrEmpty(searchString))
            {
                shiftList = shiftList.Where(s => s.ShiftAbbrId.Contains(searchString)
                                       || s.ShiftId.Contains(searchString)
                                       || s.ShiftAbbrId.Contains(searchString)
                                       || s.ShiftName.Contains(searchString)
                                       || s.OperatedUserName.Contains(searchString));
            }
            if (appliedStartDate != appliedEndDate)
            {
                shiftList = shiftList.Where(c => c.AppliedStartDate <= new DateTime(appliedStartDate) && c.AppliedEndDate >= new DateTime(appliedEndDate));
            }
            if (!String.IsNullOrEmpty(departmentId))
            {
                shiftList = shiftList.Where(c => c.DepartmentIdArr.Contains(departmentId));
            }
            if (!String.IsNullOrEmpty(shiftBusinessMode))
            {
                ShiftBusinessMode shiftBusinessMode1 = (ShiftBusinessMode)Enum.Parse(typeof(ShiftBusinessMode), shiftBusinessMode.ToUpper());
                try
                {
                    int shiftBusinessModeParse = (int)shiftBusinessMode1;
                    shiftList = shiftList.Where(c => c.ShiftAppliedMode == (int)shiftBusinessModeParse);
                }
                catch
                {
                    throw;
                }
            }
            if (!String.IsNullOrEmpty(shiftAppliedMode))
            {
                ShiftAppliedMode shiftAppliedMode1 = (ShiftAppliedMode)Enum.Parse(typeof(ShiftAppliedMode), shiftAppliedMode.ToUpper());
                try
                {
                    int shiftAppliedModeParse = (int)shiftAppliedMode1;
                    shiftList = shiftList.Where(c => c.ShiftAppliedMode == (int)shiftAppliedMode1);
                }
                catch
                {
                    throw;
                }


            }
            if (!String.IsNullOrEmpty(approvedMode))
            {
                bool approvedModeParse;
                if (bool.TryParse(approvedMode.ToLower(), out approvedModeParse))
                {
                    shiftList = shiftList.Where(c => c.IsApproved == approvedModeParse);
                }
            }
            switch (sortOrder)
            {
                case "Date":
                    shiftList = shiftList.OrderBy(s => s.AppliedStartDate);
                    break;
                case "date_desc":
                    shiftList = shiftList.OrderByDescending(s => s.AppliedStartDate);
                    break;
                default:
                    shiftList = shiftList.OrderByDescending(s => s.AppliedStartDate);
                    break;
            }

            int pageSize = 100;
            int pageNumber = (page ?? 1);
            return View(shiftList.ToPagedList(pageNumber, pageSize));
        }
    }
}