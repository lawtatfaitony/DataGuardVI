using AttendanceBussiness.DbFirst;
using System;
using System.Collections.Generic;
using static AttendanceBussiness.ShiftBusiness;

namespace DataGuard.Areas
{
    public class HolidayListView
    {
        public Holiday HolidayNew { get; set; }
        public IEnumerable<AttendanceBussiness.DbFirst.Holiday> HolidayList { get; set; }
    }
    public class HolidayView
    {
        public StatutoryHoliday StatutoryHolidayMode { get; set; }
        public string HolidayId { get; set; }
        public string HolidayCnName { get; set; }
        public string HolidayEnName { get; set; }
        public DateTime HolidayDate { get; set; }
        public bool? StatutoryHoliday { get; set; }
        public HolidayIsWholeDayType HolidayIsWholeDayType { get; set; } = 0;
        public HolidayPaidType HolidayPaidType { get; set; }
        public string HolidayPaidTypeName { get; set; }
        public decimal OnDutyPaidRatio { get; set; } = 0;
        public string MainComId { get; set; }
    }
}