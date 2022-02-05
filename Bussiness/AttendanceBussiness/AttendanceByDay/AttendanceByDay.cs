using AttendanceBussiness.DbFirst;
using AttendanceBussiness.ScheduleAndShift;
using Common;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using static AttendanceBussiness.ShiftBusiness;
using static Common.CommonBase;
using System.ComponentModel;
using System.Threading.Tasks;

namespace AttendanceBussiness.AttendanceByDay
{
    public abstract class AttendanceByDayTpl 
    { 
        public static Employee Employee { get; set; }
        public static DateTime ScheduleDate { get; set; }
        public static List<Shift> ScheduleDayShifts { get; set; }
        public static List<AttendanceByShift> DayAttendanceByShifts { get; set; }

        public AttendanceByDayTpl(Employee employee, DateTime scheduleDate, List<Shift> scheduleDayShifts, List<AttendanceByShift> dayAttendanceByShifts)
        {
            Employee = employee;
            ScheduleDate = scheduleDate;
            ScheduleDayShifts = scheduleDayShifts;
            DayAttendanceByShifts = dayAttendanceByShifts;
        }
    }
    public class AttendanceByDayCalcUnit : AttendanceByDayTpl, IDisposable
    {
        private static DateTime _DayScheduleStart;
        private static DateTime _DayScheduleEnd;
        private static TimeSpanBusiness _DayScheduleDatetimeRange;

        private static bool _IsWorkDay;
        private static bool _IsAbsentDay;
        private static Leave _Leave;
        private static string _LeaveId;
        private static int _LeaveType;
        private static string _LeaveTypeName;
        private static int _LeavePaidType;
        private static string _LeavePaidTypeName;
        private static decimal _LeaveWithPaidRatio;
        private static decimal _HolidayWithPaidRatio;
        private static Holiday _Holiday;
        private static string _HolidayId;
        private static string _HolidayName;
        private static int _HolidayPaidType;
        private static string _HolidayPaidTypeName;
        private static bool _IsHoliday = false;

        private static decimal _OnDutyWorkRatioAvg = 0;
        private static decimal _OnDutyPaidRatioAvg = 0;

