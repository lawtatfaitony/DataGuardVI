using AttendanceBussiness;
using AttendanceBussiness.AttendanceSchedule;
using AttendanceBussiness.DbFirst;
using AttendanceBussiness.Public;
using LanguageResource;
using System;
using System.Linq;
using System.Web.Mvc;

namespace DataGuard.Areas.Admin.Controllers
{
    public partial class ShiftAsignedController : BaseController
    {
        [HttpPost]
        [Authorize(Roles = "Admin,MainComOprerator,SystemAdmin")]
        public ActionResult ShiftDepartmentAsigned([Bind(Include = "ShiftId,ShiftAbbrId,ShiftName,DepartmentId,IgnoreHolidayAndLeave")]ShiftSignedDepartmentView shiftSignedDepartmentView)
        {
            ModalDialog modalDialog = new ModalDialog();
            bool rejectToModified = ShiftBusinessExtand.ShiftInScheduleRejectToModified(shiftSignedDepartmentView.ShiftId, ref modalDialog);
            if (rejectToModified)
            {
                return Json(modalDialog);
            }
            bool IsApproved = ShiftBusinessExtand.ShiftIsApproved(shiftSignedDepartmentView.ShiftId, ref modalDialog);
            if (!IsApproved)
            {
                return Json(modalDialog);
            }

            if (dbContext.Employee.Where(c => c.DepartmentId.Contains(shiftSignedDepartmentView.DepartmentId)).Count() > 100)
            {
                modalDialog.MsgCode = "1";
                modalDialog.Message = Lang.Shift_ShiftDepartmentAsigned_OverLoad;
                // to do

                return Json(modalDialog);
            }
            bool checkHolidayAndLeave = shiftSignedDepartmentView.IgnoreHolidayAndLeave;
            ScheduleGlobal.ScheduleCalcByDepartmentId(shiftSignedDepartmentView.ShiftId, shiftSignedDepartmentView.DepartmentId, checkHolidayAndLeave, out bool result);

            if (result == true)
            {
                modalDialog.MsgCode = "1";
                modalDialog.Message = Lang.Shift_ShiftDepartmentAsigned_Result;
            }
            else
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.Shift_ShiftDepartmentAsigned_Fail;
            }
            return Json(modalDialog);
        }
        public ActionResult GetShiftDetail(string ShiftId)
        {
            Shift shift = dbContext.Shift.Find(ShiftId);
            ShiftSignedDepartmentView shiftSignedDepartmentView = new ShiftSignedDepartmentView { ShiftId = shift.ShiftId, ShiftAbbrId = shift.ShiftAbbrId, ShiftName = shift.ShiftName, DepartmentId = "", IgnoreHolidayAndLeave = false };
            return Json(shiftSignedDepartmentView, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,MainComOprerator,SystemAdmin")]
        public ActionResult ShiftIsApprovedConfirmed(string shiftId, bool IsApproved)
        {
            ModalDialog modalDialog = new ModalDialog
            {
                MsgCode = "0",
                Message = Lang.ShiftIsApprovedConfirmed_ReturnTrueResult
            };

            bool rejectToModified = ShiftBusinessExtand.ShiftInScheduleRejectToModified(shiftId, ref modalDialog);
            if (rejectToModified)
            {
                return Json(modalDialog);
            }
            Shift shift = dbContext.Shift.Find(shiftId);
            shift.IsApproved = IsApproved;
            shift.OperatedUserName = User.Identity.Name;
            shift.UpdatedDate = DateTime.Now;

            dbContext.Update(shift);
            int result = dbContext.SaveChanges();

            if (result > 0)
            {
                modalDialog.MsgCode = IsApproved == true ? "1" : "2";
                modalDialog.Message = string.Format("{0} {1}", Lang.GeneralUI_Success, IsApproved);
            }
            else
            {
                modalDialog.MsgCode = "0";
                modalDialog.Message = Lang.GeneralUI_DbFail;
            }

            return Json(modalDialog);
        }
    }
}