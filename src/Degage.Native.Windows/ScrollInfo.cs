using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Degage.Native.Windows
{
    /// <summary>
    /// 对应 Win32 结构 SCROLLINFO
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ScrollInfo
    {
        public UInt32 cbSize;
        public UInt32 fMask;
        public Int32 nMin;
        public Int32 nMax;
        public UInt32 nPage;
        public Int32 nPos;
        public Int32 nTrackPos;
    }
}
