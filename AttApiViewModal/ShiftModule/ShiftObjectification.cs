using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using LanguageResource;
using static AttEnumCode.ShiftBusiness;
using AttendanceBussiness.DbFirst;
using AttEnumCode;

namespace AttApiViewModal.ShiftModule
{
    public enum ShiftHeaderStep
    {
        [EnumDisplayName("SHIFT_BASIC_INFO_SETTING")]
        SHIFT_BASIC_INFO_SETTING = 1,

        [EnumDisplayName("SHIFT_WORK_SETTING")]
        SHIFT_WORK_SETTING = 2,

        [EnumDisplayName("SHIFT_LUNCH_SETTING")]
        SHIFT_LUNCH_SETTING = 3,

        [EnumDisplayName("SHIFT_OVERTIME_SETTING")]
        SHIFT_OVERTIME_SETTING = 4,

        [EnumDisplayName("SHIF_LOGIC_OF_SPECIAL_AND_EXCLUDE_SETTING")]
        SHIF_LOGIC_OF_SPECIAL_AND_EXCLUDE_SETTING = 5,  //Logic Of SpecialAndExclude

        [EnumDisplayName("SHIFT_MISSING_CALC_SETTING")]
        SHIFT_MISSING_CALC_SETTING = 6
    }
    public partial class HeaderOfShiftBusinessMode
    {
        public string IconClass { get; set; }
        public string IconBgClass { get; set; }
        public string IconColorAndClass { get; set; }
        public ShiftBusinessMode ShiftBusinessMode { get; set; } 
    }
    public partial class HeaderOfShift
    {
        public int StepIndex { get; set; }
        public string IconStyle { get; set; }
        public string TextStyle { get; set; }
        public string HeaderName { get; set; }
        public string HeaderDesc { get; set; }
    }
    public partial class ShiftHeaderState
    {
        public  string ShiftId { get; set; }
        public decimal Progress { get; set; } = 0;
        public HeaderOfShiftBusinessMode HeaderOfShiftBusinessMode { get; set; }
        public  HeaderOfShift IconOfShiftBasic { get; set; }
        public  HeaderOfShift IconOfShiftWork { get; set; }
        public  HeaderOfShift IconOfShiftLunch { get; set; }
        public  HeaderOfShift IconOfShiftOverTime { get; set; } 
        public  HeaderOfShift IconOfSpecialAndExclude { get; set; }
        public  HeaderOfShift IconOfMissingCalc { get; set; }
    }
    public partial class ShiftObjectification
    { 
        public string ShiftId { get; set; }
        public ShiftBasic ShiftBasic { get; set; }
        public ShiftBrief ShiftBrief { get; set; }
        public ShiftWork ShiftWork { get; set; }
        public ShiftLunch ShiftLunch { get; set; }
        public ShiftOverTime ShiftOverTime { get; set; }
        public LogicOfSpecialAndExclude LogicOfSpecialAndExclude { get; set; }
        public ShiftMissingCalc ShiftMissingCalc { get; set; }
    }

