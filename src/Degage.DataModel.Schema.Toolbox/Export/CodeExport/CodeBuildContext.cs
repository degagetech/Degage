using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Degage.DataModel.Schema.Toolbox
{
    /// <summary>
    /// 记录代码组建的状态信息
    /// </summary>
    public class CodeBuildContext
    {
        internal CodeBuildContext()
        {
        }
        public BuildLocationType Location { get; internal set; }
        /// <summary>
        /// 当前分析的内容符号
        /// </summary>
        public String Symbol { get; internal set; }
        /// <summary>
        /// 命名空间
        /// </summary>
        public String NameSpace { get; internal set; }
        /// <summary>
        /// 代码组建操作使用的类型映射配置
        ///  </summary>
        public TypeMapConfig TypeMapConfig { get; internal set; }
        /// <summary>
        /// 代码组建操作使用的符号修饰器
        /// </summary>
        public ISymbolModifier SymbolModifier { get; internal set; }
        /// <summary>
        /// 代码组建正在使用的 <see cref="Schema.TableSchema"/> 元数据信息
        /// </summary>
        public TableSchemaExtend TableSchema { get; internal set; }

        /// <summary>
        /// 代码组建正在使用的 <see cref="ColumnSchema"/> 元数据信息
        /// </summary>
        public ColumnSchemaExtend ColumnSchema { get; internal set; }
    }
    /// <summary>
    /// 代码组建所处的位置的常量
    /// </summary>
    public enum BuildLocationType
    {
        /// <summary>
        /// 主模板
        /// </summary>
        Main = 0,
        /// <summary>
        /// 属性模板
        /// </summary>
        Property
    }
}
