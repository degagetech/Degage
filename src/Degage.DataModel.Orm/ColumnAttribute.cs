using System;
using System.Data;

namespace Degage.DataModel.Orm
{
    /// <summary>
    /// 附加在类的属性上的特性，以映射到数据库的表的字段
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ColumnAttribute : Attribute
    {
        public ColumnAttribute() { }
        public ColumnAttribute(String name)
        {
            this.Name = name;
        }
        /// <summary>
        ///在数据库中列的名字
        /// </summary>
        public String Name { get; set; }

        public DbType DbType { get; set; } = DbType.Object;
        /// <summary>
        /// 是否是主键
        /// </summary>
        public Boolean IsPrimaryKey { get; set; }
        /// <summary>
        /// 是否可空
        /// </summary>
        public Boolean IsNullable { get; set; }
        /// <summary>
        /// 默认值
        /// </summary>
        public Object DefalutValue { get; set; } = null;

        /// <summary>
        /// 在生成列名时，是否禁用更明确的指示，例如：不使用 表a.name 而是单纯使用 name
        /// </summary>
        public Boolean DisableColumnSpecifically { get; set; }

        /// <summary>
        /// 表示此列是否是一个 关联列，对于关联列，在 插入、更新时不会为其生成相应 SQL，而在查询时(查询列不包含此列)会尝试使用查询结果填充值
        /// </summary>
        public Boolean IsJoinColumn { get; set; }

        /// <summary>
        /// 关联列对应的表名
        /// </summary>
        public String JoinColumnTableName { get; set; }

    }
}
