using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AttendanceBussiness.DbFirst
{
    public partial class SalAssessment
    {
        [Key]
        public string SalAssessmentId { get; set; }
        public string EmployeeId  { get; set; }
        public string EmployeeFunllName { get; set; }
        public decimal SalaryAssessmentValue { get; set; }
        public string FormulaOfAssessment { get; set; }
        public string ApprovedBy { get; set; }
        public int ApprovedStatus { get; set; }
        public string CreatedUser { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string OperatedUser { get; set; }
        public DateTime OperateDateTime { get; set; }
        public string MainComId { get; set; }
        public int SettlePeriodMode { get; set; } 
    }
}
