using AttendanceBussiness.DbFirst;
using System.Collections.Generic;

namespace DataGuard.Areas
{
    public class ContractorListView
    {
        public ContractorNew ContractorNew { get; set; }
        public IEnumerable<AttendanceBussiness.DbFirst.Contractor> ContractorList { get; set; }
    }
    public class ContractorNew : Contractor
    {
        public string SetServiceDateRange { get; set; }
    }
}