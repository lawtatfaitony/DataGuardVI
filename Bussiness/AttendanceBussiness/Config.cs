using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AttendanceBussiness.DbFirst;
using Common;
using System.Xml.Serialization;
using static Common.CommonBase;

namespace AttendanceBussiness
{ 
    public class TaskSettingConfig
    {
        public static string TaskFactoryScheduleJOB = "TaskFactoryScheduleJOB";
        public static string CalcPeriodType_MONTHLY_ScheduleCalc = "CalcPeriodType_MONTHLY_ScheduleCalc";
        public static string CalcPeriodType_DAYLY_ScheduleAndShiftCalcJob = "CalcPeriodType_DAYLY_ScheduleAndShiftCalcJob";
        public static string CalcPeriodType_DEFINITION = "CalcPeriodType_DEFINITION";
        
    }
    /// <summary>
    /// 常量配置
    /// </summary>
    public class GlobalConfig
    { 
        public GlobalConfig(string MainComId = "0")
        {
            string jsonFileName = string.Format("GlobalConfig_{0}.Json", MainComId);
            if (MainComId == "0")
                jsonFileName = "GlobalConfig.Json";

            string jsonContent = string.Empty;
            if (MemoryCacheHelper.Contains(jsonFileName) == false)
            { 
                string baseDirectoryPath = GetPath(jsonFileName);
                string pathFileName = baseDirectoryPath;
                
                if (!File.Exists(pathFileName))
                {
                    pathFileName = Path.Combine("c:\\", jsonFileName);
                    //Must write to Logger
                    CommonBase.OperateDateLoger(string.Format("[0:yyyy-MM-dd HH:mm:ss] GlobalConfig.Json [PATH::{1}] Not Exist",DateTime.Now, pathFileName),LoggerMode.FATAL); 
                } 
                jsonContent = CommonBase.JsonFormat(CommonBase.ReadConfigJson(pathFileName)); 
                DateTimeOffset thisOffsetTime = DateTime.Now.AddHours(12);
                MemoryCacheHelper.Set(jsonFileName, jsonContent, thisOffsetTime);
            }
            else
            {
                jsonContent = MemoryCacheHelper.GetCacheItem<string>(jsonFileName);
            }

            Dictionary<string, string> iniGlobalConfig = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonContent);
            if (!double.TryParse(iniGlobalConfig["standardWorkDaySpan"], out _StandardWorkDaySpan))
                _StandardWorkDaySpan = 8.00d;

            _ConsoleRootFolder = iniGlobalConfig["consoleRootFolder"];
            _UploadFolder = string.IsNullOrEmpty(iniGlobalConfig["uploadFolder"])? "Upload": iniGlobalConfig["uploadFolder"];
            _DataFolder = string.IsNullOrEmpty(iniGlobalConfig["dataFolder"]) ? "Data" : iniGlobalConfig["dataFolder"];
            _ScheduleAndShiftCalc = string.IsNullOrEmpty(iniGlobalConfig["scheduleAndShiftCalc"]) ? "ScheduleAndShiftCalc" : iniGlobalConfig["scheduleAndShiftCalc"];
            _WebRootFolder = iniGlobalConfig["webRootFolder"];

            if (!bool.TryParse(iniGlobalConfig["sychronizeSystemTime"], out _SychronizeSystemTime))
                _SychronizeSystemTime = true;

            if (!double.TryParse(iniGlobalConfig["lunchTimeSpan"], out _LunchTimeSpan)) 
                _LunchTimeSpan = 0.01d;

            if (DateTime.TryParse(iniGlobalConfig["monthlyScheduleCalc"], out DateTime _Monthly))
            {
                DateTime dt = DateTime.Now;
                _MonthlyScheduleCalc = new DateTime(dt.Year, dt.Month, _Monthly.Day, _Monthly.Hour, _Monthly.Minute, _Monthly.Second);
            }
            else
            {
                _MonthlyScheduleCalc = new DateTime(1970, 1, 23, 9, 0, 0);
            }
               
        }
        
