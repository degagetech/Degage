using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Degage.DataModel.Schema.Toolbox
{
    public partial class BaseForm : Form
    {
        public Boolean BusyingFlag { get; private set; }

        public void EnterBusyingState()
        {
            this.BusyingFlag = true;
            this.Cursor = Cursors.WaitCursor;
        }
        public void LeaveBusyingState()
        {
            this.BusyingFlag = false;
            this.Cursor = Cursors.Default;
        }
        public Boolean IsBusyingState(Boolean isTip = false)
        {
            if (this.BusyingFlag && isTip)
            {
                MessageBox.Show(this, "系统当前正忙...", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return BusyingFlag;
        }
        public BaseForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 因确认操作而执行的窗体关闭
        /// </summary>
        protected void ConfirmClose()
        {
            if (this.Modal)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.Close();
            }
        }
        /// <summary>
        /// 因取消操作而执行的窗体关闭
        /// </summary>
        protected void CancelClose()
        {
            if (this.Modal)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                this.Close();
            }
        }
    }
}
