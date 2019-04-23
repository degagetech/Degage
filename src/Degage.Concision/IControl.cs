using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace Degage.Concision
{
    /// <summary>
    /// 定义控件的基础功能接口
    /// </summary>
    public interface IControl
    {
        String Text { get; set; }
        /// <summary>
        /// 控件所处父容器的位置
        /// </summary>
        Point Postition { get; set; }
    }
}
