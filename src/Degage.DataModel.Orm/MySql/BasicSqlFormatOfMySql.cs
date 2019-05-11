using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.DataModel.Orm
{
    public partial class BasicSqlFormat
    {
        /// <summary>
        /// 分页查询格式    0 查询语句    1 排序字段名称  2 起始位置  3 查询行数  4 排序规则
        /// </summary>
        public const String MYSQL_PAGE_QUERY_FORMAT = "SELECT * FROM ({0}) t ORDER BY {1} {4} LIMIT {2},{3}";


    }
}
