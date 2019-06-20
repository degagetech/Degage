using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace Degage.EMS.VersionControl
{
    //请在此文件中注册你的数据访问器
    public static partial class DataAccessManager
    {
        /// <summary>
        /// 登记数据访问器，请在此函数中通过 <see cref="AddKnownAccessorType{IDA, DA}(String)"/> 添加你的数据访问器接口以及其相应实现类型
        /// </summary>
        public static void Register()
        {
            AddKnownAccessorType<IProjectInfoDataAccessor, ProjectInfoDataAccessor>();
        }
    }
}
