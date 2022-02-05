using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttApiViewModal.ShiftModule;
using AttendanceBussiness.DbFirst;

namespace DataGuard.Areas.Admin.Controllers
{
    public partial class ShiftStepController : BaseController
    {
        [HttpGet]
        [Authorize(Roles = "Admin,MainComOprerator,SystemAdmin")]
        public ActionResult ShiftBrief(string ShiftId)
        {
            ShiftBrief shiftBrief = new ShiftBrief(); 
            if(string.IsNullOrEmpty(ShiftId))
            {
                ShiftBusinessModeDropDownList("");
                ShiftAppliedModeDropDownList("");
            }
            else
            {
                using (DataBaseContext dataBaseContext = new DataBaseContext())
                { 
                    Shift shift = dataBaseContext.Shift.Find(ShiftId);
                    ShiftObjectification shiftObjectification = AttendanceBussiness.ShiftModule.ShiftBusiness.GetObjectification(shift);
                    shiftBrief = shiftObjectification.ShiftBrief;
                    ShiftBusinessModeDropDownList(shiftBrief.ShiftBusinessMode.ToString());
                    ShiftAppliedModeDropDownList(shiftBrief.ShiftAppliedMode.ToString());
                }
            } 
            return View(shiftBrief);
        }
    }
}