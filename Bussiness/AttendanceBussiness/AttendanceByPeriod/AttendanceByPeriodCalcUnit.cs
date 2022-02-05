using System; 
using System.Text;
using AttendanceBussiness.DbFirst;
using AttendanceBussiness.ScheduleAndShift;
using Common;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json; 
using System.Collections.Generic;
using System.IO;
using System.Linq; 
using System.Threading;
using static AttendanceBussiness.ShiftBusiness;
using Microsoft.EntityFrameworkCore;
namespace AttendanceBussiness.AttendanceByPeriod
{
    public partial class AttendanceByPeriodCalcUnit
    {
        private DateTime _CurrentMonth;
        public DateTime CurrentMonth
        {
            get
            {
                return _CurrentMonth;
            }
            set
            {
                _CurrentMonth = value;
            }
        }
        private bool _HasRecords;
        private Employee _Employee;
        private List<DbFirst.AttendanceByShift> _AttendanceByShifts = new List<AttendanceByShift>(); 
        private List<DbFirst.AttendanceByDay> _AttendanceByDays = new List<DbFirst.AttendanceByDay>();
        private List<DbFirst.Leave> _Leaves = new List<DbFirst.Leave>();
        private List<DbFirst.Holiday> _Holidays = new List<DbFirst.Holiday>();

