using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Degage.DataModel.Schema.Toolbox
{
    using System.ComponentModel.Composition;
    [Export(typeof(IContentSymbol))]
    public class PropertyNameContentSymbol : IContentSymbol
    {
        /// <summary>
        /// 继承自 <see cref="IContentSymbol.Symbol"/>
        /// </summary>
        public String Symbol { get; private set; } = "PropertyName";

        /// <summary>
        ///  继承自 <see cref="IContentSymbol.Description"/>
        /// </summary>
        public String Description { get; private set; } = "属性名称";

        /// <summary>
        /// 继承自 <see cref="IContentSymbol.WhetherNeedRepetition"/>
        /// </summary>
        public Boolean WhetherNeedRepetition { get; private set; } = true;

        /// <summary>
        ///  继承自 <see cref="IContentSymbol.Analysing"/>
        /// </summary>
        public String Analysing(CodeBuildContext context)
        {
            if (context.Location == BuildLocationType.Property)
            {
                String result =
                 context.SymbolModifier.
                 Modify(
                 context.ColumnSchema.Name,
                 SymbolModifyType.PropertyName);
                return result;
            }
            return null;
        }
    }
}
