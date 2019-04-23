namespace WorkPerformance
{
    partial class PerformanceTemplateSelectForm
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
            this._lbPerformanceTemplate = new WorkPerformance.PerformanceTemplateListBox();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _lbPerformanceTemplate
            // 
            this._lbPerformanceTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this._lbPerformanceTemplate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._lbPerformanceTemplate.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this._lbPerformanceTemplate.ExistedTemplateFileImage = global::WorkPerformance.Properties.Resources.PerformanceTemplateFile;
            this._lbPerformanceTemplate.Font = new System.Drawing.Font("微软雅黑 Light", 12F);
            this._lbPerformanceTemplate.ForeColor = System.Drawing.Color.White;
            this._lbPerformanceTemplate.FormattingEnabled = true;
            this._lbPerformanceTemplate.ItemHeight = 30;
            this._lbPerformanceTemplate.Location = new System.Drawing.Point(57, 47);
            this._lbPerformanceTemplate.Margin = new System.Windows.Forms.Padding(0);
            this._lbPerformanceTemplate.Name = "_lbPerformanceTemplate";
            this._lbPerformanceTemplate.NotExistedTemplateFileImage = null;
            this._lbPerformanceTemplate.Size = new System.Drawing.Size(421, 336);
            this._lbPerformanceTemplate.TabIndex = 0;
            // 
            // _btnCancel
            // 
            this._btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnCancel.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._btnCancel.ForeColor = System.Drawing.Color.White;
            this._btnCancel.Location = new System.Drawing.Point(399, 408);
            this._btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 36);
            this._btnCancel.TabIndex = 6;
            this._btnCancel.Text = "取消";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // _btnConfirm
            // 
            this._btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnConfirm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._btnConfirm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._btnConfirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnConfirm.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._btnConfirm.ForeColor = System.Drawing.Color.White;
            this._btnConfirm.Location = new System.Drawing.Point(293, 408);
            this._btnConfirm.Margin = new System.Windows.Forms.Padding(0);
            this._btnConfirm.Name = "_btnConfirm";
            this._btnConfirm.Size = new System.Drawing.Size(75, 36);
            this._btnConfirm.TabIndex = 5;
            this._btnConfirm.Text = "确定";
            this._btnConfirm.UseVisualStyleBackColor = true;
            this._btnConfirm.Click += new System.EventHandler(this._btnConfirm_Click);
            // 
            // PerformanceTemplateSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.ClientSize = new System.Drawing.Size(536, 479);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnConfirm);
            this.Controls.Add(this._lbPerformanceTemplate);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "PerformanceTemplateSelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择绩效模板";
            this.ResumeLayout(false);

        }

        #endregion

        private PerformanceTemplateListBox _lbPerformanceTemplate;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnConfirm;
    }
}