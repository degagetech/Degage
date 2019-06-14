using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPerformance
{
    /// <summary>
    /// 指定模板结构项的类型的常量
    /// </summary>
    public enum TemplateSchemaItemType : Int32
    {
        /// <summary>
        /// 文本
        /// </summary>
        Text = 0,
        /// <summary>
        /// 表格
        /// </summary>
        Table = 1
    }
}
