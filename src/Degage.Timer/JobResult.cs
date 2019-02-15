using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.Timer
{
    /// <summary>
    /// 作业结果
    /// </summary>
    [Serializable]
    public class JobResult
    {
        public JobResultType ResultType { get; set; }
        public Int32 Code { get; set; }
        public String Message { get; set; }
    }
}
