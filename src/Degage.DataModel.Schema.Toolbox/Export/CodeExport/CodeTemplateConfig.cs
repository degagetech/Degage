using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Degage.DataModel.Schema.Toolbox
{
    /*
         在代码模板中使用 $内容符号$ 对包裹需要填充的元数据信息项的名称，例如：表名，TableName,则使用时 $TableName$
         系统会在后续的处理中将表示 TableName 的元数据信息，填充到代码模板中，以及替换所有 $TableName$ 占位符
         **********
         为了生成一些需要多次重复填充的信息，您需要单独的属性代码模板用于生成例如类的字段、属性等代码信息。
         之后在主体代码模板中使用 #属性模板名称# 对包裹属性代码模板的名称，例如，
         现有属性代码模板 ,名称为 Properties，其格式如下：
         public $MapType$ $ColumnName$ {get;set;}
         主体代码模板
         public class $TableName$
         {
             #Properties#
         }
         系统会多次使用属性代码模板，并将填充结果一次填入到主体模板中 #Properties# 中
    */
    /// <summary>
    /// 代码模板，提供元信息占位符，并预定生成代码的格式
    /// </summary>
    [XmlRoot("CodeTemplate")]
    public class CodeTemplateConfig
    {
        /// <summary>
        /// 模板名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 模板的主体内容
        /// </summary>
        public String Body { get; set; }

        /// <summary>
        /// 生成的代码文件的扩展名，例如：.cs
        /// </summary>
        public String ExtensionName { get; set; }
        /// <summary>
        /// 属性代码模板的集合
        /// </summary>
        [XmlArrayItem(ElementName = "Item")]
        public PropertyCodeTemplateItem[] PropertyCodeTemplates { get; set; }

        /// <summary>
        /// 模板信息来源文件路径，在从文件中加载模板信息时，此属性会被填充
        /// </summary>
        internal String FromFilePath { get; set; }
    }
    /// <summary>
    /// 属性代码模板，表示生成模型类的时其属性使用的代码模板
    /// </summary>
    public class PropertyCodeTemplateItem
    {
        /// <summary>
        /// 属性代码模板名称，此名称在 <see cref="CodeTemplateConfig.PropertyCodeTemplates"/> 项中应该保持唯一
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 模板的主体内容
        /// </summary>
        public String Content { get; set; }
    }
}
