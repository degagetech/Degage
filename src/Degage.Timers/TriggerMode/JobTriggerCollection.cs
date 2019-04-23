using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.Timers
{
    /// <summary>
    ///用于存取 <see cref="JobTrigger"/> 对象的集合
    /// </summary>
    public class JobTriggerCollection : IEnumerable<JobTrigger>
    {
        private ConcurrentDictionary<String, JobTrigger> _jobTriggerTable;

        /// <summary>
        /// 返回集合中当前 <see cref="JobTrigger"/> 对象的数目
        /// </summary>
        public Int32 Count
        {
            get
            {
                return this._jobTriggerTable.Count;
            }
        }

        public JobTrigger this[String triggerMode]
        {
            get
            {
                return this.TryGetValue(triggerMode);
            }
        }

        /// <summary>
        /// 初始化 <see cref="JobTriggerCollection"/> 类的实例
        /// </summary>
        public JobTriggerCollection()
        {
            this._jobTriggerTable = new ConcurrentDictionary<String, JobTrigger>();
        }

        /// <summary>
        /// 尝试向集合中添加作业触发器对象，无法添加触发模式相同的触发器
        /// </summary>
        /// <param name="trigger">作业触发器</param>
        /// <returns></returns>
        public Boolean TryAdd(JobTrigger trigger)
        {
            if (this.IsVaildJobTrigger(trigger))
            {
                return this._jobTriggerTable.TryAdd(trigger.TriggerMode, trigger);
            }
            return false;
        }

        /// <summary>
        /// 尝试从集合中移除触发模式的触发器
        /// </summary>
        /// <param name="triggerMode">作业触发器的模式</param>
        /// <returns></returns>
        public Boolean TryRemove(String triggerMode)
        {
            if (String.IsNullOrEmpty(triggerMode)) return false;
            return this._jobTriggerTable.TryRemove(triggerMode, out var jobTrigger);
        }

        /// <summary>
        /// 尝试获取指定触发模式的作业触发器，若获取失败则返回 NULL
        /// </summary>
        /// <param name="triggerMode">触发模式</param>
        /// <returns>作业触发器</returns>
        public JobTrigger TryGetValue(String triggerMode)
        {
            if (String.IsNullOrEmpty(triggerMode)) return null;
            this._jobTriggerTable.TryGetValue(triggerMode, out var jobTrigger);
            return jobTrigger;
        }

        private Boolean IsVaildJobTrigger(JobTrigger trigger)
        {
            if (trigger == null) return false;
            if (String.IsNullOrEmpty(trigger.TriggerMode)) return false;
            if (this._jobTriggerTable.ContainsKey(trigger.TriggerMode))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 返回一个循环访问集合的枚举器
        /// </summary>
        /// <returns></returns>
        public IEnumerator<JobTrigger> GetEnumerator()
        {
            return this._jobTriggerTable.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._jobTriggerTable.Values.GetEnumerator();
        }
    }
}
