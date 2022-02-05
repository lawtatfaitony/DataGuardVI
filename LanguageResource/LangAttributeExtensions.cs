using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageResource
{
    /// <summary>
    /// 扩展验证(在Lang有重复的定义LangPublic.cs)
    /// </summary>
    public class LangAttributeExtensions
    { 
        /// <summary>
        /// 手机号码格式不正确
        /// </summary>
        public static string AttributeExtensions_PhoneNumber
        { get { return LangUtilities.GetString("AttributeExtensions_PhoneNumberAttribute", KeyType.AttributeExtensions); } }


        /// <summary>
        /// 请输入数字
        /// </summary>
        public static string AttributeExtensions_DigitsAttribute
        { get { return LangUtilities.GetString("AttributeExtensions_DigitsAttribute", KeyType.AttributeExtensions); } }

        /// <summary>
        /// 必須符合数字格式 如 12-12345678-1
        /// </summary>
        public static string AttributeExtensions_CuitAttribute
        { get { return LangUtilities.GetString("AttributeExtensions_CuitAttribute", KeyType.AttributeExtensions); } }


        /// <summary>
        /// 请输入正确的信用卡格式
        /// </summary>
        public static string AttributeExtensions_CreditCardAttribute
        { get { return LangUtilities.GetString("AttributeExtensions_CreditCardAttribute", KeyType.AttributeExtensions); } }

        /// <summary>
        /// 请输入正确的Email格式
        /// </summary>
        public static string AttributeExtensions_EmailAttribute
        { get { return LangUtilities.GetString("AttributeExtensions_EmailAttribute", KeyType.AttributeExtensions); } }

        /// <summary>
        /// 请输入正确日期格式
        /// </summary>
        public static string AttributeExtensions_DateAttribute
        { get { return LangUtilities.GetString("AttributeExtensions_DateAttribute", KeyType.AttributeExtensions); } }

        /// <summary>
        ///  '{0}'与'{1}' 不一致.
        /// </summary>
        public static string AttributeExtensions_EqualToAttribute
        { get { return LangUtilities.GetString("AttributeExtensions_EqualToAttribute", KeyType.AttributeExtensions); } }


        /// <summary>
        /// 仅接受文件类型:.png,jpg,jpeg,gif
        /// </summary>
        public static string AttributeExtensions_FileExtensionsAttribute    // The {0} field only accepts files with the following extensions: {1}
        { get { return LangUtilities.GetString("AttributeExtensions_FileExtensionsAttribute", KeyType.AttributeExtensions); } }

        /// <summary>
        /// 请输入整数
        /// </summary>
        public static string AttributeExtensions_IntegerAttribute
        { get { return LangUtilities.GetString("AttributeExtensions_EqualToAttribute", KeyType.AttributeExtensions); } }

        /// <summary>
        ///  {0} 超出最大数值
        /// </summary>
        public static string AttributeExtensions_MaxAttribute
        { get { return LangUtilities.GetString("AttributeExtensions_MaxAttribute", KeyType.AttributeExtensions); } }

        
        /// <summary>
        /// {0}必须大于{1}
        /// </summary>
        public static string AttributeExtensions_MinAttribute
        { get { return LangUtilities.GetString("AttributeExtensions_MinAttribute", KeyType.AttributeExtensions); } }

        /// <summary>
        /// 请输入有效的数字
        /// </summary>
        public static string AttributeExtensions_NumericAttribute   
        { get { return LangUtilities.GetString("AttributeExtensions_NumericAttribute", KeyType.AttributeExtensions); } }

        /// <summary>
        /// 请输入有效的http,https,ftp等开头的链接
        /// </summary>
        public static string AttributeExtensions_UrlAttribute_validHttp //The {0} field is not a valid fully-qualified http, https, or ftp URL.
        { get { return LangUtilities.GetString("AttributeExtensions_UrlAttribute_validHttp", KeyType.AttributeExtensions); } }

        /// <summary>
        /// 请输入完整的url连接
        /// </summary>
        public static string AttributeExtensions_UrlAttribute_Optional_Invalid  
        { get { return LangUtilities.GetString("AttributeExtensions_UrlAttribute_Optional_Invalid", KeyType.AttributeExtensions); } }

        /// <summary>
        /// 请输入完整的url连接
        /// </summary>
        public static string AttributeExtensions_UrlAttribute_Protocol_Invalid  
        { get { return LangUtilities.GetString("AttributeExtensions_UrlAttribute_Protocol_Invalid", KeyType.AttributeExtensions); } }

        /// <summary>
        /// 请输入有效年份格式
        /// </summary>
        public static string AttributeExtensions_YearAttribute
        { get { return LangUtilities.GetString("AttributeExtensions_YearAttribute", KeyType.AttributeExtensions); } }

        /// <summary>
        /// 请输入有效年份格式
        /// </summary>
        public static string AttributeExtensions_EqualToAttributeNotFind
        { get { return LangUtilities.GetString("AttributeExtensions_EqualToAttribute", KeyType.AttributeExtensions); } }
    }
}
