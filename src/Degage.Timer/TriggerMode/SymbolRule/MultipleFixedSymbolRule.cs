using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Degage.Timer
{
    public class MultipleFixedSymbolRule : IJobTriggerModeSymbolRule
    {
        public SymbolRuleTransferParameterType TransferParameterType { get; } = SymbolRuleTransferParameterType.Unlimit;

        public Int32 RequriedParameterCount { get; } = 0;

        public Boolean IsSeparability { get; } = true;

        public Boolean RequriedValidate { get; } = false;

        public Char Symbol { get; } = TriggerModelUtilities.MultipleFixedSymbol;

        public TriggerModeMatchResultType Validate(DateTime time, TriggerModeFieldType fieldType, Int32[] args)
        {
            return TriggerModeMatchResultType.Matched;
        }
    }
}
