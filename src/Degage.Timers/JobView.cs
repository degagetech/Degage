using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.Timers
{
    /// <summary>
    /// 提供对作业细节的展示功能
    /// </summary>
    public abstract class JobView : MarshalByRefObject
    {
        /// <summary>
        ///向作业视图中添加一个用于表示文本的控件
        /// </summary>
        /// <param name="id">控件标识，唯一</param>
        /// <param name="text">文本信息</param>
        public abstract void AddLabel(String id, String text);
        /// <summary>
        /// 从作业视图中移除指定 id 的视图控件
        /// </summary>
        /// <param name="id">控件标识，唯一</param>
        public abstract void Remove(String id);
        /// <summary>
        ///绘制作业视图中指定 id 的文本控件的文本信息
        /// </summary>
        /// <param name="id">控件标识，唯一</param>
        /// <param name="text">文本信息</param>
        public abstract void DrawLabelText(String id, String text);
    }

}
