using AttendanceBussiness.DbFirst;
using System.Collections.Generic;

namespace DataGuard.Areas
{
    public class PositionListView
    {
        public Position PositionNew { get; set; }
        public IEnumerable<AttendanceBussiness.DbFirst.Position> PositionList { get; set; }
    }
}