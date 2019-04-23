using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Degage.Timers.Windows
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

            JobHost host = new JobHost();
            // host.Clock.ClockTime = DateTime.Now.AddDays(1);
            //host.JobTasks.TryAdd();

            Application.Run(new MainForm());
        }
    }
}
