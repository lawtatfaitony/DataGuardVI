using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using AttendanceBussiness.DbFirst;

namespace AttendanceBussiness
{
    public partial class UnkownView
    {
        public static string EmployeeId = "UNKNOWN";
        public static string MainComId = "UNKNOWN";
        public static string AccesscardId = "UNKNOWN "; 
        public static string CnName = "UNKNOWN";
        public static string CompanyName = "UNKNOWN";
        public static string ContractorId = "UNKNOWN";
        public static string ContractorName = "UNKNOWN";
        public static string SiteId = "UNKNOWN";
        public static string SiteName = "UNKNOWN";
        public static string DepartmentId = "UNKNOWN";
        public static string DepartmentName = "UNKNOWN";
        public static string JobId = "UNKNOWN";
        public static string JobName = "UNKNOWN";
        public static string PositionId = "UNKNOWN";
        public static string PositionTitle = "UNKNOWN";
    }
   
     
}