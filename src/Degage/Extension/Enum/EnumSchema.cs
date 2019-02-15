using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Degage.Extension
{
    /// <summary>
    /// 表示与特定枚举值关联的 Schema 信息
    /// </summary>
    public class EnumSchema : BaseSchema
    {
        /// <summary>
        /// 表示枚举对应的文本信息
        /// </summary>
        public String Text { get; set; }
        /// <summary>
        /// 表示文本对应的颜色信息
        /// </summary>
        public Color? Color { get; set; }
    }
}
