using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Degage.DataModel.Orm;
namespace Degage.EMS.VersionControl
{
    /// <summary>
    /// 表示数据访问实例设置属性的集合
    /// </summary>
    public class DataAccessOptions
    {
        public DbProvider DbProvider { get; set; }
        /// <summary>
        /// 是否启用事务，启用后数据访问接口各项操作都通过同一事务提交，
        /// 你应该在使用数据访问接口的操作之前首先设置此属性
        /// </summary>
        public Boolean EnableTransaction { get; set; }
        /// <summary>
        ///数据库的连接字符串
        /// </summary>
        public String ConnectionString
        {
            get
            {
                return this.DbProvider.ConnectionString;
            }
        }
    }
}
