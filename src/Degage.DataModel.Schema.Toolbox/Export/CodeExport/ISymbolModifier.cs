using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Degage.DataModel.Schema.Toolbox
{
    /// <summary>
    /// 提供将原始符号信息修饰为特定风格符号信息的功能
    /// </summary>
    public interface ISymbolModifier
    {
        /// <summary>
        /// 修饰指定的源符号，并指定修饰的目标类型
        /// </summary>
        /// <param name="sourceSymbol">源符号信息</param>
        /// <param name="type">目标类型</param>
        /// <returns>修饰后的符号信息</returns>
        String Modify(String sourceSymbol, SymbolModifyType type);
    }
    /// <summary>
    /// 表示符号修饰的目标类型
    /// </summary>
    public enum SymbolModifyType
    {
        Other = 0,
        ClassName = 1,
        FieldName = 2,
        PropertyName = 3,
    }
}
