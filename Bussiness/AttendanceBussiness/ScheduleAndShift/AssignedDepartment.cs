using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceBussiness.ScheduleBusiness
{
    public class AssignedDepartment
    {
        public string ShiftId { get; set; }
         
        public string DepartmentId { get; set; }
        
        public string DepartmentName { get; set; } 
        public bool Assigned { get; set; }
    }
}
