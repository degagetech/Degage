#if SQLite
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Collections.Concurrent;
using System.Configuration;
using System.Data.SQLite;

namespace Degage.DataModel.Orm
{

    /// <summary>
    /// 提供一系列用于操作数据库的辅助对象
    /// </summary>
    public class SQLiteDbProvider : DbProvider
    {

        public SQLiteDbProvider(String name, String connectionString) : base(name, connectionString)
        {

        }

        public override DbConnection DbConnection(String connectionString = null, Boolean isRelevance = false)
        {
            SQLiteConnection  sqlConnection = 
                connectionString == null ? 
                new SQLiteConnection(this.ConnectionString) : 
                new SQLiteConnection(connectionString);
            if (isRelevance && !String.IsNullOrEmpty(connectionString))
            {
                this.ConnectionString = connectionString;
            }

            return sqlConnection;
        }


        public override DbCommand DbCommand(String commandText = null, DbParameter[] dbParameterArray = null)
        {
            SQLiteCommand sqlCommand = new SQLiteCommand
            {
                CommandText = commandText
            };
            if (dbParameterArray != null && dbParameterArray.Length > 0)
            {
                sqlCommand.Parameters.AddRange(dbParameterArray);
            }
            return sqlCommand;
        }


        public override DbParameter DbParameter(String name = null, Object value = null, DbType dbType = DbType.Object)
        {
            SQLiteParameter sqlParameter = new SQLiteParameter
            {
                ParameterName = name,
                Value = value
            };
            if (dbType != DbType.Object)
            {
                sqlParameter.DbType = dbType;
            }
            return sqlParameter;
        }

        /// <summary>
        /// SQL参数对象名称前导符
        /// </summary>
        public override String Prefix { get; } = "$";

        /// <summary>
        /// 用于避免关键词与表字段冲突
        /// </summary>
        public override String ConflictFreeFormat { get; set; } = "[{0}]";

    }

}
#endif