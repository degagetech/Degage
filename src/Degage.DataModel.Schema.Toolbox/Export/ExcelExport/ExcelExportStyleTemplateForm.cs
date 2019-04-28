using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Degage.DataModel.Schema.Toolbox
{
    public partial class ExcelExportStyleTemplateForm : BaseForm
    {
        public ExcelExportTemplateConfig ExcelExportTemplateConfig { get; private set; }
        public ItemEditMode EditMode { get; private set; } = ItemEditMode.None;
        public ExcelExportTemplateItem CurrentItem { get; set; }
        public List<ExcelExportTemplateItem> TemplateItems { get; set; } = new List<ExcelExportTemplateItem>();
        public ExcelSchemaExporter SchemaExporter { get; private set; }
        public List<String> AutoFillFileNames { get; private set; } = new List<String>();
        public ExcelExportStyleTemplateForm(List<ExcelExportTemplateItem> templateItems, ExcelSchemaExporter exporter) : this()
        {
            this.SchemaExporter = exporter;
            this._colName.DataPropertyName = nameof(ExcelExportTemplateItem.Name);
            this._colStyleTemplatePath.DataPropertyName = nameof(ExcelExportTemplateItem.Path);
            this.TemplateItems = templateItems;
            this._dgvExcelExportStyleTemplate.DataSource = this.TemplateItems;
            this._tbTemplatePath.PreviewKeyDown += _tbTemplatePath_PreviewKeyDown;
            this.Shown += ExcelExportStyleTemplateForm_Shown;
        }

        private void _tbTemplatePath_PreviewKeyDown(Object sender, PreviewKeyDownEventArgs e)
        {
            //用户按下 Tab 键后，判断用户可能需要填写信息，并自动填入
            if (e.KeyData == Keys.Tab)
            {
                String newFileName = this._tbTemplatePath.Text.Trim().ToLower();
                foreach (var name in this.AutoFillFileNames)
                {
                    var exsitedFileName = name.ToLower();
                    if (exsitedFileName.StartsWith(newFileName))
                    {
                        this._tbTemplatePath.Text = name;
                    }
                }
                e.IsInputKey = true;
            }
        }

        private async void ExcelExportStyleTemplateForm_Shown(Object sender, EventArgs e)
        {
            var fileNames = await Task.Run(() =>
               {
                   return Directory.GetFiles(this.SchemaExporter.ExcelExportTemplateDirectory, "*.xlsx");
               });
            this.AutoFillFileNames = new List<String>(fileNames.Select(t => Path.GetFileName(t)));
        }



        public ExcelExportStyleTemplateForm()
        {
            InitializeComponent();
            if (!this.DesignMode)
            {
                this._plItemEdit.Enabled = false;
            }
        }

        private void _btnConfirm_Click(Object sender, EventArgs e)
        {
            this.ConfirmClose();
        }

        private void _btnCancel_Click(Object sender, EventArgs e)
        {
            this.CancelClose();
        }

        private void _btnItemAdd_Click(Object sender, EventArgs e)
        {
            this.EnableEditState(true);
            this.EditMode = ItemEditMode.Add;
            this.CurrentItem = new ExcelExportTemplateItem();
            this.RenderItemInfo(this.CurrentItem);
        }

        private void _btnItemEdit_Click(Object sender, EventArgs e)
        {
            this.EnableEditState(true);
            this.EditMode = ItemEditMode.Edit;
        }

        private void _btnItemRemove_Click(Object sender, EventArgs e)
        {
            var item = this._dgvExcelExportStyleTemplate.GetSelectedRowModel<ExcelExportTemplateItem>();
            this.TemplateItems.Remove(item);
            this.RefreshDataVeiw();
            this.RenderItemInfo(null);
        }

        private void _btnOperationCancel_Click(Object sender, EventArgs e)
        {
            this.EnableEditState(false);
        }
        private void RenderItemInfo(ExcelExportTemplateItem item)
        {
            if (item == null)
            {
                this._tbTemplateName.Text = null;
                this._tbTemplatePath.Text = null;
            }
            else
            {
                this._tbTemplateName.Text = item.Name;
                this._tbTemplatePath.Text = item.Path;
            }

        }
        private void _dgvExcelExportStyleTemplate_SelectionChanged(Object sender, EventArgs e)
        {
            var item = this._dgvExcelExportStyleTemplate.GetSelectedRowModel<ExcelExportTemplateItem>();
            if (item != null)
            {
                this.RenderItemInfo(item);
            }
            this.CurrentItem = item;
        }
        private void EnableEditState(Boolean enable = true)
        {
            this._btnItemAdd.Enabled = !enable;
            this._btnItemEdit.Enabled = !enable;
            this._btnItemRemove.Enabled = !enable;
            this._dgvExcelExportStyleTemplate.Enabled = !enable;
            this._plItemEdit.Enabled = enable;
        }
        private void RefreshDataVeiw()
        {

            this._dgvExcelExportStyleTemplate.DataSource = null;
            this._dgvExcelExportStyleTemplate.DataSource = this.TemplateItems;
        }
        private void _btnSave_Click(Object sender, EventArgs e)
        {
            ExcelExportTemplateItem item = this.CurrentItem;
            switch (this.EditMode)
            {
                case ItemEditMode.Add:
                    {
                        item.Name = this._tbTemplateName.Text.Trim();
                        item.Path = this._tbTemplatePath.Text.Trim();
                        this.TemplateItems.Add(item);
                    }
                    break;
                case ItemEditMode.Edit:
                    {
                        item.Name = this._tbTemplateName.Text.Trim();
                        item.Path = this._tbTemplatePath.Text.Trim();
                    }
                    break;
            }
            this.RefreshDataVeiw();
            this.EnableEditState(false);


        }

        private void _btnImport_Click(Object sender, EventArgs e)
        {
            var result = this._dialogOpenFile.ShowDialog();
            if (result != DialogResult.OK) return;
            String filePath = this._dialogOpenFile.FileName;
            String fileName = Path.GetFileName(filePath);
            String directory = this.SchemaExporter.ExcelExportTemplateDirectory;
            String destPath = Path.Combine(directory, fileName);
            if (File.Exists(destPath))
            {
                MessageBox.Show("系统已存在相同名称模板文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                File.Copy(filePath, destPath);
                this._tbTemplatePath.Text = fileName;
            }
        }
    }
}
