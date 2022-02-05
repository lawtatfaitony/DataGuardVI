using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class AttendanceLog
    {
        public long AttendanceLogId { get; set; }
        public int Mode { get; set; }
        public string ObjData { get; set; }
        public string DeviceId { get; set; }
        public string DeviceName { get; set; }
        public int DeviceEntryMode { get; set; }
        public string EmployeeId { get; set; }
        public string AccesscardId { get; set; }
        public string CnName { get; set; }
        public long OccurDateTime { get; set; }
        public string CatchPictureFileName { get; set; }
        public string CompanyName { get; set; }
        public string ContractorId { get; set; }
        public string ContractorName { get; set; }
        public string SiteId { get; set; }
        public string SiteName { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string JobId { get; set; }
        public string JobName { get; set; }
        public string PositionId { get; set; }
        public string PositionTitle { get; set; }
        public DateTime CratedDateTime { get; set; }
        public string CatchPicture { get; set; }
        public string FacialArea { get; set; }
        public string FacialAvatar { get; set; }
        public string LatitudeAndLongitude { get; set; }
        public string HmacHash { get; set; }
    }
}
