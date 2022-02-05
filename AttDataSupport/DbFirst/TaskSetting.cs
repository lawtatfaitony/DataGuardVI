using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class TaskSetting
    {
        public string TaskSettingId { get; set; }
        public int CalcPeriodType { get; set; }
        public int CalcPeriodSpan { get; set; }
        public TimeSpan TaskRuningStartTime { get; set; }
        public TimeSpan TaskRuningEndTime { get; set; }
        public int TimesOfTaskRunning { get; set; }
        public DateTime TaskStartDate { get; set; }
        public string TaskRemarks { get; set; }
    }
}
