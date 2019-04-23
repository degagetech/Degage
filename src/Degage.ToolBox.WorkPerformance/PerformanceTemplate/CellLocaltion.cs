using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPerformance
{
    public class CellLocaltion
    {
        /// <summary>
        /// 表示单元格所在的行的位置，可以小于 0，表示相对表格最后一行的向上偏移量
        /// </summary>
        public Int32 RowIndex { get; set; }
        /// <summary>
        /// 表示单元格处于行的位置的索引
        /// </summary>
        public Int32 CellIndex { get; set; }
    }
}
