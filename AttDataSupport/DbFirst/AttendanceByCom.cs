using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class AttendanceByCom
    {
        public string AttendanceByComId { get; set; }
        public string MainComId { get; set; }
        public string ContractorId { get; set; }
        public string ContractorName { get; set; }
        public int TotalEmployeesInAttendance { get; set; }
        public int TotalActualNetWorkDay { get; set; }
        public int TotalTimesOfLateIn { get; set; }
        public int TotalTimesOfEarlyOut { get; set; }
        public int TotalTimesOfRegularWorkOn { get; set; }
        public int TotalTimesOfRegularWorkOff { get; set; }
        public int TotalAbsentDays { get; set; }
        public int TotalTimesOfMissing { get; set; }
        public int TotalTimesOfAttendance { get; set; }
        public int TotalTimesOfOverTime { get; set; }
        public int TotalTimesOfBreak { get; set; }
        public int CalcPeriodType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCompleted { get; set; }
        public bool OnDataLocked { get; set; }
        public DateTime? SysCalcDateTime { get; set; }
    }
}
