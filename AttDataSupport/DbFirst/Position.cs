using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class Position
    {
        public string PositionId { get; set; }
        public string ParentsNodeId { get; set; }
        public string IndustryId { get; set; }
        public string IndustryName { get; set; }
        public string PositionTitle { get; set; }
        public string EnPositionTitle { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
