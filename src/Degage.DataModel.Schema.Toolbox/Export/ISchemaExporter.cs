using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.DataModel.Schema.Toolbox
{
    public interface ISchemaExporter
    {
        /// <summary>
        /// 导出进度改变时
        /// </summary>
        event Action<Object, SchemaExportEventArgs> ExportProgressChanged;
        void Export(IList<IExportTargeter> exportTargeters, IList<SchemaInfoTuple> schemas, ExportConfig config);
    }
    public class SchemaExportCompletedEventArgs : EventArgs
    {
        public String ExportDirectory { get; internal set; }

        public IList<String> ExportFiles { get; internal set; }
    }
    public class SchemaExportEventArgs : EventArgs
    {
        /// <summary>
        /// 所有需要导出的 Schema 信息的计数
        /// </summary>
        public Int32 Total { get; internal set; }
        /// <summary>
        ///  当前已导出的 Schema 信息的计数
        /// </summary>
        public Int32 Current { get; internal set; }

        /// <summary>
        /// 当前正在导出的 Schema 信息
        /// </summary>
        public SchemaInfoTuple SchemaInfo { get; internal set; }
    }
}
