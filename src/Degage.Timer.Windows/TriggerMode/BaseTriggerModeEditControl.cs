using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Degage.Timer.Windows
{
    public partial class BaseTriggerModeEditControl : BaseControl
    {
        /// <summary>
        /// 获取当前控件所表示的触发模式
        /// </summary>
        public String TriggerModel { get; protected set; }
        public BaseTriggerModeEditControl()
        {
            InitializeComponent();
        }
    }
}
