using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPerformance
{
    /// <summary>
    /// 表示一个绩效模板
    /// </summary>
    public class PerformanceTemplate
    {
        /// <summary>
        /// 模板名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 模板文件的路径
        /// </summary>
        public String TemplateFilePath { get; set; }
        /// <summary>
        /// 与模板对应的数据编辑器的程序集限定名
        /// </summary>
        public String DataEditorType { get; set; }
        /// <summary>
        /// 表示模板使用的占位格式
        /// </summary>
        public String PlaceholderFormat { get; set; }
        /// <summary>
        /// 模板结构项的结合，此集合中每个结构项的名称都唯一
        /// </summary>
        public TemplateSchemaItem[] SchemaItems { get; set; }
    }
}