        public AttendanceByDayCalcUnit(Employee employee, DateTime scheduleDate, List<Shift> scheduleDayShifts, List<AttendanceByShift> dayAttendanceByShifts) : base(employee, scheduleDate, scheduleDayShifts, dayAttendanceByShifts)
        {
            Employee = employee;
            ScheduleDate = scheduleDate;
            ScheduleDayShifts = scheduleDayShifts;
            DayAttendanceByShifts = dayAttendanceByShifts;

            TimeSpan ScheduleWorkStart = ScheduleDayShifts.OrderBy(c => c.WorkStart).FirstOrDefault().WorkStart;
            TimeSpan ScheduleWorkEnd = ScheduleDayShifts.OrderByDescending(c => c.WorkStart).FirstOrDefault().WorkEnd;
            _DayScheduleStart = new DateTime(ScheduleDate.Year, ScheduleDate.Month, ScheduleDate.Day, ScheduleWorkStart.Hours, ScheduleWorkStart.Minutes, ScheduleWorkStart.Seconds);
            _DayScheduleEnd = new DateTime(ScheduleDate.Year, ScheduleDate.Month, ScheduleDate.Day, ScheduleWorkEnd.Hours, ScheduleWorkEnd.Minutes, ScheduleWorkEnd.Seconds);
            _DayScheduleDatetimeRange = new TimeSpanBusiness(_DayScheduleStart, _DayScheduleEnd);
            IsWorkDayBusiness(out _IsWorkDay);
            IsAbsentDayBusiness(out _IsAbsentDay);
            HolidayBusiness();
            LeaveBusiness();
            OnDutyWorkRatioAvgBusiness();
            OnDutyPaidRatioAvgBusiness();
            OccurDate = scheduleDate.Date; 
        }
        public static void IsWorkDayBusiness(out bool _IsWorkDay)
        {
            using (DataBaseContext dataBaseContext = new DataBaseContext())
            {
                var Holidays = dataBaseContext.Holiday.Where(c => c.HolidayDate.Date == ScheduleDate.Date);
                
                if (Holidays.Count() > 0)
                {
                    _IsWorkDay = false;
                }
                else
                {
                    _IsWorkDay = true;
                }
            }
        }
        public static void IsAbsentDayBusiness(out bool _IsAbsentDay)
        {
            using (DataBaseContext dataBaseContext = new DataBaseContext())
            {
                var AttendanceLogs = dataBaseContext.AttendanceLog.Where(c => c.EmployeeId == Employee.EmployeeId && _DayScheduleStart.Date == DateTimeHelp.ConvertLongToDateTime(c.OccurDateTime).Date );
                if (AttendanceLogs.Count() > 0)
                {
                    _IsAbsentDay = false;
                } else
                {
                    _IsAbsentDay = true;
                }
            }
        }
        public static void LeaveBusiness()
        {
            using (DataBaseContext dataBaseContext = new DataBaseContext())
            {
                var leaves = dataBaseContext.Leave.Where(c => c.LeaveStartDate <= _DayScheduleDatetimeRange.StartTime && c.LeaveEndDate >= _DayScheduleDatetimeRange.EndTime   && c.EmployeeId == Employee.EmployeeId);
                
                if (leaves.Count() > 0)
                {
                    _Leave = leaves.FirstOrDefault();
                    _LeaveId = _Leave.LeaveId;
                    _LeaveType = _Leave.LeaveType;

                    ShiftBusiness.LeaveType leaveType = (ShiftBusiness.LeaveType)_LeaveType;
                    _LeaveTypeName = leaveType.GetDescription();

                    _IsWorkDay = false;
                    _LeavePaidType = _Leave.LeavePaidType;
                    ShiftBusiness.LeavePaidType leavePaidType = (ShiftBusiness.LeavePaidType)_Leave.LeavePaidType;
                    _LeavePaidTypeName = leavePaidType.GetDescription();
                    if (_IsAbsentDay == true)
                    {
                        if (leavePaidType == ShiftBusiness.LeavePaidType.PAID_LEAVE)
                        {
                            _LeaveWithPaidRatio = 1;
                            _OnDutyWorkRatioAvg = 1;
                            _OnDutyPaidRatioAvg = 1;
                        }
                    }
                }
                else
                {
                    _LeaveId = string.Empty;
                    _LeaveType = -1;
                    _LeaveTypeName = string.Empty;
                    _LeavePaidType = -1;
                    _LeavePaidTypeName = string.Empty;
                    _LeaveWithPaidRatio = 0;
                    _Leave = new Leave 
                    { 
                        LeaveId = _LeaveId,
                        LeaveType = _LeaveType,
                        EmployeeId = Employee.EmployeeId,
                        EmployeeName = Employee.FullName,
                        LeaveStartDate = DateTimeHelp.DT1970,
                        LeaveEndDate = DateTimeHelp.DT1970,
                        MainComId = Employee.MainComId,
                        TotalDays = 0,
                        Reason = string.Empty,
                        IsApproved = true,
                        ApprovedRemarks = string.Empty ,
                        ApplovedBy = "SYSTEM",
                        OperatedUserName = "SYSTEM",
                        CreatedDate = DateTime.Now,
                        LeavePaidType = _LeavePaidType
                    };
                }
            }
        }
        public static void HolidayBusiness()
        {
            using (DataBaseContext dataBaseContext = new DataBaseContext())
            {
                _Holiday = dataBaseContext.Holiday.Where(c => c.HolidayDate.Date == ScheduleDate.Date).FirstOrDefault();
                if (_Holiday != null)
                {
                    switch ((HolidayIsWholeDayType)_Holiday.IsWholeDay)
                    {
                        case HolidayIsWholeDayType.WHOLE_DAY:
                            _IsHoliday = true; ;
                            break;
                        case HolidayIsWholeDayType.ONLY_MORNING:
                            _IsHoliday = _DayScheduleStart.Hour < 12 ? true : false;
                            break;
                        case HolidayIsWholeDayType.ONLY_AFTERNOON:
                            _IsHoliday = _DayScheduleStart.Hour > 12 ? true : false;
                            break;
                        default:
                            _IsHoliday = false;
                            break;
                    }
                }
                else
                {
                    _IsHoliday = false;
                }

                if (_IsHoliday)
                {
                    _HolidayId = _Holiday.HolidayId;
                    _HolidayName = _Holiday.HolidayName;
                    _HolidayPaidType = _Holiday.HolidayPaidType;
                    _HolidayPaidTypeName = _Holiday.HolidayPaidTypeName;
                    _HolidayWithPaidRatio = _Holiday.OnDutyPaidRatio;

                    //---------------------------------------------------
                    
                    _LeaveId = string.Empty;
                    _LeaveType = _Leave != null ? _Leave.LeaveType : -1;
                    _LeaveTypeName = string.Empty;
                    _LeavePaidType = -1;
                    _LeavePaidTypeName = string.Empty;
                    //---------------------------------------------------
                    _IsWorkDay = false;
                }
                else
                {
                    _HolidayId = string.Empty;
                    _HolidayName = string.Empty;
                    _HolidayPaidType = -1;
                    _HolidayPaidTypeName = string.Empty;
                    _HolidayWithPaidRatio = 1;
                }
            }
        }

