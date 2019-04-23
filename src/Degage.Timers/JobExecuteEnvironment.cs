using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.Timers
{
    /// <summary>
    /// 为作业执行提供相应环境
    /// </summary>
    public class JobExecuteEnvironment : IDisposable
    {
        /// <summary>
        /// 执行环境的名称
        /// </summary>
        public String Name { get; private set; }
        /// <summary>
        /// 获取作业当前的执行域
        /// </summary>
#if NET40
        public AppDomain ExecuteDomain { get; private set; }
#endif

        /// <summary>
        /// 使用指定名称构造 <see cref="JobExecuteEnvironment"/> 类的实例，此名称应尽量保证友好，唯一
        /// </summary>
        /// <param name="name"></param>
        public JobExecuteEnvironment(String name)
        {
            this.Name = name;

#if NET40
            //创建新的执行域
            this.ExecuteDomain = AppDomain.CreateDomain(this.Name);
#endif
        }
        /// <summary>
        /// 在执行环境中创建 <see cref="JobExecutor"/> 派生类的实例
        /// </summary>
        /// <param name="executorType"></param>
        /// <returns></returns>
        public JobExecutor CreateExecutor(Type executorType)
        {
            JobExecutor executor = null;
#if NET40
            var assemblyName = executorType.Assembly.GetName();
            executor = (JobExecutor)this.ExecuteDomain.CreateInstanceAndUnwrap(assemblyName.FullName, executorType.FullName);
#endif

#if NETSTANDARD2_0
            AssemblyLoadContext context = null;
#endif
            return executor;
        }
        public void Dispose()
        {
#if NET40
            if (this.ExecuteDomain != null)
            {
                AppDomain.Unload(this.ExecuteDomain);
            }
#endif
        }
    }
}
