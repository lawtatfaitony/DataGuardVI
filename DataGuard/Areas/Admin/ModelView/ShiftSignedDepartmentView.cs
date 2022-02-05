namespace DataGuard.Areas
{
    public class ShiftSignedDepartmentView
    {
        public string ShiftId { get; set; }
        public string ShiftAbbrId { get; set; }
        public string ShiftName { get; set; }
        public string DepartmentId { get; set; }
        public bool IgnoreHolidayAndLeave { get; set; }
    }
}