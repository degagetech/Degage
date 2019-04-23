using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.Native.Windows
{
    /// <summary>
    /// Windows 窗体样式类型
    /// </summary>
    public enum WindowsStyleType : Int32
    {
        /// <summary>
        ///窗口风格：带标题栏的窗口
        /// </summary>
        Caption = 0xC00000,
        /// <summary>
        /// 窗口风格：带最大化按钮的窗口
        /// </summary>
        MaximizeBox = 0x10000,
        /// <summary>
        /// 窗口风格：带最小化按钮的窗口
        /// </summary>
        MinimizeBox = 0x20000,
        /// <summary>
        /// 窗口风格：带系统菜单的窗口
        /// </summary>
        SysMenu = 0x80000,
        /// <summary>
        ///扩展风格：窗口具有透眀属性(Win2000)以上
        /// </summary>
        ExLayered = 0x80000,
        /// <summary>
        /// 扩展风格：窗口透眀
        /// </summary>
        ExTransparent = 0x20

      
    }
}
