using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class EventLog
    {
        public string EventLogId { get; set; }
        public string OperateLogContent { get; set; }
        public string MessageIfException { get; set; }
        public DateTime? OperateDatetime { get; set; }
        public string OperateUserName { get; set; }
        public DateTime? EventDatetime { get; set; }
        public string MainComId { get; set; }
    }
}
