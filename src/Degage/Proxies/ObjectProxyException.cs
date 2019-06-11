using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Degage.Proxies
{
    /// <summary>
    /// 表示在代理对象的过程中引发的异常
    /// </summary>
    public class ObjectProxyException : Exception
    {
        /// <summary>
        /// 通过指定的错误消息，以及触发异常的被代理成员信息，初始化 <see cref="ObjectProxyException"/> 实例
        /// </summary>
        /// <param name="message">错误消息</param>
        /// <param name="proxiedMember">被代理的成员</param>
        public ObjectProxyException(String message, MemberInfo proxiedMember = null) : base(message)
        {

        }
    }
}
