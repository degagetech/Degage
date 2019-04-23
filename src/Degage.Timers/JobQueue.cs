using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Concurrent;
namespace Degage.Timers
{
    /// <summary>
    /// 用于存取 <see cref="Job"/> 对象，并提供对 FIFO 模式的支持
    /// </summary>
    public class JobQueue
    {
        /// <summary>
        /// 作业队列的容量
        /// </summary>
        public Int32 Capacity { get; }

        /// <summary>
        /// 获取队列中当前 <see cref="Job"/> 对象的数量
        /// </summary>
        public Int32 Count
        {
            get
            {
                return this._storageQueue.Count;
            }
        }

        private ConcurrentQueue<Job> _storageQueue;

        /// <summary>
        /// 初始化 <see cref="JobQueue"/> 类的新实例
        /// </summary>
        public JobQueue()
        {
            this._storageQueue = new ConcurrentQueue<Job>();
        }

        /// <summary>
        /// 将指定的 <see cref="Job"/> 对象添加到队列的末尾
        /// </summary>
        /// <remarks>此方法是线程安全的</remarks>
        /// <param name="job">作业对象</param>
        public void Enqueue(Job job)
        {
            this._storageQueue.Enqueue(job);
        }

        /// <summary>
        /// 返回并移除队列开头的 <see cref="Job"/> 对象，若操作失败，则返回空。
        /// </summary>
        /// <remarks>此方法是线程安全的</remarks>
        /// <returns></returns>
        public Job Dequeue()
        {
            Job job = null;
            this._storageQueue.TryDequeue(out job);
            return job;
        }


        /// <summary>
        /// 返回但不移除队列开头的 <see cref="Job"/> 对象，若操作失败，则返回空。
        /// </summary>
        /// <remarks>此方法是线程安全的</remarks>
        /// <returns></returns>
        public Job Peek()
        {
            Job job = null;
            this._storageQueue.TryPeek(out job);
            return job;
        }
    }
}
