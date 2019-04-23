using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.Timers
{
    /// <summary>
    /// 触发模式匹配结果
    /// </summary>
    public class TriggerModeMatchResult
    {
        /// <summary>
        /// 匹配结果类型
        /// </summary>
        public TriggerModeMatchResultType ResultType { get; set; }
        /// <summary>
        /// 对匹配结果的描述
        /// </summary>
        public String Explain { get; set; }
    }


    /// <summary>
    /// 触发模式匹配结果类型
    /// </summary>
    [Flags]
    public enum TriggerModeMatchResultType
    {
        /// <summary>
        /// 匹配
        /// </summary>
        Matched = 0,

        /// <summary>
        /// 不匹配
        /// </summary>
        NoMatch = 1,

        /// <summary>
        ///无效的触发模式
        /// </summary>
        InvaildTriggerMode = 2,

        /// <summary>
        /// 验证时错误
        /// </summary>
        ValidateError = 3,

        /// <summary>
        /// 无效的验证参数
        /// </summary>
        InvaildValidateParameter = 4

    }
}
