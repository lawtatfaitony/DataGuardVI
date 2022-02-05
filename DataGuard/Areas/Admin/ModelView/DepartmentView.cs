using LanguageResource;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataGuard.Areas
{
    public class DepartmentNew
    {
        public string DepartmentId { get; set; }
        [Required(ErrorMessageResourceName = "DepartmentView_DepartmentName_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public string DepartmentName { get; set; }
        public string EnDepartmentName { get; set; }
        public string DepartmentAbbrName { get; set; } 

    }
    public class DepartmentListView
    {
        public DepartmentNew DepartmentNew { get; set; }
        public IEnumerable<AttendanceBussiness.DbFirst.Department> DepartmentList { get; set; }
    }
}