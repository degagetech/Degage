using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Timers;
using System.Threading.Tasks;
namespace Degage.Timer
{
    public class JobClock
    {
        /// <summary>
        /// 当一秒钟时间过去时
        /// </summary>
        public event Action<Object, DateTime> SecondPassed;

        public System.Timers.Timer _secondPointer;

        /// <summary>
        /// 作业时钟当前的状态
        /// </summary>
        public JobClockState ClockState { get; private set; } = JobClockState.Stopped;

        /// <summary>
        /// 时钟当前所表示的时间
        /// </summary>
        public DateTime ClockTime
        {
            get
            {
                return this._clockTime;
            }
            set
            {
                if (this.ClockState == JobClockState.Running)
                {
                    throw new InvalidOperationException(TextRes.GetString("JobClock_WrongTiming"));
                }
                this._clockTime = value;
            }
        }
        private DateTime _clockTime;
        /// <summary>
        /// 使用指定的起始时间构造一个作业时钟对象
        /// </summary>
        /// <param name="start"></param>
        public JobClock(DateTime start) : this()
        {
            this.ClockTime = start;
        }

        /// <summary>
        /// 使用当前系统时间构造一个作业时钟对象
        /// </summary>
        public JobClock()
        {
            this._secondPointer = new System.Timers.Timer();
            this._secondPointer.Interval = 1000;
            this._secondPointer.Elapsed += _secondPointer_Elapsed;
            this.ClockTime = DateTime.Now;
        }

        private void _secondPointer_Elapsed(Object sender, ElapsedEventArgs e)
        {
            this.ClockTime.AddSeconds(1);
            Task task = new Task(this.OnSecondPassed);
            task.Start();
        }
        private void OnSecondPassed()
        {
            this.SecondPassed?.Invoke(this, this.ClockTime);
        }


        /// <summary>
        /// 启动时钟
        /// </summary>
        public void Start()
        {
            this._secondPointer.Start();
            this.ClockState = JobClockState.Running;
        }
        /// <summary>
        /// 停止时钟
        /// </summary>

        public void Stop()
        {
            this._secondPointer.Stop();
            this.ClockState = JobClockState.Stopped;
        }


    }
    /// <summary>
    /// 作业时钟的状态
    /// </summary>
    public enum JobClockState
    {
        /// <summary>
        /// 停止的
        /// </summary>
        Stopped,
        /// <summary>
        /// 正在转动
        /// </summary>
        Running
    }
}
