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
        [Authorize(Roles = "Admin,MainComOprerator,SystemAdmin")]
        public ActionResult ShiftSetting(string ShiftId)
        {
            ShiftGeneralView shiftSetting = new ShiftGeneralView();

            if (string.IsNullOrEmpty(ShiftId))
            {
                ViewBag.ShiftId = string.Empty; ;
                ViewBag.IsUpdateStatus = false;

                shiftSetting.MainComId = DataGuard.Context.WebCookie.MainComId;

                shiftSetting.ShiftBusinessMode = ShiftBusinessMode.DAYSHIFT;
                shiftSetting.ShiftBusinessMode = ShiftBusinessMode.DAYSHIFT;
                ViewBag.ShiftBusinessMode = (int)ShiftBusinessMode.DAYSHIFT;
                shiftSetting.ShiftAppliedMode = ShiftAppliedMode.PARTIAL;

                shiftSetting.AppliedStartDate = DateTime.Now;
                shiftSetting.AppliedEndDate = DateTime.Now;
                shiftSetting.IsAutoCalcMissing = true;

                PopulateAssignedWeekDayType(string.Empty);
                ShiftAppliedModeDropDownList(ShiftAppliedMode.PARTIAL);
                ShiftMissingWorkOnMissingModeDropDownList(CalcMissingMode.AUTO_MISSING);
                ShiftMissingWorkOffMissingModeDropDownList(CalcMissingMode.AUTO_MISSING);
                ShiftMissingLunchStartDropDownList(CalcMissingMode.AUTO_MISSING);
                ShiftMissingLunchEndDropDownList(CalcMissingMode.AUTO_MISSING);
                ShiftMissingOverTimeStartDropDownList(CalcMissingMode.AUTO_MISSING);
                ShiftMissingOverTimeEndDropDownList(CalcMissingMode.AUTO_MISSING);

                ////-------------------------default value start 
                shiftSetting.WorkStart = new TimeSpan(9, 0, 0);
                shiftSetting.SpecialWeekDaysWorkStart = new TimeSpan(9, 0, 0);
                ViewBag.WorkStartMinutes = shiftSetting.WorkStart.Duration().Minutes; //----------------convert to  total minutes

                shiftSetting.WorkEnd = new TimeSpan(17, 0, 0);
                shiftSetting.SpecialWeekDaysWorkEnd = new TimeSpan(13, 0, 0);
                ViewBag.WorkEndMinutes = shiftSetting.WorkEnd.Duration().Minutes; //----------------convert to  total minutes

                shiftSetting.WorkStartAllowance = 15;
                shiftSetting.WorkEndAllowance = 15;
                shiftSetting.WorkStartBuffer = 120;
                shiftSetting.WorkEndBuffer = 120;
                //-------------------------default value end

                return View(shiftSetting);
            }
            else
            {
                ShiftId = ShiftId.Trim();
                ViewBag.ShiftId = ShiftId;
                ViewBag.IsUpdateStatus = true;
                Shift shift = dbContext.Shift.Find(ShiftId);

                shiftSetting.ShiftId = shift.ShiftId;
                shiftSetting.ShiftAbbrId = shift.ShiftAbbrId;
                shiftSetting.ShiftName = shift.ShiftName;
                shiftSetting.ShiftBusinessMode = (ShiftBusinessMode)shift.ShiftBusinessMode;
                ViewBag.ShiftBusinessMode = (int)shift.ShiftBusinessMode;
                 
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
                shiftSetting.IsAutoCalcMissing = (bool)shift.IsAutoCalcMissing;
                shiftSetting.MissingWorkOn = (CalcMissingMode)shift.MissingWorkOn;
                shiftSetting.MissingWorkOff = (CalcMissingMode)shift.MissingWorkOff;
                shiftSetting.AppliedStartDate = shift.AppliedStartDate;
                shiftSetting.AppliedEndDate = shift.AppliedEndDate;

                shiftSetting.RuleDescription = shift.RuleDescription;

                PopulateAssignedWeekDayType(shiftSetting.ShiftId);
                ShiftAppliedModeDropDownList((ShiftAppliedMode)shift.ShiftAppliedMode);
                ShiftMissingWorkOnMissingModeDropDownList((CalcMissingMode)shift.MissingWorkOn);
                ShiftMissingWorkOffMissingModeDropDownList((CalcMissingMode)shift.MissingWorkOff);
                ShiftMissingLunchStartDropDownList((CalcMissingMode)shift.MissingLunchStart);
                ShiftMissingLunchEndDropDownList((CalcMissingMode)shift.MissingLunchEnd);
                ShiftMissingOverTimeStartDropDownList((CalcMissingMode)shift.MissingOverTimeStart);
                ShiftMissingOverTimeEndDropDownList((CalcMissingMode)shift.MissingOverTimeEnd);
                return View(shiftSetting);
            }
        }

        // POST: Admin/SysBusinessSetting
        [HttpPost]
        [Authorize(Roles = "Admin,Emplyee,MainComOprerator,SystemAdmin")]
        public ActionResult ShiftSetting(string ShiftId, [Bind(Include = "ShiftId,ShiftAbbrId,IconColor,ShiftName,ShiftBusinessMode,ShiftAppliedMode, MainComId, CompanyName, WorkStart, WorkEnd, WorkStartAllowance, WorkEndAllowance, WorkStartBuffer, WorkEndBuffer,SpecialWeekDays," +
            "SpecialWeekDaysWorkStart,SpecialWeekDaysWorkEnd,IsAutoCalcMissing, MissingWorkOn, MissingWorkOff,MissingLunchStart,MissingLunchEnd,MissingOverTimeStart,MissingOverTimeEnd,AppliedStartDate, AppliedEndDate, RuleDescription")]ShiftGeneralView shiftGeneralView)
        {
            ModalDialog modalDialog = new ModalDialog();

            if (shiftGeneralView.AppliedEndDate == null || shiftGeneralView.AppliedEndDate < DateTime.Now)
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

                string createId = dbContext.GetTableKeyID_DatePeriod(shiftGeneralView.AppliedStartDate, shiftGeneralView.AppliedEndDate);
                //----insert
                Shift shift = new Shift
                {
                    ShiftId = createId,
                    ShiftAbbrId = shiftGeneralView.ShiftAbbrId,
                    IconColor = shiftGeneralView.IconColor,
                    ShiftName = shiftGeneralView.ShiftName,
                    ShiftBusinessMode = (int)shiftGeneralView.ShiftBusinessMode,
                    ShiftAppliedMode = (int)shiftGeneralView.ShiftAppliedMode,
                    DepartmentIdArr = string.Empty,
                    CompanyName = shiftGeneralView.CompanyName ?? string.Empty,
                    WorkTimeSpan = DateTimePubBusiness.TimeSpanHourDiff(shiftGeneralView.WorkEnd, shiftGeneralView.WorkStart, 1),
                    WorkStart = shiftGeneralView.WorkStart,
                    WorkEnd = shiftGeneralView.WorkEnd,
                    WorkStartAllowance = shiftGeneralView.WorkStartAllowance,
                    WorkEndAllowance = shiftGeneralView.WorkEndAllowance,
                    WorkStartBuffer = shiftGeneralView.WorkStartBuffer,
                    WorkEndBuffer = shiftGeneralView.WorkEndBuffer
                };

                shift.SpecialWeekDays = UpdateUserWeekDayType(shiftGeneralView.SpecialWeekDays, shift.ShiftId);
                shift.SpecialWeekDaysWorkStart = shiftGeneralView.SpecialWeekDaysWorkStart;
                shift.SpecialWeekDaysWorkEnd = shiftGeneralView.SpecialWeekDaysWorkEnd;

                //-------------------------default value start 
                shift.OverTimeSpan = 0;
                shift.OverTimeStart = DateTimePubBusiness.TimeSpanZero();
                shift.OverTimeEnd = DateTimePubBusiness.TimeSpanZero();
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
                shift.MissingLunchStart = (int)CalcMissingMode.AUTO_MISSING;
                shift.MissingLunchEnd = (int)CalcMissingMode.AUTO_MISSING;
                //-------------------------default value end

                shift.IsAutoCalcMissing = shiftGeneralView.IsAutoCalcMissing;
                shift.MissingWorkOn = (int)shiftGeneralView.MissingWorkOn;
                shift.MissingWorkOff = (int)shiftGeneralView.MissingWorkOff;
                shift.MissingLunchStart = (int)shiftGeneralView.MissingLunchStart;
                shift.MissingLunchEnd = (int)shiftGeneralView.MissingLunchEnd;
                shift.MissingOverTimeStart = (int)shiftGeneralView.MissingOverTimeStart;
                shift.MissingOverTimeEnd = (int)shiftGeneralView.MissingOverTimeEnd;

                shift.AppliedStartDate = shiftGeneralView.AppliedStartDate;
                shift.AppliedEndDate = shiftGeneralView.AppliedEndDate;
                shift.RuleDescription = shiftGeneralView.RuleDescription??string.Empty;

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
                modalDialog.MsgCode = "1";
                modalDialog.Message = Lang.Shift_Return_Update_Success;  // update success
                //----update
                Shift shift = dbContext.Shift.Find(shiftGeneralView.ShiftId);
                shift.ShiftId = shiftGeneralView.ShiftId;
                shift.ShiftAbbrId = shiftGeneralView.ShiftAbbrId ?? string.Empty;
                shift.IconColor = shiftGeneralView.IconColor??string.Empty;
                shift.ShiftName = shiftGeneralView.ShiftName ?? string.Empty;
                shift.ShiftBusinessMode = (int)shiftGeneralView.ShiftBusinessMode;
                shift.ShiftAppliedMode = (int)shiftGeneralView.ShiftAppliedMode;
                shift.CompanyName = shiftGeneralView.CompanyName??string.Empty;
                shift.WorkTimeSpan = DateTimePubBusiness.TimeSpanHourDiff(shiftGeneralView.WorkEnd, shiftGeneralView.WorkStart, 1);
                shift.WorkStart = shiftGeneralView.WorkStart;
                shift.WorkEnd = shiftGeneralView.WorkEnd;
                shift.WorkStartAllowance = shiftGeneralView.WorkStartAllowance;
                shift.WorkEndAllowance = shiftGeneralView.WorkEndAllowance;
                shift.WorkStartBuffer = shiftGeneralView.WorkStartBuffer;
                shift.WorkEndBuffer = shiftGeneralView.WorkEndBuffer;

                shift.SpecialWeekDays = UpdateUserWeekDayType(shiftGeneralView.SpecialWeekDays, shift.ShiftId);
                shift.SpecialWeekDaysWorkStart = shiftGeneralView.SpecialWeekDaysWorkStart;
                shift.SpecialWeekDaysWorkEnd = shiftGeneralView.SpecialWeekDaysWorkEnd;

                //-------------------------default value start 
                shift.OverTimeSpan = 0;
                shift.OverTimeStart = DateTimePubBusiness.TimeSpanZero();
                shift.OverTimeEnd = DateTimePubBusiness.TimeSpanZero();
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
                shift.MissingLunchStart = (int)CalcMissingMode.AUTO_MISSING;
                shift.MissingLunchEnd = (int)CalcMissingMode.AUTO_MISSING;


                shift.IsAutoCalcMissing = shiftGeneralView.IsAutoCalcMissing;
                shift.MissingWorkOn = (int)shiftGeneralView.MissingWorkOn;
                shift.MissingWorkOff = (int)shiftGeneralView.MissingWorkOff;
                shift.MissingLunchStart = (int)shiftGeneralView.MissingLunchStart;
                shift.MissingLunchEnd = (int)shiftGeneralView.MissingLunchEnd;
                shift.MissingOverTimeStart = (int)shiftGeneralView.MissingOverTimeStart;
                shift.MissingOverTimeEnd = (int)shiftGeneralView.MissingOverTimeEnd;

                shift.AppliedStartDate = shiftGeneralView.AppliedStartDate;
                shift.AppliedEndDate = shiftGeneralView.AppliedEndDate;
                shift.RuleDescription = shiftGeneralView.RuleDescription??string.Empty;

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

        // GET: Admin/SysBusinessSetting
        [HttpGet]
        [Authorize(Roles = "Admin,Emplyee,Guest,LRO,MainComOprerator,SystemAdmin,ThirdPartyserviceContractorAdmin,ThirdPartyserviceContractorOperator")]
        public ActionResult ShiftSettingNight(string ShiftId)
        {
            ShiftGeneralView shiftSetting = new ShiftGeneralView();

            if (string.IsNullOrEmpty(ShiftId))
            {
                ViewBag.ShiftId = string.Empty; ;
                ViewBag.IsUpdateStatus = false;

                shiftSetting.MainComId = DataGuard.Context.WebCookie.MainComId;
                shiftSetting.ShiftBusinessMode = ShiftBusinessMode.NIGHTSHIFT;
                ViewBag.ShiftBusinessMode = (int)ShiftBusinessMode.NIGHTSHIFT;

                shiftSetting.AppliedStartDate = DateTime.Now;
                shiftSetting.AppliedEndDate = DateTime.Now;
                shiftSetting.IsAutoCalcMissing = true;

                PopulateAssignedWeekDayType(string.Empty);
                ShiftAppliedModeDropDownList(ShiftAppliedMode.PARTIAL);
                ShiftMissingWorkOnMissingModeDropDownList(CalcMissingMode.AUTO_MISSING);
                ShiftMissingWorkOffMissingModeDropDownList(CalcMissingMode.AUTO_MISSING);
                ShiftMissingLunchStartDropDownList(CalcMissingMode.AUTO_MISSING);
                ShiftMissingLunchEndDropDownList(CalcMissingMode.AUTO_MISSING);
                ShiftMissingOverTimeStartDropDownList(CalcMissingMode.AUTO_MISSING);
                ShiftMissingOverTimeEndDropDownList(CalcMissingMode.AUTO_MISSING);

                ////-------------------------default value start 
                shiftSetting.WorkStart = new TimeSpan(21, 0, 0);
                shiftSetting.SpecialWeekDaysWorkStart = new TimeSpan(23, 0, 0);
                ViewBag.WorkStartMinutes = shiftSetting.WorkStart.Duration().Minutes; //----------------convert to  total minutes

                shiftSetting.WorkEnd = new TimeSpan(5, 0, 0);
                shiftSetting.SpecialWeekDaysWorkEnd = new TimeSpan(1, 0, 0);
                ViewBag.WorkEndMinutes = shiftSetting.WorkEnd.Duration().Minutes; //----------------convert to  total minutes

                shiftSetting.WorkStartAllowance = 15;
                shiftSetting.WorkEndAllowance = 15;
                shiftSetting.WorkStartBuffer = 120;
                shiftSetting.WorkEndBuffer = 120;
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
                shiftSetting.IsAutoCalcMissing = (bool)shift.IsAutoCalcMissing;
                shiftSetting.MissingWorkOn = (CalcMissingMode)shift.MissingWorkOn;
                shiftSetting.MissingWorkOff = (CalcMissingMode)shift.MissingWorkOff;
                shiftSetting.AppliedStartDate = shift.AppliedStartDate;
                shiftSetting.AppliedEndDate = shift.AppliedEndDate;
                shiftSetting.RuleDescription = shift.RuleDescription;

                PopulateAssignedWeekDayType(shiftSetting.ShiftId);
                ShiftAppliedModeDropDownList((ShiftAppliedMode)shift.ShiftAppliedMode);
                ShiftMissingWorkOnMissingModeDropDownList((CalcMissingMode)shift.MissingWorkOn);
                ShiftMissingWorkOffMissingModeDropDownList((CalcMissingMode)shift.MissingWorkOff);
                ShiftMissingLunchStartDropDownList((CalcMissingMode)shift.MissingLunchStart);
                ShiftMissingLunchEndDropDownList((CalcMissingMode)shift.MissingLunchEnd);
                ShiftMissingOverTimeStartDropDownList((CalcMissingMode)shift.MissingOverTimeStart);
                ShiftMissingOverTimeEndDropDownList((CalcMissingMode)shift.MissingOverTimeEnd);
                return View(shiftSetting);
            }
        }

        // POST: Admin/SysBusinessSetting
        [HttpPost]
        public ActionResult ShiftSettingNight(string ShiftId, [Bind(Include = "ShiftId,ShiftAbbrId,IconColor,ShiftName,ShiftBusinessMode,ShiftAppliedMode, MainComId, CompanyName, WorkStart, WorkEnd, WorkStartAllowance, WorkEndAllowance, WorkStartBuffer, WorkEndBuffer, SpecialWeekDays," +
            "SpecialWeekDaysWorkStart,SpecialWeekDaysWorkEnd,IsAutoCalcMissing, MissingWorkOn,MissingWorkOff,MissingLunchStart,MissingLunchEnd,MissingOverTimeStart,MissingOverTimeEnd, AppliedStartDate, AppliedEndDate, RuleDescription")]ShiftGeneralView shiftGeneralView)
        {
            ModalDialog modalDialog = new ModalDialog();

            if (shiftGeneralView.AppliedEndDate == null || shiftGeneralView.AppliedEndDate < shiftGeneralView.AppliedStartDate)
            {
                modalDialog.MsgCode = "-1";
                modalDialog.Message = Lang.Shift_AppliedStartDateIsNotLogical_Validator;

                return Json(modalDialog);  // -1;Shift_AppliedStartDateIsNotLogical_Validator
            }
             
            //------------------------------------------------------------------------------------
            if (string.IsNullOrEmpty(ShiftId)) // insert
            {
                //----insert
                
                modalDialog.MsgCode = "1";
                modalDialog.Message = Lang.Shift_ReturnSuccess;
                 
                try
                { 
                    modalDialog.MsgCode = ShiftId;
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
               

                try
                { 
                    modalDialog.MsgCode = ShiftId;
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


        //public bool ShiftInScheduleRejectToModified(string ShiftId,ref ModalDialogView modalDialogView)
        //{ 
        //    var schedule = dbContext.Schedule.Where(c => c.ShiftId.Contains(ShiftId) && c.ScheduleDate > DateTime.Now);
        //    if(schedule.Count()>0)
        //    {
        //        modalDialogView.MsgCode = "-1";
        //        modalDialogView.Message = Lang.Shift_ShiftInScheduleRejectToModified_True;
        //        return true;
        //    }
        //    else
        //    {
        //        modalDialogView.MsgCode = "1";
        //        modalDialogView.Message = Lang.Shift_ShiftInScheduleRejectToModified_False;
        //        return false;
        //    }

        //}

    }
}