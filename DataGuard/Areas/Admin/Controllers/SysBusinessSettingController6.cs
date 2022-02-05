using AttApiViewModal;
using AttendanceBussiness;
using AttendanceBussiness.DbFirst;
using AttendanceBussiness.Public;
using AttEnumCode;
using LanguageResource;
using System.Threading;
using System.Web.Mvc;
using static AttendanceBussiness.ShiftBusiness;

namespace DataGuard.Areas.Admin.Controllers
{
    public partial class SysBusinessSettingController : BaseController
    {
        // GET: Admin/ShiftSettingBreak
        [Authorize(Roles = "Admin,MainComOprerator,SystemAdmin")]
        public ActionResult ShiftSettingBreak(string ShiftId)
        {
            ShiftGeneralLunchView shiftSetting = new ShiftGeneralLunchView();

            if (string.IsNullOrEmpty(ShiftId))
            {
                ViewBag.ShiftBusinessMode = (int)ShiftBusinessMode.DAYSHIFT;
                return View();
            }
            else
            {
                ViewBag.ShiftId = ShiftId;
                ViewBag.IsUpdateStatus = true;
                Shift shift = dbContext.Shift.Find(ShiftId);

                ViewBag.ShiftBusinessMode = shift.ShiftBusinessMode;
                return View();
            }
        } 
    }
}