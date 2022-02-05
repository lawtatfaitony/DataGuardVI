using AttendanceBussiness.DbFirst;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceBussiness.Attendance
{
    public class AttendanceLogObjData
    {
        public long AttendanceLogId { get; set; }
        public int Mode { get; set; }
        public object ObjData { get; set; }
        public Employee Employee{ get; set; } 
        public Device Device { get; set; }
        public long OccurDateTime { get; set; } 
        public string MainComId { get; set; }      
          
    }

    public class ObjDataByCard
    {
        public string CardNo { get; set; }
        public string EmployeeId { get; set; }
        public long OccurDateTime { get; set; } 
        public string DeviceId { get; set; }
    }

    public class ObjDataFingerPrint
    {
        public string FingerPrintNo { get; set; }
        public string EmployeeId { get; set; }
        public long OccurDateTime { get; set; }
        public string DeviceId { get; set; }
    }
    /// <summary>
    /// Hereby,It need modify further.
    /// </summary>
    public class ObjDataByFaceRecogn
    {
        public string FaceId { get; set; }
        public string EmployeeId { get; set; }
        public long OccurDateTime { get; set; }
        public string DeviceId { get; set; }
    }
    
}
