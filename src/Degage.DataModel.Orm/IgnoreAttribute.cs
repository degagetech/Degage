using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.DataModel.Orm
{
    /// <summary>
    /// 使得系统得 Orm 框架忽略类的指定属性，被忽略的属性不会参与任何数据访问操作
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IgnoreAttribute : System.Attribute
    {
    }
}
