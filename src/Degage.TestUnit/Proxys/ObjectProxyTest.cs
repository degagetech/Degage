using Degage.Proxys;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Degage.TestUnit.Proxys
{
    [TestClass]
    public class ObjectProxyTest
    {
#if !NETSTANDARD2_0
        [TestMethod]
        public void DynamicProxyValidityTestForInterface()
        {
            ObjectProxy<IProxiedInteface> interfaceProxy = new ObjectProxy<IProxiedInteface>();
            interfaceProxy.Proxy.Test();
        }
        [TestMethod]
        public void DynamicProxyValidityTestForAbstract()
        {
            ObjectProxy<ProxiedAbstractClass> abstractProxy = new ObjectProxy<ProxiedAbstractClass>();
          
            abstractProxy.Proxy.Test();
        }

        [TestMethod]
        public void DynamicProxyValidityTestForClass()
        {
            ObjectProxy<ProxiedClass> proxiedProxy = new ObjectProxy<ProxiedClass>();
            proxiedProxy.Proxy.Test();
        }
#endif
    }

    public interface IProxiedInteface:IDisposable
    {
        [NoProxy]
        void Test();
    }
 
    public abstract class ProxiedAbstractClass : IProxiedInteface
    {
        public abstract void Dispose();
        public abstract void Test();
    }
    public class ProxiedClass : ProxiedAbstractClass
    {
        public override void Dispose()
        {
            Debug.WriteLine("Hello ProxiedClass Dispose！");
        }

     
        public override void Test()
        {
            Debug.WriteLine("Hello ProxiedClass Test！");
        }

        public  void TestNew()
        {
            Debug.WriteLine("Hello ProxiedClass TestNew！");
        }
    }
}