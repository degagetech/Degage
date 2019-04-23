using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.DataModel.Schema
{
    /// <summary>
    /// 映射函数结构的信息
    /// </summary>
    [Serializable]
    public class FunctionSchema : SchemaBase, IObjectSchema
    {
        /// <summary>
        /// 函数的说明信息
        /// </summary>
        public String Explain { get; set; }
        /// <summary>
        /// 函数的定义信息
        /// </summary>
        public String Definition { get; set; }
    }
}
