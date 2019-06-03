using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Degage.Proxys
{
    /// <summary>
    /// 用于处理对代理对象方法的调用
    /// </summary>
    public interface IMethodInterceptor
    {
        /// <summary>
        /// 处理对代理对象方法的调用
        /// </summary>
        /// <param name="proxy">代理对象</param>
        /// <param name="proxyType">代理的类型</param>
        /// <param name="invokeMethod">调用的代理的方法</param>
        /// <param name="parameterValues">方法参数值列表</param>
        /// <param name="args">方法拦截的参数信息</param>
        /// <returns>方法的返回结果</returns>
        Object InovkeHandle(
            Object proxy,
            Type proxyType,
            MethodInfo invokeMethod,
            Object[] parameterValues,
            MethodInterceptArgs args);
    }
}
