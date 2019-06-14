namespace WorkPerformance
{
    partial class UserInfoConfigForm
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
            this._lblTest = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._tbEmailAddress = new System.Windows.Forms.TextBox();
            this._tbPassword = new System.Windows.Forms.TextBox();
            this.line1 = new WorkPerformance.Line();
            this._btnDisplayPassword = new System.Windows.Forms.Button();
            this._btnConfirm = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this._tbDefaultReceviceEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._tbName = new System.Windows.Forms.TextBox();
            this._tbDepartment = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _lblTest
            // 
            this._lblTest.AutoSize = true;
            this._lblTest.Font = new System.Drawing.Font("微软雅黑 Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._lblTest.ForeColor = System.Drawing.Color.White;
            this._lblTest.Location = new System.Drawing.Point(29, 29);
            this._lblTest.Name = "_lblTest";
            this._lblTest.Size = new System.Drawing.Size(72, 27);
            this._lblTest.TabIndex = 4;
            this._lblTest.Text = "邮箱：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑 Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(29, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 27);
            this.label1.TabIndex = 5;
            this.label1.Text = "密码：";
            // 
            // _tbEmailAddress
            // 
            this._tbEmailAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(164)))), ((int)(((byte)(175)))));
            this._tbEmailAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbEmailAddress.Font = new System.Drawing.Font("微软雅黑 Light", 15F);
            this._tbEmailAddress.ForeColor = System.Drawing.Color.White;
            this._tbEmailAddress.Location = new System.Drawing.Point(105, 29);
            this._tbEmailAddress.Name = "_tbEmailAddress";
            this._tbEmailAddress.Size = new System.Drawing.Size(242, 27);
            this._tbEmailAddress.TabIndex = 3;
            this._tbEmailAddress.Text = "你的邮箱~";
            // 
            // _tbPassword
            // 
            this._tbPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(164)))), ((int)(((byte)(175)))));
            this._tbPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbPassword.Font = new System.Drawing.Font("微软雅黑 Light", 15F);
            this._tbPassword.ForeColor = System.Drawing.Color.White;
            this._tbPassword.Location = new System.Drawing.Point(105, 80);
            this._tbPassword.Name = "_tbPassword";
            this._tbPassword.Size = new System.Drawing.Size(242, 27);
            this._tbPassword.TabIndex = 4;
            this._tbPassword.Text = "你的密码~";
            // 
            // line1
            // 
            this.line1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.line1.CustomBursh = null;
            this.line1.IsVertical = true;
            this.line1.LineColor = System.Drawing.Color.White;
            this.line1.LineLength = 371;
            this.line1.LineWidth = 1;
            this.line1.Location = new System.Drawing.Point(370, 0);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(1, 371);
            this.line1.TabIndex = 8;
            this.line1.Text = "line1";
            // 
            // _btnDisplayPassword
            // 
            this._btnDisplayPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnDisplayPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnDisplayPassword.FlatAppearance.BorderSize = 0;
            this._btnDisplayPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnDisplayPassword.Image = global::WorkPerformance.Properties.Resources.Display;
            this._btnDisplayPassword.Location = new System.Drawing.Point(374, 81);
            this._btnDisplayPassword.Margin = new System.Windows.Forms.Padding(0);
            this._btnDisplayPassword.Name = "_btnDisplayPassword";
            this._btnDisplayPassword.Size = new System.Drawing.Size(30, 25);
            this._btnDisplayPassword.TabIndex = 9;
            this._btnDisplayPassword.UseVisualStyleBackColor = true;
            this._btnDisplayPassword.MouseDown += new System.Windows.Forms.MouseEventHandler(this._btnDisplayPassword_MouseDown);
            this._btnDisplayPassword.MouseUp += new System.Windows.Forms.MouseEventHandler(this._btnDisplayPassword_MouseUp);
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
            this._btnConfirm.Location = new System.Drawing.Point(166, 314);
            this._btnConfirm.Margin = new System.Windows.Forms.Padding(0);
            this._btnConfirm.Name = "_btnConfirm";
            this._btnConfirm.Size = new System.Drawing.Size(75, 36);
            this._btnConfirm.TabIndex = 1;
            this._btnConfirm.Text = "确定";
            this._btnConfirm.UseVisualStyleBackColor = true;
            this._btnConfirm.Click += new System.EventHandler(this._btnConfirm_Click);
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
            this._btnCancel.Location = new System.Drawing.Point(272, 314);
            this._btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 36);
            this._btnCancel.TabIndex = 2;
            this._btnCancel.Text = "取消";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑 Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(29, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 27);
            this.label2.TabIndex = 10;
            this.label2.Text = "默认收信人的邮箱";
            // 
            // _tbDefaultReceviceEmail
            // 
            this._tbDefaultReceviceEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(164)))), ((int)(((byte)(175)))));
            this._tbDefaultReceviceEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbDefaultReceviceEmail.Font = new System.Drawing.Font("微软雅黑 Light", 15F);
            this._tbDefaultReceviceEmail.ForeColor = System.Drawing.Color.White;
            this._tbDefaultReceviceEmail.Location = new System.Drawing.Point(34, 164);
            this._tbDefaultReceviceEmail.Name = "_tbDefaultReceviceEmail";
            this._tbDefaultReceviceEmail.Size = new System.Drawing.Size(313, 27);
            this._tbDefaultReceviceEmail.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑 Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(29, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 27);
            this.label3.TabIndex = 11;
            this.label3.Text = "姓名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑 Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(29, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 27);
            this.label4.TabIndex = 12;
            this.label4.Text = "部门：";
            // 
            // _tbName
            // 
            this._tbName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(164)))), ((int)(((byte)(175)))));
            this._tbName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbName.Font = new System.Drawing.Font("微软雅黑 Light", 15F);
            this._tbName.ForeColor = System.Drawing.Color.White;
            this._tbName.Location = new System.Drawing.Point(105, 214);
            this._tbName.Name = "_tbName";
            this._tbName.Size = new System.Drawing.Size(242, 27);
            this._tbName.TabIndex = 13;
            // 
            // _tbDepartment
            // 
            this._tbDepartment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(164)))), ((int)(((byte)(175)))));
            this._tbDepartment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbDepartment.Font = new System.Drawing.Font("微软雅黑 Light", 15F);
            this._tbDepartment.ForeColor = System.Drawing.Color.White;
            this._tbDepartment.Location = new System.Drawing.Point(105, 259);
            this._tbDepartment.Name = "_tbDepartment";
            this._tbDepartment.Size = new System.Drawing.Size(242, 27);
            this._tbDepartment.TabIndex = 14;
            // 
            // UserInfoConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(174)))), ((int)(((byte)(175)))));
            this.ClientSize = new System.Drawing.Size(429, 371);
            this.Controls.Add(this._tbDepartment);
            this.Controls.Add(this._tbName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._tbDefaultReceviceEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnConfirm);
            this.Controls.Add(this._btnDisplayPassword);
            this.Controls.Add(this.line1);
            this.Controls.Add(this._tbPassword);
            this.Controls.Add(this._tbEmailAddress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._lblTest);
            this.Name = "UserInfoConfigForm";
            this.ShowIcon = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "用户设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserInfoConfigForm_FormClosing);
            this.Load += new System.EventHandler(this.UserInfoConfigForm_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _lblTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _tbEmailAddress;
        private System.Windows.Forms.TextBox _tbPassword;
        private Line line1;
        private System.Windows.Forms.Button _btnDisplayPassword;
        private System.Windows.Forms.Button _btnConfirm;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _tbDefaultReceviceEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _tbName;
        private System.Windows.Forms.TextBox _tbDepartment;
    }
}