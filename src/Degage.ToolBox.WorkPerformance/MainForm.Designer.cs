namespace WorkPerformance
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._plFunction = new WorkPerformance.PenetrablePanel();
            this._btnSetReceivers = new System.Windows.Forms.Button();
            this._btnEditPerformanceTemplate = new System.Windows.Forms.Button();
            this._btnDownloadAllAttacment = new System.Windows.Forms.Button();
            this._btnAddPerformance = new System.Windows.Forms.Button();
            this._btnDeleteEmail = new System.Windows.Forms.Button();
            this._btnEmailFilter = new System.Windows.Forms.Button();
            this._btnUser = new System.Windows.Forms.Button();
            this._btnSendEmail = new System.Windows.Forms.Button();
            this._btnExit = new System.Windows.Forms.Button();
            this._btnGetEmails = new System.Windows.Forms.Button();
            this._toolTip = new System.Windows.Forms.ToolTip(this.components);
            this._btnEditPerformance = new System.Windows.Forms.Button();
            this._btnRemoveAttachment = new System.Windows.Forms.Button();
            this._btnAddAttachment = new System.Windows.Forms.Button();
            this._btnAddToSendAttachment = new System.Windows.Forms.Button();
            this._btnOpenFile = new System.Windows.Forms.Button();
            this._plContainer = new WorkPerformance.PenetrablePanel();
            this._lbSendAttachments = new WorkPerformance.AttachmentListBox();
            this._lbReceviceAttachments = new WorkPerformance.AttachmentListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._lblAttachment = new System.Windows.Forms.Label();
            this.line1 = new WorkPerformance.Line();
            this._lblSender = new System.Windows.Forms.Label();
            this._lblSubject = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._lblDate = new System.Windows.Forms.Label();
            this._lblTime = new System.Windows.Forms.Label();
            this._imageAttachmentTypes = new System.Windows.Forms.ImageList(this.components);
            this._timerDate = new System.Windows.Forms.Timer(this.components);
            this._ofSelectSendAttachment = new System.Windows.Forms.OpenFileDialog();
            this._sfSavePerformanceFile = new System.Windows.Forms.SaveFileDialog();
            this._lbEmails = new WorkPerformance.EmailListBox();
            this._plFunction.SuspendLayout();
            this._plContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // _plFunction
            // 
            this._plFunction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(226)))), ((int)(((byte)(222)))));
            this._plFunction.Controls.Add(this._btnSetReceivers);
            this._plFunction.Controls.Add(this._btnEditPerformanceTemplate);
            this._plFunction.Controls.Add(this._btnDownloadAllAttacment);
            this._plFunction.Controls.Add(this._btnAddPerformance);
            this._plFunction.Controls.Add(this._btnDeleteEmail);
            this._plFunction.Controls.Add(this._btnEmailFilter);
            this._plFunction.Controls.Add(this._btnUser);
            this._plFunction.Controls.Add(this._btnSendEmail);
            this._plFunction.Controls.Add(this._btnExit);
            this._plFunction.Controls.Add(this._btnGetEmails);
            this._plFunction.EnabledMousePierce = true;
            this._plFunction.Location = new System.Drawing.Point(0, 0);
            this._plFunction.Margin = new System.Windows.Forms.Padding(0);
            this._plFunction.Name = "_plFunction";
            this._plFunction.Size = new System.Drawing.Size(50, 768);
            this._plFunction.TabIndex = 0;
            // 
            // _btnSetReceivers
            // 
            this._btnSetReceivers.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnSetReceivers.FlatAppearance.BorderSize = 0;
            this._btnSetReceivers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnSetReceivers.ForeColor = System.Drawing.Color.White;
            this._btnSetReceivers.Image = global::WorkPerformance.Properties.Resources.Receivers;
            this._btnSetReceivers.Location = new System.Drawing.Point(2, 168);
            this._btnSetReceivers.Margin = new System.Windows.Forms.Padding(0);
            this._btnSetReceivers.Name = "_btnSetReceivers";
            this._btnSetReceivers.Size = new System.Drawing.Size(45, 40);
            this._btnSetReceivers.TabIndex = 9;
            this._toolTip.SetToolTip(this._btnSetReceivers, "设置更多的邮件收信人");
            this._btnSetReceivers.UseVisualStyleBackColor = true;
            this._btnSetReceivers.Click += new System.EventHandler(this._btnSetReceivers_Click);
            // 
            // _btnEditPerformanceTemplate
            // 
            this._btnEditPerformanceTemplate.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnEditPerformanceTemplate.FlatAppearance.BorderSize = 0;
            this._btnEditPerformanceTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnEditPerformanceTemplate.ForeColor = System.Drawing.Color.White;
            this._btnEditPerformanceTemplate.Image = global::WorkPerformance.Properties.Resources.EditPerformanceTemplate;
            this._btnEditPerformanceTemplate.Location = new System.Drawing.Point(2, 450);
            this._btnEditPerformanceTemplate.Margin = new System.Windows.Forms.Padding(0);
            this._btnEditPerformanceTemplate.Name = "_btnEditPerformanceTemplate";
            this._btnEditPerformanceTemplate.Size = new System.Drawing.Size(45, 40);
            this._btnEditPerformanceTemplate.TabIndex = 8;
            this._toolTip.SetToolTip(this._btnEditPerformanceTemplate, "编写一个绩效模板");
            this._btnEditPerformanceTemplate.UseVisualStyleBackColor = true;
            this._btnEditPerformanceTemplate.Click += new System.EventHandler(this._btnEditPerformanceTemplate_Click);
            // 
            // _btnDownloadAllAttacment
            // 
            this._btnDownloadAllAttacment.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnDownloadAllAttacment.FlatAppearance.BorderSize = 0;
            this._btnDownloadAllAttacment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnDownloadAllAttacment.ForeColor = System.Drawing.Color.White;
            this._btnDownloadAllAttacment.Image = global::WorkPerformance.Properties.Resources.DownloadAllAttachment;
            this._btnDownloadAllAttacment.Location = new System.Drawing.Point(2, 269);
            this._btnDownloadAllAttacment.Margin = new System.Windows.Forms.Padding(0);
            this._btnDownloadAllAttacment.Name = "_btnDownloadAllAttacment";
            this._btnDownloadAllAttacment.Size = new System.Drawing.Size(45, 40);
            this._btnDownloadAllAttacment.TabIndex = 7;
            this._toolTip.SetToolTip(this._btnDownloadAllAttacment, "下载列表中所有邮件的附件文件到发信附件中");
            this._btnDownloadAllAttacment.UseVisualStyleBackColor = true;
            this._btnDownloadAllAttacment.Click += new System.EventHandler(this._btnDownloadAllAttacment_Click);
            // 
            // _btnAddPerformance
            // 
            this._btnAddPerformance.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnAddPerformance.FlatAppearance.BorderSize = 0;
            this._btnAddPerformance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnAddPerformance.ForeColor = System.Drawing.Color.White;
            this._btnAddPerformance.Image = global::WorkPerformance.Properties.Resources.AddPerformance;
            this._btnAddPerformance.Location = new System.Drawing.Point(2, 400);
            this._btnAddPerformance.Margin = new System.Windows.Forms.Padding(0);
            this._btnAddPerformance.Name = "_btnAddPerformance";
            this._btnAddPerformance.Size = new System.Drawing.Size(45, 40);
            this._btnAddPerformance.TabIndex = 6;
            this._toolTip.SetToolTip(this._btnAddPerformance, "开始编写一份绩效文件");
            this._btnAddPerformance.UseVisualStyleBackColor = true;
            this._btnAddPerformance.Click += new System.EventHandler(this._btnAddPerformance_Click);
            // 
            // _btnDeleteEmail
            // 
            this._btnDeleteEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnDeleteEmail.FlatAppearance.BorderSize = 0;
            this._btnDeleteEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnDeleteEmail.ForeColor = System.Drawing.Color.White;
            this._btnDeleteEmail.Image = global::WorkPerformance.Properties.Resources.DeleteEmail;
            this._btnDeleteEmail.Location = new System.Drawing.Point(2, 616);
            this._btnDeleteEmail.Margin = new System.Windows.Forms.Padding(0);
            this._btnDeleteEmail.Name = "_btnDeleteEmail";
            this._btnDeleteEmail.Size = new System.Drawing.Size(45, 40);
            this._btnDeleteEmail.TabIndex = 5;
            this._toolTip.SetToolTip(this._btnDeleteEmail, "删除当前选中邮件的本地副本");
            this._btnDeleteEmail.UseVisualStyleBackColor = true;
            this._btnDeleteEmail.Click += new System.EventHandler(this._btnDeleteEmail_Click);
            // 
            // _btnEmailFilter
            // 
            this._btnEmailFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnEmailFilter.FlatAppearance.BorderSize = 0;
            this._btnEmailFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnEmailFilter.ForeColor = System.Drawing.Color.White;
            this._btnEmailFilter.Image = global::WorkPerformance.Properties.Resources.EmailFilter;
            this._btnEmailFilter.Location = new System.Drawing.Point(2, 67);
            this._btnEmailFilter.Margin = new System.Windows.Forms.Padding(0);
            this._btnEmailFilter.Name = "_btnEmailFilter";
            this._btnEmailFilter.Size = new System.Drawing.Size(45, 40);
            this._btnEmailFilter.TabIndex = 4;
            this._toolTip.SetToolTip(this._btnEmailFilter, "设置邮件过滤");
            this._btnEmailFilter.UseVisualStyleBackColor = true;
            this._btnEmailFilter.Click += new System.EventHandler(this._btnEmailFilter_Click);
            // 
            // _btnUser
            // 
            this._btnUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnUser.FlatAppearance.BorderSize = 0;
            this._btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnUser.ForeColor = System.Drawing.Color.White;
            this._btnUser.Image = global::WorkPerformance.Properties.Resources.User;
            this._btnUser.Location = new System.Drawing.Point(2, 119);
            this._btnUser.Margin = new System.Windows.Forms.Padding(0);
            this._btnUser.Name = "_btnUser";
            this._btnUser.Size = new System.Drawing.Size(45, 40);
            this._btnUser.TabIndex = 3;
            this._toolTip.SetToolTip(this._btnUser, "设置你的信息");
            this._btnUser.UseVisualStyleBackColor = true;
            this._btnUser.Click += new System.EventHandler(this._btnUser_Click);
            // 
            // _btnSendEmail
            // 
            this._btnSendEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnSendEmail.FlatAppearance.BorderSize = 0;
            this._btnSendEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnSendEmail.ForeColor = System.Drawing.Color.White;
            this._btnSendEmail.Image = global::WorkPerformance.Properties.Resources.SendEMail;
            this._btnSendEmail.Location = new System.Drawing.Point(2, 218);
            this._btnSendEmail.Margin = new System.Windows.Forms.Padding(0);
            this._btnSendEmail.Name = "_btnSendEmail";
            this._btnSendEmail.Size = new System.Drawing.Size(45, 40);
            this._btnSendEmail.TabIndex = 2;
            this._toolTip.SetToolTip(this._btnSendEmail, "发送邮件并使用当前的发信附件");
            this._btnSendEmail.UseVisualStyleBackColor = true;
            this._btnSendEmail.Click += new System.EventHandler(this._btnSendEmail_Click);
            // 
            // _btnExit
            // 
            this._btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnExit.FlatAppearance.BorderSize = 0;
            this._btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnExit.ForeColor = System.Drawing.Color.White;
            this._btnExit.Image = global::WorkPerformance.Properties.Resources.Exit;
            this._btnExit.Location = new System.Drawing.Point(3, 700);
            this._btnExit.Margin = new System.Windows.Forms.Padding(0);
            this._btnExit.Name = "_btnExit";
            this._btnExit.Size = new System.Drawing.Size(45, 40);
            this._btnExit.TabIndex = 1;
            this._toolTip.SetToolTip(this._btnExit, "退出");
            this._btnExit.UseVisualStyleBackColor = true;
            this._btnExit.Click += new System.EventHandler(this._btnExit_Click);
            // 
            // _btnGetEmails
            // 
            this._btnGetEmails.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnGetEmails.FlatAppearance.BorderSize = 0;
            this._btnGetEmails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnGetEmails.ForeColor = System.Drawing.Color.White;
            this._btnGetEmails.Image = global::WorkPerformance.Properties.Resources.GetEmails;
            this._btnGetEmails.Location = new System.Drawing.Point(2, 15);
            this._btnGetEmails.Margin = new System.Windows.Forms.Padding(0);
            this._btnGetEmails.Name = "_btnGetEmails";
            this._btnGetEmails.Size = new System.Drawing.Size(45, 40);
            this._btnGetEmails.TabIndex = 0;
            this._toolTip.SetToolTip(this._btnGetEmails, "立即获取最新的邮件信息");
            this._btnGetEmails.UseVisualStyleBackColor = true;
            this._btnGetEmails.Click += new System.EventHandler(this._btnGetEmails_Click);
            // 
            // _toolTip
            // 
            this._toolTip.AutomaticDelay = 300;
            this._toolTip.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // _btnEditPerformance
            // 
            this._btnEditPerformance.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnEditPerformance.FlatAppearance.BorderSize = 0;
            this._btnEditPerformance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnEditPerformance.Image = global::WorkPerformance.Properties.Resources.EditPerformance;
            this._btnEditPerformance.Location = new System.Drawing.Point(16, 450);
            this._btnEditPerformance.Margin = new System.Windows.Forms.Padding(0);
            this._btnEditPerformance.Name = "_btnEditPerformance";
            this._btnEditPerformance.Size = new System.Drawing.Size(45, 40);
            this._btnEditPerformance.TabIndex = 19;
            this._toolTip.SetToolTip(this._btnEditPerformance, "尝试将当前选中附件作为绩效文件编辑");
            this._btnEditPerformance.UseVisualStyleBackColor = true;
            this._btnEditPerformance.Click += new System.EventHandler(this._btnEditPerformance_Click);
            // 
            // _btnRemoveAttachment
            // 
            this._btnRemoveAttachment.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnRemoveAttachment.FlatAppearance.BorderSize = 0;
            this._btnRemoveAttachment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnRemoveAttachment.Image = global::WorkPerformance.Properties.Resources.Remove;
            this._btnRemoveAttachment.Location = new System.Drawing.Point(16, 407);
            this._btnRemoveAttachment.Margin = new System.Windows.Forms.Padding(0);
            this._btnRemoveAttachment.Name = "_btnRemoveAttachment";
            this._btnRemoveAttachment.Size = new System.Drawing.Size(45, 40);
            this._btnRemoveAttachment.TabIndex = 18;
            this._toolTip.SetToolTip(this._btnRemoveAttachment, "移除当前选中的发信附件");
            this._btnRemoveAttachment.UseVisualStyleBackColor = true;
            this._btnRemoveAttachment.Click += new System.EventHandler(this._btnRemoveAttachment_Click);
            // 
            // _btnAddAttachment
            // 
            this._btnAddAttachment.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnAddAttachment.FlatAppearance.BorderSize = 0;
            this._btnAddAttachment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnAddAttachment.Image = global::WorkPerformance.Properties.Resources.AddAttachment;
            this._btnAddAttachment.Location = new System.Drawing.Point(14, 363);
            this._btnAddAttachment.Margin = new System.Windows.Forms.Padding(0);
            this._btnAddAttachment.Name = "_btnAddAttachment";
            this._btnAddAttachment.Size = new System.Drawing.Size(45, 40);
            this._btnAddAttachment.TabIndex = 15;
            this._toolTip.SetToolTip(this._btnAddAttachment, "添加现有文件到发信附件中");
            this._btnAddAttachment.UseVisualStyleBackColor = true;
            this._btnAddAttachment.Click += new System.EventHandler(this._btnAddAttachment_Click);
            // 
            // _btnAddToSendAttachment
            // 
            this._btnAddToSendAttachment.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnAddToSendAttachment.FlatAppearance.BorderSize = 0;
            this._btnAddToSendAttachment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnAddToSendAttachment.Image = global::WorkPerformance.Properties.Resources.AddSendAttachment;
            this._btnAddToSendAttachment.Location = new System.Drawing.Point(14, 184);
            this._btnAddToSendAttachment.Margin = new System.Windows.Forms.Padding(0);
            this._btnAddToSendAttachment.Name = "_btnAddToSendAttachment";
            this._btnAddToSendAttachment.Size = new System.Drawing.Size(45, 40);
            this._btnAddToSendAttachment.TabIndex = 13;
            this._toolTip.SetToolTip(this._btnAddToSendAttachment, "将选定附件添加至我的发信附件中");
            this._btnAddToSendAttachment.UseVisualStyleBackColor = true;
            this._btnAddToSendAttachment.Click += new System.EventHandler(this._btnAddToSendAttachment_Click);
            // 
            // _btnOpenFile
            // 
            this._btnOpenFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnOpenFile.FlatAppearance.BorderSize = 0;
            this._btnOpenFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnOpenFile.Image = global::WorkPerformance.Properties.Resources.OpenFile;
            this._btnOpenFile.Location = new System.Drawing.Point(14, 139);
            this._btnOpenFile.Margin = new System.Windows.Forms.Padding(0);
            this._btnOpenFile.Name = "_btnOpenFile";
            this._btnOpenFile.Size = new System.Drawing.Size(45, 40);
            this._btnOpenFile.TabIndex = 12;
            this._toolTip.SetToolTip(this._btnOpenFile, "使用系统默认应用打开选定的附件");
            this._btnOpenFile.UseVisualStyleBackColor = true;
            this._btnOpenFile.Click += new System.EventHandler(this._btnOpenFile_Click);
            // 
            // _plContainer
            // 
            this._plContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(189)))), ((int)(((byte)(171)))));
            this._plContainer.Controls.Add(this._btnEditPerformance);
            this._plContainer.Controls.Add(this._btnRemoveAttachment);
            this._plContainer.Controls.Add(this._btnAddAttachment);
            this._plContainer.Controls.Add(this._lbSendAttachments);
            this._plContainer.Controls.Add(this._btnAddToSendAttachment);
            this._plContainer.Controls.Add(this._btnOpenFile);
            this._plContainer.Controls.Add(this._lbReceviceAttachments);
            this._plContainer.Controls.Add(this.label3);
            this._plContainer.Controls.Add(this.label2);
            this._plContainer.Controls.Add(this._lblAttachment);
            this._plContainer.Controls.Add(this.line1);
            this._plContainer.Controls.Add(this._lblSender);
            this._plContainer.Controls.Add(this._lblSubject);
            this._plContainer.Controls.Add(this.label1);
            this._plContainer.Controls.Add(this._lblDate);
            this._plContainer.Controls.Add(this._lblTime);
            this._plContainer.EnabledMousePierce = true;
            this._plContainer.ForeColor = System.Drawing.Color.White;
            this._plContainer.Location = new System.Drawing.Point(280, 0);
            this._plContainer.Margin = new System.Windows.Forms.Padding(0);
            this._plContainer.Name = "_plContainer";
            this._plContainer.Size = new System.Drawing.Size(744, 768);
            this._plContainer.TabIndex = 2;
            // 
            // _lbSendAttachments
            // 
            this._lbSendAttachments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(189)))), ((int)(((byte)(171)))));
            this._lbSendAttachments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._lbSendAttachments.DefaultAttachmentImage = global::WorkPerformance.Properties.Resources.AttachmentDownloadWhite;
            this._lbSendAttachments.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this._lbSendAttachments.Font = new System.Drawing.Font("微软雅黑 Light", 12F);
            this._lbSendAttachments.ForeColor = System.Drawing.Color.White;
            this._lbSendAttachments.FormattingEnabled = true;
            this._lbSendAttachments.ItemHeight = 30;
            this._lbSendAttachments.Location = new System.Drawing.Point(74, 365);
            this._lbSendAttachments.Margin = new System.Windows.Forms.Padding(0);
            this._lbSendAttachments.Name = "_lbSendAttachments";
            this._lbSendAttachments.SavedAttachmentFlagImage = global::WorkPerformance.Properties.Resources.AttachmentWhite;
            this._lbSendAttachments.Size = new System.Drawing.Size(646, 216);
            this._lbSendAttachments.TabIndex = 14;
            // 
            // _lbReceviceAttachments
            // 
            this._lbReceviceAttachments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(189)))), ((int)(((byte)(171)))));
            this._lbReceviceAttachments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._lbReceviceAttachments.DefaultAttachmentImage = global::WorkPerformance.Properties.Resources.AttachmentDownloadWhite;
            this._lbReceviceAttachments.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this._lbReceviceAttachments.Font = new System.Drawing.Font("微软雅黑 Light", 12F);
            this._lbReceviceAttachments.ForeColor = System.Drawing.Color.White;
            this._lbReceviceAttachments.FormattingEnabled = true;
            this._lbReceviceAttachments.ItemHeight = 30;
            this._lbReceviceAttachments.Location = new System.Drawing.Point(70, 143);
            this._lbReceviceAttachments.Margin = new System.Windows.Forms.Padding(0);
            this._lbReceviceAttachments.Name = "_lbReceviceAttachments";
            this._lbReceviceAttachments.SavedAttachmentFlagImage = global::WorkPerformance.Properties.Resources.AttachmentWhite;
            this._lbReceviceAttachments.Size = new System.Drawing.Size(646, 150);
            this._lbReceviceAttachments.TabIndex = 11;
            this._lbReceviceAttachments.SelectedIndexChanged += new System.EventHandler(this._lbAttachments_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑 Light", 12F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(667, 328);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 21);
            this.label3.TabIndex = 10;
            this.label3.Text = "发信附件";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑 Light", 12F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(667, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "收信附件";
            // 
            // _lblAttachment
            // 
            this._lblAttachment.AutoEllipsis = true;
            this._lblAttachment.Font = new System.Drawing.Font("微软雅黑 Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._lblAttachment.ForeColor = System.Drawing.Color.White;
            this._lblAttachment.Location = new System.Drawing.Point(69, 101);
            this._lblAttachment.Name = "_lblAttachment";
            this._lblAttachment.Size = new System.Drawing.Size(554, 27);
            this._lblAttachment.TabIndex = 8;
            this._lblAttachment.Text = "附件：";
            // 
            // line1
            // 
            this.line1.CustomBursh = null;
            this.line1.IsVertical = false;
            this.line1.LineColor = System.Drawing.Color.White;
            this.line1.LineLength = 700;
            this.line1.LineWidth = 2;
            this.line1.Location = new System.Drawing.Point(20, 310);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(700, 2);
            this.line1.TabIndex = 7;
            this.line1.Text = "line1";
            // 
            // _lblSender
            // 
            this._lblSender.AutoEllipsis = true;
            this._lblSender.Font = new System.Drawing.Font("微软雅黑 Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._lblSender.ForeColor = System.Drawing.Color.White;
            this._lblSender.Location = new System.Drawing.Point(69, 65);
            this._lblSender.Name = "_lblSender";
            this._lblSender.Size = new System.Drawing.Size(554, 27);
            this._lblSender.TabIndex = 5;
            this._lblSender.Text = "发送人";
            // 
            // _lblSubject
            // 
            this._lblSubject.AutoEllipsis = true;
            this._lblSubject.Font = new System.Drawing.Font("微软雅黑 Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._lblSubject.ForeColor = System.Drawing.Color.White;
            this._lblSubject.Location = new System.Drawing.Point(69, 30);
            this._lblSubject.Name = "_lblSubject";
            this._lblSubject.Size = new System.Drawing.Size(554, 27);
            this._lblSubject.TabIndex = 4;
            this._lblSubject.Text = "标题";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑 Light", 9F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 737);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "DEGAGE.TECH";
            // 
            // _lblDate
            // 
            this._lblDate.AutoSize = true;
            this._lblDate.Font = new System.Drawing.Font("微软雅黑 Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._lblDate.ForeColor = System.Drawing.Color.White;
            this._lblDate.Location = new System.Drawing.Point(488, 720);
            this._lblDate.Name = "_lblDate";
            this._lblDate.Size = new System.Drawing.Size(142, 38);
            this._lblDate.TabIndex = 1;
            this._lblDate.Text = "日期 星期";
            // 
            // _lblTime
            // 
            this._lblTime.AutoSize = true;
            this._lblTime.Font = new System.Drawing.Font("微软雅黑 Light", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._lblTime.ForeColor = System.Drawing.Color.White;
            this._lblTime.Location = new System.Drawing.Point(464, 596);
            this._lblTime.Name = "_lblTime";
            this._lblTime.Size = new System.Drawing.Size(267, 124);
            this._lblTime.TabIndex = 0;
            this._lblTime.Text = "时:分";
            // 
            // _imageAttachmentTypes
            // 
            this._imageAttachmentTypes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_imageAttachmentTypes.ImageStream")));
            this._imageAttachmentTypes.TransparentColor = System.Drawing.Color.Transparent;
            this._imageAttachmentTypes.Images.SetKeyName(0, "Word.png");
            // 
            // _timerDate
            // 
            this._timerDate.Enabled = true;
            this._timerDate.Interval = 60000;
            this._timerDate.Tick += new System.EventHandler(this._timerDate_Tick);
            // 
            // _ofSelectSendAttachment
            // 
            this._ofSelectSendAttachment.Filter = "所有文件|*.*";
            this._ofSelectSendAttachment.Title = "选择发信附件";
            // 
            // _sfSavePerformanceFile
            // 
            this._sfSavePerformanceFile.DefaultExt = "docx";
            this._sfSavePerformanceFile.Filter = "Word 2007+ 文件|*.docx";
            this._sfSavePerformanceFile.Title = "选择保存路径";
            // 
            // _lbEmails
            // 
            this._lbEmails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(238)))));
            this._lbEmails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._lbEmails.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this._lbEmails.Font = new System.Drawing.Font("微软雅黑 Light", 12F);
            this._lbEmails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this._lbEmails.FormattingEnabled = true;
            this._lbEmails.ItemAttachmentDownloadFlagImage = global::WorkPerformance.Properties.Resources.Attachment;
            this._lbEmails.ItemAttachmentFlagImage = global::WorkPerformance.Properties.Resources.AttachmentDownload;
            this._lbEmails.ItemHeight = 64;
            this._lbEmails.ItemNotReadFlagImage = global::WorkPerformance.Properties.Resources.ItemEmail;
            this._lbEmails.ItemReadFlagImage = global::WorkPerformance.Properties.Resources.OpenItemEmail;
            this._lbEmails.Location = new System.Drawing.Point(50, 0);
            this._lbEmails.Margin = new System.Windows.Forms.Padding(0);
            this._lbEmails.Name = "_lbEmails";
            this._lbEmails.Size = new System.Drawing.Size(230, 768);
            this._lbEmails.TabIndex = 1;
            this._lbEmails.SelectedIndexChanged += new System.EventHandler(this._lbEmails_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this._plContainer);
            this.Controls.Add(this._lbEmails);
            this.Controls.Add(this._plFunction);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "MainForm";
            this.ShowIcon = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "工作绩效";
            this._plFunction.ResumeLayout(false);
            this._plContainer.ResumeLayout(false);
            this._plContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PenetrablePanel _plFunction;
        private System.Windows.Forms.Button _btnGetEmails;
        private System.Windows.Forms.ToolTip _toolTip;
        private System.Windows.Forms.Button _btnExit;
        private System.Windows.Forms.Button _btnSendEmail;
        private EmailListBox _lbEmails;
        private PenetrablePanel _plContainer;
        private System.Windows.Forms.Label _lblDate;
        private System.Windows.Forms.Label _lblTime;
        private System.Windows.Forms.Timer _timerDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _btnUser;
        private System.Windows.Forms.Button _btnEmailFilter;
        private System.Windows.Forms.Label _lblSubject;
        private System.Windows.Forms.Label _lblSender;
        private System.Windows.Forms.ImageList _imageAttachmentTypes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label _lblAttachment;
        private Line line1;
        private AttachmentListBox _lbReceviceAttachments;
        private System.Windows.Forms.Button _btnOpenFile;
        private System.Windows.Forms.Button _btnAddToSendAttachment;
        private AttachmentListBox _lbSendAttachments;
        private System.Windows.Forms.Button _btnAddAttachment;
        private System.Windows.Forms.Button _btnRemoveAttachment;
        private System.Windows.Forms.OpenFileDialog _ofSelectSendAttachment;
        private System.Windows.Forms.Button _btnDeleteEmail;
        private System.Windows.Forms.Button _btnAddPerformance;
        private System.Windows.Forms.Button _btnEditPerformance;
        private System.Windows.Forms.Button _btnDownloadAllAttacment;
        private System.Windows.Forms.Button _btnEditPerformanceTemplate;
        private System.Windows.Forms.SaveFileDialog _sfSavePerformanceFile;
        private System.Windows.Forms.Button _btnSetReceivers;
    }
}

