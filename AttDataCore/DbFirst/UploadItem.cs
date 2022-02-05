using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class UploadItem
    {
        public string UploadItemId { get; set; }
        public string TargetTalbeKeyId { get; set; }
        public string MainComId { get; set; }
        public string SubPath { get; set; }
        public string Url { get; set; }
        public string RawName { get; set; }
        public string FileExt { get; set; }
        public int RankOrder { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime OperatedDate { get; set; }
    }
}
