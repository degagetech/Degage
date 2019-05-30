using System;
using System.Linq.Expressions;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Degage.DataModel.Orm
{
    public static class DriverExtension
    {

        /// <summary>
        /// 对驱动器中的查询进行一次计数操作，此操作不改变驱动器本身的属性
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="columnName">计数的依据列，默认为 COUNT(1)</param>
        /// <param name="connection">使用的连接</param>
        /// <param name="transaction">使用的事务</param>
        /// <returns></returns>
        public static Int32 Count(this IDriver driver, String columnName = null, DbConnection connection = null)
        {
            Int32 count = 0;
            String sql = String.Empty;
            columnName = columnName ?? "1";
            //"SELECT COUNT(1) FROM (SUBQUERY) AS SUBQUERY"
            sql = SqlKeyWord.SELECT +
                SqlKeyWord.COUNT +
                SqlKeyWord.LEFT_BRACKET + columnName + SqlKeyWord.RIGHT_BRACKET +
                SqlKeyWord.FROM +
                SqlKeyWord.LEFT_BRACKET + driver.SQLComponent.SQL + SqlKeyWord.RIGHT_BRACKET + SqlKeyWord.AS + "TEMP";

            Object result = driver.DbProvider.ExecuteScalar(sql, driver.SQLComponent.Parameters.ToArray(), connection);
            if (result != null)
            {
                count = Convert.ToInt32(result);
            }

            return count;
        }
        public static IDriver<T> JoinIn<T, T1>(this IDriver<T> driver, Expression<Func<T1, Object>> filter, Object[] values)
          where T : class where T1 : class
        {
            driver.SQLComponent.AppendWhere();
            AnalyingIn<T1>(driver.DbProvider, filter, driver.SQLComponent, values);
            return driver;
        }
        public static IDriver<T> In<T>(this IDriver<T> driver, Expression<Func<T, Object>> filter, Object[] values)
            where T : class
        {
            driver.SQLComponent.AppendWhere();
            AnalyingIn<T>(driver.DbProvider, filter, driver.SQLComponent, values);
            return driver;
        }
        public static IDriver<T> In<T>(this IDriver<T> driver, String columnName, Object[] values)
         where T : class
        {
            driver.SQLComponent.AppendWhere();
            AnalyingIn<T>(driver.DbProvider, columnName, driver.SQLComponent, values);
            return driver;
        }
        /// <summary>
        /// 将指定的条件语句添加到 <see cref="IDriver"/> 中，并添加条件参数
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="whereSqlWithFormat">例如 t={0}</param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IDriver Where(this IDriver driver, String whereSqlWithFormat, params Object[] values)
        {
            String sql = whereSqlWithFormat;
            List<DbParameter> parameters = null;
            if (values.Length > 0)
            {
                parameters = new List<DbParameter>();
                String[] parameterNames = new String[values.Length];
                for (Int32 i = 0; i < values.Length; ++i)
                {
                    String paraname = driver.DbProvider.Prefix + ParaCounter<Object>.CountString;
                    parameterNames[i] = paraname;
                    Object value = values[i];
                    var parameter = driver.DbProvider.DbParameter(paraname, value);
                    parameters.Add(parameter);
                }
                sql = String.Format(sql, parameterNames);
            }
            driver.SQLComponent.AppendWhere();
            driver.SQLComponent.AppendSQL(sql);
            driver.SQLComponent.AddParameters(parameters);
            return driver;
        }
        public static IDriver<T> OrIn<T>(this IDriver<T> driver, Expression<Func<T, Object>> filter, Object[] values)
         where T : class
        {
            driver.SQLComponent.AppendWhere(false);
            AnalyingIn<T>(driver.DbProvider, filter, driver.SQLComponent, values);
            return driver;
        }
        internal static void AnalyingIn<T>(DbProvider dbProvider, Expression<Func<T, Object>> filter, SQLComponent component, Object[] values)
            where T : class
        {
            MemberExpression expression;
            ExpressionType noteType = filter.Body.NodeType; ;

            switch (noteType)
            {
                case ExpressionType.Convert:
                    UnaryExpression unary = filter.Body as UnaryExpression;
                    expression = (MemberExpression)unary.Operand;
                    break;
                case ExpressionType.MemberAccess:
                    {
                        expression = filter.Body as MemberExpression;
                    }
                    break;
                default:
                    throw new ArgumentException(nameof(filter)); ;
            }


            SchemaCache schema = Table<T>.Schema;
            var colSchema = schema.GetColumnSchema(expression.Member.Name);
            String columnName = colSchema.Name;
            columnName = String.Format(dbProvider.ConflictFreeFormat, columnName);
            columnName = String.Format(CommonFormat.COLUMN_FORMAT, schema.TableName, columnName);

            StringBuilder inParaNames = new StringBuilder();
            Int32 count = values.Length;
            String paraSymbol = "inPara";
            for (Int32 i = 0; i < count; ++i)
            {
                String paraName = dbProvider.Prefix + paraSymbol + ParaCounter<T>.CountString;
                inParaNames.Append(paraName);
                if (i != (count - 1))
                {
                    inParaNames.Append(SqlKeyWord.COMMA);
                }
                DbParameter parameter = dbProvider.DbParameter(
                    paraName, values[i], colSchema.DbType
                    );
                component.AddParameter(parameter);
            }
            component.AppendSQL(columnName);
            component.AppendSQL(SqlKeyWord.IN);
            component.AppendSQLFormat(CommonFormat.BRACKET_FORMAT, inParaNames.ToString());

        }

        internal static void AnalyingIn<T>(DbProvider dbProvider, String columnName, SQLComponent component, Object[] values)
          where T : class
        {

            StringBuilder inParaNames = new StringBuilder();
            Int32 count = values.Length;
            String paraSymbol = "inPara";
            for (Int32 i = 0; i < count; ++i)
            {
                String paraName = dbProvider.Prefix + paraSymbol + ParaCounter<T>.CountString;
                inParaNames.Append(paraName);
                if (i != (count - 1))
                {
                    inParaNames.Append(SqlKeyWord.COMMA);
                }
                DbParameter parameter = dbProvider.DbParameter(
                    paraName, values[i]
                    );
                component.AddParameter(parameter);
            }
            component.AppendSQL(columnName);
            component.AppendSQL(SqlKeyWord.IN);
            component.AppendSQLFormat(CommonFormat.BRACKET_FORMAT, inParaNames.ToString());

        }

        public static List<T> ToList<T>(this IDriver<T> driver, String connectionString = null) where T : class
        {
            return driver.ExecuteReader(connectionString).ToList();
        }

        public static List<T> ToList<T>(this IDriver<T> driver, DbConnection connection, DbTransaction transaction = null) where T : class
        {
            return driver.ExecuteReader(connection, transaction).ToList();
        }

        public static List<T> ToList<T>(this IDriver<T> driver, DbTransaction transaction) where T : class
        {
            return driver.ExecuteReader(transaction).ToList();
        }

        public static T[] ToArray<T>(this IDriver<T> driver, DbTransaction transaction) where T : class
        {
            return driver.ExecuteReader(transaction).ToArray();
        }

        public static T[] ToArray<T>(this IDriver<T> driver, String connectionString = null) where T : class
        {
            return driver.ExecuteReader(connectionString).ToArray();
        }

        public static T[] ToArray<T>(this IDriver<T> driver, DbConnection connection, DbTransaction transaction = null) where T : class
        {
            return driver.ExecuteReader(connection, transaction).ToArray();
        }

        public static T ToFirstOrDefault<T>(this IDriver<T> driver, DbTransaction transaction) where T : class
        {
            return driver.ExecuteReader(transaction).ToList().FirstOrDefault();
        }

        public static T ToFirstOrDefault<T>(this IDriver<T> driver, String connectionString = null) where T : class
        {
            return driver.ExecuteReader(connectionString).ToList().FirstOrDefault();
        }

        /// <summary>
        /// 使用当前 <see cref="IDriver{T}"/> 中的查询语句获取信息，并取出第一个，若无则返回 <see cref="{T}"/> 类型的默认值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="driver"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public static T ToFirstOrDefault<T>(this IDriver<T> driver, DbConnection connection, DbTransaction transaction = null) where T : class
        {
            return driver.ExecuteReader(connection, transaction).ToList().FirstOrDefault();
        }

    }
}
