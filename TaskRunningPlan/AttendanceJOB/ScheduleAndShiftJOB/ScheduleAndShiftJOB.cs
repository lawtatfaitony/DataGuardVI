using System;
using System.Text;
using System.Threading;
using System.Timers;
using TaskRunningPlan.AttendanceSchedule;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Quartz.Impl;
using Quartz;
using Quartz.Logging;
using Quartz.Impl.Matchers;
using static Quartz.MisfireInstruction;
using static AttendanceBussiness.ShiftBusiness; 
using AttendanceBussiness;
using AttendanceBussiness.DbFirst;
using AttendanceBussiness.ScheduleAndShift;
using TaskRunningPlan.CalculationPlan;
using AttendanceBussiness.AttendanceByDay;
using static Common.CommonBase;
using Common;

namespace TaskRunningPlan.AttendanceSchedule
{
    public partial class ScheduleAndShiftCalcJob
    { 
        private static int _TimesOfTaskRunning = 1;
        private static ShiftBusiness.CalcPeriodType CalcPeriodType; 
        private static DateTime _TaskStartDate;
        public static DateTime TaskStartDate
        {
            get
            {
                return _TaskStartDate;
            }
            set
            {
                _TaskStartDate = value;
            }
        }
        public static async Task RunScheduleAndShiftCalcProgram(ShiftBusiness.CalcPeriodType calcPeriodType, DateTime TaskStartDate,int TimesOfTaskRunning)
        {
            DateTime dateTimeLimited = new DateTime(637406496000000000);  //20111111test
            _TaskStartDate = TaskStartDate;
            _TimesOfTaskRunning = TimesOfTaskRunning;
            CalcPeriodType = calcPeriodType;
            int intervalMinutes = dateTimeLimited > DateTime.Now ? 9 : 360;
            try
            { 
                NameValueCollection props = new NameValueCollection
                {
                    { "quartz.serializer.type", "binary" }
                };
                StdSchedulerFactory factory = new StdSchedulerFactory(props);
                IScheduler scheduler = await factory.GetScheduler();

                await scheduler.Start();

                IJobDetail job = JobBuilder.Create<ScheduleAndShiftCalcDaylyJob>()
                    .WithIdentity("Job1_ScheduleAndShiftCalc", "Group_ScheduleAndShiftCalc")
                    .Build();
                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("trigger1_ScheduleAndShiftCalc")
                    .StartAt(TaskStartDate)
                    .ForJob("Job1_ScheduleAndShiftCalc", "Group_ScheduleAndShiftCalc")
                    .WithCalendarIntervalSchedule(w => w
                    .WithIntervalInMinutes(intervalMinutes)
                    )
                    .Build();
                 
                await scheduler.ScheduleJob(job, trigger); 
                await Task.Delay(TimeSpan.FromSeconds(10)); 
            }
            catch (SchedulerException se)
            {
                await Console.Error.WriteLineAsync(se.ToString());
            }
        }

        public class ScheduleAndShiftCalcDaylyJob : IJob
        { 
            public Task Execute(IJobExecutionContext context)
            {
                string loggerLineJob = "";
                if (CalcPeriodType == ShiftBusiness.CalcPeriodType.DAYLY)
                {
                    DateTime RunnedTime = DateTime.Now;
                      
                    ScheduleAndShiftCalc.ShiftCalcDaylyX();
                     
                    string logline_IsUpdStartDate = string.Format("\n[{0:yyyy-MM-dd HH:mm:ss fff}] [SCHEDULE_SHIFT_CALC_START] [func::ScheduleCalc.Execute ScheduleAndShiftCalcDaylyJob] [TaskStartDate {1:yyyy-MM-dd  HH:mm:ss fff}]", DateTime.Now,  TaskStartDate);
                    Console.Out.WriteLineAsync(logline_IsUpdStartDate);
                    CommonBase.OperateDateLoger(logline_IsUpdStartDate, LoggerMode.INFO);
                }
                loggerLineJob = string.Format("\n[{0:yyyy-MM-dd HH:mm:ss fff}] [INFO] [Execute::ScheduleAndShiftCalcDaylyJob:{1}]", DateTime.Now, context.FireInstanceId);
                CommonBase.OperateDateLoger(loggerLineJob, LoggerMode.ERROR);
                return Console.Out.WriteLineAsync(loggerLineJob); 
            }
        }
    }
}

