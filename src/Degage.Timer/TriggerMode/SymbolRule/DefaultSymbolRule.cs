using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Degage.Timer
{
   internal class DefaultSymbolRule : IJobTriggerModeSymbolRule
    {
        public SymbolRuleTransferParameterType TransferParameterType { get; } = SymbolRuleTransferParameterType.Unlimit;

        public Int32 RequriedParameterCount { get; } = 0;

        public Boolean IsSeparability { get; } = true;

        public Boolean RequriedValidate { get; } = true;

        public Char Symbol { get; } = TriggerModelUtilities.FixedSymbol;

        public TriggerModeMatchResultType Validate(DateTime time, TriggerModeFieldType fieldType, Int32[] args)
        {
            if (args.Length == 0)
            {
                return TriggerModeMatchResultType.InvaildTriggerMode;
            }

            var result = TriggerModeMatchResultType.NoMatch;


            var current = 0;
            current = TriggerModelUtilities.GetFieldValue(time, fieldType);

            foreach (var arg in args)
            {
                //检查参数
                if (!TriggerModelUtilities.IsVaildFieldValue(arg,fieldType))
                {
                    return TriggerModeMatchResultType.InvaildValidateParameter;
                }

                if (current == arg)
                {
                    return TriggerModeMatchResultType.Matched;
                }
            }
            return result;
        }
    }
}
