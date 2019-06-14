namespace WorkPerformance
{
    partial class EmailFilterForm
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
            this._tbKeywords = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._tbRcentDays = new System.Windows.Forms.TextBox();
            this._lblTest = new System.Windows.Forms.Label();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _tbKeywords
            // 
            this._tbKeywords.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(98)))), ((int)(((byte)(85)))));
            this._tbKeywords.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbKeywords.Font = new System.Drawing.Font("微软雅黑 Light", 15F);
            this._tbKeywords.ForeColor = System.Drawing.Color.White;
            this._tbKeywords.Location = new System.Drawing.Point(41, 143);
            this._tbKeywords.Name = "_tbKeywords";
            this._tbKeywords.Size = new System.Drawing.Size(294, 27);
            this._tbKeywords.TabIndex = 10;
            this._tbKeywords.Text = "关键词";
            this._tbKeywords.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑 Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(36, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 27);
            this.label3.TabIndex = 9;
            this.label3.Text = "的邮件。";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑 Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(36, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 27);
            this.label2.TabIndex = 8;
            this.label2.Text = "收集标题含有关键词为：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑 Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(234, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 27);
            this.label1.TabIndex = 7;
            this.label1.Text = "】天的邮件。";
            // 
            // _tbRcentDays
            // 
            this._tbRcentDays.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(98)))), ((int)(((byte)(85)))));
            this._tbRcentDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbRcentDays.Font = new System.Drawing.Font("微软雅黑 Light", 15F);
            this._tbRcentDays.ForeColor = System.Drawing.Color.White;
            this._tbRcentDays.Location = new System.Drawing.Point(154, 51);
            this._tbRcentDays.Name = "_tbRcentDays";
            this._tbRcentDays.Size = new System.Drawing.Size(74, 27);
            this._tbRcentDays.TabIndex = 5;
            this._tbRcentDays.Text = "天数";
            this._tbRcentDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _lblTest
            // 
            this._lblTest.AutoSize = true;
            this._lblTest.Font = new System.Drawing.Font("微软雅黑 Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._lblTest.ForeColor = System.Drawing.Color.White;
            this._lblTest.Location = new System.Drawing.Point(36, 51);
            this._lblTest.Name = "_lblTest";
            this._lblTest.Size = new System.Drawing.Size(112, 27);
            this._lblTest.TabIndex = 6;
            this._lblTest.Text = "收集最近【";
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
            this._btnCancel.Location = new System.Drawing.Point(312, 238);
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
            this._btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnConfirm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._btnConfirm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._btnConfirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnConfirm.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._btnConfirm.ForeColor = System.Drawing.Color.White;
            this._btnConfirm.Location = new System.Drawing.Point(206, 238);
            this._btnConfirm.Margin = new System.Windows.Forms.Padding(0);
            this._btnConfirm.Name = "_btnConfirm";
            this._btnConfirm.Size = new System.Drawing.Size(75, 36);
            this._btnConfirm.TabIndex = 3;
            this._btnConfirm.Text = "确定";
            this._btnConfirm.UseVisualStyleBackColor = true;
            this._btnConfirm.Click += new System.EventHandler(this._btnConfirm_Click);
            // 
            // EmailFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(98)))), ((int)(((byte)(85)))));
            this.ClientSize = new System.Drawing.Size(437, 300);
            this.Controls.Add(this._tbKeywords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._tbRcentDays);
            this.Controls.Add(this._lblTest);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnConfirm);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "EmailFilterForm";
            this.ShowIcon = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "邮件过滤";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EmailFilterForm_FormClosing);
            this.Load += new System.EventHandler(this.EmailFilterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnConfirm;
        private System.Windows.Forms.TextBox _tbRcentDays;
        private System.Windows.Forms.Label _lblTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _tbKeywords;
    }
}