        //REGULAR
        private int _RegularManualMissingWorkOn = 0;
        private int _RegularManualMissingWorkOff = 0;
        private int _RegularManualMissingLunchStart = 0;
        private int _RegularManualMissingLunchEnd = 0;
        private int _RegularManualMissingOverTimeStart = 0;
        private int _RegularManualMissingOverTimeEnd = 0;
        //AUTO_MISSING
        private int _AutoMissingWorkOn = 0;
        private int _AutoMissingWorkOff = 0;
        private int _AutoMissingLunchStart = 0;
        private int _AutoMissingLunchEnd = 0;
        private int _AutoMissingOverTimeStart = 0;
        private int _AutoMissingOverTimeEnd = 0;
        public AttendanceByPeriodCalcUnit(ShiftBusiness.CalcPeriodType calcPeriodType,Employee employee,DateTime currentMonth)
        {
            //MODE
            _Mode = (int)DataToObjectMode.MONTHLY_DTO;
            CurrentMonth = currentMonth;

            //AttendanceByPeriodId
            if (calcPeriodType == ShiftBusiness.CalcPeriodType.MONTHLY)
            {
                _AttendanceByPeriodId = string.Format("{0:yyyyMM}M{1}", CurrentMonth, employee.EmployeeId);
            }
            //PERIOD------------------------------------------------------------------------------------------------------------------------------------- 
            _StartDate = new DateTime(CurrentMonth.Year, CurrentMonth.Month, 1, 0, 0, 0);
            _EndDate = GetRealEndDateTime(CurrentMonth); 
            //INITIALIZE---------------------------------------------------------------------------------------------------------------------------------
            _Employee = employee;

            using (DataBaseContext dataBaseContext =new DataBaseContext())
            {
                _AttendanceByShifts = dataBaseContext.AttendanceByShift.AsNoTracking().Where(c => c.EmployeeId == employee.EmployeeId && c.ScheduleDate.Date >= _StartDate && c.ScheduleDate <= _EndDate && c.IsCompleted == true).ToList();

                _AttendanceByDays = dataBaseContext.AttendanceByDay.AsNoTracking().Where(c => c.EmployeeId == employee.EmployeeId && c.OccurDate.Date >= _StartDate && c.OccurDate <= _EndDate && c.IsCompleted == false).ToList(); //FALSE
                _HasRecords = _AttendanceByDays.Count > 0 ? true : false;

                _Leaves = dataBaseContext.Leave.AsNoTracking().Where(c => c.EmployeeId == employee.EmployeeId && c.LeaveStartDate.Date >= _StartDate && c.LeaveEndDate <= _EndDate && c.IsApproved == true && c.ApplovedBy.Trim() != "0").ToList();

                _Holidays = dataBaseContext.Holiday.AsNoTracking().Where(c=> c.HolidayDate.Date >= _StartDate && c.HolidayDate <= _EndDate).ToList();
            }
            //SYSTEM-------------------------------------------------------------------------------------------------------------------------------------

            //Employee Details
            _MainComId = employee.MainComId;
            _CalcPeriodType = (int)calcPeriodType;
            _EmployeeId = employee.EmployeeId;
            _EmployeeName = CommonBase.StringNullRet(employee.FullName);
            _DepartmentId = CommonBase.StringNullRet(employee.DepartmentId);
            _DepartmentName = CommonBase.StringNullRet(employee.DepartmentName);
            _PositionId = CommonBase.StringNullRet(employee.PositionId);
            _PositionTitle = CommonBase.StringNullRet(employee.PositionTitle);
            _ContractorId = CommonBase.StringNullRet(employee.ContractorId);
            _ContractorName = CommonBase.StringNullRet(employee.ContractorName);
            _JobId = CommonBase.StringNullRet(employee.JobId);
            _JobName = CommonBase.StringNullRet(employee.JobName);
            _SiteId = CommonBase.StringNullRet(employee.SiteId);
            _SiteName = CommonBase.StringNullRet(employee.SiteName);

            if(_HasRecords)
            {
                //REGULAR-------------------------------------------------------------------------------------------------------------------------------------
                //WorkOn | RegularManualMissingWorkOn
                _RegularManualMissingWorkOn = 0;
                //WorkOff | RegularManualMissingWorkOff
                _RegularManualMissingWorkOff =0;
                //LunchStart | IsRegularManualMissingLunchStart
                _RegularManualMissingLunchStart = 0;
                //LunchEnd | IsRegularManualMissingLunchEnd
                _RegularManualMissingLunchEnd = 0;
                //OverTimeStart | IsRegularManualMissingOverTimeStart
                _RegularManualMissingOverTimeStart = 0;
                //OverTimeEnd | IsRegularManualMissingOverTimeEnd
                _RegularManualMissingOverTimeEnd = 0;

                //MISSING-------------------------------------------------------------------------------------------------------------------------------------
                //WorkOn | AutoMissingWorkOn
                _AutoMissingWorkOn = 0;
                //WorkOff | RegularManualMissingWorkOff
                _AutoMissingWorkOff = 0;
                //LunchStart | IsRegularManualMissingLunchStart
                _AutoMissingLunchStart = 0;
                //LunchEnd | IsRegularManualMissingLunchEnd
                _AutoMissingLunchEnd =0;
                //OverTimeStart | IsRegularManualMissingOverTimeStart
                _AutoMissingOverTimeStart =0;
                //OverTimeEnd | IsRegularManualMissingOverTimeEnd
                _AutoMissingOverTimeEnd = 0;
            } 
        }

        #region
        private string _AttendanceByPeriodId;
        public string AttendanceByPeriodId
        {
            get
            {
                return _AttendanceByPeriodId;
            }
            set
            {
                _AttendanceByPeriodId = value;
            }
        }

        private int _Mode;
        public int Mode
        {
            get
            {
                return _Mode;
            }
            set
            {
                _Mode = value;
            }
        }

        private string _MainComId;
        public string MainComId
        {
            get
            {
                return _MainComId;
            }
            set
            {
                _MainComId = value;
            }
        }

        private int _CalcPeriodType;
        public int CalcPeriodType
        {
            get
            {
                return _CalcPeriodType;
            }
            set
            {
                _CalcPeriodType = value;
            }
        }

        private string _EmployeeId;
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

        private string _EmployeeName;
        public string EmployeeName
        {
            get
            {
                return _EmployeeName;
            }
            set
            {
                _EmployeeName = value;
            }
        }

        private string _DepartmentId;
        public string DepartmentId
        {
            get
            {
                return _DepartmentId;
            }
            set
            {
                _DepartmentId = value;
            }
        }

