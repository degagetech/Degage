#if Oracle
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.DataModel.Orm
{
    public partial class BasicSqlFormat
    {
        /// <summary>
        /// 分页查询格式    0 查询语句    1  起始位置  2 结束位置 
        /// </summary>
        public const String PAGE_QUERY_FORMAT_ORACLE =
           @"SELECT *
                                 FROM
                                        (
                                    SELECT
                                        ""T_TABLE"".*,
                                        ROWNUM ""T_ROWNUM""
                                    FROM
                                        ({0}) ""T_TABLE""
                                WHERE
                                    ROWNUM <= {1}) WHERE ""T_ROWNUM"" > {2}";

    }
}
#endif