    public partial class ShiftBasic
    {
        public string ShiftId { get; set; }
        [Required]
        [RegularExpression(@"^[\u4e00-\u9fa5]{1,2}$|^[A-Z]{1,4}$|^[a-z]{1,4}$", ErrorMessageResourceName = "Shift_ShiftAbbrId_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public string ShiftAbbrId { get; set; }

        public string IconColor { get; set; } = "#fc0366";

        public string ShiftName { get; set; }

        public ShiftBusinessMode ShiftBusinessMode { get; set; } 

        public ShiftAppliedMode ShiftAppliedMode { get; set; } 

        [Required(ErrorMessageResourceName = "Shift_WorkStartAllowance_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public int WorkStartAllowance { get; set; }

        [Required(ErrorMessageResourceName = "Shift_WorkEndAllowance_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public int WorkEndAllowance { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [RegularExpression(@"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$", ErrorMessageResourceName = "GeneralUI_Date", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public DateTime AppliedStartDate { get; set; } = DateTime.Now;

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", NullDisplayText = "1900-01-01")]
        [RegularExpression(@"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$", ErrorMessageResourceName = "GeneralUI_Date", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public DateTime AppliedEndDate { get; set; } = DateTime.Now;

        public string RuleDescription { get; set; }
    }

    public partial class ShiftBrief
    {
        public string ShiftId { get; set; }

        [RegularExpression(@"^[\u4e00-\u9fa5]{1,2}$|^[A-Z]{1,4}$|^[a-z]{1,4}$", ErrorMessageResourceName = "Shift_ShiftAbbrId_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public string ShiftAbbrId { get; set; }

        public string IconColor { get; set; } = "#fc0366";

        public string ShiftName { get; set; }

        public ShiftBusinessMode ShiftBusinessMode { get; set; }

        public ShiftAppliedMode ShiftAppliedMode { get; set; }
          
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [RegularExpression(@"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$", ErrorMessageResourceName = "GeneralUI_Date", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public DateTime AppliedStartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", NullDisplayText = "1900-01-01")]
        [RegularExpression(@"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$", ErrorMessageResourceName = "GeneralUI_Date", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public DateTime AppliedEndDate { get; set; }
    }

    public partial class ShiftWork
    {
        public string ShiftId { get; set; }
         
        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        public TimeSpan WorkStart { get; set; }

        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        public TimeSpan WorkEnd { get; set; }
         
        public int WorkStartBuffer { get; set; }
         
        public int WorkEndBuffer { get; set; }

    }

    public partial class ShiftLunch
    {
        public string ShiftId { get; set; }

        public decimal LunchTimeSpan { get; set; }

        public TimeSpan LunchTimeStart { get; set; }

        public TimeSpan LunchTimeEnd { get; set; }

        public int LunchTimeStartBuffer { get; set; }

        public int LunchTimeEndBuffer { get; set; }
    }

    public partial class ShiftOverTime
    {
        public string ShiftId { get; set; }

        public decimal OverTimeSpan { get; set; }

        public TimeSpan OverTimeStart { get; set; }

        public TimeSpan OverTimeEnd { get; set; }

        public int OverTimeStartBuffer { get; set; }

        public int OverTimeEndBuffer { get; set; }
    }

    public partial class LogicOfSpecialAndExclude
    {
        public string ShiftId { get; set; }

        public string[] SpecialWeekDays { get; set; }

        public TimeSpan SpecialWeekDaysWorkStart { get; set; }

        public TimeSpan SpecialWeekDaysWorkEnd { get; set; }

        public string[] ExcludeWeekDay { get; set; }

        public string[] ExcludeOverTime { get; set; }
    }

    public partial class ShiftMissingCalc
    {
        public string ShiftId { get; set; }

        public bool IsAutoCalcMissing { get; set; }
        
        public CalcMissingMode MissingWorkOn { get; set; } = CalcMissingMode.NO_CALC;

        public CalcMissingMode MissingWorkOff { get; set; } = CalcMissingMode.NO_CALC;

        public CalcMissingMode MissingLunchStart { get; set; } = CalcMissingMode.NO_CALC;

        public CalcMissingMode MissingLunchEnd { get; set; } = CalcMissingMode.NO_CALC;

        public CalcMissingMode MissingOverTimeStart { get; set; } = CalcMissingMode.NO_CALC;

        public CalcMissingMode MissingOverTimeEnd { get; set; } = CalcMissingMode.NO_CALC;
    }

    public partial class ShiftDefaultField
    {
        #region default Shift value
        private static string DepartmentIdArr { get; set; } = string.Empty;
        private static string CompanyName { get; set; } = string.Empty;
        private static decimal WorkTimeSpan { get; set; } = 0;
        private static TimeSpan WorkStart { get; set; } = new TimeSpan(0);
        private static TimeSpan WorkEnd { get; set; } = new TimeSpan(0);
        private static int WorkStartBuffer { get; set; }
        private static int WorkEndBuffer { get; set; }
        private static string SpecialWeekDays { get; set; } = string.Empty;
        private static TimeSpan SpecialWeekDaysWorkStart { get; set; } = new TimeSpan(0, 0, 0, 0);
        private static TimeSpan SpecialWeekDaysWorkEnd { get; set; } = new TimeSpan(0,0,0,0);
        private static string ExcludeWeekDay { get; set; } = string.Empty;
        private static string ExcludeOverTime { get; set; } = string.Empty;
        private static decimal OverTimeSpan { get; set; } = 0;
        private static TimeSpan OverTimeStart { get; set; } = new TimeSpan(0, 0, 0, 0);
        private static TimeSpan OverTimeEnd { get; set; } = new TimeSpan(0, 0, 0, 0);
        private static int OverTimeStartBuffer { get; set; } = 0;
        private static int OverTimeEndBuffer { get; set; } = 0;
        private static decimal LunchTimeSpan { get; set; } = 0;
        private static TimeSpan LunchTimeStart { get; set; } = new TimeSpan(0, 0, 0, 0);
        private static TimeSpan LunchTimeEnd { get; set; } = new TimeSpan(0, 0, 0, 0);
        private static int LunchTimeStartBuffer { get; set; } = 0;
        private static int LunchTimeEndBuffer { get; set; } = 0;
        private static int BreakTimeSpan { get; set; } = 0; //total
        private static TimeSpan BreakTimeCalcStart { get; set; } = new TimeSpan(0, 0, 0, 0);
        private static TimeSpan BreakTimeCalcEnd { get; set; } = new TimeSpan(0, 0, 0, 0);
        private static int BreakTimeAllowance { get; set; } = 0;
        private static bool IsAutoCalcMissing { get; set; } = false;
        private static int MissingWorkOn { get; set; } = (int)CalcMissingMode.NO_CALC;
        private static int MissingWorkOff { get; set; } = (int)CalcMissingMode.NO_CALC;
        private static int MissingLunchStart { get; set; } = (int)CalcMissingMode.NO_CALC;
        private static int MissingLunchEnd { get; set; } = (int)CalcMissingMode.NO_CALC;
        private static int MissingOverTimeStart { get; set; } = (int)CalcMissingMode.NO_CALC;
        private static int MissingOverTimeEnd { get; set; } = (int)CalcMissingMode.NO_CALC;
        private static DateTime UpdatedDate { get; set; } = DateTime.Now;
        private static DateTime CreatedDate { get; set; } = DateTime.Now;
        private static string OperatedUserName { get; set; }
        private static bool IsApproved { get; set; } = false;
        #endregion
        // for default value
        public static Shift CreateNewButBasic(Shift shift)
        {
            shift.DepartmentIdArr = DepartmentIdArr;
            shift.CompanyName = CompanyName;
            shift.WorkTimeSpan = WorkTimeSpan;
            shift.WorkStart = WorkStart;
            shift.WorkEnd = WorkEnd;
            shift.WorkStartBuffer = WorkStartBuffer;
            shift.WorkEndBuffer = WorkEndBuffer;
            shift.SpecialWeekDays = SpecialWeekDays;
            shift.SpecialWeekDaysWorkStart = SpecialWeekDaysWorkStart;
            shift.SpecialWeekDaysWorkEnd = SpecialWeekDaysWorkEnd;
            shift.ExcludeWeekDay = ExcludeWeekDay;
            shift.ExcludeOverTime = ExcludeOverTime;
            shift.OverTimeSpan = OverTimeSpan;
            shift.OverTimeStart = OverTimeStart;
            shift.OverTimeEnd = OverTimeEnd;
            shift.OverTimeStartBuffer = OverTimeStartBuffer;
            shift.OverTimeEndBuffer = OverTimeEndBuffer;
            shift.LunchTimeSpan = LunchTimeSpan;
            shift.LunchTimeStart = LunchTimeStart;
            shift.LunchTimeEnd = LunchTimeEnd;
            shift.LunchTimeStartBuffer = LunchTimeStartBuffer;
            shift.LunchTimeEndBuffer = LunchTimeEndBuffer;
            shift.BreakTimeSpan = BreakTimeSpan;
            shift.BreakTimeCalcStart = BreakTimeCalcStart;
            shift.BreakTimeCalcEnd = BreakTimeCalcEnd;
            shift.BreakTimeAllowance = BreakTimeAllowance;
            shift.IsAutoCalcMissing = IsAutoCalcMissing;
            shift.MissingWorkOn = MissingWorkOn;
            shift.MissingWorkOff = MissingWorkOff;
            shift.MissingLunchStart = MissingLunchStart;
            shift.MissingLunchEnd = MissingLunchEnd;
            shift.MissingOverTimeStart = MissingOverTimeStart;
            shift.MissingOverTimeEnd = MissingOverTimeEnd;
            shift.UpdatedDate = UpdatedDate;
            shift.CreatedDate = CreatedDate;
            shift.OperatedUserName = OperatedUserName;
            shift.IsApproved = IsApproved;
            return shift;
        }
    }
}
