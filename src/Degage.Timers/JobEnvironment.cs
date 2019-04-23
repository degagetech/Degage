using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.Timers
{
    /// <summary>
    /// 为作业运行提供相关辅助功能的集合
    /// </summary>
    public abstract class JobEnvironment : MarshalByRefObject
    {
        /// <summary>
        /// 在作业环境中创建一个用于展示作业细节的视图对象
        /// </summary>
        /// <returns></returns>
        public abstract JobView CreateJobView();

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="level">日志的级别</param>
        /// <param name="info">需要记录的日志信息</param>
        public abstract void RecordLog(LogLevel level, String info);

        /// <summary>
        /// 使用 <see cref="LogLevel.Info"/> 级别记录日志
        /// </summary>
        /// <param name="info">需要记录的信息</param>
        public void RecordInfoLog(String info)
        {
            this.RecordLog(LogLevel.Info, info);
        }
    }
}
