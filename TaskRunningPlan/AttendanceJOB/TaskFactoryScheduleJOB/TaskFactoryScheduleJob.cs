using System; 
using System.Collections.Specialized;
using System.Threading.Tasks;
using Quartz.Impl;
using Quartz; 
using static Quartz.MisfireInstruction;
using AttendanceBussiness;
using Common;
using static Common.CommonBase;

namespace TaskRunningPlan.TaskFactoryScheduleJOB
{
    public partial class TaskFactorySchedule
    {
        //taskSettingId = "TaskFactoryScheduleJOB"
        public static async Task TaskDailyrogram(DateTime taskStartDate, TimeSpan taskRuningStartTime)
        {
            DateTime startDateTime = new DateTime(taskStartDate.Year, taskStartDate.Month, taskStartDate.Day,0,0,0);
            startDateTime.AddSeconds(taskRuningStartTime.TotalSeconds);

            int timesOfTaskRunning = 1;
            
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
                    .WithIdentity("JOB1_TaskFactoryScheduleEveryDayOnce_Global", "GROUP_TASKFACTORY")
                    .Build();

                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("trigger1_TaskFactoryScheduleEveryDayOnce_Global")
                    .StartAt(startDateTime)
                    .ForJob("JOB1_TaskFactoryScheduleEveryDayOnce_Global", "GROUP_TASKFACTORY")
                    .WithCalendarIntervalSchedule(w => w
                    .WithIntervalInDays(timesOfTaskRunning)
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
                //1
                AttendanceBussiness.AttendanceSchedule.ScheduleGlobal.ScheduleCalc();
                //2 
                bool IsUpdStartDate = TaskSettingPlan.UpdateTaskStartDate(TaskSettingConfig.TaskFactoryScheduleJOB);
                Console.Out.WriteLineAsync(string.Format("\n[{0:yyyy-MM-dd HH:mm:ss fff}] [INFO] [func::ScheduleCalc.Execute ScheduleMonthlyGlobalJob::IsUpdStartDate = {1}] {2:yyyy-MM-dd  HH:mm:ss fff}", DateTime.Now, IsUpdStartDate, DateTime.Now));

                TaskFactoryProgram.StartRun();

                //-----------------------------------------------------------------
                string loggerLineJob = string.Format("[{0:yyyy-MM-dd HH:mm:ss fff}] [TaskFactoryScheduleJOB]", DateTime.Now);
                CommonBase.OperateDateLoger(loggerLineJob, LoggerMode.INFO);
                 
                return Console.Out.WriteLineAsync(string.Format("\n[{0:yyyy-MM-dd HH:mm:ss fff}] [INFO] [Execute::TaskFactoryScheduleJOB:{1}]", DateTime.Now, context.FireInstanceId));
            }
        }
    }
}
