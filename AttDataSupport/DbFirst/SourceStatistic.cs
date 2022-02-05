using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class SourceStatistic
    {
        public int SourceStatisticsId { get; set; }
        public string UserId { get; set; }
        public string Ip { get; set; }
        public string SourceArea { get; set; }
        public decimal Duration { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string MainComId { get; set; }
        public string Title { get; set; }
        public string SourceUrl { get; set; }
        public int LoadTime { get; set; }
        public string Osversion { get; set; }
        public string TableKeyId { get; set; }
        public string RecommUserId { get; set; }
        public string VisitorIcon { get; set; }
        public string WxNickName { get; set; }
        public int Status { get; set; }
        public string OpenId { get; set; }
    }
}
