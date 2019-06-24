using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.EMS.VersionControl
{
    /// <summary>
    /// 分页条件
    /// </summary>
    public class PageCondition
    {
        /// <summary>
        /// 表示分页设置的无效值
        /// </summary>
        public const Int32 Invaild = -2;
        /// <summary>
        /// 记录的起始索引，默认从0开始
        /// </summary>
        public virtual Int32 StartIndex { get; set; } = 0;
        /// <summary>
        /// 每一次分页获取的数据量，默认 200 条
        /// </summary>
        public virtual Int32 Count { get; set; } = 200;

        /// <summary>
        /// 符合条件的记录总数
        /// </summary>
        public virtual Int32 StatisticsCount { get; set; }

        /// <summary>
        /// 是否需要统计总数
        /// </summary>
        public virtual Boolean RequiredStatistics { get; set; }

        /// <summary>
        /// 是否需要分页
        /// </summary>
        public virtual Boolean RequiredLimit { get; set; }
    }
}
