namespace WorkPerformance
{
    partial class WaitingForm
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
            this._plContainer = new WorkPerformance.PenetrablePanel();
            this._pbLoading = new System.Windows.Forms.PictureBox();
            this._lblTipInfo = new System.Windows.Forms.Label();
            this._plContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pbLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // _plContainer
            // 
            this._plContainer.Controls.Add(this._pbLoading);
            this._plContainer.Controls.Add(this._lblTipInfo);
            this._plContainer.EnabledMousePierce = false;
            this._plContainer.Location = new System.Drawing.Point(86, 64);
            this._plContainer.Name = "_plContainer";
            this._plContainer.Size = new System.Drawing.Size(434, 275);
            this._plContainer.TabIndex = 6;
            // 
            // _pbLoading
            // 
            this._pbLoading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this._pbLoading.Image = global::WorkPerformance.Properties.Resources.Loading;
            this._pbLoading.Location = new System.Drawing.Point(85, 17);
            this._pbLoading.Name = "_pbLoading";
            this._pbLoading.Size = new System.Drawing.Size(260, 170);
            this._pbLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._pbLoading.TabIndex = 4;
            this._pbLoading.TabStop = false;
            // 
            // _lblTipInfo
            // 
            this._lblTipInfo.AutoEllipsis = true;
            this._lblTipInfo.BackColor = System.Drawing.Color.Transparent;
            this._lblTipInfo.Font = new System.Drawing.Font("微软雅黑 Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._lblTipInfo.ForeColor = System.Drawing.Color.White;
            this._lblTipInfo.Location = new System.Drawing.Point(22, 203);
            this._lblTipInfo.Name = "_lblTipInfo";
            this._lblTipInfo.Size = new System.Drawing.Size(399, 27);
            this._lblTipInfo.TabIndex = 5;
            this._lblTipInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WaitingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this._plContainer);
            this.MinimumSize = new System.Drawing.Size(260, 170);
            this.Name = "WaitingForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "请稍后";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Resize += new System.EventHandler(this.WaitingForm_Resize);
            this._plContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._pbLoading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox _pbLoading;
        private System.Windows.Forms.Label _lblTipInfo;
        private PenetrablePanel _plContainer;
    }
}