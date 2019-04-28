using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
namespace Degage.DataModel.Schema.Toolbox
{
    /// <summary>
    /// 用于表示代码导出时的相关配置
    /// </summary>
    public class CodeExportConfig : ExportConfig
    {
        public const String XmlNameSpace = "Degage.DataModel.Schema.Toolbox";

        /// <summary>
        /// 导出代码的命名空间，可缺省
        /// </summary>
        public String CodeNameSpace { get; set; }
        /// <summary>
        /// 使用的类型配置，必须
        /// </summary>
        public TypeMapConfig TypeMapConfig { get; set; }
        /// <summary>
        /// 使用的代码模板配置，必须
        /// </summary>
        public CodeTemplateConfig CodeTemplateConfig { get; set; }

        /// <summary>
        /// 使用的 <see cref="ISymbolModifier"/> 实例，以帮助构建代码
        /// </summary>
        [JsonIgnore]
        public ISymbolModifier SymbolModifier { get; set; }

        /// <summary>
        /// 使用的 <see cref="IContentSymbol"/> 对照表，以帮助构建代码
        /// </summary>
        [JsonIgnore]
        public IDictionary<String, IContentSymbol> ContentSymbolTable { get; set; }
    }
}
