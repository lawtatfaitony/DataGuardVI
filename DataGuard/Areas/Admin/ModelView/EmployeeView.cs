using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static AttendanceBussiness.ShiftBusiness;

namespace DataGuard.Areas
{
    public class EmployeeModel
    {
        public EmployeeStep1 EmployeeStep1 { get; set; }
        public EmployeeStep2 EmployeeStep2 { get; set; }
        public EmployeeStep3 EmployeeStep3 { get; set; }
        public EmployeeStep4 EmployeeStep4 { get; set; }
        public IEnumerable<AttendanceBussiness.DbFirst.Employee> EmployeeList { get; set; }
    }
    public class EmployeeStep1
    {
        private static DateTime _EnrollmentDate;
        private static DateTime _LeaveDate;
        public string EmployeeId { get; set; }
        [Required]
        public virtual string FullName => string.Format("{0} {1} {2}", CnName, LastName, FirstName).Trim();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CnName { get; set; }
        public int Gender { get; set; } = 3;
        public DateTime Birthday { get; set; } = new DateTime(1970, 1, 1, 0, 0, 0);
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime EnrollmentDate
        {
            get
            {
                return _EnrollmentDate;
            }
            set
            {
                _EnrollmentDate = value;
                _LeaveDate = value; //rule
            }
        }
        public string The3rdPartyEmployeeId { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string ParentUserId { get; set; } = string.Empty;
        public string MainComId { get; set; }
        public string CompanyName { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", NullDisplayText = "1970-01-01")]
        public DateTime LeaveDate
        {
            get
            {
                return _LeaveDate;
            }
            set
            {
                _LeaveDate = value;
            }
        }
        public string Remarks { get; set; } = string.Empty;
        public string OperatedUserName { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", NullDisplayText = "1970-01-01")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", NullDisplayText = "1970-01-01")]
        public DateTime OperatedDate { get; set; } = DateTime.Now;
        public bool IsBlock { get; set; } = false;
    }
    public class EmployeeStep2
    {
        public string EmployeeId { get; set; }
        public string FullName { get; set; }
        public string UserIcon1 { get; set; }
        public string UserIcon2 { get; set; }
        public string UserIcon3 { get; set; }
        public string AccessCardId { get; set; }
        public string FingerPrint { get; set; }
    }
    public class EmployeeStep3
    {
        public string EmployeeId { get; set; }
        public string FullName { get; set; }
        public string ContractorId { get; set; }
        public string SiteId { get; set; }
        public string DepartmentId { get; set; }
        public string JobId { get; set; }
        public string PositionId { get; set; }
    }
    public class EmployeeStep4
    {
        public string EmployeeId { get; set; }
        public string FullName { get; set; }
        public Genders Gender { get; set; }
        public string IdNumber { get; set; }
        public DateTime Birthday { get; set; } = new DateTime(1970, 1, 1, 0, 0, 0);
    }
}