        private string _DepartmentName; 
        public string DepartmentName
        {
            get
            {
                return _DepartmentName;
            }
            set
            {
                _DepartmentName = value;
            }
        }

        private string _PositionId;
        public string PositionId
        {
            get
            {
                return _PositionId;
            }
            set
            {
                _PositionId = value;
            }
        }

        private string _PositionTitle;
        public string PositionTitle
        {
            get
            {
                return _PositionTitle;
            }
            set
            {
                _PositionTitle = value;
            }
        }

        private string _ContractorId;
        public string ContractorId
        {
            get
            {
                return _ContractorId;
            }
            set
            {
                _ContractorId = value;
            }
        }

        private string _ContractorName;
        public string ContractorName
        {
            get
            {
                return _ContractorName;
            }
            set
            {
                _ContractorName = value;
            }
        }

        private string _JobId;
        public string JobId
        {
            get
            {
                return _JobId;
            }
            set
            {
                _JobId = value;
            }
        }

        private string _JobName;
        public string JobName
        {
            get
            {
                return _JobName;
            }
            set
            {
                _JobName = value;
            }
        }

        private string _SiteId;
        public string SiteId
        {
            get
            {
                return _SiteId;
            }
            set
            {
                _SiteId = value;
            }
        }

        private string _SiteName;
        public string SiteName
        {
            get
            {
                return _SiteName;
            }
            set
            {
                _SiteName = value;
            }
        }

        #endregion

        private TimeSpan _AvgWorkActualNetTimeSpan;
        public TimeSpan AvgWorkActualNetTimeSpan
        {
            get
            {
                return TimeSpan.FromHours(8); 
            }
            set
            {
                _AvgWorkActualNetTimeSpan = value;
            }
        }

        private TimeSpan _AccuWorkActualNetTimeSpan;
        public TimeSpan AccuWorkActualNetTimeSpan
        {
            get
            {
                return TimeSpan.FromHours(8);
            }
            set
            {
                _AccuWorkActualNetTimeSpan = value;
            }
        }

        private TimeSpan _AvgWorkTimeSpan;
        public TimeSpan AvgWorkTimeSpan
        {
            get
            {
                return TimeSpan.FromHours(8);
            }
            set
            {
                _AvgWorkTimeSpan = value;
            }
        }

        private TimeSpan _AccuWorkTimeSpan;
        public TimeSpan AccuWorkTimeSpan
        {
            get
            {
                return TimeSpan.FromHours(8); ;
            }
            set
            {
                _AccuWorkTimeSpan = value;
            }
        }

        private TimeSpan _AvgLunchTimeSpan;
        public TimeSpan AvgLunchTimeSpan
        {
            get
            {
                return TimeSpan.FromHours(1); ;
            }
            set
            {
                _AvgLunchTimeSpan = value;
            }
        }

        private TimeSpan _AccuLunchTimeSpan;
        public TimeSpan AccuLunchTimeSpan
        {
            get
            {
                return TimeSpan.FromHours(1); ;
            }
            set
            {
                _AccuLunchTimeSpan = value;
            }
        }

        private TimeSpan _AvgOverTimeSpan;
        public TimeSpan AvgOverTimeSpan
        {
            get
            {
                return TimeSpan.FromHours(1); ;
            }
            set
            {
                _AvgOverTimeSpan = value;
            }
        }

        private TimeSpan _AccuOverTimeSpan;
        public TimeSpan AccuOverTimeSpan
        {
            get
            {
                return TimeSpan.FromHours(1); ;
            }
            set
            {
                _AccuOverTimeSpan = value;
            }
        }

        private decimal _AccuLeaveDays;
        public decimal AccuLeaveDays
        {
            get
            {
                return 0;
            }
            set
            {
                _AccuLeaveDays = value;
            }
        }

        private decimal _AccuHolidays;
        public decimal AccuHolidays
        {
            get
            {
                return 0;
            }
            set
            {
                _AccuHolidays = value;
            }
        }

