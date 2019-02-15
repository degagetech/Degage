using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.Timer
{
    public class BeginingSymbolRule : IJobTriggerModeSymbolRule
    {
        public SymbolRuleTransferParameterType TransferParameterType { get; } = SymbolRuleTransferParameterType.Unlimit;

        public Int32 RequriedParameterCount { get; } = 0;

        public Boolean IsSeparability { get; } = true;

        public Boolean RequriedValidate { get; } = true;

        public Char Symbol { get; } = TriggerModelUtilities.BeginingSymbol;

        public TriggerModeMatchResultType Validate(DateTime time, TriggerModeFieldType fieldType, Int32[] args)
        {
            var result = TriggerModeMatchResultType.InvaildValidateParameter;

            var current = 0;
            var minFieldValue = TriggerModelUtilities.GetMinFixedValue(fieldType);
            current = TriggerModelUtilities.GetFieldValue(time, fieldType);

            if (minFieldValue == current)
            {
                result = TriggerModeMatchResultType.Matched;
            }
            return result;
        }
    }
}
