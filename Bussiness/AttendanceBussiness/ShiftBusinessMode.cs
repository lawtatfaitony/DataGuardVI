using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using LanguageResource; 
using System.Reflection;

namespace AttendanceBussiness
{ 
    public partial class ShiftBusiness  
    {
        [Description("AttendanceType")]
        public enum AttendanceType
        {
            [EnumDisplayName("AttendanceType_NORMAL")]
            NORMAL = 0,
            [EnumDisplayName("AttendanceType_NO_RECORD")]
            NO_RECORD = 1,
            [EnumDisplayName("AttendanceType_IS_EARLY")]
            IS_EARLY = 2,
            [EnumDisplayName("AttendanceType_IS_LATE")]
            IS_LATE = 3, 
            [EnumDisplayName("AttendanceType_NO_SETTING")]
            NO_SETTING = 4
        }
        [Description("ShiftBusinessMode")]
        public  enum ShiftBusinessMode
        {  
            [EnumDisplayName("ShiftBusinessMode_GENERAL")]
            GENERAL = 0,
             
            [EnumDisplayName("ShiftBusinessMode_DAYSHIFT")]
            DAYSHIFT = 1,

            [EnumDisplayName("ShiftBusinessMode_NIGHTSHIFT")]
            NIGHTSHIFT = 2  
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
            [Display(Description = "HolidayPaidType_UNPAID_HOLIDAY", ResourceType = typeof(ResourceLocalize))]
            UNPAID_LEAVE = 0,
             
            [Display(Description = "HolidayPaidType_PAID_HOLIDAY", ResourceType = typeof(ResourceLocalize))]
            PAID_LEAVE = 1  
        }

        [Description("Leave Paid Type")]  //LeavePaidType_PAID_LEAVE
        public enum LeavePaidType
        {
            [Display(Description = "LeavePaidType_UNPAID_LEAVE", ResourceType = typeof(ResourceLocalize))]
            UNPAID_LEAVE = 0,
            [Display(Description = "LeavePaidType_PAID_LEAVE", ResourceType = typeof(ResourceLocalize))]
            PAID_LEAVE = 1, 
        }

        [Description("LeaveType")]  //STATUTORY_HOLIDAY	SICK_LEAVE	ANNUAL_LEAVE	GENERAL_LEAVE
        public enum LeaveType
        {
            [Display(Description = "LeaveType_GENERAL_LEAVE", ResourceType = typeof(ResourceLocalize))]
            GENERAL_LEAVE = 0,

            [Display(Description = "LeaveType_STATUTORY_HOLIDAY", ResourceType = typeof(ResourceLocalize))]
            STATUTORY_HOLIDAY = 1,

            [Display(Description = "LeaveType_SICK_LEAVE", ResourceType = typeof(ResourceLocalize))]
            SICK_LEAVE = 2,

            [Display(Description = "LeaveType_ANNUAL_LEAVE", ResourceType = typeof(ResourceLocalize))]
            ANNUAL_LEAVE = 3, 
        }

        [Description("Auto Calc Missing")]  
        public enum AutoCalcMissingType
        {
            [Display(Description = "CalcMissingMode_NOCALC", ResourceType = typeof(ResourceLocalize))]
            NO_CALC = -1,

            [Display(Description = "AutoCalcMissingType_NoMissing", ResourceType = typeof(ResourceLocalize))]
            NO_MISSING = 0,

            [Display(Description = "AutoCalcMissingType_AutoMissingWorkOn", ResourceType = typeof(ResourceLocalize))]
            AUTO_MISSING_WORKON = 1,

            [Display(Description = "AutoCalcMissingType_AutoMissingWorkOff", ResourceType = typeof(ResourceLocalize))]
            AUTO_MISSING_WORKOFF = 2,

            [Display(Description = "AutoCalcMissingType_ManualWorkOnMissing", ResourceType = typeof(ResourceLocalize))]
            MANUAL_MISSING_WORKON = 4, 

