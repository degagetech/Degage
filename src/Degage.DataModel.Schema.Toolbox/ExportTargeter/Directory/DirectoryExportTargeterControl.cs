using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace Degage.DataModel.Schema.Toolbox
{

    public partial class DirectoryExportTargeterControl : BaseExportTargeterControl
    {
        protected DirectoryExportTargeter DirectoryExportTargeter { get; set; }
        public DirectoryExportTargeterControl()
        {
            InitializeComponent();

            this.DirectoryExportTargeter = new DirectoryExportTargeter();
            this.ExportTargeter = this.DirectoryExportTargeter;
            this.Load += DirectoryExportTargeterControl_Load;
        }

        private void DirectoryExportTargeterControl_Load(Object sender, EventArgs e)
        {
            this._fbdExportDirectory.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        private void _btnSelectdExportDirectory_Click(Object sender, EventArgs e)
        {
            var result = _fbdExportDirectory.ShowDialog();
            if (result == DialogResult.OK)
            {
                this._tbExportDirectory.Text = this._fbdExportDirectory.SelectedPath;
            }
        }
        public override (Boolean isValid, String message) VerifyTargeterSetting()
        {
            Boolean isvalid = false;
            String message = null;
            String directory = this._tbExportDirectory.Text;
            if (Directory.Exists(directory))
            {
                isvalid = true;
                this.DirectoryExportTargeter.TargetDirectory = directory;
            }
            else
            {
                message = "指定的导出目录不存在！";
            }

            return (isvalid, message);
        }
    }
}
