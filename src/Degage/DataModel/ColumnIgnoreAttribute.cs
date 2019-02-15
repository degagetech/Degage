using System;
using System.Collections.Generic;
using System.Text;

namespace Degage.DataModel
{
    /// <summary>
    /// 附加此特性以忽略指定模型类属性对列的映射
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ColumnIgnoreAttribute : System.Attribute
    {
    }
}
