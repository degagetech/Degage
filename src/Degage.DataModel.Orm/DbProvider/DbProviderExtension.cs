using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;
using System.Text;

namespace Degage.DataModel.Orm
{
    /// <summary>
    /// 为 <see cref="DbProvider"/> 类型提供常用操作扩展
    /// </summary>
    public static class DbProviderExtension
    {
        public static Table<T> CreateTable<T>(this DbProvider dbProvider) where T : class
        {
            Table<T> table = new Table<T>(dbProvider);
            return table;
        }
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

        public static IDriver<T> Select<T>(this DbProvider provider) where T : class
        {
            Table<T> table = new Table<T>(provider);
            return table.Select();
        }

        public static IDriver<T> Query<T>(this DbProvider provider, String sql) where T : class
        {
            Table<T> table = new Table<T>(provider);
            return table.SelectSQL<T>(sql);
        }


        public static IDriver<T> Delete<T>(this DbProvider provider) where T : class
        {
            Table<T> table = new Table<T>(provider);
            return table.Delete();
        }

        public static IDriver<T> Update<T>(this DbProvider provider, Expression<Func<T>> regenerator) where T : class
        {
            Table<T> table = new Table<T>(provider);
            return table.Update(regenerator);
        }

        public static IDriver<T> Insert<T>(this DbProvider provider, T obj) where T : class
        {
            Table<T> table = new Table<T>(provider);
            return table.Insert(obj);
        }
        public static IDriver<T> BatchInsert<T>(this DbProvider provider, IEnumerable<T> obj) where T : class
        {
            Table<T> table = new Table<T>(provider);
            return table.BatchInsert(obj);
        }

        public static List<T> ExecuteQuery<T>(this DbProvider dbProvider, String sql, DbParameter[] paras = null, DbConnection connection = null, DbTransaction transaction = null) where T : class
        {
            List<T> results = new List<T>();
            if (String.IsNullOrEmpty(sql))
            {
                return results;
            }
            Boolean requiredDispose = connection == null;
            DbDataReader dataReader = null;
            try
            {
                connection = connection ?? dbProvider.DbConnection();
                DbCommand command = dbProvider.DbCommand();
                ExceutePrepare(connection, command, sql, paras);
                if (transaction != null)
                {
                    command.Transaction = transaction;
                }
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                dataReader = command.ExecuteReader();
                command.Parameters.Clear();
                results = DataExtractor<T>.ToList(dataReader);

            }
            finally
            {
                dataReader?.Close();
                if (requiredDispose)
                {
                    connection.Dispose();
                }
            }

            return results;
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
        /// <summary>
        /// 根据指定的条件表达式查询数据，若无返回一个元素个数为零的链表对象
        /// </summary>
        public static List<T> Load<T>(this DbProvider provider, Expression<Func<T, Boolean>> expression = null) where T : class
        {
            List<T> result = null;
            Table<T> table = new Table<T>(provider);
            IDriver<T> driver = table.Select();
            if (expression != null)
            {
                driver = driver.Where(expression);
            }
            result = driver.ExecuteReader().ToList();

            return result;
        }
        /// <summary>
        /// 删除满足指定条件表达式的记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Boolean Delete<T>(Expression<Func<T, Boolean>> expression, DbProvider provider) where T : class
        {
            Boolean success = false;
            Table<T> table = new Table<T>(provider);
            IDriver<T> driver = table.Delete().Where(expression);
            success = driver.ExecuteNonQuery() > 0;
            return success;
        }


        /// <summary>
        /// 使用指定的更新表达式以及条件表达式更新记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="updater"></param>
        /// <param name="expression"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static Boolean Update<T>(
            this DbProvider provider,
            Expression<Func<T>> updater,
            Expression<Func<T, Boolean>> expression
            ) where T : class
        {
            Boolean success = false;
            Table<T> table = new Table<T>(provider);
            var driver = table.Update(updater);
            driver.Where(expression);
            success = driver.ExecuteNonQuery() > 0;
            return success;
        }
        /// <summary>
        /// 使用指定的条件表达式，更新对象到数据库中
        /// 注意，此操作先将旧的记录删除，在使用新的数据插入一条记录
        /// </summary>
        public static Boolean UpdateByDelete<T>(this DbProvider provider, T obj, Expression<Func<T, Boolean>> expression) where T : class
        {
            Boolean success = false;
            Table<T> table = new Table<T>(provider);
            using (DbConnection connection = provider.DbConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    success = table.Delete().Where(expression).ExecuteNonQuery(connection, transaction) > 0;
                    if (success)
                    {
                        success = table.Insert(obj).ExecuteNonQuery(connection, transaction) > 0;
                    }
                    transaction.Commit();
                }
                catch (Exception exc)
                {
                    success = false;
                    transaction.Rollback();
                    throw exc;
                }
            }
            return success;
        }
        /// <summary>
        /// 使用指定的条件表达式，更新对象到数据库中
        /// 注意，此操作忽略字段为空的值的更新
        /// </summary>
        public static Boolean Update<T>(DbProvider provider, T obj, Expression<Func<T, Boolean>> expression) where T : class
        {
            Boolean success = false;
            Table<T> table = new Table<T>(provider);
            var driver = table.Update(obj).Where(expression);
            success = driver.ExecuteNonQuery() > 0;
            return success;
        }


    }
}
