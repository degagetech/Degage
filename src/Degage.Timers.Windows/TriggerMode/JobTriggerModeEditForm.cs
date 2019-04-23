using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Degage.Timers.Windows
{
    public partial class JobTriggerModeEditForm : BaseForm
    {
        public String SecondTriggerMode { get; private set; }
        public String MinuteTriggerMode { get; private set; }
        public String HourTriggerMode { get; private set; }
        public String DayTriggerMode { get; private set; }
        public String MonthTriggerMode { get; private set; }
        public String YearTriggerMode { get; private set; }

        public JobTriggerModeEditForm()
        {
            InitializeComponent();
        }

        public JobTriggerModeEditForm(String triggerMode) : this()
        {
              //分离触发模式到各个位上
        }

        private void JobTriggerModeEditForm_Load(Object sender, EventArgs e)
        {
            //this._flpSecond.SuspendLayout();
            //Int32 count = 60;
            //CheckBox[] secondCheckBoxs = new CheckBox[count];
            //for (Int32 i = 0; i < count; ++i)
            //{
            //    secondCheckBoxs[i] = new CheckBox();
            //    secondCheckBoxs[i].Text = i.ToString();

            //    secondCheckBoxs[i].Margin = new Padding(0, 0, 0, 0);
            //    secondCheckBoxs[i].CheckedChanged += JobTriggerModeEditForm_CheckedChanged;
            //}

            //this._flpSecond.Controls.AddRange(secondCheckBoxs);
            //this._flpSecond.ResumeLayout();
        }

        private void SecondTriggerMode_CheckedChanged(Object sender, EventArgs e)
        {

        }
    }
}
