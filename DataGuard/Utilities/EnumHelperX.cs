using AttendanceBussiness;
using LanguageResource;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;

namespace DataGuard.Utilities
{
    public class EnumHelperX
    {
        /// <summary>
        /// 获取自定义属性获取的内容
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetEnumDescription(Object obj)
        {

            //获取枚举对象的枚举类型
            Type type = obj.GetType();
            //通过反射获取该枚举类型的所有属性
            FieldInfo[] fieldInfos = type.GetFields();

            foreach (FieldInfo field in fieldInfos)
            {

                //不是参数obj,就直接跳过

                if (field.Name != obj.ToString())
                {
                    continue;
                }

                //取出参数obj的自定义属性
                if (field.IsDefined(typeof(EnumDisplayNameAttribute), true))
                {

                    string dip = (field.GetCustomAttributes(typeof(EnumDisplayNameAttribute), true)[0] as EnumDisplayNameAttribute).DisplayName;
                    return dip;
                }
            }
            return obj.ToString();
        }

        /// <summary>
        ///  将枚举类型的值和自定义属性配对组合为 List<SelectListItem>
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static List<SelectListItem> GetSelectList<T>()
        {
            var enumType = typeof(T);
            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach (var obj in Enum.GetValues(enumType))
            {
                selectList.Add(new SelectListItem { Text = LangUtilities.GetStringReflectKeyName(GetEnumDescription(obj)), Value = obj.ToString() });
            }
            return selectList;
        }

        /// <summary>
        /// List转SelectListItem
        /// </summary>
        /// <typeparam name="T">Model对象</typeparam>
        /// <param name="t">集合</param>
        /// <param name="text">显示值-属性名</param>
        /// <param name="value">显示值-属性名</param>
        /// <param name="empId"></param>
        /// <returns></returns>
        public static List<SelectListItem> CreateSelect<T>(IList<T> t, string text, string value, string selectValue)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in t)
            {
                var propers = item.GetType().GetProperty(text);
                var valpropers = item.GetType().GetProperty(value);
                list.Add(new SelectListItem
                {
                    Text = propers.GetValue(item, null).ToString(),
                    Value = valpropers.GetValue(item, null).ToString(),
                    Selected = valpropers.GetValue(item, null).ToString() == selectValue
                });
            }
            return list;
        }
    }
}