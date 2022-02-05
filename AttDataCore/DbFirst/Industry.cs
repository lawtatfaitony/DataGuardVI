using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class Industry
    {
        public string IndustryId { get; set; }
        public string IndustryName { get; set; }
        public string EnIndustryName { get; set; }
        public int ParentsIndustryId { get; set; }
    }
}
