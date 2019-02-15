using System;
using System.Collections.Generic;
using System.Text;

namespace Degage
{
    /// <summary>
    /// 表示 Schema 信息的来源类型
    /// </summary>
    public enum SchemaSourceType
    {
        /// <summary>
        /// 从特性中获取 Schema 信息
        /// </summary>
        Attribute = 0,
        /// <summary>
        /// 从外部文件中获取 Schema 信息
        /// </summary>
        File = 1
    }
}
