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
        /// <summary>
        /// Basic Shift
        /// </summary>
        /// <param name="ShiftId"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Admin,MainComOprerator,SystemAdmin")]
        public ActionResult Work(string ShiftId)
        {
            ViewBag.IntShiftBusinessMode = (int)ShiftBusinessMode.DAYSHIFT; //default value

            ShiftWork shiftWork = new ShiftWork(); 

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
                shiftWork = shiftObjectification.ShiftWork;  
            } 
            return View(shiftWork);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Emplyee,MainComOprerator,SystemAdmin")]
        public ActionResult Work([Bind(Include = "ShiftId,WorkStart,WorkEnd,WorkStartBuffer,WorkEndBuffer")] ShiftWork shiftWork)
        {
            ResponseModalX responseModalX = new ResponseModalX();  
            if (string.IsNullOrEmpty(shiftWork.ShiftId))
            {
                responseModalX.meta = new MetaModalX { ErrorCode = (int)ShiftErrorCode.SHIFT_ERROR_NO_SHIFT_ID_OR_NULL, Success = false, Message = "Lang.SHIFT_ERROR_NO_SHIFT_ID_OR_NULL" };
                return Json(responseModalX);
            }
            using (DataBaseContext dataBaseContext = new DataBaseContext())
            {
                Shift shift = dataBaseContext.Shift.Find(shiftWork.ShiftId);

                try
                {
                    shift.WorkTimeSpan = Math.Abs(DateTimePubBusiness.TimeSpanHourDiff(shiftWork.WorkStart, shiftWork.WorkEnd, 2));
                    shift.WorkStart = shiftWork.WorkStart;
                    shift.WorkEnd = shiftWork.WorkEnd;
                    shift.WorkStartBuffer = shiftWork.WorkStartBuffer; 
                    shift.WorkEndBuffer = shiftWork.WorkEndBuffer; 
                 
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