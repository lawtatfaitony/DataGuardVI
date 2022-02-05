using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Timers;
using AttendanceBussiness.ScheduleAndShift;
using LoggerUtility;
using TaskRunningPlan.CalculationPlan;
using AttendanceBussiness.AttendanceSchedule;
using System.Collections.Generic;
using AttendanceBussiness.DbFirst;
using AttendanceBussiness.Public;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;

namespace TaskRunningPlan
{
    partial class Program
    { 
        static int needToClearCount = 0;
        //Task Factory Mode 
        static void Main(string[] args)
        { 
           // ScheduleAndShiftCalc.ShiftCalcDaylyX(90);
            Console.WriteLine($"[PRESS SPACE TO TEST] ScheduleAndShiftCalc.ShiftCalcDayly()  ==========================================");
            ConsoleKeyInfo keyInfo =  Console.ReadKey();
            if(keyInfo.Key == ConsoleKey.Spacebar)
            { 
                ScheduleAndShiftCalc.ShiftCalcDaylyX(); 
                Console.ReadKey();
            }
            
            //THE HEADER OF PROGRAM
            InitializeHeader.Init();

            #region SCHEDULE BEGIN---------------------------------------------------------
            var watch = new Stopwatch();  // calc duration of scehudle
            watch.Start();
            TaskProgram.TaskProgramSchedule();

            watch.Stop();
            var time = watch.ElapsedMilliseconds;
            Console.WriteLine($"Elapsed Time:{time} ms");
            Thread.SpinWait(10000);

            #endregion SCHEDULE END
             
            //THE BODY OF PROGRAM---------------------------------------------------------
            #region TASK DAILY PROGRAM 
            TaskProgram.TaskFactoryProgramDaily();
            #endregion
            // THE END OF PROGRAM
             
            //HEART BEAN ---------------------------------------------------------
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.AutoReset = true;
            timer.Interval = 60000;
            timer.Elapsed += new ElapsedEventHandler(Tick);
            timer.Start();

            #region QUIT  
            Loading.InputBusiness(out string quitInputChar, "QC", "\nPress Q to quit...");
            #endregion

            Console.ReadKey();
        }
        public static void Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            if(needToClearCount > 60)
            {
                Console.Clear();
            }

            string loggerLine = string.Format("[{0:yyyy-MM-dd HH:mm:ss fff}] [SYSTEM IS RUNNING]", DateTime.Now);

            Console.WriteLine($"\n{loggerLine}\n");

            LoggerHelper.Info(loggerLine);
          
            needToClearCount++;
        }

    }
     
}