        private double _StandardWorkDaySpan;
        public double StandardWorkDaySpan
        {
            get
            {
                return _StandardWorkDaySpan;
            }
            set
            {
                _StandardWorkDaySpan = value;
            }
        }
        private string _ConsoleRootFolder;
        public string ConsoleRootFolder
        {
            get {
                return _ConsoleRootFolder;
            }
            set
            {
                _ConsoleRootFolder = value;
            }
        }
        private string _UploadFolder;
        public string UploadFolder
        {
            get
            {
                return _UploadFolder;
            }
            set
            {
                _UploadFolder = value;
            }
        }
        private string _DataFolder;
        public string DataFolder
        {
            get
            {
                return _DataFolder;
            }
            set
            {
                _DataFolder = value;
            }
        }
        private string _ScheduleAndShiftCalc; 
        public  string ScheduleAndShiftCalc
        {
            get
            {
                return _ScheduleAndShiftCalc;
            }
            set
            {
                _ScheduleAndShiftCalc = value;
            }
        }
        private string _WebRootFolder;
        public  string WebRootFolder
        {
            get
            {
                return _WebRootFolder;
            }
            set
            {
                _WebRootFolder = value;
            }
        }
        private bool _SychronizeSystemTime;
        public  bool SychronizeSystemTime
        {
            get
            {
                return _SychronizeSystemTime;
            }
            set
            {
                _SychronizeSystemTime = value;
            }
        }
        private double _LunchTimeSpan;
        public  double LunchTimeSpan
        {
            get
            {
                return _LunchTimeSpan;
            }
            set
            {
                _LunchTimeSpan = value;
            }
        }
        private DateTime _MonthlyScheduleCalc;
        public DateTime MonthlyScheduleCalc
        {
            get
            {
                return _MonthlyScheduleCalc;
            }
            set
            {
                _MonthlyScheduleCalc = value;
            }
        }
        public string GetPath(string AnchorFileName)
        {
            string LoggerLine;
            System.Reflection.Assembly curPath = System.Reflection.Assembly.GetExecutingAssembly();
            string assemblypath = curPath.CodeBase;
            string basePath = Path.GetDirectoryName(assemblypath);

            //supplement
            if (basePath.ToLower().StartsWith("file"))
            {
                Uri uri = new Uri(basePath);
                basePath = uri.LocalPath;
            }

            if (File.Exists(Path.Combine(basePath, "DataGuard.dll")))
            {
                basePath = PathRemoveBin(basePath);
                return basePath;
            }
            
            string pathFileName = Path.Combine(basePath, AnchorFileName);
            if (!File.Exists(pathFileName))
            {
                basePath = Path.GetFullPath(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                basePath = Path.GetDirectoryName(basePath);
                pathFileName = Path.Combine(basePath, AnchorFileName);
                if (!File.Exists(pathFileName))
                {
                    basePath = AppDomain.CurrentDomain.BaseDirectory;
                    pathFileName = Path.Combine(basePath, AnchorFileName);
                    if (!File.Exists(pathFileName))
                    {
                        basePath = Environment.CurrentDirectory;
                        pathFileName = Path.Combine(basePath, AnchorFileName);
                        if (!File.Exists(pathFileName))
                        {
                            LoggerLine = string.Format("[FUN::GetPath::CASE::Environment.CurrentDirectory ][{0:yyyy-MM-dd HH:mm:ss fff}][ConnectionConfig.conf {1} Exist]", DateTime.Now, pathFileName);
                            Console.WriteLine(LoggerLine);
                            CommonBase.OperateDateLoger(LoggerLine);
                        }
                        else
                        {
                            return pathFileName;
                        }
                    }
                    else
                    {
                        return pathFileName;
                    }
                }
                else
                {
                    return pathFileName;
                }
            }
            else
            {
                return pathFileName;
            }
            return pathFileName;
        }

        public static string PathRemoveBin(string pathApp)
        {
            int pathIndex = pathApp.LastIndexOf("\\");
            if (pathIndex != -1)
            {
                string existBinPath = pathApp.Remove(0, pathIndex).ToLower();
                existBinPath = existBinPath.TrimStart('\\');

                if (existBinPath.ToLower() == "bin")
                {
                    pathApp = pathApp.Substring(0, pathIndex);
                    return pathApp;
                }
                else
                {
                    return pathApp.Substring(0, pathIndex);
                }
            }
            else
            {
                return pathApp;
            }
        }
    }  
}