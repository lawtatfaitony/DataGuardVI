using AttendanceBussiness.DbFirst;
using System.Collections.Generic;

namespace DataGuard.Areas
{
    public class JobListView
    {
        public Job JobNew { get; set; }
        public IEnumerable<AttendanceBussiness.DbFirst.Job> JobList { get; set; }
    }
}