namespace Degage.DataModel.Schema.Toolbox
{
    partial class ExcelExportStyleTemplateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this._dgvExcelExportStyleTemplate = new System.Windows.Forms.DataGridView();
            this._colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colStyleTemplatePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnConfirm = new System.Windows.Forms.Button();
            this._btnItemAdd = new System.Windows.Forms.Button();
            this._btnItemEdit = new System.Windows.Forms.Button();
            this._btnItemRemove = new System.Windows.Forms.Button();
            this._plItemEdit = new System.Windows.Forms.Panel();
            this._tbTemplatePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._tbTemplateName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._btnOperationCancel = new System.Windows.Forms.Button();
            this._btnSave = new System.Windows.Forms.Button();
            this._toolTip = new System.Windows.Forms.ToolTip(this.components);
            this._btnImport = new System.Windows.Forms.Button();
            this._dialogOpenFile = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this._dgvExcelExportStyleTemplate)).BeginInit();
            this._plItemEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dgvExcelExportStyleTemplate
            // 
            this._dgvExcelExportStyleTemplate.AllowUserToAddRows = false;
            this._dgvExcelExportStyleTemplate.AllowUserToDeleteRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._dgvExcelExportStyleTemplate.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this._dgvExcelExportStyleTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvExcelExportStyleTemplate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgvExcelExportStyleTemplate.BackgroundColor = System.Drawing.Color.White;
            this._dgvExcelExportStyleTemplate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._dgvExcelExportStyleTemplate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._colName,
            this._colStyleTemplatePath});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvExcelExportStyleTemplate.DefaultCellStyle = dataGridViewCellStyle12;
            this._dgvExcelExportStyleTemplate.Location = new System.Drawing.Point(12, 12);
            this._dgvExcelExportStyleTemplate.Name = "_dgvExcelExportStyleTemplate";
            this._dgvExcelExportStyleTemplate.ReadOnly = true;
            this._dgvExcelExportStyleTemplate.RowHeadersVisible = false;
            this._dgvExcelExportStyleTemplate.RowTemplate.Height = 23;
            this._dgvExcelExportStyleTemplate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvExcelExportStyleTemplate.Size = new System.Drawing.Size(604, 286);
            this._dgvExcelExportStyleTemplate.TabIndex = 8;
            this._dgvExcelExportStyleTemplate.SelectionChanged += new System.EventHandler(this._dgvExcelExportStyleTemplate_SelectionChanged);
            // 
            // _colName
            // 
            this._colName.HeaderText = "模板名称";
            this._colName.Name = "_colName";
            this._colName.ReadOnly = true;
            // 
            // _colStyleTemplatePath
            // 
            this._colStyleTemplatePath.HeaderText = "样式模板路径（相对）";
            this._colStyleTemplatePath.Name = "_colStyleTemplatePath";
            this._colStyleTemplatePath.ReadOnly = true;
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCancel.Location = new System.Drawing.Point(546, 488);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(70, 30);
            this._btnCancel.TabIndex = 23;
            this._btnCancel.Text = "取消";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // _btnConfirm
            // 
            this._btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnConfirm.Location = new System.Drawing.Point(454, 488);
            this._btnConfirm.Name = "_btnConfirm";
            this._btnConfirm.Size = new System.Drawing.Size(70, 30);
            this._btnConfirm.TabIndex = 22;
            this._btnConfirm.Text = "确定";
            this._toolTip.SetToolTip(this._btnConfirm, "将您的更改保存到本地磁盘中");
            this._btnConfirm.UseVisualStyleBackColor = true;
            this._btnConfirm.Click += new System.EventHandler(this._btnConfirm_Click);
            // 
            // _btnItemAdd
            // 
            this._btnItemAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnItemAdd.FlatAppearance.BorderSize = 0;
            this._btnItemAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this._btnItemAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this._btnItemAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnItemAdd.Image = global::Degage.DataModel.Schema.Toolbox.Properties.Resources.add;
            this._btnItemAdd.Location = new System.Drawing.Point(12, 308);
            this._btnItemAdd.Name = "_btnItemAdd";
            this._btnItemAdd.Size = new System.Drawing.Size(35, 30);
            this._btnItemAdd.TabIndex = 24;
            this._btnItemAdd.UseVisualStyleBackColor = true;
            this._btnItemAdd.Click += new System.EventHandler(this._btnItemAdd_Click);
            // 
            // _btnItemEdit
            // 
            this._btnItemEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnItemEdit.FlatAppearance.BorderSize = 0;
            this._btnItemEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this._btnItemEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this._btnItemEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnItemEdit.Image = global::Degage.DataModel.Schema.Toolbox.Properties.Resources.edit;
            this._btnItemEdit.Location = new System.Drawing.Point(52, 308);
            this._btnItemEdit.Name = "_btnItemEdit";
            this._btnItemEdit.Size = new System.Drawing.Size(35, 30);
            this._btnItemEdit.TabIndex = 25;
            this._btnItemEdit.UseVisualStyleBackColor = true;
            this._btnItemEdit.Click += new System.EventHandler(this._btnItemEdit_Click);
            // 
            // _btnItemRemove
            // 
            this._btnItemRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnItemRemove.FlatAppearance.BorderSize = 0;
            this._btnItemRemove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this._btnItemRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this._btnItemRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnItemRemove.Image = global::Degage.DataModel.Schema.Toolbox.Properties.Resources.remove;
            this._btnItemRemove.Location = new System.Drawing.Point(92, 308);
            this._btnItemRemove.Name = "_btnItemRemove";
            this._btnItemRemove.Size = new System.Drawing.Size(35, 30);
            this._btnItemRemove.TabIndex = 26;
            this._btnItemRemove.UseVisualStyleBackColor = true;
            this._btnItemRemove.Click += new System.EventHandler(this._btnItemRemove_Click);
            // 
            // _plItemEdit
            // 
            this._plItemEdit.Controls.Add(this._btnImport);
            this._plItemEdit.Controls.Add(this._tbTemplatePath);
            this._plItemEdit.Controls.Add(this.label1);
            this._plItemEdit.Controls.Add(this._tbTemplateName);
            this._plItemEdit.Controls.Add(this.label2);
            this._plItemEdit.Controls.Add(this._btnOperationCancel);
            this._plItemEdit.Controls.Add(this._btnSave);
            this._plItemEdit.Location = new System.Drawing.Point(12, 344);
            this._plItemEdit.Name = "_plItemEdit";
            this._plItemEdit.Size = new System.Drawing.Size(604, 135);
            this._plItemEdit.TabIndex = 27;
            // 
            // _tbTemplatePath
            // 
            this._tbTemplatePath.Location = new System.Drawing.Point(78, 50);
            this._tbTemplatePath.Name = "_tbTemplatePath";
            this._tbTemplatePath.Size = new System.Drawing.Size(404, 23);
            this._tbTemplatePath.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "模板路径";
            // 
            // _tbTemplateName
            // 
            this._tbTemplateName.Location = new System.Drawing.Point(78, 12);
            this._tbTemplateName.Name = "_tbTemplateName";
            this._tbTemplateName.Size = new System.Drawing.Size(404, 23);
            this._tbTemplateName.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "模板名称";
            // 
            // _btnOperationCancel
            // 
            this._btnOperationCancel.Location = new System.Drawing.Point(85, 90);
            this._btnOperationCancel.Name = "_btnOperationCancel";
            this._btnOperationCancel.Size = new System.Drawing.Size(60, 28);
            this._btnOperationCancel.TabIndex = 25;
            this._btnOperationCancel.Text = "取消";
            this._btnOperationCancel.UseVisualStyleBackColor = true;
            this._btnOperationCancel.Click += new System.EventHandler(this._btnOperationCancel_Click);
            // 
            // _btnSave
            // 
            this._btnSave.Location = new System.Drawing.Point(17, 90);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(60, 28);
            this._btnSave.TabIndex = 24;
            this._btnSave.Text = "保存";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this._btnSave_Click);
            // 
            // _btnImport
            // 
            this._btnImport.Location = new System.Drawing.Point(503, 48);
            this._btnImport.Name = "_btnImport";
            this._btnImport.Size = new System.Drawing.Size(60, 28);
            this._btnImport.TabIndex = 30;
            this._btnImport.Text = "导入";
            this._toolTip.SetToolTip(this._btnImport, "您需要先将模板文件导入，系统才能找到您的模板文件");
            this._btnImport.UseVisualStyleBackColor = true;
            this._btnImport.Click += new System.EventHandler(this._btnImport_Click);
            // 
            // _dialogOpenFile
            // 
            this._dialogOpenFile.Filter = "Excel样式文件|*.xlsx";
            this._dialogOpenFile.Title = "选择导入的样式模板文件";
            // 
            // ExcelExportStyleTemplateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 528);
            this.Controls.Add(this._plItemEdit);
            this.Controls.Add(this._btnItemRemove);
            this.Controls.Add(this._btnItemEdit);
            this.Controls.Add(this._btnItemAdd);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnConfirm);
            this.Controls.Add(this._dgvExcelExportStyleTemplate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExcelExportStyleTemplateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Excel 导出样式模板设置";
            ((System.ComponentModel.ISupportInitialize)(this._dgvExcelExportStyleTemplate)).EndInit();
            this._plItemEdit.ResumeLayout(false);
            this._plItemEdit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _dgvExcelExportStyleTemplate;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnConfirm;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colStyleTemplatePath;
        private System.Windows.Forms.Button _btnItemAdd;
        private System.Windows.Forms.Button _btnItemEdit;
        private System.Windows.Forms.Button _btnItemRemove;
        private System.Windows.Forms.Panel _plItemEdit;
        private System.Windows.Forms.Button _btnOperationCancel;
        private System.Windows.Forms.Button _btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _tbTemplateName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _tbTemplatePath;
        private System.Windows.Forms.ToolTip _toolTip;
        private System.Windows.Forms.Button _btnImport;
        private System.Windows.Forms.OpenFileDialog _dialogOpenFile;
    }
}