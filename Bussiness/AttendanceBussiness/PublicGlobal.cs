using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AttendanceBussiness.DbFirst;
using Common;
using Newtonsoft.Json;
using static Common.CommonBase;

namespace AttendanceBussiness
{
    public class PublicGlobal
    {
        private static AttendanceBussiness.DbFirst.DataBaseContext dbContext = new AttendanceBussiness.DbFirst.DataBaseContext();
        public static string MainComId { get; set; }
        public static string IndustryId { get; set; }
        public static DbFirst.TaskSetting GetTaskSetting(string Id)  //
        {
            DbFirst.TaskSetting taskSetting = dbContext.TaskSetting.Find(Id);
            return taskSetting;   
        }
        public static void ConsoleWriteline(string Loggerline)  //
        { 
            Console.Out.WriteLineAsync(string.Format("\n[{0:yyyy-MM-dd HH:mm:ss fff}] [{1}]",DateTime.Now, Loggerline)); 
            return ;
        }
        public static void ConsoleWriteline(string Loggerline,LoggerMode loggerMode)  //
        {
           
            Console.WriteLine("");
            Console.WriteLine("[{0:yyyy-MM-dd HH:mm:ss fff}] [{1}]", DateTime.Now, Loggerline); 
            return;
        }
        public static void ConsoleWriteline(string Loggerline,object obj)  //
        {
            Console.WriteLine("");
            string ObjectData = CommonBase.JsonCompress(JsonConvert.SerializeObject(obj));
            Console.WriteLine("[{0:yyyy-MM-dd HH:mm:ss fff}] [{1}] [ObjectData:{2}]", DateTime.Now, Loggerline, ObjectData);
           
            return;
        }
        public static List<MonthHeader> GetMonthHeader(DateTime startDate , int days)  //
        {
            List<MonthHeader> monthHeaders = new List<MonthHeader>();
            DateTime dateTime = new DateTime(startDate.Year, startDate.Month, startDate.Day);
            int index = 1;
            for (int i = 0; i<= days;i++)
            {

                MonthHeader monthHeader = new MonthHeader
                {
                    DayIndex = index
                   , Day = dateTime.Day
                   , DayOfWeekIndex = dateTime.DayOfWeek
                   , DayOfWeekName = dateTime.DayOfWeek.ToString()
                   , Month = dateTime.Month
                   , MonthName = dateTime.ToString("MMMM", new System.Globalization.CultureInfo("en-us"))
                   , ScheduleDate = DateTimeHelp.ConvertDateTimeToLong(dateTime) // DateTimePubBusiness.ConvertDateTimeInt(dateTime)
                };
                monthHeaders.Add(monthHeader);
                index++;
                dateTime = startDate.AddDays(i);
            }
            return monthHeaders;
        }

        //  Data/ScheduleAndShiftCalc
        public static void CheckMainComDataSubFolder(string DataFolder,string SubFolder)
        {
            using (DataBaseContext dataBaseContext = new DataBaseContext() )
            {
                var mainComs = dataBaseContext.MainCom.ToList();
                foreach(var item in mainComs)
                {
                    string basePath = CommonBase.BasePath;

                    string scheduleAndShiftCalcPath = Path.Combine(basePath, DataFolder, item.MainComId, SubFolder);
                    if (!Directory.Exists(scheduleAndShiftCalcPath))
                    {
                        Directory.CreateDirectory(scheduleAndShiftCalcPath);
                    }
                }
            }
        }

        public static void CheckMainComDataFolder(string DataFolder)
        {
            using (DataBaseContext dataBaseContext = new DataBaseContext())
            {
                var mainComs = dataBaseContext.MainCom.ToList();
                foreach (var item in mainComs)
                {
                    string basePath = CommonBase.BasePath;

                    string scheduleAndShiftCalcPath = Path.Combine(basePath, DataFolder, item.MainComId);
                    if (!Directory.Exists(scheduleAndShiftCalcPath))
                    {
                        Directory.CreateDirectory(scheduleAndShiftCalcPath);
                    }
                }
            }
        }
    }
    public class MonthHeader
    { 
        public  int DayIndex { get; set; }
        public  int Day { get; set; }
        public DayOfWeek DayOfWeekIndex { get; set; }
        public  string DayOfWeekName { get; set; } 
        public  int Month { get; set; }
        public  string MonthName { get; set; }
        public long ScheduleDate { get; set; }

    }
}
