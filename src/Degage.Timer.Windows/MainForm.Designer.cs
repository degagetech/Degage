namespace Degage.Timer.Windows
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._tvJobTaskList = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this._splitMain = new System.Windows.Forms.SplitContainer();
            this._btnDeleteJobTask = new System.Windows.Forms.Button();
            this._btnAddJobTask = new System.Windows.Forms.Button();
            this._ctlJobViewContainer = new Degage.Timer.Windows.JobViewContainerControl();
            this.line1 = new Degage.Timer.Windows.Line();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._ctlJobTaskView = new Degage.Timer.Windows.JobTaskControl();
            this._toolTip = new System.Windows.Forms.ToolTip(this.components);
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._tsmiView = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmiLog = new System.Windows.Forms.ToolStripMenuItem();
            this._statusStrip = new System.Windows.Forms.StatusStrip();
            this._lblTipInfo = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this._splitMain)).BeginInit();
            this._splitMain.Panel1.SuspendLayout();
            this._splitMain.Panel2.SuspendLayout();
            this._splitMain.SuspendLayout();
            this._menuStrip.SuspendLayout();
            this._statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tvJobTaskList
            // 
            this._tvJobTaskList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tvJobTaskList.BackColor = System.Drawing.Color.White;
            this._tvJobTaskList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this._tvJobTaskList.ItemHeight = 25;
            this._tvJobTaskList.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this._tvJobTaskList.Location = new System.Drawing.Point(7, 34);
            this._tvJobTaskList.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._tvJobTaskList.Name = "_tvJobTaskList";
            this._tvJobTaskList.Size = new System.Drawing.Size(321, 487);
            this._tvJobTaskList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoEllipsis = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "作业任务";
            // 
            // _splitMain
            // 
            this._splitMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._splitMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this._splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this._splitMain.Location = new System.Drawing.Point(0, 29);
            this._splitMain.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._splitMain.Name = "_splitMain";
            // 
            // _splitMain.Panel1
            // 
            this._splitMain.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this._splitMain.Panel1.Controls.Add(this._btnDeleteJobTask);
            this._splitMain.Panel1.Controls.Add(this._btnAddJobTask);
            this._splitMain.Panel1.Controls.Add(this._tvJobTaskList);
            this._splitMain.Panel1.Controls.Add(this.label1);
            this._splitMain.Panel1MinSize = 300;
            // 
            // _splitMain.Panel2
            // 
            this._splitMain.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this._splitMain.Panel2.Controls.Add(this._ctlJobViewContainer);
            this._splitMain.Panel2.Controls.Add(this.line1);
            this._splitMain.Panel2.Controls.Add(this.label3);
            this._splitMain.Panel2.Controls.Add(this.label2);
            this._splitMain.Panel2.Controls.Add(this._ctlJobTaskView);
            this._splitMain.Panel2MinSize = 650;
            this._splitMain.Size = new System.Drawing.Size(1193, 558);
            this._splitMain.SplitterDistance = 335;
            this._splitMain.SplitterWidth = 2;
            this._splitMain.TabIndex = 2;
            // 
            // _btnDeleteJobTask
            // 
            this._btnDeleteJobTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnDeleteJobTask.BackColor = System.Drawing.Color.White;
            this._btnDeleteJobTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnDeleteJobTask.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._btnDeleteJobTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnDeleteJobTask.Image = global::Degage.Timer.Windows.Properties.Resources.delete_jobtask_16x16;
            this._btnDeleteJobTask.Location = new System.Drawing.Point(35, 526);
            this._btnDeleteJobTask.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._btnDeleteJobTask.Name = "_btnDeleteJobTask";
            this._btnDeleteJobTask.Size = new System.Drawing.Size(23, 26);
            this._btnDeleteJobTask.TabIndex = 3;
            this._toolTip.SetToolTip(this._btnDeleteJobTask, "删除作业任务");
            this._btnDeleteJobTask.UseVisualStyleBackColor = false;
            // 
            // _btnAddJobTask
            // 
            this._btnAddJobTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnAddJobTask.BackColor = System.Drawing.Color.White;
            this._btnAddJobTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnAddJobTask.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._btnAddJobTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnAddJobTask.Image = global::Degage.Timer.Windows.Properties.Resources.add_jobtask_16x16;
            this._btnAddJobTask.Location = new System.Drawing.Point(7, 526);
            this._btnAddJobTask.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._btnAddJobTask.Name = "_btnAddJobTask";
            this._btnAddJobTask.Size = new System.Drawing.Size(23, 26);
            this._btnAddJobTask.TabIndex = 2;
            this._toolTip.SetToolTip(this._btnAddJobTask, "新增作业任务");
            this._btnAddJobTask.UseVisualStyleBackColor = false;
            // 
            // _ctlJobViewContainer
            // 
            this._ctlJobViewContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._ctlJobViewContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this._ctlJobViewContainer.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._ctlJobViewContainer.Location = new System.Drawing.Point(2, 405);
            this._ctlJobViewContainer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._ctlJobViewContainer.Name = "_ctlJobViewContainer";
            this._ctlJobViewContainer.Size = new System.Drawing.Size(686, 150);
            this._ctlJobViewContainer.TabIndex = 10;
            // 
            // line1
            // 
            this.line1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.line1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.line1.CustomBursh = null;
            this.line1.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.line1.IsVertical = false;
            this.line1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.line1.LineLength = 865;
            this.line1.LineWidth = 1;
            this.line1.Location = new System.Drawing.Point(3, 380);
            this.line1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(865, 1);
            this.line1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoEllipsis = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.label3.Location = new System.Drawing.Point(6, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(601, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "任务信息";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoEllipsis = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.label2.Location = new System.Drawing.Point(6, 385);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(601, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "作业视图";
            // 
            // _ctlJobTaskView
            // 
            this._ctlJobTaskView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._ctlJobTaskView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this._ctlJobTaskView.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._ctlJobTaskView.Location = new System.Drawing.Point(2, 34);
            this._ctlJobTaskView.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this._ctlJobTaskView.Name = "_ctlJobTaskView";
            this._ctlJobTaskView.Size = new System.Drawing.Size(688, 340);
            this._ctlJobTaskView.TabIndex = 0;
            // 
            // _toolTip
            // 
            this._toolTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this._toolTip.ForeColor = System.Drawing.Color.White;
            this._toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this._toolTip.ToolTipTitle = "提示";
            // 
            // _menuStrip
            // 
            this._menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this._menuStrip.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.28571F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsmiView,
            this._tsmiLog});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this._menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this._menuStrip.Size = new System.Drawing.Size(1025, 28);
            this._menuStrip.TabIndex = 4;
            // 
            // _tsmiView
            // 
            this._tsmiView.Name = "_tsmiView";
            this._tsmiView.Size = new System.Drawing.Size(68, 24);
            this._tsmiView.Text = "视图(&V)";
            // 
            // _tsmiLog
            // 
            this._tsmiLog.Name = "_tsmiLog";
            this._tsmiLog.Size = new System.Drawing.Size(66, 24);
            this._tsmiLog.Text = "日志(&L)";
            // 
            // _statusStrip
            // 
            this._statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this._statusStrip.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.28571F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._lblTipInfo});
            this._statusStrip.Location = new System.Drawing.Point(0, 595);
            this._statusStrip.Name = "_statusStrip";
            this._statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 11, 0);
            this._statusStrip.Size = new System.Drawing.Size(1025, 25);
            this._statusStrip.TabIndex = 5;
            // 
            // _lblTipInfo
            // 
            this._lblTipInfo.ForeColor = System.Drawing.Color.White;
            this._lblTipInfo.Name = "_lblTipInfo";
            this._lblTipInfo.Size = new System.Drawing.Size(37, 20);
            this._lblTipInfo.Text = "就绪";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 620);
            this.Controls.Add(this._statusStrip);
            this.Controls.Add(this._splitMain);
            this.Controls.Add(this._menuStrip);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this._menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MinimumSize = new System.Drawing.Size(800, 659);
            this.Name = "MainForm";
            this.Opacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "定时作业";
            this._splitMain.Panel1.ResumeLayout(false);
            this._splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitMain)).EndInit();
            this._splitMain.ResumeLayout(false);
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this._statusStrip.ResumeLayout(false);
            this._statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView _tvJobTaskList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer _splitMain;
        private System.Windows.Forms.Button _btnAddJobTask;
        private System.Windows.Forms.ToolTip _toolTip;
        private System.Windows.Forms.Button _btnDeleteJobTask;
        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.StatusStrip _statusStrip;
        private JobTaskControl _ctlJobTaskView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Line line1;
        private JobViewContainerControl _ctlJobViewContainer;
        private System.Windows.Forms.ToolStripMenuItem _tsmiView;
        private System.Windows.Forms.ToolStripMenuItem _tsmiLog;
        private System.Windows.Forms.ToolStripStatusLabel _lblTipInfo;
    }
}