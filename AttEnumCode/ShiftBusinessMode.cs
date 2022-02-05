using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text; 

namespace AttEnumCode
{
    public partial class ShiftBusiness
    {
        [Description("AttendanceType")]
        public enum AttendanceType
        {
            [EnumDisplayName("AttendanceType_NORMAL")]
            NORMAL = 0,

            [EnumDisplayName("AttendanceType_IS_LATE")]
            IS_LATE = 1,

            [EnumDisplayName("AttendanceType_IS_EARLY")]
            IS_EARLY = 2,

            [EnumDisplayName("AttendanceType_NO_RECORD")]
            NO_RECORD = 3,

            [EnumDisplayName("AttendanceType_NO_SETTING")]
            NO_SETTING = 4
        }
        [Description("ShiftBusinessMode")]
        public enum ShiftBusinessMode
        {
            [EnumDisplayName("ShiftBusinessMode_GENERAL")]
            GENERAL = 0,

            [EnumDisplayName("ShiftBusinessMode_DAYSHIFT")]
            DAYSHIFT = 1,

            [EnumDisplayName("ShiftBusinessMode_NIGHTSHIFT")]
            NIGHTSHIFT = 2

            //[Display(Description = "ShiftBusinessMode_CROSSDAYSSHIFT", ResourceType = typeof(ResourceLocalize))]
            //CROSSDAYS_SHIFT = 3,

            //[Display(Description = "ShiftBusinessMode_OVERNIGHTSHIFT", ResourceType = typeof(ResourceLocalize))]
            //OVERNIGHT_SHIFT = 4,

            //[Display(Description = "ShiftBusinessMode_THREESHIFT", ResourceType = typeof(ResourceLocalize))]
            //THREE_SHIFT = 5
        }
        [Description("ShiftAppliedMode")]
        public enum ShiftAppliedMode
        {
            [EnumDisplayName("ShiftAppliedMode_GLOBAL")]
            GLOBAL = 0,

            [EnumDisplayName("ShiftAppliedMode_PARTIAL")]
            PARTIAL = 1
        }

        [Description("ShiftAssignedMode")]
        public enum ShiftAssignedMode
        {
            [EnumDisplayName("ShiftAssignedMode_SYSTEM_ASSIGNED")]
            SYSTEM_ASSIGNED = 0,

            [EnumDisplayName("ShiftAssignedMode_MANUAL_ASSIGNED")]
            MANUAL_ASSIGNED = 1
        }

        [Description("Holiday Paid Type")]
        public enum HolidayPaidType
        {
            [EnumDisplayName("HolidayPaidType_UNPAID_HOLIDAY")] 
            UNPAID_LEAVE = 0,
            [EnumDisplayName("HolidayPaidType_PAID_HOLIDAY")] 
            PAID_LEAVE = 1
        }

        [Description("Leave Paid Type")] 
        public enum LeavePaidType
        {
            [EnumDisplayName("LeavePaidType_UNPAID_LEAVE")] 
            UNPAID_LEAVE = 0,
            [EnumDisplayName("LeavePaidType_PAID_LEAVE")] 
            PAID_LEAVE = 1,
        }

        [Description("LeaveType")]  //STATUTORY_HOLIDAY	SICK_LEAVE	ANNUAL_LEAVE	GENERAL_LEAVE
        public enum LeaveType
        {
            [EnumDisplayName("LeaveType_GENERAL_LEAVE")] 
            GENERAL_LEAVE = 0,
            [EnumDisplayName("LeaveType_STATUTORY_HOLIDAY")] 
            STATUTORY_HOLIDAY = 1,
            [EnumDisplayName("LeaveType_SICK_LEAVE")] 
            SICK_LEAVE = 2,
            [EnumDisplayName("LeaveType_ANNUAL_LEAVE")]
            ANNUAL_LEAVE = 3,
        }

        [Description("Auto Calc Missing")]
        public enum AutoCalcMissingType
        {
            [EnumDisplayName("CalcMissingMode_NOCALC")] 
            NO_CALC = -1,

            [EnumDisplayName("AutoCalcMissingType_NoMissing")] 
            NO_MISSING = 0,

            [EnumDisplayName("AutoCalcMissingType_AutoMissingWorkOn")] 
            AUTO_MISSING_WORKON = 1,

            [EnumDisplayName("AutoCalcMissingType_AutoMissingWorkOff")] 
            AUTO_MISSING_WORKOFF = 2,

            [EnumDisplayName("AutoCalcMissingType_ManualWorkOnMissing")]
            MANUAL_MISSING_WORKON = 4,

            [EnumDisplayName("AutoCalcMissingType_ManualWorkOffMissing")]
            MANUAL_MISSING_WORKOFF = 5,

            [EnumDisplayName("AutoCalcMissingType_AutoMissingLunchStart")]
            AUTO_MISSING_LUNCH_START = 6,

            [EnumDisplayName("AutoCalcMissingType_AutoMissingLunchEnd")]
            AUTO_MISSING_LUNCH_END = 7,

            [EnumDisplayName("AutoCalcMissingType_ManualMissingLunchStart")]
            MANUAL_MISSING_LUNCH_START = 8,

            [EnumDisplayName("AutoCalcMissingType_ManualMissingLunchEnd")]
            MANUAL_MISSING_LUNCH_END = 9,

            [EnumDisplayName("AutoCalcMissingType_AutoMissingOvertimeStart")]
            AUTO_MISSING_OVERTIME_START = 10,

