using AttendanceBussiness.DbFirst;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LanguageResource;
using static AttendanceBussiness.ShiftBusiness;
using Common;
using AttendanceBussiness.AttendanceSchedule;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using static Common.CommonBase;
using AttendanceBussiness.Public;
using MemoryCacheHelper = Common.MemoryCacheHelper;

namespace AttendanceBussiness.ScheduleAndShift
{
    public abstract class ScheduleAndShiftTpl
    { 
        public static Shift Shift { get; set; }
        public static Employee Employee{ get;set; }
        public static Schedule Schedule { get; set; } 
        public static List<ShortAttendance>  ScheduleAttendanceLog { get; set; }
        
        public ScheduleAndShiftTpl(Shift shift, Employee employee, Schedule schedule, List<ShortAttendance>  scheduleAttendanceLog)
        {
            Shift = shift;
            Employee = employee;
            Schedule = schedule;
            if (scheduleAttendanceLog != null)
            {
                ScheduleAttendanceLog = scheduleAttendanceLog;
            }
            else
            {
                ScheduleAttendanceLog = new List<ShortAttendance>(); 
            }
        } 
    }
 

    public class CalcFoundationDataX : ScheduleAndShiftTpl, IDisposable
    {
        private bool _disposed;

        private string _ScheduleId;
        private string _ShiftId;
        private string _ShiftAbbrId;
        private string _EmployeeId;
        private string _AttendanceByShiftId;

        private string _DepartmentId;
        private string _DepartmentName;
        private string _PositionId;
        private string _PositionTitle;
        private string _ContractorId;
        private string _ContractorName;
        private string _JobId;
        private string _JobName;
        private string _SiteId;
        private string _SiteName;
        public CalcFoundationDataX(Shift shift, Employee employee, Schedule schedule, List<ShortAttendance> scheduleAttendanceLog) : base(shift, employee, schedule, scheduleAttendanceLog)
        {
            Shift = shift;
            Employee = employee;
            Schedule = schedule; // ScheduleAndShiftCalc.GetScheduleById(scheduleId);
            if (scheduleAttendanceLog != null && employee != null)
            {
                ScheduleAttendanceLog = scheduleAttendanceLog.Where(c => c.EmployeeId == employee.EmployeeId).ToList();
            }
            else
            {
                ScheduleAttendanceLog = new List<ShortAttendance>();
            }
            _EmployeeId = employee.EmployeeId;
            _ShiftId = shift.ShiftId;
            _ShiftAbbrId = shift.ShiftAbbrId;
            _ScheduleId = Schedule.ScheduleId;
            _AttendanceByShiftId = Schedule.ScheduleId; //*********

            IsAutoCalcMissing = Shift.IsAutoCalcMissing == true ? true : false;
            IsRegularWorkOn = false;
            IsRegularWorkOff = false;

            ShiftAbbrId = shift.ShiftAbbrId;
            ShiftName = shift.ShiftName;

            ScheduleDate = Schedule.ScheduleDate;

            EmployeeId = employee.EmployeeId;
            EmployeeName = employee.FullName;
            _DepartmentId = employee.DepartmentId ?? string.Empty;
            _DepartmentName = employee.DepartmentName ?? string.Empty;
            _PositionId = employee.PositionId ?? string.Empty;
            _PositionTitle = employee.PositionTitle ?? string.Empty;
            _ContractorId = employee.ContractorId ?? string.Empty;
            _ContractorName = employee.ContractorName ?? string.Empty;
            _JobId = employee.JobId ?? string.Empty;
            _JobName = employee.JobName ?? string.Empty;
            _SiteId = employee.SiteId ?? string.Empty;
            _SiteName = employee.SiteName ?? string.Empty;
            SysCalcDateTime = DateTime.Now;
        }

        public string AttendanceByShiftId
        {
            get
            {

                return _AttendanceByShiftId;
            }
            set
            {
                _AttendanceByShiftId = value;
            }
        }

        public string ShiftId
        {
            get
            {
                return _ShiftId;
            }
            set
            {
                _ShiftId = value;
            }
        }
        public string ShiftAbbrId
        {
            get
            {
                return _ShiftAbbrId;
            }
            set
            {
                _ShiftAbbrId = value;
            }
        }
        public string ShiftName { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string EmployeeId
        {
            get
            {
                return _EmployeeId;
            }
            set
            {
                _EmployeeId = value;
            }
        }
        public string EmployeeName { get; set; }
        public string DepartmentId
        {
            get
            {
                if (string.IsNullOrEmpty(_DepartmentId))
                {
                    return string.Empty;
                }
                else
                {
                    return _DepartmentId;
                }

            }
        }
        public string DepartmentName
        {
            get
            {
                if (string.IsNullOrEmpty(_DepartmentName))
                {
                    return string.Empty;
                }
                else
                {
                    if (_DepartmentName.Length > 50)
                        _DepartmentName = _DepartmentName.Substring(0, 49);

                    return _DepartmentName;
                }
            }
        }
        public string PositionId
        {
            get
            {
                if (string.IsNullOrEmpty(_PositionId))
                {
                    return string.Empty;
                }
                else
                {
                    return _PositionId;
                }
            }
        }
        public string PositionTitle
        {
            get
            {
                if (string.IsNullOrEmpty(_PositionTitle))
                {
                    return string.Empty;
                }
                if (_PositionTitle.Length > 50)
                    _PositionTitle = _PositionTitle.Substring(0, 49);

                return _PositionTitle;
            }
        }
        public string ContractorId
        {
            get
            {
                if (string.IsNullOrEmpty(_ContractorId))
                {
                    return string.Empty;
                }
                else
                {
                    return _ContractorId;
                }
            }
        }
        public string ContractorName
        {
            get
            {
                if (string.IsNullOrEmpty(_ContractorName))
                {
                    return string.Empty;
                }
                if (_ContractorName.Length > 50)
                    _ContractorName = _ContractorName.Substring(0, 49);

                return _ContractorName;
            }
        }
        public string JobId
        {
            get
            {
                if (string.IsNullOrEmpty(_JobId))
                {
                    return string.Empty;
                }
                else
                {
                    return _JobId;
                }
            }
        }
        public string JobName
        {
            get
            {
                if (string.IsNullOrEmpty(_JobName))
                {
                    return string.Empty;
                }

                if (_JobName.Length > 50)
                    _JobName = _JobName.Substring(0, 49);

                return _JobName;
            }
        }
        public string SiteId
        {
            get
            {
                if (string.IsNullOrEmpty(_SiteId))
                {
                    return string.Empty;
                }
                else
                {
                    return _SiteId;
                }
            }
        }
        public string SiteName
        {
            get
            {
                if (string.IsNullOrEmpty(_SiteName))
                {
                    return string.Empty;
                }
                if (_SiteName.Length > 50)
                    _SiteName = _SiteName.Substring(0, 49);

                return _SiteName;
            }
        }
        public int CalcPeriodType { get; set; } = 0;
        public bool OnDataLocked { get; set; } = false;
        public bool IsCompleted { get; set; } = false;
        public DateTime SysCalcDateTime { get; set; }
        public bool IsAutoCalcMissing { get; set; }
        public bool IsRegularWorkOn { get; set; }
        public bool IsRegularWorkOff { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            // If you need thread safety, use a lock around these 
            // operations, as well as in your methods that use the resource.
            if (!_disposed)
            {
                if (disposing)
                {
                    Console.Out.WriteLineAsync(string.Format("[{0:yyyy-MM-dd HH:mm:ss fff}] [INFO] [new CalcFoundationData::{1}] ", DateTime.Now, "CLOSED"));
                }
                Shift = null;
                Employee = null;
                Schedule = null;
                _disposed = true;
            }
        }
    }
     