        private decimal _AccuWorkDays;
        public decimal AccuWorkDays
        {
            get
            {
                return 0;
            }
            set
            {
                _AccuWorkDays = value;
            }
        }
        private decimal _AccuAbsentDays;
        public decimal AccuAbsentDays
        {
            get
            {
                return 0;
            }
            set
            {
                _AccuAbsentDays = value;
            }
        }

        private int _AccuTimesOfLateIn;
        public int AccuTimesOfLateIn
        {
            get
            {
                return 0;
            }
            set
            {
                _AccuTimesOfLateIn = value;
            }
        }

        private TimeSpan _AccuLateInTimeSpan;
        public TimeSpan AccuLateInTimeSpan
        {
            get
            {
                return TimeSpan.FromSeconds(0);
            }
            set
            {
                _AccuLateInTimeSpan = value;
            }
        }

        private int _AccuTimesOfEarlyOut;
        public int AccuTimesOfEarlyOut
        {
            get
            {
                return 0;
            }
            set
            {
                _AccuTimesOfEarlyOut = value;
            }
        }

        private TimeSpan _AccuEarlyOutTimeSpan;
        public TimeSpan AccuEarlyOutTimeSpan
        {
            get
            {
                if (!_HasRecords)
                {
                    return new TimeSpan(0,0,0);
                }
                else
                {
                    int _AccuEarlyOutTimeSpanD = _AttendanceByDays.Sum(c => c.DayEarlyOutTimeSpan);
                    _AccuEarlyOutTimeSpan = TimeSpan.FromMinutes(_AccuEarlyOutTimeSpanD);
                    return _AccuEarlyOutTimeSpan;
                } 
            }
            set
            {
                _AccuEarlyOutTimeSpan = value;
            }
        }

        private int _AccuTimesOfLunchLateIn;
        public int AccuTimesOfLunchLateIn
        {
            get
            {
                if (!_HasRecords)
                {
                    return 0;
                }
                else
                {
                    int _AccuTimesOfLunchLateInD = _AttendanceByDays.Sum(c => c.DayLunchLateInTimeSpan);
                    _AccuTimesOfLunchLateIn = _AccuTimesOfLunchLateInD; 
                    return _AccuTimesOfLunchLateIn;
                }
            }
            set
            {
                _AccuTimesOfLunchLateIn = value;
            }
        }

        private TimeSpan _AccuLunchLateInTimeSpan;
        public TimeSpan AccuLunchLateInTimeSpan
        {
            get
            {
                return _AccuLunchLateInTimeSpan;
            }
            set
            {
                _AccuLunchLateInTimeSpan = value;
            }
        }

        private int _AccuTimesOfLunchEarlyOut;
        public int AccuTimesOfLunchEarlyOut
        {
            get
            {
                if (!_HasRecords)
                {
                    return 0;
                }
                else
                {
                    int _AccuTimesOfLunchEarlyOutD = _AttendanceByDays.Sum(c => c.DayLunchIsEarlyTimez);
                    _AccuTimesOfLunchEarlyOut = _AccuTimesOfLunchEarlyOutD;
                    return _AccuTimesOfLunchEarlyOut;
                }
            }
            set
            {
                _AccuTimesOfLunchEarlyOut = value;
            }
        }

        private TimeSpan _AccuEarlyLunchOutTimeSpan;
        public TimeSpan AccuEarlyLunchOutTimeSpan
        {
            get
            {
                if (!_HasRecords)
                {
                    return new TimeSpan(0, 0, 0);
                }
                else
                {
                    int _AccuEarlyLunchOutTimeSpanD = _AttendanceByDays.Sum(c => c.DayLunchEarlyOutTimeSpan);
                    _AccuEarlyLunchOutTimeSpan = TimeSpan.FromMinutes(_AccuEarlyLunchOutTimeSpanD);
                    return _AccuEarlyLunchOutTimeSpan;
                } 
            }
            set
            {
                _AccuEarlyLunchOutTimeSpan = value;
            }
        }

