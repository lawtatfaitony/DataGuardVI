using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceBussiness.LeaveBusiness
{
    public partial class LeaveBusinessView
    {
        public string LeaveId { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeIcon { get; set; }
        public string LeaveTypeName { get; set; }
        public int LeavePaidType { get; set; } = 0;
        public string LeavePaidTypeName { get; set; }
        public string LeaveDateTimeRange { get; set; }
        public decimal TotalDays { get; set; }
        public string Reason { get; set; }
        public bool IsApproved { get; set; }
        public string ApplovedBy { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string MainComId { get; set; }
    }
}