        public static void OnDutyWorkRatioAvgBusiness()
        {
            decimal OnDutyWorkRatioTotal = DayAttendanceByShifts.Sum(c => c.OnDutyWorkRatio);
            int record = DayAttendanceByShifts.Count();
            _OnDutyWorkRatioAvg = OnDutyWorkRatioTotal / (decimal)record;
        }
        public static void OnDutyPaidRatioAvgBusiness()
        {
            decimal OnDutyPaidRatioTotal = DayAttendanceByShifts.Sum(c => c.OnDutyPaidRatio);
            int record = DayAttendanceByShifts.Count();
            _OnDutyPaidRatioAvg = OnDutyPaidRatioTotal / (decimal)record;
            //_OnDutyPaidRatioAvg = _OnDutyPaidRatioAvg > 1 ? 1 : _OnDutyPaidRatioAvg;
        }
        public string AttendanceByDayId
        {
            get
            {
                return string.Format("{0:yyyyMMdd}{1}", ScheduleDate, Employee.EmployeeId);
            }
        }
        public string MainComId {
            get
            {
                return Employee.MainComId;
            }
        }
        public string ShiftIdArr {
            get
            {
                string shifIdArr = ScheduleDayShifts.Select(c => c.ShiftAbbrId).Join(",");
                return shifIdArr;
            }
        }
        public string EmployeeId
        {
            get
            {
                return Employee.EmployeeId;
            }
        }
        public string EmployeeName
        {
            get
            {
                return Employee.FullName;
            }
        }
        public string DepartmentId
        {
            get
            {
                return Employee.DepartmentId;
            }
        }
        public string DepartmentName
        {
            get
            {
                return Employee.DepartmentName;
            }
        }
        public string PositionId
        {
            get
            {
                return Employee.PositionId;
            }
        }
        public string PositionTitle
        {
            get
            {
                return Employee.PositionTitle;
            }
        }
        public string ContractorId
        {
            get
            {
                return Employee.ContractorId;
            }
        }
        public string ContractorName
        {
            get
            {
                return Employee.ContractorName;
            }
        }
        public string JobId
        {
            get
            {
                return Employee.JobId;
            }
        }
        public string JobName
        {
            get
            {
                return Employee.JobName;
            }
        }
        public string SiteId
        {
            get
            {
                return Employee.SiteId;
            }
        }
        public string SiteName
        {
            get
            {
                return Employee.SiteName;
            }
        }
        public bool IsWorkDay
        {
            get
            {
                return _IsWorkDay;
            }
        }
        public bool IsAbsentDay
        {
            get
            {
                return _IsAbsentDay;
            }
        }
        public string DayShiftNameList {
            get
            { 
                return string.Empty;
            }
        }
        public string DayShiftListJson
        {
            get
            {
                string JsonDayShiftNameList = "";
                JsonDayShiftNameList = JsonConvert.SerializeObject(ScheduleDayShifts);
                return JsonDayShiftNameList;
            }
        }
         
