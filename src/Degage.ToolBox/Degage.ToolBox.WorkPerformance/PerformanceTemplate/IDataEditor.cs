using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPerformance
{
    /// <summary>
    /// 提供与绩效模板对应的数据编辑能力
    /// </summary>
    public interface IDataEditor
    {
        /// <summary>
        /// 使用指定的绩效模板初始化数据编辑器
        /// </summary>
        /// <param name="template"></param>
        void Init(PerformanceTemplate template);
        /// <summary>
        /// 加载数据项到编辑器中
        /// </summary>
        /// <param name="dataItems"></param>
        void LoadDataItems(IList<DataItem> dataItems);
        /// <summary>
        /// 获取编辑器当前编辑的所有数据项
        /// </summary>
        /// <returns></returns>
        IList<DataItem> GetDataItems();
    }
}
