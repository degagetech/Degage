using System;
using System.Collections.Generic;
using System.Text;

namespace Degage.DataModel
{
    /// <summary>
    /// 为模型类属性映射到列提供相应信息
    /// </summary>
    [AttributeUsage(AttributeTargets.Property,AllowMultiple =false)]
    public class ColumnAttribute : System.Attribute
    {
        /// <summary>
        /// 属性对应的数据库列的名称
        /// </summary>
        public String Name { get; set; }
    }
}
