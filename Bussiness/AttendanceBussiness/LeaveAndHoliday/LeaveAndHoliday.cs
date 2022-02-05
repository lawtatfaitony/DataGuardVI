using AttendanceBussiness.DbFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttendanceBussiness.LeaveAndHoliday
{
    public partial class LeaveAndHolidayBusiness
    { 
        public static bool ExceptEveryWeekDay(string ExcludeWeekDay, DateTime ScheduleDate)
        {
            if (!string.IsNullOrEmpty(ExcludeWeekDay))
            {
                if ((int)ScheduleDate.DayOfWeek == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
