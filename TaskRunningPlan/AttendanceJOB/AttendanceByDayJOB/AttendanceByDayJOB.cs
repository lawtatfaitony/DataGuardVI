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
using AttendanceBussiness.AttendanceByDay;
using Common;
using static Common.CommonBase;

namespace TaskRunningPlan.AttendanceSchedule
{
    public partial class AttendanceByDayJOB
    { 
        public static async Task RunAttendanceByDayCalcProgram(DateTime ConsoleStartDate)
        {
            DateTime dateTimeLimited = new DateTime(637344288000000000);  //200831
            int intervalMinutes = dateTimeLimited > DateTime.Now ? 9 : 59;
            double intervalAfterByShiftCalc = dateTimeLimited > DateTime.Now ? 0.05 : 3; //3mins
            using (DataBaseContext dataBaseContext = new DataBaseContext())
            {
                TaskSetting taskSetting = dataBaseContext.TaskSetting.Find(TaskSettingConfig.CalcPeriodType_DAYLY_ScheduleAndShiftCalcJob);
                DateTime JobStartDate = ConsoleStartDate;//taskSetting.TaskStartDate.AddHours(intervalAfterByShiftCalc);
                try
                {
                    NameValueCollection props = new NameValueCollection
                {
                    { "quartz.serializer.type", "binary" }
                };
                    StdSchedulerFactory factory = new StdSchedulerFactory(props);
                    IScheduler scheduler = await factory.GetScheduler();

                    await scheduler.Start();

                    IJobDetail job = JobBuilder.Create<AttendanceByDayCalcJob>()
                        .WithIdentity("JOB_AttendanceByDayCalc", "GROUP3")
                        .Build();
                    ITrigger trigger = TriggerBuilder.Create()
                        .WithIdentity("trigger1_AttendanceByDayCalc")
                        .StartAt(JobStartDate)
                        .ForJob("JOB_AttendanceByDayCalc", "GROUP3")
                        .WithCalendarIntervalSchedule(w => w
                        .WithIntervalInMinutes(intervalMinutes)   //.WithIntervalInSeconds(intervalMinutes) //.WithIntervalInDays(1).WithIntervalInSeconds(intervalMinutes)
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
        }
        //[DisallowConcurrentExecution] 
        public class AttendanceByDayCalcJob : IJob
        {
            public Task Execute(IJobExecutionContext context)
            {
                DateTime RunnedTime = DateTime.Now;
                bool IsJobTimeRange = TaskSettingPlan.IsRunnedByTaskSettingBusiness(TaskSettingConfig.CalcPeriodType_DAYLY_ScheduleAndShiftCalcJob, RunnedTime);
                if (IsJobTimeRange)
                {
                    //-----------------------------------------------------------------
                    string loggerLineJob = string.Format("[{0:yyyy-MM-dd HH:mm:ss fff}] [ATTENDANCE BY DAY CALC START JOB]", DateTime.Now);
                    CommonBase.OperateDateLoger(loggerLineJob,LoggerMode.INFO);

                    AttendanceByDayCalc.CalcByDay();
                    //if fininsh then calc by month remain //===============================================
                    return Console.Out.WriteLineAsync(string.Format("\n[{0:yyyy-MM-dd HH:mm:ss fff}] [INFO] [Execute::AttendanceByDayCalcJob:{1}]", DateTime.Now, context.FireInstanceId));
                }
                else
                {
                    string loggerLineJob = string.Format("\n[{0:yyyy-MM-dd HH:mm:ss fff}] [INFO] [NOTHING TO RUN [NOT IN JOB TIME RANGE]::AttendanceByDayCalcJob:{1}]", DateTime.Now, context.FireInstanceId);
                    CommonBase.OperateDateLoger(loggerLineJob, LoggerMode.ERROR);
                    return Console.Out.WriteLineAsync(loggerLineJob); ;
                }
            }
        }
    }
}