    public class CalcAttendanceDataX : ScheduleAndShiftTpl, IDisposable
    {
        private bool _disposed;

        private static DateTime dt1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        #region Header 
        private static ScheduleDate _ObjScheduleDate;
        private string _AttendanceByShiftId;
        private static DateTime _WorkStart;
        private static DateTime _WorkEnd;
        private static decimal _WorkTimeSpan;
        private static decimal _WorkActualNetTimeSpan;

        private static int _LateIn;
        private static int _IsLate;
        private static int _EarlyOut;
        private static int _IsEarly;

        private static DateTime _LunchTimeStart;
        private static DateTime _LunchTimeEnd;
        private static decimal _LunchTimeSpan;
        private static double _LunchTimeSpan_GlobalConfig;

        private static int _LunchTimeLateIn;
        private static int _LunchTimeIsLate;
        private static int _LunchTimeEarlyOut;
        private static int _LunchTimeIsEarly;

        private static DateTime _OverTimeStart;
        private static DateTime _OverTimeEnd;
        private static decimal _OverTimeSpan;

        private static int _OverTimeLateIn;
        private static int _OverTimeIsLate;
        private static int _OverTimeEarlyOut;
        private static int _OverTimeIsEarly;
        private static bool _IsExcludeOverTime;

        private static bool _IsWorkDay = true;
        private static bool _IsAbsentDay = false;
        private static AutoCalcMissingType _MissingWorkOn;
        private static AutoCalcMissingType _MissingWorkOff;
        private static AutoCalcMissingType _MissingLunchStart;
        private static AutoCalcMissingType _MissingLunchEnd;
        private static AutoCalcMissingType _MissingOverTimeStart;
        private static AutoCalcMissingType _MissingOverTimeEnd;

        private static Leave _Leave;
        private static string _LeaveId;
        private static int _LeaveType;
        private static string _LeaveTypeName;
        private static int _LeavePaidType;
        private static string _LeavePaidTypeName;

        private static Holiday _Holiday;
        private static string _HolidayId;
        private static string _HolidayName;
        private static int _HolidayPaidType;
        private static string _HolidayPaidTypeName;
        private static bool _IsHoliday = false;

        private static decimal _OnDutyWorkRatio;
        private static decimal _OnDutyPaidRatio;
        #endregion

        public CalcAttendanceDataX(Shift shift, Employee employee, Schedule schedule, List<ShortAttendance> scheduleAttendanceLog) : base(shift, employee, schedule, scheduleAttendanceLog)
        {
            _AttendanceByShiftId = schedule.ScheduleId;
            Shift = shift ;
            Employee = employee;
            Schedule = schedule;// ScheduleAndShiftCalc.GetScheduleById(scheduleId);
            ScheduleAttendanceLog = scheduleAttendanceLog.Where(c => c.EmployeeId == employee.EmployeeId).ToList();
            _ObjScheduleDate = new ScheduleDate((ShiftBusinessMode)Shift.ShiftBusinessMode, Schedule);
            GlobalConfig globalConfig = new GlobalConfig();
            _LunchTimeSpan_GlobalConfig = globalConfig.LunchTimeSpan;
            WorkTimeBusiness();
            LunchTimeBusiness();
            OverTimeBusiness();
            _IsExcludeOverTime = IsExcludeOverTime(Shift, Schedule);
            LeaveBusiness();
            HolidayBusiness();
            OnDutyWorkRatioBusiness();
            OnDutyPaidRatioBusiness();
        }


        #region Business Handle
        public static void WorkTimeBusiness()
        {
            DateTime scheduleStartDate = _ObjScheduleDate.ScheduleStartDate;
            DateTime scheduleEndDate = _ObjScheduleDate.ScheduleEndDate;

            TimeSpan shiftWorkStart = SchedulePubBusiness.WorkStart(Shift, Schedule.ScheduleDate);
            TimeSpan shiftWorkEnd = SchedulePubBusiness.WorkEnd(Shift, Schedule.ScheduleDate);
              

            var WorkStartLog = ScheduleAttendanceLog.Where(c => c.EmployeeId == Employee.EmployeeId).OrderByDescending(c => c.OccurDateTime);
            if (WorkStartLog.Count() > 0)
            {
                ShortAttendance WorkStartFirstLog = WorkStartLog.FirstOrDefault();
                _WorkStart = DateTimeHelp.ConvertLongToDateTime(WorkStartFirstLog.OccurDateTime);
            }
            else
            {
                _WorkStart = dt1970;
            }

            var WorkEndLog = ScheduleAttendanceLog.Where(c => c.EmployeeId == Employee.EmployeeId).OrderBy(c => c.OccurDateTime);
            if (WorkEndLog.Count() > 0)
            {
                ShortAttendance WorkEndLastLog = WorkEndLog.FirstOrDefault();
                _WorkEnd = DateTimeHelp.ConvertLongToDateTime(WorkEndLastLog.OccurDateTime);
            }
            else
            {
                _WorkEnd = dt1970;
            }

            _IsAbsentDay = _WorkStart == _WorkEnd ? true : false;
            TimeSpanBusiness timeSpanBusiness = new TimeSpanBusiness(_WorkStart, _WorkEnd);
            double dblTotalSpanMinutes = timeSpanBusiness.TotalSpanMinutes / 60;
            _WorkTimeSpan = decimal.Parse(dblTotalSpanMinutes.ToString());
            _WorkStart = timeSpanBusiness.StartTime;
            _WorkEnd = timeSpanBusiness.EndTime;
            _MissingWorkOn =  AutoCalcMissingType.NO_CALC;
            _MissingWorkOff = AutoCalcMissingType.NO_CALC;
            _IsWorkDay = true; //in schedule
        }
        public static void LunchTimeBusiness()
        { 
            _LunchTimeStart = dt1970; 
            _LunchTimeEnd = dt1970; 
            _MissingLunchStart = AutoCalcMissingType.NO_CALC;
            _MissingLunchEnd =   AutoCalcMissingType.NO_CALC; 
            _LunchTimeSpan = 1;
        }
        public static void OverTimeBusiness()
        {
            _OverTimeStart = dt1970;
            _OverTimeEnd = dt1970;
            _MissingLunchStart = AutoCalcMissingType.NO_CALC;
            _MissingLunchEnd = AutoCalcMissingType.NO_CALC;
            _OverTimeSpan = 1;
        }

        public static bool IsExcludeOverTime(Shift shift, Schedule schedule)
        { 
            if (!string.IsNullOrEmpty(shift.ExcludeOverTime))
            { 
                return true;
            }
            else
            {
                return false;
            }
        }
        //Leave 
        public static void LeaveBusiness()
        {
            _Leave = null;
            _LeaveId = string.Empty;
            _LeaveType = -1;
            _LeaveTypeName = string.Empty;
            _LeavePaidType = -1;
            _LeavePaidTypeName = string.Empty;
        }
        public static void HolidayBusiness()
        {
            _HolidayId = string.Empty;
            _HolidayName = string.Empty;
            _HolidayPaidType = -1;
            _HolidayPaidTypeName = string.Empty;
        }

