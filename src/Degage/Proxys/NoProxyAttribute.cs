using System;
using System.Collections.Generic;
using System.Text;

namespace Degage.Proxys
{
    /// <summary>
    /// 忽略对此成员的代理
    /// </summary>
    [AttributeUsage(
        AttributeTargets.Method,
        Inherited =false, 
        AllowMultiple=false)]
    public class NoProxyAttribute : System.Attribute
    {
    }
}
