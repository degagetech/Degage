using System;
using System.Collections.Generic;
using System.Text;

namespace Degage.Proxys
{
    /// <summary>
    /// 提供方法拦截的参数信息，用于控制拦截行为
    /// </summary>
    public class MethodInterceptArgs
    {
        
        /// <summary>
        /// 表示是否需要取消后续的拦截器的调用，并返回此次拦截结果
        /// </summary>
        public Boolean Cancel { get; set; }
    }
}
