using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.Timers
{
    /*
         解析过程

         依次获取触发模式的字符，并按模式符与数字分别压入不同的栈中，在此过程中
         检验触发模式是否都为合法字符（0-9、以及支持的模式符）
         
         将数字压入至数字栈，模式符压入符号栈

         例如：   0/20 30 15 w2,3 * * 
                      表示每周二、三下午3点半时每隔20秒触发一次   
         
          依次解析模式字符串
          遇到数字符  添加至数字符号链表
          遇到模式符号  添加至模式符号队列，并将数字符号链表转换为数字添加至数字队列
          遇到空格  从符号队列中出队列获取符号规则，
                          从数字队列获取数字作为参数，循环此操作直到符号队列为空


         压入栈   数字队列    符号栈
            0            
                          /
            进入弹出准备状态
            2
            0            
           遇到空格下一个模式符
           弹出
           调用模式符处理接口 TriggerModeMatchResult  (String symbol,param Int32[] args)
           若为空格则推进字段位

    */
    /// <summary>
    /// 用于匹配触发模式，并提供匹配规则的扩展
    /// </summary>
    public interface IJobTriggerModeMacther
    {
        /// <summary>
        /// 新增模式符规则，若存在则替换
        /// </summary>
        /// <param name="matcher"></param>
        void AddSymbolRule(IJobTriggerModeSymbolRule rule);
        /// <summary>
        /// 获取指定时间与触发模式的匹配结果
        /// </summary>
        /// <param name="time">时间</param>
        /// <param name="triggerMode">触发模式</param>
        /// <returns></returns>
        TriggerModeMatchResult Match(DateTime time, String triggerMode);
    }


    /// <summary>
    /// 提供对 <see cref="IJobTriggerModeMacther"/> 的默认实现
    /// </summary>
    public class JobTriggerModeMacther : IJobTriggerModeMacther
    {


        private Dictionary<Char, IJobTriggerModeSymbolRule> _symbolRuleTable;

        private IJobTriggerModeSymbolRule _defaultSymbolRule;

        /// <summary>
        /// 初始化 <see cref="JobTriggerModeMacther"/> 类的实例
        /// </summary>
        public JobTriggerModeMacther()
        {

            _symbolRuleTable = new Dictionary<Char, IJobTriggerModeSymbolRule>();
            _defaultSymbolRule = new DefaultSymbolRule();

            _symbolRuleTable.Add(TriggerModelUtilities.BeginingSymbol, new BeginingSymbolRule());
            _symbolRuleTable.Add(TriggerModelUtilities.EndingSymbol, new EndingSymbolRule());
            _symbolRuleTable.Add(TriggerModelUtilities.LoopSymbol, new LoopSymbolRule());
            _symbolRuleTable.Add(TriggerModelUtilities.MultipleFixedSymbol, new MultipleFixedSymbolRule());
            _symbolRuleTable.Add(TriggerModelUtilities.RangeSymbol, new RangeSymbolRule());
            _symbolRuleTable.Add(TriggerModelUtilities.UnlimitedSymbol, new UnlimitedSymbolRule());
            _symbolRuleTable.Add(TriggerModelUtilities.WeekSymbol, new WeekSymbolRule());
        }



        public void AddSymbolRule(IJobTriggerModeSymbolRule rule)
        {
            if (rule.Symbol != TriggerModelUtilities.Empty)
                _symbolRuleTable[rule.Symbol] = rule;
        }

        public Boolean IsSupportedSymbol(Char symbol)
        {
            return this._symbolRuleTable.ContainsKey(symbol);
        }


        private IJobTriggerModeSymbolRule GetSymbolRule(Char symbol)
        {
            IJobTriggerModeSymbolRule rule = null;
            rule = this._symbolRuleTable[symbol];
            return rule;
        }

        private Int32[] TakeParameters(Queue<Int32> numberQueue, Int32 count)
        {
            List<Int32> args = new List<Int32>();
            while (count > 0 && numberQueue.Count > 0)
            {
                args.Add(numberQueue.Dequeue());
            }
            return args.ToArray();
        }

        public TriggerModeMatchResult Match(DateTime time, String triggerMode)
        {
            var result = new TriggerModeMatchResult();
            result.ResultType = TriggerModeMatchResultType.Matched;
            if (String.IsNullOrEmpty(triggerMode))
            {
                result.ResultType = TriggerModeMatchResultType.InvaildTriggerMode;
                return result;
            }


            List<Char> numberChars = new List<Char>();
            Queue<Int32> numberQueue = new Queue<Int32>();
            Queue<Char> symbolQueue = new Queue<Char>();

            var currentFieldType = TriggerModeFieldType.Second;

            var lastCh = TriggerModelUtilities.Empty;
            var symbol = TriggerModelUtilities.Empty;

            void TryAddNumberToQueue()
            {
                if (numberChars.Count == 0)
                {
                    return;
                }
                String numberStr = new String(numberChars.ToArray());
                numberQueue.Enqueue(Int32.Parse(numberStr));
                numberChars.Clear();
            }
            void AddSymbol(Char s)
            {
                symbolQueue.Enqueue(s);
            }

            foreach (var ch in triggerMode)
            {
                switch (ch)
                {
                    case var c when Char.IsDigit(c):
                        {
                            numberChars.Add(c);
                        }
                        break;
                    case var c when c == TriggerModelUtilities.Empty:
                        {
                            //如果是连续的空白符，则忽略
                            if (lastCh == TriggerModelUtilities.Empty) break;
                            TryAddNumberToQueue();

                            //尝试验证符号规则队列中的符号规则
                            while (symbolQueue.Count != 0)
                            {
                                Int32[] args = new Int32[] { };
                                var s = symbolQueue.Dequeue();
                                var rule = this.GetSymbolRule(s);
                                switch (rule.TransferParameterType)
                                {
                                    case SymbolRuleTransferParameterType.Unlimit:
                                        {
                                            //如果没有其他符号则参数全部传入，是否则不传入参数
                                            if (symbolQueue.Count == 0)
                                            {
                                                args = this.TakeParameters(numberQueue, numberQueue.Count);
                                            }
                                        }
                                        break;
                                    case SymbolRuleTransferParameterType.Fixed:
                                        {
                                            if (rule.RequriedParameterCount >= 0 && numberQueue.Count >= rule.RequriedParameterCount)
                                            {
                                                args = this.TakeParameters(numberQueue, rule.RequriedParameterCount);
                                            }
                                            else
                                            {
                                                result.ResultType = TriggerModeMatchResultType.InvaildTriggerMode;
                                                return result;
                                            }

                                        }
                                        break;
                                    case SymbolRuleTransferParameterType.All:
                                        {
                                            args = this.TakeParameters(numberQueue, rule.RequriedParameterCount);
                                        }
                                        break;
                                    default:
                                        {
                                            result.ResultType = TriggerModeMatchResultType.InvaildTriggerMode;
                                        }
                                        return result;
                                }
                                result.ResultType |= rule.Validate(time, currentFieldType, args);
                            }

                            //若还有剩余参数则当作固定值处理
                            if (numberQueue.Count != 0)
                            {
                                var args = this.TakeParameters(numberQueue, numberQueue.Count);
                                result.ResultType |= _defaultSymbolRule.Validate(time, currentFieldType, args);
                            }
                            currentFieldType += 1;
                        }
                        break;
                    case var c when this.IsSupportedSymbol(c):
                        {
                            var rule = this.GetSymbolRule(c);
                            if (rule.IsSeparability)
                            {
                                TryAddNumberToQueue();
                            }
                            if (rule.RequriedValidate)
                            {
                                AddSymbol(c);
                            }
                        }
                        break;
                    default:
                        {
                        }
                        return result;
                }
                lastCh = ch;
                if (result.ResultType != TriggerModeMatchResultType.Matched) return result;

            }

            return result;
        }
    }
}
