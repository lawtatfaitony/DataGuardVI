using System.ComponentModel;
using static AttendanceBussiness.ShiftBusiness;

namespace DataGuard.Areas
{
    public class SynchronizeView
    {
        [DefaultValue(SynchronizeMode.CNNAME)]
        public SynchronizeMode synchronizeMode { get; set; }
        public string The3rdPartyEmployeeId { get; set; } = string.Empty;
        public virtual string FullName => string.Format("{0} {1} {2}", CnName, LastName, FirstName).Trim();
        public string CnName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string IdNumber { get; set; }
        public string AccessCardId { get; set; }
        public string ContractorId { get; set; }
        public string SiteId { get; set; }
        public string DepartmentId { get; set; }
        public string JobId { get; set; }
        public string PositionId { get; set; }
    }
}