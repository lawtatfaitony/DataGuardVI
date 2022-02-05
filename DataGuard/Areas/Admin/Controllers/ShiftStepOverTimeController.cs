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
        public ActionResult OverTime(string ShiftId)
        {
            ViewBag.IntShiftBusinessMode = (int)ShiftBusinessMode.DAYSHIFT; //default value

            ShiftOverTime shiftOverTime = new ShiftOverTime(); 

            if (string.IsNullOrEmpty(ShiftId))
            {
                return RedirectToAction("Basic", "ShiftStep", new { Message = Lang.EmployeeQuick_Message });
            }
            else
            {
                ViewBag.IsUpdateStatus = true;

                Shift shift = dbContext.Shift.Find(ShiftId);

                if (shift == null)
                    return RedirectToAction("Basic", "ShiftStep", new { Message = Lang.EmployeeQuick_Message });

                ViewBag.IntShiftBusinessMode = shift.ShiftBusinessMode;
                ShiftObjectification shiftObjectification = AttendanceBussiness.ShiftModule.ShiftBusiness.GetObjectification(shift);
                shiftOverTime = shiftObjectification.ShiftOverTime;  
            }
            return View(shiftOverTime);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Emplyee,MainComOprerator,SystemAdmin")]
        public ActionResult OverTime([Bind(Include = "ShiftId,OverTimeSpan,OverTimeStart,OverTimeEnd,OverTimeStartBuffer,OverTimeEndBuffer")] ShiftOverTime shiftOverTime)
        {
            ResponseModalX responseModalX = new ResponseModalX();  
            if (string.IsNullOrEmpty(shiftOverTime.ShiftId))
            {
                responseModalX.meta = new MetaModalX { ErrorCode = (int)ShiftErrorCode.SHIFT_ERROR_NO_SHIFT_ID_OR_NULL, Success = false, Message = "Lang.SHIFT_ERROR_NO_SHIFT_ID_OR_NULL" };
                return Json(responseModalX);
            }
            using (DataBaseContext dataBaseContext = new DataBaseContext())
            {
                Shift shift = dataBaseContext.Shift.Find(shiftOverTime.ShiftId);

                try
                {
                    shift.OverTimeSpan = Math.Abs(DateTimePubBusiness.TimeSpanHourDiff(shiftOverTime.OverTimeStart, shiftOverTime.OverTimeEnd, 2));
                    shift.OverTimeStart = shiftOverTime.OverTimeStart;
                    shift.OverTimeEnd = shiftOverTime.OverTimeEnd;
                    shift.OverTimeStartBuffer = shiftOverTime.OverTimeStartBuffer; 
                    shift.OverTimeEndBuffer = shiftOverTime.OverTimeEndBuffer; 
                 
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