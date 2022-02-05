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
using DataGuard.Context;
using LanguageResource;
using Microsoft.AspNet.Identity;
using static AttendanceBussiness.ShiftBusiness;

namespace DataGuard.Areas.Admin.Controllers
{
    public partial class ShiftStepController : BaseController
    {
        /// <summary>
        /// Basic Shift
        /// </summary>
        /// <param name="ShiftId">& ViewBag.IntShiftBusinessMode is required. default value = 1</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Admin,MainComOprerator,SystemAdmin")]
        public ActionResult Basic(string ShiftId)
        {
            ViewBag.IntShiftBusinessMode = (int)ShiftBusinessMode.DAYSHIFT; //default value

            ShiftBasic shiftBasic = new ShiftBasic(); 

            if (string.IsNullOrEmpty(ShiftId))
            { 
                ViewBag.IsUpdateStatus = false;
                shiftBasic.AppliedStartDate = DateTime.Now;
                shiftBasic.AppliedEndDate = DateTime.Now;
                ShiftBusinessModeDropDownList(ShiftBusinessMode.DAYSHIFT.ToString()); 
                ShiftAppliedModeDropDownList(ShiftAppliedMode.GLOBAL.ToString()); 
            }
            else
            {
                ViewBag.IsUpdateStatus = true;

                Shift shift = dbContext.Shift.Find(ShiftId);
                ShiftObjectification shiftObjectification = AttendanceBussiness.ShiftModule.ShiftBusiness.GetObjectification(shift);
                shiftBasic = shiftObjectification.ShiftBasic;
                ShiftBusinessModeDropDownList(shiftBasic.ShiftBusinessMode.ToString());
                ShiftAppliedModeDropDownList(shiftBasic.ShiftAppliedMode.ToString());
                ViewBag.IntShiftBusinessMode = (int)shiftBasic.ShiftBusinessMode;  //***
            } 
            return View(shiftBasic);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Emplyee,MainComOprerator,SystemAdmin")]
        public ActionResult Basic([Bind(Include = "ShiftId,ShiftAbbrId,IconColor,ShiftName,ShiftBusinessMode,ShiftAppliedMode,WorkStartAllowance,WorkEndAllowance,AppliedStartDate,AppliedEndDate,RuleDescription")] ShiftBasic shiftBasic)
        {
            string userName = User.Identity.Name;
            string userId = User.Identity.GetUserId();
            DateTime dtNow = DateTime.Now;
            ResponseModalX responseModalX = new ResponseModalX();  
            if (shiftBasic.AppliedEndDate == null || shiftBasic.AppliedEndDate < DateTime.Now)
            { 
                responseModalX.meta = new MetaModalX { ErrorCode = (int)ShiftErrorCode.APPLIED_STARTDATE_NOT_LOGICAL, Success = false, Message = Lang.Shift_AppliedStartDateIsNotLogical_Validator };
                return Json(responseModalX);  //Shift_AppliedStartDateIsNotLogical_Validator

                //responseModalX.meta = new MetaModalX { ErrorCode = (int)ShiftErrorCode.SHIFT_ERROR_NO_SHIFT_ID_OR_NULL, Success = false, Message = "Lang.SHIFT_ERROR_NO_SHIFT_ID_OR_NULL" };
            }
            if (string.IsNullOrEmpty(shiftBasic.ShiftId))
            {
                using (DataBaseContext dataBaseContext = new DataBaseContext())
                {
                    Shift shift = new Shift();
                    shift = ShiftDefaultField.CreateNewButBasic(shift);

                    shift.ShiftId = dbContext.GetTableKeyID_DatePeriod(shiftBasic.AppliedStartDate, shiftBasic.AppliedEndDate);

                    shift.ShiftAbbrId = shiftBasic.ShiftAbbrId;
                    shift.IconColor = shiftBasic.IconColor;
                    shift.ShiftName = shiftBasic.ShiftName;
                    shift.ShiftBusinessMode = (int)shiftBasic.ShiftBusinessMode;
                    shift.ShiftAppliedMode = (int)shiftBasic.ShiftAppliedMode;
                    shift.WorkStartAllowance = shiftBasic.WorkStartAllowance;
                    shift.WorkEndAllowance = shiftBasic.WorkEndAllowance;
                    shift.AppliedStartDate = shiftBasic.AppliedStartDate;
                    shift.AppliedEndDate = shiftBasic.AppliedEndDate;
                    shift.RuleDescription = shiftBasic.RuleDescription;
                    //[System] 
                    shift.OperatedUserName = userName;
                    shift.UpdatedDate = dtNow;
                    shift.CreatedDate = dtNow;

                    try
                    {
                        dbContext.Add(shift);
                        dbContext.SaveChanges();
                         
                        responseModalX.meta = new MetaModalX { ErrorCode = (int)GeneralReturnCode.SUCCESS, Success = true, Message = Lang.GeneralUI_Success };
                        responseModalX.data = new { shift.ShiftId };

                        return Json(responseModalX);
                    }
                    catch (Exception e)
                    { 
                        responseModalX.meta = new MetaModalX { ErrorCode = (int)GeneralReturnCode.EXCEPTION, Success = false, Message = e.Message };
                        return Json(responseModalX);
                    }
                }
            }else
            { 
                using (DataBaseContext dataBaseContext = new DataBaseContext())
                {
                    Shift shift = dbContext.Shift.Find(shiftBasic.ShiftId);

                    try
                    {
                        shift.ShiftAbbrId = shiftBasic.ShiftAbbrId;
                        shift.IconColor = shiftBasic.IconColor;
                        shift.ShiftName = shiftBasic.ShiftName;
                        shift.ShiftBusinessMode = (int)shiftBasic.ShiftBusinessMode;
                        shift.ShiftAppliedMode = (int)shiftBasic.ShiftAppliedMode;
                        shift.WorkStartAllowance = shiftBasic.WorkStartAllowance;
                        shift.WorkEndAllowance = shiftBasic.WorkEndAllowance;
                        shift.AppliedStartDate = shiftBasic.AppliedStartDate;
                        shift.AppliedEndDate = shiftBasic.AppliedEndDate;
                        shift.RuleDescription = shiftBasic.RuleDescription;
                         
                        shift.OperatedUserName = userName;
                        shift.UpdatedDate = dtNow;  

                        bool rejectToModified = ShiftBusinessExtand.ShiftInScheduleRejectToModified(shift.ShiftId, ref responseModalX);
                        if (rejectToModified && shift.IsApproved)
                        {
                            return Json(responseModalX);
                        }
                        dbContext.Update(shift);
                        dbContext.SaveChanges();

                        responseModalX.meta = new MetaModalX { ErrorCode = (int)GeneralReturnCode.SUCCESS, Success = true, Message = Lang.GeneralUI_Success };
                        responseModalX.data = new { ShiftId = shift.ShiftId };
                        return Json(responseModalX);
                    }
                    catch (Exception e)
                    {
                        responseModalX.meta = new MetaModalX { ErrorCode = (int)GeneralReturnCode.EXCEPTION, Success = false, Message = e.Message };
                        return Json(responseModalX);
                    }
                }
            }
           
        }
    }
}