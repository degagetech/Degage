using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Degage.EMS.VersionControl
{
    /// <summary>
    /// 表示承载数据访问器的环境
    /// </summary>
    public class DataAcceesorEnvironment
    {
        /// <summary>
        /// 用于创建数据访问器
        /// </summary>
        public Func<Object> Creator { get; internal set; }
        /// <summary>
        /// 表示数据访问器所属域
        /// </summary>
        public String Area { get; set; }
    }
}
