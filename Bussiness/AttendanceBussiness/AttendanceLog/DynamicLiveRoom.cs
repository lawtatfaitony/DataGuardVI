using AttDataSupport.Context;
using AttendanceBussiness.DbFirst;
using AttendanceBussiness.EntriesBusiness;
using Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using static Common.CommonBase;

namespace AttendanceBussiness.Attendance
{
    public class AttendanceLiveRoomInitialize
    {
        public void ToInstance()
        {
            _LastIndexId = 0;
            DateTime dt = DateTime.Now;
            DateTimeOffset dateTimeOffset = new DateTimeOffset(dt);
            _LastIndexTimeStamp = dateTimeOffset.ToUnixTimeMilliseconds();
            using (var t = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                using (DataBaseContext dataBaseContext = new DataBaseContext())
                {
                    var attOccurDateTime25 = dataBaseContext.AttendanceLog.AsNoTracking().Select(c => new { c.AttendanceLogId, c.OccurDateTime, c.CatchPictureFileName }).Where(c => c.CatchPictureFileName.Length != 49 && !string.IsNullOrEmpty(c.CatchPictureFileName) && c.CatchPictureFileName != "0").OrderByDescending(c => c.OccurDateTime).Take(25).ToList();
                    List<AttendanceLog> attTop25 = new List<AttendanceLog>();
                    attOccurDateTime25.ForEach(a =>
                    {
                        AttendanceLog attItem = dataBaseContext.AttendanceLog.Find(a.AttendanceLogId);
                        attTop25.Add(attItem);
                    });
                    List<AttendanceLiveRoom> liveRooms20 = new List<AttendanceLiveRoom>();
                    List<AttendanceLiveRoom> liveRooms3 = new List<AttendanceLiveRoom>();
                    int i = 0;

                    foreach (var item in attTop25)
                    {
                        AttendanceLiveRoom attendanceLiveRoom = AttendanceLiveRoom.AttTransToLiveRoomObj(item);
                        if (i > 2)
                        {
                            liveRooms20.Add(attendanceLiveRoom);
                        }
                        else
                        {
                            liveRooms3.Add(attendanceLiveRoom);
                        }
                        i++;
                    }

                    if (attTop25.Count > 0)
                    {
                        _ListTop20 = liveRooms20;
                        _LiveRooms3 = liveRooms3;
                    }
                    else
                    {
                        CommonBase.OperateDateLoger("DynamicLiveRoom.cs AttendanceLiveRoomInitialize liveRooms20 :: = NULL ", LoggerMode.FATAL);
                    }

                    AttendanceLiveRoom AttendanceLiveRoomTop1 = liveRooms3.OrderBy(c => c.OccurDateTime).FirstOrDefault();
                    _LastIndexTimeStamp = AttendanceLiveRoomTop1.OccurDateTime;
                    _LastIndexId = AttendanceLiveRoomTop1.AttendanceLogId;
                    _LasstIndexItem = AttendanceLiveRoomTop1;
                } 
                t.Complete();
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
        public long LastIndexTimeStamp
        {
            get
            {

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
            get
            {
                return _LasstIndexItem;
            }
            set
            {
                _LasstIndexItem = value;
            }
        }
        private List<AttendanceLiveRoom> _ListTop20;
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

        private List<AttendanceLiveRoom> _LiveRooms3;
        public List<AttendanceLiveRoom> LiveRooms3
        {
            get
            {
                return _LiveRooms3;
            }
            set
            {
                _LiveRooms3 = value;
            }
        }
    }
    public class AttendanceLiveRoom : AttendanceLog
    {
        public AttendanceLiveRoom()
        {
            _OccurTimeSpan = DateTimePubBusiness.DateTimeToUnixTimestamp(OccurDateTime).TimeOfDay;
            _CurrentIndexTimeStamp = OccurDateTime;
            //clear special column field value 
            ObjData = string.Empty;
            CatchPicture = string.Empty;
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
        public DateTime ConvetToDateTime()
        {
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime date = start.AddMilliseconds(OccurDateTime).ToLocalTime();
            return date;
        }
        public virtual UserIconOfEmployee UserIconOfEmployee => new UserIconOfEmployee(EmployeeId);
        public static AttendanceLiveRoom AttTransToLiveRoomObj(AttendanceLog att)
        {
            AttendanceLiveRoom attendanceLiveRoom = new AttendanceLiveRoom
            {
                AttendanceLogId = att.AttendanceLogId,
                Mode = att.Mode,
                ObjData = string.Empty,
                DeviceId = att.DeviceId,
                DeviceName = att.DeviceName,
                DeviceEntryMode = att.DeviceEntryMode,
                EmployeeId = att.EmployeeId,
                AccesscardId = att.AccesscardId,
                CnName = att.CnName,
                OccurDateTime = att.OccurDateTime,
                CatchPictureFileName = att.CatchPictureFileName,
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
                CatchPicture = string.Empty,
                FacialArea = att.FacialArea,
                FacialAvatar = att.FacialAvatar,
                LatitudeAndLongitude = att.LatitudeAndLongitude,
                HmacHash = att.LatitudeAndLongitude
            };
            attendanceLiveRoom.CurrentIndexTimeStamp = att.OccurDateTime;
            return attendanceLiveRoom;
        }
    }

    public class ReturnNewAttendanceLiveRoom
    {
        public long CurrentIndexTimeStamp { get; set; }
        public long CurrentLastIndexId { get; set; }
        public AttendanceLiveRoom AttendanceLiveRoom { get; set; }
        public static AttendanceLiveRoom GetNextAttendanceLiveRoomItem(long CurrentIndexTimeStamp)
        {
            using (var t = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                using (DataBaseContext dataBaseContext = new DataBaseContext())
                {
                    AttendanceLiveRoom attendanceLiveRoom = new AttendanceLiveRoom();
                    var attendanceLogs = dataBaseContext.AttendanceLog.AsNoTracking()
                        .Select(c => new { c.AttendanceLogId, c.OccurDateTime, c.CatchPictureFileName }).Where(c => c.CatchPictureFileName.Length != 49 && !string.IsNullOrEmpty(c.CatchPictureFileName) && c.CatchPictureFileName != "0")
                        .Where(c => c.OccurDateTime > CurrentIndexTimeStamp);

                    if (attendanceLogs.Count() > 0)
                    {
                        var attAbbr = attendanceLogs.OrderBy(c => c.OccurDateTime).Where(c => c.OccurDateTime > CurrentIndexTimeStamp).FirstOrDefault();
                        AttendanceLog att = dataBaseContext.AttendanceLog.Find(attAbbr.AttendanceLogId);
                        attendanceLiveRoom = AttendanceLiveRoom.AttTransToLiveRoomObj(att);
                    }
                    else
                    {
                        attendanceLiveRoom = new AttendanceLiveRoom
                        {
                            CurrentIndexTimeStamp = 0,
                            AttendanceLogId = 0,
                            Mode = 0,
                            ObjData = string.Empty,
                            DeviceId = string.Empty,
                            DeviceName = string.Empty,
                            DeviceEntryMode = 0,
                            EmployeeId = string.Empty,
                            AccesscardId = string.Empty,
                            CnName = string.Empty,
                            OccurDateTime = 0,
                            CatchPictureFileName = string.Empty,
                            CompanyName = string.Empty,
                            ContractorId = string.Empty,
                            ContractorName = string.Empty,
                            SiteId = string.Empty,
                            SiteName = string.Empty,
                            DepartmentId = string.Empty,
                            DepartmentName = string.Empty,
                            JobId = string.Empty,
                            JobName = string.Empty,
                            PositionId = string.Empty,
                            PositionTitle = string.Empty,
                            CratedDateTime = new DateTime(1970, 1, 1, 0, 0, 0),
                            CatchPicture = string.Empty,
                            FacialArea = string.Empty,
                            FacialAvatar = string.Empty,
                            LatitudeAndLongitude = string.Empty,
                            HmacHash = string.Empty,
                        };
                    }
                    return attendanceLiveRoom;
                }
            }
        }
        public static AttendanceLiveRoom GetCurrentAttendanceLiveRoomItem(long AttendanceLogId)
        {
            using (var t = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                using (DataBaseContext dataBaseContext = new DataBaseContext())
                {
                    AttendanceLog att = dataBaseContext.AttendanceLog.Find(AttendanceLogId);

                    AttendanceLiveRoom attendanceLiveRoom = new AttendanceLiveRoom();
                    if (att != null)
                    {
                        attendanceLiveRoom = AttendanceLiveRoom.AttTransToLiveRoomObj(att);
                    }
                    else
                    {
                        attendanceLiveRoom = null;
                    }
                    return attendanceLiveRoom;
                }
            }
        }
    }

}