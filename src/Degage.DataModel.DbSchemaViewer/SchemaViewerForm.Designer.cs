namespace Degage.DataModel.DbSchemaViewer
{
    partial class SchemaViewerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchemaViewerForm));
            this._btnConfirm = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this._cmbDataBaseType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._cbNewForm = new System.Windows.Forms.CheckBox();
            this._cmbCollectionName = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this._btnQuery = new System.Windows.Forms.Button();
            this._txtRestriction = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._cbConnectionString = new System.Windows.Forms.ComboBox();
            this._dgvDataShow = new Degage.DataModel.DbSchemaViewer.DataGridViewEx();
            ((System.ComponentModel.ISupportInitialize)(this._dgvDataShow)).BeginInit();
            this.SuspendLayout();
            // 
            // _btnConfirm
            // 
            this._btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._btnConfirm.FlatAppearance.BorderSize = 0;
            this._btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnConfirm.Font = new System.Drawing.Font("微软雅黑", 10F);
            this._btnConfirm.ForeColor = System.Drawing.Color.White;
            this._btnConfirm.Location = new System.Drawing.Point(827, 67);
            this._btnConfirm.Name = "_btnConfirm";
            this._btnConfirm.Size = new System.Drawing.Size(80, 31);
            this._btnConfirm.TabIndex = 6;
            this._btnConfirm.Text = "连接";
            this._btnConfirm.UseVisualStyleBackColor = false;
            this._btnConfirm.Click += new System.EventHandler(this._btnConfrim_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label2.Location = new System.Drawing.Point(35, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "连接字符串";
            // 
            // _cmbDataBaseType
            // 
            this._cmbDataBaseType.BackColor = System.Drawing.Color.White;
            this._cmbDataBaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbDataBaseType.Font = new System.Drawing.Font("微软雅黑", 10F);
            this._cmbDataBaseType.FormattingEnabled = true;
            this._cmbDataBaseType.Location = new System.Drawing.Point(128, 26);
            this._cmbDataBaseType.Name = "_cmbDataBaseType";
            this._cmbDataBaseType.Size = new System.Drawing.Size(371, 27);
            this._cmbDataBaseType.TabIndex = 1;
            this._cmbDataBaseType.SelectedIndexChanged += new System.EventHandler(this._cmbDataBaseType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label1.Location = new System.Drawing.Point(35, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据库类型";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.label5.Location = new System.Drawing.Point(824, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "（请以 ; 号分割）";
            // 
            // _cbNewForm
            // 
            this._cbNewForm.AutoSize = true;
            this._cbNewForm.Font = new System.Drawing.Font("微软雅黑", 10F);
            this._cbNewForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this._cbNewForm.Location = new System.Drawing.Point(520, 114);
            this._cbNewForm.Name = "_cbNewForm";
            this._cbNewForm.Size = new System.Drawing.Size(112, 24);
            this._cbNewForm.TabIndex = 10;
            this._cbNewForm.Text = "显示到新窗体";
            this._cbNewForm.UseVisualStyleBackColor = true;
            // 
            // _cmbCollectionName
            // 
            this._cmbCollectionName.BackColor = System.Drawing.Color.White;
            this._cmbCollectionName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this._cmbCollectionName.FormattingEnabled = true;
            this._cmbCollectionName.Location = new System.Drawing.Point(128, 112);
            this._cmbCollectionName.Name = "_cmbCollectionName";
            this._cmbCollectionName.Size = new System.Drawing.Size(371, 27);
            this._cmbCollectionName.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label6.Location = new System.Drawing.Point(21, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "查询集合名称";
            // 
            // _btnQuery
            // 
            this._btnQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._btnQuery.FlatAppearance.BorderSize = 0;
            this._btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnQuery.ForeColor = System.Drawing.Color.White;
            this._btnQuery.Location = new System.Drawing.Point(53, 196);
            this._btnQuery.Name = "_btnQuery";
            this._btnQuery.Size = new System.Drawing.Size(80, 31);
            this._btnQuery.TabIndex = 7;
            this._btnQuery.Text = "查询";
            this._btnQuery.UseVisualStyleBackColor = false;
            this._btnQuery.Click += new System.EventHandler(this._btnQuery_Click);
            // 
            // _txtRestriction
            // 
            this._txtRestriction.BackColor = System.Drawing.Color.White;
            this._txtRestriction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtRestriction.Font = new System.Drawing.Font("微软雅黑", 10F);
            this._txtRestriction.Location = new System.Drawing.Point(128, 155);
            this._txtRestriction.Multiline = true;
            this._txtRestriction.Name = "_txtRestriction";
            this._txtRestriction.Size = new System.Drawing.Size(684, 23);
            this._txtRestriction.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label4.Location = new System.Drawing.Point(49, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "查询限制";
            // 
            // _cbConnectionString
            // 
            this._cbConnectionString.BackColor = System.Drawing.Color.White;
            this._cbConnectionString.Font = new System.Drawing.Font("微软雅黑", 10F);
            this._cbConnectionString.FormattingEnabled = true;
            this._cbConnectionString.Items.AddRange(new object[] {
            "SQLServer:Data Source=ip;Uid=user;Pwd=password;Initial Catalog=dbname;",
            "Oracle:Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=ip)(PO" +
                "RT=port)))(CONNECT_DATA=(SERVICE_NAME=servicename)));User Id=user;Password=passw" +
                "ord",
            "MySql:server=ip;Port=port;Uid=root;Pwd=password;DataBase=dbname;Pooling=true;char" +
                "set=utf8;",
            "SQLite:Data Source=path;UTF8Encoding=True;"});
            this._cbConnectionString.Location = new System.Drawing.Point(128, 69);
            this._cbConnectionString.Name = "_cbConnectionString";
            this._cbConnectionString.Size = new System.Drawing.Size(684, 27);
            this._cbConnectionString.TabIndex = 3;
            // 
            // _dgvDataShow
            // 
            this._dgvDataShow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvDataShow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this._dgvDataShow.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this._dgvDataShow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._dgvDataShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvDataShow.Location = new System.Drawing.Point(12, 245);
            this._dgvDataShow.MultiSelect = false;
            this._dgvDataShow.Name = "_dgvDataShow";
            this._dgvDataShow.RowHeadersVisible = false;
            this._dgvDataShow.RowTemplate.Height = 23;
            this._dgvDataShow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvDataShow.Size = new System.Drawing.Size(984, 472);
            this._dgvDataShow.TabIndex = 0;
            // 
            // SchemaViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this._txtRestriction);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._cbNewForm);
            this.Controls.Add(this._cmbCollectionName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._btnQuery);
            this.Controls.Add(this._cbConnectionString);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._cmbDataBaseType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._dgvDataShow);
            this.Controls.Add(this._btnConfirm);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SchemaViewerForm";
            this.Text = "Degage ADO.NET Schema 查看工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SchemaViewerForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this._dgvDataShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _cmbDataBaseType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _btnConfirm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _txtRestriction;
        private System.Windows.Forms.Button _btnQuery;
        private DataGridViewEx _dgvDataShow;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox _cmbCollectionName;
        private System.Windows.Forms.CheckBox _cbNewForm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox _cbConnectionString;
    }
}

