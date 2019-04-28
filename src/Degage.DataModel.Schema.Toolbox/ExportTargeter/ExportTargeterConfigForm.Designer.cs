namespace Degage.DataModel.Schema.Toolbox
{
    partial class ExportTargeterConfigForm
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
            this._btnConfirm = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._plContainer = new System.Windows.Forms.Panel();
            this.line1 = new Degage.DataModel.Schema.Toolbox.Line();
            this.SuspendLayout();
            // 
            // _btnConfirm
            // 
            this._btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnConfirm.Location = new System.Drawing.Point(182, 92);
            this._btnConfirm.Name = "_btnConfirm";
            this._btnConfirm.Size = new System.Drawing.Size(70, 30);
            this._btnConfirm.TabIndex = 20;
            this._btnConfirm.Text = "确定";
            this._btnConfirm.UseVisualStyleBackColor = true;
            this._btnConfirm.Click += new System.EventHandler(this._btnConfirm_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCancel.Location = new System.Drawing.Point(263, 92);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(70, 30);
            this._btnCancel.TabIndex = 21;
            this._btnCancel.Text = "取消";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // _plContainer
            // 
            this._plContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._plContainer.AutoSize = true;
            this._plContainer.Location = new System.Drawing.Point(22, 12);
            this._plContainer.Name = "_plContainer";
            this._plContainer.Size = new System.Drawing.Size(304, 61);
            this._plContainer.TabIndex = 22;
            // 
            // line1
            // 
            this.line1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.line1.CustomBursh = null;
            this.line1.EnabledMousePierce = false;
            this.line1.IsVertical = false;
            this.line1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.line1.LineLength = 364;
            this.line1.LineWidth = 1;
            this.line1.Location = new System.Drawing.Point(0, 84);
            this.line1.Margin = new System.Windows.Forms.Padding(0);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(364, 1);
            this.line1.TabIndex = 23;
            this.line1.Text = "line1";
            this.line1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExportTargeterConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(348, 128);
            this.Controls.Add(this.line1);
            this.Controls.Add(this._plContainer);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnConfirm);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportTargeterConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "导出定向配置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExportTargeterConfigForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnConfirm;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Panel _plContainer;
        private Line line1;
    }
}