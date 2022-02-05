using AttendanceBussiness;
using AttendanceBussiness.DbFirst;
using AttendanceBussiness.Public;
using LanguageResource;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;
using static AttendanceBussiness.ShiftBusiness;

namespace DataGuard.Areas.Admin.Controllers
{
    public partial class SysBusinessSettingController : BaseController
    {
        // GET: Admin/SysBusinessSetting
        [HttpGet]
        [Authorize(Roles = "Admin,Emplyee,MainComOprerator,SystemAdmin")]
        public ActionResult ShiftSettingOverTime(string ShiftId)
        {
            ShiftOverTimeView shiftSetting = new ShiftOverTimeView();

            if (string.IsNullOrEmpty(ShiftId))
            {
                ViewBag.ShiftId = string.Empty; ;
                ViewBag.IsUpdateStatus = false;

                shiftSetting.MainComId = DataGuard.Context.WebCookie.MainComId;
                shiftSetting.ShiftBusinessMode = ShiftBusinessMode.GENERAL;

                ViewBag.ShiftBusinessMode = (int)ShiftBusinessMode.GENERAL;

                shiftSetting.ShiftAppliedMode = ShiftAppliedMode.PARTIAL;

                shiftSetting.AppliedStartDate = DateTime.Now;
                shiftSetting.AppliedEndDate = DateTime.Now;
                shiftSetting.IsAutoCalcMissing = true;

                PopulateAssignedWeekDayType(string.Empty);

                ////-------------------------default value start 
                shiftSetting.WorkStart = new TimeSpan(21, 0, 0);
                shiftSetting.SpecialWeekDaysWorkStart = new TimeSpan(0, 0, 0);
                ViewBag.WorkStartMinutes = shiftSetting.WorkStart.Duration().Minutes; //----------------convert to  total minutes

                shiftSetting.WorkEnd = new TimeSpan(5, 0, 0);
                shiftSetting.SpecialWeekDaysWorkEnd = new TimeSpan(23, 59, 0);
                ViewBag.WorkEndMinutes = shiftSetting.WorkEnd.Duration().Minutes; //----------------convert to  total minutes

                shiftSetting.WorkStartAllowance = 0;
                shiftSetting.WorkEndAllowance = 0;
                shiftSetting.WorkStartBuffer = 0;
                shiftSetting.WorkEndBuffer = 0;
                //-------------------------default value end

                return View(shiftSetting);
            }
            else
            {
                ViewBag.ShiftId = ShiftId;
                ViewBag.IsUpdateStatus = true;
                Shift shift = dbContext.Shift.Find(ShiftId);

                shiftSetting.ShiftId = shift.ShiftId;
                shiftSetting.ShiftAbbrId = shift.ShiftAbbrId;
                shiftSetting.ShiftName = shift.ShiftName;
                shiftSetting.ShiftBusinessMode = (ShiftBusinessMode)shift.ShiftBusinessMode;
                ViewBag.ShiftBusinessMode = shift.ShiftBusinessMode;

                shiftSetting.ShiftAppliedMode = (ShiftAppliedMode)shift.ShiftAppliedMode; 
                shiftSetting.CompanyName = shift.CompanyName;

                shiftSetting.WorkStart = shift.WorkStart;
                ViewBag.WorkStartMinutes = shiftSetting.WorkStart.Duration().Minutes; //----------------convert to  total minutes

                shiftSetting.WorkEnd = shift.WorkEnd;
                ViewBag.WorkEndMinutes = shiftSetting.WorkEnd.Duration().Minutes; //----------------convert to  total minutes

                shiftSetting.SpecialWeekDaysWorkStart = shift.SpecialWeekDaysWorkStart;
                shiftSetting.SpecialWeekDaysWorkEnd = shift.SpecialWeekDaysWorkEnd;

                shiftSetting.OverTimeStart = shift.OverTimeStart == null ? new TimeSpan(0, 0, 0) : shift.OverTimeStart;
                shiftSetting.OverTimeEnd = shift.OverTimeEnd == null ? new TimeSpan(0, 0, 0) : shift.OverTimeEnd;
                shiftSetting.OverTimeStartBuffer = shift.OverTimeStartBuffer;
                shiftSetting.OverTimeEndBuffer = shift.OverTimeEndBuffer;

                shiftSetting.WorkStartAllowance = shift.WorkStartAllowance;
                shiftSetting.WorkEndAllowance = shift.WorkEndAllowance;
                shiftSetting.WorkStartBuffer = shift.WorkStartBuffer;
                shiftSetting.WorkEndBuffer = shift.WorkEndBuffer;
                shiftSetting.AppliedStartDate = shift.AppliedStartDate;
                shiftSetting.AppliedEndDate = shift.AppliedEndDate;
                shiftSetting.RuleDescription = shift.RuleDescription;

                PopulateAssignedWeekDayType(shiftSetting.ShiftId);

                return View(shiftSetting);
            }
        }

