using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Degage.DataModel.Schema.Toolbox
{
    using System.ComponentModel.Composition;
    [Export(typeof(IContentSymbol))]
    public class ColumnExplainContentSymbol : IContentSymbol
    {
        /// <summary>
        /// 继承自 <see cref="IContentSymbol.Symbol"/>
        /// </summary>
        public String Symbol { get; private set; } = "ColumnExplain";

        /// <summary>
        ///  继承自 <see cref="IContentSymbol.Description"/>
        /// </summary>
        public String Description { get; private set; } = "对列的说明信息";

        /// <summary>
        /// 继承自 <see cref="IContentSymbol.WhetherNeedRepetition"/>
        /// </summary>
        public Boolean WhetherNeedRepetition { get; private set; } = false;

        /// <summary>
        ///  继承自 <see cref="IContentSymbol.Analysing"/>
        /// </summary>
        public String Analysing(CodeBuildContext context)
        {
            String result = null;
            if (context.Location == BuildLocationType.Property)
            {
                result = context.ColumnSchema.Explain;
            }
            return result;
        }
    }
}
