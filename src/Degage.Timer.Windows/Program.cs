using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Degage.Timer.Windows
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
            host.Clock.ClockTime = DateTime.Now.AddDays(1);
            //host.JobTasks.TryAdd(new JobTask
            //{

            //});
            Application.Run(new MainForm());
        }
    }
}
