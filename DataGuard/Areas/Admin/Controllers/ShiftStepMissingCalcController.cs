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
        public ActionResult MissingCalc(string ShiftId)
        {
            ViewBag.IntShiftBusinessMode = (int)ShiftBusinessMode.DAYSHIFT; //default value

            ShiftMissingCalc shiftMissingCalc = new ShiftMissingCalc(); 

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
                shiftMissingCalc = shiftObjectification.ShiftMissingCalc;

                ShiftMissingWorkOnMissingModeDropDownList(shiftMissingCalc.MissingWorkOn.ToString());
                ShiftMissingWorkOffMissingModeDropDownList(shiftMissingCalc.MissingWorkOff.ToString());
                ShiftMissingLunchStartDropDownList(shiftMissingCalc.MissingLunchStart.ToString());
                ShiftMissingLunchEndDropDownList(shiftMissingCalc.MissingLunchEnd.ToString());
                ShiftMissingOverTimeStartDropDownList(shiftMissingCalc.MissingOverTimeStart.ToString());
                ShiftMissingOverTimeEndDropDownList(shiftMissingCalc.MissingOverTimeEnd.ToString());

            }
            return View(shiftMissingCalc);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Emplyee,MainComOprerator,SystemAdmin")]
        public ActionResult MissingCalc([Bind(Include = "ShiftId,IsAutoCalcMissing,MissingWorkOn,MissingWorkOff,MissingLunchStart,MissingLunchEnd,MissingOverTimeStart,MissingOverTimeEnd")] ShiftMissingCalc shiftMissingCalc)
        {
            ResponseModalX responseModalX = new ResponseModalX();  
            if (string.IsNullOrEmpty(shiftMissingCalc.ShiftId))
            {
                responseModalX.meta = new MetaModalX { ErrorCode = (int)ShiftErrorCode.SHIFT_ERROR_NO_SHIFT_ID_OR_NULL, Success = false, Message = "Lang.SHIFT_ERROR_NO_SHIFT_ID_OR_NULL" };
                return Json(responseModalX);
            }
            using (DataBaseContext dataBaseContext = new DataBaseContext())
            {
                Shift shift = dataBaseContext.Shift.Find(shiftMissingCalc.ShiftId);
                bool oneOfSelect = (int)shiftMissingCalc.MissingWorkOn == (int)CalcMissingMode.AUTO_MISSING
                        || (int)shiftMissingCalc.MissingWorkOff == (int)CalcMissingMode.AUTO_MISSING
                        || (int)shiftMissingCalc.MissingLunchStart == (int)CalcMissingMode.AUTO_MISSING
                        || (int)shiftMissingCalc.MissingLunchEnd == (int)CalcMissingMode.AUTO_MISSING
                        || (int)shiftMissingCalc.MissingOverTimeStart == (int)CalcMissingMode.AUTO_MISSING
                        || (int)shiftMissingCalc.MissingOverTimeEnd == (int)CalcMissingMode.AUTO_MISSING;
                try
                {  
                    shift.IsAutoCalcMissing = oneOfSelect;
                    shift.MissingWorkOn = (int)shiftMissingCalc.MissingWorkOn;
                    shift.MissingWorkOff = (int)shiftMissingCalc.MissingWorkOff;
                    shift.MissingLunchStart = (int)shiftMissingCalc.MissingLunchStart;
                    shift.MissingLunchEnd = (int)shiftMissingCalc.MissingLunchEnd; 
                    shift.MissingOverTimeStart = (int)shiftMissingCalc.MissingOverTimeStart;
                    shift.MissingOverTimeEnd = (int)shiftMissingCalc.MissingOverTimeEnd;

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