        public static void OnDutyWorkRatioBusiness()
        {
            if (_WorkTimeSpan != 0)
            {
                _OnDutyWorkRatio = 1;
            }
            else
            {
                _OnDutyWorkRatio = 0; 
            }
        }

        public static void OnDutyPaidRatioBusiness()
        { 
            if (_IsWorkDay == true && _IsAbsentDay == false)
            {
                _OnDutyPaidRatio = 1 * _OnDutyWorkRatio; 
            }
            else
            {
                _OnDutyPaidRatio = 0;

              
            } 
        }
       
        #endregion
        public string AttendanceByShiftId
        {
            get
            {

                return _AttendanceByShiftId;
            }
            set
            {
                _AttendanceByShiftId = value;
            }
        }
        public ScheduleDate ObjScheduleDate
        {
            get
            {
                return _ObjScheduleDate;
            }
            set
            {
                _ObjScheduleDate = value;
            }
        }
        public bool IsWorkDay
        {
            get
            {
                return _IsWorkDay;
            }
            set
            {
                _IsWorkDay = value;
            }
        }
        public bool IsAbsentDay
        {
            get
            {

                return _IsAbsentDay;
            }
            set
            {
                _IsAbsentDay = value;
            }
        }
        public DateTime WorkStart
        {
            get
            {
                return _WorkStart;
            }
            set
            {
                _WorkStart = value;
            }
        }
        public DateTime WorkEnd
        {
            get
            {
                return _WorkEnd;
            }
            set
            {
                _WorkEnd = value;
            }
        }
        public int LateIn
        {
            get
            {
                return _LateIn;
            }
            set
            {
                _LateIn = value;
            }
        }
        public int IsLate
        {
            get
            {
                return _IsLate;
            }
            set
            {
                _IsLate = value;
            }
        }

        public int EarlyOut
        {
            get
            {
                return _EarlyOut;
            }
        }
        public int IsEarly
        {
            get
            {

                return _IsEarly;
            }
            set
            {
                _IsEarly = value;
            }
        }

        public decimal WorkTimeSpan
        {
            get
            {
                return _WorkTimeSpan;
            }
            set
            {
                _WorkTimeSpan = value;
            }
        }
        public decimal WorkActualNetTimeSpan
        {
            get
            {
                _WorkActualNetTimeSpan = WorkTimeSpan - LunchTimeSpan + OverTimeSpan;
                return _WorkActualNetTimeSpan;
            }
        }
        public DateTime OverTimeStart
        {
            get
            {
                return _OverTimeStart;
            }
            set
            {
                _OverTimeStart = value;
            }
        }
        public DateTime OverTimeEnd
        {
            get
            {
                return _OverTimeEnd;
            }
            set
            {
                _OverTimeEnd = value;
            }
        }
        public decimal OverTimeSpan
        {
            get
            {
                return _OverTimeSpan;
            }
            set
            {
                _OverTimeSpan = value;
            }
        }
        public int OverTimeLateIn
        {
            get
            {
                return _OverTimeLateIn;
            }
            set
            {
                _OverTimeLateIn = value;
            }
        }
        public int OverTimeIsLate
        {
            get
            {
                return _OverTimeIsLate;
            }
            set
            {
                _OverTimeIsLate = value;
            }
        }
        public int OverTimeEarlyOut
        {
            get
            {
                return _OverTimeEarlyOut;
            }
            set
            {
                _OverTimeEarlyOut = value;
            }
        }
        public int OverTimeIsEarly
        {
            get
            {
                return _OverTimeIsEarly;
            }
            set
            {
                _OverTimeIsEarly = value;
            }
        }
        public int BreakTimes { get; set; } = 0;
        public decimal BreakTimeTotalSpan { get; set; } = 0;
        public DateTime LunchTimeStart
        {
            get
            {
                return _LunchTimeStart;
            }
            set
            {
                _LunchTimeStart = value;
            }
        }
        public DateTime LunchTimeEnd
        {
            get
            {
                return _LunchTimeEnd;
            }
            set
            {
                _LunchTimeEnd = value;
            }
        }
        public decimal LunchTimeSpan
        {
            get
            {
                return _LunchTimeSpan;
            }
            set
            {
                _LunchTimeSpan = value;
            }
        }

        public int LunchTimeLateIn
        {
            get
            {
                return _LunchTimeLateIn;
            }
            set
            {
                _LunchTimeLateIn = value;
            }
        }
        public int LunchTimeIsLate
        {
            get
            {
                return _LunchTimeIsLate;
            }
            set
            {
                _LunchTimeIsLate = value;
            }
        }
        public int LunchTimeEarlyOut
        {
            get
            {
                return _LunchTimeEarlyOut;
            }
            set
            {
                _LunchTimeEarlyOut = value;
            }
        }
        public int LunchTimeIsEarly
        {
            get
            {
                return _LunchTimeIsEarly;
            }
            set
            {
                _LunchTimeIsEarly = value;
            }
        }

        public AutoCalcMissingType MissingWorkOn
        {
            get
            {
                return _MissingWorkOn;
            }
            set
            {
                _MissingWorkOn = value;
            }
        }
        public AutoCalcMissingType MissingWorkOff
        {
            get
            {
                return _MissingWorkOff;
            }
            set
            {
                _MissingWorkOff = value;
            }
        }
        public AutoCalcMissingType MissingLunchStart
        {
            get
            {
                return _MissingLunchStart;
            }
            set
            {
                _MissingLunchStart = value;
            }
        }
        public AutoCalcMissingType MissingLunchEnd
        {
            get
            {
                return _MissingLunchEnd;
            }
            set
            {
                _MissingLunchEnd = value;
            }
        }
        public AutoCalcMissingType MissingOverTimeStart
        {
            get
            {
                return _MissingOverTimeStart;
            }
            set
            {
                _MissingOverTimeStart = value;
            }
        }
        public AutoCalcMissingType MissingOverTimeEnd
        {
            get
            {
                return _MissingOverTimeEnd;
            }
            set
            {
                _MissingOverTimeEnd = value;
            }
        }

        public string LeaveId
        {
            get
            {
                return _LeaveId;
            }
            set
            {
                _LeaveId = value;
            }
        }
        public int LeaveType
        {
            get
            {
                return _LeaveType;
            }
            set
            {
                _LeaveType = value;
            }
        }
        public string LeaveTypeName
        {
            get
            {
                return _LeaveTypeName;
            }
            set
            {
                _LeaveTypeName = value;
            }
        }
        public int LeavePaidType
        {
            get
            {
                return _LeavePaidType;
            }
            set
            {
                _LeavePaidType = value;
            }
        }
        public string LeavePaidTypeName
        {
            get
            {
                return _LeavePaidTypeName;
            }
            set
            {
                _LeavePaidTypeName = value;
            }
        }
        public string HolidayId
        {
            get
            {
                return _HolidayId;
            }
            set
            {
                _HolidayId = value;
            }
        }
        public string HolidayName
        {
            get
            {
                return _HolidayName;
            }
            set
            {
                _HolidayName = value;
            }
        }
        public int HolidayPaidType { get; set; }
        public string HolidayPaidTypeName { get; set; }
        public decimal OnDutyWorkRatio
        {
            get
            {
                return _OnDutyWorkRatio;
            }
            set
            {
                _OnDutyWorkRatio = value;
            }
        }
        public decimal OnDutyPaidRatio
        {
            get
            {
                return _OnDutyPaidRatio;
            }
            set
            {
                _OnDutyPaidRatio = value;
            }
        }

