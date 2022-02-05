using Common;
using LanguageResource;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace AttendanceBussiness
{
     public class DateTimePubBusiness
    {
        public static string HalfAnHourMiddlePartId(string Letter, TimeSpan timeSpan, int HalfAnHour)
        {
            int min = timeSpan.Hours * 60 + timeSpan.Minutes;
            int result = min / HalfAnHour;
            string strResult = result.ToString().PadLeft(2, '0');
            return string.Format("{0}{1}", Letter, strResult);
        }

        /// <summary>
        /// 取得某月的第一天
        /// </summary>
        /// <param name="datetime">要取得月份第一天的时间</param>
        /// <returns></returns>
        public static DateTime FirstDayOfMonth(DateTime datetime)
        {
            return datetime.AddDays(1 - datetime.Day);
        }
        /**//// <summary>
        /// 取得某月的最后一天
        /// </summary>
        /// <param name="datetime">要取得月份最后一天的时间</param>
        /// <returns></returns>
        public static DateTime LastDayOfMonth(DateTime datetime)
        {
            return datetime.AddDays(1 - datetime.Day).AddMonths(1).AddDays(-1);
        }

        /**//// <summary>
        /// 取得上个月第一天
        /// </summary>
        /// <param name="datetime">要取得上个月第一天的当前时间</param>
        /// <returns></returns>
        public static DateTime FirstDayOfPreviousMonth(DateTime datetime)
        {
            return datetime.AddDays(1 - datetime.Day).AddMonths(-1);
        }

        /**//// <summary>
        /// 取得上个月的最后一天
        /// </summary>
        /// <param name="datetime">要取得上个月最后一天的当前时间</param>
        /// <returns></returns>
        public static DateTime LastDayOfPrdviousMonth(DateTime datetime)
        {
            return datetime.AddDays(1 - datetime.Day).AddDays(-1);
        }
        //两个时间的差值
        public static string DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            string dateDiff = null;
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new
            TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            dateDiff = ts.Days.ToString() + "天" + ts.Hours.ToString() + "小时" + ts.Minutes.ToString() + "分钟" + ts.Seconds.ToString() + "秒";
            return dateDiff; 
        }
        public static int DaysDiff(DateTime DateTime1, DateTime DateTime2)
        { 
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration(); 
            return ts.Days;
        }
        public static decimal TimeSpanHourDiff(TimeSpan tsStart, TimeSpan tsEnd, int point_pricision)
        {
            if(tsStart < tsEnd)
            {
                decimal thours = (decimal)tsStart.Subtract(tsEnd).TotalHours;
                return Math.Abs(Math.Round(thours, point_pricision));
            }else
            {
                tsEnd = tsEnd.Add(new TimeSpan(24, 0, 0));
                decimal thours = (decimal)tsEnd.Subtract(tsStart).TotalHours;
                return Math.Abs(Math.Round(thours, point_pricision));
            }
        } 
        public static TimeSpan TimeSpanZero()
        {
            TimeSpan timeSpan = new TimeSpan(0,0,0);
            return timeSpan;
        }
         
        public static DateTime SetZeroSecond(DateTime currentDatetime)
        {
            currentDatetime = new DateTime(currentDatetime.Year, currentDatetime.Month, currentDatetime.Day, currentDatetime.Hour, currentDatetime.Minute, 0);
            return currentDatetime;
        }
        public static DateTime SetZeroDateTime(DateTime currentDatetime)
        {
            currentDatetime = new DateTime(currentDatetime.Year, currentDatetime.Month, currentDatetime.Day, 0, 0, 0);
            return currentDatetime;
        }
        /// <summary>
        /// 把时间格式12:59:00 转换成小时数，并保留一位小数  保留一位小数,且不四舍五入
        /// </summary>
        /// <param name="myDate"></param>
        /// <returns></returns>
        private string GetTotalHours(TimeSpan? myDate)
        { 
            decimal returnHours = 0;
            if (myDate != null)
            {
                decimal hours = myDate.Value.Hours;//取小时部分
                decimal minsAll = (decimal)myDate.Value.Minutes / 60;//取分钟部分，除以60，换算成小时
                decimal mins = Math.Truncate(minsAll * 10) / 10;//保留一位小数
                returnHours = hours + mins;
            }
            string returnResult = String.Format("{0:F1}", returnHours);//默认为保留两位 此处设置保留一位小数 
            return returnResult;
        }
        public static DateTime NewDate(long timestamp)
        {
            DateTime dt1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            long t = dt1970.Ticks + timestamp * 10000;
            return new DateTime(t);
        }
        public static DateTime DateTimeToUnixTimestamp(long timestamp)
        {
            DateTime dt1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            long t = dt1970.Ticks + timestamp ;
            return new DateTime(t);
        }
        /// <summary>
        /// 将Unix时间戳转换为Date 2019-10-1 类型 
        /// </summary>

        public static DateTime ConvertIntDate(long unixDateTime)
        { 
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime date = start.AddDays(unixDateTime).ToLocalTime();
            return date;
        }
        /// <summary>
        /// 将Unix时间戳转换为DateTime类型时间
        /// </summary>

        public static DateTime ConvertIntDateTime(long unixDateTime)
        {
           
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime date = start.AddMilliseconds(unixDateTime).ToLocalTime(); 
            return date; 
        }

        /// <summary>
        /// 将c# DateTime时间格式转换为Unix时间戳格式
        /// </summary> 
        public static long ConvertDateTimeInt(System.DateTime dt)
        {
            //DateTime time = System.DateTime.MinValue;
            //DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, 0));
            //long t = (time.Ticks - startTime.Ticks) / 10000;   //除10000调整为13位      
            //return t;
            //return (dt.ToUniversalTime().Ticks / 10000000 - 62135596800);
            TimeSpan ts = dt - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds * 1000);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="divisor">1000 | 1000000</param>
        /// <returns></returns>
        public static long ConvertDateTimeFixByDivisor(System.DateTime dt,int divisor)
        { 
            TimeSpan ts = dt - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds * divisor);
        }
        public static long ConvertDateTimeFixByDivisor(System.DateTime dt,TimeSpan timeSpan, int divisor)
        {
            DateTime new_dt = new DateTime(dt.Year,dt.Month,dt.Day,timeSpan.Hours,timeSpan.Minutes,timeSpan.Seconds);
            TimeSpan ts = new_dt - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds * divisor);
        }

        public static decimal GetWorkDays(string strDaterange)
        {
            GlobalConfig globalConfig = new GlobalConfig();
            DateTimeRangeObj dateTimeRangeObj = new DateTimeRangeObj();
            dateTimeRangeObj = CommonBase.DateTimeRangeParse(strDaterange);
            if (dateTimeRangeObj.Start > dateTimeRangeObj.End)
                dateTimeRangeObj.End.AddDays(1);

            double TotalDays = dateTimeRangeObj.End.Subtract(dateTimeRangeObj.Start).TotalDays;
            double TotalHours = dateTimeRangeObj.End.Subtract(dateTimeRangeObj.Start).TotalHours;

            double WorkDaySpan = globalConfig.StandardWorkDaySpan; // default value = 8 hours

            if (TotalDays < 1)
            {
                double a = TotalHours / WorkDaySpan;
                TotalDays = Math.Round(a, 3);
            }
            else
            {
                double Remainder = TotalDays % 1;
                double a = Remainder * WorkDaySpan / 10;
                TotalDays = Math.Floor(TotalDays) + a;
            }

            return decimal.Parse(TotalDays.ToString());
        }
         
        public static bool IsInDateTimeRange(DateTime dt, DateTime start, DateTime end)
        {
            return dt.CompareTo(start) >= 0 && dt.CompareTo(end) <= 0;
        }
    }

    /// <summary>
    /// 时间戳
    /// </summary>
    public class DateTimeHelp
    {
        public static DateTime DT1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        private static DateTime _dt1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStamp(System.DateTime time, int length = 13)
        {
            long ts = ConvertDateTimeToLong(time);
            return ts.ToString().Substring(0, length);
        }
        public static long GetTimeStamp13(System.DateTime datetime)
        {
            int length = 13;
            long ts = ConvertDateTimeToLong(datetime);
            string tsStr = ts.ToString().Substring(0, length);
            return Convert.ToInt64(tsStr);
        }
        /// <summary>  
        /// 将c# DateTime时间格式转换为Unix时间戳格式  
        /// </summary>  
        /// <param name="datetime">时间</param>  
        /// <returns>long</returns>  
        public static long ConvertDateTimeToLong(System.DateTime datetime)
        {
            DateTime dtStart = new System.DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            System.DateTime startTime = dtStart; // TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            long t = (datetime.Ticks - startTime.Ticks) / 10000;   //除10000调整为13位      
            return t;
        }
        /// <summary>        
        /// 时间戳转为C#格式时间        
        /// </summary>        
        /// <param name=”timeStamp”></param>        
        /// <returns></returns>        
        //public static DateTime ConvertStringToDateTime(string timeStamp)
        //{
        //    DateTime dtStart = new System.DateTime(1970, 1, 1).ToLocalTime();
        //    //DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        //    long lTime = long.Parse(timeStamp + "0000");
        //    TimeSpan toNow = new TimeSpan(lTime);
        //    return dtStart.Add(toNow);
        //}
        /// <summary>
        /// E.g.:1572321217157 ( 13bit )
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime ConvertLongToDateTime(long timeStamp) 
        { 
            DateTime dtStart = new System.DateTime(1970, 1, 1).ToLocalTime();
            long lTime = timeStamp * 10000; //long.Parse(timeStamp + "0000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }
        /// <summary>
        /// 时间戳转为C#格式时间10位
        /// </summary>
        /// <param name="timeStamp">Unix时间戳格式</param>
        /// <returns>C#格式时间</returns>
        public static DateTime GetDateTimeFrom1970Ticks(long curSeconds)
        {
            DateTime dtStart = new DateTime(1970, 1, 1).ToLocalTime();
            //DateTime dtStart = DateTime.UtcNow.ToLocalTime();  // TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            ////dtStart = TimeZone.CurrentTimeZone.ToLocalTime(Convert.ToDateTime(dtnow));
            //dt1970.ToLocalTime()
            return dtStart.AddSeconds(curSeconds);
        }

        /// <summary>
        /// 验证时间戳
        /// </summary>
        /// <param name="time"></param>
        /// <param name="interval">差值（分钟）</param>
        /// <returns></returns>
        public static bool IsTime(long time, double interval)
        {
            DateTime dt = GetDateTimeFrom1970Ticks(time);
            //取现在时间
            DateTime dt1 = DateTime.Now.AddMinutes(interval);
            DateTime dt2 = DateTime.Now.AddMinutes(interval * -1);
            if (dt > dt2 && dt < dt1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 判断时间戳是否正确（验证前8位）
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static bool IsTime(string datetime)
        {
            string str = GetTimeStamp(DateTime.Now, 8);
            if (str.Equals(datetime))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Trun Into string
        /// </summary>
        /// <param name="dateTime">dateTime</param>
        /// <param name="mode">mode = 0:yyyy-MM-dd HH:mm |  1:yyyy-MM-dd |  2: HH:mm</param>
        /// <returns></returns>
        public static string DateTimeFormat(DateTime dateTime, int mode = 0)
        {
            string format = string.Format("{{0:{0}}}", Lang.GeneralUI_DateTimeFormat);
            if (dateTime == _dt1970)
            {
                return "-";
            }
            switch (mode)
            {
                case 0:
                    return string.Format(format, dateTime);

                case 1:
                    format = string.Format("{{0:{0}}}", Lang.GeneralUI_DateFormate);
                    return string.Format(format, dateTime);
                case 2:
                    format = string.Format("{{0:{0}}}", Lang.GeneralUI_TimeFormate);
                    return string.Format(format, dateTime);
                default:
                    return string.Format(format, dateTime);
            }
        }

        public static string DateTimeFormat(DateTime dateTime, bool timeAhead, bool newLine)
        {
            string fotmat = string.Format("{{0:{0}}}", Lang.GeneralUI_DateTimeFormat);
            if (dateTime == _dt1970)
            {
                return "-";
            }
            if (timeAhead && newLine)
            {
                fotmat = string.Format("{{0:{0}}}", Lang.GeneralUI_DateTimeAheadFormat);
                return string.Format(fotmat, dateTime);
            }
            else if (timeAhead && !newLine)
            {
                fotmat = string.Format("{{0:{0}}}", Lang.GeneralUI_TimeFormate);
                return string.Format(fotmat, dateTime);
            }
            else if (!timeAhead && !newLine)
            {
                fotmat = string.Format("{{0:{0}}}", Lang.GeneralUI_DateTimeFormat);
                return string.Format(fotmat, dateTime);
            }
            fotmat = string.Format("{{0:{0}}}", Lang.GeneralUI_DateTimeFormat);
            return string.Format(fotmat, dateTime);
        }

        public static string DateTimeFormat(DateTime dateTime,bool timeAhead)
        {
            DateTimeFormat dateTimeFormat = new DateTimeFormat();
            string result ;
            if (timeAhead)
            {
                result = string.Format(dateTimeFormat, "{0:F}", dateTime);
            }else
            {
                result = string.Format(dateTimeFormat, "{0:L}", dateTime);
            }
            return result;
        }
    }
    public class DateTimeFormat : IFormatProvider, ICustomFormatter
    {
        private static readonly DateTime _dt1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0);
         
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }
        public string Format(string fmt, object arg, IFormatProvider formatProvider)
        {
            DateTime argDT = (DateTime)arg;
            if (argDT == _dt1970)
            {
                return "-";
            } 
            // Provide default formatting for unsupported format strings.
            string ufmt = fmt.ToUpper(CultureInfo.InvariantCulture);
            if (!(ufmt == "F" || ufmt == "L"))
                try
                {
                    return HandleOtherFormats(fmt, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(String.Format("The format of '{0}' is invalid.", fmt), e);
                }
 
            if (ufmt == "L")                   
                return string.Format("{0:yyyy-MM-dd\nHH:mm}", argDT); 
            
            if (ufmt == "F")
                return string.Format("{0:HH:mm\nyyyy-MM-dd}", argDT);

            
            return string.Format("{0:yyyy-MM-dd HH:mm}", argDT);
        }

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            else if (arg != null)
                return arg.ToString();
            else
                return String.Empty;
        }
    } 
}