        public TimeSpan DayTotalWorkTimeSpan
        {
            get
            {
                decimal workTimeSpan = DayAttendanceByShifts.Sum(c => c.WorkTimeSpan);
                TimeSpan timeSpan = TimeSpan.FromHours((double)workTimeSpan);
                return timeSpan;
            }
        }
        //-----------------------------------------------------------------------------------------------------------------------------
        public TimeSpan DayTotalWorkNetTimeSpan
        {
            get
            {
                decimal WorkActualNetTimeSpan = DayAttendanceByShifts.Sum(c => c.WorkActualNetTimeSpan);
                TimeSpan timeSpan = TimeSpan.FromMinutes((double)WorkActualNetTimeSpan);
                return timeSpan;
            }
        }

        public TimeSpan DayTotalLunchTimeSpan
        {
            get
            {
               
                decimal _dayTotalLunchTimeSpan = 0;
                DayAttendanceByShifts.ForEach(c =>
                {
                    _dayTotalLunchTimeSpan = _dayTotalLunchTimeSpan + c.LunchTimeSpan;
                });

                TimeSpan timeSpan = TimeSpan.FromMinutes((double)_dayTotalLunchTimeSpan);
                return timeSpan;
            }
        }

        public TimeSpan DayTotalOverTimeSpan
        {
            get
            {
                decimal _dayTotalOverTimeSpan = 0;
                DayAttendanceByShifts.ForEach(c =>
                {
                    _dayTotalOverTimeSpan = _dayTotalOverTimeSpan + c.OverTimeSpan;
                });
                TimeSpan timeSpan = TimeSpan.FromMinutes((double)_dayTotalOverTimeSpan);
                return timeSpan;
            }
        }
        public int DayLateInTimeSpan
        {
            get
            {
                int SumDayLateIn = 0;
                var dayLateInTimeSpanCollection = DayAttendanceByShifts.Where(c => c.IsLate == (int)AttendanceType.IS_LATE).ToList();
                dayLateInTimeSpanCollection.ForEach(c =>
                {
                    SumDayLateIn = SumDayLateIn + c.LateIn; 
                });
                return SumDayLateIn;
            }
        }
        public int DayIsLateTimez
        {
            get
            { 
                var dayIsLateTimezCollection = DayAttendanceByShifts.Where(c => c.IsLate == (int)AttendanceType.IS_LATE);
                int dayIsLateTimez = dayIsLateTimezCollection.Count(); 
                return dayIsLateTimez;
            }
        }
        public int DayEarlyOutTimeSpan
        {
            get
            {
                var dayEarlyOutTimeSpanCollection = DayAttendanceByShifts.Where(c => c.IsEarly == (int)AttendanceType.IS_EARLY).ToList(); 
                int dayEarlyOutTimeSpan = 0;
                dayEarlyOutTimeSpanCollection.ForEach(c =>
                {
                    dayEarlyOutTimeSpan = dayEarlyOutTimeSpan + c.EarlyOut;
                });
                return dayEarlyOutTimeSpan;
            }
        }
        public int DayIsEarlyTimez
        {
            get
            {
                int dayIsEarlyTimez = DayAttendanceByShifts.Where(c => c.IsEarly == (int)AttendanceType.IS_EARLY).Count();
                return dayIsEarlyTimez;
            }
        } 
        //-----------------------------------------------------------------------------------------------------------------------------
        public int DayLunchLateInTimeSpan
        {
            get
            { 
                var dayLunchLateInTimeSpanCollection = DayAttendanceByShifts.Where(c => c.LunchTimeIsLate == (int)AttendanceType.IS_LATE).ToList();
                int dayLunchLateInTimeSpan = 0;
                dayLunchLateInTimeSpanCollection.ForEach(c =>
                {
                    dayLunchLateInTimeSpan = dayLunchLateInTimeSpan + c.LunchTimeLateIn;
                });
                return dayLunchLateInTimeSpan;
            }
        }
        public int DayLunchIsLateTimez {
            get
            {
                int dayLunchIsLateTimez = DayAttendanceByShifts.Where(c => c.LunchTimeIsLate == (int)AttendanceType.IS_LATE).Count();
                return dayLunchIsLateTimez;
            }
        }
        public int DayLunchEarlyOutTimeSpan
        {
            get
            {
                var dayLunchEarlyOutTimeSpanCollection = DayAttendanceByShifts.Where(c => c.LunchTimeIsEarly == (int)AttendanceType.IS_EARLY).ToList();
                int dayLunchEarlyOutTimeSpan = 0;
                dayLunchEarlyOutTimeSpanCollection.ForEach(c =>
                {
                    dayLunchEarlyOutTimeSpan = dayLunchEarlyOutTimeSpan + c.LunchTimeEarlyOut;
                });
                return dayLunchEarlyOutTimeSpan;
            }
        }
        public int DayLunchIsEarlyTimez
        {
            get
            {
                int dayOverTimeIsEarlyTimez = DayAttendanceByShifts.Where(c => c.LunchTimeIsEarly == (int)AttendanceType.IS_EARLY).Count();
                return dayOverTimeIsEarlyTimez;
            }
        }
        //-----------------------------------------------------------------------------------------------------------------------------
        public int DayOverTimeLateInTimeSpan
        {
            get
            { 
                var dayOverTimeLateInTimeSpanCollection = DayAttendanceByShifts.Where(c => c.OverTimeIsLate == (int)AttendanceType.IS_LATE).ToList();
                int dayOverTimeLateInTimeSpan = 0;
                dayOverTimeLateInTimeSpanCollection.ForEach(c =>
                {
                    dayOverTimeLateInTimeSpan = dayOverTimeLateInTimeSpan + c.OverTimeLateIn;
                });
                return dayOverTimeLateInTimeSpan;
            }
        }
        public int DayOverTimeIsLateTimez
        {
            get
            {
                int dayLunchIsLateTimez = DayAttendanceByShifts.Where(c => c.OverTimeIsLate == (int)AttendanceType.IS_LATE).Count();
                return dayLunchIsLateTimez;
            }
        }
        public int DayOverTimeEarlyOutTimeSpan
        {
            get
            {
                var dayOverTimeEarlyOutTimeSpanCollection = DayAttendanceByShifts.Where(c => c.OverTimeIsEarly == (int)AttendanceType.IS_EARLY).ToList();
                int dayOverTimeEarlyOutTimeSpan = 0;
                dayOverTimeEarlyOutTimeSpanCollection.ForEach(c =>
                {
                    dayOverTimeEarlyOutTimeSpan = dayOverTimeEarlyOutTimeSpan + c.OverTimeEarlyOut;
                });
                return dayOverTimeEarlyOutTimeSpan;
            }
        }
        public int DayOverTimeIsEarlyTimez
        {
            get
            {
                int dayOverTimeIsEarlyTimez = DayAttendanceByShifts.Where(c => c.OverTimeIsEarly == (int)AttendanceType.IS_EARLY).Count();
                return dayOverTimeIsEarlyTimez;
            }
        }
        //-----------------------------------------------------------------------------------------------------------------------------
        public int DayMissingWorkOnTimez
        {
            get
            {
                int totalMissingWorkOn = DayAttendanceByShifts.Where(c => c.IsAutoMissingWorkOn).Count();
                return totalMissingWorkOn;
            }
        }
        public int DayMissingWorkOffTimez
        {
            get
            {
                int totalMissingWorkOff = DayAttendanceByShifts.Where(c => c.IsAutoMissingWorkOff).Count();
                return totalMissingWorkOff;
            }
        }
        public int DayMissingLunchStartTimez
        {
            get
            {
                int totalMissingLunchStart = DayAttendanceByShifts.Where(c => c.IsAutoMissingLunchStart).Count();
                return totalMissingLunchStart;
            }
        }
        public int DayMissingLunchEndTimez
        {
            get
            {
                int totalMissingLunchEnd = DayAttendanceByShifts.Where(c =>c.IsAutoMissingLunchEnd).Count();
                return totalMissingLunchEnd;
            }
        }
        public int DayMissingOverTimeStartTimez
        {
            get
            {
                int totalMissingOverTimeStart = DayAttendanceByShifts.Where(c => c.IsAutoMissingOverTimeStart).Count();
                return totalMissingOverTimeStart;
            }
        }
        public int DayMissingOverTimeEndTimez
        {
            get
            {
                int totalMissingOverTimeEnd = DayAttendanceByShifts.Where(c => c.IsAutoMissingOverTimeEnd).Count();
                return totalMissingOverTimeEnd;
            }
        }
        //Regular-----------------------------------------------------------------------------------------------------------------------------
        public int TotalTimesOfRegularWorkOn
        {
            get
            { 
                return 0;
            }
        }
        public int TotalTimesOfRegularWorkOff
        {
            get
            {
                int result = DayAttendanceByShifts.Where(c => c.IsRegularManualMissingWorkOff).Count();
                return result;
            }
        }
        public int TotalTimesOfRegularLunchStart
        {
            get
            {
                int result = DayAttendanceByShifts.Where(c => c.IsRegularManualMissingLunchStart).Count();
                return result;
                ;
            }
        }
        public int TotalTimesOfRegularLunchEnd
        {
            get
            {
                int result = DayAttendanceByShifts.Where(c => c.IsRegularManualMissingLunchEnd).Count();
                return result;
            }
        }
        public int TotalTimesOfRegularOverTimeStart
        {
            get
            {
                int result = DayAttendanceByShifts.Where(c => c.IsRegularManualMissingOverTimeStart).Count();
                return result;
            }
        }
        public int TotalTimesOfRegularOverTimeEnd
        {
            get
            {
                int result = DayAttendanceByShifts.Where(c => c.IsRegularManualMissingOverTimeEnd).Count();
                return result;
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------
        public string LeaveId
        {
            get
            {
                return _LeaveId;
            }
        }
        public int LeaveType {
            get
            {
                return _LeaveType;
            }
        }
        public string LeaveTypeName
        {
            get
            {
                return _LeaveTypeName;
            }
        }
        public int LeavePaidType
        {
            get
            {
                return _LeavePaidType;
            }
        }
        public string LeavePaidTypeName
        {
            get
            {
                return _LeavePaidTypeName;
            }
        }
        public decimal LeaveWithPaidRatio
        {
            get
            {
                return _LeaveWithPaidRatio;
            }
        } 
        public string HolidayId
        {
            get
            {
                return _HolidayId;
            }
        }
        public string HolidayName
        {
            get
            {
                return _HolidayName;
            }
        }
        public int HolidayPaidType
        {
            get
            {
                return _HolidayPaidType;
            }
        }
        public string HolidayPaidTypeName
        {
            get
            {
                return _HolidayPaidTypeName;
            }
        }
        public decimal HolidayWithPaidRatio
        {
            get
            {
                return _HolidayWithPaidRatio;
            }
        }
        public decimal OnDutyWorkRatioAvg
        {
            get
            {
                return _OnDutyWorkRatioAvg;
            }
        }
        public decimal OnDutyPaidRatioAvg
        {
            get
            {
                return _OnDutyPaidRatioAvg;
            }
        }
        public int CalcPeriodType { get; set; }
        [DefaultValue(false)]
        public bool OnDataLocked { get; set; }
        [DefaultValue(false)]
        public bool IsCompleted { get; set; }
        public DateTime SysCalcDateTime { get; set; } = DateTime.Now;
        public DateTime OccurDate { get; set; }
        public string HmacHash { get; set; }

        private bool _disposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            throw new NotImplementedException();
        }
        protected virtual void Dispose(bool disposing)
        {
            // If you need thread safety, use a lock around these 
            // operations, as well as in your methods that use the resource.
            if (!_disposed)
            {
                if (disposing)
                {
                    Console.Out.WriteLineAsync(string.Format("[{0:yyyy-MM-dd HH:mm:ss fff}] [INFO] [AttendanceByDayTpl::{1}] ", DateTime.Now, "DISPOSED"));
                }
                _disposed = true;
            }
        }
    } 
}
