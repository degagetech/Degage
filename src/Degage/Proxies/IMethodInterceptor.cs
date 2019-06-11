using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Degage.Proxies
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
        /// <param name="proxiedType">被代理的类型</param>
        /// <param name="invokeMethod">调用的被代理的方法</param>
        /// <param name="parameterValues">方法参数值列表</param>
        /// <param name="args">方法拦截的参数信息</param>
        /// <returns>方法的返回结果</returns>
        Object InovkeHandle(
            Object proxy,
            Type proxiedType,
            MethodInfo invokeMethod,
            Object[] parameterValues,
            MethodInterceptArgs args);

        /// <summary>
        /// 处理被代理方法的原始代码执行时发生的异常
        /// </summary>
        /// <param name="exc"></param>
        /// <param name="proxy"></param>
        /// <param name="proxiedType"></param>
        /// <param name="invokeMethod"></param>
        /// <param name="parameterValues"></param>
        /// <returns>针对于此调用的一个有效的返回值</returns>
        Object ExceptionHandle(
            Exception exc,
            Object proxy,
            Type proxiedType,
            MethodInfo invokeMethod,
            Object[] parameterValues,
            MethodInterceptArgs args);
    }
}
