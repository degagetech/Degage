using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Degage.DataModel.Schema.Toolbox
{
    public partial class ExportTargeterConfigForm : BaseForm
    {
        private BaseExportTargeterControl _configControl;
        public ExportTargeterConfigForm()
        {
            InitializeComponent();
        }

        public ExportTargeterConfigForm(BaseExportTargeterControl configCtl) : this()
        {
            _configControl = configCtl;
            this._plContainer.Controls.Add(configCtl);
        }

        private void _btnConfirm_Click(Object sender, EventArgs e)
        {
            var ctl = this._plContainer.Controls[0] as BaseExportTargeterControl;
            var result = ctl.VerifyTargeterSetting();
            if (!result.isValid)
            {
                MessageBox.Show(result.message, "设置错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.ConfirmClose();
        }

        private void _btnCancel_Click(Object sender, EventArgs e)
        {
            this.CancelClose();
        }

        private void ExportTargeterConfigForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            _configControl = null;
            this._plContainer.Controls.Remove(_configControl);
        }
    }
}
