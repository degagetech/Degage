using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.Timers
{
    /// <summary>
    /// 作业执行的调度模式
    /// </summary>
    public enum ScheduleMode
    {
        /// <summary>
        /// 当已有作业在执行时，则忽略后续的需要执行的作业
        /// </summary>
        Ignore = 0,
        /// <summary>
        /// 当已有作业在执行时，后续的作业操作被依次添加到待执行队列中
        /// </summary>
        Queue = 1,
        /// <summary>
        ///  当已有作业在执行时，后续的作业会与其并行执行
        /// </summary>
        Parallel = 2
    }
}
