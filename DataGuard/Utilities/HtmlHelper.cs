using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace DataGuard.Utilities
{
    public static class HtmlHelper
    {
        /// <summary>
        /// 返回没有边框的只读的TextBox标签
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="html"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static MvcHtmlString EditorReadonlyFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            string format = null;
            object htmlAttributes = new
            {
                @readonly = "readonly",
                @style = "border:none;float:left;width:100%;",

            };


            return html.TextBoxFor(expression, format, htmlAttributes);
        }

        /// <summary>
        /// 时间格式
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static MvcHtmlString CalenderTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            Func<TModel, TProperty> deleg = expression.Compile();
            var result = deleg(htmlHelper.ViewData.Model);
            string value = null;
            if (result.ToString() == DateTime.MinValue.ToString())
                value = string.Empty;
            else
                value = string.Format("{0:M-dd-yyyy}", result);
            return htmlHelper.TextBoxFor(expression, new { Value = value });
        }
    }
}