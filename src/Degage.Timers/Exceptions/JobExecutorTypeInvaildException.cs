using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.Timers
{
    /// <summary>
    ///当指定类型为 <see cref="JobExecutor"/> 无效的派生类时
    /// </summary>
    public class JobExecutorTypeInvaildException : Exception
    {
        /// <summary>
        /// 初始化 <see cref="JobExecutorTypeInvaildException"/> 类的实例
        /// </summary>
        public JobExecutorTypeInvaildException() : base()
        {

        }

        /// <summary>
        /// 使用指定的消息初始化 <see cref="JobExecutorTypeInvaildException"/> 类的实例
        /// </summary>
        /// <param name="message"></param>
        public JobExecutorTypeInvaildException(String message) : base(message)
        {
        }
    }
}
