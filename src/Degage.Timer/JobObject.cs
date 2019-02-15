using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Degage.Timer
{
    /// <summary>
    ///表示作业对象
    /// </summary>
    public abstract class JobObject : MarshalByRefObject
    {
        public abstract void InitJobView(JobView view);
        /// <summary>
        /// 执行作业
        /// </summary>
        /// <param name="taskArgs">作业所属任务的参数</param>
        /// <param name="context">作业上下文</param>
        /// <returns>作业结果</returns>
        public abstract JobResult JobExecute(String taskArgs, JobEnvironment context);
    }
}
