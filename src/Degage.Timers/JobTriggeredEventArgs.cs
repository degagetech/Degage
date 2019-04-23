using System;
using System.Collections.Generic;
using System.Text;

namespace Degage.Timers
{
    /// <summary>
    /// 触发作业操作事件参数
    /// </summary>
    public class JobTriggeredEventArgs : System.EventArgs
    {
        /// <summary>
        /// 作业操作信息
        /// </summary>
        public Job Job { get; internal set; }
        /// <summary>
        /// 是否取消此次作业操作
        /// </summary>
        public Boolean Cancel { get; set; } = false;
    }
}
