using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Degage.DataModel.Schema.Toolbox
{
    /// <summary>
    /// 表示代码模板中的内容符号，以及提供对内容符号表示信息的解析功能，您应该将此接口实现为无状态的
    /// </summary>
    public interface IContentSymbol
    {
        /// <summary>
        /// 内容符号
        /// </summary>
        String Symbol { get; }

        /// <summary>
        /// 内容符号的描述
        /// </summary>
        String Description { get; }

        /// <summary>
        /// 表示此内容符号在同一次代码组建活动中是否需要被重复解析
        /// </summary>
        Boolean WhetherNeedRepetition { get; }
        /// <summary>
        /// 解析内容符号在指定上下文中表示的信息，若无解析结果，则返回 NULL
        /// </summary>
        /// <param name="context">代码组建上下文</param>
        /// <returns>表示的信息</returns>
        String Analysing(CodeBuildContext context);

    }
}
