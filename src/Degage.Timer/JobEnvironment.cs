using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.Timer
{
    /// <summary>
    /// 为作业运行提供相关辅助功能的集合
    /// </summary>
    public abstract class JobEnvironment : MarshalByRefObject
    {
        /// <summary>
        /// 获取与当前作业环境关联的作业视图
        /// </summary>
        /// <returns></returns>
        public abstract JobView GetCurrentView();
        /// <summary>
        ///记录日志
        /// </summary>
        public abstract void WriteLog(LogLevel level, String log);

        /// <summary>
        /// 使用 <see cref="LogLevel.Info"/> 日志级别记录日志
        /// </summary>
        /// <param name="log">日志信息</param>
        public void WriteInfoLog(String log)
        {
            this.WriteLog(LogLevel.Info, log);
        }
    }
}