        public void Dispose()
        {
            Dispose(true); 
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        { 
            if (!_disposed)
            {
                Shift = null;
                Employee = null;
                Schedule = null;

                if (disposing)
                {
                    Console.Out.WriteLineAsync(string.Format("\n[{0:yyyy-MM-dd HH:mm:ss fff}] [INFO] [new CalcAttendanceData::{1}] ", DateTime.Now, "CLOSED"));
                }
                _disposed = true;
            }
        }
    }

    public class ScheduleAndShiftCalc
    {
        public static int DayRange = 2; 

        public static void ShiftCalcDaylyX()
        {
            string PathData = Path.GetFullPath("./");
            DateTime dtEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            DateTime dtBegin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 1);

            for (int i = 0; i < DayRange; i++)
            {
                int begin = i + 1;
                int end = i - 1;
                DateTime EndDate = dtEnd.AddDays(-end);
                DateTime StartDate = dtBegin.AddDays(-begin);
                DateTime CalcScheduleDate = StartDate;
                string cacheNameOfSchedule = string.Format("ScheduleDate{0:yyyyMMdd}", StartDate);
                List<ScheduleByDayQuery> scheduleByDayQueries = GetSchduleByDay(CalcScheduleDate, cacheNameOfSchedule);

                string cacheNameOfAtt = $"ATTLOG{StartDate:yyyyMMdd}";
                List<ShortAttendance> shortAttendances = GetAttLogDateOptimize(StartDate, EndDate, cacheNameOfAtt);

                Console.WriteLine("[ShiftCalcDaylyX] cacheNameOfSchedule = {0} [=sfdsfsfsgdgdfgfdgd]gfdgfdg=]", cacheNameOfSchedule);
                Console.WriteLine("[ShiftCalcDaylyX] cacheNameOfAtt = {0} [=sfdsfsfsgdgdfgfdgd]gfdgfdg=]", cacheNameOfAtt);

                foreach (var scheduleByDayQuery in scheduleByDayQueries)
                {
                    using (DataBaseContext dataBaseContext = new DataBaseContext())
                    {
                        Shift shift = GetShiftById(scheduleByDayQuery.ShiftId);  
                        shift.WorkStart = scheduleByDayQuery.WorkStart;// SchedulePubBusiness.WorkStart(shift, scheduleItem.ScheduleDate);
                        shift.WorkEnd = SchedulePubBusiness.WorkEnd(shift, scheduleByDayQuery.ScheduleDate); //scheduleItem.WorkEnd;
                      
                        Employee employee = GetEmployeeById(scheduleByDayQuery.EmployeeId);
                        Schedule schedule = GetScheduleById(scheduleByDayQuery.ScheduleId);

                        CalcFoundationDataX calcFoundationData = new CalcFoundationDataX(shift, employee, schedule, shortAttendances);

                        CalcAttendanceDataX calcAttendanceData = new CalcAttendanceDataX(shift, employee, schedule, shortAttendances);

                        DateTime EndpiontOfScheduleDatetime = SchedulePubBusiness.GetShiftTimeEndpiont(shift, scheduleByDayQuery.ScheduleDate);

                        if (EndpiontOfScheduleDatetime < DateTime.Now)
                        {
                            string calcAttendanceDataJson = JsonConvert.SerializeObject(calcAttendanceData, Formatting.Indented);
                            string Loggerline = string.Format("[INFO] [calcAttendanceData::{0}]", DateTime.Now, calcAttendanceDataJson);
                            PublicGlobal.ConsoleWriteline(Loggerline, LoggerMode.INFO);

                            AttendanceByShift attendanceByShift = new AttendanceByShift
                            {
                                AttendanceByShiftId = calcFoundationData.AttendanceByShiftId,
                                ShiftId = calcFoundationData.ShiftId,
                                ShiftAbbrId = calcFoundationData.ShiftAbbrId,
                                ShiftName = calcFoundationData.ShiftName,
                                ScheduleDate = calcFoundationData.ScheduleDate,
                                EmployeeId = calcFoundationData.EmployeeId,
                                EmployeeName = calcFoundationData.EmployeeName ?? string.Empty,
                                DepartmentId = calcFoundationData.DepartmentId ?? string.Empty,
                                DepartmentName = calcFoundationData.DepartmentName ?? string.Empty,
                                PositionId = calcFoundationData.PositionId ?? string.Empty,
                                PositionTitle = calcFoundationData.PositionTitle ?? string.Empty,
                                ContractorId = calcFoundationData.ContractorId ?? string.Empty,
                                ContractorName = calcFoundationData.ContractorName ?? string.Empty,
                                JobId = calcFoundationData.JobId ?? string.Empty,
                                JobName = calcFoundationData.JobName ?? string.Empty,
                                SiteId = calcFoundationData.SiteId ?? string.Empty,
                                SiteName = calcFoundationData.SiteName ?? string.Empty,
                                IsWorkDay = calcAttendanceData.IsWorkDay,
                                IsAbsentDay = calcAttendanceData.IsAbsentDay,
                                WorkStart = calcAttendanceData.WorkStart,
                                WorkEnd = calcAttendanceData.WorkEnd,
                                LateIn = calcAttendanceData.LateIn,
                                IsLate = calcAttendanceData.IsLate,
                                EarlyOut = calcAttendanceData.EarlyOut,
                                IsEarly = calcAttendanceData.IsEarly,
                                IsRegularWorkOn = calcFoundationData.IsRegularWorkOn,
                                IsRegularWorkOff = calcFoundationData.IsRegularWorkOff,
                                WorkTimeSpan = calcAttendanceData.WorkTimeSpan,
                                WorkActualNetTimeSpan = calcAttendanceData.WorkActualNetTimeSpan,
                                OverTimeSpan = calcAttendanceData.OverTimeSpan,
                                OverTimeStart = calcAttendanceData.OverTimeStart,
                                OverTimeEnd = calcAttendanceData.OverTimeEnd,
                                OverTimeLateIn = calcAttendanceData.OverTimeLateIn,
                                OverTimeIsLate = calcAttendanceData.OverTimeIsLate,
                                OverTimeEarlyOut = calcAttendanceData.OverTimeEarlyOut,
                                OverTimeIsEarly = calcAttendanceData.OverTimeIsEarly,
                                BreakTimes = calcAttendanceData.BreakTimes,
                                BreakTimeTotalSpan = calcAttendanceData.BreakTimeTotalSpan,
                                LunchTimeStart = calcAttendanceData.LunchTimeStart,
                                LunchTimeEnd = calcAttendanceData.LunchTimeEnd,
                                LunchTimeSpan = calcAttendanceData.LunchTimeSpan,
                                LunchTimeLateIn = calcAttendanceData.LunchTimeLateIn,
                                LunchTimeIsLate = calcAttendanceData.LunchTimeIsLate,
                                LunchTimeEarlyOut = calcAttendanceData.LunchTimeEarlyOut,
                                LunchTimeIsEarly = calcAttendanceData.LunchTimeIsEarly,
                                IsAutoCalcMissing = calcFoundationData.IsAutoCalcMissing,
                                MissingWorkOn = (int)calcAttendanceData.MissingWorkOn,
                                MissingWorkOff = (int)calcAttendanceData.MissingWorkOff,
                                MissingLunchStart = (int)calcAttendanceData.MissingLunchStart,
                                MissingLunchEnd = (int)calcAttendanceData.MissingLunchEnd,
                                MissingOverTimeStart = (int)calcAttendanceData.MissingOverTimeStart,
                                MissingOverTimeEnd = (int)calcAttendanceData.MissingOverTimeEnd,
                                LeaveId = calcAttendanceData.LeaveId,
                                LeaveType = calcAttendanceData.LeaveType,
                                LeaveTypeName = calcAttendanceData.LeaveTypeName ?? string.Empty,
                                LeavePaidType = calcAttendanceData.LeaveType,
                                LeavePaidTypeName = calcAttendanceData.LeavePaidTypeName ?? string.Empty,
                                HolidayId = calcAttendanceData.HolidayId,
                                HolidayName = calcAttendanceData.HolidayName ?? string.Empty,
                                HolidayPaidType = calcAttendanceData.HolidayPaidType,
                                HolidayPaidTypeName = calcAttendanceData.HolidayPaidTypeName ?? string.Empty,
                                OnDutyWorkRatio = calcAttendanceData.OnDutyPaidRatio,
                                OnDutyPaidRatio = calcAttendanceData.OnDutyPaidRatio,
                                CalcPeriodType = calcFoundationData.CalcPeriodType,
                                OnDataLocked = true,
                                IsCompleted = false,
                                SysCalcDateTime = DateTime.Now,
                                HmacHash = string.Empty
                            };

                            attendanceByShift.HmacHash = ScheduleAndShiftUtil.AttendanceByShiftHmac(attendanceByShift);
                            string attendanceByShiftJsonContent = JsonConvert.SerializeObject(attendanceByShift, Formatting.Indented);

                            string attendanceByShiftBase = CommonBase.StringToBase64(attendanceByShiftJsonContent);
                            attendanceByShift.ObjData = attendanceByShiftBase;

                            try
                            {
                                AttendanceByShift eAttShift = dataBaseContext.AttendanceByShift.Find(attendanceByShift.AttendanceByShiftId);
                                if (eAttShift == null)
                                {
                                    try
                                    {
                                        dataBaseContext.AttendanceByShift.Add(attendanceByShift);
                                        int result = dataBaseContext.SaveChanges();
                                        if (result > 0)
                                        {
                                            SchedulePubBusiness.OnDataLockedChange(scheduleByDayQuery.ScheduleId, true);
                                            SchedulePubBusiness.IsCompletedChange(scheduleByDayQuery.ScheduleId, true);
                                            //save json 
                                            string AttendanceByShiftFileName = string.Format("{0}.json", attendanceByShift.AttendanceByShiftId);

                                            string savePath = System.IO.Path.Combine(PathData, "Data", "ScheduleAndShiftCalc");

                                            CommonBase.SaveDataJson(attendanceByShiftJsonContent, savePath, AttendanceByShiftFileName);

                                            Thread.Sleep(30);
                                            Loggerline = string.Format("[INFO] [AttendanceByShift::{0}= {1}] [INSERT SUCCESS]", attendanceByShift.AttendanceByShiftId, result);
                                            PublicGlobal.ConsoleWriteline(Loggerline, LoggerMode.INFO);
                                        }
                                        else
                                        {
                                            Loggerline = string.Format("[INFO] [AttendanceByShift::{0}= {1}] [INSERT FAILURE]", attendanceByShift.AttendanceByShiftId, result);
                                            PublicGlobal.ConsoleWriteline(Loggerline, LoggerMode.FATAL);
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        SchedulePubBusiness.OnDataLockedChange(scheduleByDayQuery.ScheduleId, false);
                                        SchedulePubBusiness.IsCompletedChange(scheduleByDayQuery.ScheduleId, false);
                                        Loggerline = string.Format("[ERROR::CATCH] [ADD] [AttendanceByShift::{0}= {1}] [FAILURE]", attendanceByShift.AttendanceByShiftId, e.Message);
                                        PublicGlobal.ConsoleWriteline(Loggerline, LoggerMode.FATAL);
                                    }
                                }
                                else if (eAttShift.IsCompleted == false)  //如果状态为未完成，则可以重新更新当前的计算。
                                {
                                    #region UPDATE BEGIN
                                    // NOT ALLOW TO BE MODIFIED ::MainComId  ShiftId  ScheduleDate EmployeeId IsCompleted
                                    eAttShift.ShiftAbbrId = calcFoundationData.ShiftAbbrId;
                                    eAttShift.ShiftName = calcFoundationData.ShiftName;
                                    eAttShift.EmployeeName = calcFoundationData.EmployeeName;
                                    eAttShift.DepartmentId = calcFoundationData.DepartmentId;
                                    eAttShift.DepartmentName = calcFoundationData.DepartmentName;
                                    eAttShift.PositionId = calcFoundationData.PositionId;
                                    eAttShift.PositionTitle = calcFoundationData.PositionTitle;
                                    eAttShift.ContractorId = calcFoundationData.ContractorId;
                                    eAttShift.ContractorName = calcFoundationData.ContractorName;
                                    eAttShift.JobId = calcFoundationData.JobId;
                                    eAttShift.JobName = calcFoundationData.JobName;
                                    eAttShift.SiteId = calcFoundationData.SiteId;
                                    eAttShift.SiteName = calcFoundationData.SiteName;
                                    eAttShift.IsWorkDay = calcAttendanceData.IsWorkDay;
                                    eAttShift.IsAbsentDay = calcAttendanceData.IsAbsentDay;
                                    eAttShift.WorkStart = calcAttendanceData.WorkStart;
                                    eAttShift.WorkEnd = calcAttendanceData.WorkEnd;
                                    eAttShift.LateIn = calcAttendanceData.LateIn;
                                    eAttShift.IsLate = calcAttendanceData.IsLate;
                                    eAttShift.EarlyOut = calcAttendanceData.EarlyOut;
                                    eAttShift.IsEarly = calcAttendanceData.IsEarly;
                                    eAttShift.IsRegularWorkOn = calcFoundationData.IsRegularWorkOn;
                                    eAttShift.IsRegularWorkOff = calcFoundationData.IsRegularWorkOff;
                                    eAttShift.WorkTimeSpan = calcAttendanceData.WorkTimeSpan;
                                    eAttShift.WorkActualNetTimeSpan = calcAttendanceData.WorkActualNetTimeSpan;
                                    eAttShift.OverTimeSpan = calcAttendanceData.OverTimeSpan;
                                    eAttShift.OverTimeStart = calcAttendanceData.OverTimeStart;
                                    eAttShift.OverTimeEnd = calcAttendanceData.OverTimeEnd;
                                    eAttShift.OverTimeLateIn = calcAttendanceData.OverTimeLateIn;
                                    eAttShift.OverTimeIsLate = calcAttendanceData.OverTimeIsLate;
                                    eAttShift.OverTimeEarlyOut = calcAttendanceData.OverTimeEarlyOut;
                                    eAttShift.OverTimeIsEarly = calcAttendanceData.OverTimeIsEarly;
                                    eAttShift.BreakTimes = calcAttendanceData.BreakTimes;
                                    eAttShift.BreakTimeTotalSpan = calcAttendanceData.BreakTimeTotalSpan;
                                    eAttShift.LunchTimeStart = calcAttendanceData.LunchTimeStart;
                                    eAttShift.LunchTimeEnd = calcAttendanceData.LunchTimeEnd;
                                    eAttShift.LunchTimeSpan = calcAttendanceData.LunchTimeSpan;
                                    eAttShift.LunchTimeLateIn = calcAttendanceData.LunchTimeLateIn;
                                    eAttShift.LunchTimeIsLate = calcAttendanceData.LunchTimeIsLate;
                                    eAttShift.LunchTimeEarlyOut = calcAttendanceData.LunchTimeEarlyOut;
                                    eAttShift.LunchTimeIsEarly = calcAttendanceData.LunchTimeIsEarly;
                                    eAttShift.IsAutoCalcMissing = calcFoundationData.IsAutoCalcMissing;
                                    eAttShift.MissingWorkOn = (int)calcAttendanceData.MissingWorkOn;
                                    eAttShift.MissingWorkOff = (int)calcAttendanceData.MissingWorkOff;
                                    eAttShift.MissingLunchStart = (int)calcAttendanceData.MissingLunchStart;
                                    eAttShift.MissingLunchEnd = (int)calcAttendanceData.MissingLunchEnd;
                                    eAttShift.MissingOverTimeStart = (int)calcAttendanceData.MissingOverTimeStart;
                                    eAttShift.MissingOverTimeEnd = (int)calcAttendanceData.MissingOverTimeEnd;
                                    eAttShift.LeaveId = calcAttendanceData.LeaveId;
                                    eAttShift.LeaveType = calcAttendanceData.LeaveType;
                                    eAttShift.LeaveTypeName = calcAttendanceData.LeaveTypeName;
                                    eAttShift.LeavePaidType = calcAttendanceData.LeaveType;
                                    eAttShift.LeavePaidTypeName = calcAttendanceData.LeavePaidTypeName;
                                    eAttShift.HolidayId = calcAttendanceData.HolidayId;
                                    eAttShift.HolidayName = calcAttendanceData.HolidayName;
                                    eAttShift.HolidayPaidType = calcAttendanceData.HolidayPaidType;
                                    eAttShift.HolidayPaidTypeName = calcAttendanceData.HolidayPaidTypeName;
                                    eAttShift.OnDutyWorkRatio = calcAttendanceData.OnDutyPaidRatio;
                                    eAttShift.OnDutyPaidRatio = calcAttendanceData.OnDutyPaidRatio;
                                    eAttShift.CalcPeriodType = calcFoundationData.CalcPeriodType;
                                    eAttShift.OnDataLocked = true;

                                    eAttShift.SysCalcDateTime = DateTime.Now;
                                    eAttShift.HmacHash = string.Empty;
                                    #endregion UPDATE END

                                    eAttShift.HmacHash = ScheduleAndShiftUtil.AttendanceByShiftHmac(eAttShift);
                                    string eAttShiftJsonContent = JsonConvert.SerializeObject(eAttShift, Formatting.Indented);
                                    string eAttShiftBase = CommonBase.StringToBase64(eAttShiftJsonContent);
                                    eAttShift.ObjData = string.Empty;

                                    try
                                    {
                                        dataBaseContext.AttendanceByShift.Update(eAttShift);
                                        int result = dataBaseContext.SaveChanges();
                                        if (result > 0)
                                        {
                                            //save json 
                                            string AttendanceByShiftFileName = string.Format("{0}_Update.json", attendanceByShift.AttendanceByShiftId);
                                            string savePath = System.IO.Path.Combine(PathData, "Data", "ScheduleAndShiftCalc");

                                            CommonBase.SaveDataJson(attendanceByShiftJsonContent, savePath, AttendanceByShiftFileName);

                                            Console.Out.WriteLineAsync();
                                            SchedulePubBusiness.OnDataLockedChange(scheduleByDayQuery.ScheduleId, true);
                                            SchedulePubBusiness.IsCompletedChange(scheduleByDayQuery.ScheduleId, true);

                                            Loggerline = string.Format("[INFO] [AttendanceByShift::{0}= {1}] [UPDATE SUCCESS]", attendanceByShift.AttendanceByShiftId, result);
                                            PublicGlobal.ConsoleWriteline(Loggerline);
                                        }
                                        else
                                        {
                                            SchedulePubBusiness.OnDataLockedChange(scheduleByDayQuery.ScheduleId, false);
                                            SchedulePubBusiness.IsCompletedChange(scheduleByDayQuery.ScheduleId, false);
                                            Console.Out.WriteLineAsync();
                                            Loggerline = string.Format("[INFO] [AttendanceByShift::{0}= {1}] [UPDATE FAILURE]", attendanceByShift.AttendanceByShiftId, result);
                                            PublicGlobal.ConsoleWriteline(Loggerline, LoggerMode.INFO);
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Console.Write(e);
                                        SchedulePubBusiness.OnDataLockedChange(scheduleByDayQuery.ScheduleId, false);
                                        SchedulePubBusiness.IsCompletedChange(scheduleByDayQuery.ScheduleId, false);
                                        Loggerline = string.Format("[ERROR::CATCH] [UPDATE] [AttendanceByShift::{0}= {1}] [FAILURE]", attendanceByShift.AttendanceByShiftId, e.Message);
                                        PublicGlobal.ConsoleWriteline(Loggerline, LoggerMode.FATAL);
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                SchedulePubBusiness.OnDataLockedChange(scheduleByDayQuery.ScheduleId, false);
                                SchedulePubBusiness.IsCompletedChange(scheduleByDayQuery.ScheduleId, false);
                                Loggerline = string.Format(" [ERROR::CATCH] [AttendanceByShift::{0}= {1}] [FAILURE]", attendanceByShift.AttendanceByShiftId, e.Message);
                                PublicGlobal.ConsoleWriteline(Loggerline, LoggerMode.FATAL);
                            }
                            finally
                            {
                                calcFoundationData.Dispose();
                                calcAttendanceData.Dispose();
                                Thread.Sleep(64);
                            }
                        }
                    }
                    Thread.Sleep(100);
                }  
            }
        }

        public static List<ScheduleByDayQuery> GetSchduleByDay(DateTime scheduleDate,string CacheName)
        { 
            List<ScheduleByDayQuery> scheduleByDayQueries = new List<ScheduleByDayQuery>();

            if (MemoryCacheHelper.Contains(CacheName) == false)
            {
                using (DataBaseContext databaseContext = new DataBaseContext())
                { 
                    try
                    {
                        var schedules = databaseContext.Schedule.AsNoTracking().Select(c => new { c.ScheduleId, c.ScheduleDate, c.ShiftId, c.EmployeeId,c.WorkStart,c.WorkEnd, c.IsCompleted })
                            .Where(c => c.ScheduleDate== scheduleDate.Date && c.IsCompleted ==false).OrderByDescending(c => c.ScheduleId).ToList();
                        if(schedules!=null)
                        {
                            foreach(var item in schedules)
                            {
                                ScheduleByDayQuery scheduleByDayQuery = new ScheduleByDayQuery
                                {
                                    ScheduleId = item.ScheduleId,
                                    ShiftId = item.ShiftId,
                                    EmployeeId = item.EmployeeId,
                                    ScheduleDate = item.ScheduleDate,
                                    WorkStart = item.WorkStart,
                                    WorkEnd = item.WorkEnd,
                                    IsCompleted = item.IsCompleted
                                };

                                scheduleByDayQueries.Add(scheduleByDayQuery);
                            }
                        }
                        if(schedules!=null)
                        {
                            DateTimeOffset dto = DateTimeOffset.Now.AddHours(1);
                            MemoryCacheHelper.Set(CacheName, scheduleByDayQueries, dto);
                            return scheduleByDayQueries;
                        }else
                        {
                            return null;
                        }
                    }
                    catch (Exception ex)
                    {
                        string loggerLine = string.Format("[GET RANGE OF scheduleByDayQueries Occured EXCEPTION LINE 12312asd][GetSchduleByDay]", ex.Message);
                        CommonBase.OperateDateLoger(loggerLine);
                        //throw ex;
                        return null;
                    }
                }
            }
            else
            {
                scheduleByDayQueries = MemoryCacheHelper.GetCacheItem<List<ScheduleByDayQuery>>(CacheName);
                return scheduleByDayQueries;
            }
        }

        public static List<ShortAttendance> GetScheduleAttendanceLogDateRange(DateTime StartDate,DateTime EndDate)
        {  
            List<ShortAttendance> ScheduleAttendanceLog = new List<ShortAttendance>();

            if (MemoryCacheHelper.Contains("ScheduleAttendanceLog") == false)
            {
                using (DataBaseContext databaseContext = new DataBaseContext())
                {
                    long lStartDate = DateTimeHelp.ConvertDateTimeToLong(StartDate);
                    long lEndDate = DateTimeHelp.ConvertDateTimeToLong(EndDate);
                    try 
                    {
                        var att = databaseContext.AttendanceLog.AsNoTracking().Select(c=>new { c.AttendanceLogId, c.Mode,c.EmployeeId,c.OccurDateTime,c.CratedDateTime }).Where(c => c.OccurDateTime > lStartDate && c.OccurDateTime < lEndDate).ToList();
                        foreach(var item in att)
                        {
                            ShortAttendance shortAttendance = new ShortAttendance { AttendanceLogId = item.AttendanceLogId, EmployeeId = item.EmployeeId, Mode = item.Mode, OccurDateTime = item.OccurDateTime};
                            ScheduleAttendanceLog.Add(shortAttendance);
                        }
                        DateTimeOffset dto = DateTimeOffset.Now.AddHours(12);
                        MemoryCacheHelper.Set("ScheduleAttendanceLog", ScheduleAttendanceLog, dto);
                        return ScheduleAttendanceLog;
                    }
                    catch(Exception ex)
                    { 
                        string loggerLine = string.Format("[GET RANGE OF ScheduleAttendanceLog Occured EXCEPTION LINE 12312asd][GetScheduleAttendanceLogDateRange]", ex.Message);
                        CommonBase.OperateDateLoger(loggerLine);
                        //throw ex;
                        return null;
                    } 
                }
            }
            else
            {
                ScheduleAttendanceLog = MemoryCacheHelper.GetCacheItem<List<ShortAttendance>>("ScheduleAttendanceLog");
                return ScheduleAttendanceLog;
            } 
        }

        public static List<ShortAttendance> GetAttLogDateOptimize(DateTime StartDate, DateTime EndDate,string cacheName)
        { 
            List<ShortAttendance> ScheduleAttendanceLog = new List<ShortAttendance>();

            DateTimeOffset offsetStart = new DateTimeOffset(StartDate);
            long lStartDate = offsetStart.ToUnixTimeMilliseconds();
            DateTimeOffset offsetEndDate = new DateTimeOffset(EndDate);
            long lEndDate = offsetEndDate.ToUnixTimeMilliseconds();

            if (MemoryCacheHelper.Contains(cacheName) == false)
            {
                using (DataBaseContext databaseContext = new DataBaseContext())
                { 
                    var attlogs = databaseContext.AttendanceLog.Select(c => new { c.AttendanceLogId,c.OccurDateTime}).Where(c => c.OccurDateTime > lStartDate && c.OccurDateTime < lEndDate).ToList();
                    foreach (var item in attlogs)
                    {
                        var attx = databaseContext.AttendanceLog.Find(item.AttendanceLogId);
                        if (attx != null)
                        {
                            ShortAttendance shortAttendance = new ShortAttendance { AttendanceLogId = attx.AttendanceLogId, EmployeeId = attx.EmployeeId, Mode = attx.Mode, OccurDateTime = attx.OccurDateTime};
                            ScheduleAttendanceLog.Add(shortAttendance);
                        }
                    }
                    //ONLIY FOR TEXT//REMOVE//REMOVE//REMOVE//REMOVE//REMOVE//REMOVE//REMOVE//REMOVE//REMOVE//REMOVE//REMOVE//REMOVE//REMOVE//REMOVE//REMOVE//REMOVE//REMOVE//REMOVE//REMOVE//REMOVE//REMOVE//REMOVE//REMOVE//REMOVE//REMOVE//REMOVE//REMOVE//REMOVE//REMOVE//REMOVE//REMOVE
                    foreach (var item in ScheduleAttendanceLog)
                    {
                        Console.WriteLine("{0}[KEY::ATTENDANCELOG] [GetAttLogDateOptimize]", JsonConvert.SerializeObject(item));
                    }
                    return ScheduleAttendanceLog;
                }
            }
            else
            {
                ScheduleAttendanceLog = MemoryCacheHelper.GetCacheItem<List<ShortAttendance>>(cacheName);
                return ScheduleAttendanceLog;
            }
        }

        public static Shift GetShiftByMainQuery(ShiftMainQuery shiftMainQuery)
        {
            Shift shift = new Shift
            {
                ShiftId = shiftMainQuery.ShiftId,
                ShiftAbbrId = shiftMainQuery.ShiftAbbrId,
                IconColor = shiftMainQuery.IconColor ?? string.Empty,
                ShiftName = shiftMainQuery.ShiftName ?? string.Empty,
                ShiftBusinessMode = shiftMainQuery.ShiftBusinessMode,
                ShiftAppliedMode = shiftMainQuery.ShiftAppliedMode,
                DepartmentIdArr = shiftMainQuery.DepartmentIdArr ?? string.Empty,
                CompanyName = shiftMainQuery.CompanyName ?? string.Empty,
                WorkTimeSpan = shiftMainQuery.WorkTimeSpan,
                WorkStart = shiftMainQuery.WorkStart,
                WorkEnd = shiftMainQuery.WorkEnd,
                WorkStartAllowance = shiftMainQuery.WorkStartAllowance,
                WorkEndAllowance = shiftMainQuery.WorkEndAllowance,
                WorkStartBuffer = shiftMainQuery.WorkStartBuffer,
                WorkEndBuffer = shiftMainQuery.WorkEndBuffer,
                SpecialWeekDays = shiftMainQuery.SpecialWeekDays ?? string.Empty,
                SpecialWeekDaysWorkStart = shiftMainQuery.SpecialWeekDaysWorkStart,
                SpecialWeekDaysWorkEnd = shiftMainQuery.SpecialWeekDaysWorkEnd,
                ExcludeWeekDay = shiftMainQuery.ExcludeWeekDay ?? string.Empty,
                ExcludeOverTime = shiftMainQuery.ExcludeOverTime ?? string.Empty,
                OverTimeSpan = shiftMainQuery.OverTimeSpan,
                OverTimeStart = shiftMainQuery.OverTimeStart,
                OverTimeEnd = shiftMainQuery.OverTimeEnd,
                OverTimeStartBuffer = shiftMainQuery.OverTimeStartBuffer,
                OverTimeEndBuffer = shiftMainQuery.OverTimeEndBuffer,
                LunchTimeSpan = shiftMainQuery.LunchTimeSpan,
                LunchTimeStart = shiftMainQuery.LunchTimeStart,
                LunchTimeEnd = shiftMainQuery.LunchTimeEnd,
                LunchTimeStartBuffer = shiftMainQuery.LunchTimeStartBuffer,
                LunchTimeEndBuffer = shiftMainQuery.LunchTimeEndBuffer,
                BreakTimeSpan = shiftMainQuery.BreakTimeSpan,
                BreakTimeCalcStart = shiftMainQuery.BreakTimeCalcStart,
                BreakTimeCalcEnd = shiftMainQuery.BreakTimeCalcEnd,
                BreakTimeAllowance = shiftMainQuery.BreakTimeAllowance,
                IsAutoCalcMissing = shiftMainQuery.IsAutoCalcMissing,
                MissingWorkOn = shiftMainQuery.MissingWorkOn,
                MissingWorkOff = shiftMainQuery.MissingWorkOff,
                MissingLunchStart = shiftMainQuery.MissingLunchStart,
                MissingLunchEnd = shiftMainQuery.MissingLunchEnd,
                MissingOverTimeStart = shiftMainQuery.MissingOverTimeStart,
                MissingOverTimeEnd = shiftMainQuery.MissingOverTimeEnd,
                AppliedStartDate = shiftMainQuery.AppliedStartDate,
                AppliedEndDate = shiftMainQuery.AppliedEndDate,
                RuleDescription = shiftMainQuery.RuleDescription ?? string.Empty,
                UpdatedDate = shiftMainQuery.UpdatedDate,
                CreatedDate = shiftMainQuery.CreatedDate,
                OperatedUserName = shiftMainQuery.OperatedUserName ,
                IsApproved = shiftMainQuery.IsApproved
            };
            return shift;
        }

        public static Shift GetShiftById(string shiftId)
        {
            Shift shift = new Shift();
            DataBaseContext dataBaseContext = new DataBaseContext();
            shift = dataBaseContext.Shift.Find(shiftId);
            dataBaseContext.Dispose();
            if (shift == null)
                return null;
             
            return shift;
        }

        public static Schedule GetScheduleById(string scheduleId)
        {
            Schedule schedule = new Schedule();
            DataBaseContext dataBaseContext = new DataBaseContext();
            schedule = dataBaseContext.Schedule.Find(scheduleId);
            dataBaseContext.Dispose();

            if (schedule == null)
                return null;

            return schedule;
        }

        public static Employee GetEmployeeById(string employeeId)
        {
            Employee employee = new Employee();
            DataBaseContext dataBaseContext = new DataBaseContext();
            employee = dataBaseContext.Employee.Find(employeeId);
            dataBaseContext.Dispose();
            if (employee == null)
                return null;

            return employee;
        }
    }

    public class ScheduleByDayQuery
    {
        public string ScheduleId { get; set; }
        public string ShiftId { get; set; } 
        public string EmployeeId { get; set; }
        public DateTime ScheduleDate { get; set; }
        public TimeSpan WorkStart { get; set; }
        public TimeSpan WorkEnd { get; set; }
        public bool IsCompleted { get; set; } 
    }

    public partial class ScheduleAndShiftUtil
    {
        public static string AttendanceByShiftHmac(AttendanceByShift a)
        {
            string HamcContent = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}", a.EmployeeId.Trim(),a.ShiftId, a.WorkStart, a.WorkEnd, a.LunchTimeStart,a.LunchTimeEnd, a.OverTimeStart, a.OverTimeEnd);
            
            string HmacHash = CommonBase.HMACSHA1Encode(HamcContent);
            return HmacHash;
        }
        public static string AttendanceByDayHmac(DbFirst.AttendanceByDay a)
        {
            string HamcContent = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}", a.EmployeeId.Trim(), a.AttendanceByDayId, a.DayShiftNameList, a.DepartmentId, a.HolidayId, a.LeaveId, a.OccurDate, a.DayLateInTimeSpan, a.SysCalcDateTime, a.DayIsLateTimez, a.DayIsEarlyTimez);
             
            string HmacHash = CommonBase.HMACSHA1Encode(HamcContent);
            return HmacHash;
        }
        public static string AttendanceByPeriodHmac(DbFirst.AttendanceByPeriod a)
        {
            string HamcContent = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}", a.EmployeeId.Trim(), a.AttendanceByPeriodId, a.AccuWorkTimeSpan, a.AccuWorkActualNetTimeSpan, a.AccuTimesOfRegular, a.AccuTimesOfRegularWorkOn, a.SysCalcDateTime, a.EmployeeId, a.EmployeeName, a.AccuAbsentDays, a.AccuLeaveDays);
             
            string HmacHash = CommonBase.HMACSHA1Encode(HamcContent);
            return HmacHash;
        }

