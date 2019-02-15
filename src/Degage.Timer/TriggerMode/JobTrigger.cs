using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.Timer
{
    /// <summary>
    ///作业触发器
    /// </summary>
    public class JobTrigger
    {
        /// <summary>
        /// 已触发计数
        /// </summary>
        public Int32 TiggeredCount { get; set; }
        /// <summary>
        /// 上次触发的时间
        /// </summary>
        public DateTime LastTiggeredTime { get; set; }
        /// <summary>
        /// 触发模式字符串
        /// 格式如下：
        /// 
        /// * * * * * * *  (秒 分 时 天 周 月 年)
        /// *                  表示此位上无限制，如果右边全为此可缺省，左边不可缺省
        /// 例如： 5 * * * * * *，表示每年每月每周每天每时每分的第五秒触发一次，
        /// 可简写为 5
        /// %numeber   表示每，例如  %5  表示每 5 秒触发一次
        /// ^                 表示开头，例如  ^ ， 表示每分钟的第一秒触发一次
        /// &                 表示结尾，例如  & ， 表示每分钟的最后一秒触发一次
        /// </summary>
        public String TriggerMode { get; set; }
    }

}
