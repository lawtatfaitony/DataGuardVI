using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class AttendanceByDay
    {
        public string AttendanceByDayId { get; set; }
        public string MainComId { get; set; }
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
        public string DayShiftNameList { get; set; }
        public string DayShiftListJson { get; set; }
        public TimeSpan DayTotalWorkTimeSpan { get; set; }
        public TimeSpan DayTotalWorkNetTimeSpan { get; set; }
        public TimeSpan DayTotalLunchTimeSpan { get; set; }
        public TimeSpan DayTotalOverTimeSpan { get; set; }
        public int DayLateInTimeSpan { get; set; }
        public int DayIsLateTimez { get; set; }
        public int DayEarlyOutTimeSpan { get; set; }
        public int DayIsEarlyTimez { get; set; }
        public int DayLunchLateInTimeSpan { get; set; }
        public int DayLunchIsLateTimez { get; set; }
        public int DayLunchEarlyOutTimeSpan { get; set; }
        public int DayLunchIsEarlyTimez { get; set; }
        public int DayOverTimeLateInTimeSpan { get; set; }
        public int DayOverTimeIsLateTimez { get; set; }
        public int DayOverTimeEarlyOutTimeSpan { get; set; }
        public int DayOverTimeIsEarlyTimez { get; set; }
        public int DayMissingWorkOnTimez { get; set; }
        public int DayMissingWorkOffTimez { get; set; }
        public int DayMissingLunchStartTimez { get; set; }
        public int DayMissingLunchEndTimez { get; set; }
        public int DayMissingOverTimeStartTimez { get; set; }
        public int DayMissingOverTimeEndTimez { get; set; }
        public int TotalTimesOfRegularWorkOn { get; set; }
        public int TotalTimesOfRegularWorkOff { get; set; }
        public int TotalTimesOfRegularLunchStart { get; set; }
        public int TotalTimesOfRegularLunchEnd { get; set; }
        public int TotalTimesOfRegularOverTimeStart { get; set; }
        public int TotalTimesOfRegularOverTimeEnd { get; set; }
        public string LeaveId { get; set; }
        public int LeaveType { get; set; }
        public string LeaveTypeName { get; set; }
        public int LeavePaidType { get; set; }
        public string LeavePaidTypeName { get; set; }
        public decimal LeaveWithPaidRatio { get; set; }
        public string HolidayId { get; set; }
        public string HolidayName { get; set; }
        public int HolidayPaidType { get; set; }
        public string HolidayPaidTypeName { get; set; }
        public decimal? HolidayWithPaidRatio { get; set; }
        public decimal OnDutyWorkRatioAvg { get; set; }
        public decimal OnDutyPaidRatioAvg { get; set; }
        public int CalcPeriodType { get; set; }
        public bool OnDataLocked { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime SysCalcDateTime { get; set; }
        public DateTime OccurDate { get; set; }
        public string HmacHash { get; set; }
    }
}
