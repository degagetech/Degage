using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Degage.Native.Windows
{
    /*
     *如何在 Windows 上编写高DPI适应的应用程序请参见：
     * https://docs.microsoft.com/en-us/windows/desktop/hidpi/high-dpi-desktop-application-development-on-windows
    */
    public static partial class WindowsApi
    {
        /// <summary>
        /// 设置进程 Dpi 感知的类型，
        /// 此函数在 Windows Vista 以及以上的系统中受支持，
        /// 否则调用无效，返回 <see cref="LastErrorCode.UnKnown"/> 未知错误的结果。
        /// </summary>
        public static NativeApiResult<Int32> SetProcessDpiAwareness(ProcessDPIAwareness dpiAwarenessValue)
        {
            NativeApiResult<Int32> result = null;
            if (Environment.OSVersion.Version.Major >= 6 && Environment.OSVersion.Version.Minor>=2)
            {
                var setResult = SetProcessDpiAwarenessNative((Int32)dpiAwarenessValue);
                result = NativeApiResult.Create(setResult, NativeApiResult.GetLastError());
            }
            else
            {
                result = NativeApiResult.Create(-1, (Int32)LastErrorCode.UnKnown);
            }
            return result;
        }

        [DllImport("shcore.dll", SetLastError = true, EntryPoint = "SetProcessDpiAwareness")]
        private static extern Int32 SetProcessDpiAwarenessNative(Int32 dpiAwarenessValue);
    }
}
