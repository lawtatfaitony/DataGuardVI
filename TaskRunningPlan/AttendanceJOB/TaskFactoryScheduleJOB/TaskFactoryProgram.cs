using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AttendanceBussiness;
using AttendanceBussiness.AttendanceByPeriod;
using AttendanceBussiness.ScheduleAndShift;
using Common;
using static Common.CommonBase;

namespace TaskRunningPlan.TaskFactoryScheduleJOB
{
   
    public partial class TaskFactoryProgram
    {
        public static GlobalConfig globalConfig = new GlobalConfig();
         
        public static void StartRun()
        {
            var parentTask = Task.Run(() => {
                CancellationTokenSource cts = new CancellationTokenSource();
                 
                TaskFactory<int> tf = new TaskFactory<int>(cts.Token, TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
 
                Task<int>[] childTasks = new Task<int>[] {
                    tf.StartNew(() => TaskProgramCalcDaylyInitial())
                };
                 
                childTasks.ForEach(f =>
                {
                    f.ContinueWith(childTask => cts.Cancel(), TaskContinuationOptions.OnlyOnFaulted);
                });
                 
                var tfTask = tf.ContinueWhenAll(childTasks,
                completedTasks => completedTasks.Where(completedTask => !completedTask.IsCanceled && !completedTask.IsFaulted).Max(completedTask => completedTask.Result), CancellationToken.None);

                //FIRST
                tfTask.ContinueWith(childTasksCompleteTask =>
                {
                    TaskProgramCalcDayly(); 

                }, TaskContinuationOptions.ExecuteSynchronously);

                //SECOND
                tfTask.ContinueWith(childTasksCompleteTask =>
                {
                    TaskProgramCalcPeriod();
                    
                }, TaskContinuationOptions.ExecuteSynchronously);

                 
                tfTask.ContinueWith(childTasksCompleteTask =>
                {
                    Console.WriteLine("The Max Return Value is {0}", childTasksCompleteTask.Result);
                }, TaskContinuationOptions.ExecuteSynchronously);
            });

            Console.WriteLine("[Main Continue......]");
        }
        //INITIALIZE TASK
        public static int TaskProgramCalcDaylyInitial()
        {
            Console.WriteLine("[Task Factory Initial......]");
            int retValue = 0;
            return retValue;
        }
        //FIRST
        public static int TaskProgramCalcDayly()
        {
            Console.WriteLine("\n[ATTENDANCE DAILY PERIOD SHIFT CALC BUSINESS]");
             
            string logline_IsUpdStartDate = string.Format("\n[{0:yyyy-MM-dd HH:mm:ss fff}] [SCHEDULE_SHIFT_CALC_START] [DAILY] [func::ScheduleCalc.Execute TaskProgramScheduleShiftCalc] [TaskStartDate {1:yyyy-MM-dd  HH:mm:ss fff}]", DateTime.Now, DateTime.Now);
            ////BEGIN TO RUN... 
            ScheduleAndShiftCalc.ShiftCalcDaylyX();

            Console.Out.WriteLineAsync(logline_IsUpdStartDate);
            
            CommonBase.OperateDateLoger(logline_IsUpdStartDate, LoggerMode.INFO);
            
            string loggerLineJob = string.Format("\n[{0:yyyy-MM-dd HH:mm:ss fff}] [INFO] [Execute::TaskProgramScheduleShiftCalc]", DateTime.Now);
            CommonBase.OperateDateLoger(loggerLineJob, LoggerMode.ERROR);

            int retValue = 1;
            return retValue;

        }

        //SECOND
        public static int TaskProgramCalcPeriod()
        {
            Console.WriteLine("\n[ATTENDANCE DAILY PERIOD CALC BUSINESS]");
             
            ////BEGIN TO RUN... 
            AttendanceByPeriodBusiness attendanceByPeriodBusiness = new AttendanceByPeriodBusiness();

            ScheduleAndShiftCalc.ShiftCalcDaylyX();
            attendanceByPeriodBusiness.CalcPeriod();
            
            string loggerLineJob = string.Format("[{0:yyyy-MM-dd HH:mm:ss fff}] [ATTENDANCE PERIOD FINISHED JOB] [FINISHED AT {0:yyyy-MM-dd HH:mm:ss fff}]", DateTime.Now);
            CommonBase.OperateDateLoger(loggerLineJob, LoggerMode.INFO);

            int retValue = 2;
            return retValue;
        }
    }
}
