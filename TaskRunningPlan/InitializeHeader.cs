using System;
using System.Collections.Generic;
using System.Text;
using AttendanceBussiness;
using AttendanceBussiness.DbFirst;
using AttendanceBussiness.NetWorkTime;

namespace TaskRunningPlan
{
    public partial class InitializeHeader
    {
        //initialize
        public static int Init()
        {
            //==============================================================================================================================
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
             
            #region TEE BEGIN HEADER
            //-------------------------------------------------------------------
            Loading.RenderProgress();
            //------------------------------------------------------------------- 输入Y/N继续
            //Loading.InputBusiness(out string inputChar, "YN", "\nPress Y to Sychronize Time:\n");
            string inputChar = "Y";
            bool SychronizeSystemTime = inputChar == "Y" ? true : false;
            bool result = InterNetTime.GetInternetTime(out DateTime machineTime, out DateTime interNetTime, SychronizeSystemTime);

            long lMachineTime = DateTimeHelp.ConvertDateTimeToLong(machineTime);
            long lInterNetTime = DateTimeHelp.ConvertDateTimeToLong(interNetTime);

            Console.WriteLine("\n[SUCCESS={4}] MachineTime: {0:yyyy-MM-dd HH:mm:ss fff}:{1} | NetworkTime : {2:yyyy-MM-dd HH:mm:ss fff}:{3} [IsUpdateTime = {5}]"
                , machineTime, lMachineTime, interNetTime, lInterNetTime, result, SychronizeSystemTime);

            bool checkTime = InterNetTime.InterNetTimeCheck(result, machineTime, interNetTime);
            Console.WriteLine("\n[{0:yyyy-MM-dd HH:mm:ss fff}] [AUTH] [NTP NetworkTime] [{1:X}] \n", interNetTime, checkTime);

            //Check SQL Connection----------------------------------------------------------------------------------------
            using (DataBaseContext dbContext = new DataBaseContext())
            {
                if (!dbContext.Database.CanConnect())
                {
                    Console.WriteLine("\n>>> Can not Connect to SQL Server,Please Comfirm The ConnectionString.");
                }
                else
                {
                    Console.WriteLine("\n>>> [{0:yyyy-MM-dd HH:mm:ss fff}] DataBase Server has Connected......", DateTime.Now);
                }
            }

            Console.Title = string.Format("DATA GUARD {0:yyyy-MM-dd HH:mm:ss fff}", DateTime.Now);

            Console.WriteLine();
            Console.WriteLine("\n[{0:yyyy-MM-dd HH:mm:ss fff}] [MAIN FUNC] [INFO] [Hello World!] [JOB TIMER START] ", DateTime.Now);
            #endregion //EDN HEADER check SQL Connection-------------------------------------------------------------------

            int retValue = 0;
            return retValue;
        }
    }
}
