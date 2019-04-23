using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Degage.Native.Windows
{
    /// <summary>
    /// 对应 Win32 结构 RECT
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        public Int32 left;
        public Int32 top;
        public Int32 right;
        public Int32 bottom;
    }
}
