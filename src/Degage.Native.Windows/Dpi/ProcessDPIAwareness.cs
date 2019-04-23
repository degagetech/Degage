using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.Native.Windows
{
    /*~~~囧 ，
    详细请参见：https://docs.microsoft.com/zh-cn/windows/desktop/api/shellscalingapi/ne-shellscalingapi-process_dpi_awareness
   */
    /// <summary>
    /// 
    /// Identifies dots per inch (dpi) awareness values. 
    /// DPI awareness indicates how much scaling work an application performs for DPI versus how much is done by the system.
    /// </summary>
    public enum ProcessDPIAwareness:Int32
    {
        /// <summary>
        /// DPI unaware.（该种方式是告诉系统， 我的程序不支持DPI aware, 请通过DWM虚拟化帮我们实现。）
        /// This app does not scale for DPI changes and is always assumed to have a scale factor of 100% (96 DPI). 
        /// It will be automatically scaled by the system on any other DPI setting.
        /// </summary>
        ProcessDPIUnaware = 0,
        /// <summary>
        /// System DPI aware.（该方式下告诉系统， 我的程序会在启动的显示器上自己支持DPI aware, 所以不需要对我进行DWM 虚拟化。 但是当我的程序被拖动到其他DPI不一样的显示器时， 请对我们先进行system DWM虚拟化缩放。）
        /// This app does not scale for DPI changes.
        /// It will query for the DPI once and use that value for the lifetime of the app. 
        /// If the DPI changes, the app will not adjust to the new DPI value. It will be automatically scaled up or down by the system when the DPI changes from the system value.
        /// </summary>
        ProcessSystemDPIAware = 1,
        /// <summary>
        /// Per monitor DPI aware. （ 该方式是告诉系统， 请永远不要对我进行DWM虚拟化，我会自己针对不同的Monitor的DPi缩放比率进行缩放。）
        /// This app checks for the DPI when it is created and adjusts the scale factor whenever the DPI changes.
        /// These applications are not automatically scaled by the system.
        /// </summary>
        ProcessPerMonitorDPIAware = 2
    }
}
