using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.Timer
{
    public class LoopSymbolRule : IJobTriggerModeSymbolRule
    {
        public SymbolRuleTransferParameterType TransferParameterType { get; } = SymbolRuleTransferParameterType.Fixed;

        public Int32 RequriedParameterCount { get; } = 2;

        public Boolean IsSeparability { get; } = true;

        public Boolean RequriedValidate { get; } = true;

        public Char Symbol { get; } = TriggerModelUtilities.LoopSymbol;

        public TriggerModeMatchResultType Validate(DateTime time, TriggerModeFieldType fieldType, Int32[] args)
        {
            var result = TriggerModeMatchResultType.InvaildValidateParameter;
            var start = args[0];
            var limit = args[1];
            if (limit == 0)
            {
                return result;
            }
            var current = 0;
            if (!TriggerModelUtilities.IsVaildFieldValue(start, fieldType))
            {
                return TriggerModeMatchResultType.InvaildValidateParameter;
            }
            current = TriggerModelUtilities.GetFieldValue(time, fieldType);

            //例如 2/10 从每分钟的第二秒开始，每隔 10 秒
            if (current >= start && (current - start) % limit == 0)
            {
                result = TriggerModeMatchResultType.Matched;
            }

            return result;
        }
    }
}
