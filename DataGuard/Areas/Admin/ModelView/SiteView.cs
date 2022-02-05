using AttendanceBussiness.DbFirst;
using LanguageResource;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataGuard.Areas
{
    public class SiteListView
    {
        public Site SiteNew { get; set; }
        public IEnumerable<AttendanceBussiness.DbFirst.Site> SiteList { get; set; }
    }
    public class SiteView
    {
        public string SiteId { get; set; }
        [Required(ErrorMessageResourceName = "SiteView_SiteName_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public string SiteName { get; set; }
        public string MainComId { get; set; }
        [Required(ErrorMessageResourceName = "SiteView_SiteAddress_Required", ErrorMessageResourceType = typeof(ResourceLocalize))]
        public string SiteAddress { get; set; }

    }
}