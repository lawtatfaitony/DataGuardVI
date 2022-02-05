using AttEnumCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AttApiViewModal.SalaryBusiness
{
    public class SalAssessment
    {
        public string EmployeeId { get; set; }

        [Required]
        public string FullName { get; set; }

        public bool IsTempAssessment { get; set; }
         
        public int SettlePeriodMode { get; set; }

        [DefaultValue(100000)]
        public decimal SalaryMaxValue { get; set; }

        [DefaultValue(999999)]
        public decimal SalaryAssessmentValue { get; set; }

        [DefaultValue(100)]
        public int Ability { get; set; }
        
        [DefaultValue(100)]
        public int Education { get; set; }
        [DefaultValue(100)]
        public int Marriage { get; set; }
        [DefaultValue(100)]
        public int Family { get; set; }
        [DefaultValue(100)]
        public int Qualifications { get; set; }
        [DefaultValue(100)]
        public int Experience { get; set; }
        [DefaultValue(100)]
        public int IndustryReputation { get; set; }
        [DefaultValue(100)]
        public int IndustryEthics { get; set; }

        public string MainComId { get; set; }
    }
   
    public enum SettlePeriodMode
    {
        [EnumDisplayName("SettlePeriodMode_Hour")]
        HOUR = 0,
        [EnumDisplayName("SettlePeriodMode_Day")]
        DAY = 1,
        [EnumDisplayName("SettlePeriodMode_Week")]
        Week = 2,
        [EnumDisplayName("SettlePeriodMode_Month")]
        MONTH = 3,
        [EnumDisplayName("SettlePeriodMode_Year")]
        YEAR = 4,
    }

    /// <summary>
    /// SalAssessmentId, ApprovedStatus, MainComId
    /// </summary>
    public class SalAssessmentApproved
    {
        public string SalAssessmentId { get; set; }
        public int ApprovedStatus { get; set; }
        public string MainComId { get; set; }
    }

    public class SalAssessmentDel
    {
        public string SalAssessmentId { get; set; } 
        public string MainComId { get; set; }
    }
}
