using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.Timer
{
    public class TriggerModelUtilities
    {
        /// <summary>
        /// 循环模式符
        /// </summary>
        public static Char LoopSymbol = '/';
        /// <summary>
        /// 无限制
        /// </summary>
        public static Char UnlimitedSymbol = '*';
        /// <summary>
        /// 
        /// </summary>
        public static Char BeginingSymbol = '^';
        public static Char EndingSymbol = '$';
        public static Char WeekSymbol = 'w';
        public static Char MultipleFixedSymbol = ',';
        public static Char FixedSymbol = '#';
        public static Char RangeSymbol = '-';
        public static Char Empty = ' ';

        public static Int32 MinSecondValue = 0;
        public static Int32 MaxSecondValue = 59;

        public static Int32 MinMintueValue = 0;
        public static Int32 MaxMintueValue = 59;

        public static Int32 MinHourValue = 0;
        public static Int32 MaxHourValue = 23;

        public static Int32 MinWeekValue = 0;
        public static Int32 MaxWeekValue = 6;

        public static Int32 MinDayValue = 1;
        public static Int32 MaxDayValue = 31;

        public static Int32 MinMonthValue = 1;
        public static Int32 MaxMonthValue = 12;

        public static Int32 MinYearValue = 1999;
        public static Int32 MaxYearValue = 2099;


        /// <summary>
        /// 获取某个字段位上所能允许的最小值
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Int32 GetMinFixedValue(TriggerModeFieldType type)
        {
            Int32 result = 0;
            switch (type)
            {
                case TriggerModeFieldType.Second:
                    {
                        result = MinSecondValue;
                    }
                    break;
                case TriggerModeFieldType.Minute:
                    {
                        result = MinMintueValue;
                    }
                    break;
                case TriggerModeFieldType.Hour:
                    {
                        result = MinHourValue;
                    }
                    break;
                case TriggerModeFieldType.DayOrWeek:
                    {
                        result = MinDayValue;
                    }
                    break;
                case TriggerModeFieldType.Month:
                    {
                        result = MinMonthValue;
                    }
                    break;
                case TriggerModeFieldType.Year:
                    {
                        result = MinYearValue;
                    }
                    break;
            }
            return result;
        }
        /// <summary>
        /// 获取某个字段位上所能允许的最大值
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Int32 GetMaxFixedValue(TriggerModeFieldType type)
        {
            Int32 result = 0;
            switch (type)
            {
                case TriggerModeFieldType.Second:
                    {
                        result = MaxSecondValue;
                    }
                    break;
                case TriggerModeFieldType.Minute:
                    {
                        result = MaxMintueValue;
                    }
                    break;
                case TriggerModeFieldType.Hour:
                    {
                        result = MaxHourValue;
                    }
                    break;
                case TriggerModeFieldType.DayOrWeek:
                    {
                        result = MaxDayValue;
                    }
                    break;
                case TriggerModeFieldType.Month:
                    {
                        result = MaxMonthValue;
                    }
                    break;
                case TriggerModeFieldType.Year:
                    {
                        result = MaxYearValue;
                    }
                    break;
            }
            return result;
        }

        /// <summary>
        /// 获取某个时间具体字段位上的值，注意当类型位 <see cref="TriggerModeFieldType.DayOrWeek"/> 获取的是当月第几天
        /// </summary>
        /// <param name="time"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Int32 GetFieldValue(DateTime time, TriggerModeFieldType type)
        {
            Int32 result = 0;
            switch (type)
            {
                case TriggerModeFieldType.Second:
                    {
                        result = time.Second;
                    }
                    break;
                case TriggerModeFieldType.Minute:
                    {
                        result = time.Minute;
                    }
                    break;
                case TriggerModeFieldType.Hour:
                    {
                        result = time.Hour;
                    }
                    break;
                case TriggerModeFieldType.DayOrWeek:
                    {
                        result = time.Day;
                    }
                    break;
           
                case TriggerModeFieldType.Month:
                    {
                        result = time.Month;
                    }
                    break;
                case TriggerModeFieldType.Year:
                    {
                        result = time.Year;
                    }
                    break;
            }

            return result;
        }


        /// <summary>
        /// 根据指定字段位判断传入的值是否有效，此方法依据指定字段位所能允许的最小最大值给定范围，并判断传入值是否再范围内
        /// </summary>
        /// <param name="val"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Boolean IsVaildFieldValue(Int32 val, TriggerModeFieldType type)
        {
            Boolean result = false;
            switch (type)
            {
                case TriggerModeFieldType.Second:
                    {
                        result = IsVaildSecondValue(val);
                    }
                    break;
                case TriggerModeFieldType.Minute:
                    {
                        result = IsVaildMinuteValue(val);
                    }
                    break;
                case TriggerModeFieldType.Hour:
                    {
                        result =IsVaildHourValue(val);
                    }
                    break;
                case TriggerModeFieldType.DayOrWeek:
                    {
                        result = IsVaildDayValue(val);
                    }
                    break;
                case TriggerModeFieldType.Month:
                    {
                        result = IsVaildMonthValue(val);
                    }
                    break;
                case TriggerModeFieldType.Year:
                    {
                        result = IsVaildYearValue(val);
                    }
                    break;
            }
            return result;
        }
      
        public static Boolean IsVaildSecondValue(Int32 secondValue)
        {
            return MinSecondValue <= secondValue && secondValue <= MaxSecondValue;
        }
        public static Boolean IsVaildMinuteValue(Int32 minuteValue)
        {
            return MinMintueValue <= minuteValue && minuteValue <= MaxMintueValue;
        }
        public static Boolean IsVaildHourValue(Int32 hourValue)
        {
            return MinHourValue <= hourValue && hourValue <= MaxHourValue;
        }

        public static Boolean IsVaildWeekValue(Int32 weekValue)
        {
            return MinWeekValue <= weekValue && weekValue <= MaxWeekValue;
        }

        public static Boolean IsVaildDayValue(Int32 dayValue)
        {
            return MinDayValue <= dayValue && dayValue <= MaxDayValue;
        }

        public static Boolean IsVaildMonthValue(Int32 monthValue)
        {
            return MinMonthValue <= monthValue && monthValue <= MaxMonthValue;
        }

        public static Boolean IsVaildYearValue(Int32 yearValue)
        {
            return MinYearValue <= yearValue && yearValue <= MaxYearValue;
        }
    }
}
