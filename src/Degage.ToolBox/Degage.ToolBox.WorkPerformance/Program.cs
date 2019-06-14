using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkPerformance
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

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.ThreadException += Application_ThreadException;
            MainForm.Current = new MainForm();
            Application.Run(MainForm.Current);
        }
      
        private static void Application_ThreadException(Object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            WaitingForm.HideWaiting();
            MessageBox.Show("系统发生了异常！");
        }

        private static void CurrentDomain_UnhandledException(Object sender, UnhandledExceptionEventArgs e)
        {
            WaitingForm.HideWaiting();
            MessageBox.Show("系统发生了异常！");
        }
    }
}