        private int _AccuTimesOfOverTimeLateIn;
        public int AccuTimesOfOverTimeLateIn {

            get
            {
                if (!_HasRecords)
                {
                    return 0;
                }
                else
                {
                    int _AccuTimesOfOverTimeLateInD = _AttendanceByDays.Sum(c => c.DayOverTimeIsLateTimez);
                    _AccuTimesOfOverTimeLateIn = _AccuTimesOfOverTimeLateInD;
                    return _AccuTimesOfOverTimeLateIn;
                } 
            }
            set
            {
                _AccuTimesOfOverTimeLateIn = value;
            }
        
        }

        private TimeSpan _AccuOverTimeLateInTimeSpan;
        public TimeSpan AccuOverTimeLateInTimeSpan
        {

            get
            {
                if (!_HasRecords)
                {
                    return new TimeSpan(0, 0, 0);
                }
                else
                {
                    int _AccuOverTimeLateInTimeSpanD = _AttendanceByDays.Sum(c => c.DayOverTimeLateInTimeSpan);
                    _AccuOverTimeLateInTimeSpan = TimeSpan.FromMinutes(_AccuOverTimeLateInTimeSpanD);
                    return _AccuOverTimeLateInTimeSpan;
                } 
            }
            set
            {
                _AccuOverTimeLateInTimeSpan = value;
            }

        }
        private int _AccuTimesOfOverTimeEarlyOut;
        public int AccuTimesOfOverTimeEarlyOut
        { 
            get
            {
                if (!_HasRecords)
                {
                    return 0;
                }
                else
                {
                    int _AccuTimesOfOverTimeEarlyOutD = _AttendanceByDays.Sum(c => c.DayOverTimeEarlyOutTimeSpan);
                    _AccuTimesOfOverTimeEarlyOut = _AccuTimesOfOverTimeEarlyOutD;
                    return _AccuTimesOfOverTimeEarlyOut;
                }
            }
            set
            {
                _AccuTimesOfOverTimeEarlyOut = value;
            }
        }
        private TimeSpan _AccuEarlyOverTimeOutTimeSpan;
        public TimeSpan AccuEarlyOverTimeOutTimeSpan
        { 
            get
            {
                if (!_HasRecords)
                {
                    return new TimeSpan(0, 0, 0);
                }
                else
                {
                    int _AccuEarlyOverTimeOutTimeSpanD = _AttendanceByDays.Sum(c => c.DayOverTimeEarlyOutTimeSpan);
                    _AccuEarlyOverTimeOutTimeSpan = TimeSpan.FromMinutes(_AccuEarlyOverTimeOutTimeSpanD);
                    return _AccuEarlyOverTimeOutTimeSpan;
                }
            }
            set
            {
                _AccuEarlyOverTimeOutTimeSpan = value;
            } 
        }
         
        //REGULAR-------------------------------------------------------------------------------------------------------------------------------------
        private int _AccuTimesOfRegular;
        public int AccuTimesOfRegular
        {
            get
            { 
                if (!_HasRecords)
                {
                    return 0;
                }
                else
                { 
                    _AccuTimesOfRegular = _RegularManualMissingWorkOn + _RegularManualMissingWorkOff + _RegularManualMissingLunchStart + _RegularManualMissingLunchEnd + _RegularManualMissingOverTimeStart + _RegularManualMissingOverTimeEnd;
                    return _AccuTimesOfRegular;
                } 
            }
            set
            {
                 _AccuTimesOfRegular = value;
            }
        }

        private int _AccuTimesOfRegularWorkOn;
        public int AccuTimesOfRegularWorkOn
        {
            get
            {
                if (!_HasRecords)
                { 
                    return 0;
                }
                else
                { 
                    _AccuTimesOfRegularWorkOn = _RegularManualMissingWorkOn;
                    return _AccuTimesOfRegularWorkOn;
                }
            }
            set
            {
                _AccuTimesOfRegularWorkOn = value;
            }
        }

