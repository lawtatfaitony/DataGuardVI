using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class Shift
    {
        public string ShiftId { get; set; }
        public string ShiftAbbrId { get; set; }
        public string IconColor { get; set; }
        public string ShiftName { get; set; }
        public int ShiftBusinessMode { get; set; }
        public int ShiftAppliedMode { get; set; }
        public string DepartmentIdArr { get; set; }
        public string MainComId { get; set; }
        public string CompanyName { get; set; }
        public decimal WorkTimeSpan { get; set; }
        public TimeSpan WorkStart { get; set; }
        public TimeSpan WorkEnd { get; set; }
        public int WorkStartAllowance { get; set; }
        public int WorkEndAllowance { get; set; }
        public int WorkStartBuffer { get; set; }
        public int WorkEndBuffer { get; set; }
        public string SpecialWeekDays { get; set; }
        public TimeSpan SpecialWeekDaysWorkStart { get; set; }
        public TimeSpan SpecialWeekDaysWorkEnd { get; set; }
        public string ExcludeWeekDay { get; set; }
        public string ExcludeOverTime { get; set; }
        public decimal OverTimeSpan { get; set; }
        public TimeSpan OverTimeStart { get; set; }
        public TimeSpan OverTimeEnd { get; set; }
        public int OverTimeStartBuffer { get; set; }
        public int OverTimeEndBuffer { get; set; }
        public decimal LunchTimeSpan { get; set; }
        public TimeSpan LunchTimeStart { get; set; }
        public TimeSpan LunchTimeEnd { get; set; }
        public int LunchTimeStartBuffer { get; set; }
        public int LunchTimeEndBuffer { get; set; }
        public int BreakTimeSpan { get; set; }
        public TimeSpan BreakTimeCalcStart { get; set; }
        public TimeSpan BreakTimeCalcEnd { get; set; }
        public int BreakTimeAllowance { get; set; }
        public bool IsAutoCalcMissing { get; set; }
        public int MissingWorkOn { get; set; }
        public int MissingWorkOff { get; set; }
        public int MissingLunchStart { get; set; }
        public int MissingLunchEnd { get; set; }
        public int MissingOverTimeStart { get; set; }
        public int MissingOverTimeEnd { get; set; }
        public DateTime AppliedStartDate { get; set; }
        public DateTime AppliedEndDate { get; set; }
        public string RuleDescription { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string OperatedUserName { get; set; }
        public bool IsApproved { get; set; }
    }
}
