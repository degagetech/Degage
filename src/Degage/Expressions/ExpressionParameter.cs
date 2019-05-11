using System;
using System.Collections.Generic;
using System.Text;

namespace System.Linq.Expressions
{
    /// <summary>
    ///提供表达式中的参数信息
    /// </summary>
    public class ExpressionParameter
    {
        /// <summary>
        /// 参数的名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 参数的类型
        /// </summary>
        public Type Type { get; set; }
    }
}
