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
using Common;
using static Common.CommonBase;

namespace TaskRunningPlan.AttendanceSchedule
{
    public partial class ScheduleGlobal
    {
        private static ShiftBusiness.CalcPeriodType _CalcPeriodType; 
        public static async Task RunScheduleMonthlyGlobalProgram(ShiftBusiness.CalcPeriodType calcPeriodType, DateTime TaskMonthlyStartDate)
        {
            int timesOfTaskRunning = 1;
            _CalcPeriodType = calcPeriodType;
            try
            {
                NameValueCollection props = new NameValueCollection
                {
                    { "quartz.serializer.type", "binary" }
                };
                StdSchedulerFactory factory = new StdSchedulerFactory(props);
                IScheduler scheduler = await factory.GetScheduler();

                await scheduler.Start();

                IJobDetail job = JobBuilder.Create<ScheduleMonthlyGlobalJob>()
                    .WithIdentity("JOB1_Monthly_CalcPeriodType_Global", "GROUP1")
                    .Build();
                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("trigger1_Monthly_CalcPeriodType_Global")
                    .StartAt(TaskMonthlyStartDate)
                    .ForJob("JOB1_Monthly_CalcPeriodType_Global", "GROUP1")
                    .WithCalendarIntervalSchedule(w => w
                    .WithIntervalInMonths(timesOfTaskRunning) 
                    )  
                    .Build();
                 
                await scheduler.ScheduleJob(job, trigger);
                 
                await Task.Delay(TimeSpan.FromMilliseconds(2000));
                 
            }
            catch (SchedulerException se)
            {
                await Console.Error.WriteLineAsync(se.ToString());
            }
        }

        public class ScheduleMonthlyGlobalJob : IJob
        { 
            public Task Execute(IJobExecutionContext context)
            { 
                 AttendanceBussiness.AttendanceSchedule.ScheduleGlobal.ScheduleCalc();
                
                 if(_CalcPeriodType == ShiftBusiness.CalcPeriodType.MONTHLY )
                 {
                    bool IsUpdStartDate = TaskSettingPlan.UpdateTaskStartDate(TaskSettingConfig.CalcPeriodType_MONTHLY_ScheduleCalc);
                    Console.Out.WriteLineAsync(string.Format("\n[{0:yyyy-MM-dd HH:mm:ss fff}] [INFO] [func::ScheduleCalc.Execute ScheduleMonthlyGlobalJob::IsUpdStartDate = {1}] {2:yyyy-MM-dd  HH:mm:ss fff}", DateTime.Now, IsUpdStartDate, DateTime.Now));

                    //-----------------------------------------------------------------
                    string loggerLineJob = string.Format("[{0:yyyy-MM-dd HH:mm:ss fff}] [SCHEDULE_MONTHLY_START_JOB]", DateTime.Now);
                    CommonBase.OperateDateLoger(loggerLineJob, LoggerMode.INFO);
                 }
                return Console.Out.WriteLineAsync(string.Format("\n[{0:yyyy-MM-dd HH:mm:ss fff}] [INFO] [Execute::ScheduleMonthlyGlobal:{1}]", DateTime.Now, context.FireInstanceId));
            }
        }
    }
}

