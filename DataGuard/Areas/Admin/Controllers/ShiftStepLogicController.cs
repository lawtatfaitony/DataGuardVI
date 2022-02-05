using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttApiViewModal;
using AttApiViewModal.ShiftModule;
using AttendanceBussiness;
using AttendanceBussiness.DbFirst;
using AttendanceBussiness.ShiftModule;
using AttEnumCode;
using LanguageResource;
using static AttendanceBussiness.ShiftBusiness;

namespace DataGuard.Areas.Admin.Controllers
{
    public partial class ShiftStepController : BaseController
    {
        [HttpGet]
        [Authorize(Roles = "Admin,MainComOprerator,SystemAdmin")]
        public ActionResult Logic(string ShiftId)
        {
            ViewBag.IntShiftBusinessMode = (int)ShiftBusinessMode.DAYSHIFT; //default value

            LogicOfSpecialAndExclude logicOfSpecialAndExclude = new LogicOfSpecialAndExclude(); 

            if (string.IsNullOrEmpty(ShiftId))
            {
                return RedirectToAction("Basic", "ShiftStep", new { Message = Lang.EmployeeQuick_Message });
            }
            else
            {
                ViewBag.IsUpdateStatus = true;
               
                Shift shift = dbContext.Shift.Find(ShiftId);

                if(shift == null)
                    return RedirectToAction("Basic", "ShiftStep", new { Message = Lang.EmployeeQuick_Message });

                ViewBag.IntShiftBusinessMode = shift.ShiftBusinessMode;
                ShiftObjectification shiftObjectification = AttendanceBussiness.ShiftModule.ShiftBusiness.GetObjectification(shift);
                logicOfSpecialAndExclude = shiftObjectification.LogicOfSpecialAndExclude;
                 
                PopulateAssignedWeekDayType(logicOfSpecialAndExclude.ShiftId);
                PopulateAssignedExcludeWeekDay(logicOfSpecialAndExclude.ShiftId);
                PopulateAssignedExcludeOverTime(logicOfSpecialAndExclude.ShiftId);
            }
            return View(logicOfSpecialAndExclude);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Emplyee,MainComOprerator,SystemAdmin")]
        public ActionResult Logic([Bind(Include = "ShiftId,SpecialWeekDays,SpecialWeekDaysWorkStart,SpecialWeekDaysWorkEnd,ExcludeWeekDay,ExcludeOverTime")] LogicOfSpecialAndExclude logicOfSpecialAndExclude)
        {
            ResponseModalX responseModalX = new ResponseModalX();  
            if (string.IsNullOrEmpty(logicOfSpecialAndExclude.ShiftId))
            {
                responseModalX.meta = new MetaModalX { ErrorCode = (int)ShiftErrorCode.SHIFT_ERROR_NO_SHIFT_ID_OR_NULL, Success = false, Message = "Lang.SHIFT_ERROR_NO_SHIFT_ID_OR_NULL" };
                return Json(responseModalX);
            }
            using (DataBaseContext dataBaseContext = new DataBaseContext())
            {
                Shift shift = dataBaseContext.Shift.Find(logicOfSpecialAndExclude.ShiftId);

                try
                {
                    shift.SpecialWeekDays = logicOfSpecialAndExclude.SpecialWeekDays !=null ? string.Join(",",logicOfSpecialAndExclude.SpecialWeekDays) : string.Empty; 
                    shift.SpecialWeekDaysWorkStart = logicOfSpecialAndExclude.SpecialWeekDaysWorkStart;
                    shift.SpecialWeekDaysWorkEnd = logicOfSpecialAndExclude.SpecialWeekDaysWorkEnd;
                    shift.ExcludeWeekDay = logicOfSpecialAndExclude.ExcludeWeekDay != null ? string.Join(",", logicOfSpecialAndExclude.ExcludeWeekDay) : string.Empty;
                    shift.ExcludeOverTime = logicOfSpecialAndExclude.ExcludeOverTime != null ? string.Join(",", logicOfSpecialAndExclude.ExcludeOverTime) : string.Empty;

                    bool rejectToModified = ShiftBusinessExtand.ShiftInScheduleRejectToModified(shift.ShiftId, ref responseModalX);
                    if (rejectToModified && shift.IsApproved)
                    {
                        return Json(responseModalX);
                    }
                    dataBaseContext.Update(shift);
                    dataBaseContext.SaveChanges();

                    responseModalX.meta = new MetaModalX {ErrorCode = (int)GeneralReturnCode.SUCCESS ,Success =true, Message = Lang.GeneralUI_Success }; 
                    responseModalX.data = new { shift.ShiftId }; 
                    return Json(responseModalX);
                }
                catch (Exception e)
                { 
                    responseModalX.meta = new MetaModalX { ErrorCode = (int)GeneralReturnCode.EXCEPTION,Success= false,Message = e.Message }; 
                    return Json(responseModalX);
                }
            } 
        }
    }
}