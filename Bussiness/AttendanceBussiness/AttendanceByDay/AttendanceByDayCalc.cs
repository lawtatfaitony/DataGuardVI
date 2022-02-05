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
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using AttendanceBussiness.AttendanceSchedule;

namespace AttendanceBussiness.AttendanceByDay
{ 
    public class AttendanceByDayCalc
    {
        public static void CalcByDay()
        {
            List<Schedule> schedules = new List<Schedule>();
            List<AttendanceByShift> attendanceByShifts = new List<AttendanceByShift>();
            List<string> employeeLists = new List<string>();
            using (DataBaseContext dataBaseContext = new DataBaseContext())
            { 
                schedules = dataBaseContext.Schedule.Where(c=>c.IsCompleted == true).ToList();
                attendanceByShifts = dataBaseContext.AttendanceByShift.Where(c => c.IsCompleted == false).ToList();
                #region query_employees_schedules 
                var query_employees_schedules = from e in attendanceByShifts
                                                join s in schedules on e.EmployeeId equals s.EmployeeId
                                                select new
                                                {
                                                    s.EmployeeId 
                                                };
                #endregion
                var employeeIdList = query_employees_schedules.GroupBy(p => new { p.EmployeeId })
                                  .Select(g => new
                                  {
                                      g.Key.EmployeeId
                                  }).ToList();
                foreach(var item in employeeIdList)
                {
                    employeeLists.Add(item.EmployeeId);
                }
            }
            if (employeeLists.Count > 0)
            {
                foreach (var employeeId in employeeLists)
                {
                    using (DataBaseContext dataBaseContext = new DataBaseContext())
                    {
                        var my_scheduledates_collection = dataBaseContext.AttendanceByShift.Where(c => c.IsCompleted == false && c.EmployeeId == employeeId).GroupBy(p => new { p.ScheduleDate })
                                       .Select(g => new
                                       {
                                           g.Key.ScheduleDate
                                       }).ToList();
                         
                        string LoggerMySchedule = string.Format("[ATTENDANCEBYDAYCALC::CALCBYDAY::SCHEDULE : my_scheduledates_collection = {0}] [EmployeeId={1}]", my_scheduledates_collection.Count, employeeId);
                        PublicGlobal.ConsoleWriteline(LoggerMySchedule, LoggerMode.INFO);
                        int k = 0;
                        foreach (var item2 in my_scheduledates_collection)
                        {
                            #region Schedule Date 
                            string TempAttendanceByDayId = "";
                            DateTime scheduleDate = item2.ScheduleDate; //
                            Employee employee = dataBaseContext.Employee.Find(employeeId); //

                            List<Shift> myScheduleDayShifts = new List<Shift>(); //
                            List<AttendanceByShift> dayAttendanceByShifts = dataBaseContext.AttendanceByShift.Where(c => c.EmployeeId == employeeId
                                                                                            && c.ScheduleDate.Date == scheduleDate.Date).ToList();//
                            foreach (var item3 in dayAttendanceByShifts)
                            {
                                Shift shift = dataBaseContext.Shift.Find(item3.ShiftId);
                                if (shift != null)
                                {
                                    myScheduleDayShifts.Add(shift);
                                }
                            }
                            //----------------------------------------------------------------------------------------------------------------------------------------------
                            #region HANDLE BUSINESS UNIT
                            AttendanceByDayCalcUnit attendanceByDayCalcUnit = new AttendanceByDayCalcUnit(employee, scheduleDate, myScheduleDayShifts, dayAttendanceByShifts);

                            DbFirst.AttendanceByDay attendanceByDay = new DbFirst.AttendanceByDay
                            {
                                AttendanceByDayId = attendanceByDayCalcUnit.AttendanceByDayId,
                                MainComId = attendanceByDayCalcUnit.MainComId,
                                EmployeeId = attendanceByDayCalcUnit.EmployeeId,
                                EmployeeName = attendanceByDayCalcUnit.EmployeeName,
                                DepartmentId = attendanceByDayCalcUnit.DepartmentId,
                                DepartmentName = attendanceByDayCalcUnit.DepartmentName,
                                PositionId = attendanceByDayCalcUnit.PositionId,
                                PositionTitle = attendanceByDayCalcUnit.PositionTitle,
                                ContractorId = attendanceByDayCalcUnit.ContractorId,
                                ContractorName = attendanceByDayCalcUnit.ContractorName,
                                JobId = attendanceByDayCalcUnit.JobId,
                                JobName = attendanceByDayCalcUnit.JobName,
                                SiteId = attendanceByDayCalcUnit.SiteId,
                                SiteName = attendanceByDayCalcUnit.SiteName,
                                IsWorkDay = attendanceByDayCalcUnit.IsWorkDay,
                                IsAbsentDay = attendanceByDayCalcUnit.IsAbsentDay,
                                DayShiftNameList = attendanceByDayCalcUnit.DayShiftNameList,
                                DayShiftListJson = attendanceByDayCalcUnit.DayShiftListJson,
                                DayTotalWorkTimeSpan = attendanceByDayCalcUnit.DayTotalWorkTimeSpan,
                                DayTotalWorkNetTimeSpan = attendanceByDayCalcUnit.DayTotalWorkNetTimeSpan,
                                DayTotalLunchTimeSpan = attendanceByDayCalcUnit.DayTotalLunchTimeSpan,
                                DayTotalOverTimeSpan = attendanceByDayCalcUnit.DayTotalOverTimeSpan,
                                DayLateInTimeSpan = attendanceByDayCalcUnit.DayLateInTimeSpan,
                                DayIsLateTimez = attendanceByDayCalcUnit.DayIsLateTimez,
                                DayEarlyOutTimeSpan = attendanceByDayCalcUnit.DayEarlyOutTimeSpan,
                                DayIsEarlyTimez = attendanceByDayCalcUnit.DayIsEarlyTimez,
                                DayLunchLateInTimeSpan = attendanceByDayCalcUnit.DayLunchLateInTimeSpan,
                                DayLunchIsLateTimez = attendanceByDayCalcUnit.DayLunchIsLateTimez,
                                DayLunchEarlyOutTimeSpan = attendanceByDayCalcUnit.DayLunchEarlyOutTimeSpan,
                                DayLunchIsEarlyTimez = attendanceByDayCalcUnit.DayLunchIsEarlyTimez,
                                DayOverTimeLateInTimeSpan = attendanceByDayCalcUnit.DayOverTimeLateInTimeSpan,
                                DayOverTimeIsLateTimez = attendanceByDayCalcUnit.DayOverTimeIsLateTimez,
                                DayOverTimeEarlyOutTimeSpan = attendanceByDayCalcUnit.DayOverTimeEarlyOutTimeSpan,
                                DayOverTimeIsEarlyTimez = attendanceByDayCalcUnit.DayOverTimeIsEarlyTimez,
                                DayMissingWorkOnTimez = attendanceByDayCalcUnit.DayMissingWorkOnTimez,
                                DayMissingWorkOffTimez = attendanceByDayCalcUnit.DayMissingWorkOffTimez,
                                DayMissingLunchStartTimez = attendanceByDayCalcUnit.DayMissingLunchStartTimez,
                                DayMissingLunchEndTimez = attendanceByDayCalcUnit.DayMissingLunchEndTimez,
                                DayMissingOverTimeStartTimez = attendanceByDayCalcUnit.DayMissingOverTimeStartTimez,
                                DayMissingOverTimeEndTimez = attendanceByDayCalcUnit.DayMissingOverTimeEndTimez,

                                TotalTimesOfRegularWorkOn = attendanceByDayCalcUnit.TotalTimesOfRegularWorkOn,
                                TotalTimesOfRegularWorkOff = attendanceByDayCalcUnit.TotalTimesOfRegularWorkOff,
                                TotalTimesOfRegularLunchStart = attendanceByDayCalcUnit.TotalTimesOfRegularLunchStart,
                                TotalTimesOfRegularLunchEnd = attendanceByDayCalcUnit.TotalTimesOfRegularLunchEnd,
                                TotalTimesOfRegularOverTimeStart = attendanceByDayCalcUnit.TotalTimesOfRegularOverTimeStart,
                                TotalTimesOfRegularOverTimeEnd = attendanceByDayCalcUnit.TotalTimesOfRegularOverTimeEnd,

                                LeaveId = attendanceByDayCalcUnit.LeaveId,
                                LeaveType = attendanceByDayCalcUnit.LeaveType,
                                LeaveTypeName = attendanceByDayCalcUnit.LeaveTypeName,
                                LeavePaidType = attendanceByDayCalcUnit.LeavePaidType,
                                LeavePaidTypeName = attendanceByDayCalcUnit.LeavePaidTypeName,
                                LeaveWithPaidRatio = attendanceByDayCalcUnit.LeaveWithPaidRatio,
                                HolidayId = attendanceByDayCalcUnit.HolidayId,
                                HolidayName = attendanceByDayCalcUnit.HolidayName,
                                HolidayPaidType = attendanceByDayCalcUnit.HolidayPaidType,
                                HolidayPaidTypeName = attendanceByDayCalcUnit.HolidayPaidTypeName,
                                HolidayWithPaidRatio = attendanceByDayCalcUnit.HolidayWithPaidRatio,
                                OnDutyWorkRatioAvg = attendanceByDayCalcUnit.OnDutyWorkRatioAvg,
                                OnDutyPaidRatioAvg = attendanceByDayCalcUnit.OnDutyPaidRatioAvg,
                                CalcPeriodType = attendanceByDayCalcUnit.CalcPeriodType,
                                OnDataLocked = attendanceByDayCalcUnit.OnDataLocked,
                                IsCompleted = attendanceByDayCalcUnit.IsCompleted,
                                SysCalcDateTime = attendanceByDayCalcUnit.SysCalcDateTime,
                                OccurDate = item2.ScheduleDate
                            };
                            attendanceByDay.HmacHash = ScheduleAndShiftUtil.AttendanceByDayHmac(attendanceByDay);
                            TempAttendanceByDayId = attendanceByDay.AttendanceByDayId;
                            //SAVE RECORD 
                            DbFirst.AttendanceByDay ExistAttendanceByDay = new DbFirst.AttendanceByDay();
                            ExistAttendanceByDay = dataBaseContext.AttendanceByDay.Find(attendanceByDayCalcUnit.AttendanceByDayId);

                            if (ExistAttendanceByDay == null)
                            {
                                bool add_result = AddAttendanceByDay(attendanceByDay, k);
                            }
                            else
                            {
                                bool update_result = UpdateAttendanceByDay(attendanceByDay, k);

                            }
                            //detroy
                            scheduleDate = DateTimeHelp.DT1970;
                            myScheduleDayShifts = null;
                            dayAttendanceByShifts = null;
                            //attendanceByDayCalcUnit.Dispose();  //---------------------------------NOTE
                            #endregion

                            #endregion
                            k += 1;
                        }
                        Thread.Sleep(134);
                    }
                }
            }
            else
            {
                string logText = string.Format("[HANDLE DAY BUSINESS] [group_employees_schedules = 0 no employee to calc the Attendance by day]");
                PublicGlobal.ConsoleWriteline(logText, LoggerMode.FATAL);
            }
           
        } 
        public static bool ChangeScheduleAndShiftStatus(string EmployeeId,DateTime ScheduleDate,bool IsComplete)
        {
            using(DataBaseContext dataBaseContext = new DataBaseContext())
            {
                Employee employee = dataBaseContext.Employee.Find(EmployeeId);
                if(employee != null)
                {
                    var scheduleAndShifts = dataBaseContext.AttendanceByShift.Where(c => c.EmployeeId == EmployeeId && c.ScheduleDate.Date == ScheduleDate.Date).ToList();
                    scheduleAndShifts.ForEach(c => c.IsCompleted = IsComplete);
                    dataBaseContext.AttendanceByShift.UpdateRange(scheduleAndShifts);
                    int result = dataBaseContext.SaveChanges();
                    if (result > 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }else
                {
                    return true;
                }
            }
        }

        public static bool UpdateAttendanceByDay(DbFirst.AttendanceByDay attendanceByDayCalcUnit,int k)
        {
            using (DataBaseContext dataBaseContext = new DataBaseContext() )
            {
                DbFirst.AttendanceByDay ExistAttendanceByDay = new DbFirst.AttendanceByDay();
                ExistAttendanceByDay = dataBaseContext.AttendanceByDay.Find(attendanceByDayCalcUnit.AttendanceByDayId);
                try
                {
                    ExistAttendanceByDay.IsWorkDay = attendanceByDayCalcUnit.IsWorkDay;
                    ExistAttendanceByDay.IsAbsentDay = attendanceByDayCalcUnit.IsAbsentDay;
                    ExistAttendanceByDay.DayShiftNameList = attendanceByDayCalcUnit.DayShiftNameList;
                    ExistAttendanceByDay.DayShiftListJson = attendanceByDayCalcUnit.DayShiftListJson;
                    ExistAttendanceByDay.DayTotalWorkTimeSpan = attendanceByDayCalcUnit.DayTotalWorkTimeSpan;
                    ExistAttendanceByDay.DayTotalWorkNetTimeSpan = attendanceByDayCalcUnit.DayTotalWorkNetTimeSpan;
                    ExistAttendanceByDay.DayTotalLunchTimeSpan = attendanceByDayCalcUnit.DayTotalLunchTimeSpan;
                    ExistAttendanceByDay.DayTotalOverTimeSpan = attendanceByDayCalcUnit.DayTotalOverTimeSpan;
                    ExistAttendanceByDay.DayLateInTimeSpan = attendanceByDayCalcUnit.DayLateInTimeSpan;
                    ExistAttendanceByDay.DayIsLateTimez = attendanceByDayCalcUnit.DayIsLateTimez;
                    ExistAttendanceByDay.DayEarlyOutTimeSpan = attendanceByDayCalcUnit.DayEarlyOutTimeSpan;
                    ExistAttendanceByDay.DayIsEarlyTimez = attendanceByDayCalcUnit.DayIsEarlyTimez;
                    ExistAttendanceByDay.DayLunchLateInTimeSpan = 0;
                    ExistAttendanceByDay.DayLunchIsLateTimez = 0;
                    ExistAttendanceByDay.DayLunchEarlyOutTimeSpan = 0;
                    ExistAttendanceByDay.DayLunchIsEarlyTimez =0;
                    ExistAttendanceByDay.DayOverTimeLateInTimeSpan = 0;
                    ExistAttendanceByDay.DayOverTimeIsLateTimez = 0;
                    ExistAttendanceByDay.DayOverTimeEarlyOutTimeSpan =0;
                    ExistAttendanceByDay.DayOverTimeIsEarlyTimez = 0;
                    ExistAttendanceByDay.DayMissingWorkOnTimez =0;
                    ExistAttendanceByDay.DayMissingWorkOffTimez = 0;
                    ExistAttendanceByDay.DayMissingLunchStartTimez = attendanceByDayCalcUnit.DayMissingLunchStartTimez;
                    ExistAttendanceByDay.DayMissingLunchEndTimez = attendanceByDayCalcUnit.DayMissingLunchEndTimez;
                    ExistAttendanceByDay.DayMissingOverTimeStartTimez = attendanceByDayCalcUnit.DayMissingOverTimeStartTimez;
                    ExistAttendanceByDay.DayMissingOverTimeEndTimez = attendanceByDayCalcUnit.DayMissingOverTimeEndTimez;

                    ExistAttendanceByDay.TotalTimesOfRegularWorkOn = attendanceByDayCalcUnit.TotalTimesOfRegularWorkOn;
                    ExistAttendanceByDay.TotalTimesOfRegularWorkOff = attendanceByDayCalcUnit.TotalTimesOfRegularWorkOff;
                    ExistAttendanceByDay.TotalTimesOfRegularLunchStart = attendanceByDayCalcUnit.TotalTimesOfRegularLunchStart;
                    ExistAttendanceByDay.TotalTimesOfRegularLunchEnd = attendanceByDayCalcUnit.TotalTimesOfRegularLunchEnd;
                    ExistAttendanceByDay.TotalTimesOfRegularOverTimeStart = attendanceByDayCalcUnit.TotalTimesOfRegularOverTimeStart;
                    ExistAttendanceByDay.TotalTimesOfRegularOverTimeEnd = attendanceByDayCalcUnit.TotalTimesOfRegularOverTimeEnd;

                    ExistAttendanceByDay.LeaveId = string.Empty;
                    ExistAttendanceByDay.LeaveType = attendanceByDayCalcUnit.LeaveType;
                    ExistAttendanceByDay.LeaveTypeName = string.Empty;
                    ExistAttendanceByDay.LeavePaidType = attendanceByDayCalcUnit.LeavePaidType;
                    ExistAttendanceByDay.LeavePaidTypeName = string.Empty;
                    ExistAttendanceByDay.LeaveWithPaidRatio = attendanceByDayCalcUnit.LeaveWithPaidRatio;
                    ExistAttendanceByDay.HolidayId = string.Empty;
                    ExistAttendanceByDay.HolidayName = string.Empty;
                    ExistAttendanceByDay.HolidayPaidType = attendanceByDayCalcUnit.HolidayPaidType;
                    ExistAttendanceByDay.HolidayPaidTypeName = string.Empty;
                    ExistAttendanceByDay.HolidayWithPaidRatio = 0;
                    ExistAttendanceByDay.OnDutyWorkRatioAvg = 1;
                    ExistAttendanceByDay.OnDutyPaidRatioAvg = 1;
                    ExistAttendanceByDay.CalcPeriodType = attendanceByDayCalcUnit.CalcPeriodType;
                    ExistAttendanceByDay.OnDataLocked = attendanceByDayCalcUnit.OnDataLocked;
                    ExistAttendanceByDay.IsCompleted = true;
                    ExistAttendanceByDay.SysCalcDateTime = attendanceByDayCalcUnit.SysCalcDateTime;

                    ExistAttendanceByDay.HmacHash = ScheduleAndShiftUtil.AttendanceByDayHmac(ExistAttendanceByDay);

                    dataBaseContext.AttendanceByDay.Update(ExistAttendanceByDay);
                    int result = dataBaseContext.SaveChanges();
                    bool update_result = result > 0;
                    if (update_result)
                    {
                        bool changeStatus = ChangeScheduleAndShiftStatus(ExistAttendanceByDay.EmployeeId, ExistAttendanceByDay.OccurDate.Date, true);
                      
                    }
                    else
                    {
                        string logText = string.Format("[HANDLE DAY BUSINESS] [UPDATE] [FAIL] [{0}] [{1:yyyy-MM-dd HH:mm:ss fff}][result = {2}][AttendanceByDayId = {3}]", k, ExistAttendanceByDay.OccurDate.Date, update_result, ExistAttendanceByDay.AttendanceByDayId);
                         
                    }
                    return result > 0;
                }
                catch (Exception ex)
                {
                    string errlog = string.Format("[AttendanceByDay] [Update] {0} {1}", ex.Message, attendanceByDayCalcUnit.AttendanceByDayId);
                    PublicGlobal.ConsoleWriteline(errlog, LoggerMode.FATAL); 
                    return false;
                }
            }
        }

        public static bool AddAttendanceByDay(DbFirst.AttendanceByDay attendanceByDayCalcUnit,int k)
        {
            using (DataBaseContext dataBaseContext = new DataBaseContext())
            {
                try
                {
                    dataBaseContext.AttendanceByDay.Add(attendanceByDayCalcUnit);
                    int result = dataBaseContext.SaveChanges();
                    if (result > 0)
                    {
                        bool changeStatus = ChangeScheduleAndShiftStatus(attendanceByDayCalcUnit.EmployeeId, attendanceByDayCalcUnit.OccurDate.Date, true);
                        string logText = string.Format("[HANDLE DAY BUSINESS][{0}] [{1:yyyy-MM-dd HH:mm:ss fff}][result = {2}][AttendanceByDayId = {3}][changeStatus = {4}]", k, attendanceByDayCalcUnit.OccurDate.Date, result, attendanceByDayCalcUnit.AttendanceByDayId, changeStatus);
                        PublicGlobal.ConsoleWriteline(logText, LoggerMode.INFO);
                        return true;
                    }
                    else
                    {
                        string logText = string.Format("[HANDLE DAY BUSINESS][FAILURE][{0}]", attendanceByDayCalcUnit.AttendanceByDayId);
                        PublicGlobal.ConsoleWriteline(logText, LoggerMode.FATAL);
                        return false;
                    }
                }
                catch (DbUpdateException ex)
                {
                    string loggerline = string.Format("[AttendanceByDayCalc] [DATABASE.ADD ERROR] [{0}]", ex.Message);
                    PublicGlobal.ConsoleWriteline(loggerline, attendanceByDayCalcUnit);
                    PublicGlobal.ConsoleWriteline(loggerline, LoggerMode.FATAL);
                    return false;
                }
            }
        }
    }
}
