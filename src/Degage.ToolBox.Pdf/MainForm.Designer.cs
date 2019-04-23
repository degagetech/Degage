namespace Degage.ToolBox.Pdf
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._gbSelectedImages = new System.Windows.Forms.GroupBox();
            this._toolTip = new System.Windows.Forms.ToolTip(this.components);
            this._ofdSelectedImages = new System.Windows.Forms.OpenFileDialog();
            this._flpImageContainer = new System.Windows.Forms.FlowLayoutPanel();
            this._btnSelect = new System.Windows.Forms.Button();
            this._btnGenerate = new System.Windows.Forms.Button();
            this._sfSavePdf = new System.Windows.Forms.SaveFileDialog();
            this._btnClose = new System.Windows.Forms.Button();
            this._lblTipInfo = new System.Windows.Forms.Label();
            this._gbSelectedImages.SuspendLayout();
            this.SuspendLayout();
            // 
            // _gbSelectedImages
            // 
            this._gbSelectedImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._gbSelectedImages.Controls.Add(this._flpImageContainer);
            this._gbSelectedImages.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._gbSelectedImages.ForeColor = System.Drawing.Color.White;
            this._gbSelectedImages.Location = new System.Drawing.Point(21, 50);
            this._gbSelectedImages.Name = "_gbSelectedImages";
            this._gbSelectedImages.Size = new System.Drawing.Size(728, 325);
            this._gbSelectedImages.TabIndex = 1;
            this._gbSelectedImages.TabStop = false;
            this._gbSelectedImages.Text = "选择的图像";
            // 
            // _toolTip
            // 
            this._toolTip.BackColor = System.Drawing.Color.White;
            this._toolTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            // 
            // _ofdSelectedImages
            // 
            this._ofdSelectedImages.Filter = "图像文件|*.jpg;*.png;bmp";
            this._ofdSelectedImages.Multiselect = true;
            this._ofdSelectedImages.Title = "选择图像";
            // 
            // _flpImageContainer
            // 
            this._flpImageContainer.AutoScroll = true;
            this._flpImageContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flpImageContainer.Location = new System.Drawing.Point(3, 25);
            this._flpImageContainer.Margin = new System.Windows.Forms.Padding(0);
            this._flpImageContainer.Name = "_flpImageContainer";
            this._flpImageContainer.Size = new System.Drawing.Size(722, 297);
            this._flpImageContainer.TabIndex = 0;
            // 
            // _btnSelect
            // 
            this._btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnSelect.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._btnSelect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._btnSelect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnSelect.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._btnSelect.ForeColor = System.Drawing.Color.White;
            this._btnSelect.Location = new System.Drawing.Point(21, 394);
            this._btnSelect.Margin = new System.Windows.Forms.Padding(0);
            this._btnSelect.Name = "_btnSelect";
            this._btnSelect.Size = new System.Drawing.Size(103, 36);
            this._btnSelect.TabIndex = 3;
            this._btnSelect.Text = "选择";
            this._toolTip.SetToolTip(this._btnSelect, "按您想要的顺序选择合成PDF的源图像");
            this._btnSelect.UseVisualStyleBackColor = true;
            this._btnSelect.Click += new System.EventHandler(this._btnSelecte_Click);
            // 
            // _btnGenerate
            // 
            this._btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnGenerate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._btnGenerate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._btnGenerate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnGenerate.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._btnGenerate.ForeColor = System.Drawing.Color.White;
            this._btnGenerate.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this._btnGenerate.Location = new System.Drawing.Point(646, 394);
            this._btnGenerate.Margin = new System.Windows.Forms.Padding(0);
            this._btnGenerate.Name = "_btnGenerate";
            this._btnGenerate.Size = new System.Drawing.Size(103, 36);
            this._btnGenerate.TabIndex = 4;
            this._btnGenerate.Text = "生成";
            this._btnGenerate.UseVisualStyleBackColor = true;
            this._btnGenerate.Click += new System.EventHandler(this._btnGenerate_Click);
            // 
            // _sfSavePdf
            // 
            this._sfSavePdf.DefaultExt = "pdf";
            this._sfSavePdf.Filter = "Pdf 文档|*.pdf";
            this._sfSavePdf.Title = "选择保存路径";
            // 
            // _btnClose
            // 
            this._btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnClose.FlatAppearance.BorderSize = 0;
            this._btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnClose.ForeColor = System.Drawing.Color.White;
            this._btnClose.Image = global::Degage.ToolBox.Pdf.Properties.Resources.Close;
            this._btnClose.Location = new System.Drawing.Point(737, 13);
            this._btnClose.Margin = new System.Windows.Forms.Padding(0);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(25, 25);
            this._btnClose.TabIndex = 7;
            this._btnClose.UseVisualStyleBackColor = true;
            this._btnClose.Click += new System.EventHandler(this._btnClose_Click);
            // 
            // _lblTipInfo
            // 
            this._lblTipInfo.AutoEllipsis = true;
            this._lblTipInfo.Font = new System.Drawing.Font("微软雅黑 Light", 12F);
            this._lblTipInfo.ForeColor = System.Drawing.Color.White;
            this._lblTipInfo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this._lblTipInfo.Location = new System.Drawing.Point(21, 11);
            this._lblTipInfo.Name = "_lblTipInfo";
            this._lblTipInfo.Size = new System.Drawing.Size(402, 34);
            this._lblTipInfo.TabIndex = 13;
            this._lblTipInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(776, 455);
            this.Controls.Add(this._lblTipInfo);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._btnGenerate);
            this.Controls.Add(this._btnSelect);
            this.Controls.Add(this._gbSelectedImages);
            this.Font = new System.Drawing.Font("微软雅黑 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "PDF 生成";
            this._gbSelectedImages.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox _gbSelectedImages;
        private System.Windows.Forms.ToolTip _toolTip;
        private System.Windows.Forms.OpenFileDialog _ofdSelectedImages;
        private System.Windows.Forms.FlowLayoutPanel _flpImageContainer;
        private System.Windows.Forms.Button _btnSelect;
        private System.Windows.Forms.Button _btnGenerate;
        private System.Windows.Forms.SaveFileDialog _sfSavePdf;
        private System.Windows.Forms.Button _btnClose;
        private System.Windows.Forms.Label _lblTipInfo;
    }
}

