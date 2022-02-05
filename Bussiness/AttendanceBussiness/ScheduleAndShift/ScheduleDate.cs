using AttendanceBussiness.DbFirst;
using System;
using System.Collections.Generic;
using System.Text;
using static AttendanceBussiness.ShiftBusiness;
using AttendanceBussiness.AttendanceSchedule;
namespace AttendanceBussiness.ScheduleAndShift
{
    public abstract class ScheduleDateTpl
    {
        public static DateTime _ScheduleStartDate { get; set; }
        public static DateTime _ScheduleEndDate { get; set; }

        public ScheduleDateTpl(ShiftBusinessMode shiftBusinessMode, Schedule schedule)
        {
            DateTime ScheduleDate = schedule.ScheduleDate;
            if (shiftBusinessMode == ShiftBusinessMode.NIGHTSHIFT)
            {
                if(schedule.WorkStart > schedule.WorkEnd)
                {
                    _ScheduleStartDate = new DateTime(ScheduleDate.Year, ScheduleDate.Month, ScheduleDate.Day, schedule.WorkStart.Hours, schedule.WorkStart.Minutes,0);

                    _ScheduleEndDate = new DateTime(ScheduleDate.Year, ScheduleDate.Month, ScheduleDate.Day, schedule.WorkEnd.Hours, schedule.WorkEnd.Minutes, 0);

                    _ScheduleEndDate.AddDays(1); 
                }
                else
                {
                    _ScheduleStartDate = new DateTime(ScheduleDate.Year, ScheduleDate.Month, ScheduleDate.Day, schedule.WorkStart.Hours, schedule.WorkStart.Minutes, 0);

                    _ScheduleEndDate = new DateTime(ScheduleDate.Year, ScheduleDate.Month, ScheduleDate.Day, schedule.WorkEnd.Hours, schedule.WorkEnd.Minutes, 0);
                }
            }else
            {
                _ScheduleStartDate = new DateTime(ScheduleDate.Year, ScheduleDate.Month, ScheduleDate.Day, schedule.WorkStart.Hours, schedule.WorkStart.Minutes, 0);

                _ScheduleEndDate = new DateTime(ScheduleDate.Year, ScheduleDate.Month, ScheduleDate.Day, schedule.WorkEnd.Hours, schedule.WorkEnd.Minutes, 0);
            }
        }
    }
    public class ScheduleDate: ScheduleDateTpl
    {
        public ScheduleDate(ShiftBusinessMode shiftBusinessMode, Schedule scheduleDate) : base(shiftBusinessMode, scheduleDate)
        { 
            ScheduleStartDate = _ScheduleStartDate;
            ScheduleEndDate = _ScheduleEndDate;
        }
        /// <summary>
        /// Schedule Work Start DateTime
        /// </summary>
        public DateTime ScheduleStartDate { get; set; }
        /// <summary>
        /// Schedule Work End DateTime
        /// </summary>
        public DateTime ScheduleEndDate { get; set; }
    }

    public abstract class TimeSpanBusinessTpl
    {
        private static DateTime dt1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        public static DateTime _StartTime { get; set; }
        public static DateTime _EndTime { get; set; }
        public static double _TotalSpanMinutes { get; set; }

        public TimeSpanBusinessTpl(DateTime StartTime, DateTime EndTime)
        {
            TimeSpan timeSpan = new TimeSpan();
            
            if (StartTime != dt1970 && EndTime != dt1970)
            {
                if (StartTime > EndTime )
                {
                    EndTime = EndTime.AddDays(1);
                }
                _StartTime = StartTime;
                _EndTime = EndTime;
                TimeSpan timeSpanStart = StartTime.TimeOfDay;
                TimeSpan timeSpanEnd = EndTime.TimeOfDay;
                timeSpan = EndTime.Subtract(StartTime);
                _TotalSpanMinutes = timeSpan.TotalMinutes;
            }
            else
            {
                _StartTime = StartTime;
                _EndTime = EndTime;
                _TotalSpanMinutes = 0;
            }
        }
    }
    public class TimeSpanBusiness : TimeSpanBusinessTpl
    {
        public TimeSpanBusiness(DateTime startTime, DateTime endTime) : base(startTime, endTime)
        {
            StartTime = _StartTime;
            EndTime = _EndTime;
            TotalSpanMinutes = _TotalSpanMinutes;
        }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double TotalSpanMinutes { get; set; }

        public CalcMissingMode calcMissingModeStart { get; set; } = CalcMissingMode.NO_CALC;
        public CalcMissingMode calcMissingModeEnd { get; set; } = CalcMissingMode.NO_CALC;
    }
}
