using System;
using System.Collections.Generic;
using System.Text;

namespace Degage.Timers
{
    /// <summary>
    ///作业任务的状态
    /// </summary>
    public enum JobTaskState
    {
        /// <summary>
        /// 已创建
        /// </summary>
        Created = 0,
        /// <summary>
        /// 运行中
        /// </summary>
        Running = 1,
        /// <summary>
        /// 已停止
        /// </summary>
        Stopped = 2
    }
}
