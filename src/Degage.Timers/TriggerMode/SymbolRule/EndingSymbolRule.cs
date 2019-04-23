using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.Timers
{
    public class EndingSymbolRule : IJobTriggerModeSymbolRule
    {
        public SymbolRuleTransferParameterType TransferParameterType { get; } = SymbolRuleTransferParameterType.Unlimit;

        public Int32 RequriedParameterCount { get; } = 0;

        public Boolean IsSeparability { get; } = true;

        public Boolean RequriedValidate { get; } = true;

        public Char Symbol { get; } = TriggerModelUtilities.EndingSymbol;

        public TriggerModeMatchResultType Validate(DateTime time, TriggerModeFieldType fieldType, Int32[] args)
        {
            var result = TriggerModeMatchResultType.InvaildValidateParameter;

            var current = 0;
            var maxFieldValue = TriggerModelUtilities.GetMaxFixedValue(fieldType);
            if (fieldType == TriggerModeFieldType.DayOrWeek)
            {
                maxFieldValue = DateTime.DaysInMonth(time.Year, time.Month);
            }


            current = TriggerModelUtilities.GetFieldValue(time, fieldType);

            if (maxFieldValue == current)
            {
                result = TriggerModeMatchResultType.Matched;
            }
            return result;
        }
    }
}
