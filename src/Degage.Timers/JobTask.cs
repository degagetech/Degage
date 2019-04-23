using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
#if NETSTANDARD2_0
using System.Runtime.Loader;
#endif

namespace Degage.Timers
{
    /// <summary>
    /// 作业任务
    /// </summary>
    public class JobTask : IDisposable
    {
        /// <summary>
        /// 触发一次作业操作时
        /// </summary>
        public Action<Object, JobTriggeredEventArgs> JobTriggered;
        /// <summary>
        /// 当一次作业操作执行完成时
        /// </summary>
        public Action<Object, JobExecuteCompletedEventArgs> JobExecuteCompleted;

        /// <summary>
        /// 任务的名称
        /// </summary>
        public String Name { get; private set; }

        /// <summary>
        /// 任务的描述
        /// </summary>
        public String Description { get; internal set; }

        /// <summary>
        /// 任务参数
        /// </summary>
        public String TaskArgs { get; internal set; }

        /// <summary>
        /// 作业执行的超时时间（单位：秒）
        /// </summary>
        public Int32 JobRunTimeout { get; private set; }

        /// <summary>
        /// 作业任务触发的次数
        /// </summary>
        public Int32 JobTriggedCount { get; private set; }

        /// <summary>
        /// 作业任务当前的状态
        /// </summary>
        public JobTaskState JobTaskState { get; private set; }

        /// <summary>
        /// 调度模式
        /// </summary>
        public ScheduleMode ScheduleMode { get; internal set; }

        /// <summary>
        /// 当前关联的作业作业执行器的类型
        ///</summary>
        public Type JobExecutorType { get; private set; }

        /// <summary>
        /// 作业任务拥有的触发器的集合
        /// </summary>
        public JobTriggerCollection Triggers { get; private set; }

        /// <summary>
        /// 与此作业任务关联的作业环境，此作业环境通常与 <see cref="JobHost"/> 有关
        /// </summary>
        public JobEnvironment Environment { get; internal set; }

        /// <summary>
        /// 作业任务当前使用的执行环境
        /// </summary>
        public JobExecuteEnvironment ExecuteEnvironment { get; internal set; }

        /// <summary>
        /// 作业任务使用触发模式匹配器
        /// </summary>
        public IJobTriggerModeMacther TriggerModeMatcher { get; internal set; }

        /// <summary>
        /// 当 <see cref="JobTask"/> 对象的调度模式处于 <see cref="ScheduleMode.Parallel"/> 时，此属性决定最大的同时执行的作业数量
        /// </summary>
        /// <remarks>设置后，属性将在下一次调度时生效</remarks>
        public Int32 MaximumParallel { get; set; }
        /// <summary>
        /// 当前用于执行任务的对象
        /// </summary>
        public JobExecutor Executor { get; private set; }

        /// <summary>
        /// 最后一次执行任务调度的时间，此处的时间为作业时钟生成的时间，而不是设备时间
        /// </summary>
        public DateTime? LastScheduleTime { get; private set; }
        /// <summary>
        /// 作业任务的作业队列
        /// </summary>
        public JobQueue JobQueue { get; private set; }

        public TaskScheduler Scheduler { get; private set; }
        /// <summary>
        /// 用于触发器状态的同步对象
        /// </summary>
        private readonly Object _triggerStateSyncObj = new Object();

        private CancellationTokenSource TokenSource { get; set; }


        /// <summary>
        /// 初始化 <see cref="JobTask"/> 类的实例
        /// </summary>
        public JobTask()
        {
            this.Triggers = new JobTriggerCollection();
            this.JobQueue = new JobQueue();
        }


        /// <summary>
        ///  使用程序集以及类型完全限定名称信息初始化 <see cref="JobTask"/> 实例
        /// </summary>
        ///<exception cref="FileNotFoundException">未能通过路径找到程序集文件时</exception>
        /// <param name="assemblyPath">程序集的路径</param>
        /// <param name="typeName">类型名称</param>
        public JobTask(String assemblyPath, String typeName) : this()
        {
            if (!File.Exists(assemblyPath))
            {
                throw new FileNotFoundException(nameof(assemblyPath));
            }
            Byte[] rawAssembly = File.ReadAllBytes(assemblyPath);
            var jobAssembly = Assembly.ReflectionOnlyLoad(rawAssembly);
            var jobObjectType = jobAssembly.GetType(typeName);
            rawAssembly = null;
            this.SwitchJobExecutorType(jobObjectType);
        }

        /// <summary>
        /// 使用指定作业对象的类型信息初始化 <see cref="JobTask"/> 类型实例
        /// </summary>
        /// <param name="jobExecutorType"></param>
        public JobTask(Type jobExecutorType) : this()
        {
            this.SwitchJobExecutorType(jobExecutorType);
        }

