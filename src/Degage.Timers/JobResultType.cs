using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.Timers
{
    /// <summary>
    /// 作业操作执行的结果类型
    /// </summary>
    [Serializable]
    public enum JobResultType
    {
        /// <summary>
        /// 作业已被忽略执行
        /// </summary>
        Ignore = -2,
        /// <summary>
        /// 作业尚未执行
        /// </summary>
        NonExecution = -1,
        /// <summary>
        /// 作业执行正常
        /// </summary>
        Normal = 0,
        /// <summary>
        /// 作业执行出现错误
        /// </summary>
        Error = 1,
        /// <summary>
        /// 作业执行时出现异常
        /// </summary>
        Exception = 2
    }
}
