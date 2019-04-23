using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Degage.Native.Windows
{
    /// <summary>
    /// 对应 Win32 结构 COMBOBOXINFO
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ComboboxInfo
    {
        public Int32 cbSize;
        public Rect rcItem;
        public Rect rcButton;
        public IntPtr stateButton;
        public IntPtr hwndCombo;
        public IntPtr hwndItem;
        public IntPtr hwndList;
    }
}
