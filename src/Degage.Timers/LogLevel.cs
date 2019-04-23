using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.Timers
{
    /// <summary>
    ///表示日志信息的级别
    /// </summary>
    public class LogLevel
    {
        /// <summary>
        /// 普通日志信息，等级 0，不持久化
        /// </summary>
        public static LogLevel Info { get; }
        /// <summary>
        /// 警告信息，等级 10，持久化
        /// </summary>
        public static LogLevel Warning { get; }
        /// <summary>
        /// 错误信息，等级 100，持久化
        /// </summary>
        public static LogLevel Error { get; }

        /// <summary>
        /// 级别
        /// </summary>
        public Int32 Level { get; internal set; }
        /// <summary>
        /// 描述
        /// </summary>
        public String Description { get; internal set; }
        /// <summary>
        /// 是否持久化
        /// </summary>
        public Boolean IsPersistence { get; internal set; }


        static LogLevel()
        {
            Info = Create(0, TextRes.GetString("LogLevel_Info"), false);
            Warning = Create(10, TextRes.GetString("LogLevel_Warning"), true);
            Error = Create(100, TextRes.GetString("LogLevel_Error"), true);
        }

        public static LogLevel Create(Int32 level, String desc, Boolean isPersistence)
        {
            LogLevel logLevel = new LogLevel
            {
                Level = level,
                Description = desc,
                IsPersistence = isPersistence
            };
            return logLevel;
        }

    }
}
