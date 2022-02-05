using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class Department
    {
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string EnDepartmentName { get; set; }
        public string DepartmentAbbrName { get; set; }
        public string MainComId { get; set; }
        public string CompanyName { get; set; }
        public string IndustryId { get; set; }
    }
}
