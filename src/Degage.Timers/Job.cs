using System;
using System.Collections.Generic;
using System.Text;

namespace Degage.Timers
{
    /// <summary>
    /// 表示一次作业操作
    /// </summary>
    public class Job
    {
        /// <summary>
        /// 作业所属的作业任务的名称
        /// </summary>
        public String Name { get; internal set; }
        /// <summary>
        /// 符合的触发模式
        /// </summary>
        public String TriggerMode { get; internal set; }
        /// <summary>
        /// 作业的触发时间
        /// </summary>
        public DateTime TriggeTime { get; internal set; }

        /// <summary>
        /// 作业操作的执行结果
        /// </summary>
        public JobResult JobResult { get; internal set; }

        /// <summary>
        /// 初始化 <see cref="Job"/> 类的新实例
        /// </summary>
        public Job()
        {

        }
    }
}
