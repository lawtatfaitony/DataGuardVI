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
        [Authorize(Roles = "Admin,MainComOprerator,SystemAdmin")]
        public ActionResult ShiftSettingLunch(string ShiftId)
        {
            ShiftGeneralLunchView shiftSetting = new ShiftGeneralLunchView();

            if (string.IsNullOrEmpty(ShiftId))
            {
                ViewBag.ShiftId = string.Empty; ;
                ViewBag.IsUpdateStatus = false;

                shiftSetting.MainComId = string.Format("0:yyyyMMdd");
                shiftSetting.IconColor = "FC0366";
                shiftSetting.CompanyName = string.Empty ;
                shiftSetting.ShiftBusinessMode = ShiftBusinessMode.DAYSHIFT;
                shiftSetting.ShiftAppliedMode = ShiftAppliedMode.PARTIAL;

                ViewBag.ShiftBusinessMode = (int)ShiftBusinessMode.DAYSHIFT;

                shiftSetting.AppliedStartDate = DateTime.Now;
                shiftSetting.AppliedEndDate = DateTime.Now;
                shiftSetting.IsAutoCalcMissing = true;

                PopulateAssignedWeekDayType(string.Empty);

                ////-------------------------default value start 
                if (shiftSetting.ShiftBusinessMode == ShiftBusinessMode.NIGHTSHIFT)
                {
                    shiftSetting.LunchTimeSpan = 1;
                    shiftSetting.LunchTimeStart = new TimeSpan(23, 30, 0);
                    shiftSetting.LunchTimeEnd = new TimeSpan(0, 30, 0);
                    shiftSetting.LunchTimeStartBuffer = 30;
                    shiftSetting.LunchTimeEndBuffer = 30;
                }
                else
                {
                    shiftSetting.LunchTimeSpan = 1;
                    shiftSetting.LunchTimeStart = new TimeSpan(12, 00, 0);
                    shiftSetting.LunchTimeEnd = new TimeSpan(13, 00, 0);
                    shiftSetting.LunchTimeStartBuffer = 30;
                    shiftSetting.LunchTimeEndBuffer = 30;
                }
                shiftSetting.WorkStart = new TimeSpan(9, 0, 0);
                shiftSetting.SpecialWeekDaysWorkStart = new TimeSpan(0, 0, 0);
                ViewBag.WorkStartMinutes = shiftSetting.WorkStart.Duration().Minutes; //----------------convert to  total minutes

                shiftSetting.WorkEnd = new TimeSpan(17, 0, 0);
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
                shiftSetting.IconColor = shift.IconColor;
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

                shiftSetting.WorkStartAllowance = shift.WorkStartAllowance;
                shiftSetting.WorkEndAllowance = shift.WorkEndAllowance;
                shiftSetting.WorkStartBuffer = shift.WorkStartBuffer;
                shiftSetting.WorkEndBuffer = shift.WorkEndBuffer;
                shiftSetting.AppliedStartDate = shift.AppliedStartDate;
                shiftSetting.AppliedEndDate = shift.AppliedEndDate;

                shiftSetting.LunchTimeSpan = shift.LunchTimeSpan;
                shiftSetting.LunchTimeStart = shift.LunchTimeStart;
                shiftSetting.LunchTimeEnd = shift.LunchTimeEnd;
                shiftSetting.LunchTimeStartBuffer = shift.LunchTimeStartBuffer;
                shiftSetting.LunchTimeEndBuffer = shift.LunchTimeEndBuffer;

                shiftSetting.RuleDescription = shift.RuleDescription;

                PopulateAssignedWeekDayType(shiftSetting.ShiftId);
                return View(shiftSetting);
            }
        }

        // POST: Admin/SysBusinessSetting
        [HttpPost]
        [Authorize(Roles = "Admin,Emplyee,MainComOprerator,SystemAdmin")]
        public ActionResult ShiftSettingLunch(string ShiftId, [Bind(Include = "ShiftId,ShiftAbbrId,ShiftName,ShiftBusinessMode,ShiftAppliedMode,ShiftAppliedModeInt, MainComId, CompanyName, WorkStart, WorkEnd, WorkStartAllowance, WorkEndAllowance, WorkStartBuffer, WorkEndBuffer,SpecialWeekDays," +
            "SpecialWeekDaysWorkStart,SpecialWeekDaysWorkEnd,LunchTimeStart,LunchTimeEnd,LunchTimeStartBuffer,LunchTimeEndBuffer,AppliedStartDate, AppliedEndDate, RuleDescription")]ShiftGeneralLunchView shiftGeneralLunchView)
        {
            ModalDialog modalDialogView = new ModalDialog();

            if (shiftGeneralLunchView.AppliedEndDate < DateTime.Now || shiftGeneralLunchView.AppliedEndDate < DateTime.Now)
            {
                modalDialogView.MsgCode = "-1";
                modalDialogView.Message = Lang.Shift_AppliedStartDateIsNotLogical_Validator;

                return Json(modalDialogView);  // -1;Shift_AppliedStartDateIsNotLogical_Validator
            }

            string UserName = User.Identity.Name; 
            //------------------------------------------------------------------------------------
            if (string.IsNullOrEmpty(ShiftId)) // insert
            {
                modalDialogView.MsgCode = "1";
                modalDialogView.Message = Lang.Shift_ReturnSuccess;

                //----insert
                Shift shift = new Shift();

                shift.ShiftId = dbContext.GetTableKeyID_DatePeriod(shiftGeneralLunchView.AppliedStartDate, shiftGeneralLunchView.AppliedEndDate);
                shift.ShiftAbbrId = shiftGeneralLunchView.ShiftAbbrId;
                shift.IconColor = shiftGeneralLunchView.IconColor??string.Empty;
                shift.ShiftName = shiftGeneralLunchView.ShiftName;
                shift.ShiftBusinessMode = (int)shiftGeneralLunchView.ShiftBusinessMode;
                shift.ShiftAppliedMode = (int)shiftGeneralLunchView.ShiftAppliedMode;
                shift.CompanyName = shiftGeneralLunchView.CompanyName ??string.Empty; ;
                shift.WorkTimeSpan = DateTimePubBusiness.TimeSpanHourDiff(shiftGeneralLunchView.WorkEnd, shiftGeneralLunchView.WorkStart, 1);
                shift.WorkStart = shiftGeneralLunchView.WorkStart;
                shift.WorkEnd = shiftGeneralLunchView.WorkEnd;
                shift.WorkStartAllowance = shiftGeneralLunchView.WorkStartAllowance;
                shift.WorkEndAllowance = shiftGeneralLunchView.WorkEndAllowance;
                shift.WorkStartBuffer = shiftGeneralLunchView.WorkStartBuffer;
                shift.WorkEndBuffer = shiftGeneralLunchView.WorkEndBuffer;

                shift.SpecialWeekDays = UpdateUserWeekDayType(shiftGeneralLunchView.SpecialWeekDays, shift.ShiftId);
                shift.SpecialWeekDaysWorkStart = shiftGeneralLunchView.SpecialWeekDaysWorkStart;
                shift.SpecialWeekDaysWorkEnd = shiftGeneralLunchView.SpecialWeekDaysWorkEnd;

                //-------------------------------------------
                shift.LunchTimeSpan = Math.Abs(DateTimePubBusiness.TimeSpanHourDiff(shiftGeneralLunchView.LunchTimeStart, shiftGeneralLunchView.LunchTimeEnd, 1));
                shift.LunchTimeStart = shiftGeneralLunchView.LunchTimeStart;
                shift.LunchTimeEnd = shiftGeneralLunchView.LunchTimeEnd;
                shift.LunchTimeStartBuffer = shiftGeneralLunchView.LunchTimeStartBuffer;
                shift.LunchTimeEndBuffer = shiftGeneralLunchView.LunchTimeEndBuffer;

                //-------------------------default value start 
                shift.OverTimeSpan = 0;
                shift.OverTimeStart = DateTimePubBusiness.TimeSpanZero();
                shift.OverTimeEnd = DateTimePubBusiness.TimeSpanZero();
                shift.OverTimeStartBuffer = 0;
                shift.OverTimeEndBuffer = 0;

                shift.BreakTimeSpan = 0;
                shift.BreakTimeCalcStart = DateTimePubBusiness.TimeSpanZero();
                shift.BreakTimeCalcEnd = DateTimePubBusiness.TimeSpanZero();
                shift.BreakTimeAllowance = 0;

                //-------------------------default value end

                shift.AppliedStartDate = shiftGeneralLunchView.AppliedStartDate;
                shift.AppliedEndDate = shiftGeneralLunchView.AppliedEndDate;
                shift.RuleDescription = shiftGeneralLunchView.RuleDescription;

                shift.UpdatedDate = DateTime.Now;
                shift.CreatedDate = DateTime.Now;
                shift.OperatedUserName = UserName;

                try
                {
                    dbContext.Add(shift);
                    dbContext.SaveChanges();

                    modalDialogView.MsgCode = shift.ShiftId;
                    modalDialogView.Message = Lang.GeneralUI_Success;

                    return Json(modalDialogView);
                }
                catch (Exception e)
                {
                    modalDialogView.MsgCode = "0";
                    modalDialogView.Message = e.Message;
                    return Json(modalDialogView);
                }
            }
            else
            {
                modalDialogView.MsgCode = "1";
                modalDialogView.Message = Lang.Shift_Return_Update_Success;  // update success 
                //----update
                Shift shift = dbContext.Shift.Find(shiftGeneralLunchView.ShiftId);

                shift.ShiftId = shiftGeneralLunchView.ShiftId;
                shift.ShiftAbbrId = shiftGeneralLunchView.ShiftAbbrId;
             
                shift.ShiftName = shiftGeneralLunchView.ShiftName;
                shift.ShiftBusinessMode = (int)shiftGeneralLunchView.ShiftBusinessMode;
                shift.ShiftAppliedMode = (int)shiftGeneralLunchView.ShiftAppliedMode;
                  
                shift.WorkTimeSpan = DateTimePubBusiness.TimeSpanHourDiff(shiftGeneralLunchView.WorkEnd, shiftGeneralLunchView.WorkStart, 1);
                shift.WorkStart = shiftGeneralLunchView.WorkStart;
                shift.WorkEnd = shiftGeneralLunchView.WorkEnd;
                shift.WorkStartAllowance = shiftGeneralLunchView.WorkStartAllowance;
                shift.WorkEndAllowance = shiftGeneralLunchView.WorkEndAllowance;
                shift.WorkStartBuffer = shiftGeneralLunchView.WorkStartBuffer;
                shift.WorkEndBuffer = shiftGeneralLunchView.WorkEndBuffer;

                shift.SpecialWeekDays = UpdateUserWeekDayType(shiftGeneralLunchView.SpecialWeekDays, shift.ShiftId);
                shift.SpecialWeekDaysWorkStart = shiftGeneralLunchView.SpecialWeekDaysWorkStart;
                shift.SpecialWeekDaysWorkEnd = shiftGeneralLunchView.SpecialWeekDaysWorkEnd;

                shift.LunchTimeSpan = Math.Abs(DateTimePubBusiness.TimeSpanHourDiff(shiftGeneralLunchView.LunchTimeStart, shiftGeneralLunchView.LunchTimeEnd, 1));
                shift.LunchTimeStart = shiftGeneralLunchView.LunchTimeStart;
                shift.LunchTimeEnd = shiftGeneralLunchView.LunchTimeEnd;
                shift.LunchTimeStartBuffer = shiftGeneralLunchView.LunchTimeStartBuffer;
                shift.LunchTimeEndBuffer = shiftGeneralLunchView.LunchTimeEndBuffer;
                  
                shift.UpdatedDate = DateTime.Now;
                shift.CreatedDate = DateTime.Now;
                shift.OperatedUserName = UserName;
                try
                {
                    bool rejectToModified = ShiftBusinessExtand.ShiftInScheduleRejectToModified(shift.ShiftId, ref modalDialogView);
                    if (rejectToModified && shift.IsApproved)
                    {
                        return Json(modalDialogView);
                    }
                    dbContext.Update(shift);
                    dbContext.SaveChanges();

                    modalDialogView.MsgCode = shift.ShiftId;
                    modalDialogView.Message = Lang.GeneralUI_Success;

                    return Json(modalDialogView);
                }
                catch (Exception e)
                {
                    modalDialogView.MsgCode = "0";
                    modalDialogView.Message = e.Message;
                    return Json(modalDialogView);
                }
            }
        }
    }
}