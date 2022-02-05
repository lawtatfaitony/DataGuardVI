using AttendanceBussiness; 
using AttendanceBussiness.DbFirst;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TaskRunningPlan.AttendanceByPeriod;
using TaskRunningPlan.TaskFactoryScheduleJOB;
using TaskRunningPlan.AttendanceSchedule;
using Common;

namespace TaskRunningPlan.CalculationPlan
{
    public class TaskProgram
    {
        
        public static GlobalConfig globalConfig = new GlobalConfig();
        public static void TaskProgramSchedule()
        {
            string loggerLine = "[SCHEDULE BUSINESS MONTHLY]";
            Console.WriteLine($"\n{loggerLine}");
            Common.CommonBase.OperateDateLoger(loggerLine, CommonBase.LoggerMode.INFO);

            TaskSettingPlan.InitializeSceduleStartDate();

            string taskIdCorrespondingToSceduleDaily = TaskSettingConfig.CalcPeriodType_DAYLY_ScheduleAndShiftCalcJob;

            TaskSetting taskSetting = TaskSettingPlan.GetTaskSettingbyId(taskIdCorrespondingToSceduleDaily);

            ScheduleGlobal.RunScheduleMonthlyGlobalProgram(ShiftBusiness.CalcPeriodType.MONTHLY, taskSetting.TaskStartDate).GetAwaiter();
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------
        public static void TaskProgramScheduleShiftCalc(DateTime ConsoleStartDate)
        {
            Console.WriteLine("\n[SCHEDULE SHIFT CALC BUSINESS]");
            DateTime monthlyScheduleCalc = globalConfig.MonthlyScheduleCalc.AddHours(1); // one our later after schedule monthly Completed.
            double laterHour = monthlyScheduleCalc.Ticks > 637406820300000000 ? 1 : 0.01;
            monthlyScheduleCalc = monthlyScheduleCalc.AddHours(laterHour);
            int TimesOfTaskRunning = 1;  
            ScheduleAndShiftCalcJob.RunScheduleAndShiftCalcProgram(ShiftBusiness.CalcPeriodType.DAYLY, monthlyScheduleCalc, TimesOfTaskRunning).GetAwaiter();
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------
        public static void TaskProgramAttendanceByDayCalc(DateTime ConsoleStartDate)
        {
            Console.WriteLine("\n[ATTENDANCE DAY CALC BUSINESS]");
            DateTime monthlyScheduleCalc = globalConfig.MonthlyScheduleCalc; // one our later after TaskProgramScheduleShiftCalc monthly Completed.
            double laterHour = monthlyScheduleCalc.Ticks > 637406820300000000 ? 3 : 0.3;
            monthlyScheduleCalc = monthlyScheduleCalc.AddHours(laterHour);

            AttendanceByDayJOB.RunAttendanceByDayCalcProgram(monthlyScheduleCalc).GetAwaiter();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------
        public static void TaskProgramAttendanceByPeriodCalc(DateTime ConsoleStartDate)
        {
            Console.WriteLine("\n[ATTENDANCE MONTHLY PERIOD CALC BUSINESS]");
            DateTime monthlyScheduleCalc = globalConfig.MonthlyScheduleCalc;  
            double laterHour = monthlyScheduleCalc.Ticks > 637406820300000000 ? 5 : 0.5;
            monthlyScheduleCalc = monthlyScheduleCalc.AddHours(laterHour);

            AttendanceByPeriodJOB.RunAttendanceByPeriodGlobalProgram(ShiftBusiness.CalcPeriodType.MONTHLY, monthlyScheduleCalc).GetAwaiter();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------
        public static void TaskFactoryProgramDaily()
        {
            TaskSetting taskSetting = TaskSettingPlan.GetTaskSettingbyId(TaskSettingConfig.TaskFactoryScheduleJOB);

            TaskFactorySchedule.TaskDailyrogram(taskSetting.TaskStartDate, taskSetting.TaskRuningStartTime).GetAwaiter();
        }
    }
}