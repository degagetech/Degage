using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Degage.EMS.VersionControl
{
    /// <summary>
    /// 响应状态编码集合
    /// </summary>
    public class ResponseStatusCodes
    {
        /// <summary>
        /// 成功
        /// </summary>
        public static Int32 OK = 0;
        /// <summary>
        /// 会话信息过期
        /// </summary>
        public static Int32 SessionExceed = 100;
    }
}
