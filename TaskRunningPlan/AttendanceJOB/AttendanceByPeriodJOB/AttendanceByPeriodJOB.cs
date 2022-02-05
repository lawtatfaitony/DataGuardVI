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
using AttendanceBussiness.AttendanceByPeriod;

namespace TaskRunningPlan.AttendanceByPeriod
{
    public partial class AttendanceByPeriodJOB
    {
        private static ShiftBusiness.CalcPeriodType _CalcPeriodType; 
        public static async Task RunAttendanceByPeriodGlobalProgram(ShiftBusiness.CalcPeriodType calcPeriodType, DateTime TaskStartDate)
        {
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

                IJobDetail job = JobBuilder.Create<AttendanceByPeriodGlobalJob>()
                    .WithIdentity("JOB1_Period", "Group_Period")
                    .Build();
                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("trigger1_Period")
                    .StartAt(TaskStartDate)
                    .ForJob("JOB1_Period", "Group_Period")
                    .WithCalendarIntervalSchedule(w => w
                    .WithIntervalInHours(4)
                    )
                    .Build();
                 
                await scheduler.ScheduleJob(job, trigger);

                await Task.Delay(TimeSpan.FromMilliseconds(2000));
            }
            catch (SchedulerException se)
            {
                CommonBase.OperateDateLoger(string.Format("[RunAttendanceByPeriodGlobalProgram] [AttendanceByPeriodException]", se.Message), LoggerMode.FATAL);
                await Console.Error.WriteLineAsync(se.ToString());
            }
        }
        public class AttendanceByPeriodGlobalJob : IJob
        { 
            public Task Execute(IJobExecutionContext context)
            {  
                 if(_CalcPeriodType == ShiftBusiness.CalcPeriodType.MONTHLY )
                 {
                    ////BEGIN TO RUN... 
                    AttendanceByPeriodBusiness attendanceByPeriodBusiness = new AttendanceByPeriodBusiness();
                    attendanceByPeriodBusiness.CalcPeriod();
                    //-----------------------------------------------------------------
                    string loggerLineJob = string.Format("[{0:yyyy-MM-dd HH:mm:ss fff}] [ATTENDANCE MONTHLY FINISHED JOB] [FINISHED AT {0:yyyy-MM-dd HH:mm:ss fff}]", DateTime.Now);
                    CommonBase.OperateDateLoger(loggerLineJob, LoggerMode.INFO);
                 }
                return Console.Out.WriteLineAsync(string.Format("\n[{0:yyyy-MM-dd HH:mm:ss fff}] [INFO] [Execute::ATTENDANCE MONTHLY START JOB:{1}]", DateTime.Now, context.FireInstanceId));
            }
        }
    }
}

