using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class Department
    {
        public Department()
        { 
        }
        public virtual string DepartmentFullName => string.Format("{0} {1} {2}", DepartmentAbbrName, DepartmentName, EnDepartmentName).Trim();
    }
}
