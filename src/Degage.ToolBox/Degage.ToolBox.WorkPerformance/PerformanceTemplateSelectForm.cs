using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkPerformance
{
    public partial class PerformanceTemplateSelectForm : BaseForm
    {
        public PerformanceTemplateInfo SelectedPerformanceTemplateInfo
        {
            get; private set;
        }
        public PerformanceTemplateSelectForm()
        {
            InitializeComponent();
            this._lbPerformanceTemplate.SelectedIndexChanged += _lbPerformanceTemplate_SelectedIndexChanged;
        }
        public PerformanceTemplateSelectForm(List<PerformanceTemplateInfo> templateInfos) : this()
        {
            this._lbPerformanceTemplate.ShowPerformanceTemplateInfo(templateInfos);
        }
        private void _lbPerformanceTemplate_SelectedIndexChanged(Object sender, EventArgs e)
        {
            this.SelectedPerformanceTemplateInfo = this._lbPerformanceTemplate.SelectedPerformanceTemplateInfo;
        }

        private void _btnConfirm_Click(Object sender, EventArgs e)
        {
            if (this.SelectedPerformanceTemplateInfo == null || !this.SelectedPerformanceTemplateInfo.IsExistedTemplateFile)
            {
                return;
            }
            this.ConfirmClose();
        }

        private void _btnCancel_Click(Object sender, EventArgs e)
        {
            this.CancelClose();
        }
    }
}
