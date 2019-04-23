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
    /// 绩效模板结构项的填充结构
    /// </summary>
    public class FillSchema
    {
        /// <summary>
        /// 当结构项为 <see cref="TemplateSchemaItemType.Text"/> 时，使用此属性作为识别填充位置的标识，
        /// 例如 Id=Name，则模板文件中应有 ${Name}$  作为填充值的接收地址
        /// </summary>
        public String Id { get; set; }

        /// <summary>
        ///  当结构项为 <see cref="TemplateSchemaItemType.Table"/> 时，
        ///  使用此属性作为数据填充行的起始位置，表示相对于表格第 0 行的向下偏移量，此属性无法小于 0
        /// </summary>
        public Int32? RowIndex { get; set; }
    }
}
