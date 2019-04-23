namespace Degage.ToolBox.Pdf
{
    partial class ImageControl
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
            this._pbImage = new System.Windows.Forms.PictureBox();
            this._lblFileName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // _pbImage
            // 
            this._pbImage.Location = new System.Drawing.Point(27, 20);
            this._pbImage.Name = "_pbImage";
            this._pbImage.Size = new System.Drawing.Size(119, 107);
            this._pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._pbImage.TabIndex = 0;
            this._pbImage.TabStop = false;
            // 
            // _lblFileName
            // 
            this._lblFileName.AutoEllipsis = true;
            this._lblFileName.Font = new System.Drawing.Font("微软雅黑 Light", 12F);
            this._lblFileName.ForeColor = System.Drawing.Color.White;
            this._lblFileName.Location = new System.Drawing.Point(11, 136);
            this._lblFileName.Name = "_lblFileName";
            this._lblFileName.Size = new System.Drawing.Size(149, 38);
            this._lblFileName.TabIndex = 12;
            this._lblFileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ImageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.Controls.Add(this._lblFileName);
            this.Controls.Add(this._pbImage);
            this.Font = new System.Drawing.Font("微软雅黑 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ImageControl";
            this.Size = new System.Drawing.Size(175, 187);
            ((System.ComponentModel.ISupportInitialize)(this._pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox _pbImage;
        private System.Windows.Forms.Label _lblFileName;
    }
}
