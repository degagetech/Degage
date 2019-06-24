using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.EMS.VersionControl
{
    /// <summary>
    /// 提供与时间相关的功能，请在系统中使用此类获取时间相关的信息，若有需要请扩充此类
    /// </summary>
    public static class TimeAssistor
    {
        /// <summary>
        /// 默认当前系统使用的时间字符串的格式
        /// </summary>
        public const String SystemTimeStringFormat = "yyyy-MM-dd HH:mm:ss:fff";

        /// <summary>
        /// 此函数使用系统时间字符串格式 <see cref="TimeAssistor.SystemTimeStringFormat"/>
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static String ToTimeString(this DateTime time)
        {
            return time.ToString(SystemTimeStringFormat);
        }
        /// <summary>
        /// 在当前系统中用于表示一个无效时间
        /// </summary>
        public static DateTime InvalidTime
        {
            get
            {
                return _invalidTime;
            }
        }
        private static DateTime _invalidTime = new DateTime(1900, 1, 1, 0, 0, 0, 0);

        /// <summary>
        /// 判断时间在当前系统中是否有效
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static Boolean IsValid(this DateTime time)
        {
            return (time != DateTime.MinValue && time != _invalidTime);
        }
        /// <summary> 
        /// </summary>
        public static DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }
        /// <summary>
        /// 获取 yyyy-MM-dd hh:mm:ss 格式的当前时间的字符串
        /// </summary>
        public static String NowString
        {
            get
            {
                return DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            }
        }
        /// <summary>
        /// 获取类似于  yyyy-MM-dd 格式的当前日期的字符串
        /// </summary>
        public static String NowDateString
        {
            get
            {
                return GetDateString(DateTime.Now);
            }
        }
        /// <summary>
        /// 获取 hh:mm:ss:fff 格式的当前时间的字符串
        /// </summary>
        public static String HMSF
        {
            get
            {
                return DateTime.Now.ToString("hh:mm:ss:fff");
            }
        }
        /// <summary>
        /// 获取与当前日前相差指定间隔天数的日期的字符串格式类似于：yyyy-MM-dd
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public static String DateString(Int32 day)
        {
            return GetDateString(DateTime.Now.AddDays(day));
        }
        public static String DateString(this DateTime dateTime)
        {
            return GetDateString(dateTime);
        }
        private static String GetDateString(DateTime time)
        {
            return time.ToString("yyyy-MM-dd");
        }
        /// <summary>
        /// 将类似于  yyyy-MM-dd 格式的字符串转换为时间
        /// </summary>
        /// <param name="dateString"></param>
        /// <returns></returns>
        public static DateTime FromDateString(String dateString)
        {
            return DateTime.Parse(dateString);
        }
    }
}
