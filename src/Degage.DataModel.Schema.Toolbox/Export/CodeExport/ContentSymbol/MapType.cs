using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Degage.DataModel.Schema.Toolbox
{
    using System.ComponentModel.Composition;
    [Export(typeof(IContentSymbol))]
    public class MapTypeContentSymbol : IContentSymbol
    {
        /// <summary>
        /// 继承自 <see cref="IContentSymbol.Symbol"/>
        /// </summary>
        public String Symbol { get; private set; } = "MapType";

        /// <summary>
        ///  继承自 <see cref="IContentSymbol.Description"/>
        /// </summary>
        public String Description { get; private set; } = "使用此符号以表示数据库列类型映射到的 .Net 类型";

        /// <summary>
        /// 继承自 <see cref="IContentSymbol.WhetherNeedRepetition"/>
        /// </summary>
        public Boolean WhetherNeedRepetition { get; private set; } = true;

        /// <summary>
        ///  继承自 <see cref="IContentSymbol.Analysing"/>
        /// </summary>
        public String Analysing(CodeBuildContext context)
        {
            if (context.Location == BuildLocationType.Property)
            {
                var schema = context.ColumnSchema;
                String dbType = context.ColumnSchema.DbTypeString;
                var mapItems = context.TypeMapConfig.MapItems.Where(t => t.Condition.DbType == dbType);
                foreach (var mapItem in mapItems)
                {
                    var condition = mapItem.Condition;
                    if (condition.IsNullable.HasValue)
                    {
                        if (schema.IsNullable != condition.IsNullable.Value)
                        {
                            continue; ;
                        }
                    }

                    if (condition.Length != null)
                    {
                        //如果长度为 * ，则列必须有长度信息(但可为任意数值)才能匹配
                        if (condition.Length == "*")
                        {
                            if (!schema.Length.HasValue)
                            {
                                continue;
                            }
                        }
                        //需要匹配具体的长度
                        else
                        {
                            if (schema.Length.Value.ToString() != condition.Length)
                            {
                                continue;
                            }
                        }
                    }

                    return mapItem.MapType;
                }
            }
            return null;
        }
    }
}
