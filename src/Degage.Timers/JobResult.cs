using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.Timers
{
    /// <summary>
    /// 表示一次作业操作的结果
    /// </summary>
    [Serializable]
    public class JobResult
    {
        /// <summary>
        /// 初始化 <see cref="JobResult"/> 类的实例
        /// </summary>
        public JobResult() { }

        /// <summary>
        /// 初始化 <see cref="JobResult"/> 类的实例，并使用指定的信息
        /// </summary>
        /// <param name="resultType">作业的结果</param>
        /// <param name="code">结果的编码，用于对结果信息的扩展</param>
        /// <param name="message">结果的描述信息，用于对结果信息的扩展</param>
        public JobResult(JobResultType resultType, Int32 code, String message) : this()
        {
            this.ResultType = resultType;
            this.Code = code;
            this.Message = message;
        }
        /// <summary>
        /// 作业结果类型
        /// </summary>
        public JobResultType ResultType { get; internal set; }
        /// <summary>
        /// 结果编码
        /// </summary>
        public Int32 Code { get; internal set; }
        /// <summary>
        /// 消息
        /// </summary>
        public String Message { get; internal set; }
    }
}
