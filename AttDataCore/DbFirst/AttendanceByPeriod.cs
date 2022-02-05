using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class AttendanceByPeriod
    {
        public string AttendanceByPeriodId { get; set; }
        public string MainComId { get; set; }
        public int Mode { get; set; }
        public string ObjectData { get; set; }
        public string ShiftNameStructure { get; set; }
        public int CalcPeriodType { get; set; }
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
        public long AvgWorkActualNetTimeSpan { get; set; }
        public long AccuWorkActualNetTimeSpan { get; set; }
        public long AvgWorkTimeSpan { get; set; }
        public long AccuWorkTimeSpan { get; set; }
        public long AvgLunchTimeSpan { get; set; }
        public long AccuLunchTimeSpan { get; set; }
        public long AvgOverTimeSpan { get; set; }
        public long AccuOverTimeSpan { get; set; }
        public decimal AccuLeaveDays { get; set; }
        public decimal AccuHolidays { get; set; }
        public decimal AccuWorkDays { get; set; }
        public decimal AccuAbsentDays { get; set; }
        public int AccuTimesOfLateIn { get; set; }
        public long AccuLateInTimeSpan { get; set; }
        public int AccuTimesOfEarlyOut { get; set; }
        public long AccuEarlyOutTimeSpan { get; set; }
        public int AccuTimesOfLunchLateIn { get; set; }
        public long AccuLunchLateInTimeSpan { get; set; }
        public int AccuTimesOfLunchEarlyOut { get; set; }
        public long AccuEarlyLunchOutTimeSpan { get; set; }
        public int AccuTimesOfOverTimeLateIn { get; set; }
        public long AccuOverTimeLateInTimeSpan { get; set; }
        public int AccuTimesOfOverTimeEarlyOut { get; set; }
        public long AccuEarlyOverTimeOutTimeSpan { get; set; }
        public int AccuTimesOfRegular { get; set; }
        public int AccuTimesOfRegularWorkOn { get; set; }
        public int AccuTimesOfRegularWorkOff { get; set; }
        public int AccuTimesOfRegularLunchStart { get; set; }
        public int AccuTimesOfRegularLunchEnd { get; set; }
        public int AccuTimesOfRegularOverTimeStart { get; set; }
        public int AccuTimesOfRegularOverTimeEnd { get; set; }
        public int AccuTimesOfMissing { get; set; }
        public int AccuTimesOfMissingWorkOn { get; set; }
        public int AccuTimesOfMissingWorkOff { get; set; }
        public int AccuTimesOfMissingLunchStart { get; set; }
        public int AccuTimesOfMissingLunchEnd { get; set; }
        public int AccuTimesOfMissingOverTimeStart { get; set; }
        public int AccuTimesOfMissingOverTimeEnd { get; set; }
        public decimal AvgOnDutyWorkRatio { get; set; }
        public decimal AvgOnDutyPaidRatio { get; set; }
        public bool OnDataLocked { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime SysCalcDateTime { get; set; }
        public string HmacHash { get; set; }
    }
}
