using System;
using System.Collections.Generic;
using System.Text;

namespace Degage.Timers
{
    /// <summary>
    /// 作业操作执行完成事件参数
    /// </summary>
    public class JobExecuteCompletedEventArgs : System.EventArgs
    {
        /// <summary>
        /// 被执行的作业操作信息
        /// </summary>
        public Job Job { get; internal set; }
        /// <summary>
        /// 执行的结果
        /// </summary>
        public JobResult ExecuteResult { get; set; }
    }
}
