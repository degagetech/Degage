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
            this._btnCannel = new System.Windows.Forms.Button();
            this._btnConfirm = new System.Windows.Forms.Button();
            this._lbHistory = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // _btnCannel
            // 
            this._btnCannel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCannel.Location = new System.Drawing.Point(506, 272);
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
            this._btnConfirm.Location = new System.Drawing.Point(430, 272);
            this._btnConfirm.Name = "_btnConfirm";
            this._btnConfirm.Size = new System.Drawing.Size(65, 30);
            this._btnConfirm.TabIndex = 39;
            this._btnConfirm.Text = "确定";
            this._btnConfirm.UseVisualStyleBackColor = true;
            this._btnConfirm.Click += new System.EventHandler(this._btnConfirm_Click);
            // 
            // _lbHistory
            // 
            this._lbHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lbHistory.BackColor = System.Drawing.SystemColors.Control;
            this._lbHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._lbHistory.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._lbHistory.FormattingEnabled = true;
            this._lbHistory.HorizontalScrollbar = true;
            this._lbHistory.ItemHeight = 20;
            this._lbHistory.Location = new System.Drawing.Point(16, 12);
            this._lbHistory.Name = "_lbHistory";
            this._lbHistory.Size = new System.Drawing.Size(553, 240);
            this._lbHistory.TabIndex = 41;
            this._lbHistory.DoubleClick += new System.EventHandler(this._lbHistory_DoubleClick);
            // 
            // ConnectionStringHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 311);
            this.Controls.Add(this._lbHistory);
            this.Controls.Add(this._btnCannel);
            this.Controls.Add(this._btnConfirm);
            this.MaximizeBox = false;
            this.Name = "ConnectionStringHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "连接记录";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnCannel;
        private System.Windows.Forms.Button _btnConfirm;
        private System.Windows.Forms.ListBox _lbHistory;
    }
}