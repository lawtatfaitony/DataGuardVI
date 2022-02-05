using System;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections.Generic; 
using AttendanceBussiness.DbFirst;
using AttendanceBussiness;
using Microsoft.EntityFrameworkCore;
using static AttendanceBussiness.ShiftBusiness;
using System.Threading;
using AttendanceBussiness.Public;
using System.IO;
using Common;
using AttendanceBussiness.ScheduleAndShift;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AttendanceBussiness.AttendanceSchedule
{
    public partial class ScheduleGlobal : SchedulePubBusiness
    {
        public static void ScheduleCalc()
        {
            using (DataBaseContext dbContext=new DataBaseContext())
            {
                var TheShiftAppliedModeGLOBAL = dbContext.Shift.Where(c => c.ShiftAppliedMode == (int)ShiftAppliedMode.GLOBAL && c.IsApproved == true).OrderByDescending(c => c.AppliedStartDate).ToList();
                foreach (var itemShift in TheShiftAppliedModeGLOBAL)
                {
                    string ShiftId = itemShift.ShiftId;
                    Shift shift = dbContext.Shift.Find(ShiftId);
                    string shiftDepartmentId = shift.DepartmentIdArr;

                    var shiftEmployees = dbContext.Employee.Where(c => c.IsBlock == false);
                    if (shiftDepartmentId != "0" && !string.IsNullOrEmpty(shiftDepartmentId))
                    {
                        List<string> lstShiftDepartmentId = shiftDepartmentId.Split(',').ToList();
                        shiftEmployees = dbContext.Employee.Where(c => lstShiftDepartmentId.Contains(c.DepartmentId));
                    }
                    DateTime NextMonth = DateTime.Now.AddMonths(1);
                    DateTime NextMonthFirstDay = DateTimePubBusiness.FirstDayOfMonth(NextMonth);
                    DateTime NextMonthLastDay = DateTimePubBusiness.LastDayOfMonth(NextMonth);

                    int daysInMonth = DateTime.DaysInMonth(NextMonth.Year, NextMonth.Month);
                    DateTime ScheduleDate = NextMonthFirstDay;
                    foreach (var item in shiftEmployees)
                    {
                        for (int i = 1; i <= daysInMonth; i++)
                        {
                            if (ScheduleDate <= shift.AppliedEndDate)
                            {
                                bool result = ScheduleSystemAssignedIns(ShiftId, shift, item.EmployeeId, ScheduleDate, 0, true, true);
                                string LoggerLine1 = string.Format("[func::ScheduleCalc::ScheduleIns:ShiftId={0},EmployeeId={1},ScheduleDate={2:yyyy-MM-dd},result={3}]", ShiftId, item.EmployeeId, ScheduleDate, result);
                                PublicGlobal.ConsoleWriteline(LoggerLine1, CommonBase.LoggerMode.INFO);
                            }
                            ScheduleDate = NextMonthFirstDay.AddDays(i);

                        }
                    } 
                }
            }
        }
        public static void ScheduleCalcByDepartmentId( string ShiftId, string DepartmentId, bool checkHolidayAndLeave, out bool result)
        { 
            using (DataBaseContext dbContext = new DataBaseContext())
            {
                var employees = dbContext.Employee.Where(c => c.IsBlock == false && c.DepartmentId.Contains(DepartmentId));
                Shift shift = dbContext.Shift.Find(ShiftId); 

                string LoggerLine; 
                DateTime nowDt = DateTime.Now;
                DateTime dt = new DateTime(nowDt.Year, nowDt.Month, nowDt.Day, 0, 0, 0);
                DateTime AppliedStartDate = shift.AppliedStartDate;
                DateTime AppliedEndDate = shift.AppliedEndDate;
                int days = DateTimePubBusiness.DaysDiff(dt, AppliedEndDate);
                DateTime ScheduleDate = dt;
                result = false;
                foreach (var item in employees)
                {
                    for (int i = 1; i <= days; i++)
                    {
                        ScheduleDate = dt.AddDays(i);
                        if (ScheduleDate <= shift.AppliedEndDate)
                        {
                            result = ScheduleSystemAssignedIns( ShiftId, shift, item.EmployeeId, ScheduleDate, shift.ShiftAppliedMode, checkHolidayAndLeave, checkHolidayAndLeave);
                            LoggerLine = string.Format("[func::ScheduleCalc::ScheduleIns:ShiftId={0},EmployeeId={1},ScheduleDate={2:yyyy-MM-dd},result={3}]", ShiftId, item.EmployeeId, ScheduleDate, result);
                            PublicGlobal.ConsoleWriteline(LoggerLine);
                        }
                    }
                    LoggerLine = string.Format("[INFO] [func::ScheduleCalc::foreach::ShiftId= [{0}],EmployeeId={1}]", ShiftId, item.EmployeeId);
                    PublicGlobal.ConsoleWriteline(LoggerLine);
                }
                LoggerLine = string.Format("[INFO] [ShiftId:{0}] [func::ScheduleCalc Finished DaysOfMonth={1}]", ShiftId, days);
                PublicGlobal.ConsoleWriteline(LoggerLine);
            }
        } 

        public static CalendarScheduleView CalendarScheduletList(string EmployeeId)
        { 
            CalendarScheduleView calendarScheduleView = new CalendarScheduleView();
            List<ClendarScheduleModal> clendarScheduleModals = new List<ClendarScheduleModal>();
             
            using (DataBaseContext dbContext = new DataBaseContext())
            {
                Employee employee = dbContext.Employee.Find(EmployeeId);

                EmployeeModal employeeModal = new EmployeeModal
                {
                    MainComId = employee.MainComId,
                    EmployeeId = employee.EmployeeId,
                    EmployeeName = employee.FullName,
                    DefaultDate = DateTime.Now,
                    DepartmentId = employee.DepartmentId,
                    DepartmentName = employee.DepartmentName
                };
                calendarScheduleView.EmployeeModal = employeeModal;

                #region params 
                DateTime dt = DateTime.Now;
                DateTimeRangeObj dateTimeRangeObj = new DateTimeRangeObj();
                dateTimeRangeObj.End = dt.AddDays(31);
                dateTimeRangeObj.Start = dt.AddDays(-365);
                #endregion

                #region currentQuery
                var schedules = from s in dbContext.Schedule.Where(c => c.MainComId == employee.MainComId && c.EmployeeId.Contains(EmployeeId) && c.ScheduleDate.Date >= dateTimeRangeObj.Start.Date && c.ScheduleDate.Date <= dateTimeRangeObj.End.Date)
                                select s;

                var shifts = from t in dbContext.Shift
                             select t;

                var query_shifts_schedules = from s in schedules
                                             join t in shifts on s.ShiftId equals t.ShiftId
                                             select new
                                             {
                                                 s.ScheduleId,
                                                 s.IdOfMonthlyShiftEmploy,
                                                 s.ShiftId,
                                                 s.ShiftAbbrId,
                                                 t.IconColor,
                                                 t.ShiftAppliedMode,
                                                 t.ShiftName,
                                                 t.ShiftBusinessMode,
                                                 t.IsApproved,
                                                 s.EmployeeId,
                                                 s.ScheduleDate,
                                                 s.ShiftAssignedMode,
                                                 s.WorkStart,
                                                 s.WorkEnd,
                                                 s.OnDataLocked,
                                                 s.IsCompleted
                                             };
                #endregion

                foreach (var item in query_shifts_schedules)
                {
                    Schedule schedule = dbContext.Schedule.Find(item.ScheduleId);
                    ScheduleDate ObjScheduleDate = new ScheduleDate((ShiftBusinessMode)item.ShiftBusinessMode, schedule);

                    //DateTime ScheduleStartDate = new DateTime(ObjScheduleDate.ScheduleStartDate.Year, ObjScheduleDate.ScheduleStartDate.Month,
                    //    ObjScheduleDate.ScheduleStartDate.Day, item.WorkStart.Hours, item.WorkStart.Minutes, 0);
                    //DateTime ScheduleEndDate = new DateTime(ObjScheduleDate.ScheduleEndDate.Year, ObjScheduleDate.ScheduleEndDate.Month,
                    //     ObjScheduleDate.ScheduleEndDate.Day, item.WorkEnd.Hours, item.WorkEnd.Minutes, 0);

                    DateTime ScheduleStartDate = ObjScheduleDate.ScheduleStartDate;
                    DateTime ScheduleEndDate = ObjScheduleDate.ScheduleEndDate;

                    string title = string.Format("{0}-{1}\n{2} - {3}", item.ShiftAbbrId, item.ShiftName, ScheduleStartDate.ToShortTimeString(), ScheduleEndDate.ToShortTimeString());

                    ClendarScheduleModal clendarScheduleModal = new ClendarScheduleModal
                    {
                        Title = title,
                        Start = ScheduleStartDate,
                        End = ScheduleEndDate,
                        GroupId = "",//item.ShiftAbbrId
                        Constraint = string.Empty,
                        Color = item.IconColor
                    };

                    clendarScheduleModals.Add(clendarScheduleModal);
                }
                calendarScheduleView.ClendarScheduleList = clendarScheduleModals;
            }
            return calendarScheduleView;
        }
    }
}