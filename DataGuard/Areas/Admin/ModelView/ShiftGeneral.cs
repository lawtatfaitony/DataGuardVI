using AttendanceBussiness.DbFirst;
using LanguageResource;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static AttendanceBussiness.ShiftBusiness;

namespace DataGuard.Areas
{
    public class ShiftGeneralView
    {
        public string ShiftId { get; set; }

        [RegularExpression(@"^[\u4e00-\u9fa5]{1,2}$|^[A-Z]{1,4}$|^[a-z]{1,4}$", ErrorMessageResourceName = "Shift_ShiftAbbrId_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public string ShiftAbbrId { get; set; }
        public string IconColor { get; set; } = "#fc0366";
        [Required(ErrorMessageResourceName = "Shift_ShiftName_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public string ShiftName { get; set; }
        public ShiftBusinessMode ShiftBusinessMode { get; set; }
        public ShiftAppliedMode ShiftAppliedMode { get; set; }

        public string MainComId { get; set; }
        public string CompanyName { get; set; }
        [Required(ErrorMessageResourceName = "Shift_WorkStart_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        public TimeSpan WorkStart { get; set; }
        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        [Required(ErrorMessageResourceName = "Shift_WorkEnd_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public TimeSpan WorkEnd { get; set; }
        [Required(ErrorMessageResourceName = "Shift_WorkStartAllowance_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public int WorkStartAllowance { get; set; }
        [Required(ErrorMessageResourceName = "Shift_WorkEndAllowance_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public int WorkEndAllowance { get; set; }
        [Required(ErrorMessageResourceName = "Shift_WorkStartBuffer_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public int WorkStartBuffer { get; set; }
        [Required(ErrorMessageResourceName = "Shift_WorkEndBuffer_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public int WorkEndBuffer { get; set; }
        public string[] SpecialWeekDays { get; set; }
        public TimeSpan SpecialWeekDaysWorkStart { get; set; }
        public TimeSpan SpecialWeekDaysWorkEnd { get; set; }
        public bool IsAutoCalcMissing { get; set; }

        public CalcMissingMode MissingWorkOn { get; set; } = CalcMissingMode.AUTO_MISSING;
        public CalcMissingMode MissingWorkOff { get; set; } = CalcMissingMode.AUTO_MISSING;
        public CalcMissingMode MissingLunchStart { get; set; } = CalcMissingMode.AUTO_MISSING;
        public CalcMissingMode MissingLunchEnd { get; set; } = CalcMissingMode.AUTO_MISSING;
        public CalcMissingMode MissingOverTimeStart { get; set; } = CalcMissingMode.AUTO_MISSING;
        public CalcMissingMode MissingOverTimeEnd { get; set; } = CalcMissingMode.AUTO_MISSING;

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [RegularExpression(@"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$", ErrorMessageResourceName = "GeneralUI_Date", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public DateTime AppliedStartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", NullDisplayText = "1900-01-01")]
        [RegularExpression(@"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$", ErrorMessageResourceName = "GeneralUI_Date", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public DateTime AppliedEndDate { get; set; }
        public string RuleDescription { get; set; }

        [DefaultValue(false)]
        public bool IsApproved { get; set; }
    }
    public class ShiftOverTimeView
    {
        public string ShiftId { get; set; }

        [RegularExpression(@"^[\u4e00-\u9fa5]{1,2}$|^[A-Z]{1,4}$|^[a-z]{1,4}$", ErrorMessageResourceName = "Shift_ShiftAbbrId_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public string ShiftAbbrId { get; set; }

        [Required(ErrorMessageResourceName = "Shift_ShiftName_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public string ShiftName { get; set; }
        public ShiftBusinessMode ShiftBusinessMode { get; set; }
        public ShiftAppliedMode ShiftAppliedMode { get; set; }

        public int ShiftAppliedModeInt { get; set; }
        public string MainComId { get; set; }
        public string CompanyName { get; set; }
        [Required(ErrorMessageResourceName = "Shift_WorkStart_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        public TimeSpan WorkStart { get; set; }
        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        [Required(ErrorMessageResourceName = "Shift_WorkEnd_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public TimeSpan WorkEnd { get; set; }
        [Required(ErrorMessageResourceName = "Shift_WorkStartAllowance_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public int WorkStartAllowance { get; set; }
        [Required(ErrorMessageResourceName = "Shift_WorkEndAllowance_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public int WorkEndAllowance { get; set; }
        [Required(ErrorMessageResourceName = "Shift_WorkStartBuffer_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public int WorkStartBuffer { get; set; }
        [Required(ErrorMessageResourceName = "Shift_WorkEndBuffer_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public int WorkEndBuffer { get; set; }
        public string[] SpecialWeekDays { get; set; }
        public TimeSpan SpecialWeekDaysWorkStart { get; set; }
        public TimeSpan SpecialWeekDaysWorkEnd { get; set; }

        public decimal OverTimeSpan { get; set; }
        public TimeSpan OverTimeStart { get; set; }
        public TimeSpan OverTimeEnd { get; set; }
        public int OverTimeStartBuffer { get; set; }
        public int OverTimeEndBuffer { get; set; }

        public bool IsAutoCalcMissing { get; set; }

        public CalcMissingMode MissingWorkOn { get; set; }
        public CalcMissingMode MissingWorkOff { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [RegularExpression(@"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$", ErrorMessageResourceName = "GeneralUI_Date", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public DateTime AppliedStartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", NullDisplayText = "1900-01-01")]
        [RegularExpression(@"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$", ErrorMessageResourceName = "GeneralUI_Date", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public DateTime AppliedEndDate { get; set; }
        public string RuleDescription { get; set; }
    }
    public class ShiftExcludeWeekDayView
    {
        public string ShiftId { get; set; }

        [Required(ErrorMessageResourceName = "Shift_ShiftAbbrId_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public string ShiftAbbrId { get; set; }

        public string IconColor { get; set; }

        [Required(ErrorMessageResourceName = "Shift_ShiftName_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public string ShiftName { get; set; }
        public ShiftBusinessMode ShiftBusinessMode { get; set; }
        public ShiftAppliedMode ShiftAppliedMode { get; set; }

        public int ShiftAppliedModeInt { get; set; }
        public string MainComId { get; set; }
        public string CompanyName { get; set; }
        [Required(ErrorMessageResourceName = "Shift_WorkStart_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        public TimeSpan WorkStart { get; set; }
        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        [Required(ErrorMessageResourceName = "Shift_WorkEnd_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public TimeSpan WorkEnd { get; set; }
        [Required(ErrorMessageResourceName = "Shift_WorkStartAllowance_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public int WorkStartAllowance { get; set; }
        [Required(ErrorMessageResourceName = "Shift_WorkEndAllowance_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public int WorkEndAllowance { get; set; }
        [Required(ErrorMessageResourceName = "Shift_WorkStartBuffer_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public int WorkStartBuffer { get; set; }
        [Required(ErrorMessageResourceName = "Shift_WorkEndBuffer_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public int WorkEndBuffer { get; set; }
        public string[] SpecialWeekDays { get; set; }
        public TimeSpan SpecialWeekDaysWorkStart { get; set; }
        public TimeSpan SpecialWeekDaysWorkEnd { get; set; }
        public string[] ExcludeWeekDay { get; set; }
        public bool IsAutoCalcMissing { get; set; }

        public CalcMissingMode MissingWorkOn { get; set; }
        public CalcMissingMode MissingWorkOff { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [RegularExpression(@"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$", ErrorMessageResourceName = "GeneralUI_Date", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public DateTime AppliedStartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", NullDisplayText = "1900-01-01")]
        [RegularExpression(@"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$", ErrorMessageResourceName = "GeneralUI_Date", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public DateTime AppliedEndDate { get; set; }
        public string RuleDescription { get; set; }
    }
    public class ShiftGeneralLunchView
    {
        public string ShiftId { get; set; }

        [Required(ErrorMessageResourceName = "Shift_ShiftAbbrId_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public string ShiftAbbrId { get; set; }

        [Required(ErrorMessageResourceName = "Shift_ShiftName_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]

        public string ShiftName { get; set; }
        public string IconColor { get; set; }
        public ShiftBusinessMode ShiftBusinessMode { get; set; }
        public ShiftAppliedMode ShiftAppliedMode { get; set; }
        public string MainComId { get; set; }
        public string CompanyName { get; set; }
        [Required(ErrorMessageResourceName = "Shift_WorkStart_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        public TimeSpan WorkStart { get; set; }
        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        [Required(ErrorMessageResourceName = "Shift_WorkEnd_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public TimeSpan WorkEnd { get; set; }
        [Required(ErrorMessageResourceName = "Shift_WorkStartAllowance_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public int WorkStartAllowance { get; set; }
        [Required(ErrorMessageResourceName = "Shift_WorkEndAllowance_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public int WorkEndAllowance { get; set; }
        [Required(ErrorMessageResourceName = "Shift_WorkStartBuffer_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public int WorkStartBuffer { get; set; }
        [Required(ErrorMessageResourceName = "Shift_WorkEndBuffer_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public int WorkEndBuffer { get; set; }
        public string[] SpecialWeekDays { get; set; }
        public TimeSpan SpecialWeekDaysWorkStart { get; set; }
        public TimeSpan SpecialWeekDaysWorkEnd { get; set; }
        //Lunch----------------------------
        public decimal LunchTimeSpan { get; set; }
        public TimeSpan LunchTimeStart { get; set; }
        public TimeSpan LunchTimeEnd { get; set; }
        public int LunchTimeStartBuffer { get; set; }
        public int LunchTimeEndBuffer { get; set; }

        public bool IsAutoCalcMissing { get; set; }
        public CalcMissingMode MissingWorkOn { get; set; }
        public CalcMissingMode MissingWorkOff { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [RegularExpression(@"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$", ErrorMessageResourceName = "GeneralUI_Date", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public DateTime AppliedStartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", NullDisplayText = "1900-01-01")]
        [RegularExpression(@"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$", ErrorMessageResourceName = "GeneralUI_Date", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public DateTime AppliedEndDate { get; set; }
        public string RuleDescription { get; set; }
    }

    public class EmployeeView : Employee
    {
        public bool SynchronizeDeviceUser;
    }
    public class AssignedShiftAppliedMode
    {
        public int ShiftAppliedMode { get; set; }
        public string Name { get; set; }
        public bool Assigned { get; set; }
    }
}