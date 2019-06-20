using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;

namespace Degage.DataModel.Schema.Toolbox
{
    /// <summary>
    /// 表示本地文件目录的定向器
    /// </summary>
    public class DirectoryExportTargeter : IExportTargeter
    {
        public String TargeterName { get; protected set; }
        public String TargeterDescription { get; protected set; }
        /// <summary>
        /// 目标目录
        /// </summary>
        public String TargetDirectory { get; internal set; }

        public event Action<Object, ExportTargetEventArgs> ExportTargetProcessed;

        public DirectoryExportTargeter()
        {
            this.TargeterName = "文件目录";
            this.TargeterDescription = "将导出结构定向到本地磁盘目录中";
        }
        /// <summary>
        /// 继承自 <see cref="IExportTargeter.PointTo(String[])"/>
        /// </summary>
        /// <param name="exportFiles"></param>
        public void PointTo(String[] exportFiles)
        {
            if (exportFiles != null && exportFiles.Length > 0)
            {
                ExportTargetEventArgs args = new ExportTargetEventArgs();
                args.Total = exportFiles.Length;
                foreach (var filePath in exportFiles)
                {
                    String fileName = Path.GetFileName(filePath);
                    args.FileName = fileName;
                    String newPath = Path.Combine(this.TargetDirectory, fileName);
                    File.Copy(filePath, newPath, true);
                    args.Current++;
                    this.ExportTargetProcessed?.Invoke(this, args);
                }
            }


        }
    }
}
