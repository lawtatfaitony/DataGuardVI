using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class Device
    {
        public string DeviceId { get; set; }
        public string SysModuleId { get; set; }
        public string DeviceName { get; set; }
        public int DeviceEntryMode { get; set; }
        public string IpAddress { get; set; }
        public string Port { get; set; }
        public string DeviceUrl { get; set; }
        public string AppId { get; set; }
        public string AppSecret { get; set; }
        public string ClientId { get; set; }
        public string DeviceSerialNo { get; set; }
        public string SiteId { get; set; }
        public string SiteName { get; set; }
        public string MainComId { get; set; }
    }
}
