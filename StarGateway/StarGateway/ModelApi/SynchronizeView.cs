using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarGateway.ModelApi
{
    public class SynchronizeView
    {
        public string The3rdPartyEmployeeId { get; set; } = string.Empty;
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
