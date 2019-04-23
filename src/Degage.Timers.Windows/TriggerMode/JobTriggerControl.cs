using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Degage.Timers.Windows
{
    public partial class JobTriggerControl : BaseControl
    {
        public String TriggerMode { get; private set; }
        public JobTriggerControl()
        {
            InitializeComponent();
        }

        private void _btnEditTimingMode_Click(Object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(this.TriggerMode))
            //{
            //    return;
            //}
            JobTriggerModeEditForm modeEditForm = new JobTriggerModeEditForm(this.TriggerMode);
            modeEditForm.ShowDialog();
        }
    }
}