        //棄用 :: 上班 和 加班 結束 加 隨機秒數 測試不通過，棄用。 新增之前的引用：attendanceByShift = ScheduleAndShiftUtil.CalcFilterAttendanceByShift(attendanceByShift);
        public static AttendanceByShift CalcFilterAttendanceByShift(AttendanceByShift attendanceByShift)
        {
            int rX = int.TryParse(CommonBase.GenerateNumberRandom(1), out int X) == true ? X + 1 : 1;

            attendanceByShift.WorkStart = attendanceByShift.WorkStart.AddSeconds(-rX); 

            attendanceByShift.OverTimeEnd = attendanceByShift.OverTimeEnd.AddSeconds(3 * rX); 

            return attendanceByShift;
        }
    }

    public class ShiftMainQuery
    {
        public string ShiftId { get; set; }
        public string ShiftAbbrId { get; set; }
        public string IconColor { get; set; }
        public string ShiftName { get; set; }
        public int ShiftBusinessMode { get; set; }
        public int ShiftAppliedMode { get; set; }
        public string DepartmentIdArr { get; set; }
        public string CompanyName { get; set; }
        public decimal WorkTimeSpan { get; set; }
        public TimeSpan WorkStart { get; set; }
        public TimeSpan WorkEnd { get; set; }
        public int WorkStartAllowance { get; set; }
        public int WorkEndAllowance { get; set; }
        public int WorkStartBuffer { get; set; }
        public int WorkEndBuffer { get; set; }
        public string SpecialWeekDays { get; set; }
        public TimeSpan SpecialWeekDaysWorkStart { get; set; }
        public TimeSpan SpecialWeekDaysWorkEnd { get; set; }
        public string ExcludeWeekDay { get; set; }
        public string ExcludeOverTime { get; set; }
        public decimal OverTimeSpan { get; set; }
        public TimeSpan OverTimeStart { get; set; }
        public TimeSpan OverTimeEnd { get; set; }
        public int OverTimeStartBuffer { get; set; }
        public int OverTimeEndBuffer { get; set; }
        public decimal LunchTimeSpan { get; set; }
        public TimeSpan LunchTimeStart { get; set; }
        public TimeSpan LunchTimeEnd { get; set; }
        public int LunchTimeStartBuffer { get; set; }
        public int LunchTimeEndBuffer { get; set; }
        public int BreakTimeSpan { get; set; }
        public TimeSpan BreakTimeCalcStart { get; set; }
        public TimeSpan BreakTimeCalcEnd { get; set; }
        public int BreakTimeAllowance { get; set; }
        public bool? IsAutoCalcMissing { get; set; }
        public int MissingWorkOn { get; set; }
        public int MissingWorkOff { get; set; }
        public int MissingLunchStart { get; set; }
        public int MissingLunchEnd { get; set; }
        public int MissingOverTimeStart { get; set; }
        public int MissingOverTimeEnd { get; set; }
        public DateTime AppliedStartDate { get; set; }
        public DateTime AppliedEndDate { get; set; }
        public string RuleDescription { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string OperatedUserName { get; set; }
        public bool IsApproved { get; set; }
    }
}
