using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class DefinitedPeriod
    {
        public string DefinitedPeriodId { get; set; }
        public string DefinitedPeriodName { get; set; }
        public DateTime PeriodStartDate { get; set; }
        public DateTime PeriodEndDate { get; set; }
        public DateTime OperatedUserName { get; set; }
        public string MainComId { get; set; }
    }
}
