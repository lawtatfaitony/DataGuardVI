using AttendanceBussiness;
using AttendanceBussiness.DbFirst;
using AttendanceBussiness.Public;
using DataGuard.Context;
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
        public ActionResult ShiftSettingWeekDay(string ShiftId)
        {
            ShiftExcludeWeekDayView shiftSetting = new ShiftExcludeWeekDayView();

            if (string.IsNullOrEmpty(ShiftId))
            {
                ViewBag.ShiftId = string.Empty; ;
                ViewBag.IsUpdateStatus = false;

                shiftSetting.MainComId =string.Empty;
                shiftSetting.ShiftBusinessMode = ShiftBusinessMode.GENERAL;
                ViewBag.ShiftBusinessMode = (int)ShiftBusinessMode.GENERAL;
                shiftSetting.IconColor = "FC0366";

                shiftSetting.AppliedStartDate = DateTime.Now;
                shiftSetting.AppliedEndDate = DateTime.Now;
                shiftSetting.IsAutoCalcMissing = true;

                PopulateAssignedWeekDayType(string.Empty);
                PopulateAssignedExcludeWeekDay(string.Empty);
                ShiftAppliedModeDropDownList(ShiftAppliedMode.GLOBAL);
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
                shiftSetting.IconColor = shift.IconColor?? "FC0366";
                shiftSetting.ShiftAbbrId = shift.ShiftAbbrId ?? DateTime.Now.Millisecond.ToString();
                shiftSetting.ShiftName = shift.ShiftName ?? string.Empty;
                shiftSetting.ShiftBusinessMode = (ShiftBusinessMode)shift.ShiftBusinessMode;
                ViewBag.ShiftBusinessMode = shift.ShiftBusinessMode;
                 
                shiftSetting.CompanyName = shift.CompanyName ?? string.Empty;

                shiftSetting.WorkStart = shift.WorkStart;
                ViewBag.WorkStartMinutes = shiftSetting.WorkStart.Duration().Minutes; //----------------convert to  total minutes

                shiftSetting.WorkEnd = shift.WorkEnd;
                ViewBag.WorkEndMinutes = shiftSetting.WorkEnd.Duration().Minutes; //----------------convert to  total minutes

                shiftSetting.SpecialWeekDaysWorkStart = shift.SpecialWeekDaysWorkStart;
                shiftSetting.SpecialWeekDaysWorkEnd = shift.SpecialWeekDaysWorkEnd;

                shiftSetting.WorkStartAllowance = shift.WorkStartAllowance;
                shiftSetting.WorkEndAllowance = shift.WorkEndAllowance;
                shiftSetting.WorkStartBuffer = shift.WorkStartBuffer;
                shiftSetting.WorkEndBuffer = shift.WorkEndBuffer;
                shiftSetting.AppliedStartDate = shift.AppliedStartDate;
                shiftSetting.AppliedEndDate = shift.AppliedEndDate;
                shiftSetting.RuleDescription = shift.RuleDescription;

                PopulateAssignedWeekDayType(shiftSetting.ShiftId);
                PopulateAssignedExcludeWeekDay(shiftSetting.ShiftId);

                return View(shiftSetting);
            }
        }

        // POST: Admin/SysBusinessSetting
        [HttpPost]
        public ActionResult ShiftSettingWeekDay(string ShiftId, [Bind(Include = "ShiftId,ShiftAbbrId,ShiftName,ShiftBusinessMode,ShiftAppliedMode, MainComId, CompanyName, WorkStart, WorkEnd, WorkStartAllowance, WorkEndAllowance, WorkStartBuffer, WorkEndBuffer,SpecialWeekDays, " +
            "SpecialWeekDaysWorkStart,SpecialWeekDaysWorkEnd,ExcludeWeekDay, AppliedStartDate, AppliedEndDate, RuleDescription")]ShiftExcludeWeekDayView shiftExcludeWeekDayView)
        {
            ModalDialog modalDialog = new ModalDialog();

            if (shiftExcludeWeekDayView.AppliedEndDate < DateTime.Now || shiftExcludeWeekDayView.AppliedEndDate < shiftExcludeWeekDayView.AppliedStartDate)
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
                Shift shift = new Shift
                {
                    ShiftId = dbContext.GetTableKeyID_DatePeriod(shiftExcludeWeekDayView.AppliedStartDate, shiftExcludeWeekDayView.AppliedEndDate ),
                    ShiftAbbrId = shiftExcludeWeekDayView.ShiftAbbrId,
                    ShiftName = shiftExcludeWeekDayView.ShiftName,
                    ShiftBusinessMode = (int)shiftExcludeWeekDayView.ShiftBusinessMode,
                    ShiftAppliedMode = (int)shiftExcludeWeekDayView.ShiftAppliedMode,
                    CompanyName = shiftExcludeWeekDayView.CompanyName??string.Empty,
                    WorkTimeSpan = Math.Abs(DateTimePubBusiness.TimeSpanHourDiff(shiftExcludeWeekDayView.WorkStart, shiftExcludeWeekDayView.WorkEnd, 1)),
                    WorkStart = shiftExcludeWeekDayView.WorkStart,
                    WorkEnd = shiftExcludeWeekDayView.WorkEnd,
                    WorkStartAllowance = shiftExcludeWeekDayView.WorkStartAllowance,
                    WorkEndAllowance = shiftExcludeWeekDayView.WorkEndAllowance,
                    WorkStartBuffer = shiftExcludeWeekDayView.WorkStartBuffer,
                    WorkEndBuffer = shiftExcludeWeekDayView.WorkEndBuffer
                };

                shift.SpecialWeekDays = UpdateUserWeekDayType(shiftExcludeWeekDayView.ExcludeWeekDay, shift.ShiftId);
                shift.SpecialWeekDaysWorkStart = shiftExcludeWeekDayView.SpecialWeekDaysWorkStart;
                shift.SpecialWeekDaysWorkEnd = shiftExcludeWeekDayView.SpecialWeekDaysWorkEnd;

                shift.ExcludeWeekDay = UpdateUserWeekDayType(shiftExcludeWeekDayView.ExcludeWeekDay, shift.ShiftId);

                //-------------------------default value start 
                shift.OverTimeSpan = 0;
                shift.OverTimeStart = new TimeSpan(0, 0, 0);
                shift.OverTimeEnd = new TimeSpan(0, 0, 0);
                shift.OverTimeStartBuffer = 0;
                shift.OverTimeEndBuffer = 0;
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
                shift.AppliedStartDate = shiftExcludeWeekDayView.AppliedStartDate;
                shift.AppliedEndDate = shiftExcludeWeekDayView.AppliedEndDate;
                shift.RuleDescription = shiftExcludeWeekDayView.RuleDescription;

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
                modalDialog.MsgCode = "1";
                modalDialog.Message = Lang.Shift_Return_Update_Success;  // update success

                //----update
                Shift shift = dbContext.Shift.Find(shiftExcludeWeekDayView.ShiftId);


                shift.WorkTimeSpan = DateTimePubBusiness.TimeSpanHourDiff(shiftExcludeWeekDayView.WorkStart, shiftExcludeWeekDayView.WorkEnd, 1);
                shift.WorkStart = shiftExcludeWeekDayView.WorkStart;
                shift.WorkEnd = shiftExcludeWeekDayView.WorkEnd;
                shift.WorkStartAllowance = shiftExcludeWeekDayView.WorkStartAllowance;
                shift.WorkEndAllowance = shiftExcludeWeekDayView.WorkEndAllowance;
                shift.WorkStartBuffer = shiftExcludeWeekDayView.WorkStartBuffer;
                shift.WorkEndBuffer = shiftExcludeWeekDayView.WorkEndBuffer;
                 
                shift.SpecialWeekDays = UpdateUserWeekDayType(shiftExcludeWeekDayView.SpecialWeekDays, shift.ShiftId);
                shift.SpecialWeekDaysWorkStart = shiftExcludeWeekDayView.SpecialWeekDaysWorkStart;
                shift.SpecialWeekDaysWorkEnd = shiftExcludeWeekDayView.SpecialWeekDaysWorkEnd;

                shift.ExcludeWeekDay = UpdateUserWeekDayType(shiftExcludeWeekDayView.ExcludeWeekDay, shift.ShiftId);
    

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