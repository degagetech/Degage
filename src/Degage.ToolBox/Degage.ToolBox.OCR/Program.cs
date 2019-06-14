using Degage.Native.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Degage.ToolBox.OCR
{
    static class Program
    {
        readonly static Dictionary<String, Assembly> AssemblyTable = new Dictionary<String, Assembly>();
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
         //   AppDomain.CurrentDomain.AssemblyResolve += OnAssemblyResolve;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            WindowsApi.SetProcessDpiAwareness(ProcessDPIAwareness.ProcessPerMonitorDPIAware);
            Application.Run(new MainForm());
        }
        
        private static Assembly OnAssemblyResolve(Object sender, ResolveEventArgs args)
        {
            Assembly assembly = null;
            String dllName = new AssemblyName(args.Name).Name;
            //忽略对此类文件的加载
            if (dllName.Contains(".resources"))
            {
                return null; 
            }
            if (AssemblyTable.ContainsKey(dllName))
            {
                assembly = AssemblyTable[dllName];
                return assembly;
            }
            String dllResourceName = GetDllResourceName(dllName);
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(dllResourceName))
            {
                if (stream == null)
                {
                    Debug.Print($"Not found dll in resource :{dllName}");
                    return null;
                }
                Byte[] buffer = new BinaryReader(stream).ReadBytes((Int32)stream.Length);
                assembly = Assembly.Load(buffer);

                AssemblyTable[dllName] = assembly;
                return assembly;
            }
        }

        /// <summary>
        /// 获取指定名称的程序集的资源名称
        /// </summary>
        /// <param name="dllName"></param>
        /// <returns></returns>
        private static String GetDllResourceName(String dllName)
        {
            if (dllName.Contains(".dll") == false)
            {
                dllName += ".dll";
            }
            foreach (String name in Assembly.GetExecutingAssembly().GetManifestResourceNames())
            {
                if (name.EndsWith(dllName))
                {
                    return name;
                } 
            }
            return dllName;
        }

    }
}
