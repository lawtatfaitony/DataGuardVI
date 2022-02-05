using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class UserTrace
    {
        public string UserTraceId { get; set; }
        public string TableKeyId { get; set; }
        public string UserId { get; set; }
        public string MainComId { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime OperatedDate { get; set; }
    }
}
