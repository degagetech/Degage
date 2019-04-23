using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.Timers
{
    public enum SymbolRuleTransferParameterType
    {
        /// <summary>
        /// 无限制，可传入任意个数的参数，注意，系统会优先将参数分配给选择其他传参类型的符号
        /// </summary>
        Unlimit = 0,
        /// <summary>
        /// 固定的个数
        /// </summary>
        Fixed,
        /// <summary>
        /// 请求所有可用参数
        /// </summary>
        All
    }

}
