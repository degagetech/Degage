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
    /// 绩效模板的结构项目
    /// </summary>
    public class TemplateSchemaItem
    {
        /// <summary>
        /// 结构项的描述
        /// </summary>
        public String Explain { get; set; }
        /// <summary>
        /// 项名称，在模板的所有结构项中唯一
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 模板结构项的类型
        /// </summary>
        public TemplateSchemaItemType ItemType { get; set; } = TemplateSchemaItemType.Text;
        /// <summary>
        /// 当结构项为 <see cref="TemplateSchemaItemType.Table"/> 时，此属性指出表格的列的名称的集合，其长度也指明了列的数目
        /// </summary>
        public String[] TableSchemaItemColumns { get; set; }

        /// <summary>
        /// 当结构项为 <see cref="TemplateSchemaItemType.Table"/> 时，此属性指出对应表格的索引
        /// </summary>
        public Int32? TableIndex { get; set; }
        /// <summary>
        /// 填充结构
        /// </summary>
        public FillSchema FillSchema { get; set; }
        /// <summary>
        /// 提取结构
        /// </summary>
        public ExtractSchema ExtractSchema { get; set; }
    }
}
