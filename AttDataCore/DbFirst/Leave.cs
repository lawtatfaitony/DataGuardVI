using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class Leave
    {
        public string LeaveId { get; set; }
        public int LeaveType { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime LeaveStartDate { get; set; }
        public DateTime LeaveEndDate { get; set; }
        public string MainComId { get; set; }
        public decimal TotalDays { get; set; }
        public string Reason { get; set; }
        public bool IsApproved { get; set; }
        public string ApprovedRemarks { get; set; }
        public string ApplovedBy { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LeavePaidType { get; set; }
    }
}
