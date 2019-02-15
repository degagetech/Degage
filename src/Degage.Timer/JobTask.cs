using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.Timer
{
    /// <summary>
    /// 作业任务
    /// </summary>
    public class JobTask
    {
        /// <summary>
        /// 任务的名称
        /// </summary>
        public String Name { get; }

        /// <summary>
        /// 任务的描述
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// 任务参数
        /// </summary>
        public String TaskArgs { get; }

        /// <summary>
        /// 作业执行的超时时间（单位：秒）
        /// </summary>
        public Int32 JobRunTimeout { get; }

        /// <summary>
        /// 调度模式
        /// </summary>
        public ScheduleMode ScheduleMode { get; }

        /// <summary>
        /// 此任务关联的作业对象的类型
        ///</summary>
        public Type JobObjectType { get; }

        /// <summary>
        /// 此作业任务拥有的触发器的集合
        /// </summary>
        public JobTriggerCollection Triggers { get; }

        /// <summary>
        /// 作业环境
        /// </summary>
        public JobEnvironment Environment { get; }


        public JobTask(Type jobObjectType)
        {
            this.Triggers = new JobTriggerCollection();

            if (!jobObjectType.IsSubclassOf(typeof(JobObject)))
            {
                throw new ArgumentException(nameof(jobObjectType));
            }
            this.JobObjectType = jobObjectType;


        }

        public void AddTrigger(JobTrigger trigger)
        {
            if (this.Triggers.TryAdd(trigger))
            {
                //
            }
        }

    }
}
