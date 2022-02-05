using System.Collections.Generic;
using static AttendanceBussiness.ShiftBusiness;

namespace DataGuard.Areas
{
    public class LeaveListApprovedView
    {
        public LeaveApproved LeaveApprovedModal { get; set; }
        public IEnumerable<AttendanceBussiness.DbFirst.Leave> LeaveList { get; set; }
    }
    public class LeaveApproved
    {
        public string LeaveId { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public ApprovedMode IsApproved { get; set; }
        public string ApprovedRemarks { get; set; }
    }
}