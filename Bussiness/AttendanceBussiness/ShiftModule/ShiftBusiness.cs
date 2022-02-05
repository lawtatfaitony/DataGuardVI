using System;
using System.Collections.Generic;
using System.Text;
using AttApiViewModal.ShiftModule;
using AttendanceBussiness.DbFirst;
using static AttEnumCode.ShiftBusiness;

namespace AttendanceBussiness.ShiftModule
{
    public partial class ShiftBusiness
    {
        public static ShiftObjectification GetObjectification(Shift shift)
        {
            ShiftObjectification shiftObjectification = new ShiftObjectification();

            ShiftBasic shiftBasic = new ShiftBasic() ;
            ShiftBrief shiftBrief = new ShiftBrief();
            ShiftWork shiftWork = new ShiftWork();
            ShiftLunch shiftLunch = new ShiftLunch();
            ShiftOverTime shiftOverTime = new ShiftOverTime();
            LogicOfSpecialAndExclude logicOfSpecialAndExclude = new LogicOfSpecialAndExclude() ;
            ShiftMissingCalc shiftMissingCalc = new ShiftMissingCalc() ;

            //ShiftBrief
            shiftBrief.ShiftId = shift.ShiftId;
            shiftBrief.ShiftAbbrId = shift.ShiftAbbrId;
            shiftBrief.IconColor = shift.IconColor;
            shiftBrief.ShiftName = shift.ShiftName;
            shiftBrief.ShiftBusinessMode = (ShiftBusinessMode)shift.ShiftBusinessMode;
            shiftBrief.ShiftAppliedMode = (ShiftAppliedMode)shift.ShiftAppliedMode;
            shiftBrief.AppliedStartDate = shift.AppliedStartDate;
            shiftBrief.AppliedEndDate = shift.AppliedEndDate;
            //Basic
            shiftBasic.ShiftId = shift.ShiftId; 
            shiftBasic.ShiftAbbrId = shift.ShiftAbbrId; 
            shiftBasic.IconColor = shift.IconColor; 
            shiftBasic.ShiftName = shift.ShiftName; 
            shiftBasic.ShiftBusinessMode = (ShiftBusinessMode)shift.ShiftBusinessMode; 
            shiftBasic.ShiftAppliedMode = (ShiftAppliedMode)shift.ShiftAppliedMode; 
            shiftBasic.WorkStartAllowance = shift.WorkStartAllowance;
            shiftBasic.WorkEndAllowance = shift.WorkEndAllowance; 
            shiftBasic.AppliedStartDate = shift.AppliedStartDate;
            shiftBasic.AppliedEndDate = shift.AppliedEndDate;
            shiftBasic.RuleDescription = shift.RuleDescription;
            //ShiftWork
            shiftWork.ShiftId = shift.ShiftId;
            shiftWork.WorkStart = shift.WorkStart;
            shiftWork.WorkEnd = shift.WorkEnd;
            shiftWork.WorkStartBuffer = shift.WorkStartBuffer;
            shiftWork.WorkEndBuffer = shift.WorkEndBuffer;
            //ShiftLunch
            shiftLunch.ShiftId = shift.ShiftId;
            shiftLunch.LunchTimeSpan = shift.LunchTimeSpan;
            shiftLunch.LunchTimeStart = shift.LunchTimeStart;
            shiftLunch.LunchTimeEnd = shift.LunchTimeEnd;
            shiftLunch.LunchTimeStartBuffer = shift.LunchTimeStartBuffer;
            shiftLunch.LunchTimeEndBuffer = shift.LunchTimeEndBuffer;
            //ShiftOverTime
            shiftOverTime.ShiftId = shift.ShiftId;
            shiftOverTime.OverTimeSpan = shift.OverTimeSpan;
            shiftOverTime.OverTimeStart = shift.OverTimeStart;
            shiftOverTime.OverTimeEnd = shift.OverTimeEnd;
            shiftOverTime.OverTimeStartBuffer = shift.OverTimeStartBuffer;
            shiftOverTime.OverTimeEndBuffer = shift.OverTimeEndBuffer;

            //logicOfSpecialAndExclude
            logicOfSpecialAndExclude.ShiftId = shift.ShiftId;
            logicOfSpecialAndExclude.SpecialWeekDays = string.IsNullOrEmpty(shift.SpecialWeekDays) || shift.SpecialWeekDays == "0" ? null: shift.SpecialWeekDays.Split(',');
            logicOfSpecialAndExclude.SpecialWeekDaysWorkStart = shift.SpecialWeekDaysWorkStart;
            logicOfSpecialAndExclude.SpecialWeekDaysWorkEnd = shift.SpecialWeekDaysWorkEnd;
            logicOfSpecialAndExclude.ExcludeWeekDay = string.IsNullOrEmpty(shift.ExcludeWeekDay) || shift.ExcludeWeekDay == "0" ? null : shift.ExcludeWeekDay.Split(',');
            logicOfSpecialAndExclude.ExcludeOverTime = string.IsNullOrEmpty(shift.ExcludeOverTime) || shift.ExcludeOverTime == "0" ? null : shift.ExcludeOverTime.Split(',');
            //ShiftMissingCalc
            shiftMissingCalc.ShiftId = shift.ShiftId;
            shiftMissingCalc.IsAutoCalcMissing = shift.IsAutoCalcMissing.GetValueOrDefault();
            shiftMissingCalc.MissingWorkOn = (CalcMissingMode)shift.MissingWorkOn;
            shiftMissingCalc.MissingWorkOff = (CalcMissingMode)shift.MissingWorkOff;
            shiftMissingCalc.MissingLunchStart = (CalcMissingMode)shift.MissingLunchStart;
            shiftMissingCalc.MissingLunchEnd = (CalcMissingMode)shift.MissingLunchEnd;
            shiftMissingCalc.MissingOverTimeStart = (CalcMissingMode)shift.MissingOverTimeStart;
            shiftMissingCalc.MissingOverTimeEnd = (CalcMissingMode)shift.MissingOverTimeEnd;

            //--------------------------------------------
            shiftObjectification.ShiftId = shift.ShiftId;
            shiftObjectification.ShiftBrief = shiftBrief;
            shiftObjectification.ShiftBasic = shiftBasic;
            shiftObjectification.ShiftWork = shiftWork;
            shiftObjectification.ShiftLunch = shiftLunch;
            shiftObjectification.ShiftOverTime = shiftOverTime;
            shiftObjectification.LogicOfSpecialAndExclude = logicOfSpecialAndExclude;
            shiftObjectification.ShiftMissingCalc = shiftMissingCalc;

            return shiftObjectification;
        }
    }
}
