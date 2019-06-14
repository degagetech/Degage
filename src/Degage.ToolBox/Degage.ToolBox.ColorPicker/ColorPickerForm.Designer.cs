namespace Degage.ToolBox.ColorPicker
{
    partial class ColorPickerForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorPickerForm));
            this._panelColorBoard = new System.Windows.Forms.Panel();
            this._timerCursorPoint = new System.Windows.Forms.Timer(this.components);
            this._labelColorRGBTitle = new System.Windows.Forms.Label();
            this._panelColorBoardBack = new System.Windows.Forms.Panel();
            this._labelPoint = new System.Windows.Forms.Label();
            this._labelColorHEXTitle = new System.Windows.Forms.Label();
            this._labelClose = new System.Windows.Forms.Label();
            this._labelMin = new System.Windows.Forms.Label();
            this._tbRGBColor = new System.Windows.Forms.TextBox();
            this._tbHEXColor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._toolTip = new System.Windows.Forms.ToolTip(this.components);
            this._btnPickingColor = new System.Windows.Forms.Button();
            this._btnCopyHEX = new System.Windows.Forms.Button();
            this._btnCopyRGB = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this._btnTop = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._colorDialog = new System.Windows.Forms.ColorDialog();
            this._flpFiexdColor = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this._panelColorBoardBack.SuspendLayout();
            this._flpFiexdColor.SuspendLayout();
            this.SuspendLayout();
            // 
            // _panelColorBoard
            // 
            this._panelColorBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this._panelColorBoard.Location = new System.Drawing.Point(4, 4);
            this._panelColorBoard.Margin = new System.Windows.Forms.Padding(0);
            this._panelColorBoard.Name = "_panelColorBoard";
            this._panelColorBoard.Size = new System.Drawing.Size(70, 70);
            this._panelColorBoard.TabIndex = 0;
            // 
            // _timerCursorPoint
            // 
            this._timerCursorPoint.Tick += new System.EventHandler(this._timerCursorPoint_Tick);
            // 
            // _labelColorRGBTitle
            // 
            this._labelColorRGBTitle.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this._labelColorRGBTitle.AutoSize = true;
            this._labelColorRGBTitle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._labelColorRGBTitle.ForeColor = System.Drawing.Color.White;
            this._labelColorRGBTitle.Location = new System.Drawing.Point(14, 45);
            this._labelColorRGBTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._labelColorRGBTitle.Name = "_labelColorRGBTitle";
            this._labelColorRGBTitle.Size = new System.Drawing.Size(43, 20);
            this._labelColorRGBTitle.TabIndex = 1;
            this._labelColorRGBTitle.Text = "RGB:";
            // 
            // _panelColorBoardBack
            // 
            this._panelColorBoardBack.BackColor = System.Drawing.Color.White;
            this._panelColorBoardBack.Controls.Add(this._panelColorBoard);
            this._panelColorBoardBack.Location = new System.Drawing.Point(18, 117);
            this._panelColorBoardBack.Margin = new System.Windows.Forms.Padding(0);
            this._panelColorBoardBack.Name = "_panelColorBoardBack";
            this._panelColorBoardBack.Size = new System.Drawing.Size(78, 78);
            this._panelColorBoardBack.TabIndex = 6;
            // 
            // _labelPoint
            // 
            this._labelPoint.AutoSize = true;
            this._labelPoint.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._labelPoint.ForeColor = System.Drawing.Color.White;
            this._labelPoint.Location = new System.Drawing.Point(8, 11);
            this._labelPoint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._labelPoint.Name = "_labelPoint";
            this._labelPoint.Size = new System.Drawing.Size(16, 20);
            this._labelPoint.TabIndex = 7;
            this._labelPoint.Text = "*";
            // 
            // _labelColorHEXTitle
            // 
            this._labelColorHEXTitle.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this._labelColorHEXTitle.AutoSize = true;
            this._labelColorHEXTitle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._labelColorHEXTitle.ForeColor = System.Drawing.Color.White;
            this._labelColorHEXTitle.Location = new System.Drawing.Point(14, 80);
            this._labelColorHEXTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._labelColorHEXTitle.Name = "_labelColorHEXTitle";
            this._labelColorHEXTitle.Size = new System.Drawing.Size(61, 20);
            this._labelColorHEXTitle.TabIndex = 8;
            this._labelColorHEXTitle.Text = "HEX:  #";
            // 
            // _labelClose
            // 
            this._labelClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._labelClose.AutoSize = true;
            this._labelClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this._labelClose.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._labelClose.ForeColor = System.Drawing.Color.White;
            this._labelClose.Location = new System.Drawing.Point(285, 10);
            this._labelClose.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._labelClose.Name = "_labelClose";
            this._labelClose.Size = new System.Drawing.Size(20, 19);
            this._labelClose.TabIndex = 13;
            this._labelClose.Text = "×";
            this._labelClose.Click += new System.EventHandler(this._labelClose_Click);
            // 
            // _labelMin
            // 
            this._labelMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._labelMin.AutoSize = true;
            this._labelMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this._labelMin.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._labelMin.ForeColor = System.Drawing.Color.White;
            this._labelMin.Location = new System.Drawing.Point(264, 10);
            this._labelMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._labelMin.Name = "_labelMin";
            this._labelMin.Size = new System.Drawing.Size(16, 19);
            this._labelMin.TabIndex = 15;
            this._labelMin.Text = "-";
            this._labelMin.Click += new System.EventHandler(this._labelMin_Click);
            // 
            // _tbRGBColor
            // 
            this._tbRGBColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this._tbRGBColor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbRGBColor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._tbRGBColor.ForeColor = System.Drawing.Color.White;
            this._tbRGBColor.Location = new System.Drawing.Point(80, 42);
            this._tbRGBColor.Margin = new System.Windows.Forms.Padding(4);
            this._tbRGBColor.Name = "_tbRGBColor";
            this._tbRGBColor.Size = new System.Drawing.Size(97, 24);
            this._tbRGBColor.TabIndex = 16;
            this._tbRGBColor.TextChanged += new System.EventHandler(this._tbRGBColor_TextChanged);
            // 
            // _tbHEXColor
            // 
            this._tbHEXColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this._tbHEXColor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tbHEXColor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._tbHEXColor.ForeColor = System.Drawing.Color.White;
            this._tbHEXColor.Location = new System.Drawing.Point(80, 77);
            this._tbHEXColor.Margin = new System.Windows.Forms.Padding(4);
            this._tbHEXColor.Name = "_tbHEXColor";
            this._tbHEXColor.Size = new System.Drawing.Size(97, 24);
            this._tbHEXColor.TabIndex = 17;
            this._tbHEXColor.TextChanged += new System.EventHandler(this._tbHEXColor_TextChanged);
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 20);
            this.label1.TabIndex = 18;
            this.label1.Tag = "#1ABC9C";
            this._toolTip.SetToolTip(this.label1, "绿松石");
            this.label1.Click += new System.EventHandler(this.SelectedFixedColor);
            // 
            // label2
            // 
            this.label2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.label2.Location = new System.Drawing.Point(30, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 20);
            this.label2.TabIndex = 19;
            this._toolTip.SetToolTip(this.label2, "绿海");
            this.label2.Click += new System.EventHandler(this.SelectedFixedColor);
            // 
            // label3
            // 
            this.label3.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.label3.Location = new System.Drawing.Point(55, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 20);
            this.label3.TabIndex = 20;
            this.label3.Click += new System.EventHandler(this.SelectedFixedColor);
            // 
            // _toolTip
            // 
            this._toolTip.BackColor = System.Drawing.Color.White;
            this._toolTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            // 
            // _btnPickingColor
            // 
            this._btnPickingColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnPickingColor.FlatAppearance.BorderSize = 0;
            this._btnPickingColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnPickingColor.Image = global::Degage.ToolBox.ColorPicker.Properties.Resources.Collimation;
            this._btnPickingColor.Location = new System.Drawing.Point(258, 200);
            this._btnPickingColor.Margin = new System.Windows.Forms.Padding(0);
            this._btnPickingColor.Name = "_btnPickingColor";
            this._btnPickingColor.Size = new System.Drawing.Size(45, 40);
            this._btnPickingColor.TabIndex = 24;
            this._toolTip.SetToolTip(this._btnPickingColor, "选取颜色，进入后按下 ESC 可取消");
            this._btnPickingColor.UseVisualStyleBackColor = true;
            this._btnPickingColor.Click += new System.EventHandler(this._btnCollimationColor_Click);
            // 
            // _btnCopyHEX
            // 
            this._btnCopyHEX.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnCopyHEX.FlatAppearance.BorderSize = 0;
            this._btnCopyHEX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnCopyHEX.Image = global::Degage.ToolBox.ColorPicker.Properties.Resources.Copy;
            this._btnCopyHEX.Location = new System.Drawing.Point(190, 69);
            this._btnCopyHEX.Margin = new System.Windows.Forms.Padding(0);
            this._btnCopyHEX.Name = "_btnCopyHEX";
            this._btnCopyHEX.Size = new System.Drawing.Size(30, 30);
            this._btnCopyHEX.TabIndex = 25;
            this._toolTip.SetToolTip(this._btnCopyHEX, "复制");
            this._btnCopyHEX.UseVisualStyleBackColor = true;
            this._btnCopyHEX.Click += new System.EventHandler(this._btnCopyHEX_Click);
            // 
            // _btnCopyRGB
            // 
            this._btnCopyRGB.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnCopyRGB.FlatAppearance.BorderSize = 0;
            this._btnCopyRGB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnCopyRGB.Image = global::Degage.ToolBox.ColorPicker.Properties.Resources.Copy;
            this._btnCopyRGB.Location = new System.Drawing.Point(190, 32);
            this._btnCopyRGB.Margin = new System.Windows.Forms.Padding(0);
            this._btnCopyRGB.Name = "_btnCopyRGB";
            this._btnCopyRGB.Size = new System.Drawing.Size(30, 30);
            this._btnCopyRGB.TabIndex = 26;
            this._toolTip.SetToolTip(this._btnCopyRGB, "复制");
            this._btnCopyRGB.UseVisualStyleBackColor = true;
            this._btnCopyRGB.Click += new System.EventHandler(this._btnCopyRGB_Click);
            // 
            // label5
            // 
            this.label5.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.label5.Location = new System.Drawing.Point(105, 5);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 20);
            this.label5.TabIndex = 24;
            this.label5.Tag = "#1ABC9C";
            this._toolTip.SetToolTip(this.label5, "彼得河");
            this.label5.Click += new System.EventHandler(this.SelectedFixedColor);
            // 
            // label7
            // 
            this.label7.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.label7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.label7.Location = new System.Drawing.Point(155, 5);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 20);
            this.label7.TabIndex = 26;
            this._toolTip.SetToolTip(this.label7, "紫晶");
            this.label7.Click += new System.EventHandler(this.SelectedFixedColor);
            // 
            // label8
            // 
            this.label8.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.label8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.label8.Location = new System.Drawing.Point(5, 30);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 20);
            this.label8.TabIndex = 27;
            this._toolTip.SetToolTip(this.label8, "紫藤");
            this.label8.Click += new System.EventHandler(this.SelectedFixedColor);
            // 
            // label10
            // 
            this.label10.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.label10.Location = new System.Drawing.Point(55, 30);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 20);
            this.label10.TabIndex = 29;
            this._toolTip.SetToolTip(this.label10, "午夜蓝");
            this.label10.Click += new System.EventHandler(this.SelectedFixedColor);
            // 
            // label11
            // 
            this.label11.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.label11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.label11.Location = new System.Drawing.Point(80, 30);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 20);
            this.label11.TabIndex = 30;
            this._toolTip.SetToolTip(this.label11, "太阳花");
            this.label11.Click += new System.EventHandler(this.SelectedFixedColor);
            // 
            // label12
            // 
            this.label12.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.label12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.label12.Location = new System.Drawing.Point(105, 30);
            this.label12.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 20);
            this.label12.TabIndex = 31;
            this._toolTip.SetToolTip(this.label12, "橙子");
            this.label12.Click += new System.EventHandler(this.SelectedFixedColor);
            // 
            // label13
            // 
            this.label13.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.label13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.label13.Location = new System.Drawing.Point(130, 30);
            this.label13.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 20);
            this.label13.TabIndex = 32;
            this.label13.Tag = "#1ABC9C";
            this._toolTip.SetToolTip(this.label13, "胡萝卜");
            this.label13.Click += new System.EventHandler(this.SelectedFixedColor);
            // 
            // label14
            // 
            this.label14.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.label14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.label14.Location = new System.Drawing.Point(155, 30);
            this.label14.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(20, 20);
            this.label14.TabIndex = 33;
            this._toolTip.SetToolTip(this.label14, "南瓜");
            this.label14.Click += new System.EventHandler(this.SelectedFixedColor);
            // 
            // label16
            // 
            this.label16.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.label16.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.label16.Location = new System.Drawing.Point(30, 55);
            this.label16.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(20, 20);
            this.label16.TabIndex = 35;
            this._toolTip.SetToolTip(this.label16, "石榴");
            this.label16.Click += new System.EventHandler(this.SelectedFixedColor);
            // 
            // _btnTop
            // 
            this._btnTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnTop.AutoSize = true;
            this._btnTop.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnTop.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._btnTop.ForeColor = System.Drawing.Color.White;
            this._btnTop.Image = global::Degage.ToolBox.ColorPicker.Properties.Resources.NoPin;
            this._btnTop.Location = new System.Drawing.Point(17, 212);
            this._btnTop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._btnTop.Name = "_btnTop";
            this._btnTop.Size = new System.Drawing.Size(20, 19);
            this._btnTop.TabIndex = 29;
            this._btnTop.Text = "×";
            this._toolTip.SetToolTip(this._btnTop, "将程序固定在其他程序上层");
            this._btnTop.Click += new System.EventHandler(this._btnTop_Click);
            // 
            // label4
            // 
            this.label4.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.label4.Location = new System.Drawing.Point(80, 5);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 20);
            this.label4.TabIndex = 23;
            this.label4.Click += new System.EventHandler(this.SelectedFixedColor);
            // 
            // _flpFiexdColor
            // 
            this._flpFiexdColor.Controls.Add(this.label1);
            this._flpFiexdColor.Controls.Add(this.label2);
            this._flpFiexdColor.Controls.Add(this.label3);
            this._flpFiexdColor.Controls.Add(this.label4);
            this._flpFiexdColor.Controls.Add(this.label5);
            this._flpFiexdColor.Controls.Add(this.label6);
            this._flpFiexdColor.Controls.Add(this.label7);
            this._flpFiexdColor.Controls.Add(this.label8);
            this._flpFiexdColor.Controls.Add(this.label9);
            this._flpFiexdColor.Controls.Add(this.label10);
            this._flpFiexdColor.Controls.Add(this.label11);
            this._flpFiexdColor.Controls.Add(this.label12);
            this._flpFiexdColor.Controls.Add(this.label13);
            this._flpFiexdColor.Controls.Add(this.label14);
            this._flpFiexdColor.Controls.Add(this.label15);
            this._flpFiexdColor.Controls.Add(this.label16);
            this._flpFiexdColor.Controls.Add(this.label17);
            this._flpFiexdColor.Controls.Add(this.label18);
            this._flpFiexdColor.Controls.Add(this.label19);
            this._flpFiexdColor.Location = new System.Drawing.Point(128, 113);
            this._flpFiexdColor.Margin = new System.Windows.Forms.Padding(0);
            this._flpFiexdColor.Name = "_flpFiexdColor";
            this._flpFiexdColor.Size = new System.Drawing.Size(177, 82);
            this._flpFiexdColor.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.label6.Location = new System.Drawing.Point(130, 5);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 20);
            this.label6.TabIndex = 25;
            this.label6.Click += new System.EventHandler(this.SelectedFixedColor);
            // 
            // label9
            // 
            this.label9.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.label9.Location = new System.Drawing.Point(30, 30);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 20);
            this.label9.TabIndex = 28;
            this.label9.Tag = "#1ABC9C";
            this.label9.Click += new System.EventHandler(this.SelectedFixedColor);
            // 
            // label15
            // 
            this.label15.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.label15.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.label15.Location = new System.Drawing.Point(5, 55);
            this.label15.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(20, 20);
            this.label15.TabIndex = 34;
            this.label15.Click += new System.EventHandler(this.SelectedFixedColor);
            // 
            // label17
            // 
            this.label17.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(241)))), ((int)(((byte)(240)))));
            this.label17.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label17.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.label17.Location = new System.Drawing.Point(55, 55);
            this.label17.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(20, 20);
            this.label17.TabIndex = 36;
            this.label17.Click += new System.EventHandler(this.SelectedFixedColor);
            // 
            // label18
            // 
            this.label18.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.label18.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label18.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.label18.Location = new System.Drawing.Point(80, 55);
            this.label18.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(20, 20);
            this.label18.TabIndex = 37;
            this.label18.Click += new System.EventHandler(this.SelectedFixedColor);
            // 
            // label19
            // 
            this.label19.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.label19.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label19.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.label19.Location = new System.Drawing.Point(105, 55);
            this.label19.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(20, 20);
            this.label19.TabIndex = 38;
            this.label19.Click += new System.EventHandler(this.SelectedFixedColor);
            // 
            // ColorPickerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(314, 244);
            this.Controls.Add(this._btnTop);
            this.Controls.Add(this._btnPickingColor);
            this.Controls.Add(this._flpFiexdColor);
            this.Controls.Add(this._btnCopyRGB);
            this.Controls.Add(this._btnCopyHEX);
            this.Controls.Add(this._tbHEXColor);
            this.Controls.Add(this._tbRGBColor);
            this.Controls.Add(this._labelMin);
            this.Controls.Add(this._labelClose);
            this.Controls.Add(this._labelColorHEXTitle);
            this.Controls.Add(this._labelPoint);
            this.Controls.Add(this._panelColorBoardBack);
            this.Controls.Add(this._labelColorRGBTitle);
            this.Font = new System.Drawing.Font("微软雅黑 Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "ColorPickerForm";
            this.Text = "ColorPicker";
            this.Activated += new System.EventHandler(this.ColorPickerForm_Activated);
            this._panelColorBoardBack.ResumeLayout(false);
            this._flpFiexdColor.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel _panelColorBoard;
        private System.Windows.Forms.Timer _timerCursorPoint;
        private System.Windows.Forms.Label _labelColorRGBTitle;
        private System.Windows.Forms.Panel _panelColorBoardBack;
        private System.Windows.Forms.Label _labelPoint;
        private System.Windows.Forms.Label _labelColorHEXTitle;
        private System.Windows.Forms.Label _labelClose;
        private System.Windows.Forms.Label _labelMin;
        private System.Windows.Forms.TextBox _tbRGBColor;
        private System.Windows.Forms.TextBox _tbHEXColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip _toolTip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button _btnPickingColor;
        private System.Windows.Forms.Button _btnCopyHEX;
        private System.Windows.Forms.Button _btnCopyRGB;
        private System.Windows.Forms.ColorDialog _colorDialog;
        private System.Windows.Forms.FlowLayoutPanel _flpFiexdColor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label _btnTop;
    }
}

