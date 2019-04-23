using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Degage.Extension;
namespace Degage.Native.Windows
{
    /// <summary>
    /// 指定 Native API 调用时，调用线程可能发生的错误的编码
    /// </summary>
    public enum LastErrorCode
    {
        /// <summary>
        /// 未知错误   
        /// </summary>
        [EnumText("未知错误")]
        UnKnown = -1,

        /// <summary>
        /// 操作正常执行，当错误码为此时，可以认为操作调用成功
        /// </summary>
        [EnumText("操作正常执行")]
        Normal = 0
    }
}
