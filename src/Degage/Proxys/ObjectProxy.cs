using System;
using System.Collections.Generic;
using System.Text;

namespace Degage.Proxys
{
    /// <summary>
    /// 提供对指定类型的对象的代理能力
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObjectProxy<T> : IDisposable where T : class
    {
        public T Proxy { get; protected set; }
        public Type ProxyType { get; protected set; }
        public IList<IMethodInterceptor> MethodInterceptors { get; private set; }
        public ObjectProxy()
        {
            this.MethodInterceptors = new List<IMethodInterceptor>();
            this.ProxyType = typeof(T);
            var checkProxyType = this.ProxyType.IsInterface && this.ProxyType.IsAbstract && this.ProxyType.IsClass;
            if (!checkProxyType)
            {
                throw new Exception(TextResources.ObjectFactoryProxyTypeInvaild);
            }
        }

        public virtual void Open()
        {

        }
        public virtual void Close()
        {

        }
        public void Dispose()
        {

        }
    }
}
