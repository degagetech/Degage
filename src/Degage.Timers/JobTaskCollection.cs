using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using System.Collections;

namespace Degage.Timers
{
    /// <summary>
    /// /表示线程安全的作业任务集合
    /// </summary>
    public class JobTaskCollection : IEnumerable<JobTask>
    {
        private ConcurrentDictionary<String, JobTask> _jobTaskTable;

        public Int32 Count
        {
            get
            {
                return this._jobTaskTable.Count;
            }
        }

        public JobTask this[String taskName]
        {
            get
            {
                return this.TryGetValue(taskName);
            }
        }

        public JobTaskCollection()
        {
            this._jobTaskTable = new ConcurrentDictionary<String, JobTask>();
        }

        /// <summary>
        /// 尝试向集合中添加作业任务对象，无法添加名称相同的作业任务
        /// </summary>
        /// <param name="task">作业任务</param>
        /// <returns></returns>
        public Boolean TryAdd(JobTask task)
        {
            if (this.IsVaildJobTask(task))
            {
                return this._jobTaskTable.TryAdd(task.Name, task);
            }
            return false;
        }

        /// <summary>
        /// 尝试从集合中移除指定名称的作业任务
        /// </summary>
        /// <param name="taskName">作业任务的名称</param>
        /// <returns></returns>
        public Boolean TryRemove(String taskName)
        {
            if (String.IsNullOrEmpty(taskName)) return false;
            return this._jobTaskTable.TryRemove(taskName, out var jobTask);
        }

        /// <summary>
        /// 尝试获取指定名称的作业任务，若获取失败则返回 NULL
        /// </summary>
        /// <param name="taskName"></param>
        /// <returns>作业任务</returns>
        public JobTask TryGetValue(String taskName)
        {
            if (String.IsNullOrEmpty(taskName)) return null;
            this._jobTaskTable.TryGetValue(taskName, out var jobTask);
            return jobTask;
        }

        private Boolean IsVaildJobTask(JobTask task)
        {
            if (task == null) return false;
            if (String.IsNullOrEmpty(task.Name)) return false;
            if (this._jobTaskTable.ContainsKey(task.Name))
            {
                return false;
            }
            return true;
        }

        public IEnumerator<JobTask> GetEnumerator()
        {
            return this._jobTaskTable.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._jobTaskTable.Values.GetEnumerator();
        }
    }
}
