using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class Holiday
    {
        public string HolidayId { get; set; }
        public string HolidayCnName { get; set; }
        public string HolidayEnName { get; set; }
        public DateTime HolidayDate { get; set; }
        public int IsWholeDay { get; set; }
        public bool? StatutoryHoliday { get; set; }
        public int HolidayPaidType { get; set; }
        public string HolidayPaidTypeName { get; set; }
        public decimal OnDutyPaidRatio { get; set; }
        public string MainComId { get; set; }
    }
}
