namespace Degage.Timers.Windows
{
    partial class JobTriggerModeEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JobTriggerModeEditForm));
            this.line4 = new Degage.Timers.Windows.Line();
            this.label12 = new System.Windows.Forms.Label();
            this._pageTriggerModeEdit = new System.Windows.Forms.TabControl();
            this._pageSecond = new System.Windows.Forms.TabPage();
            this.jobSecondTriggerModeEditControl1 = new Degage.Timers.Windows.JobSecondTriggerModeEditControl();
            this._pageMinute = new System.Windows.Forms.TabPage();
            this.jobMinuteTriggerModeEditControl1 = new Degage.Timers.Windows.JobMinuteTriggerModeEditControl();
            this._pageHour = new System.Windows.Forms.TabPage();
            this.jobHourTriggerModeEditControl1 = new Degage.Timers.Windows.JobHourTriggerModeEditControl();
            this._pageDay = new System.Windows.Forms.TabPage();
            this.jobDayTriggerModeEditControl1 = new Degage.Timers.Windows.JobDayTriggerModeEditControl();
            this._pageMonth = new System.Windows.Forms.TabPage();
            this.jobMonthTriggerModeEditControl1 = new Degage.Timers.Windows.JobMonthTriggerModeEditControl();
            this._pageYear = new System.Windows.Forms.TabPage();
            this.jobYearTriggerModeEditControl1 = new Degage.Timers.Windows.JobYearTriggerModeEditControl();
            this._pageExplain = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this._lvTimeTest = new System.Windows.Forms.ListView();
            this._colTestTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colIsTrigger = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._btnDeleteTestTime = new System.Windows.Forms.Button();
            this._btnAddTestTime = new System.Windows.Forms.Button();
            this._btnTestStart = new System.Windows.Forms.Button();
            this._toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this._pageTriggerModeEdit.SuspendLayout();
            this._pageSecond.SuspendLayout();
            this._pageMinute.SuspendLayout();
            this._pageHour.SuspendLayout();
            this._pageDay.SuspendLayout();
            this._pageMonth.SuspendLayout();
            this._pageYear.SuspendLayout();
            this._pageExplain.SuspendLayout();
            this.SuspendLayout();
            // 
            // line4
            // 
            this.line4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.line4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.line4.CustomBursh = null;
            this.line4.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.line4.IsVertical = false;
            this.line4.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.line4.LineLength = 610;
            this.line4.LineWidth = 1;
            this.line4.Location = new System.Drawing.Point(0, 269);
            this.line4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.line4.Name = "line4";
            this.line4.Size = new System.Drawing.Size(610, 1);
            this.line4.TabIndex = 33;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 10.28571F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.label12.Location = new System.Drawing.Point(9, 276);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 20);
            this.label12.TabIndex = 32;
            this.label12.Text = "触发模式：";
            // 
            // _pageTriggerModeEdit
            // 
            this._pageTriggerModeEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pageTriggerModeEdit.Controls.Add(this._pageSecond);
            this._pageTriggerModeEdit.Controls.Add(this._pageMinute);
            this._pageTriggerModeEdit.Controls.Add(this._pageHour);
            this._pageTriggerModeEdit.Controls.Add(this._pageDay);
            this._pageTriggerModeEdit.Controls.Add(this._pageMonth);
            this._pageTriggerModeEdit.Controls.Add(this._pageYear);
            this._pageTriggerModeEdit.Controls.Add(this._pageExplain);
            this._pageTriggerModeEdit.Location = new System.Drawing.Point(9, 7);
            this._pageTriggerModeEdit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._pageTriggerModeEdit.Name = "_pageTriggerModeEdit";
            this._pageTriggerModeEdit.SelectedIndex = 0;
            this._pageTriggerModeEdit.Size = new System.Drawing.Size(591, 255);
            this._pageTriggerModeEdit.TabIndex = 43;
            // 
            // _pageSecond
            // 
            this._pageSecond.Controls.Add(this.jobSecondTriggerModeEditControl1);
            this._pageSecond.Location = new System.Drawing.Point(4, 26);
            this._pageSecond.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._pageSecond.Name = "_pageSecond";
            this._pageSecond.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._pageSecond.Size = new System.Drawing.Size(583, 225);
            this._pageSecond.TabIndex = 0;
            this._pageSecond.Text = "秒";
            this._pageSecond.UseVisualStyleBackColor = true;
            // 
            // jobSecondTriggerModeEditControl1
            // 
            this.jobSecondTriggerModeEditControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.jobSecondTriggerModeEditControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jobSecondTriggerModeEditControl1.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.jobSecondTriggerModeEditControl1.Location = new System.Drawing.Point(2, 3);
            this.jobSecondTriggerModeEditControl1.Margin = new System.Windows.Forms.Padding(0);
            this.jobSecondTriggerModeEditControl1.Name = "jobSecondTriggerModeEditControl1";
            this.jobSecondTriggerModeEditControl1.Size = new System.Drawing.Size(579, 219);
            this.jobSecondTriggerModeEditControl1.TabIndex = 0;
            // 
            // _pageMinute
            // 
            this._pageMinute.Controls.Add(this.jobMinuteTriggerModeEditControl1);
            this._pageMinute.Location = new System.Drawing.Point(4, 26);
            this._pageMinute.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._pageMinute.Name = "_pageMinute";
            this._pageMinute.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._pageMinute.Size = new System.Drawing.Size(583, 225);
            this._pageMinute.TabIndex = 1;
            this._pageMinute.Text = "分";
            this._pageMinute.UseVisualStyleBackColor = true;
            // 
            // jobMinuteTriggerModeEditControl1
            // 
            this.jobMinuteTriggerModeEditControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.jobMinuteTriggerModeEditControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jobMinuteTriggerModeEditControl1.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.jobMinuteTriggerModeEditControl1.Location = new System.Drawing.Point(2, 3);
            this.jobMinuteTriggerModeEditControl1.Margin = new System.Windows.Forms.Padding(0);
            this.jobMinuteTriggerModeEditControl1.Name = "jobMinuteTriggerModeEditControl1";
            this.jobMinuteTriggerModeEditControl1.Size = new System.Drawing.Size(579, 219);
            this.jobMinuteTriggerModeEditControl1.TabIndex = 0;
            // 
            // _pageHour
            // 
            this._pageHour.Controls.Add(this.jobHourTriggerModeEditControl1);
            this._pageHour.Location = new System.Drawing.Point(4, 26);
            this._pageHour.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._pageHour.Name = "_pageHour";
            this._pageHour.Size = new System.Drawing.Size(583, 225);
            this._pageHour.TabIndex = 2;
            this._pageHour.Text = "时";
            this._pageHour.UseVisualStyleBackColor = true;
            // 
            // jobHourTriggerModeEditControl1
            // 
            this.jobHourTriggerModeEditControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.jobHourTriggerModeEditControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jobHourTriggerModeEditControl1.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.jobHourTriggerModeEditControl1.Location = new System.Drawing.Point(0, 0);
            this.jobHourTriggerModeEditControl1.Margin = new System.Windows.Forms.Padding(0);
            this.jobHourTriggerModeEditControl1.Name = "jobHourTriggerModeEditControl1";
            this.jobHourTriggerModeEditControl1.Size = new System.Drawing.Size(583, 225);
            this.jobHourTriggerModeEditControl1.TabIndex = 0;
            // 
            // _pageDay
            // 
            this._pageDay.Controls.Add(this.jobDayTriggerModeEditControl1);
            this._pageDay.Location = new System.Drawing.Point(4, 26);
            this._pageDay.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._pageDay.Name = "_pageDay";
            this._pageDay.Size = new System.Drawing.Size(583, 225);
            this._pageDay.TabIndex = 3;
            this._pageDay.Text = "天";
            this._pageDay.UseVisualStyleBackColor = true;
            // 
            // jobDayTriggerModeEditControl1
            // 
            this.jobDayTriggerModeEditControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.jobDayTriggerModeEditControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jobDayTriggerModeEditControl1.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.jobDayTriggerModeEditControl1.Location = new System.Drawing.Point(0, 0);
            this.jobDayTriggerModeEditControl1.Margin = new System.Windows.Forms.Padding(0);
            this.jobDayTriggerModeEditControl1.Name = "jobDayTriggerModeEditControl1";
            this.jobDayTriggerModeEditControl1.Size = new System.Drawing.Size(583, 225);
            this.jobDayTriggerModeEditControl1.TabIndex = 0;
            // 
            // _pageMonth
            // 
            this._pageMonth.Controls.Add(this.jobMonthTriggerModeEditControl1);
            this._pageMonth.Location = new System.Drawing.Point(4, 26);
            this._pageMonth.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._pageMonth.Name = "_pageMonth";
            this._pageMonth.Size = new System.Drawing.Size(583, 225);
            this._pageMonth.TabIndex = 4;
            this._pageMonth.Text = "月";
            this._pageMonth.UseVisualStyleBackColor = true;
            // 
            // jobMonthTriggerModeEditControl1
            // 
            this.jobMonthTriggerModeEditControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.jobMonthTriggerModeEditControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jobMonthTriggerModeEditControl1.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.jobMonthTriggerModeEditControl1.Location = new System.Drawing.Point(0, 0);
            this.jobMonthTriggerModeEditControl1.Margin = new System.Windows.Forms.Padding(0);
            this.jobMonthTriggerModeEditControl1.Name = "jobMonthTriggerModeEditControl1";
            this.jobMonthTriggerModeEditControl1.Size = new System.Drawing.Size(583, 225);
            this.jobMonthTriggerModeEditControl1.TabIndex = 0;
            // 
            // _pageYear
            // 
            this._pageYear.Controls.Add(this.jobYearTriggerModeEditControl1);
            this._pageYear.Location = new System.Drawing.Point(4, 26);
            this._pageYear.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._pageYear.Name = "_pageYear";
            this._pageYear.Size = new System.Drawing.Size(583, 225);
            this._pageYear.TabIndex = 5;
            this._pageYear.Text = "年";
            this._pageYear.UseVisualStyleBackColor = true;
            // 
            // jobYearTriggerModeEditControl1
            // 
            this.jobYearTriggerModeEditControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.jobYearTriggerModeEditControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jobYearTriggerModeEditControl1.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.jobYearTriggerModeEditControl1.Location = new System.Drawing.Point(0, 0);
            this.jobYearTriggerModeEditControl1.Margin = new System.Windows.Forms.Padding(0);
            this.jobYearTriggerModeEditControl1.Name = "jobYearTriggerModeEditControl1";
            this.jobYearTriggerModeEditControl1.Size = new System.Drawing.Size(583, 225);
            this.jobYearTriggerModeEditControl1.TabIndex = 0;
            // 
            // _pageExplain
            // 
            this._pageExplain.Controls.Add(this.richTextBox1);
            this._pageExplain.Location = new System.Drawing.Point(4, 26);
            this._pageExplain.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._pageExplain.Name = "_pageExplain";
            this._pageExplain.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._pageExplain.Size = new System.Drawing.Size(583, 225);
            this._pageExplain.TabIndex = 6;
            this._pageExplain.Text = "模式说明";
            this._pageExplain.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("微软雅黑", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.richTextBox1.Location = new System.Drawing.Point(2, 3);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(579, 219);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            this.richTextBox1.WordWrap = false;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(12, 337);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(586, 23);
            this.textBox3.TabIndex = 44;
            // 
            // _lvTimeTest
            // 
            this._lvTimeTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._lvTimeTest.BackColor = System.Drawing.Color.White;
            this._lvTimeTest.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._colTestTime,
            this._colIsTrigger});
            this._lvTimeTest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this._lvTimeTest.FullRowSelect = true;
            this._lvTimeTest.GridLines = true;
            this._lvTimeTest.Location = new System.Drawing.Point(12, 369);
            this._lvTimeTest.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._lvTimeTest.Name = "_lvTimeTest";
            this._lvTimeTest.Size = new System.Drawing.Size(228, 156);
            this._lvTimeTest.TabIndex = 45;
            this._lvTimeTest.UseCompatibleStateImageBehavior = false;
            this._lvTimeTest.View = System.Windows.Forms.View.Details;
            // 
            // _colTestTime
            // 
            this._colTestTime.Text = "测试样例";
            this._colTestTime.Width = 159;
            // 
            // _colIsTrigger
            // 
            this._colIsTrigger.Text = "是否触发";
            this._colIsTrigger.Width = 65;
            // 
            // _btnDeleteTestTime
            // 
            this._btnDeleteTestTime.BackColor = System.Drawing.Color.White;
            this._btnDeleteTestTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnDeleteTestTime.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._btnDeleteTestTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnDeleteTestTime.Image = global::Degage.Timers.Windows.Properties.Resources.delete_jobtask_16x16;
            this._btnDeleteTestTime.Location = new System.Drawing.Point(245, 399);
            this._btnDeleteTestTime.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._btnDeleteTestTime.Name = "_btnDeleteTestTime";
            this._btnDeleteTestTime.Size = new System.Drawing.Size(23, 26);
            this._btnDeleteTestTime.TabIndex = 47;
            this._toolTip.SetToolTip(this._btnDeleteTestTime, "移除当前选中的测试时间");
            this._btnDeleteTestTime.UseVisualStyleBackColor = false;
            // 
            // _btnAddTestTime
            // 
            this._btnAddTestTime.BackColor = System.Drawing.Color.White;
            this._btnAddTestTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnAddTestTime.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._btnAddTestTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnAddTestTime.Image = global::Degage.Timers.Windows.Properties.Resources.add_jobtask_16x16;
            this._btnAddTestTime.Location = new System.Drawing.Point(245, 369);
            this._btnAddTestTime.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._btnAddTestTime.Name = "_btnAddTestTime";
            this._btnAddTestTime.Size = new System.Drawing.Size(23, 26);
            this._btnAddTestTime.TabIndex = 46;
            this._toolTip.SetToolTip(this._btnAddTestTime, "添加一个测试时间");
            this._btnAddTestTime.UseVisualStyleBackColor = false;
            // 
            // _btnTestStart
            // 
            this._btnTestStart.BackColor = System.Drawing.Color.White;
            this._btnTestStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnTestStart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._btnTestStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnTestStart.Image = global::Degage.Timers.Windows.Properties.Resources.start_16x16;
            this._btnTestStart.Location = new System.Drawing.Point(245, 429);
            this._btnTestStart.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._btnTestStart.Name = "_btnTestStart";
            this._btnTestStart.Size = new System.Drawing.Size(23, 26);
            this._btnTestStart.TabIndex = 48;
            this._toolTip.SetToolTip(this._btnTestStart, "使用列表中的时间测试是否匹配触发模式");
            this._btnTestStart.UseVisualStyleBackColor = false;
            // 
            // _toolTip
            // 
            this._toolTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this._toolTip.ForeColor = System.Drawing.Color.White;
            this._toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this._toolTip.ToolTipTitle = "提示";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.label9.Location = new System.Drawing.Point(13, 306);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 19);
            this.label9.TabIndex = 49;
            this.label9.Text = "秒";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(37, 303);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(57, 23);
            this.textBox1.TabIndex = 50;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(134, 303);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(57, 23);
            this.textBox2.TabIndex = 52;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.label13.Location = new System.Drawing.Point(110, 306);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(22, 19);
            this.label13.TabIndex = 51;
            this.label13.Text = "分";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.BackColor = System.Drawing.Color.White;
            this.textBox4.Location = new System.Drawing.Point(236, 303);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(57, 23);
            this.textBox4.TabIndex = 54;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.label14.Location = new System.Drawing.Point(212, 306);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(22, 19);
            this.label14.TabIndex = 53;
            this.label14.Text = "时";
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.BackColor = System.Drawing.Color.White;
            this.textBox5.Location = new System.Drawing.Point(338, 303);
            this.textBox5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(57, 23);
            this.textBox5.TabIndex = 56;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.label15.Location = new System.Drawing.Point(313, 306);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(22, 19);
            this.label15.TabIndex = 55;
            this.label15.Text = "天";
            // 
            // textBox6
            // 
            this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox6.BackColor = System.Drawing.Color.White;
            this.textBox6.Location = new System.Drawing.Point(441, 303);
            this.textBox6.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(57, 23);
            this.textBox6.TabIndex = 58;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.label16.Location = new System.Drawing.Point(417, 306);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 19);
            this.label16.TabIndex = 57;
            this.label16.Text = "月";
            // 
            // textBox7
            // 
            this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox7.BackColor = System.Drawing.Color.White;
            this.textBox7.Location = new System.Drawing.Point(541, 303);
            this.textBox7.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(57, 23);
            this.textBox7.TabIndex = 60;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.label17.Location = new System.Drawing.Point(517, 306);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(22, 19);
            this.label17.TabIndex = 59;
            this.label17.Text = "年";
            // 
            // JobTriggerModeEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 533);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this._btnTestStart);
            this.Controls.Add(this._btnDeleteTestTime);
            this.Controls.Add(this._btnAddTestTime);
            this.Controls.Add(this._lvTimeTest);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this._pageTriggerModeEdit);
            this.Controls.Add(this.line4);
            this.Controls.Add(this.label12);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "JobTriggerModeEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "编辑触发模式";
            this.Load += new System.EventHandler(this.JobTriggerModeEditForm_Load);
            this._pageTriggerModeEdit.ResumeLayout(false);
            this._pageSecond.ResumeLayout(false);
            this._pageMinute.ResumeLayout(false);
            this._pageHour.ResumeLayout(false);
            this._pageDay.ResumeLayout(false);
            this._pageMonth.ResumeLayout(false);
            this._pageYear.ResumeLayout(false);
            this._pageExplain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Line line4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabControl _pageTriggerModeEdit;
        private System.Windows.Forms.TabPage _pageSecond;
        private System.Windows.Forms.TabPage _pageMinute;
        private System.Windows.Forms.TabPage _pageHour;
        private System.Windows.Forms.TabPage _pageDay;
        private System.Windows.Forms.TabPage _pageMonth;
        private System.Windows.Forms.TabPage _pageYear;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ListView _lvTimeTest;
        private System.Windows.Forms.ColumnHeader _colTestTime;
        private System.Windows.Forms.ColumnHeader _colIsTrigger;
        private System.Windows.Forms.Button _btnDeleteTestTime;
        private System.Windows.Forms.Button _btnAddTestTime;
        private System.Windows.Forms.Button _btnTestStart;
        private System.Windows.Forms.ToolTip _toolTip;
        private System.Windows.Forms.TabPage _pageExplain;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label17;
        private JobSecondTriggerModeEditControl jobSecondTriggerModeEditControl1;
        private JobMinuteTriggerModeEditControl jobMinuteTriggerModeEditControl1;
        private JobHourTriggerModeEditControl jobHourTriggerModeEditControl1;
        private JobDayTriggerModeEditControl jobDayTriggerModeEditControl1;
        private JobMonthTriggerModeEditControl jobMonthTriggerModeEditControl1;
        private JobYearTriggerModeEditControl jobYearTriggerModeEditControl1;
    }
}