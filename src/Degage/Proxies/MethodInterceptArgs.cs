using System;
using System.Collections.Generic;
using System.Text;

namespace Degage.Proxies
{
    /// <summary>
    /// 提供方法拦截的参数信息，用于控制拦截行为
    /// </summary>
    public class MethodInterceptArgs
    {
        public Object CorrelationState { get; set; }
        /// <summary>
        /// 表示是否此方法调用是否已处理
        /// </summary>
        public Boolean Handled { get; set; }
        /// <summary>
        /// 停止方法调用，并抛出此异常
        /// </summary>
        public Exception AbortException { get; set; }
        /// <summary>
        /// 表示被代理方法的原始代理在执行时发生的异常是否已被处理
        /// </summary>
        public Boolean ExceptionHandled { get; set; }
    }
}
