using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text; 

namespace ConnectionService
{
    public enum DataBaeType
    {
        MSSQL = 0,
        MYSQL = 1,
        MONGODB = 2,
        ORACLE = 3
    }
    public  class ConnectComponent
    {
        public ConnectComponent()
        { 
        } 
        private static string _ConnectiongString; 
        public static string ConnectiongString
        {
            get
            {    
                ConnectionConfig ConnectionConfig = new ConnectionConfig();
                return ConnectionConfig.ConnectionString;
            }
            set
            {
                _ConnectiongString = value;
            }
        } 
        
    }
    public class ConnectionConfig
    {
        public ConnectionConfig()
        {
            string jsonFileName = "ConnectionConfig.conf";
              
            string jsonContent = string.Empty;

            if (MemoryCacheHelper.Contains(jsonFileName) == false)
            { 
                string pathFileName = GetPath(jsonFileName);
                if (!File.Exists(pathFileName))
                {
                    //Must write to Logger
                    CommonBase.OperateDateLoger(string.Format("[{0:yyyy-MM-dd HH:mm:ss fff}][ConnectionConfig.conf {1} Not Exist]", DateTime.Now, pathFileName), Common.CommonBase.LoggerMode.FATAL);
                }
                else
                {
                    jsonContent = CommonBase.JsonFormat(ReadConfigJson(pathFileName));
                    DateTimeOffset thisOffsetTime = DateTime.Now.AddHours(12);
                    MemoryCacheHelper.Set(jsonFileName, jsonContent, thisOffsetTime);
                } 
            }
            else
            {
                jsonContent = MemoryCacheHelper.GetCacheItem<string>(jsonFileName);
            }

            Dictionary<string, string> intConnectionConfig = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonContent);
             
            _Server = intConnectionConfig["Server"];
            _DataBase = intConnectionConfig["DataBase"];
            _IsTrustMode = bool.Parse(intConnectionConfig["IsTrustMode"]);
            _UserId = intConnectionConfig["UserId"] ;
            _Password = intConnectionConfig["Password"]; 
        }

        private string _Server;
        public string Server
        {
            get
            {
                return _Server;
            }
            set
            {
                _Server = value;
            }
        }
        private string _DataBase;
        public string DataBase
        {
            get
            {
                return _DataBase;
            }
            set
            {
                _DataBase = value;
            }
        }
        private bool _IsTrustMode;
        public bool IsTrustMode
        {
            get
            {
                return _IsTrustMode;
            }
            set
            {
                _IsTrustMode = value;
            }
        }
        
        private string _UserId;
        public string UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                _UserId = value;
            }
        }
        private string _Password;
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }

        private string _ConnectiongString;
        public virtual string ConnectionString
        {
            get
            { 
                ////---------------------------------------------------------------------------------------------------
                if (_IsTrustMode)
                {
                    _ConnectiongString = string.Format("Server = {0}; Database = {1}; Trusted_Connection = True;Integrated Security=SSPI", Server,DataBase);
                }
                else
                {
                    _ConnectiongString =string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};TrustServerCertificate=True;ApplicationIntent=ReadWrite;", Server, DataBase,UserId, Password);
                } 
                return _ConnectiongString;
            } 
        }

        public string GetPath(string FileName)
        {
            string LoggerLine;
            string pathFileName;
            System.Reflection.Assembly curPath = System.Reflection.Assembly.GetExecutingAssembly();
            string assemblypath = curPath.CodeBase;
            if (assemblypath.ToLower().StartsWith("file"))
            {
                Uri uri = new Uri(assemblypath);
                assemblypath = uri.AbsolutePath;
            }
            string basePath = Path.GetDirectoryName(assemblypath);
            if(File.Exists(Path.Combine(basePath, "DataGuard.dll")))
            {
                basePath = PathRemoveBin(basePath);
                pathFileName = Path.Combine(basePath, FileName);
                return pathFileName;
            }
            pathFileName = Path.Combine(basePath, FileName);

            if (!File.Exists(pathFileName))
            {
                basePath = Path.GetFullPath(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                basePath = Path.GetDirectoryName(basePath);
                pathFileName = Path.Combine(basePath, FileName);
                if(!File.Exists(pathFileName))
                {
                    basePath = AppDomain.CurrentDomain.BaseDirectory;
                    pathFileName = Path.Combine(basePath, FileName);
                    if (!File.Exists(pathFileName))
                    {
                        basePath = Environment.CurrentDirectory;
                        pathFileName = Path.Combine(basePath, FileName);
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
                    pathApp = Directory.GetParent(pathApp).FullName ;
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
        public static string ReadConfigJson(string PathFileName)
        {
            if (File.Exists(PathFileName))
            {
                string content = File.ReadAllText(PathFileName, Encoding.UTF8);
                return content;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
