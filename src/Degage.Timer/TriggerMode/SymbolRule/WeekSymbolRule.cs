using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Degage.Timer
{
    public class WeekSymbolRule : IJobTriggerModeSymbolRule
    {
        public SymbolRuleTransferParameterType TransferParameterType { get; } = SymbolRuleTransferParameterType.Unlimit;

        public Int32 RequriedParameterCount { get; } = 0;

        public Boolean IsSeparability { get; } = true;

        public Boolean RequriedValidate { get; } = true;

        public Char Symbol { get; } = TriggerModelUtilities.WeekSymbol;

        public TriggerModeMatchResultType Validate(DateTime time, TriggerModeFieldType fieldType, Int32[] args)
        {

            if (fieldType != TriggerModeFieldType.DayOrWeek || args.Length == 0)
            {
                return TriggerModeMatchResultType.InvaildValidateParameter;
            }

            var result = TriggerModeMatchResultType.NoMatch;


            var current = 0;
            current = (Int32)time.DayOfWeek;

            foreach (var arg in args)
            {
                //检查参数
                if (!TriggerModelUtilities.IsVaildWeekValue(arg))
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
