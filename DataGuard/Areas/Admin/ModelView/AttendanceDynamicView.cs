using AttendanceBussiness.DbFirst;
using System.Collections.Generic;

namespace DataGuard.Areas
{
    public class AttendanceDynamicView
    { 
        public AttendanceDynamicView()
        {

        }

        private static long _LastTimeStamp;
        public static long LastTimeStamp {
            get {
                return _LastTimeStamp;
            }
            set
            {
                _LastTimeStamp = value;
            } 
        
        }

        private static IEnumerable<AttendanceBussiness.DbFirst.AttendanceLog> _AttendanceLogs;
        public static IEnumerable<AttendanceBussiness.DbFirst.AttendanceLog> AttendanceLogs
        {
            get
            {
                return _AttendanceLogs;
            }
            set
            {
                _AttendanceLogs = value;
            } 
        }
    }
     
}