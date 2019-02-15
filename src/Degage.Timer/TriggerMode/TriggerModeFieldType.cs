using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.Timer
{
    /// <summary>
    /// 触发模式字段位的类型
    /// </summary>
    public enum TriggerModeFieldType
    {
        /// <summary>
        /// 秒
        /// </summary>
        Second = 0,
        /// <summary>
        /// 分
        /// </summary>
        Minute,
        /// <summary>
        /// 时
        /// </summary>
        Hour,
        /// <summary>
        /// 天或周
        /// </summary>
        DayOrWeek,
      
        /// <summary>
        /// 月份
        /// </summary>
        Month,
        /// <summary>
        /// 年份
        /// </summary>
        Year
    }
}
