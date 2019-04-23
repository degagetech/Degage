namespace Degage.ToolBox.OCR
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
            this._ofdSelectImage = new System.Windows.Forms.OpenFileDialog();
            this._pbImage = new System.Windows.Forms.PictureBox();
            this._tbRecognitionResult = new System.Windows.Forms.TextBox();
            this._btnScreenHost = new System.Windows.Forms.Button();
            this._btnRecognition = new System.Windows.Forms.Button();
            this._notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this._btnLocalRecognition = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._btnSelectLocal = new System.Windows.Forms.Button();
            this._plImageContainer = new System.Windows.Forms.Panel();
            this._btnBinaryzation = new System.Windows.Forms.Button();
            this._btnSharpening = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this._disposePbImage = new System.Windows.Forms.PictureBox();
            this._chbProcessAfter = new System.Windows.Forms.CheckBox();
            this._numScale = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._btnLocalRecognition1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._pbImage)).BeginInit();
            this._plImageContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._disposePbImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numScale)).BeginInit();
            this.SuspendLayout();
            // 
            // _ofdSelectImage
            // 
            this._ofdSelectImage.FileName = "openFileDialog1";
            this._ofdSelectImage.Filter = "图像文件|*.png;*.jpg";
            // 
            // _pbImage
            // 
            this._pbImage.Location = new System.Drawing.Point(0, 0);
            this._pbImage.Margin = new System.Windows.Forms.Padding(0);
            this._pbImage.Name = "_pbImage";
            this._pbImage.Size = new System.Drawing.Size(346, 303);
            this._pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this._pbImage.TabIndex = 0;
            this._pbImage.TabStop = false;
            // 
            // _tbRecognitionResult
            // 
            this._tbRecognitionResult.Location = new System.Drawing.Point(397, 54);
            this._tbRecognitionResult.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._tbRecognitionResult.Multiline = true;
            this._tbRecognitionResult.Name = "_tbRecognitionResult";
            this._tbRecognitionResult.Size = new System.Drawing.Size(341, 303);
            this._tbRecognitionResult.TabIndex = 1;
            // 
            // _btnScreenHost
            // 
            this._btnScreenHost.Location = new System.Drawing.Point(116, 6);
            this._btnScreenHost.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._btnScreenHost.Name = "_btnScreenHost";
            this._btnScreenHost.Size = new System.Drawing.Size(100, 40);
            this._btnScreenHost.TabIndex = 2;
            this._btnScreenHost.Text = "屏幕截图";
            this._btnScreenHost.UseVisualStyleBackColor = true;
            this._btnScreenHost.Click += new System.EventHandler(this._btnScreenHost_Click);
            // 
            // _btnRecognition
            // 
            this._btnRecognition.Location = new System.Drawing.Point(523, 378);
            this._btnRecognition.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._btnRecognition.Name = "_btnRecognition";
            this._btnRecognition.Size = new System.Drawing.Size(100, 40);
            this._btnRecognition.TabIndex = 3;
            this._btnRecognition.Text = "网络识别";
            this._btnRecognition.UseVisualStyleBackColor = true;
            this._btnRecognition.Click += new System.EventHandler(this._btnRecognition_Click);
            // 
            // _notifyIcon
            // 
            this._notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this._notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("_notifyIcon.Icon")));
            this._notifyIcon.Text = "文字识别工具（DegageTech）";
            this._notifyIcon.Visible = true;
            // 
            // _btnLocalRecognition
            // 
            this._btnLocalRecognition.Location = new System.Drawing.Point(638, 378);
            this._btnLocalRecognition.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._btnLocalRecognition.Name = "_btnLocalRecognition";
            this._btnLocalRecognition.Size = new System.Drawing.Size(100, 40);
            this._btnLocalRecognition.TabIndex = 4;
            this._btnLocalRecognition.Text = "本地识别";
            this._btnLocalRecognition.UseVisualStyleBackColor = true;
            this._btnLocalRecognition.Click += new System.EventHandler(this._btnLocalRecognition_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(383, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "识别结果";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "待识别图像";
            // 
            // _btnSelectLocal
            // 
            this._btnSelectLocal.Location = new System.Drawing.Point(228, 6);
            this._btnSelectLocal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._btnSelectLocal.Name = "_btnSelectLocal";
            this._btnSelectLocal.Size = new System.Drawing.Size(100, 40);
            this._btnSelectLocal.TabIndex = 7;
            this._btnSelectLocal.Text = "本地选择";
            this._btnSelectLocal.UseVisualStyleBackColor = true;
            this._btnSelectLocal.Click += new System.EventHandler(this._btnSelectLocal_Click);
            // 
            // _plImageContainer
            // 
            this._plImageContainer.AutoScroll = true;
            this._plImageContainer.Controls.Add(this._pbImage);
            this._plImageContainer.Location = new System.Drawing.Point(24, 54);
            this._plImageContainer.Margin = new System.Windows.Forms.Padding(0);
            this._plImageContainer.Name = "_plImageContainer";
            this._plImageContainer.Size = new System.Drawing.Size(346, 303);
            this._plImageContainer.TabIndex = 8;
            // 
            // _btnBinaryzation
            // 
            this._btnBinaryzation.Location = new System.Drawing.Point(24, 364);
            this._btnBinaryzation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._btnBinaryzation.Name = "_btnBinaryzation";
            this._btnBinaryzation.Size = new System.Drawing.Size(70, 35);
            this._btnBinaryzation.TabIndex = 9;
            this._btnBinaryzation.Text = "二值化";
            this._btnBinaryzation.UseVisualStyleBackColor = true;
            this._btnBinaryzation.Click += new System.EventHandler(this._btnBinaryzation_ClickAsync);
            // 
            // _btnSharpening
            // 
            this._btnSharpening.Location = new System.Drawing.Point(111, 364);
            this._btnSharpening.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._btnSharpening.Name = "_btnSharpening";
            this._btnSharpening.Size = new System.Drawing.Size(70, 35);
            this._btnSharpening.TabIndex = 11;
            this._btnSharpening.Text = "锐化";
            this._btnSharpening.UseVisualStyleBackColor = true;
            this._btnSharpening.Click += new System.EventHandler(this._btnSharpening_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this._disposePbImage);
            this.panel1.Location = new System.Drawing.Point(24, 431);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(346, 263);
            this.panel1.TabIndex = 13;
            // 
            // _disposePbImage
            // 
            this._disposePbImage.Location = new System.Drawing.Point(0, 0);
            this._disposePbImage.Margin = new System.Windows.Forms.Padding(0);
            this._disposePbImage.Name = "_disposePbImage";
            this._disposePbImage.Size = new System.Drawing.Size(346, 263);
            this._disposePbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this._disposePbImage.TabIndex = 0;
            this._disposePbImage.TabStop = false;
            // 
            // _chbProcessAfter
            // 
            this._chbProcessAfter.AutoSize = true;
            this._chbProcessAfter.Location = new System.Drawing.Point(439, 389);
            this._chbProcessAfter.Name = "_chbProcessAfter";
            this._chbProcessAfter.Size = new System.Drawing.Size(76, 24);
            this._chbProcessAfter.TabIndex = 14;
            this._chbProcessAfter.Text = "处理后";
            this._chbProcessAfter.UseVisualStyleBackColor = true;
            // 
            // _numScale
            // 
            this._numScale.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this._numScale.Location = new System.Drawing.Point(242, 371);
            this._numScale.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this._numScale.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this._numScale.Name = "_numScale";
            this._numScale.Size = new System.Drawing.Size(62, 27);
            this._numScale.TabIndex = 15;
            this._numScale.ValueChanged += new System.EventHandler(this._numScale_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(201, 374);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "缩放";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(310, 374);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "X";
            // 
            // _btnLocalRecognition1
            // 
            this._btnLocalRecognition1.Location = new System.Drawing.Point(638, 431);
            this._btnLocalRecognition1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._btnLocalRecognition1.Name = "_btnLocalRecognition1";
            this._btnLocalRecognition1.Size = new System.Drawing.Size(100, 40);
            this._btnLocalRecognition1.TabIndex = 18;
            this._btnLocalRecognition1.Text = "本地识别1";
            this._btnLocalRecognition1.UseVisualStyleBackColor = true;
            this._btnLocalRecognition1.Click += new System.EventHandler(this._btnLocalRecognition1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 701);
            this.Controls.Add(this._btnLocalRecognition1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._numScale);
            this.Controls.Add(this._chbProcessAfter);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._btnSharpening);
            this.Controls.Add(this._btnBinaryzation);
            this.Controls.Add(this._plImageContainer);
            this.Controls.Add(this._btnSelectLocal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._btnLocalRecognition);
            this.Controls.Add(this._btnRecognition);
            this.Controls.Add(this._btnScreenHost);
            this.Controls.Add(this._tbRecognitionResult);
            this.Font = new System.Drawing.Font("微软雅黑 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "OCR测试";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this._pbImage)).EndInit();
            this._plImageContainer.ResumeLayout(false);
            this._plImageContainer.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._disposePbImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numScale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog _ofdSelectImage;
        private System.Windows.Forms.PictureBox _pbImage;
        private System.Windows.Forms.TextBox _tbRecognitionResult;
        private System.Windows.Forms.Button _btnScreenHost;
        private System.Windows.Forms.Button _btnRecognition;
        private System.Windows.Forms.NotifyIcon _notifyIcon;
        private System.Windows.Forms.Button _btnLocalRecognition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _btnSelectLocal;
        private System.Windows.Forms.Panel _plImageContainer;
        private System.Windows.Forms.Button _btnBinaryzation;
        private System.Windows.Forms.Button _btnSharpening;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox _disposePbImage;
        private System.Windows.Forms.CheckBox _chbProcessAfter;
        private System.Windows.Forms.NumericUpDown _numScale;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button _btnLocalRecognition1;
    }
}

