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
    ///  绩效模板结构项的提取结构
    /// </summary>
    public class ExtractSchema
    {
        /// <summary>
        /// 当结构项为 <see cref="TemplateSchemaItemType.Text"/> 时，使用此正则表达式作为提取依据
        /// </summary>
        public String ExtractRegex { get; set; }



        /// <summary>
        ///  当结构项为 <see cref="TemplateSchemaItemType.Table"/> 时，
        ///   表示相对于上一次提取操作结束行的向下偏移量，第一次提取操作总是相对于第 0 行
        /// </summary>
        public Int32? RowIndex { get; set; }

    }
}
