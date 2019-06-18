using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Common;
namespace Degage.EMS.VersionControl
{
    /// <summary>
    /// 提供对 <see cref="IDataAccessor"/> 接口的基本实现
    /// </summary>
    public abstract class DataAccessor : IDataAccessor
    {
        /// <summary>
        /// 数据访问设置的选项
        /// </summary>
        public DataAccessOptions Options { get; set; } = new DataAccessOptions();
        public Boolean EnableTransaction
        {
            get
            {
                return this.Options.EnableTransaction;
            }
        }
        /// <summary>
        /// 表示此数据访问器是否已挂载到其他数据访问上
        /// </summary>
        public Boolean Mounted { get; private set; }
        private DataAccessor MountPoint
        {
            get
            {
                if (this._mountPointWeakReference.TryGetTarget(out var point))
                {
                    return point;
                }
                else
                {
                    throw new Exception("挂载点已被回收！");
                }
            }
        }
        WeakReference<DataAccessor> _mountPointWeakReference;
        /// <summary>
        ///当前使用的连接对象
        /// </summary>
        public DbConnection Connection
        {
            get
            {
                if (this.Mounted)
                {
                    return this.MountPoint.Connection;
                }
                if (_connection == null)
                {
                    if (this.Options?.DbProvider == null)
                    {
                        throw new Exception("数据访问实例配置错误！");
                    }
                    _connection = this.Options.DbProvider.DbConnection(this.Options.ConnectionString);
                    _connection.Open();
                    if (this.EnableTransaction)
                    {
                        this._transaction = this._connection.BeginTransaction();
                    }
                }
                return this._connection;
            }
        }
        private DbConnection _connection;
        /// <summary>
        /// 当前使用的事务对象，若未启用则为 NULL
        /// </summary>
        public DbTransaction Transaction
        {
            get
            {
                if (this.Mounted)
                {
                    return this.MountPoint.Transaction;
                }
                //如果在使用中启用了事务
                if (this._transaction == null && this.EnableTransaction)
                {
                    this._transaction = this._connection.BeginTransaction();
                }
                return this._transaction;
            }
        }
        private DbTransaction _transaction;


        /// <summary>
        /// 通过默认的构造函数创建一个 <see cref="DataAccessor"/> 的实例
        /// </summary>
        public DataAccessor()
        {

        }
        public virtual void Dispose()
        {
            try
            {
                if (this._connection != null)
                {
                    if (this._connection.State == System.Data.ConnectionState.Open)
                    {
                        this._connection.Close();
                    }
                }
                if (this._transaction != null)
                {
                    this._transaction.Dispose();
                }
            }
            catch
            {
            }
        }

        public void Commit()
        {
            if (this._transaction != null)
            {
                try
                {
                    this._transaction.Commit();
                }
                catch
                {
                    this._transaction.Rollback();
                    throw;
                }
            }
        }

        public async Task CommitAsync()
        {
            await Task.Run(this.Commit);
        }

        public void Mount(IDataAccessor accessor)
        {


            var mountPoint = accessor as DataAccessor;
            if (mountPoint == null)
            {
                throw new Exception($"挂载点类型不匹配，应该是类型 {typeof(DataAccessor).Name} 或其派生类！");
            }
            this._mountPointWeakReference = new WeakReference<DataAccessor>(mountPoint);
            this.Mounted = true;
        }
    }
}
