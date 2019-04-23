using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Degage.Timers
{
    /// <summary>
    ///表示作业操作的执行对象
    /// </summary>
    /// <remarks>
    /// 定时作业系统不保证对执行对象的调用是线程安全的，
    /// 你需要自行在代码中处理执行对象状态的同步
    /// </remarks>
    public abstract class JobExecutor : MarshalByRefObject, IDisposable
    {
        /// <summary>
        /// 使用指定的作业环境初始化 <see cref="JobExecutor"/> 类的实例
        /// </summary>
        /// <param name="environment">作业环境</param>
        public abstract void Init(JobEnvironment environment);
        /// <summary>
        /// 执行一次作业操作
        /// </summary>
        /// <param name="taskArgs">作业所属任务的参数</param>
        /// <returns>作业结果</returns>
        public abstract JobResult Execute(String taskArgs);

        /// <summary>
        /// 释放作业对象占用的资源
        /// </summary>
        public abstract void Dispose();
    }
}
