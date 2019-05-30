#if MySql
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Collections.Concurrent;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Degage.DataModel.Orm
{

    /// <summary>
    /// 提供一系列用于操作数据库的辅助对象
    /// </summary>
    public class MySqlDbProvider : DbProvider
    {

        public MySqlDbProvider(String friendlyName, String connectionString) : base(friendlyName, connectionString)
        {

        }

        public override DbConnection DbConnection(String connectionString = null, Boolean isRelevance = false)
        {
            MySqlConnection sqlConnection = 
                connectionString == null ? 
                new MySqlConnection(this.ConnectionString) : 
                new MySqlConnection(connectionString);
            if (isRelevance && !String.IsNullOrEmpty(connectionString))
            {
                this.ConnectionString = connectionString;
            }

            return sqlConnection;
        }


        public override DbCommand DbCommand(String commandText = null, DbParameter[] dbParameterArray = null)
        {
            MySqlCommand sqlCommand = new MySqlCommand
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
            MySqlParameter sqlParameter = new MySqlParameter
            {
                ParameterName = name,
                Value = value
            };
            if (dbType != DbType.Object)
            {
                sqlParameter.DbType = dbType;
            }
            //   sqlParameter.DbType = dbType;
            return sqlParameter;
        }

        /// <summary>
        /// SQL参数对象名称前导符
        /// </summary>
        public override String Prefix { get; } = ":";

        /// <summary>
        /// 用于避免关键词与表字段冲突
        /// </summary>
        public override String ConflictFreeFormat { get; set; } = "`{0}`";

    }

}
#endif