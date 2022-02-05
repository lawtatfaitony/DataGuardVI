using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class AttendanceByShift
    {
        public string AttendanceByShiftId { get; set; }
        public string ObjData { get; set; }
        public string MainComId { get; set; }
        public string ShiftId { get; set; }
        public string ShiftAbbrId { get; set; }
        public string ShiftName { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string PositionId { get; set; }
        public string PositionTitle { get; set; }
        public string ContractorId { get; set; }
        public string ContractorName { get; set; }
        public string JobId { get; set; }
        public string JobName { get; set; }
        public string SiteId { get; set; }
        public string SiteName { get; set; }
        public bool IsWorkDay { get; set; }
        public bool IsAbsentDay { get; set; }
        public DateTime WorkStart { get; set; }
        public DateTime WorkEnd { get; set; }
        public int LateIn { get; set; }
        public int IsLate { get; set; }
        public int EarlyOut { get; set; }
        public int IsEarly { get; set; }
        public decimal WorkTimeSpan { get; set; }
        public decimal WorkActualNetTimeSpan { get; set; }
        public decimal OverTimeSpan { get; set; }
        public DateTime OverTimeStart { get; set; }
        public DateTime OverTimeEnd { get; set; }
        public int OverTimeLateIn { get; set; }
        public int OverTimeIsLate { get; set; }
        public int OverTimeEarlyOut { get; set; }
        public int OverTimeIsEarly { get; set; }
        public int BreakTimes { get; set; }
        public decimal BreakTimeTotalSpan { get; set; }
        public DateTime LunchTimeStart { get; set; }
        public DateTime LunchTimeEnd { get; set; }
        public decimal LunchTimeSpan { get; set; }
        public int LunchTimeLateIn { get; set; }
        public int LunchTimeIsLate { get; set; }
        public int LunchTimeEarlyOut { get; set; }
        public int LunchTimeIsEarly { get; set; }
        public bool IsAutoCalcMissing { get; set; }
        public bool IsRegularWorkOn { get; set; }
        public bool IsRegularWorkOff { get; set; }
        public bool IsRegularLunchStart { get; set; }
        public bool IsRegularLunchEnd { get; set; }
        public bool IsRegularOverTimeStart { get; set; }
        public bool IsRegularOverTimeEnd { get; set; }
        public int MissingWorkOn { get; set; }
        public int MissingWorkOff { get; set; }
        public int MissingLunchStart { get; set; }
        public int MissingLunchEnd { get; set; }
        public int MissingOverTimeStart { get; set; }
        public int MissingOverTimeEnd { get; set; }
        public string LeaveId { get; set; }
        public int LeaveType { get; set; }
        public string LeaveTypeName { get; set; }
        public int LeavePaidType { get; set; }
        public string LeavePaidTypeName { get; set; }
        public string HolidayId { get; set; }
        public string HolidayName { get; set; }
        public int HolidayPaidType { get; set; }
        public string HolidayPaidTypeName { get; set; }
        public decimal OnDutyWorkRatio { get; set; }
        public decimal OnDutyPaidRatio { get; set; }
        public int CalcPeriodType { get; set; }
        public bool OnDataLocked { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime SysCalcDateTime { get; set; }
        public string HmacHash { get; set; }
    }
}