            [EnumDisplayName("AutoCalcMissingType_AutoMissingOvertimeEnd")]
            AUTO_MISSING_OVERTIME_END = 11,

            [EnumDisplayName("AutoCalcMissingType_ManualMissingOvertimeStart")]
            MANUAL_MISSING_OVERTIME_START = 12,

            [EnumDisplayName("AutoCalcMissingType_ManualMissingOvertimeEnd")]
            MANUAL_MISSING_OVERTIME_END = 13
        }

        [Description("Calc Missing Mode")]
        public enum CalcMissingMode
        {
            [EnumDisplayName("CalcMissingMode_NOCALC")]
            NO_CALC = -1,

            [EnumDisplayName("CalcMissingMode_AUTO")]
            AUTO_MISSING = 1
        }

        public enum CalcPeriodType
        {
            [EnumDisplayName("CalcPeriodType_DAYLY")]
            DAYLY = 0,

            [EnumDisplayName("CalcPeriodType_WEEKLY")]
            WEEKLY = 1,

            [EnumDisplayName("CalcPeriodType_MONTHLY")]
            MONTHLY = 2,

            [EnumDisplayName("CalcPeriodType_YEARLY")]
            YEARLY = 3,

            [EnumDisplayName("CalcPeriodType_DEFINITION")]
            DEFINITION = 4
        }
        public enum WeekDayType
        {
            [EnumDisplayName("WeekDayType_MONDAY")]
            MON = 1,
            [EnumDisplayName("WeekDayType_TUEDAY")]
            TUE = 2,
            [EnumDisplayName("WeekDayType_WEDNESDAY")]
            WED = 3,
            [EnumDisplayName("WeekDayType_THURSDAY")]
            THU = 4,
            [EnumDisplayName("WeekDayType_FRIDAY")]
            FRI = 5,
            [EnumDisplayName("WeekDayType_SATURDAY")]
            SAT = 6,
            [EnumDisplayName("WeekDayType_SUNDAY")]
            SUN = 0
        }

        public enum DeviceEntryMode
        {
            [EnumDisplayName("DeviceEntryMode_UNDEFINED")]
            UNDEFINED = 0,
            [EnumDisplayName("DeviceEntryMode_IN")]
            IN = 1,
            [EnumDisplayName("DeviceEntryMode_OUT")]
            OUT = -1,
            [EnumDisplayName("DeviceEntryMode_INOUT")]
            INOUT = 2
        }
        public enum DayShiftOrNightShiftMode
        {
            [EnumDisplayName("DayShiftOrNightMode_DAYSHIFT")]
            DAYSHIFT = 0,
            [EnumDisplayName("DayShiftOrNightMode_NIGHTSHIFT")]
            NIGHTSHIFT = 1
        }

        public enum StatutoryHoliday
        {
            [EnumDisplayName("StatutoryHoliday_NOT_STATUTORY")]
            NOT_STATUTORY = 0,
            [EnumDisplayName("StatutoryHoliday_IS_STATUTORY")]
            IS_STATUTORY = 1
        }
        public enum BitNull
        {
            False,
            True,
            Null = -1
        };
        public enum ApprovedMode
        {
            [EnumDisplayName("ApprovedMode_NotApproved")]
            False = 0,
            [EnumDisplayName("ApprovedMode_IsApproved")]
            True = 1,
            [EnumDisplayName("ApprovedMode_Rejected")]
            Rejected = -1,
        }

        public enum Genders
        {
            [EnumDisplayName("Genders_MALE")]
            Male = 1,
            [EnumDisplayName("Genders_FEMALE")]
            Female = 2,
            [EnumDisplayName("Genders_UNKOWN")]
            Unkown = 3  // M;F;UNKOWN
        }

        public enum HolidayIsWholeDayType
        {
            [EnumDisplayName("HolidayIsWholeDayType_WholeDay")] 
            WHOLE_DAY = 1,
            [EnumDisplayName("HolidayIsWholeDayType_OnlyMorning")] 
            ONLY_MORNING = 2,
            [EnumDisplayName("HolidayIsWholeDayType_OnlyAfterNoon")] 
            ONLY_AFTERNOON = 3
        }
        public enum SynchronizeMode
        {
            [EnumDisplayName("SynchronizeMode_CNNAME")] 
            CNNAME = 0,
            [EnumDisplayName("SynchronizeMode_FULL_NAME")] 
            FULL_NAME = 1,
            [EnumDisplayName("SynchronizeMode_ID_NUMBER")] 
            ID_NUMBER = 2,
            [EnumDisplayName("SynchronizeMode_ACCESSCARD_ID")] 
            ACCESSCARD_ID = 3,
            [EnumDisplayName("SynchronizeMode_CWRG")] 
            CWRG = 4
        }

        //ATTENDANCE MODE FOR ATTENDANCE_LOG
        public enum AttendanceMode
        {
            [EnumDisplayName("AttendanceMode_ACC")]
            ACC = -1,
            [EnumDisplayName("AttendanceMode_CAM_GUARD")]
            CAM_GUARD = 0,
            [EnumDisplayName("AttendanceMode_HIK_CARD")]
            HIK_CARD = 1
        }

        //ATTENDANCE MODE
        public enum DataToObjectMode
        {
            MONTHLY_DTO = -1
        }

        public enum MainComServiceStatus
        {
            ON_SERVICE = 1,
            OFF_SERVICE = -1
        }
    }
    public class CalcPeriodType
    {
        public string Period;
        public CalcPeriodType PeriodType;
        public string StartDate;
        public string EndDate;
    } 
}
