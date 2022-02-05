using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class SysModule
    {
        public string SysModuleId { get; set; }
        public string SysModuleName { get; set; }
        public string IpAddress { get; set; }
        public string Port { get; set; }
        public string SysModuleUrl { get; set; }
        public string AppId { get; set; }
        public string AppSecret { get; set; }
        public string ClientId { get; set; }
        public string SyncTargetPath { get; set; }
        public string SiteId { get; set; }
        public string SiteName { get; set; }
        public string MainComId { get; set; }
    }
}
