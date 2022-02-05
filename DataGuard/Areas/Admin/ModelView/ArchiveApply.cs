using System;

namespace DataGuard.Areas.Admin.ModelView
{
    public class ArchiveApprove
    {
        public string EmployeeId { get; set; }
        public DateTime LeaveDate { get; set; }

    }
    public class BanApprove
    {
        public string EmployeeId { get; set; }
        public bool IsBlock { get; set; }

    }
}