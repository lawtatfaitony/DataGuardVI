using LanguageResource;
using System;
namespace DataGuard.Context
{
    public class LocalizedDisplayName : System.ComponentModel.DisplayNameAttribute
    {
        private string _Language = LangUtilities.LanguageCode;
        private string _defaultName = "";
        public LocalizedDisplayName(string defaultName)
        {
            _defaultName = defaultName;
        }
        public string KeyName { get; set; }
        public string KeyType { get; set; }
        public override string DisplayName
        {
            get
            {
                //Lang tmp_Lang = new Lang();
                //Type type = tmp_Lang.GetType();  
                //System.Reflection.PropertyInfo propertyInfo = type.GetProperty(KeyName);  
                //string rtn_str = (string)propertyInfo.GetValue(tmp_Lang);  
                //return rtn_str;

                // the follow is old version  2019年6月6日

                using (Model1 db1 = new Model1())   //using (Context.ApplicationDbContext db1 = new Context.ApplicationDbContext())
                {
                    string returnValue = KeyName;

                    returnValue = LangUtilities.GetString(KeyName);
                    if (returnValue == KeyName)
                    {
                        //If no record, insert the database and return the original column field name
                        LanguageResource.Modal.Language Lang = getObjData(_defaultName);
                        LanguageResource.Modal.Language LangExits = db1.Languages.Find(Lang.KeyName);
                        if (LangExits == null)
                        {
                            try
                            {
                                db1.Languages.Add(Lang);
                                db1.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                returnValue = KeyName;
                                throw ex;
                            }
                        }
                        returnValue = _defaultName;
                    }
                    return returnValue;
                }
            }
        }

        public string GetLangFieldValue(string LanguageField, LanguageResource.Modal.Language LangDetails)
        {
            LanguageField = GetLanguageField(LanguageField);
            switch (LanguageField)
            {
                case "zh-CN":
                    return LangDetails.zh_CN;
                case "zh-SG":
                    return LangDetails.zh_CN;
                case "zh-HK":
                    return LangDetails.zh_HK;
                case "zh-hant-HK":
                    return LangDetails.zh_HK;
                case "en-US":
                    return LangDetails.zh_CN;
                default:
                    return LangDetails.en_US;
            }
        }
        /// <summary>
        ///  Insert a new rec to Language
        /// </summary>
        /// <param name="_defaultName"></param>
        /// <returns></returns>
        public LanguageResource.Modal.Language getObjData(string _defaultName)
        {
            _Language = GetLanguageField(_Language);
            string zh_HK = ChineseStringUtility.ToTraditional(_defaultName);
            var LangData = new LanguageResource.Modal.Language { KeyName = KeyName, KeyType = KeyType, zh_CN = _defaultName, zh_HK = zh_HK };
            return LangData;
        }

        public string GetLanguageField(string Language)
        {
            if (Language == "zh-hant-hk")
            {
                return "zh-HK";
            }
            else
            {
                return Language;  // return Language = Language.Substring(0, 2);   // Only take the first two language codes, for example: zh: Chinese, en: Pan English fr: French
            }
        }
    }
}