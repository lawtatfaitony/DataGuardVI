using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StarGateway
{ 
    public class GatewayConfig
    {
        public GatewayConfig()
        {
            string  MainComId = "0";
            string jsonFileName = string.Format("CWRGConfig_{0}.Json", MainComId);
            string baseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;

            if (MainComId == "0")
            {
                jsonFileName = "CWRGConfig.Json";
            } 
            string pathFileName = Path.Combine(baseDirectoryPath, jsonFileName);
            if (!File.Exists(pathFileName))
            {
                //Must write to Logger
                CommonBase.OperateDateLoger(string.Format("[CWRGConfig.Json {0} Not Exist]", pathFileName));
            }
            string jsonContent ;

            if (MemoryCacheHelper.Contains(jsonFileName) == false)
            {
                if (!File.Exists(pathFileName))
                {
                    jsonFileName = "CWRGConfig.Json";
                    pathFileName = Path.Combine(baseDirectoryPath, jsonFileName);
                }
                jsonContent = CommonBase.ReadConfigJson(pathFileName);
                jsonContent = CommonBase.JsonFormat(jsonContent); 
            }
            else
            {
                jsonContent = MemoryCacheHelper.GetCacheItem<string>(jsonFileName);
            }

            Dictionary<string, string> iniConfig = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonContent);
             
            _Account = iniConfig["Account"];
            _Password = string.IsNullOrEmpty(iniConfig["Password"]) ? "" : iniConfig["Password"];
            _Roles = string.IsNullOrEmpty(iniConfig["Roles"]) ? "" : iniConfig["Roles"];
            _ContractorId = string.IsNullOrEmpty(iniConfig["ContractorId"]) ? "" : iniConfig["ContractorId"];
            _Token = string.IsNullOrEmpty(iniConfig["Token"]) ? string.Empty : iniConfig["Token"];
            _RefreshToken = string.IsNullOrEmpty(iniConfig["RefreshToken"]) ? string.Empty : iniConfig["RefreshToken"];
            bool tryDate = DateTime.TryParse(iniConfig["TokenExpiryDate"], out _TokenExpiryDate);
            _TokenExpiryDate = tryDate ? _TokenExpiryDate :new DateTime(1970,1,1,0,0,0) ;
            _Name = string.IsNullOrEmpty(iniConfig["Name"]) ? string.Empty : iniConfig["Name"];
            _WebRootFolder = string.IsNullOrEmpty(iniConfig["WebRootFolder"]) ? string.Empty : iniConfig["WebRootFolder"];
            if (MemoryCacheHelper.Contains(jsonFileName) == false)
            { 
                MemoryCacheHelper.Set(jsonFileName, jsonContent, _TokenExpiryDate);
            }
        } 
        private string _Account;
        public string Account
        {
            get
            {
                return _Account;
            }
            set
            {
                _Account = value;
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
        private string _Roles;
        public string Roles
        {
            get
            {
                return _Roles;
            }
            set
            {
                _Roles = value;
            }
        }
        private string _ContractorId;
        public string ContractorId
        {
            get
            {
                return _ContractorId;
            }
            set
            {
                _ContractorId = value;
            }
        } 
        private string _Token;
        public string Token
        {
            get
            {
                return _Token;
            }
            set
            {
                _Token = value;
            }
        }

        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        
        private string _RefreshToken;
        public string RefreshToken
        {
            get
            {
                return _RefreshToken;
            }
            set
            {
                _RefreshToken = value;
            }
        }
        private DateTime _TokenExpiryDate;
        public DateTime TokenExpiryDate
        {
            get
            {
                return _TokenExpiryDate;
            }
            set
            {
                _TokenExpiryDate = value;
            }
        }

        private string _WebRootFolder;
        public string WebRootFolder
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
        public void Save(GatewayConfig config)
        {
            string baseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory; 
            string jsonFileName = "CWRGConfig.Json";
            string pathFileName = Path.Combine(baseDirectoryPath, jsonFileName);
            string StrContentConfig = JsonConvert.SerializeObject(config,Formatting.Indented);
            bool result = CommonBase.SaveDataJson(StrContentConfig, pathFileName);
            if(result)
            {
                MemoryCacheHelper.Remove(jsonFileName);
            }
        }
    }
}
