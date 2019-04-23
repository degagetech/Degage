using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Degage.DataModel.Orm
{
    /// <summary>
    /// 用于表示列的结构信息
    /// </summary>
    public class ColumnSchema
    {
        /// <summary>
        /// 列名称
        /// </summary>
        public String Name { get; set; }
        public Boolean IsPrimaryKey { get; set; }
        public DbType DbType { get; set; } = DbType.Object;
        /// <summary>
        /// 在生成列名时，是否禁用更明确的指示，例如：不使用 表a.name 而是单纯使用 name
        /// </summary>
        public Boolean DisableColumnSpecifically { get;  set; }

        /// <summary>
        /// 表示此列是否是一个 关联列，对于关联列，在 插入、更新时不会为其生成相应 SQL，而在查询时会尝试使用查询结果填充值
        /// </summary>
        public Boolean IsJoinColumn { get; set; }

        /// <summary>
        /// 关联列对应的表名
        /// </summary>
        public String JoinColumnTableName { get; set; }
    }
}
