using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Web;

namespace LanguageResource
{
    public  class LangConnectComponent
    {
        public LangConnectComponent()
        {
            _basePath = AppDomain.CurrentDomain.BaseDirectory;
        }
        private static string _basePath; 
        private static string _ConnectiongString; 
        public static string ConnectiongString
        {
            get
            { 
                if (HttpContext.Current.Cache.Get("ConnectionConfig") != null)
                {
                    _ConnectiongString = (string)LangCacheHelper.GetCache("ConnectionConfig");
                }
                else
                {
                    _ConnectiongString = "Server = (local)\\DATAGUARD; Database = DataGuardX; Trusted_Connection = True; ";
                    if (string.IsNullOrEmpty(_basePath))
                    {
                        _basePath = AppDomain.CurrentDomain.BaseDirectory;
                    }
                    //---------------------------------------------------------------------------------------------------
                    LangConnectionConfig ConnectionConfig = new LangConnectionConfig(_basePath);
                    LangCacheHelper.SetCache("ConnectionConfig", ConnectionConfig.ConnectionString, System.TimeSpan.FromMinutes(600));
                }
                return _ConnectiongString;
            }
            set
            {
                _ConnectiongString = value;
            }
        }
    }
    public class LangConnectionConfig
    {
        public LangConnectionConfig(string basePath)
        {
            string jsonFileName = "ConnectionConfig.conf";
              
            string pathFileName = Path.Combine(basePath, jsonFileName);
             
            string jsonContent = string.Empty;

            jsonContent = LangCommonBase.JsonFormat(LangCommonBase.ReadConfigJson(pathFileName));

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
                 
                if (_IsTrustMode)
                {
                    _ConnectiongString = string.Format("Server = {0}; Database = {1}; Trusted_Connection = True; ",Server,DataBase);
                }
                else
                {
                    _ConnectiongString =string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};TrustServerCertificate=True;ApplicationIntent=ReadWrite;", Server, DataBase,UserId, Password);
                } 
                return _ConnectiongString;
            } 
        }
    }
}
