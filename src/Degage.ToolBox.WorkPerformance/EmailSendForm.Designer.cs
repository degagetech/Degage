namespace WorkPerformance
{
    partial class EmailSendForm
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
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnConfirm = new System.Windows.Forms.Button();
            this._tbEmailTitle = new System.Windows.Forms.TextBox();
            this._lblTest = new System.Windows.Forms.Label();
            this._tbRecevicer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._tbTextBody = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._toolTip = new System.Windows.Forms.ToolTip(this.components);
            this._lblTipInfo = new System.Windows.Forms.Label();
            this._cbIsRespectivelySend = new System.Windows.Forms.CheckBox();
            this._btnEditPerformance = new System.Windows.Forms.Button();
            this._btnRemoveAttachment = new System.Windows.Forms.Button();
            this._btnAddAttachment = new System.Windows.Forms.Button();
            this._lbSendAttachments = new WorkPerformance.SendAttachmentListBox();
            this._btnSettingReceiver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnCancel.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._btnCancel.ForeColor = System.Drawing.Color.White;
            this._btnCancel.Location = new System.Drawing.Point(636, 611);
            this._btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 36);
            this._btnCancel.TabIndex = 4;
            this._btnCancel.Text = "取消";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // _btnConfirm
            // 
            this._btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnConfirm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._btnConfirm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._btnConfirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnConfirm.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._btnConfirm.ForeColor = System.Drawing.Color.White;
            this._btnConfirm.Location = new System.Drawing.Point(530, 611);
            this._btnConfirm.Margin = new System.Windows.Forms.Padding(0);
            this._btnConfirm.Name = "_btnConfirm";
            this._btnConfirm.Size = new System.Drawing.Size(75, 36);
            this._btnConfirm.TabIndex = 3;
            this._btnConfirm.Text = "发送";
            this._btnConfirm.UseVisualStyleBackColor = true;
            this._btnConfirm.Click += new System.EventHandler(this._btnConfirm_Click);
            // 
            // _tbEmailTitle
            // 
            this._tbEmailTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(150)))), ((int)(((byte)(133)))));
            this._tbEmailTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbEmailTitle.Font = new System.Drawing.Font("微软雅黑 Light", 15F);
            this._tbEmailTitle.ForeColor = System.Drawing.Color.White;
            this._tbEmailTitle.Location = new System.Drawing.Point(127, 36);
            this._tbEmailTitle.Name = "_tbEmailTitle";
            this._tbEmailTitle.Size = new System.Drawing.Size(584, 27);
            this._tbEmailTitle.TabIndex = 5;
            // 
            // _lblTest
            // 
            this._lblTest.AutoSize = true;
            this._lblTest.Font = new System.Drawing.Font("微软雅黑 Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._lblTest.ForeColor = System.Drawing.Color.White;
            this._lblTest.Location = new System.Drawing.Point(51, 36);
            this._lblTest.Name = "_lblTest";
            this._lblTest.Size = new System.Drawing.Size(72, 27);
            this._lblTest.TabIndex = 6;
            this._lblTest.Text = "标题：";
            // 
            // _tbRecevicer
            // 
            this._tbRecevicer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(150)))), ((int)(((byte)(133)))));
            this._tbRecevicer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbRecevicer.Font = new System.Drawing.Font("微软雅黑 Light", 15F);
            this._tbRecevicer.ForeColor = System.Drawing.Color.White;
            this._tbRecevicer.Location = new System.Drawing.Point(127, 82);
            this._tbRecevicer.Name = "_tbRecevicer";
            this._tbRecevicer.Size = new System.Drawing.Size(584, 27);
            this._tbRecevicer.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑 Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(31, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 27);
            this.label1.TabIndex = 8;
            this.label1.Text = "收件人：";
            // 
            // _tbTextBody
            // 
            this._tbTextBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(150)))), ((int)(((byte)(133)))));
            this._tbTextBody.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbTextBody.Font = new System.Drawing.Font("微软雅黑 Light", 15F);
            this._tbTextBody.ForeColor = System.Drawing.Color.White;
            this._tbTextBody.Location = new System.Drawing.Point(127, 130);
            this._tbTextBody.Multiline = true;
            this._tbTextBody.Name = "_tbTextBody";
            this._tbTextBody.Size = new System.Drawing.Size(584, 172);
            this._tbTextBody.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑 Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(51, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 27);
            this.label2.TabIndex = 10;
            this.label2.Text = "正文：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑 Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(51, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 27);
            this.label3.TabIndex = 11;
            this.label3.Text = "附件：";
            // 
            // _toolTip
            // 
            this._toolTip.AutomaticDelay = 300;
            this._toolTip.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // _lblTipInfo
            // 
            this._lblTipInfo.AutoEllipsis = true;
            this._lblTipInfo.Font = new System.Drawing.Font("微软雅黑 Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._lblTipInfo.ForeColor = System.Drawing.Color.White;
            this._lblTipInfo.Location = new System.Drawing.Point(29, 620);
            this._lblTipInfo.Name = "_lblTipInfo";
            this._lblTipInfo.Size = new System.Drawing.Size(359, 27);
            this._lblTipInfo.TabIndex = 18;
            // 
            // _cbIsRespectivelySend
            // 
            this._cbIsRespectivelySend.AutoSize = true;
            this._cbIsRespectivelySend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this._cbIsRespectivelySend.FlatAppearance.BorderSize = 0;
            this._cbIsRespectivelySend.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this._cbIsRespectivelySend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._cbIsRespectivelySend.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._cbIsRespectivelySend.Location = new System.Drawing.Point(126, 581);
            this._cbIsRespectivelySend.Name = "_cbIsRespectivelySend";
            this._cbIsRespectivelySend.Size = new System.Drawing.Size(81, 24);
            this._cbIsRespectivelySend.TabIndex = 21;
            this._cbIsRespectivelySend.Text = "分别发送";
            this._toolTip.SetToolTip(this._cbIsRespectivelySend, "将附件发送给不同的收件人，若未指定则发送给默认收件人");
            this._cbIsRespectivelySend.UseVisualStyleBackColor = false;
            this._cbIsRespectivelySend.CheckedChanged += new System.EventHandler(this._cbIsRespectivelySend_CheckedChanged);
            // 
            // _btnEditPerformance
            // 
            this._btnEditPerformance.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnEditPerformance.FlatAppearance.BorderSize = 0;
            this._btnEditPerformance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnEditPerformance.Image = global::WorkPerformance.Properties.Resources.EditPerformance;
            this._btnEditPerformance.Location = new System.Drawing.Point(59, 459);
            this._btnEditPerformance.Margin = new System.Windows.Forms.Padding(0);
            this._btnEditPerformance.Name = "_btnEditPerformance";
            this._btnEditPerformance.Size = new System.Drawing.Size(45, 40);
            this._btnEditPerformance.TabIndex = 20;
            this._toolTip.SetToolTip(this._btnEditPerformance, "尝试将当前选中附件作为绩效文件编辑");
            this._btnEditPerformance.UseVisualStyleBackColor = true;
            this._btnEditPerformance.Click += new System.EventHandler(this._btnEditPerformance_Click);
            // 
            // _btnRemoveAttachment
            // 
            this._btnRemoveAttachment.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnRemoveAttachment.FlatAppearance.BorderSize = 0;
            this._btnRemoveAttachment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnRemoveAttachment.Image = global::WorkPerformance.Properties.Resources.Remove;
            this._btnRemoveAttachment.Location = new System.Drawing.Point(58, 415);
            this._btnRemoveAttachment.Margin = new System.Windows.Forms.Padding(0);
            this._btnRemoveAttachment.Name = "_btnRemoveAttachment";
            this._btnRemoveAttachment.Size = new System.Drawing.Size(45, 40);
            this._btnRemoveAttachment.TabIndex = 17;
            this._toolTip.SetToolTip(this._btnRemoveAttachment, "移除当前选中的发信附件");
            this._btnRemoveAttachment.UseVisualStyleBackColor = true;
            this._btnRemoveAttachment.Click += new System.EventHandler(this._btnRemoveAttachment_Click);
            // 
            // _btnAddAttachment
            // 
            this._btnAddAttachment.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnAddAttachment.FlatAppearance.BorderSize = 0;
            this._btnAddAttachment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnAddAttachment.Image = global::WorkPerformance.Properties.Resources.AddAttachment;
            this._btnAddAttachment.Location = new System.Drawing.Point(56, 370);
            this._btnAddAttachment.Margin = new System.Windows.Forms.Padding(0);
            this._btnAddAttachment.Name = "_btnAddAttachment";
            this._btnAddAttachment.Size = new System.Drawing.Size(45, 40);
            this._btnAddAttachment.TabIndex = 16;
            this._toolTip.SetToolTip(this._btnAddAttachment, "添加现有文件到发信附件中");
            this._btnAddAttachment.UseVisualStyleBackColor = true;
            this._btnAddAttachment.Click += new System.EventHandler(this._btnAddAttachment_Click);
            // 
            // _lbSendAttachments
            // 
            this._lbSendAttachments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(150)))), ((int)(((byte)(133)))));
            this._lbSendAttachments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._lbSendAttachments.DefaultAttachmentImage = global::WorkPerformance.Properties.Resources.AttachmentDownloadWhite;
            this._lbSendAttachments.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this._lbSendAttachments.DrawReceiver = false;
            this._lbSendAttachments.Font = new System.Drawing.Font("微软雅黑 Light", 12F);
            this._lbSendAttachments.ForeColor = System.Drawing.Color.White;
            this._lbSendAttachments.FormattingEnabled = true;
            this._lbSendAttachments.ItemHeight = 30;
            this._lbSendAttachments.Location = new System.Drawing.Point(126, 327);
            this._lbSendAttachments.Margin = new System.Windows.Forms.Padding(0);
            this._lbSendAttachments.Name = "_lbSendAttachments";
            this._lbSendAttachments.SavedAttachmentFlagImage = global::WorkPerformance.Properties.Resources.AttachmentWhite;
            this._lbSendAttachments.Size = new System.Drawing.Size(585, 246);
            this._lbSendAttachments.TabIndex = 15;
            // 
            // _btnSettingReceiver
            // 
            this._btnSettingReceiver.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnSettingReceiver.FlatAppearance.BorderSize = 0;
            this._btnSettingReceiver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnSettingReceiver.Image = global::WorkPerformance.Properties.Resources.EmailReceiver;
            this._btnSettingReceiver.Location = new System.Drawing.Point(60, 502);
            this._btnSettingReceiver.Margin = new System.Windows.Forms.Padding(0);
            this._btnSettingReceiver.Name = "_btnSettingReceiver";
            this._btnSettingReceiver.Size = new System.Drawing.Size(45, 40);
            this._btnSettingReceiver.TabIndex = 22;
            this._toolTip.SetToolTip(this._btnSettingReceiver, "手动单独设置当前选中附件的接收人");
            this._btnSettingReceiver.UseVisualStyleBackColor = true;
            this._btnSettingReceiver.Click += new System.EventHandler(this._btnSettingReceiver_Click);
            // 
            // EmailSendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.ClientSize = new System.Drawing.Size(752, 674);
            this.Controls.Add(this._btnSettingReceiver);
            this.Controls.Add(this._cbIsRespectivelySend);
            this.Controls.Add(this._btnEditPerformance);
            this.Controls.Add(this._lblTipInfo);
            this.Controls.Add(this._btnRemoveAttachment);
            this.Controls.Add(this._btnAddAttachment);
            this.Controls.Add(this._lbSendAttachments);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._tbTextBody);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._tbRecevicer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._tbEmailTitle);
            this.Controls.Add(this._lblTest);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnConfirm);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "EmailSendForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "发送邮件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnConfirm;
        private System.Windows.Forms.TextBox _tbEmailTitle;
        private System.Windows.Forms.Label _lblTest;
        private System.Windows.Forms.TextBox _tbRecevicer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _tbTextBody;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private SendAttachmentListBox _lbSendAttachments;
        private System.Windows.Forms.Button _btnAddAttachment;
        private System.Windows.Forms.ToolTip _toolTip;
        private System.Windows.Forms.Button _btnRemoveAttachment;
        private System.Windows.Forms.Label _lblTipInfo;
        private System.Windows.Forms.Button _btnEditPerformance;
        private System.Windows.Forms.CheckBox _cbIsRespectivelySend;
        private System.Windows.Forms.Button _btnSettingReceiver;
    }
}