using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class InfoDetail
    {
        public string InfoId { get; set; }
        public string InfoCateId { get; set; }
        public string Title { get; set; }
        public string TitleThumbNail { get; set; }
        public bool ShowTitleThumbNail { get; set; }
        public string SubTitle { get; set; }
        public string SeoKeyword { get; set; }
        public string SeoDescription { get; set; }
        public string InfoDescription { get; set; }
        public string VideoUrl { get; set; }
        public string Author { get; set; }
        public int Views { get; set; }
        public string MainComId { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime OperatedDate { get; set; }
        public string StaffId { get; set; }
        public string InfoItemTemplateIds { get; set; }
        public bool IsOriginal { get; set; }
        public string UserTraceId { get; set; }
    }
}
