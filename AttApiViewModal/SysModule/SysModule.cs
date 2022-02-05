using System;
using System.Collections.Generic;

namespace AttApiViewModal
{
    //SysModuleId，SysModuleName，IpAddress，Port，SysModuleUrl，SiteId，SiteName，MainComId
    public partial class SysModule
    {
        public string SysModuleId { get; set; }
        public string SysModuleName { get; set; }
        public string IpAddress { get; set; }
        public string Port { get; set; }
        public string SysModuleUrl { get; set; } 
        public string SiteId { get; set; }
        public string SiteName { get; set; }
        public string MainComId { get; set; }
    }

    public partial class DeviceForSelect
    {
        public string DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string SysModuleId { get; set; }
        public string SiteId { get; set; }
        public string SiteName { get; set; }
        public string MainComId { get; set; }
    }
}
