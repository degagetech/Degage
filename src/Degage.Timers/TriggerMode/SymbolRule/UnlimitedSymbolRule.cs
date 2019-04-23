using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.Timers
{
    public class UnlimitedSymbolRule : IJobTriggerModeSymbolRule
    {
        public SymbolRuleTransferParameterType TransferParameterType { get; } = SymbolRuleTransferParameterType.Unlimit;

        public Int32 RequriedParameterCount { get; } = 0;

        public Boolean IsSeparability { get; } = true;

        public Boolean RequriedValidate { get; } = true;

        public Char Symbol { get; } = TriggerModelUtilities.UnlimitedSymbol;

        public TriggerModeMatchResultType Validate(DateTime time, TriggerModeFieldType fieldType, Int32[] args)
        {
            return TriggerModeMatchResultType.Matched;
        }
    }
}
