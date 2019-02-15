using System;
using System.Collections.Generic;
using System.Text;

namespace Degage.DataModel
{
    /// <summary>
    /// 为模型类映射到表提供相应信息
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TableAttribute : System.Attribute
    {
        /// <summary>
        /// 对应的数据库表的名称
        /// </summary>
        public String Name { get; set; }
    }

}
