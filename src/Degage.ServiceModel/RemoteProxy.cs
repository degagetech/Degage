using System;
using System.Collections.Generic;
using System.Text;
using Degage.Proxies;
namespace Degage.ServiceModel
{
    /// <summary>
    /// 为被代理的普通类型提供远程类型映射的能力，以使其具体行为由远程类型的决定
    /// </summary>
    public class RemoteProxy<T> : ObjectProxy<T>
    {
      
    }
}
