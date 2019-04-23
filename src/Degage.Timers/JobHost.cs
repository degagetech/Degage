using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.Timers
{
    public class JobHost
    {
        public JobHost()
        {
            this.JobTasks = new JobTaskCollection();
            this.Clock = new JobClock();
        }
        /// <summary>
        /// 作业时钟
        /// </summary>
        public JobClock Clock { get; }
        public JobTaskCollection JobTasks { get; }
    }
}
