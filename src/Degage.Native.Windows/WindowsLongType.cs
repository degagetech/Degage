using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.Native.Windows
{
    /// <summary>
    /// 窗口有关信息的类型，此值其实定义了窗口内存中偏移的值
    /// </summary>
    public enum WindowsLongType : Int32
    {
        /// <summary>
        /// 获取窗口样式，对应 GWL_STYLE
        /// </summary>
        Style = -16,
        /// <summary>
        /// 获取扩展窗口样式，对应 GWL_EXSTYLE
        /// </summary>
        ExStyle = -20,
        /// <summary>
        /// 获取实例句柄，对应 GWL_HINSTANCE
        /// </summary>
        HInstance = -6


        //GWL_HWNDPARENT
        //-8	获取所有者窗口句柄
        //GWL_ID
        //-12	获取窗口ID
        //GWL_USERDATA
        //-21	获取用户设置的32位数据，其值默认为0
        //GWL_WNDPROC
        //-4	获取窗口过程地址或句柄。必须使用CallWindowProc函数调用获取的窗口过程。
    }
}