            [Display(Description = "AutoCalcMissingType_ManualWorkOffMissing", ResourceType = typeof(ResourceLocalize))]
            MANUAL_MISSING_WORKOFF = 5, 

            [Display(Description = "AutoCalcMissingType_AutoMissingLunchStart", ResourceType = typeof(ResourceLocalize))]
            AUTO_MISSING_LUNCH_START = 6,

            [Display(Description = "AutoCalcMissingType_AutoMissingLunchEnd", ResourceType = typeof(ResourceLocalize))]
            AUTO_MISSING_LUNCH_END = 7,

            [Display(Description = "AutoCalcMissingType_ManualMissingLunchStart", ResourceType = typeof(ResourceLocalize))]
            MANUAL_MISSING_LUNCH_START = 8,

            [Display(Description = "AutoCalcMissingType_ManualMissingLunchEnd", ResourceType = typeof(ResourceLocalize))]
            MANUAL_MISSING_LUNCH_END = 9,

            [Display(Description = "AutoCalcMissingType_AutoMissingOvertimeStart", ResourceType = typeof(ResourceLocalize))]
            AUTO_MISSING_OVERTIME_START = 10,

            [Display(Description = "AutoCalcMissingType_AutoMissingOvertimeEnd", ResourceType = typeof(ResourceLocalize))]
            AUTO_MISSING_OVERTIME_END = 11,

            [Display(Description = "AutoCalcMissingType_ManualMissingOvertimeStart", ResourceType = typeof(ResourceLocalize))]
            MANUAL_MISSING_OVERTIME_START = 12,

            [Display(Description = "AutoCalcMissingType_ManualMissingOvertimeEnd", ResourceType = typeof(ResourceLocalize))]
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
            OUT = -1 ,
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
            [Display(Description = "HolidayIsWholeDayType_WholeDay", ResourceType = typeof(ResourceLocalize))]
            WHOLE_DAY = 1, 
            [Display(Description = "HolidayIsWholeDayType_OnlyMorning", ResourceType = typeof(ResourceLocalize))]
            ONLY_MORNING = 2, 
            [Display(Description = "HolidayIsWholeDayType_OnlyAfterNoon", ResourceType = typeof(ResourceLocalize))]
            ONLY_AFTERNOON = 3 
        }
        public enum SynchronizeMode
        {
            [Display(Description = "SynchronizeMode_CNNAME", ResourceType = typeof(ResourceLocalize))]
            CNNAME = 0,

            [Display(Description = "SynchronizeMode_FULL_NAME", ResourceType = typeof(ResourceLocalize))]
            FULL_NAME = 1,

            [Display(Description = "SynchronizeMode_ID_NUMBER", ResourceType = typeof(ResourceLocalize))]
            ID_NUMBER = 2,

            [Display(Description = "SynchronizeMode_ACCESSCARD_ID", ResourceType = typeof(ResourceLocalize))]
            ACCESSCARD_ID = 3,

            [Display(Description = "SynchronizeMode_CWRG", ResourceType = typeof(ResourceLocalize))]
            CWRG = 4
        }

        //ATTENDANCE MODE FOR ATTENDANCE_LOG
        public enum AttendanceMode
        {
            [Display(Description = "AttendanceMode_ACC", ResourceType = typeof(ResourceLocalize))]
            ACC = -1,

            [Display(Description = "AttendanceMode_CAM_GUARD", ResourceType = typeof(ResourceLocalize))]
            CAM_GUARD = 0,

            [Display(Description = "AttendanceMode_HIK_CARD", ResourceType = typeof(ResourceLocalize))]
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

    /// <summary>
    /// 自定义注解属性
    /// </summary>
    public class EnumDisplayNameAttribute : Attribute
    {
        private string _diaplayName;
        public string DisplayName
        {
            get
            {
                string langDesc = LangUtilities.GetStringReflectKeyName(_diaplayName); 
                return langDesc;
            }
        }
        public EnumDisplayNameAttribute(string displayName)
        {
            _diaplayName = displayName;
        }
    }
}
