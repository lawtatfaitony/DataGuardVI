using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class Schedule
    {
        public string ScheduleId { get; set; }
        public string MainComId { get; set; }
        public string IdOfMonthlyShiftEmploy { get; set; }
        public string ShiftId { get; set; }
        public string ShiftAbbrId { get; set; }
        public string EmployeeId { get; set; }
        public DateTime ScheduleDate { get; set; }
        public int ShiftAssignedMode { get; set; }
        public TimeSpan WorkStart { get; set; }
        public TimeSpan WorkEnd { get; set; }
        public bool OnDataLocked { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime SysCalcDateTime { get; set; }
    }
}