        /// <summary>
        /// 切换任务的作业执行对象的类型
        /// </summary>
        /// <exception cref="JobTaskStateInvaildException">对象状态处于 <see cref="JobTaskState.Running"/> 时</exception>
        /// <exception cref="JobExecutorTypeInvaildException">传入参数的类型不属于 <see cref="JobExecutor"/> 类的派生类时</exception>
        /// <exception cref="ArgumentNullException">传入参数的类型对象为空时</exception>
        /// <remarks>
        /// 当作业执行对象的类型与当前的相同时，此方法不会执行任何操作
        /// </remarks>
        /// <param name="jobExecutorType">作业执行对象的类型</param>
        public void SwitchJobExecutorType(Type jobExecutorType)
        {
            if (this.JobTaskState == JobTaskState.Running)
            {
                throw new JobTaskStateInvaildException();
            }
            if (jobExecutorType == null)
            {
                throw new ArgumentNullException(nameof(jobExecutorType));
            }
            if (!jobExecutorType.IsSubclassOf(typeof(JobExecutor)))
            {
                throw new JobExecutorTypeInvaildException(nameof(jobExecutorType));
            }

            this.JobExecutorType = jobExecutorType;
        }

        /// <summary>
        /// 作业调度操作
        /// </summary>
        private void Scheduling(DateTime clockTime)
        {
            this.LastScheduleTime = clockTime;
            //使用时钟时间匹配触发模式，生成相应数量的作业
            var jobs = this.GenerateJobs(clockTime);

            //添加作业至队列中排队
            foreach (var job in jobs)
            {
                this.JobQueue.Enqueue(job);
            }

            while (this.JobQueue.Count > 0)
            {
                var job = this.JobQueue.Dequeue();
                if (job == null) return;
                switch (this.ScheduleMode)
                {
                    case ScheduleMode.Ignore:
                        {
                            job.JobResult.ResultType = JobResultType.Ignore;
                        }
                        break;
                    case ScheduleMode.Queue:
                        {
                              
                        }
                        break;
                    case ScheduleMode.Parallel:
                        {
                               
                        }
                        break;
                }
            }


            //根据当前的调度模式判断是否将作业加入到队列中
            //根据当前的调度模式依次执行队列中的作业操作
        }

        /// <summary>
        /// 通过当前任务设置的触发器以及时钟时间，生成需要作业的集合，此函数会修改触发器的状态
        /// </summary>
        /// <param name="clockTime">时钟时间</param>
        /// <returns>若无则返回一个元素个数为零的链表</returns>
        private List<Job> GenerateJobs(DateTime clockTime)
        {
            List<Job> jobs = new List<Job>();

            //TODO:作业任务调度时，对时钟时间进行作业触发的匹配流程需要优化
            if (this.Triggers.Count > 0)
            {
                foreach (var trigger in this.Triggers)
                {
                    var result = this.TriggerModeMatcher.Match(clockTime, trigger.TriggerMode);
                    switch (result.ResultType)
                    {
                        case TriggerModeMatchResultType.Matched:
                            {
                                Job job = new Job
                                {
                                    Name = this.Name,
                                    TriggerMode = trigger.TriggerMode,
                                    TriggeTime = clockTime,
                                    JobResult = new JobResult
                                    {
                                        ResultType = JobResultType.NonExecution
                                    }
                                };
                                jobs.Add(job);
                                lock (_triggerStateSyncObj)
                                {
                                    trigger.LastTiggeredTime = clockTime;
                                    trigger.TiggeredCount++;
                                }
                            }
                            break;
                    }
                }
            }

            return jobs;
        }

        /// <summary>
        /// 执行任务的调度操作
        /// </summary>
        /// <param name="clockTime">时钟时间</param>
        public void SchedulingLauncher(DateTime clockTime)
        {
            if (this.JobTaskState == JobTaskState.Running)
            {
                Task task = new Task(() =>
                {
                    this.Scheduling(clockTime);
                });
                task.Start();
            }
        }
        /// <summary>
        /// 创建用于作业的执行环境，并开始对处理作业的调度
        /// </summary>
        public void Start()
        {
            //释放上一次运行的执行环境
            this.ReleaseExecuteEnvironment();
            this.AllocateExecuteEnvironment();
            this.JobTaskState = JobTaskState.Running;

            //运行后立即执行一次调度
        }
        /// <summary>
        /// 分配作业执行的环境，并创建作业执行的对象
        /// </summary>
        private void AllocateExecuteEnvironment()
        {
            this.ExecuteEnvironment = new JobExecuteEnvironment(this.Name);
            this.Executor = this.ExecuteEnvironment.CreateExecutor(this.JobExecutorType);
        }
        /// <summary>
        /// 释放用于作业的执行环境，并停止对作业处理的调度
        /// </summary>
        public void Stop()
        {
            this.JobTaskState = JobTaskState.Stopped;
            this.ReleaseExecuteEnvironment();
        }

        /// <summary>
        /// 释放作业执行的环境
        /// </summary>
        private void ReleaseExecuteEnvironment()
        {
            this.ExecuteEnvironment?.Dispose();
            this.ExecuteEnvironment = null;

            this.Executor?.Dispose();
            this.Executor = null;

            this.TokenSource?.Dispose();
            this.TokenSource = null;
        }

        /// <summary>
        /// 释放作业任务使用的资源
        /// </summary>
        public void Dispose()
        {
            this.ReleaseExecuteEnvironment();
        }

    }
}