        private int _AccuTimesOfRegularWorkOff;
        public int AccuTimesOfRegularWorkOff
        {
            get
            {
                if (!_HasRecords)
                {
                    return 0;
                }
                else
                { 
                    _AccuTimesOfRegularWorkOff = _RegularManualMissingWorkOff;
                    return _AccuTimesOfRegularWorkOff;
                }
            }
            set
            {
                _AccuTimesOfRegularWorkOff = value;
            }
        }

        private int _AccuTimesOfRegularLunchStart;
        public int AccuTimesOfRegularLunchStart
        {
            get
            {
                if (!_HasRecords)
                {
                    return 0;
                }
                else
                {
                    _AccuTimesOfRegularLunchStart = _RegularManualMissingLunchStart;
                    return _AccuTimesOfRegularLunchStart;
                }
            }
            set
            {
                _AccuTimesOfRegularLunchStart = value;
            }
        }

        private int _AccuTimesOfRegularLunchEnd;
        public int AccuTimesOfRegularLunchEnd
        {
            get
            {
                if (!_HasRecords)
                {
                    return 0;
                }
                else
                {
                    _AccuTimesOfRegularLunchEnd = _RegularManualMissingLunchEnd;
                    return _AccuTimesOfRegularLunchEnd;
                } 
            }
            set
            {
                _AccuTimesOfRegularLunchEnd = value;
            }
        }

        private int _AccuTimesOfRegularOverTimeStart;
        public int AccuTimesOfRegularOverTimeStart
        {
            get
            {
                if (!_HasRecords)
                {
                    return 0;
                }
                else
                {
                    _AccuTimesOfRegularOverTimeStart = _RegularManualMissingOverTimeStart;
                    return _AccuTimesOfRegularOverTimeStart;
                } 
            }
            set
            {
                _AccuTimesOfRegularOverTimeStart = value;
            }
        }

        private int _AccuTimesOfRegularOverTimeEnd;
        public int AccuTimesOfRegularOverTimeEnd
        {
            get
            {
                if (!_HasRecords)
                {
                    return 0;
                }
                else
                {
                    _AccuTimesOfRegularOverTimeEnd = _RegularManualMissingOverTimeEnd;
                    return _AccuTimesOfRegularOverTimeEnd;
                } 
            }
            set
            {
                _AccuTimesOfRegularOverTimeEnd = value;
            }
        }
        //MISSING-------------------------------------------------------------------------------------------------------------------------------------
        private int _AccuTimesOfMissing;
        public int AccuTimesOfMissing
        {
            get
            {
                _AccuTimesOfMissing = _AutoMissingWorkOn + _AutoMissingWorkOff + _AutoMissingLunchStart + _AutoMissingLunchEnd + _AutoMissingOverTimeStart + _AutoMissingOverTimeEnd;
                return _AccuTimesOfMissing;
            }
            set
            {
                _AccuTimesOfMissing = value;
            }
        }

        private int _AccuTimesOfMissingWorkOn;
        public int AccuTimesOfMissingWorkOn
        {
            get
            {
                _AccuTimesOfMissingWorkOn = _AutoMissingWorkOn;
                return _AccuTimesOfMissingWorkOn;
            }
            set
            {
                _AccuTimesOfMissingWorkOn = value;
            }
        }

        private int _AccuTimesOfMissingWorkOff;
        public int AccuTimesOfMissingWorkOff
        {
            get
            {
                _AccuTimesOfMissingWorkOff = _AutoMissingWorkOff;
                return _AccuTimesOfMissingWorkOff;
            }
            set
            {
                _AccuTimesOfMissingWorkOff = value;
            }
        }

        private int _AccuTimesOfMissingLunchStart;
        public int AccuTimesOfMissingLunchStart
        {
            get
            {
                _AccuTimesOfMissingLunchStart = _AutoMissingLunchStart;
                return _AccuTimesOfMissingLunchStart;
            }
            set
            {
                _AccuTimesOfMissingLunchStart = value;
            }
        }

