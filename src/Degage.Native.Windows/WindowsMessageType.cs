using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.Native.Windows
{
    /// <summary>
    /// Windows 消息类型
    /// </summary>
    public enum WindowsMessageType : Int32
    {
        /// <summary>
        /// 空
        /// </summary>
        Null = 0x0000,
        /// <summary>
        /// 应用程序创建一个窗口   
        /// </summary>
        Create = 0x0001,
        /// <summary>
        /// 一个窗口被销毁 
        /// </summary>
        Destroy = 0x0002,
        /// <summary>
        /// 移动一个窗口   
        /// </summary>
        Move = 0x0003,
        /// <summary>
        /// 改变一个窗口的大小 
        /// </summary>
        Size = 0x0005,
        /// <summary>
        /// 一个窗口被激活或失去激活状态；  
        /// </summary>
        Activate = 0x0006
    }
}
