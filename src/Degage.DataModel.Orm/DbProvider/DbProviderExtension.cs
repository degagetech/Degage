using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;
using System.Text;

namespace Degage.DataModel.Orm
{
    public static class DbProviderExtension
    {
        private static void ExceutePrepare(
           DbConnection connection,
           DbCommand command,
           String sql,
           DbParameter[] parameters)
        {
            command.Connection = connection;
            command.CommandText = sql;
            if (parameters != null && parameters.Length > 0)
                command.Parameters.AddRange(parameters);

        }
        public static Int32 ExecuteNonQuery(this DbProvider dbProvider, String sql, DbParameter[] paras = null, DbConnection connection = null)
        {
            Int32 effect = 0;
            Boolean requiredDispose = connection == null;
            connection = connection ?? dbProvider.DbConnection();

            try
            {
                DbCommand command = dbProvider.DbCommand();
                ExceutePrepare(connection, command, sql, paras);
                effect = command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            finally
            {
                if (requiredDispose) connection.Dispose();
            }


            return effect;
        }
        public static Object ExecuteScalar(this DbProvider dbProvider, String sql, DbParameter[] paras = null, DbConnection connection = null)
        {
            Object result = 0;
            Boolean requiredDispose = connection == null;
            connection = connection ?? dbProvider.DbConnection();
            try
            {
                DbCommand command = dbProvider.DbCommand();
                ExceutePrepare(connection, command, sql, paras);
                result = command.ExecuteScalar();
                command.Parameters.Clear();
            }
            finally
            {
                if (requiredDispose) connection.Dispose();
            }


            return result;
        }


        /// <summary>
        /// 执行指定的查询语句，并返回包含查询结果的<see cref="DataTable"/>对象
        /// </summary>
        /// <returns>若参数异常，返回空引用</returns>
        public static DataTable ExecuteQuery(this DbProvider dbProvider, String sql, DbParameter[] paras = null, DbConnection connection = null)
        {
            DataTable table = null;
            if (String.IsNullOrEmpty(sql))
            {
                return table;
            }
            table = new DataTable();
            Boolean requiredDispose = connection == null;
            try
            {
                connection = connection ?? dbProvider.DbConnection();
                DbCommand command = dbProvider.DbCommand();
                ExceutePrepare(connection, command, sql, paras);
                connection.Open();
                DbDataReader dataReader = command.ExecuteReader();
                command.Parameters.Clear();
                table.Load(dataReader);
            }
            finally
            {
                if (requiredDispose)
                {
                    connection.Dispose();
                }
            }
            return table;
        }
    }
}
