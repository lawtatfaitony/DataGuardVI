using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class TaskJob
    {
        public string TaskJobId { get; set; }
        public string MainComId { get; set; }
        public int CalcPeriodType { get; set; }
        public string TableName { get; set; }
        public string TargetTalbeKeyId { get; set; }
        public DateTime TriggerDateTime { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedDatetime { get; set; }
        public bool OnDataLocked { get; set; }
    }
}
