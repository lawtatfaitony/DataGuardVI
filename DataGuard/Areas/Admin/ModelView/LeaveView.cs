using LanguageResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static AttendanceBussiness.ShiftBusiness;
namespace DataGuard.Areas
{
    public class LeaveListView
    {
        public LeaveView LeaveView { get; set; }
        public IEnumerable<AttendanceBussiness.DbFirst.Leave> LeaveList { get; set; }
    }
    public class LeaveView
    {
        public string LeaveId { get; set; }
        [Required(ErrorMessageResourceName = "LeaveView_LeaveType_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public LeaveType LeaveType { get; set; }
        [Required(ErrorMessageResourceName = "LeaveView_EmployeeId_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        [Required(ErrorMessageResourceName = "LeaveView_LeaveDateTimeRange_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public string LeaveDateTimeRange { get; set; }

        public string MainComId { get; set; }
        public decimal TotalDays { get; set; }
        public string Reason { get; set; }
        public bool IsApproved { get; set; }
        public string ApplovedBy { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required(ErrorMessageResourceName = "LeaveView_LeavePaidType_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public LeavePaidType LeavePaidType { get; set; }
    }
}