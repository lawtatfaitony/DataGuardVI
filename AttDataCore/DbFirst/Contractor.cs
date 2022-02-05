using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class Contractor
    {
        public string ContractorId { get; set; }
        public string ContractorName { get; set; }
        public string MainComId { get; set; }
        public string CompanyName { get; set; }
        public string ContractorNo { get; set; }
        public string IndustryId { get; set; }
        public string IndustryName { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string CompanyTel { get; set; }
        public string CompanyFax { get; set; }
        public string CompanyNameLogo { get; set; }
        public DateTime ServiceStartDate { get; set; }
        public DateTime ServiceEndDate { get; set; }
        public string CompanyAddress { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime OperatedDate { get; set; }
    }
}
