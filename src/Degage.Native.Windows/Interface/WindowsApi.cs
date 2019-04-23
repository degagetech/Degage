using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Degage.Native.Windows
{
    /// <summary>
    /// 提供对 Windows 本地 Api 的封装
    /// </summary>
    public static partial class WindowsApi
    {
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern Int32 SendMessage(IntPtr hWnd, Int32 wMsg,
        Int32 wParam, [MarshalAs(UnmanagedType.LPWStr)] String lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern Boolean SendMessage(IntPtr hwnd, Int32 msg, Int32 wParam, StringBuilder lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern Int32 SendMessage(IntPtr hwnd, Int32 wMsg, Int32 wParam, Int32 lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern Boolean GetComboBoxInfo(IntPtr hwnd, ref ComboboxInfo pcbi);

        /// <summary>
        /// 该函数能在显示与隐藏窗口时能产生特殊的效果。
        /// </summary>
        /// <param name="handle">指定产生动画的窗口的句柄。</param>
        /// <param name="dwTime">指明动画持续的时间（以微秒计），完成一个动画的标准时间为200微秒。</param>
        /// <param name="dwFags">指定动画类型。这个参数可以是一个或多个下列标志的组合。标志描述：</param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true, EntryPoint = "AnimateWindow")]
        public static extern Boolean AnimateWindow(IntPtr handle, Int32 dwTime, Int32 dwFags);

        [DllImport("user32.dll", SetLastError = true, EntryPoint = "GetScrollInfo")]
        public static extern Boolean GetScrollInfo(IntPtr hwnd, Int32 fnBar, ref ScrollInfo lpsi);

        #region WindowsLong
        /// <summary>
        /// 获取指定窗口的有关信息
        /// </summary>
        /// <param name="hWnd">窗口的句柄</param>
        /// <param name="type">获取的信息的类型</param>
        /// <returns></returns>
        public static NativeApiResult<Int32> GetWindowsLong(IntPtr hWnd, WindowsLongType type)
        {
            NativeApiResult<Int32> result = null;
            //本地API调用
            var value = GetWindowLongNative(hWnd, (Int32)type);
            var errorCode = NativeApiResult.GetLastError();
            result = new NativeApiResult<Int32>(value, errorCode);
            return result;
        }

        /// <summary>
        /// 使用指定的新值替换指定窗口的有关信息
        /// </summary>
        /// <param name="hWnd">窗口的句柄</param>
        /// <param name="type">设置的信息的类型</param>
        /// <param name="newValue">新的值</param>
        /// <returns><see cref="NativeApiResult{Int32}.Result"/> 值表示替换前的值</returns>
        public static NativeApiResult<Int32> SetWindowLong(IntPtr hWnd, WindowsLongType type, Int32 newValue)
        {
            NativeApiResult<Int32> result = null;
            var value = SetWindowLongNative(hWnd, (Int32)type, (Int32)newValue);
            var errorCode = NativeApiResult.GetLastError();
            result = new NativeApiResult<Int32>(value, errorCode);
            return result;
        }

        [DllImport("User32.dll", SetLastError = true, EntryPoint = "GetWindowLong")]
        internal static extern Int32 GetWindowLongNative(IntPtr hWnd, Int32 nIndex);

        [DllImport("user32.dll", SetLastError = true, EntryPoint = "SetWindowLong")]
        internal static extern Int32 SetWindowLongNative(IntPtr hWnd, Int32 nIndex, Int32 dwNewLong);


        #endregion

        /// <summary>
        /// 获取指定窗口的设备上下文句柄
        /// </summary>
        /// <param name="hwnd">将获取其设备场景的窗口的句柄。若为 0，则要获取整个屏幕的DC</param>
        /// <returns><see cref="NativeApiResult{IntPtr}.Result"/>指定窗口的设备上下文的句柄，出错则为 0</returns>
        public static NativeApiResult<IntPtr> GetDC(IntPtr hwnd)
        {
            NativeApiResult<IntPtr> result = null;
            var dcIntPtr = GetDCNative(hwnd);
            var errorCode = NativeApiResult.GetLastError();
            result = new NativeApiResult<IntPtr>(dcIntPtr, errorCode);
            return result;
        }

        /// <summary>
        /// 释放由 <see cref="GetDC(IntPtr)"/> 函数获取的上下文句柄关联的资源
        /// </summary>
        /// <param name="hwnd">窗体的句柄</param>
        /// <param name="hdc">上下文的句柄</param>
        /// <returns><see cref="NativeApiResult{Int32}.Result"/>执行成功为1，否则为 0</returns>
        public static NativeApiResult<Int32> ReleaseDC(IntPtr hwnd, IntPtr hdc)
        {
            NativeApiResult<Int32> result = null;
            var releaseResult = ReleaseDCNative(hwnd, hdc);
            var errorCode = NativeApiResult.GetLastError();
            result = NativeApiResult.Create(releaseResult, errorCode);
            return result;
        }

        [DllImport("user32.dll", SetLastError = true, EntryPoint = "GetDC")]
        internal static extern IntPtr GetDCNative(IntPtr hwnd);

        [DllImport("user32.dll", SetLastError = true, EntryPoint = "ReleaseDC")]
        internal static extern Int32 ReleaseDCNative(IntPtr hwnd, IntPtr hdc);



        /// <summary>
        /// 获取指定设备上下文中具体位置上的像素信息
        /// </summary>
        /// <param name="hdc">设备上下文的句柄</param>
        /// <param name="nXPos">像素点的横向坐标</param>
        /// <param name="nYPos">像素点的纵向坐标</param>
        /// <returns>结果1 表示尝试转换的颜色信息对象，结果2 表示原始的像素信息</returns>
        public static NativeApiResult<Color?, UInt32> GetPixel(IntPtr hdc, Int32 nXPos, Int32 nYPos)
        {
            NativeApiResult<Color?, UInt32> result = null;
            Color? color = null;
            var pixel = GetPixelNative(hdc, nXPos, nYPos);
            var errorCode = NativeApiResult.GetLastError();
            if (errorCode == (Int32)LastErrorCode.Normal)
            {
                //    color= Color.FromArgb((Int32)pixel);
                color = Color.FromArgb(
                  //    (Int32)(pixel & 0xFF000000) >> 24,
                  (Int32)(pixel & 0x000000FF),
                  (Int32)(pixel & 0x0000FF00) >> 8,
                  (Int32)(pixel & 0x00FF0000) >> 16);
            }
            else
            {

            }
            result = NativeApiResult.Create(color, pixel, errorCode);
            return result;
        }

        /// <summary>
        /// 在指定的设备场景中取得一个像素的
        /// </summary>
        /// <param name="hdc">一个设备场景的句柄</param>
        /// <param name="nXPos">逻辑坐标中要检查的横坐标</param>
        /// <param name="nYPos">逻辑坐标中要检查的纵坐标</param>
        /// <returns>指定点的颜色</returns>
        [DllImport("gdi32.dll", SetLastError = true, EntryPoint = "GetPixel")]
        internal static extern UInt32 GetPixelNative(IntPtr hdc, Int32 nXPos, Int32 nYPos);

        [DllImport("user32.dll")]
        public static extern Int32 GetCursorPos(ref Point lpPoint);



    }
}