        // POST: Admin/SysBusinessSetting
        [HttpPost]
        public ActionResult ShiftSettingOverTime(string ShiftId, [Bind(Include = "ShiftId,ShiftAbbrId,ShiftName,ShiftBusinessMode,ShiftAppliedMode, MainComId, CompanyName, WorkStart, WorkEnd, WorkStartAllowance, WorkEndAllowance, WorkStartBuffer, WorkEndBuffer, " +
            "SpecialWeekDaysWorkStart,SpecialWeekDaysWorkEnd,OverTimeStart,OverTimeEnd,OverTimeStartBuffer,OverTimeEndBuffer,AppliedStartDate, AppliedEndDate, RuleDescription")]ShiftOverTimeView shiftGeneralView, string[] SpecialWeekDays)
        {
            ModalDialog modalDialog = new ModalDialog();

            if (shiftGeneralView.AppliedEndDate == null || shiftGeneralView.AppliedEndDate < shiftGeneralView.AppliedStartDate)
            {
                modalDialog.MsgCode = "-1";
                modalDialog.Message = Lang.Shift_AppliedStartDateIsNotLogical_Validator;

                return Json(modalDialog);  // -1;Shift_AppliedStartDateIsNotLogical_Validator
            }

            string UserName = User.Identity.Name;
            string UserId = User.Identity.GetUserId();
            //------------------------------------------------------------------------------------
            if (string.IsNullOrEmpty(ShiftId)) // insert
            {
                modalDialog.MsgCode = "1";
                modalDialog.Message = Lang.Shift_ReturnSuccess;

                //----insert
                Shift shift = new Shift();

                shift.ShiftId = dbContext.GetTableKeyID_DatePeriod(shiftGeneralView.AppliedStartDate, shiftGeneralView.AppliedEndDate);
                shift.ShiftAbbrId = shiftGeneralView.ShiftAbbrId;
                shift.ShiftName = shiftGeneralView.ShiftName;
                shift.ShiftBusinessMode = (int)shiftGeneralView.ShiftBusinessMode;
                shift.ShiftAppliedMode = (int)shiftGeneralView.ShiftAppliedMode;
                shift.CompanyName = dbContext.MainCom.Find(shiftGeneralView.MainComId).CompanyName;
                shift.WorkTimeSpan = Math.Abs(DateTimePubBusiness.TimeSpanHourDiff(shiftGeneralView.WorkStart, shiftGeneralView.WorkEnd, 1));
                shift.WorkStart = shiftGeneralView.WorkStart;
                shift.WorkEnd = shiftGeneralView.WorkEnd;
                shift.WorkStartAllowance = shiftGeneralView.WorkStartAllowance;
                shift.WorkEndAllowance = shiftGeneralView.WorkEndAllowance;
                shift.WorkStartBuffer = shiftGeneralView.WorkStartBuffer;
                shift.WorkEndBuffer = shiftGeneralView.WorkEndBuffer;

                shift.SpecialWeekDays = UpdateUserWeekDayType(SpecialWeekDays, shift.ShiftId);
                shift.SpecialWeekDaysWorkStart = shiftGeneralView.SpecialWeekDaysWorkStart;
                shift.SpecialWeekDaysWorkEnd = shiftGeneralView.SpecialWeekDaysWorkEnd;

                shift.OverTimeSpan = Math.Abs(DateTimePubBusiness.TimeSpanHourDiff(shiftGeneralView.OverTimeStart, shiftGeneralView.OverTimeEnd, 1));
                shift.OverTimeStart = shiftGeneralView.OverTimeStart;
                shift.OverTimeEnd = shiftGeneralView.OverTimeEnd;
                shift.OverTimeStartBuffer = shiftGeneralView.OverTimeStartBuffer;
                shift.OverTimeEndBuffer = shiftGeneralView.OverTimeEndBuffer;

                //-------------------------default value start 

                shift.LunchTimeSpan = 0;
                shift.LunchTimeStart = DateTimePubBusiness.TimeSpanZero();
                shift.LunchTimeEnd = DateTimePubBusiness.TimeSpanZero();
                shift.LunchTimeStartBuffer = 0;
                shift.LunchTimeEndBuffer = 0;
                shift.BreakTimeSpan = 0;
                shift.BreakTimeCalcStart = DateTimePubBusiness.TimeSpanZero();
                shift.BreakTimeCalcEnd = DateTimePubBusiness.TimeSpanZero();
                shift.BreakTimeAllowance = 0;

                //-------------------------default value end 
                shift.AppliedStartDate = shiftGeneralView.AppliedStartDate;
                shift.AppliedEndDate = shiftGeneralView.AppliedEndDate;
                shift.RuleDescription = shiftGeneralView.RuleDescription;

                shift.UpdatedDate = DateTime.Now;
                shift.CreatedDate = DateTime.Now;
                shift.OperatedUserName = UserName;

                try
                {
                    dbContext.Add(shift);
                    dbContext.SaveChanges();

                    modalDialog.MsgCode = shift.ShiftId;
                    modalDialog.Message = Lang.GeneralUI_Success;

                    return Json(modalDialog);
                }
                catch (Exception e)
                {
                    modalDialog.MsgCode = "0";
                    modalDialog.Message = e.Message;
                    return Json(modalDialog);
                }
            }
            else
            {
                //----update
                Shift shift = dbContext.Shift.Find(shiftGeneralView.ShiftId);

                modalDialog.MsgCode = "1";
                modalDialog.Message = Lang.Shift_Return_Update_Success;  // update success

                shift.ShiftId = shiftGeneralView.ShiftId;
                shift.ShiftAbbrId = shiftGeneralView.ShiftAbbrId;
                shift.ShiftName = shiftGeneralView.ShiftName;
                shift.ShiftBusinessMode = (int)shiftGeneralView.ShiftBusinessMode;
                shift.ShiftAppliedMode = (int)shiftGeneralView.ShiftAppliedMode;
                shift.CompanyName = dbContext.MainCom.Find(shiftGeneralView.MainComId).CompanyName;
                shift.WorkTimeSpan = DateTimePubBusiness.TimeSpanHourDiff(shiftGeneralView.WorkStart, shiftGeneralView.WorkEnd, 1);
                shift.WorkStart = shiftGeneralView.WorkStart;
                shift.WorkEnd = shiftGeneralView.WorkEnd;
                shift.WorkStartAllowance = shiftGeneralView.WorkStartAllowance;
                shift.WorkEndAllowance = shiftGeneralView.WorkEndAllowance;
                shift.WorkStartBuffer = shiftGeneralView.WorkStartBuffer;
                shift.WorkEndBuffer = shiftGeneralView.WorkEndBuffer;

                shift.SpecialWeekDays = UpdateUserWeekDayType(SpecialWeekDays, shift.ShiftId);
                shift.SpecialWeekDaysWorkStart = shiftGeneralView.SpecialWeekDaysWorkStart;
                shift.SpecialWeekDaysWorkEnd = shiftGeneralView.SpecialWeekDaysWorkEnd;

                //-------------------------default value start 
                shift.OverTimeSpan = DateTimePubBusiness.TimeSpanHourDiff(shiftGeneralView.OverTimeStart, shiftGeneralView.OverTimeEnd, 1);
                shift.OverTimeStart = shiftGeneralView.OverTimeStart;
                shift.OverTimeEnd = shiftGeneralView.OverTimeEnd;
                shift.OverTimeStartBuffer = shiftGeneralView.OverTimeStartBuffer;
                shift.OverTimeEndBuffer = shiftGeneralView.OverTimeEndBuffer;
                shift.LunchTimeSpan = 0;
                shift.LunchTimeStart = DateTimePubBusiness.TimeSpanZero();
                shift.LunchTimeEnd = DateTimePubBusiness.TimeSpanZero();
                shift.LunchTimeStartBuffer = 0;
                shift.LunchTimeEndBuffer = 0;
                shift.BreakTimeSpan = 0;
                shift.BreakTimeCalcStart = DateTimePubBusiness.TimeSpanZero();
                shift.BreakTimeCalcEnd = DateTimePubBusiness.TimeSpanZero();
                shift.BreakTimeAllowance = 0;
                //-------------------------default value end 

                shift.AppliedStartDate = shiftGeneralView.AppliedStartDate;
                shift.AppliedEndDate = shiftGeneralView.AppliedEndDate;
                shift.RuleDescription = shiftGeneralView.RuleDescription;

                shift.UpdatedDate = DateTime.Now;
                shift.CreatedDate = DateTime.Now;
                shift.OperatedUserName = UserName;

                try
                {
                    bool rejectToModified = ShiftBusinessExtand.ShiftInScheduleRejectToModified(shift.ShiftId, ref modalDialog);
                    if (rejectToModified && shift.IsApproved)
                    {
                        return Json(modalDialog);
                    }
                    dbContext.Update(shift);
                    dbContext.SaveChanges();

                    modalDialog.MsgCode = shift.ShiftId;
                    modalDialog.Message = Lang.GeneralUI_Success;

                    return Json(modalDialog);
                }
                catch (Exception e)
                {
                    modalDialog.MsgCode = "0";
                    modalDialog.Message = e.Message;
                    return Json(modalDialog);
                }
            }
        }

    }
}