        private int _AccuTimesOfMissingLunchEnd;
        public int AccuTimesOfMissingLunchEnd
        {
            get
            {
                _AccuTimesOfMissingLunchEnd =_AutoMissingLunchEnd;
                return _AccuTimesOfMissingLunchEnd;
            }
            set
            {
                _AccuTimesOfMissingLunchEnd = value;
            }
        }

        private int _AccuTimesOfMissingOverTimeStart;
        public int AccuTimesOfMissingOverTimeStart
        {
            get
            {
                _AccuTimesOfMissingOverTimeStart = _AutoMissingOverTimeStart;
                return _AccuTimesOfMissingOverTimeStart;
            }
            set
            {
                _AccuTimesOfMissingOverTimeStart = value;
            }
        }

        private int _AccuTimesOfMissingOverTimeEnd;
        public int AccuTimesOfMissingOverTimeEnd
        {
            get
            {
                _AccuTimesOfMissingOverTimeEnd = _AutoMissingOverTimeEnd;
                return _AccuTimesOfMissingOverTimeEnd;
            }
            set
            {
                _AccuTimesOfMissingOverTimeEnd = value;
            }
        }

        //SYSTEM-------------------------------------------------------------------------------------------------------------------------------------
        private decimal _AvgOnDutyWorkRatio;
        public decimal AvgOnDutyWorkRatio
        {
            get
            {
                if (!_HasRecords)
                {
                    return 0;
                }
                else
                {
                    _AvgOnDutyWorkRatio = _AttendanceByDays.Average(c => c.OnDutyWorkRatioAvg); 
                    return _AvgOnDutyWorkRatio;
                }
            }
            set
            {
                _AvgOnDutyWorkRatio = value;
            }
        }

        private decimal _AvgOnDutyPaidRatio;
        public decimal AvgOnDutyPaidRatio
        {
            get
            {
                if(!_HasRecords)
                {
                    return 0;
                }else
                {
                    _AvgOnDutyPaidRatio = _AttendanceByDays.Average(c => c.OnDutyPaidRatioAvg);
                    return _AvgOnDutyPaidRatio;
                }
            }
            set
            {
                _AvgOnDutyPaidRatio = value;
            }
        }

        private bool _OnDataLocked;
        public bool OnDataLocked
        {
            get
            {
                _OnDataLocked = false;
                return _OnDataLocked;
            }
            set
            {
                _OnDataLocked = value;
            }
        }
        private bool _IsCompleted;
        public bool IsCompleted
        {
            get
            {
                _IsCompleted = false;
                return _IsCompleted;
            }
            set
            {
                _IsCompleted = value;
            }
        }
        private DateTime _StartDate;
        public DateTime StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                _StartDate = value;
            }
        }

        private DateTime _EndDate;
        public DateTime EndDate
        {
            get
            {
                return _EndDate;
            }
            set
            {
                _EndDate = value;
            }
        }

        private DateTime _SysCalcDateTime;
        public DateTime SysCalcDateTime
        {
            get
            {
                _SysCalcDateTime = DateTime.Now;
                return _SysCalcDateTime;
            }
            set
            {
                _SysCalcDateTime = value;
            }
        }
        private string _HmacHash;
        public string HmacHash
        {
            get
            { 
                return _HmacHash;
            }
            set
            {
                _HmacHash = value;
            }
        }
        //--FUNC------------------------------------------------------------------
        private static bool checkHasRecordFromLeaves(List<DbFirst.Leave> leaves)
        {
            if (leaves.Count() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static DateTime GetRealEndDateTime(DateTime endDateTime)
        {
            endDateTime = DateTimePubBusiness.LastDayOfMonth(endDateTime);
            endDateTime = new DateTime(endDateTime.Year, endDateTime.Month, endDateTime.Day, 23, 59, 59);
            return endDateTime;
        }
    }
}
