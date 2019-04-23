using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Degage.Timers
{
    public class RangeSymbolRule : IJobTriggerModeSymbolRule
    {
        public SymbolRuleTransferParameterType TransferParameterType { get; } = SymbolRuleTransferParameterType.Fixed;

        public Int32 RequriedParameterCount { get; } = 2;

        public Boolean IsSeparability { get; } = true;

        public Boolean RequriedValidate { get; } = true;

        public Char Symbol { get; } = TriggerModelUtilities.RangeSymbol;

        public TriggerModeMatchResultType Validate(DateTime time, TriggerModeFieldType fieldType, Int32[] args)
        {
            if (args.Length == 0)
            {
                return TriggerModeMatchResultType.InvaildTriggerMode;
            }

            var result = TriggerModeMatchResultType.NoMatch;

            Int32 start = args[0];
            Int32 end = args[1];
            if (start >= end)
            {
                return TriggerModeMatchResultType.InvaildTriggerMode;
            }
            var current = 0;
            current = TriggerModelUtilities.GetFieldValue(time, fieldType);

            if (start <= current && current <= end)
            {
                result = TriggerModeMatchResultType.Matched;
            }
            return result;
        }
    }
}
