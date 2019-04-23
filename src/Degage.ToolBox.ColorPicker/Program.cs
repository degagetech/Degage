using Degage.Native.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Degage.ToolBox.ColorPicker
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            WindowsApi.SetProcessDpiAwareness(ProcessDPIAwareness.ProcessPerMonitorDPIAware);
            Application.Run(new ColorPickerForm());
        }
    }
}
