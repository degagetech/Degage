using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Degage.EMS.VersionControl
{
    /// <summary>
    /// 提供各项数据访问操作，实现此接口的实例通常在使用一次后便被释放，所以应将其实现为较轻量的
    /// </summary>
    public interface IDataAccessor : IDisposable
    {
        DataAccessOptions Options { get; set; }
        /// <summary>
        /// 表示此数据访问器是否已挂载到其他数据访问上
        /// </summary>
        Boolean Mounted { get; }
        /// <summary>
        /// 若数据库访问启用了事务，此操作会提交所有数据操作
        /// </summary>
        void Commit();
        /// <summary>
        /// 异步提交数据访问事务
        /// </summary>
        /// <returns></returns>
        Task CommitAsync();
        /// <summary>
        /// 将数据访问器挂载到指定的数据访问上，挂载后所有数据访问操作都通过挂载点执行
        /// </summary>
        /// <param name="accessor"></param>
        void Mount(IDataAccessor accessor);
    }
}
