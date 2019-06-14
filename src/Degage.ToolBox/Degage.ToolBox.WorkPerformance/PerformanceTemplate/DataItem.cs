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
    /// 表示在模板填充、提取过程中结构项对应的数据
    /// </summary>
    public class DataItem
    {
        public DataItem()
        {
        }
        public DataItem(String name,String textData)
        {
            this.Name = name;
            this.TextData = textData;
        }
        public DataItem(String name, DataTable table)
        {
            this.Name = name;
            this.TableData = table;
        }
        /// <summary>
        /// 表示数据项的名称，此名称应与结构项的名称一一对应
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 用于存储 <see cref="TemplateSchemaItemType.Text"/> 类型结构项对应的数据项的值
        /// </summary>
        public String TextData { get; set; }
        /// <summary>
        /// 用于存储 <see cref="TemplateSchemaItemType.Table"/> 类型结构项对应的数据项的值
        /// </summary>
        public DataTable TableData { get; set; }
    }
}
