using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
namespace Degage.DataModel.Schema.Toolbox
{
    /// <summary>
    /// 用于将导出结果指向到特定位置，例如：本地磁盘的其他目录、VS项目结构下等
    /// </summary>
    public interface IExportTargeter
    {
        String TargeterName { get; }
        String TargeterDescription { get; }

        event Action<Object, ExportTargetEventArgs> ExportTargetProcessed;
        /// <summary>
        /// 将指定的导出文件，定向到定向器当前表示的位置
        /// </summary>
        /// <param name="exportFiles"></param>
        void PointTo(String[] exportFiles);
    }
    public class ExportTargetEventArgs
    {
        public String FileName { get; set; }
        public Int32 Total { get; set; }
        public Int32 Current { get; set; }
    }
}
