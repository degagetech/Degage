using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.Timers
{
    /// <summary>
    ///当 <see cref="JobTask"/> 对象方法的执行与对象此时的状态冲突时
    /// </summary>
    public class JobTaskStateInvaildException : Exception
    {
        /// <summary>
        /// 初始化 <see cref="JobTaskStateInvaildException"/> 类的实例
        /// </summary>
        public JobTaskStateInvaildException()
        {

        }
    }
}
