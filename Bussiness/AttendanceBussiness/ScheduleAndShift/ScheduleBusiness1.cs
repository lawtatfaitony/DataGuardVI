using AttendanceBussiness.DbFirst;
using Common;
using LanguageResource;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AttendanceBussiness.ScheduleBusiness
{
    public partial class ScheduleUtilize
    {
        public static ScheduleSearchingResult ScheduleSearching(string MainComId, string ContractorId, string SiteId, string DepartmentId, string PositionId, string JobId,
           string sortOrder, string searchString, DateTimeRangeObj dateTimeRangeObj)
        {
            using (DataBaseContext dbContext = new DataBaseContext())
            { 
                ScheduleSearchingResult scheduleSearchingResult = new ScheduleSearchingResult();
                scheduleSearchingResult.mainCom = dbContext.MainCom.Find(MainComId);

                //DateTime dt = DateTime.Now;
                //long scheduleDateStartLong = DateTimeHelp.ConvertDateTimeToLong(dateTimeRangeObj.Start);
                //long scheduleDateEndLong = DateTimeHelp.ConvertDateTimeToLong(dateTimeRangeObj.End) ;

                var schedules = from s in dbContext.Schedule.Where(c => c.MainComId == MainComId && c.ScheduleDate.Date >= dateTimeRangeObj.Start.Date && c.ScheduleDate <= dateTimeRangeObj.End.Date)
                                select s;
 
                // Employee
                var employees = from e in dbContext.Employee.Where(c => c.MainComId == MainComId)
                                select e;

                #region QUERY

                var query_employees_schedules = from e in employees
                                                join s in schedules on e.EmployeeId equals s.EmployeeId
                                                select new
                                                {
                                                    s.ScheduleId,
                                                    s.IdOfMonthlyShiftEmploy,
                                                    s.ShiftId,
                                                    s.ShiftAbbrId,
                                                    s.EmployeeId,
                                                    s.ScheduleDate,
                                                    s.ShiftAssignedMode,
                                                    s.WorkStart,
                                                    s.WorkEnd,
                                                    s.OnDataLocked,
                                                    s.IsCompleted,
                                                    e.CnName,
                                                    e.FirstName,
                                                    e.LastName,
                                                    e.ContractorId,
                                                    e.ContractorName,
                                                    e.SiteId,
                                                    e.SiteName,
                                                    e.DepartmentId,
                                                    e.DepartmentName,
                                                    e.JobId,
                                                    e.JobName,
                                                    e.PositionId,
                                                    e.PositionTitle,
                                                    e.AccessCardId
                                                };
                #endregion
                if (!String.IsNullOrEmpty(searchString))
                {
                    query_employees_schedules = query_employees_schedules.Where(s => s.EmployeeId.Contains(searchString)
                                        || s.CnName.Contains(searchString)
                                        || s.FirstName.Contains(searchString)
                                        || s.ContractorName.Contains(searchString)
                                        || s.SiteName.Contains(searchString)
                                        || s.DepartmentName.Contains(searchString)
                                        || s.PositionTitle.Contains(searchString)
                                        || s.JobName.Contains(searchString)
                                        || s.AccessCardId.Contains(searchString)
                                        || s.EmployeeId.Contains(searchString));
                }
                if (!String.IsNullOrEmpty(ContractorId))
                {
                    query_employees_schedules = query_employees_schedules.Where(s => s.ContractorId == ContractorId);

                }
                if (!String.IsNullOrEmpty(SiteId))
                {
                    query_employees_schedules = query_employees_schedules.Where(s => s.SiteId == SiteId);
                }
                if (!String.IsNullOrEmpty(DepartmentId))
                {
                    query_employees_schedules = query_employees_schedules.Where(s => s.DepartmentId == DepartmentId);
                }
                if (!String.IsNullOrEmpty(PositionId))
                {
                    query_employees_schedules = query_employees_schedules.Where(s => s.PositionId == PositionId);
                }
                if (!String.IsNullOrEmpty(JobId))
                {
                    query_employees_schedules = query_employees_schedules.Where(s => s.PositionId == JobId);
                }

                List<ScheduleMonth31> lstScheduleMonth31 = new List<ScheduleMonth31>();
                List<MonthHeader> monthHeaders = PublicGlobal.GetMonthHeader(dateTimeRangeObj.Start, 31);
                scheduleSearchingResult.monthHeaders = monthHeaders;
                var schedulesGroupByEmployeeIdX = query_employees_schedules.Select(x => x.EmployeeId).Distinct();
                foreach (var item in schedulesGroupByEmployeeIdX)
                {
                    string item_employeeId = item.ToString();
                    Employee item_employee = employees.Where(c => c.EmployeeId == item_employeeId).FirstOrDefault();
                    ScheduleMonth31 scheduleMonth31 = new ScheduleMonth31();
                    scheduleMonth31.EmployeeId = item_employeeId;
                    scheduleMonth31.EnName = string.Format("{0} {1}", item_employee.FirstName, item_employee.LastName);
                    scheduleMonth31.LastName = item_employee.LastName;
                    scheduleMonth31.CnName = item_employee.CnName;
                    scheduleMonth31.ScheduleId = "-";
                    Type type = scheduleMonth31.GetType();
                    foreach (var item2 in monthHeaders)
                    {
                        DateTime item2Dt = DateTimePubBusiness.SetZeroDateTime(DateTimePubBusiness.ConvertIntDateTime(item2.ScheduleDate));
                        string[] arrShiftAbbrId = query_employees_schedules.Where(c => c.ScheduleDate.Year == item2Dt.Year && c.ScheduleDate.Month == item2Dt.Month && c.ScheduleDate.Day == item2Dt.Day && c.EmployeeId == item_employeeId).Select(s => s.ShiftAbbrId).ToArray();
                        string shiftAbbrIds = arrShiftAbbrId.Length > 0 ? string.Join("<br>", arrShiftAbbrId) : "-";
                        string propName = string.Format("Day{0}", item2.DayIndex);
                        PropertyInfo propertyInfo = type.GetProperty(propName);
                        if (CommonBase.JudgeHasProperty(propName, scheduleMonth31))
                        {
                            propertyInfo.SetValue(scheduleMonth31, shiftAbbrIds, null);
                        }
                        continue;
                    }
                    lstScheduleMonth31.Add(scheduleMonth31);
                }

                List<Shift> shiftLists = new List<Shift>();
                var query_employees_schedules_distict = query_employees_schedules.Select(c => c.ShiftId).Distinct();
                foreach (var item in query_employees_schedules_distict.ToArray())
                {
                    Shift shift = dbContext.Shift.Find(item.ToString());
                    shiftLists.Add(shift);
                }
                scheduleSearchingResult.ShiftList = shiftLists;

                if(!string.IsNullOrEmpty(sortOrder))
                {
                    sortOrder.ToLower();
                }
                else
                {
                    sortOrder = "date_desc";
                }
                switch (sortOrder)
                {
                    case "date":
                        scheduleSearchingResult.ListScheduleMonth31 = lstScheduleMonth31.OrderBy(s => s.ScheduleId);
                        break;
                    case "date_desc":
                        scheduleSearchingResult.ListScheduleMonth31 = lstScheduleMonth31.OrderByDescending(s => s.ScheduleId);
                        break;
                    default:
                        scheduleSearchingResult.ListScheduleMonth31 = lstScheduleMonth31.OrderByDescending(s => s.ScheduleId);
                        break;
                }
                return scheduleSearchingResult;
        }
        } 
        public static List<AssignedDepartment> ShiftDepartmentChkLst(DataBaseContext dataBaseContext, string ShiftId)
        {
            Shift shift = dataBaseContext.Shift.Find(ShiftId);
            var allDepartments = dataBaseContext.Department.OrderBy(s => s.DepartmentId);
            string departmentArrStr =shift.DepartmentIdArr;

            var viewAssignedDepartment = new List<AssignedDepartment>
            {
                new AssignedDepartment
                {
                    ShiftId = ShiftId,
                    DepartmentId = "DEPARTMENT01",
                    DepartmentName = Lang.Department_DEPARTMENTALL,
                    Assigned = shift.DepartmentIdArr == "0" || string.IsNullOrEmpty(departmentArrStr) ? true : false
                }
            };
            foreach (var item in allDepartments)
            {
                bool assigned = false;
                if (string.IsNullOrEmpty(shift.DepartmentIdArr))
                {
                    departmentArrStr = "0";
                }
                assigned = departmentArrStr.Contains(item.DepartmentId);

                viewAssignedDepartment.Add(new AssignedDepartment
                {
                    ShiftId = ShiftId,
                    DepartmentId = item.DepartmentId,
                    DepartmentName = item.DepartmentName,
                    Assigned = assigned
                });
            }
            
            return viewAssignedDepartment;
        }
    }
    public class ScheduleMonth28
    {
        [DefaultValue("")] 
        public string ScheduleId{ get; set; }
        [DefaultValue("")]
        public string EmployeeId{ get; set; }
        [DefaultValue("")]
        public string CnName{ get; set; }
        [DefaultValue("")]
        public string EnName{ get; set; }
        [DefaultValue("")]
        public string LastName{ get; set; }
        [DefaultValue("")] 
        public string Day1{ get; set; }
        [DefaultValue("")]
        public string Day2{ get; set; }
        [DefaultValue("")]
        public string Day3{ get; set; }
        [DefaultValue("")]
        public string Day4{ get; set; }
        [DefaultValue("")]
        public string Day5{ get; set; }
        [DefaultValue("")]
        public string Day6{ get; set; }
        [DefaultValue("")]
        public string Day7{ get; set; }
        [DefaultValue("")]
        public string Day8{ get; set; }
        [DefaultValue("")]
        public string Day9{ get; set; }
        [DefaultValue("")]
        public string Day10{ get; set; }
        [DefaultValue("")]
        public string Day11{ get; set; }
        [DefaultValue("")]
        public string Day12{ get; set; }
        [DefaultValue("")]
        public string Day13{ get; set; }
        [DefaultValue("")]
        public string Day14{ get; set; }
        [DefaultValue("")]
        public string Day15{ get; set; }
        [DefaultValue("")]
        public string Day16{ get; set; }
        [DefaultValue("")]
        public string Day17{ get; set; }
        [DefaultValue("")]
        public string Day18{ get; set; }
        [DefaultValue("")]
        public string Day19{ get; set; }
        [DefaultValue("")]
        public string Day20{ get; set; }
        [DefaultValue("")]
        public string Day21{ get; set; }
        [DefaultValue("")]
        public string Day22{ get; set; }
        [DefaultValue("")]
        public string Day23{ get; set; }
        [DefaultValue("")]
        public string Day24{ get; set; }
        [DefaultValue("")]
        public string Day25{ get; set; }
        [DefaultValue("")]
        public string Day26{ get; set; }
        [DefaultValue("")]
        public string Day27{ get; set; }
        [DefaultValue("")]
        public string Day28{ get; set; }
    }
    public class ScheduleMonth29 : ScheduleMonth28
    {
        [DefaultValue("")]
        public string Day29{ get; set; }
    }
    public class ScheduleMonth30 : ScheduleMonth28
    {
        [DefaultValue("")]
        public string Day29{ get; set; }
        [DefaultValue("")]
        public string Day30{ get; set; }
    }
    public class ScheduleMonth31 : ScheduleMonth28
    {
        [DefaultValue("")]
        public string Day29{ get; set; }
        [DefaultValue("")]
        public string Day30{ get; set; }
        [DefaultValue("")]
        public string Day31{ get; set; } 
    }

    public class ScheduleSearchingResult
    {
        public List<MonthHeader> monthHeaders { get; set; }
        public IEnumerable<ScheduleMonth31> ListScheduleMonth31 { get; set; }

        public List<Shift> ShiftList { get; set; }

        public MainCom mainCom { get; set; }
    }

    /// <summary>
    /// ScheduleIndexDownLoad::input
    /// </summary>
    public partial class ScheduleIndexExcelInput
    {
        public string MainComId { get; set; }
        public string ContractorId { get; set; }
        public string SiteId { get; set; }
        public string DepartmentId { get; set; }
        public string JobId { get; set; }
        public string PositionId { get; set; }
        public string ScheduleDateRange { get; set; }
        [DefaultValue("date_desc")]
        public string SortOrder { get; set; }
        public string Search { get; set; }
    }

    /// <summary>
    /// ScheduleIndexExcelReports 
    /// </summary>
    public partial class ScheduleIndexExcelReports
    {
        public string StarDate { get; set; }
        public string EndDate { get; set; }
        public string MainComId { get; set; }
        public string CompanyName { get; set; }
        public string ReportDate { get; set; }
        public string DayRpt1 { get; set; }
        public string WeekNameRpt1 { get; set; }
        public string DayRpt2 { get; set; }
        public string WeekNameRpt2 { get; set; }
        public string DayRpt3 { get; set; }
        public string WeekNameRpt3 { get; set; }
        public string DayRpt4 { get; set; }
        public string WeekNameRpt4 { get; set; }
        public string DayRpt5 { get; set; }
        public string WeekNameRpt5 { get; set; }
        public string DayRpt6 { get; set; }
        public string WeekNameRpt6 { get; set; }
        public string DayRpt7 { get; set; }
        public string WeekNameRpt7 { get; set; }
        public string DayRpt8 { get; set; }
        public string WeekNameRpt8 { get; set; }
        public string DayRpt9 { get; set; }
        public string WeekNameRpt9 { get; set; }
        public string DayRpt10 { get; set; }
        public string WeekNameRpt10 { get; set; }
        public string DayRpt11 { get; set; }
        public string WeekNameRpt11 { get; set; }
        public string DayRpt12 { get; set; }
        public string WeekNameRpt12 { get; set; }
        public string DayRpt13 { get; set; }
        public string WeekNameRpt13 { get; set; }
        public string DayRpt14 { get; set; }
        public string WeekNameRpt14 { get; set; }
        public string DayRpt15 { get; set; }
        public string WeekNameRpt15 { get; set; }
        public string DayRpt16 { get; set; }
        public string WeekNameRpt16 { get; set; }
        public string DayRpt17 { get; set; }
        public string WeekNameRpt17 { get; set; }
        public string DayRpt18 { get; set; }
        public string WeekNameRpt18 { get; set; }
        public string DayRpt19 { get; set; }
        public string WeekNameRpt19 { get; set; }
        public string DayRpt20 { get; set; }
        public string WeekNameRpt20 { get; set; }
        public string DayRpt21 { get; set; }
        public string WeekNameRpt21 { get; set; }
        public string DayRpt22 { get; set; }
        public string WeekNameRpt22 { get; set; }
        public string DayRpt23 { get; set; }
        public string WeekNameRpt23 { get; set; }
        public string DayRpt24 { get; set; }
        public string WeekNameRpt24 { get; set; }
        public string DayRpt25 { get; set; }
        public string WeekNameRpt25 { get; set; }
        public string DayRpt26 { get; set; }
        public string WeekNameRpt26 { get; set; }
        public string DayRpt27 { get; set; }
        public string WeekNameRpt27 { get; set; }
        public string DayRpt28 { get; set; }
        public string WeekNameRpt28 { get; set; }
        public string DayRpt29 { get; set; }
        public string WeekNameRpt29 { get; set; }
        public string DayRpt30 { get; set; }
        public string WeekNameRpt30 { get; set; }
        public string DayRpt31 { get; set; }
        public string WeekNameRpt31 { get; set; }
        public List<ScheduleMonth31> ListScheduleMonth31s { get; set; }
    }
}