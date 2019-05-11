namespace Degage.DataModel.Schema.Toolbox
{
    partial class CodeExportConfigControl
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
            this.components = new System.ComponentModel.Container();
            this._cbTypeMapConfig = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._cbCodeTemplate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this._btnEditorConnectionString = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this._tbNamespace = new System.Windows.Forms.TextBox();
            this._flpContentSymbol = new System.Windows.Forms.FlowLayoutPanel();
            this._toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _cbTypeMapConfig
            // 
            this._cbTypeMapConfig.BackColor = System.Drawing.Color.White;
            this._cbTypeMapConfig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbTypeMapConfig.Font = new System.Drawing.Font("微软雅黑", 10F);
            this._cbTypeMapConfig.FormattingEnabled = true;
            this._cbTypeMapConfig.Location = new System.Drawing.Point(120, 16);
            this._cbTypeMapConfig.Name = "_cbTypeMapConfig";
            this._cbTypeMapConfig.Size = new System.Drawing.Size(349, 27);
            this._cbTypeMapConfig.TabIndex = 4;
            this._cbTypeMapConfig.SelectedIndexChanged += new System.EventHandler(this._cbTypeMapConfig_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "类型映射配置";
            // 
            // _cbCodeTemplate
            // 
            this._cbCodeTemplate.BackColor = System.Drawing.Color.White;
            this._cbCodeTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbCodeTemplate.Font = new System.Drawing.Font("微软雅黑", 10F);
            this._cbCodeTemplate.FormattingEnabled = true;
            this._cbCodeTemplate.Location = new System.Drawing.Point(120, 59);
            this._cbCodeTemplate.Name = "_cbCodeTemplate";
            this._cbCodeTemplate.Size = new System.Drawing.Size(349, 27);
            this._cbCodeTemplate.TabIndex = 6;
            this._cbCodeTemplate.SelectedIndexChanged += new System.EventHandler(this._cbCodeTemplate_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.Location = new System.Drawing.Point(37, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "代码模板";
            // 
            // _btnEditorConnectionString
            // 
            this._btnEditorConnectionString.Location = new System.Drawing.Point(482, 12);
            this._btnEditorConnectionString.Name = "_btnEditorConnectionString";
            this._btnEditorConnectionString.Size = new System.Drawing.Size(70, 30);
            this._btnEditorConnectionString.TabIndex = 8;
            this._btnEditorConnectionString.Text = "编辑...";
            this._btnEditorConnectionString.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(482, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 30);
            this.button1.TabIndex = 9;
            this.button1.Text = "编辑...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.Location = new System.Drawing.Point(37, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "命名空间";
            // 
            // _tbNamespace
            // 
            this._tbNamespace.Font = new System.Drawing.Font("微软雅黑", 10F);
            this._tbNamespace.Location = new System.Drawing.Point(120, 102);
            this._tbNamespace.Name = "_tbNamespace";
            this._tbNamespace.Size = new System.Drawing.Size(349, 25);
            this._tbNamespace.TabIndex = 11;
            this._tbNamespace.Text = "Degage.DataModel";
            this._tbNamespace.TextChanged += new System.EventHandler(this._tbNamespace_TextChanged);
            // 
            // _flpContentSymbol
            // 
            this._flpContentSymbol.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._flpContentSymbol.AutoScroll = true;
            this._flpContentSymbol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._flpContentSymbol.Location = new System.Drawing.Point(578, 44);
            this._flpContentSymbol.Name = "_flpContentSymbol";
            this._flpContentSymbol.Size = new System.Drawing.Size(312, 84);
            this._flpContentSymbol.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.Location = new System.Drawing.Point(560, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "目前支持的代码模板内容符号：";
            // 
            // CodeExportConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this._flpContentSymbol);
            this.Controls.Add(this._tbNamespace);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._btnEditorConnectionString);
            this.Controls.Add(this._cbCodeTemplate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._cbTypeMapConfig);
            this.Controls.Add(this.label1);
            this.Name = "CodeExportConfigControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox _cbTypeMapConfig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _cbCodeTemplate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _btnEditorConnectionString;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _tbNamespace;
        private System.Windows.Forms.FlowLayoutPanel _flpContentSymbol;
        private System.Windows.Forms.ToolTip _toolTip;
        private System.Windows.Forms.Label label4;
    }
}
