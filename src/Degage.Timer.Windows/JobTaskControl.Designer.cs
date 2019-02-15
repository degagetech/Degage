namespace Degage.Timer.Windows
{
    partial class JobTaskControl
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
            this._tbTaskDesc = new System.Windows.Forms.TextBox();
            this._tbTaskName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.line1 = new Degage.Timer.Windows.Line();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._tbTaskParameter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._rbScheduleIgnore = new System.Windows.Forms.RadioButton();
            this._rbScheduleQueue = new System.Windows.Forms.RadioButton();
            this._rbScheduleParallel = new System.Windows.Forms.RadioButton();
            this._toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this._numJobTimeout = new System.Windows.Forms.NumericUpDown();
            this.jobTriggerControl1 = new Degage.Timer.Windows.JobTriggerControl();
            ((System.ComponentModel.ISupportInitialize)(this._numJobTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // _tbTaskDesc
            // 
            this._tbTaskDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tbTaskDesc.BackColor = System.Drawing.Color.White;
            this._tbTaskDesc.Location = new System.Drawing.Point(85, 54);
            this._tbTaskDesc.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._tbTaskDesc.Name = "_tbTaskDesc";
            this._tbTaskDesc.Size = new System.Drawing.Size(398, 23);
            this._tbTaskDesc.TabIndex = 1;
            // 
            // _tbTaskName
            // 
            this._tbTaskName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tbTaskName.BackColor = System.Drawing.Color.White;
            this._tbTaskName.Location = new System.Drawing.Point(85, 14);
            this._tbTaskName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._tbTaskName.Name = "_tbTaskName";
            this._tbTaskName.Size = new System.Drawing.Size(398, 23);
            this._tbTaskName.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 56);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "任务描述";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "任务名称";
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
            this.line1.LineLength = 506;
            this.line1.LineWidth = 1;
            this.line1.Location = new System.Drawing.Point(2, 207);
            this.line1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(506, 1);
            this.line1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 220);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "触发模式";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 19);
            this.label2.TabIndex = 12;
            this.label2.Text = "任务参数";
            this._toolTip.SetToolTip(this.label2, "此任务参数会在传递至正在执行的作业");
            // 
            // _tbTaskParameter
            // 
            this._tbTaskParameter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tbTaskParameter.BackColor = System.Drawing.Color.White;
            this._tbTaskParameter.Location = new System.Drawing.Point(85, 95);
            this._tbTaskParameter.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._tbTaskParameter.Name = "_tbTaskParameter";
            this._tbTaskParameter.Size = new System.Drawing.Size(398, 23);
            this._tbTaskParameter.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 134);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 19);
            this.label5.TabIndex = 14;
            this.label5.Text = "调度模式";
            this._toolTip.SetToolTip(this.label5, "表示已有作业执行时，对于后续的调度请求应该如何处理");
            // 
            // _rbScheduleIgnore
            // 
            this._rbScheduleIgnore.AutoSize = true;
            this._rbScheduleIgnore.Image = global::Degage.Timer.Windows.Properties.Resources.schedule_ignore_16x16;
            this._rbScheduleIgnore.Location = new System.Drawing.Point(88, 135);
            this._rbScheduleIgnore.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._rbScheduleIgnore.Name = "_rbScheduleIgnore";
            this._rbScheduleIgnore.Size = new System.Drawing.Size(69, 23);
            this._rbScheduleIgnore.TabIndex = 18;
            this._rbScheduleIgnore.TabStop = true;
            this._rbScheduleIgnore.Text = "忽略";
            this._rbScheduleIgnore.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._toolTip.SetToolTip(this._rbScheduleIgnore, "当已有作业在执行时，则忽略后续的任务调度请求");
            this._rbScheduleIgnore.UseVisualStyleBackColor = true;
            // 
            // _rbScheduleQueue
            // 
            this._rbScheduleQueue.AutoSize = true;
            this._rbScheduleQueue.Image = global::Degage.Timer.Windows.Properties.Resources.schedule_queue_16x16;
            this._rbScheduleQueue.Location = new System.Drawing.Point(185, 135);
            this._rbScheduleQueue.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._rbScheduleQueue.Name = "_rbScheduleQueue";
            this._rbScheduleQueue.Size = new System.Drawing.Size(69, 23);
            this._rbScheduleQueue.TabIndex = 17;
            this._rbScheduleQueue.TabStop = true;
            this._rbScheduleQueue.Text = "队列";
            this._rbScheduleQueue.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._toolTip.SetToolTip(this._rbScheduleQueue, "当已有作业在执行时，后续的调度请求会被依次添加到待执行队列中");
            this._rbScheduleQueue.UseVisualStyleBackColor = true;
            // 
            // _rbScheduleParallel
            // 
            this._rbScheduleParallel.AutoSize = true;
            this._rbScheduleParallel.Image = global::Degage.Timer.Windows.Properties.Resources.schedule_parallel_16x16;
            this._rbScheduleParallel.Location = new System.Drawing.Point(282, 135);
            this._rbScheduleParallel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._rbScheduleParallel.Name = "_rbScheduleParallel";
            this._rbScheduleParallel.Size = new System.Drawing.Size(69, 23);
            this._rbScheduleParallel.TabIndex = 16;
            this._rbScheduleParallel.TabStop = true;
            this._rbScheduleParallel.Text = "并行";
            this._rbScheduleParallel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._toolTip.SetToolTip(this._rbScheduleParallel, "当已有作业在执行时，后续的调度请求会与其并行执行");
            this._rbScheduleParallel.UseVisualStyleBackColor = true;
            // 
            // _toolTip
            // 
            this._toolTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this._toolTip.ForeColor = System.Drawing.Color.White;
            this._toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this._toolTip.ToolTipTitle = "提示";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 173);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 19);
            this.label6.TabIndex = 19;
            this.label6.Text = "作业限时";
            this._toolTip.SetToolTip(this.label6, "表示作业最大的执行时间（单位：秒），一旦超出此时间，作业会被强制中断");
            // 
            // _numJobTimeout
            // 
            this._numJobTimeout.BackColor = System.Drawing.Color.White;
            this._numJobTimeout.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this._numJobTimeout.Location = new System.Drawing.Point(88, 172);
            this._numJobTimeout.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._numJobTimeout.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this._numJobTimeout.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this._numJobTimeout.Name = "_numJobTimeout";
            this._numJobTimeout.Size = new System.Drawing.Size(93, 23);
            this._numJobTimeout.TabIndex = 3;
            this._numJobTimeout.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // jobTriggerControl1
            // 
            this.jobTriggerControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.jobTriggerControl1.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.jobTriggerControl1.Location = new System.Drawing.Point(34, 248);
            this.jobTriggerControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.jobTriggerControl1.Name = "jobTriggerControl1";
            this.jobTriggerControl1.Size = new System.Drawing.Size(449, 34);
            this.jobTriggerControl1.TabIndex = 20;
            // 
            // JobTaskControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.jobTriggerControl1);
            this.Controls.Add(this._numJobTimeout);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._rbScheduleIgnore);
            this.Controls.Add(this._rbScheduleQueue);
            this.Controls.Add(this._rbScheduleParallel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._tbTaskParameter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.line1);
            this.Controls.Add(this._tbTaskDesc);
            this.Controls.Add(this._tbTaskName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "JobTaskControl";
            this.Size = new System.Drawing.Size(506, 340);
            ((System.ComponentModel.ISupportInitialize)(this._numJobTimeout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _tbTaskDesc;
        private System.Windows.Forms.TextBox _tbTaskName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Line line1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _tbTaskParameter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton _rbScheduleParallel;
        private System.Windows.Forms.RadioButton _rbScheduleQueue;
        private System.Windows.Forms.RadioButton _rbScheduleIgnore;
        private System.Windows.Forms.ToolTip _toolTip;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown _numJobTimeout;
        private JobTriggerControl jobTriggerControl1;
    }
}
