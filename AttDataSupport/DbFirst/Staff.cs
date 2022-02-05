using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class Staff
    {
        public string StaffId { get; set; }
        public string MainComId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string StaffName { get; set; }
        public bool IsConfirmed { get; set; }
        public string Qrcode { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime OperatedDate { get; set; }
        public string ContactTitle { get; set; }
        public string Introduction { get; set; }
        public string ChannelId { get; set; }
        public string OtherChannelName { get; set; }
        public string OtherQrcode { get; set; }
        public string IconPortrait { get; set; }
        public string PublicNo { get; set; }
    }
}
