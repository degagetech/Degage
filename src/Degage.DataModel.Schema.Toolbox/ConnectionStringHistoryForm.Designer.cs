namespace Degage.DataModel.Schema.Toolbox
{
    partial class ConnectionStringHistoryForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this._btnCannel = new System.Windows.Forms.Button();
            this._btnConfirm = new System.Windows.Forms.Button();
            this._dgvHistory = new System.Windows.Forms.DataGridView();
            this._btnSaveHistory = new System.Windows.Forms.Button();
            this._btnRemove = new System.Windows.Forms.Button();
            this._colProviderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colConnectionString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this._dgvHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // _btnCannel
            // 
            this._btnCannel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCannel.Location = new System.Drawing.Point(506, 270);
            this._btnCannel.Name = "_btnCannel";
            this._btnCannel.Size = new System.Drawing.Size(65, 30);
            this._btnCannel.TabIndex = 40;
            this._btnCannel.Text = "取消";
            this._btnCannel.UseVisualStyleBackColor = true;
            this._btnCannel.Click += new System.EventHandler(this._btnCannel_Click);
            // 
            // _btnConfirm
            // 
            this._btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnConfirm.Location = new System.Drawing.Point(430, 270);
            this._btnConfirm.Name = "_btnConfirm";
            this._btnConfirm.Size = new System.Drawing.Size(65, 30);
            this._btnConfirm.TabIndex = 39;
            this._btnConfirm.Text = "确定";
            this._btnConfirm.UseVisualStyleBackColor = true;
            this._btnConfirm.Click += new System.EventHandler(this._btnConfirm_Click);
            // 
            // _dgvHistory
            // 
            this._dgvHistory.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._dgvHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgvHistory.BackgroundColor = System.Drawing.Color.White;
            this._dgvHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._dgvHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._colProviderName,
            this._colConnectionString});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(166)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvHistory.DefaultCellStyle = dataGridViewCellStyle2;
            this._dgvHistory.Location = new System.Drawing.Point(12, 12);
            this._dgvHistory.MultiSelect = false;
            this._dgvHistory.Name = "_dgvHistory";
            this._dgvHistory.RowHeadersVisible = false;
            this._dgvHistory.RowTemplate.Height = 23;
            this._dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvHistory.Size = new System.Drawing.Size(559, 244);
            this._dgvHistory.TabIndex = 41;
            // 
            // _btnSaveHistory
            // 
            this._btnSaveHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnSaveHistory.FlatAppearance.BorderSize = 0;
            this._btnSaveHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnSaveHistory.Image = global::Degage.DataModel.Schema.Toolbox.Properties.Resources.save;
            this._btnSaveHistory.Location = new System.Drawing.Point(37, 262);
            this._btnSaveHistory.Name = "_btnSaveHistory";
            this._btnSaveHistory.Size = new System.Drawing.Size(29, 26);
            this._btnSaveHistory.TabIndex = 42;
            this._btnSaveHistory.UseVisualStyleBackColor = true;
            this._btnSaveHistory.Click += new System.EventHandler(this._btnSaveHistory_Click);
            // 
            // _btnRemove
            // 
            this._btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnRemove.FlatAppearance.BorderSize = 0;
            this._btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnRemove.Image = global::Degage.DataModel.Schema.Toolbox.Properties.Resources.remove_red;
            this._btnRemove.Location = new System.Drawing.Point(8, 262);
            this._btnRemove.Name = "_btnRemove";
            this._btnRemove.Size = new System.Drawing.Size(29, 26);
            this._btnRemove.TabIndex = 43;
            this._btnRemove.UseVisualStyleBackColor = true;
            this._btnRemove.Click += new System.EventHandler(this._btnRemove_Click);
            // 
            // _colProviderName
            // 
            this._colProviderName.FillWeight = 47.71573F;
            this._colProviderName.HeaderText = "提供器名称";
            this._colProviderName.Name = "_colProviderName";
            // 
            // _colConnectionString
            // 
            this._colConnectionString.FillWeight = 152.2842F;
            this._colConnectionString.HeaderText = "连接字符串";
            this._colConnectionString.Name = "_colConnectionString";
            // 
            // ConnectionStringHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 311);
            this.Controls.Add(this._btnRemove);
            this.Controls.Add(this._btnSaveHistory);
            this.Controls.Add(this._dgvHistory);
            this.Controls.Add(this._btnCannel);
            this.Controls.Add(this._btnConfirm);
            this.MaximizeBox = false;
            this.Name = "ConnectionStringHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "连接记录";
            ((System.ComponentModel.ISupportInitialize)(this._dgvHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnCannel;
        private System.Windows.Forms.Button _btnConfirm;
        private System.Windows.Forms.DataGridView _dgvHistory;
        private System.Windows.Forms.Button _btnSaveHistory;
        private System.Windows.Forms.Button _btnRemove;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colProviderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colConnectionString;
    }
}