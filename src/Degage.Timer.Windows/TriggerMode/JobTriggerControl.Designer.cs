namespace Degage.Timer.Windows
{
    partial class JobTriggerControl
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
            this.textBox3 = new System.Windows.Forms.TextBox();
            this._btnEditTimingMode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(9, 7);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(492, 27);
            this.textBox3.TabIndex = 12;
            // 
            // _btnEditTimingMode
            // 
            this._btnEditTimingMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnEditTimingMode.BackColor = System.Drawing.Color.White;
            this._btnEditTimingMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnEditTimingMode.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._btnEditTimingMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnEditTimingMode.Image = global::Degage.Timer.Windows.Properties.Resources.edit_16x16;
            this._btnEditTimingMode.Location = new System.Drawing.Point(512, 6);
            this._btnEditTimingMode.Name = "_btnEditTimingMode";
            this._btnEditTimingMode.Size = new System.Drawing.Size(29, 29);
            this._btnEditTimingMode.TabIndex = 13;
            this._btnEditTimingMode.UseVisualStyleBackColor = false;
            this._btnEditTimingMode.Click += new System.EventHandler(this._btnEditTimingMode_Click);
            // 
            // JobTriggerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._btnEditTimingMode);
            this.Controls.Add(this.textBox3);
            this.Name = "JobTriggerControl";
            this.Size = new System.Drawing.Size(548, 40);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnEditTimingMode;
        private System.Windows.Forms.TextBox textBox3;
    }
}
