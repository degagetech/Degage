namespace Degage.DataModel.Schema.Toolbox
{
    partial class DirectoryExportTargeterControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this._btnSelectdExportDirectory = new System.Windows.Forms.Button();
            this._tbExportDirectory = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._fbdExportDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // _btnSelectdExportDirectory
            // 
            this._btnSelectdExportDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnSelectdExportDirectory.Location = new System.Drawing.Point(19, 54);
            this._btnSelectdExportDirectory.Name = "_btnSelectdExportDirectory";
            this._btnSelectdExportDirectory.Size = new System.Drawing.Size(63, 26);
            this._btnSelectdExportDirectory.TabIndex = 28;
            this._btnSelectdExportDirectory.Text = "选择...";
            this._btnSelectdExportDirectory.UseVisualStyleBackColor = true;
            this._btnSelectdExportDirectory.Click += new System.EventHandler(this._btnSelectdExportDirectory_Click);
            // 
            // _tbExportDirectory
            // 
            this._tbExportDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._tbExportDirectory.BackColor = System.Drawing.Color.White;
            this._tbExportDirectory.Location = new System.Drawing.Point(81, 16);
            this._tbExportDirectory.Name = "_tbExportDirectory";
            this._tbExportDirectory.Size = new System.Drawing.Size(322, 23);
            this._tbExportDirectory.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 26;
            this.label5.Text = "导出目录";
            // 
            // _fbdExportDirectory
            // 
            this._fbdExportDirectory.Description = "选择导出路径";
            // 
            // DirectoryExportTargeterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._btnSelectdExportDirectory);
            this.Controls.Add(this._tbExportDirectory);
            this.Controls.Add(this.label5);
            this.Name = "DirectoryExportTargeterControl";
            this.Size = new System.Drawing.Size(428, 91);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnSelectdExportDirectory;
        private System.Windows.Forms.TextBox _tbExportDirectory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FolderBrowserDialog _fbdExportDirectory;
    }
}
