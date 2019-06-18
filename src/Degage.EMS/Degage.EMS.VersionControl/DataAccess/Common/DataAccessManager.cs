using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace Degage.EMS.VersionControl
{
    /// <summary>
    /// 用于管理现有的数据访问器
    /// </summary>
    public static partial class DataAccessManager
    {
        public static ConcurrentDictionary<Type, DataAcceesorEnvironment> DataAcceesorEnvironmentTable = new ConcurrentDictionary<Type, DataAcceesorEnvironment>();
        /// <summary>
        /// 添加已知的数据访问器类型，并注明此访问器所属数据域
        /// </summary>
        /// <typeparam name="IDA"></typeparam>
        /// <typeparam name="DA"></typeparam>
        public static void AddKnownAccessorType<IDA, DA>(String area = null) where IDA : IDataAccessor where DA : DataAccessor
        {
            AddKnownAccessorType(typeof(IDA), typeof(DA), area);
        }
        /// <summary>
        /// 添加已知的数据访问器类型，并注明此访问器所属数据域
        /// </summary>
        public static void AddKnownAccessorType(Type interfaceType, Type implementationType, String area = null)
        {
            if (!DataAcceesorEnvironmentTable.TryGetValue(interfaceType, out var factory))
            {
                Type type = implementationType;
                Expression exp = Expression.New(type);
                var convertExp = Expression.Convert(exp, typeof(Object));
                var objectCreator = (Func<Object>)Expression.Lambda(convertExp).Compile();

                DataAcceesorEnvironment environment = new DataAcceesorEnvironment();
                environment.Creator = objectCreator;
                environment.Area = area;
                DataAcceesorEnvironmentTable.TryAdd(interfaceType, environment);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="setupOptions">
        /// <see cref="String"/> 表示数据访问所属数据域 ，
        /// <see cref="DataAccessOptions"/> 表示数据访问设置</param>
        /// <returns></returns>
        public static IServiceCollection AddDataAccessService(this IServiceCollection services, Action<String, DataAccessOptions> setupOptions)
        {
            Register();
            foreach (var pair in DataAcceesorEnvironmentTable)
            {
                services.AddTransient(pair.Key, (provider) =>
                {
                    var environment = pair.Value;
                    var result = environment.Creator.Invoke();
                    IDataAccessor accessor = (IDataAccessor)result;
                    setupOptions.Invoke(environment.Area, accessor.Options);
                    return result;
                });
            }
            return services;
        }
    }
}
