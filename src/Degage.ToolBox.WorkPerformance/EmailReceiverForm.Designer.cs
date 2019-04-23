namespace WorkPerformance
{
    partial class EmailReceiverForm
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
            this._listReceiverItems = new WorkPerformance.EmailReceiverListBox();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnConfirm = new System.Windows.Forms.Button();
            this._btnRemoveReceiver = new System.Windows.Forms.Button();
            this._btnAddReceiver = new System.Windows.Forms.Button();
            this._toolTip = new System.Windows.Forms.ToolTip(this.components);
            this._tbEmailAddress = new System.Windows.Forms.TextBox();
            this._lblEmailAddress = new System.Windows.Forms.Label();
            this._tbName = new System.Windows.Forms.TextBox();
            this._lblName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _listReceiverItems
            // 
            this._listReceiverItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this._listReceiverItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._listReceiverItems.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this._listReceiverItems.Font = new System.Drawing.Font("微软雅黑 Light", 12F);
            this._listReceiverItems.ForeColor = System.Drawing.Color.White;
            this._listReceiverItems.FormattingEnabled = true;
            this._listReceiverItems.ItemHeight = 30;
            this._listReceiverItems.Location = new System.Drawing.Point(18, 22);
            this._listReceiverItems.Margin = new System.Windows.Forms.Padding(0);
            this._listReceiverItems.Name = "_listReceiverItems";
            this._listReceiverItems.Size = new System.Drawing.Size(612, 336);
            this._listReceiverItems.TabIndex = 0;
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
            this._btnCancel.Location = new System.Drawing.Point(555, 497);
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
            this._btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnConfirm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._btnConfirm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._btnConfirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnConfirm.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._btnConfirm.ForeColor = System.Drawing.Color.White;
            this._btnConfirm.Location = new System.Drawing.Point(449, 497);
            this._btnConfirm.Margin = new System.Windows.Forms.Padding(0);
            this._btnConfirm.Name = "_btnConfirm";
            this._btnConfirm.Size = new System.Drawing.Size(75, 36);
            this._btnConfirm.TabIndex = 5;
            this._btnConfirm.Text = "确定";
            this._toolTip.SetToolTip(this._btnConfirm, "将修改保存至本地介质中");
            this._btnConfirm.UseVisualStyleBackColor = true;
            this._btnConfirm.Click += new System.EventHandler(this._btnConfirm_Click);
            // 
            // _btnRemoveReceiver
            // 
            this._btnRemoveReceiver.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnRemoveReceiver.FlatAppearance.BorderSize = 0;
            this._btnRemoveReceiver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnRemoveReceiver.Image = global::WorkPerformance.Properties.Resources.ReceiverRemove;
            this._btnRemoveReceiver.Location = new System.Drawing.Point(73, 368);
            this._btnRemoveReceiver.Margin = new System.Windows.Forms.Padding(0);
            this._btnRemoveReceiver.Name = "_btnRemoveReceiver";
            this._btnRemoveReceiver.Size = new System.Drawing.Size(45, 40);
            this._btnRemoveReceiver.TabIndex = 19;
            this._toolTip.SetToolTip(this._btnRemoveReceiver, "移除当前选中的邮件接收人");
            this._btnRemoveReceiver.UseVisualStyleBackColor = true;
            this._btnRemoveReceiver.Click += new System.EventHandler(this._btnRemoveReceiver_Click);
            // 
            // _btnAddReceiver
            // 
            this._btnAddReceiver.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnAddReceiver.FlatAppearance.BorderSize = 0;
            this._btnAddReceiver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnAddReceiver.Image = global::WorkPerformance.Properties.Resources.ReceiverAdd;
            this._btnAddReceiver.Location = new System.Drawing.Point(22, 368);
            this._btnAddReceiver.Margin = new System.Windows.Forms.Padding(0);
            this._btnAddReceiver.Name = "_btnAddReceiver";
            this._btnAddReceiver.Size = new System.Drawing.Size(45, 40);
            this._btnAddReceiver.TabIndex = 18;
            this._toolTip.SetToolTip(this._btnAddReceiver, "新增一个邮件接收人");
            this._btnAddReceiver.UseVisualStyleBackColor = true;
            this._btnAddReceiver.Click += new System.EventHandler(this._btnAddReceiver_Click);
            // 
            // _toolTip
            // 
            this._toolTip.AutomaticDelay = 300;
            this._toolTip.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // _tbEmailAddress
            // 
            this._tbEmailAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this._tbEmailAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbEmailAddress.Font = new System.Drawing.Font("微软雅黑 Light", 15F);
            this._tbEmailAddress.ForeColor = System.Drawing.Color.White;
            this._tbEmailAddress.Location = new System.Drawing.Point(106, 458);
            this._tbEmailAddress.Name = "_tbEmailAddress";
            this._tbEmailAddress.Size = new System.Drawing.Size(418, 27);
            this._tbEmailAddress.TabIndex = 22;
            this._tbEmailAddress.TextChanged += new System.EventHandler(this._tbEmailAddress_TextChanged);
            // 
            // _lblEmailAddress
            // 
            this._lblEmailAddress.AutoSize = true;
            this._lblEmailAddress.Font = new System.Drawing.Font("微软雅黑 Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._lblEmailAddress.ForeColor = System.Drawing.Color.White;
            this._lblEmailAddress.Location = new System.Drawing.Point(30, 458);
            this._lblEmailAddress.Name = "_lblEmailAddress";
            this._lblEmailAddress.Size = new System.Drawing.Size(72, 27);
            this._lblEmailAddress.TabIndex = 23;
            this._lblEmailAddress.Text = "地址：";
            // 
            // _tbName
            // 
            this._tbName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this._tbName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbName.Font = new System.Drawing.Font("微软雅黑 Light", 15F);
            this._tbName.ForeColor = System.Drawing.Color.White;
            this._tbName.Location = new System.Drawing.Point(106, 417);
            this._tbName.Name = "_tbName";
            this._tbName.Size = new System.Drawing.Size(418, 27);
            this._tbName.TabIndex = 20;
            this._tbName.TextChanged += new System.EventHandler(this._tbName_TextChanged);
            // 
            // _lblName
            // 
            this._lblName.AutoSize = true;
            this._lblName.Font = new System.Drawing.Font("微软雅黑 Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._lblName.ForeColor = System.Drawing.Color.White;
            this._lblName.Location = new System.Drawing.Point(30, 417);
            this._lblName.Name = "_lblName";
            this._lblName.Size = new System.Drawing.Size(72, 27);
            this._lblName.TabIndex = 21;
            this._lblName.Text = "姓名：";
            // 
            // EmailReceiverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(650, 550);
            this.Controls.Add(this._tbEmailAddress);
            this.Controls.Add(this._lblEmailAddress);
            this.Controls.Add(this._tbName);
            this.Controls.Add(this._lblName);
            this.Controls.Add(this._btnRemoveReceiver);
            this.Controls.Add(this._btnAddReceiver);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnConfirm);
            this.Controls.Add(this._listReceiverItems);
            this.Font = new System.Drawing.Font("微软雅黑 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "EmailReceiverForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "邮件接收人设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EmailReceiverListBox _listReceiverItems;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnConfirm;
        private System.Windows.Forms.Button _btnRemoveReceiver;
        private System.Windows.Forms.Button _btnAddReceiver;
        private System.Windows.Forms.ToolTip _toolTip;
        private System.Windows.Forms.TextBox _tbEmailAddress;
        private System.Windows.Forms.Label _lblEmailAddress;
        private System.Windows.Forms.TextBox _tbName;
        private System.Windows.Forms.Label _lblName;
    }
}