using AttendanceBussiness.DbFirst;
using AttendanceBussiness.EntriesBusiness;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataGuard.Areas
{
    /// <summary>
    /// DISCARD Turn to AttendanceBusiness
    /// </summary>
    public class AttendanceLiveRoomInitialize
    { 
        public AttendanceLiveRoomInitialize()
        {
            _LastIndexId = 0;
            DateTime dt = DateTime.Now;
            DateTimeOffset dateTimeOffset = new DateTimeOffset(dt);
            _LastIndexTimeStamp = dateTimeOffset.ToUnixTimeMilliseconds();
            using (DataBaseContext dataBaseContext = new DataBaseContext())
            {
                var attendaceLog23 = dataBaseContext.AttendanceLog.OrderByDescending(c => c.OccurDateTime).Take(23).ToList();
                var attendaceLogTop3 = dataBaseContext.AttendanceLog.OrderByDescending(c => c.OccurDateTime).Take(3).ToList();
                foreach(var item in attendaceLogTop3)
                {
                    attendaceLog23.Remove(item);
                }
                foreach(var item in attendaceLog23)
                {
                    _ListTop20.Add(AttendanceLiveRoom.AttTransToLiveRoomObj(item));
                } 

                AttendanceLog attendaceLogTop1 = attendaceLogTop3.OrderBy(c => c.OccurDateTime).FirstOrDefault();
                if(attendaceLogTop1 != null)
                {
                    _LastIndexId = attendaceLogTop1.AttendanceLogId;
                    _LastIndexTimeStamp = attendaceLogTop1.OccurDateTime;
                    LasstIndexItem = AttendanceLiveRoom.AttTransToLiveRoomObj(attendaceLogTop1);
                }
            }
        }
        private long _LastIndexId;
        public long LastIndexId
        {
            get
            {
                return _LastIndexId;
            }
            set
            {
                _LastIndexId = value;
            }
        }
        private long _LastIndexTimeStamp;
        public long LastIndexTimeStamp {
            get {

                return _LastIndexTimeStamp;
            }
            set
            {
                _LastIndexTimeStamp = value;
            }
        }
        private AttendanceLiveRoom _LasstIndexItem;
        public AttendanceLiveRoom LasstIndexItem
        {
            get {
                return _LasstIndexItem;
            }
            set {
                _LasstIndexItem = value;
            }
        }
        private List<AttendanceLiveRoom> _ListTop20 ;
        public List<AttendanceLiveRoom> ListTop20
        {
            get
            {
                return _ListTop20;
            }
            set
            {
                _ListTop20 = value;
            }
        }

        public AttendanceLiveRoom GetNextAttendanceLiveRoomItem(long CurrentIndexTimeStamp)
        {
            AttendanceLog att;
            using (DataBaseContext dataBaseContext = new DataBaseContext() )
            {
                att = dataBaseContext.AttendanceLog.Where(c => c.OccurDateTime > CurrentIndexTimeStamp).OrderBy(c=>c.OccurDateTime).Take(1).FirstOrDefault();
            }
            AttendanceLiveRoom attendanceLiveRoom = AttendanceLiveRoom.AttTransToLiveRoomObj(att);
            return attendanceLiveRoom;
        }
    }
    /// <summary>
    /// DISCARD  Turn to AttendanceBusiness
    /// </summary>
    public class AttendanceLiveRoom : AttendanceBussiness.DbFirst.AttendanceLog
    {
        public AttendanceLiveRoom()
        {
            DateTime dt0 = new DateTime( 1970,1,1,0,0,0,0).ToLocalTime();
            DateTime DOccureDateTime = dt0.AddMilliseconds(OccurDateTime);
            _OccurTimeSpan = DOccureDateTime.TimeOfDay;
            _CurrentIndexTimeStamp = OccurDateTime;
        }
        
        private long _CurrentIndexTimeStamp;
        public long CurrentIndexTimeStamp
        {
            get
            {
                return _CurrentIndexTimeStamp;
            }
            set
            {
                _CurrentIndexTimeStamp = value;
            }
        }
        private TimeSpan _OccurTimeSpan;
        public TimeSpan OccurTimeSpan
        {
            get
            {
                return _OccurTimeSpan;
            }
            set
            {
                _OccurTimeSpan = value;
            }
        }
        public virtual UserIconOfEmployee UserIconOfEmployee => new UserIconOfEmployee(EmployeeId);

        public static AttendanceLiveRoom AttTransToLiveRoomObj(AttendanceLog att)
        {
            AttendanceLiveRoom attendanceLiveRoom = new AttendanceLiveRoom
            {
                AttendanceLogId = att.AttendanceLogId,
                Mode = att.Mode,
                ObjData = att.ObjData,
                DeviceId = att.DeviceId,
                DeviceName = att.DeviceName,
                DeviceEntryMode = att.DeviceEntryMode,
                EmployeeId = att.EmployeeId,
                AccesscardId = att.AccesscardId,
                CnName = att.CnName,
                OccurDateTime = att.OccurDateTime,
                CatchPictureFileName = att.CatchPictureFileName,
                MainComId = att.MainComId,
                CompanyName = att.CompanyName,
                ContractorId = att.ContractorId,
                ContractorName = att.ContractorName,
                SiteId = att.SiteId,
                SiteName = att.SiteName,
                DepartmentId = att.DepartmentId,
                DepartmentName = att.DepartmentName,
                JobId = att.JobId,
                JobName = att.JobName,
                PositionId = att.PositionId,
                PositionTitle = att.PositionTitle,
                CratedDateTime = att.CratedDateTime,
                CatchPicture = att.CatchPicture,
                FacialArea = att.FacialArea,
                FacialAvatar = att.FacialAvatar,
                LatitudeAndLongitude = att.LatitudeAndLongitude,
                HmacHash = att.LatitudeAndLongitude
            };

            return attendanceLiveRoom;
        }
    }
}