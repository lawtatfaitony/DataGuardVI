using System;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections.Generic;
using AttendanceBussiness.DbFirst;
using static AttendanceBussiness.ShiftBusiness;
using AttendanceBussiness;
using Microsoft.EntityFrameworkCore;
using AttendanceBussiness.LeaveAndHoliday;
using Newtonsoft.Json;

namespace AttendanceBussiness.AttendanceSchedule
{
    public partial class SchedulePubBusiness
    {
        public static string GenerateScheduleId(Shift shift,DateTime scheduleDate,string employeeId)
        {
            string strScheduleDate = string.Format("{0:yyyyMMdd}", scheduleDate); 
            string HalfAnHourMiddlePartId = DateTimePubBusiness.HalfAnHourMiddlePartId("S", shift.WorkStart, 30);
            string midIdOfEndTime = DateTimePubBusiness.HalfAnHourMiddlePartId("E", shift.WorkEnd, 30);
            HalfAnHourMiddlePartId = string.Format("{0}{1}", HalfAnHourMiddlePartId, midIdOfEndTime);
            string ScheduleId = string.Format("{0:yyyyMMdd}{1}{2}", strScheduleDate, HalfAnHourMiddlePartId, employeeId);   //string.Format("{0:yyyyMMdd}{1}", strScheduleDate, EmployeeId);
            return ScheduleId;
        }
        public static bool IS_MANUAL_ASSIGNED( string ShiftId, string EmployeeId, string YearMonthDay)
        {
            using(DataBaseContext dbContext = new DataBaseContext())
            {
                string IdOfMonthlyShiftEmploy = string.Format("{0}{1}{2}", YearMonthDay, ShiftId, EmployeeId); 

                Schedule schedule = new Schedule { };
                schedule = dbContext.Schedule.Where(c => c.IdOfMonthlyShiftEmploy == IdOfMonthlyShiftEmploy && c.ShiftAssignedMode == 1).FirstOrDefault();

                if (schedule == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            } 
        }
        public static bool IS_MANUAL_ASSIGNED(string scheduleId)
        {
            using (DataBaseContext dbContext = new DataBaseContext())
            {
                Schedule schedule = new Schedule { };
                schedule = dbContext.Schedule.Where(c => c.ScheduleId == scheduleId && c.ShiftAssignedMode == (int)ShiftAssignedMode.MANUAL_ASSIGNED).FirstOrDefault();

                if (schedule == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public static bool IS_SYSTEM_ASSIGNED(string ShiftId, string EmployeeId, string YearMonthDay)
        {
            using (DataBaseContext dbContext = new DataBaseContext())
            {
                string IdOfMonthlyShiftEmploy = string.Format("{0}{1}{2}", YearMonthDay, ShiftId, EmployeeId);   // 20190820190619CAB20190914190605E0001

                Schedule schedule = new Schedule { };
                schedule = dbContext.Schedule.Where(c => c.IdOfMonthlyShiftEmploy == IdOfMonthlyShiftEmploy && c.ShiftAssignedMode == 0).FirstOrDefault();

                if (schedule == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public static bool IS_SYSTEM_ASSIGNED(string scheduleId)
        {
            using (DataBaseContext dbContext = new DataBaseContext())
            {
                Schedule schedule = new Schedule { };
                schedule = dbContext.Schedule.Where(c => c.ScheduleId == scheduleId).FirstOrDefault();

                if (schedule == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }      
        }
        public static bool EmployeeHasScheduleThatDay(string EmployeeId, DateTime ScheduleDate)
        {
            using (DataBaseContext dbContext = new DataBaseContext())
            {
                Schedule schedule = new Schedule { };
                schedule = dbContext.Schedule.Where(c => c.EmployeeId == EmployeeId && c.ScheduleDate == ScheduleDate).FirstOrDefault();

                if (schedule == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }   
        }
        public static bool EmployeeHasScheduleThatDay(string EmployeeId, DateTime ScheduleDate, ShiftAssignedMode shiftAssignedMode)
        {
            using (DataBaseContext dbContext = new DataBaseContext())
            {
                Schedule schedule = new Schedule { };
                schedule = dbContext.Schedule.Where(c => c.EmployeeId == EmployeeId && c.ScheduleDate == ScheduleDate && c.ShiftAssignedMode == (int)shiftAssignedMode).FirstOrDefault();

                if (schedule == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public static bool EmployeeExistScheduleThatDayDelete(string EmployeeId, DateTime ScheduleDate, ShiftAssignedMode shiftAssignedMode)
        {
            using (DataBaseContext dbContext = new DataBaseContext())
            {
                Schedule schedule = new Schedule { };
                schedule = dbContext.Schedule.Where(c => c.EmployeeId == EmployeeId && c.ScheduleDate == ScheduleDate && c.ShiftAssignedMode == (int)shiftAssignedMode && c.IsCompleted == false && c.OnDataLocked == false).FirstOrDefault();

                if (schedule == null)
                {
                    return false;
                }
                else
                {
                    var entry = dbContext.Entry(schedule);
                    entry.State = EntityState.Deleted;
                    bool result = dbContext.SaveChanges() > 0 ? true : false;

                    return result;
                }
            } 
        }
        public static bool EmployeeExistScheduleThatDayDelete(string EmployeeId, DateTime ScheduleDate,Shift shift)
        {
            using (DataBaseContext dbContext = new DataBaseContext())
            {
                string scheduleId = GenerateScheduleId(shift, ScheduleDate, EmployeeId);
                Schedule schedule = new Schedule();

                if (shift.ShiftAppliedMode == (int)ShiftAppliedMode.GLOBAL)
                {
                    schedule = dbContext.Schedule.Where(c => c.ScheduleId == scheduleId && c.ScheduleDate == ScheduleDate && c.ShiftAssignedMode == (int)ShiftAssignedMode.SYSTEM_ASSIGNED && c.IsCompleted == false && c.OnDataLocked == false).FirstOrDefault();
                }
                else
                {
                    schedule = dbContext.Schedule.Where(c => c.ScheduleId == scheduleId && c.ScheduleDate == ScheduleDate && c.IsCompleted == false && c.OnDataLocked == false).FirstOrDefault();
                }

                if (schedule == null)
                {
                    return false;
                }
                else
                {
                    var entry = dbContext.Entry(schedule);
                    entry.State = EntityState.Deleted;
                    bool result = dbContext.SaveChanges() > 0 ? true : false;
                    return result;
                }
            }
        }

        // SYSTEM_ASSIGNED = 0
        public static bool ScheduleSystemAssignedIns(string ShiftId, Shift shift, string EmployeeId, DateTime ScheduleDate, int shiftAssignedMode,bool ExceptHoliday,bool ExceptLeave)
        {
            using (DataBaseContext dbContext = new DataBaseContext())
            {
                if (!shift.IsApproved)
                {
                    return false;
                }
                string MainComId = dbContext.Employee.Find(EmployeeId).MainComId;
                string IdOfMonthlyShiftEmploy = string.Format("{0:yyyyMMdd}_{1}_{2}", ScheduleDate, ShiftId, EmployeeId);

                string ScheduleId = GenerateScheduleId(shift, ScheduleDate, EmployeeId);

                Schedule schedule = new Schedule
                {
                    ScheduleId = ScheduleId,
                    MainComId = MainComId,
                    IdOfMonthlyShiftEmploy = IdOfMonthlyShiftEmploy,
                    ShiftId = ShiftId,
                    ShiftAbbrId = shift.ShiftAbbrId,
                    EmployeeId = EmployeeId,
                    ScheduleDate = ScheduleDate,
                    WorkStart = WorkStart(shift, ScheduleDate),
                    WorkEnd = WorkEnd(shift, ScheduleDate),
                    ShiftAssignedMode = shiftAssignedMode,
                    OnDataLocked = false,
                    IsCompleted = false,
                    SysCalcDateTime = DateTime.Now
                };
                int result = 0;
                
                bool IsTodo = true;
                 
               
                //--------------------------------------------------
                bool bExceptEveryWeekDay = LeaveAndHolidayBusiness.ExceptEveryWeekDay(shift.ExcludeWeekDay, ScheduleDate);
                if (bExceptEveryWeekDay == true)
                {
                    IsTodo = false;
                }
                if (IsTodo)  // then ToDo
                {
                    if (IS_SYSTEM_ASSIGNED(ScheduleId) == false)
                    {
                        try
                        {
                            dbContext.Schedule.Add(schedule);
                            result = dbContext.SaveChanges(); 
                        }
                        catch (DbUpdateConcurrencyException Ex)
                        {
                            string jsonSchedule = JsonConvert.SerializeObject(schedule, Formatting.Indented);
                            Console.WriteLine("\n >>> [{0:yyyy-MM-dd mm:HH:ss fff}] [INFO] [func::ScheduleCalc::ScheduleSystemAssignedIns::Oject Schedule=\n", DateTime.Now, jsonSchedule);
                            Console.WriteLine("\n >>> [{0:yyyy-MM-dd mm:HH:ss fff}] [INFO] [func::ScheduleCalc::ScheduleSystemAssignedIns::DbUpdateConcurrencyException Ex {1}", DateTime.Now, Ex.Message);
                            Console.WriteLine("\n >>> [{0:yyyy-MM-dd mm:HH:ss fff}] [INFO] [func::ScheduleCalc::ScheduleSystemAssignedIns::catch: ShiftId = {1} , EmployeeId = {2} , ScheduleDate = {3:yyyy-MM-dd} , result = {4}]", DateTime.Now, schedule.ShiftId, schedule.EmployeeId, schedule.ScheduleDate, Ex.Message);
                        } 
                    }
                    else if (EmployeeExistScheduleThatDayDelete(schedule.EmployeeId, schedule.ScheduleDate, shift))
                    {
                        try
                        {
                            Console.WriteLine("\n >>> [{0:yyyy-MM-dd HH:mm:ss fff}][INFO][ EmployeeExistScheduleThatDayDelete:{1}][ID={2}][SCHEDULE DATE ={3}]", schedule.SysCalcDateTime, schedule.EmployeeId, schedule.ScheduleId, schedule.ScheduleDate);
                            dbContext.Schedule.Add(schedule);
                            result = dbContext.SaveChanges();
                        }
                        catch
                        {
                            var jsonSchedule = JsonConvert.SerializeObject(schedule, Formatting.Indented);
                            Console.WriteLine("\n >>> [{0:yyyy-MM-dd mm:HH:ss fff}] [INFO] [IS_SYSTEM_ASSIGNED = TRUE][func::ScheduleCalc::ScheduleSystemAssignedIns::catch: Object Json = \n{1}", DateTime.Now, jsonSchedule);
                            result = 0;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n >>> [{0:yyyy-MM-dd HH:mm:ss fff}][INFO] [EmployeeExistScheduleThatDayDelete = false > schedule == null:{1}]", schedule.SysCalcDateTime, schedule.EmployeeId);
                    }

                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("\n >>> [{0:yyyy-MM-dd HH:mm:ss}][INFO] [EmployeeId = {1}] [IsTodo = {2}]; [[ScheduleDate = {3:yyyy-MM-dd}] [bExceptEveryWeekDay = {4}]\n", DateTime.Now, EmployeeId, IsTodo, ScheduleDate, bExceptEveryWeekDay);
                    return false; //remark://------------------------------------------------------
                }
            }  
        }
         
        public static TimeSpan WorkStart(Shift shift,DateTime ScheduleDate)
        {
            int weekDayOfScheduleDate = Convert.ToInt32(ScheduleDate.DayOfWeek);
            if (string.IsNullOrEmpty(shift.SpecialWeekDays))
            {
                return shift.WorkStart;
            }

            string SpecialWeekDays = shift.SpecialWeekDays.Trim();

            if (SpecialWeekDays.Length > 0)
            {
                string[] arrSpecialWeekDays = SpecialWeekDays.Split(',');
                int[] intArrSpecialWeekDays = Array.ConvertAll<string, int>(arrSpecialWeekDays, s => int.Parse(s));
                foreach (int item in intArrSpecialWeekDays)
                { 
                    if (weekDayOfScheduleDate == item)
                    {
                        return shift.SpecialWeekDaysWorkStart;
                    }else
                    {
                        return shift.WorkStart;
                    }
                }
                return new TimeSpan(shift.WorkStart.Hours, shift.WorkStart.Minutes, 0);
            }
            else
            {
                return new TimeSpan(shift.WorkStart.Hours, shift.WorkStart.Minutes, 0);
            }
        }
        public static TimeSpan WorkEnd(Shift shift, DateTime ScheduleDate)
        {
            int weekDayOfScheduleDate = Convert.ToInt32(ScheduleDate.DayOfWeek);
            if (string.IsNullOrEmpty(shift.SpecialWeekDays))
            {
                return shift.WorkEnd;
            } 
            string SpecialWeekDays = shift.SpecialWeekDays.Trim(); 
            if (SpecialWeekDays.Length > 0)
            {
                string[] arrSpecialWeekDays = SpecialWeekDays.Split(',');
                int[] intArrSpecialWeekDays = Array.ConvertAll<string, int>(arrSpecialWeekDays, s => int.Parse(s));
                foreach (int item in intArrSpecialWeekDays)
                {  
                    if (weekDayOfScheduleDate == item)
                    {
                        return shift.SpecialWeekDaysWorkEnd;
                    }
                    else
                    {
                        return shift.WorkEnd;
                    }
                }
                return new TimeSpan(shift.WorkEnd.Hours, shift.WorkEnd.Minutes, 0);
            }
            else
            {
                return new TimeSpan(shift.WorkEnd.Hours, shift.WorkEnd.Minutes, 0);
            }
        }

        public static DateTime GetShiftTimeEndpiont(Shift shift, DateTime ScheduleDate)
        {
            DateTime ScheduleDateZeroTS = new DateTime(ScheduleDate.Year, ScheduleDate.Month, ScheduleDate.Day, 0, 0, 0, 0); 
            string SpecialWeekDays = shift.SpecialWeekDays.Trim();
            string ExcludeOverTime = shift.ExcludeOverTime.Trim();

            TimeSpan EndpiontOfTimeSpan = new TimeSpan();
            DateTime EndpiontOfScheduleDatetime = ScheduleDateZeroTS;
            TimeSpan bufferOfWorkTimeEnd = new TimeSpan(0, shift.WorkEndBuffer, 0);
            TimeSpan bufferOfOverTimeEnd = new TimeSpan(0, shift.OverTimeEndBuffer, 0);
            TimeSpan ts0 = new TimeSpan(0, 0, 0, 0, 0);

            int weekDayOfScheduleDate = Convert.ToInt32(ScheduleDate.DayOfWeek);

            bool IsExcludeOverTime = true;
            if (!string.IsNullOrEmpty(ExcludeOverTime))
            {
                string[] arrExcludeOverTime = ExcludeOverTime.Split(',');
                int[] intArrExcludeOverTime = Array.ConvertAll<string, int>(arrExcludeOverTime, s => int.Parse(s));
                IsExcludeOverTime = intArrExcludeOverTime.Where(c => c == weekDayOfScheduleDate).Count() > 0 ? true : false;
            }

            if (string.IsNullOrEmpty(SpecialWeekDays))
            {
                if(shift.OverTimeEnd == ts0)
                {
                    EndpiontOfTimeSpan = shift.WorkEnd.Add(bufferOfWorkTimeEnd);
                    return EndpiontOfScheduleDatetime.AddMinutes(EndpiontOfTimeSpan.TotalMinutes);
                }else
                {
                    if(IsExcludeOverTime)
                    {
                        EndpiontOfTimeSpan = shift.WorkEnd.Add(bufferOfWorkTimeEnd);
                        return EndpiontOfScheduleDatetime.AddMinutes(EndpiontOfTimeSpan.TotalMinutes);
                    }
                    else
                    {
                        EndpiontOfTimeSpan = shift.OverTimeEnd.Add(bufferOfOverTimeEnd);
                        return EndpiontOfScheduleDatetime.AddMinutes(EndpiontOfTimeSpan.TotalMinutes);
                    }
                }
            }else 
            {
                TimeSpan specialWeekDaysWorkEnd = new TimeSpan(); 
                string[] arrSpecialWeekDays = SpecialWeekDays.Split(',');
                int[] intArrSpecialWeekDays = Array.ConvertAll<string, int>(arrSpecialWeekDays, s => int.Parse(s));
                bool IsSpecialWeekDay = intArrSpecialWeekDays.Where(c => c == weekDayOfScheduleDate).Count() > 0 ? true : false;
                 
                if (IsSpecialWeekDay)
                {
                    if (IsExcludeOverTime)
                    {
                        specialWeekDaysWorkEnd = shift.SpecialWeekDaysWorkEnd;
                        EndpiontOfTimeSpan = specialWeekDaysWorkEnd.Add(bufferOfWorkTimeEnd);
                        return EndpiontOfScheduleDatetime.AddMinutes(EndpiontOfTimeSpan.TotalMinutes);
                    }
                    else
                    {
                        EndpiontOfTimeSpan = shift.OverTimeEnd.Add(bufferOfOverTimeEnd);
                        return EndpiontOfScheduleDatetime.AddMinutes(EndpiontOfTimeSpan.TotalMinutes);
                    } 
                }
                else
                {
                    if (shift.OverTimeEnd == ts0)
                    {
                        EndpiontOfTimeSpan = shift.WorkEnd.Add(bufferOfWorkTimeEnd);
                        return EndpiontOfScheduleDatetime.AddMinutes(EndpiontOfTimeSpan.TotalMinutes);
                    }
                    else
                    {
                        if (IsExcludeOverTime)
                        {
                            specialWeekDaysWorkEnd = shift.SpecialWeekDaysWorkEnd;
                            EndpiontOfTimeSpan = specialWeekDaysWorkEnd.Add(bufferOfWorkTimeEnd);
                            return EndpiontOfScheduleDatetime.AddMinutes(EndpiontOfTimeSpan.TotalMinutes);
                        }
                        else
                        {
                            EndpiontOfTimeSpan = shift.OverTimeEnd.Add(bufferOfOverTimeEnd);
                            return EndpiontOfScheduleDatetime.AddMinutes(EndpiontOfTimeSpan.TotalMinutes);
                        }
                    }
                }  
            }
        }
        public static bool OnDataLockedChange(string ScheduleId, bool OnDataLocked)
        {
            bool result = false;
            using (DataBaseContext dataBaseContext = new DataBaseContext())
            {
                Schedule schedule = dataBaseContext.Schedule.Find(ScheduleId);
                try
                {
                    schedule.OnDataLocked = OnDataLocked;
                    schedule.SysCalcDateTime = DateTime.Now;
                    dataBaseContext.Attach(schedule);
                    dataBaseContext.Entry(schedule).Property(p => p.OnDataLocked).IsModified = true;
                    dataBaseContext.Entry(schedule).Property(p => p.SysCalcDateTime).IsModified = true;
                    result = dataBaseContext.SaveChanges() > 0 ? true : false;
                    return result;
                }
                catch
                {
                    result = false;
                    return result;
                }
            }
        }
        public static bool OnDataLockedChange(List<Schedule> schedules, bool OnDataLocked)
        {
            bool result = false;
            using (DataBaseContext dataBaseContext = new DataBaseContext())
            {
                try
                {
                    schedules.ForEach(c => c.OnDataLocked = OnDataLocked);
                    dataBaseContext.Schedule.AttachRange(schedules);
                    result = dataBaseContext.SaveChanges() > 0 ? true : false;
                    return result;
                }
                catch
                {
                    result = false;
                    return result;
                }
            }
        }
        public static bool IsCompletedChange(string ScheduleId, bool IsCompleted)
        {
            bool result = false;
            using (DataBaseContext dataBaseContext = new DataBaseContext())
            {
                Schedule schedule = dataBaseContext.Schedule.Find(ScheduleId);
                try
                {
                    schedule.IsCompleted = IsCompleted;
                    schedule.SysCalcDateTime = DateTime.Now;
                    dataBaseContext.Attach(schedule); 
                    dataBaseContext.Entry(schedule).Property(p => p.IsCompleted).IsModified = true;
                    dataBaseContext.Entry(schedule).Property(p => p.SysCalcDateTime).IsModified = true;
                    result = dataBaseContext.SaveChanges() > 0 ? true : false;
                    return result;
                }
                catch
                {
                    result = false;
                    return result;
                }
            }
        }
    }
}
