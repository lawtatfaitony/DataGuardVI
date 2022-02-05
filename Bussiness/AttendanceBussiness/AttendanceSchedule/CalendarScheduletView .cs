using LanguageResource;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static AttendanceBussiness.ShiftBusiness;

namespace AttendanceBussiness.AttendanceSchedule
{
    public class EmployeeModal
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string MainComId { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public DateTime DefaultDate { get; set; }
    }
    public class ClendarScheduleModal
    {
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string GroupId { get; set; }
        public string Constraint { get; set; }
        public string Color { get; set; }
    }
    public class CalendarScheduleView
    {
        public EmployeeModal EmployeeModal { get; set; }
        public IEnumerable<ClendarScheduleModal> ClendarScheduleList { get; set; }
    }
}