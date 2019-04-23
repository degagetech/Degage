#if Oracle
using System;
using System.Linq.Expressions;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections;
namespace Degage.DataModel.Orm
{
    public static class OracleDriverExtension
    {
        /// <summary>
        ///【置于调用链末尾】 对当前的查询做分页操作，start 起始位置。 count 获取数量，排序顺序默认
        /// </summary>
        public static IDriver<T> PageForOracle<T>(this IDriver<T> driver, Int32 start, Int32 count)
        where T : class
        {
            String sql = BasicSqlFormat.PAGE_QUERY_FORMAT_ORACLE;
            String endIndex = (start + count).ToString();
            String startIndex = start.ToString();
            sql = String.Format(sql, driver.SQLComponent.SQL, startIndex, endIndex);
            driver.SQLComponent.ClearSQL(sql);
            return driver;
        }
    }
}
#endif