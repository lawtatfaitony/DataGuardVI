using AttendanceBussiness.DbFirst;
using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static Common.CommonBase;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AttendanceBussiness.ScheduleAndShift;

namespace AttendanceBussiness.AttendanceByPeriod
{
    public class AttendanceByPeriodBusiness
    {
        private object obj1 = new object(); 
        private static List<DbFirst.Employee> _employees;
        public static bool ThisMonthFinished()
        {
            return true;
        }
        public AttendanceByPeriodBusiness()
        {
            using(DataBaseContext dataBaseContext = new DataBaseContext())
            {
                _employees = dataBaseContext.Employee.Where(c => c.IsBlock == false).ToList();
            } 
        }

        public void CalcPeriod()
        {
            DateTime currentMonth = DateTime.Now.AddHours(-12);
            foreach(var item in _employees)
            {
                lock (obj1) { 
                    try
                    {
                        AttendanceByPeriodCalcUnit pCalcUnit = new AttendanceByPeriodCalcUnit(ShiftBusiness.CalcPeriodType.MONTHLY, item, currentMonth);

                        string loggerLine = string.Format("[ATTENDANCE BY PERIOD BUSINESS] [THE CURRENT] [FullName = {0} ][EmployeeId = {1} ]", item.FullName, item.EmployeeId);
                        Console.WriteLine(loggerLine);
                     
                        try
                        {
                            string pCalcUnitJson = JsonConvert.SerializeObject(pCalcUnit);
                            //debug
                            //Console.WriteLine("pCalcUnitJson : \n{0}",CommonBase.JsonFormat( pCalcUnitJson )); 

                            using (DataBaseContext dataBaseContext = new DataBaseContext() )
                            {
                                bool result;
                                DbFirst.AttendanceByPeriod attendanceByPeriod = new DbFirst.AttendanceByPeriod
                                {
                                    AttendanceByPeriodId = pCalcUnit.AttendanceByPeriodId,
                                    Mode = pCalcUnit.Mode,
                                    ObjectData = CommonBase.StringToBase64(pCalcUnitJson),
                                    ShiftNameStructure = CalcShiftNameStructureList(pCalcUnit.EmployeeId, pCalcUnit.StartDate, pCalcUnit.EndDate),
                                    MainComId = pCalcUnit.MainComId,
                                    CalcPeriodType = pCalcUnit.CalcPeriodType,
                                    EmployeeId = pCalcUnit.EmployeeId,
                                    EmployeeName = pCalcUnit.EmployeeName,
                                    DepartmentId = pCalcUnit.DepartmentId,
                                    DepartmentName = pCalcUnit.DepartmentName,
                                    PositionId = pCalcUnit.PositionId,
                                    PositionTitle = pCalcUnit.PositionTitle,
                                    ContractorId = pCalcUnit.ContractorId,
                                    ContractorName = pCalcUnit.ContractorName,
                                    JobId = pCalcUnit.JobId,
                                    JobName = pCalcUnit.JobName,
                                    SiteId = pCalcUnit.SiteId,
                                    SiteName = pCalcUnit.SiteName,
                                    AvgWorkActualNetTimeSpan = Convert.ToInt64(pCalcUnit.AvgWorkActualNetTimeSpan.TotalSeconds),
                                    AccuWorkActualNetTimeSpan = Convert.ToInt64(pCalcUnit.AccuWorkActualNetTimeSpan.TotalSeconds),
                                    AvgWorkTimeSpan = Convert.ToInt64(pCalcUnit.AvgWorkTimeSpan.TotalSeconds),
                                    AccuWorkTimeSpan = Convert.ToInt64(pCalcUnit.AccuWorkTimeSpan.TotalSeconds),
                                    AvgLunchTimeSpan = Convert.ToInt64(pCalcUnit.AvgLunchTimeSpan.TotalSeconds),
                                    AccuLunchTimeSpan = Convert.ToInt64(pCalcUnit.AccuLunchTimeSpan.TotalSeconds),
                                    AvgOverTimeSpan = Convert.ToInt64(pCalcUnit.AvgOverTimeSpan.TotalSeconds),
                                    AccuOverTimeSpan = Convert.ToInt64(pCalcUnit.AccuOverTimeSpan.TotalSeconds),
                                    AccuLeaveDays = pCalcUnit.AccuLeaveDays,
                                    AccuHolidays = pCalcUnit.AccuHolidays,
                                    AccuWorkDays = pCalcUnit.AccuWorkDays,
                                    AccuAbsentDays = pCalcUnit.AccuAbsentDays,
                                    AccuTimesOfLateIn = pCalcUnit.AccuTimesOfLateIn,
                                    AccuLateInTimeSpan = Convert.ToInt64(pCalcUnit.AccuLateInTimeSpan.TotalSeconds),
                                    AccuTimesOfEarlyOut = pCalcUnit.AccuTimesOfEarlyOut,
                                    AccuEarlyOutTimeSpan = Convert.ToInt64(pCalcUnit.AccuEarlyOutTimeSpan.TotalSeconds),
                                    AccuTimesOfLunchLateIn = pCalcUnit.AccuTimesOfLunchLateIn,
                                    AccuLunchLateInTimeSpan = Convert.ToInt64(pCalcUnit.AccuLunchLateInTimeSpan.TotalSeconds),
                                    AccuTimesOfLunchEarlyOut = pCalcUnit.AccuTimesOfLunchEarlyOut,
                                    AccuEarlyLunchOutTimeSpan = Convert.ToInt64(pCalcUnit.AccuEarlyLunchOutTimeSpan.TotalSeconds),
                                    AccuTimesOfOverTimeLateIn = pCalcUnit.AccuTimesOfOverTimeLateIn,
                                    AccuOverTimeLateInTimeSpan = Convert.ToInt64(pCalcUnit.AccuOverTimeLateInTimeSpan.TotalSeconds),
                                    AccuTimesOfOverTimeEarlyOut = pCalcUnit.AccuTimesOfOverTimeEarlyOut,
                                    AccuEarlyOverTimeOutTimeSpan = Convert.ToInt64(pCalcUnit.AccuEarlyOverTimeOutTimeSpan.TotalSeconds),
                                    AccuTimesOfRegular = pCalcUnit.AccuTimesOfRegular,
                                    AccuTimesOfRegularWorkOn = pCalcUnit.AccuTimesOfRegularWorkOn,
                                    AccuTimesOfRegularWorkOff = pCalcUnit.AccuTimesOfRegularWorkOff,
                                    AccuTimesOfRegularLunchStart = pCalcUnit.AccuTimesOfRegularLunchStart,
                                    AccuTimesOfRegularLunchEnd = pCalcUnit.AccuTimesOfRegularLunchEnd,
                                    AccuTimesOfRegularOverTimeStart = pCalcUnit.AccuTimesOfRegularOverTimeStart,
                                    AccuTimesOfRegularOverTimeEnd = pCalcUnit.AccuTimesOfRegularOverTimeEnd,
                                    AccuTimesOfMissing = pCalcUnit.AccuTimesOfMissing,
                                    AccuTimesOfMissingWorkOn = pCalcUnit.AccuTimesOfMissingWorkOn,
                                    AccuTimesOfMissingWorkOff = pCalcUnit.AccuTimesOfMissingWorkOff,
                                    AccuTimesOfMissingLunchStart = pCalcUnit.AccuTimesOfMissingLunchStart,
                                    AccuTimesOfMissingLunchEnd = pCalcUnit.AccuTimesOfMissingLunchEnd,
                                    AccuTimesOfMissingOverTimeStart = pCalcUnit.AccuTimesOfMissingOverTimeStart,
                                    AccuTimesOfMissingOverTimeEnd = pCalcUnit.AccuTimesOfMissingOverTimeEnd,
                                    AvgOnDutyWorkRatio = pCalcUnit.AvgOnDutyWorkRatio,
                                    AvgOnDutyPaidRatio = pCalcUnit.AvgOnDutyPaidRatio,
                                    OnDataLocked = pCalcUnit.OnDataLocked,
                                    IsCompleted = pCalcUnit.IsCompleted,
                                    StartDate = pCalcUnit.StartDate,
                                    EndDate = pCalcUnit.EndDate,
                                    SysCalcDateTime = pCalcUnit.SysCalcDateTime,
                                    HmacHash = string.Empty
                                };
                                attendanceByPeriod.HmacHash = ScheduleAndShiftUtil.AttendanceByPeriodHmac(attendanceByPeriod);
                                int HasExistRecord = dataBaseContext.AttendanceByPeriod.AsNoTracking().Where(c => c.AttendanceByPeriodId.Contains(pCalcUnit.AttendanceByPeriodId)).Count();
                                attendanceByPeriod = ConfuExCalc(attendanceByPeriod);
                                if (HasExistRecord == 0)
                                {
                                    dataBaseContext.Add(attendanceByPeriod);
                                    result = dataBaseContext.SaveChanges() > 0 ? true : false;
                                }
                                else
                                {
                                    dataBaseContext.Update(attendanceByPeriod);
                                    dataBaseContext.Attach<DbFirst.AttendanceByPeriod>(attendanceByPeriod).State = EntityState.Modified;
                                    dataBaseContext.Entry<DbFirst.AttendanceByPeriod>(attendanceByPeriod).State = EntityState.Modified;
                                    result = dataBaseContext.SaveChanges() > 0 ? true : false;
                                }
                                
                                if (result)
                                {
                                    Console.WriteLine(string.Format("[ATTENDANCE BY PERIOD BUSINESS] [SAVE TO DATABASE]{0} {1} [SUCCCESS]\n", item.FullName, item.EmployeeId));
                                }
                                else
                                {
                                    Console.WriteLine(string.Format("[ATTENDANCE BY PERIOD BUSINESS] [SAVE TO DATABASE]{0} {1} [FAIL]\n", item.FullName, item.EmployeeId));
                                }
                            }
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(string.Format("[JSON SERIALOBJECT FAILUE]{0}", e.Message));
                            loggerLine = string.Format("[ATTENDANCE BY PERIOD BUSINESS] [CalcPeriod::AttendanceByPeriodCalcUnit] [FAILURE] [FullName = {0}][EmployeeId = {1}] \n[{2}]", item.FullName, item.EmployeeId, e.Message);
                            Common.CommonBase.OperateDateLoger(loggerLine, pCalcUnit, LoggerMode.FATAL);
                        }
                        // 
                        Thread.Sleep(6000);
                    }
                    catch(Exception e)
                    {
                        string loggerLine = string.Format("[ATTENDANCE BY PERIOD BUSINESS] [CalcPeriod::AttendanceByPeriodCalcUnit] [FAILURE] [FullName = {0}][EmployeeId = {1}] \n[{2}]", item.FullName,item.EmployeeId,e.Message);
                        Common.CommonBase.OperateDateLoger(loggerLine,LoggerMode.FATAL);
                    }
                }
            }
        }

