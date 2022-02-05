using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class Employee
    {
        public string EmployeeId { get; set; }
        public string The3rdPartyEmployeeId { get; set; }
        public string UserId { get; set; }
        public string ParentUserId { get; set; }
        public string UserIcon { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CnName { get; set; }
        public int Gender { get; set; }
        public string IdNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string MainComId { get; set; }
        public string CompanyName { get; set; }
        public string ContractorId { get; set; }
        public string ContractorName { get; set; }
        public string SiteId { get; set; }
        public string SiteName { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string JobId { get; set; }
        public string JobName { get; set; }
        public string PositionId { get; set; }
        public string PositionTitle { get; set; }
        public string AccessCardId { get; set; }
        public string FingerPrint { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public DateTime LeaveDate { get; set; }
        public string Remarks { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime OperatedDate { get; set; }
        public bool IsBlock { get; set; }
    }
}
