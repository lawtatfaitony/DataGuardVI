using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class TableIdentity
    {
        public string TableName { get; set; }
        public int TableIdentityId { get; set; }
        public DateTime OperatedDate { get; set; }
    }
}
