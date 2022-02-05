using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttApiViewModal.ShiftModule;
using AttendanceBussiness.DbFirst;
using AttendanceBussiness.ShiftModule;
using LanguageResource;
using static AttEnumCode.ShiftBusiness;

namespace DataGuard.Areas.Admin.Controllers
{
    public partial class ShiftStepController : BaseController
    {
        // GET: Admin/ShiftStep
        public ActionResult HeaderState(string shiftId ,int intShiftBusinessMode,int step)
        {
            ShiftBusinessMode shiftBusinessMode = (ShiftBusinessMode)intShiftBusinessMode;

            ShiftHeaderState shiftHeaderState = new ShiftHeaderState();
            shiftHeaderState.ShiftId = shiftId;
            shiftHeaderState.IconOfShiftBasic = new HeaderOfShift { StepIndex = (int)ShiftHeaderStep.SHIFT_BASIC_INFO_SETTING, IconStyle = "bg-white", TextStyle="info-primary", HeaderName = Lang.SHIFT_BASIC_INFO_SETTING, HeaderDesc = Lang.SHIFT_BASIC_INFO_SETTING_HeaderDesc }; // Lang.SHIFT_BASIC_INFO_SETTING
            shiftHeaderState.IconOfShiftWork = new HeaderOfShift { StepIndex = (int)ShiftHeaderStep.SHIFT_WORK_SETTING, IconStyle = "bg-white", TextStyle = "info-primary", HeaderName = Lang.SHIFT_WORK_TIME_SETTING, HeaderDesc = Lang.SHIFT_WORK_TIME_SETTING_DESC};
            shiftHeaderState.IconOfShiftLunch = new HeaderOfShift { StepIndex = (int)ShiftHeaderStep.SHIFT_LUNCH_SETTING, IconStyle = "bg-white", TextStyle = "info-primary", HeaderName = Lang.Shift_LunchTimeLabel, HeaderDesc = Lang.Shift_LunchTimeLabel_Desc  };
            shiftHeaderState.IconOfShiftOverTime = new HeaderOfShift { StepIndex = (int)ShiftHeaderStep.SHIFT_OVERTIME_SETTING, IconStyle = "bg-white", TextStyle = "info-primary", HeaderName = Lang.Shift_OverTimeLabel, HeaderDesc = Lang.Shift_OverTimeLabel_Desc };
            shiftHeaderState.IconOfSpecialAndExclude = new HeaderOfShift { StepIndex = (int)ShiftHeaderStep.SHIF_LOGIC_OF_SPECIAL_AND_EXCLUDE_SETTING, IconStyle = "bg-white", TextStyle = "info-primary", HeaderName = Lang.SHIFT_EXCEPTION_INFO_SETTING, HeaderDesc = Lang.SHIFT_EXCEPTION_INFO_SETTING_DESC  };
            shiftHeaderState.IconOfMissingCalc = new HeaderOfShift { StepIndex = (int)ShiftHeaderStep.SHIFT_MISSING_CALC_SETTING, IconStyle = "bg-white", TextStyle = "info-primary", HeaderName = Lang.SHIFT_MISSING_SETTING, HeaderDesc = Lang.SHIFT_MISSING_SETTING_DESC };
            if (step == 0)
                shiftHeaderState.Progress = 1;
            else
            {
                double x = ((double)step/6)*100;
                shiftHeaderState.Progress = (decimal)Math.Round(x, 1);
            } 

            using (DataBaseContext dataBaseContext = new DataBaseContext())
            {
                switch(shiftBusinessMode)
                {
                    case ShiftBusinessMode.DAYSHIFT:
                        shiftHeaderState.HeaderOfShiftBusinessMode = new HeaderOfShiftBusinessMode { IconClass = "fas fa-sun", IconColorAndClass ="text-white", IconBgClass = "bg-warning-gradient", ShiftBusinessMode = ShiftBusinessMode.DAYSHIFT };
                        break;

                    case ShiftBusinessMode.NIGHTSHIFT:
                        shiftHeaderState.HeaderOfShiftBusinessMode = new HeaderOfShiftBusinessMode { IconClass = "fas fa-moon", IconColorAndClass = "text-white", IconBgClass = "bg-dark-gradient ", ShiftBusinessMode = ShiftBusinessMode.NIGHTSHIFT };
                        break;

                    case ShiftBusinessMode.GENERAL:
                        shiftHeaderState.HeaderOfShiftBusinessMode = new HeaderOfShiftBusinessMode { IconClass = "fas fa-globe-asia", IconColorAndClass = "text-white", IconBgClass = "bg-success-gradient", ShiftBusinessMode = ShiftBusinessMode.DAYSHIFT };
                        break;

                    default:
                        shiftHeaderState.HeaderOfShiftBusinessMode = new HeaderOfShiftBusinessMode { IconClass = "fas fa-address-card", IconColorAndClass = "text-white", IconBgClass = "bg-success-gradient", ShiftBusinessMode = ShiftBusinessMode.DAYSHIFT };
                        break;
                }

                switch (step)
                {
                    case 1: 
                        shiftHeaderState.IconOfShiftBasic.TextStyle = "text-white";
                        shiftHeaderState.IconOfShiftBasic.IconStyle = "bg-secondary-gradient";
                        break;
                    case 2:
                        shiftHeaderState.IconOfShiftWork.TextStyle = "text-white";
                        shiftHeaderState.IconOfShiftWork.IconStyle = "bg-secondary-gradient";
                        break;
                    case 3:
                        shiftHeaderState.IconOfShiftLunch.TextStyle = "text-white";
                        shiftHeaderState.IconOfShiftLunch.IconStyle = "bg-secondary-gradient";
                        break;
                    case 4:
                        shiftHeaderState.IconOfShiftOverTime.TextStyle = "text-white";
                        shiftHeaderState.IconOfShiftOverTime.IconStyle = "bg-secondary-gradient";
                        break;

                    case 5:
                        shiftHeaderState.IconOfSpecialAndExclude.TextStyle = "text-white";
                        shiftHeaderState.IconOfSpecialAndExclude.IconStyle = "bg-secondary-gradient";
                        break;

                    case 6:
                        shiftHeaderState.IconOfMissingCalc.TextStyle = "text-white";
                        shiftHeaderState.IconOfMissingCalc.IconStyle = "bg-secondary-gradient";
                        break;

                    default:
                        shiftHeaderState.IconOfShiftBasic.TextStyle = "text-white";
                        shiftHeaderState.IconOfShiftBasic.IconStyle = "bg-secondary-gradient";
                        break;
                }
                return View(shiftHeaderState);
            }
        }
    }
}