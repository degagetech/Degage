using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.Timers
{
    /// <summary>
    /// 模式符规则
    /// </summary>
    public interface IJobTriggerModeSymbolRule
    {
        /// <summary>
        /// 传参类型
        /// </summary>
        SymbolRuleTransferParameterType TransferParameterType { get; }
        /// <summary>
        /// 验证此符号所需参数的个数
        /// </summary>
        Int32 RequriedParameterCount { get; }
        /// <summary>
        /// 此符号是否具有分离性，例如  223X200 假定 X，符号不具有分离性则 223200 将会被作为一个数字
        /// </summary>
        Boolean IsSeparability { get; }
        /// <summary>
        /// 此符号是否必须被验证
        /// </summary>
        Boolean RequriedValidate { get; }
        /// <summary>
        /// 所表示的模式符
        /// </summary>
        Char Symbol { get; }
        /// <summary>
        /// 验证指定时间的指定字段是否属于在此规则下指定的参数的作用域中
        /// 此规则、参数、作用字段会确定出作用域，此函数验证指定时间是否在作用域中
        /// 例如   秒字段上    2-5 会确定出作用域的集合为   2、3、4、5  则验证时判断时间的
        /// 秒字段是否在此作用域中
        /// </summary>
        /// <param name="time">匹配的时间</param>
        /// <param name="fieldType">作用字段</param>
        /// <param name="args">参数顺序总是从左至右，例如： 0/20 则传入参数顺序
        /// 为  0 20
        /// </param>
        /// <returns></returns>
        TriggerModeMatchResultType Validate(
            DateTime time,
            TriggerModeFieldType fieldType,
            Int32[] args
            );
    }
}
