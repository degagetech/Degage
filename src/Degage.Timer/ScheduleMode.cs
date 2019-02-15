using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.Timer
{
    /// <summary>
    /// 作业任务的调度模式
    /// </summary>
    public enum ScheduleMode
    {
        /// <summary>
        /// 当已有作业在执行时，则忽略后续的任务调度请求
        /// </summary>
        Ignore = 0,
        /// <summary>
        /// 当已有作业在执行时，后续的调度请求会被依次添加到待执行队列中
        /// </summary>
        Queue = 1,
        /// <summary>
        ///  当已有作业在执行时，后续的调度请求会与其并行执行
        /// </summary>
        Parallel = 2
    }
}