        public static List<ShiftNameStructure> GetShiftNameStructureDTO(string shiftNameStructure)
        {
            if (!string.IsNullOrEmpty(shiftNameStructure))
            {
                List<ShiftNameStructure> shiftNameStructureList = JsonConvert.DeserializeObject<List<ShiftNameStructure>>(CommonBase.Base64ToString(shiftNameStructure));
                return shiftNameStructureList;
            }
            else
            {
                return null;
            } 
        } 

        public static string CalcShiftNameStructureList(string employeeId, DateTime StateDate,DateTime EndDate)
        {
            string result = string.Empty;

            List<DbFirst.AttendanceByPeriod> listNew  = new List<DbFirst.AttendanceByPeriod>();
            using (DataBaseContext dbContext = new DataBaseContext())
            {
                List<Shift> shifts = dbContext.Shift.AsNoTracking().Where(c => c.IsApproved == true).ToList();
                 
                var schedules = dbContext.Schedule.AsNoTracking().Select(c => new {c.ScheduleDate, c.ScheduleId, c.ShiftId, c.EmployeeId })
                    .Where(c => c.EmployeeId == employeeId && c.ScheduleDate >= StateDate.Date & c.ScheduleDate >= EndDate.Date).Select(c=>new { c.ShiftId}).GroupBy(c=>c.ShiftId).ToList();

                List<ShiftNameStructure> shiftNameStructureList = new List<ShiftNameStructure>();
                foreach (var item2 in schedules)
                {
                    Shift shift = shifts.Where(c=>c.ShiftId.Contains(item2.Key)).FirstOrDefault();
                    int exitCount = 0;
                    if(shiftNameStructureList != null)
                    {
                        exitCount = shiftNameStructureList.Where(c => c.ShiftId.Contains(item2.Key)).Count();
                    }

                    if (shift != null && exitCount==0)
                    {
                        try
                        {
                            ShiftNameStructure shiftNameStructure = new ShiftNameStructure
                            {
                                ShiftId = shift.ShiftId,
                                IconColor = shift.IconColor,
                                ShiftAbbrId = shift.ShiftAbbrId,
                                ShiftName = shift.ShiftName
                            };
                            shiftNameStructureList.Add(shiftNameStructure); // shift.Result;
                        }
                        catch(Exception a)
                        {
                            throw a;
                        }
                    }
                }
                 
                if(shiftNameStructureList.Count>0)
                {
                    result = JsonConvert.SerializeObject(shiftNameStructureList);
                    return CommonBase.StringToBase64(result);
                }
                return result;
            }
        }
        private DbFirst.AttendanceByPeriod ConfuExCalc(DbFirst.AttendanceByPeriod pCalcUnit)
        {
            int A = new Random(Guid.NewGuid().GetHashCode()).Next(0, 11);  //month
            
            return pCalcUnit;
        }

        public static string AbbrPid(string str, int StartIndex, int RemoveLenght)
        {
            if (string.IsNullOrEmpty(str) || str.Length < StartIndex)
            {
                return str;
            }
            str = str.Replace("\"", "");
            str = str.Replace("'", "");
            if (str.Length > StartIndex)
            {
                return string.Format("{0}..", str.Remove(StartIndex, RemoveLenght).TrimStart('0'));
            }
            else
            {
                return str;
            }
        }
    }
}
