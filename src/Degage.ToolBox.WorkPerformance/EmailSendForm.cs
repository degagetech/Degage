using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkPerformance
{
    public partial class EmailSendForm : BaseForm
    {
        public OpenFileDialog OpenFileDialog { get; internal set; }
        public List<EmailAttachmentInfo> AttachmentInfos { get; private set; } = new List<EmailAttachmentInfo>();
        public EmailSendForm()
        {
            InitializeComponent();
            this.Load += InitMailInfo;
        }

        private void InitMailInfo(Object sender, EventArgs e)
        {
            //绩效考核表_时间_部门_姓名
            var userInfo = Config<UserInfoConfig>.Current;



            String title = userInfo.GetDefaultPerformanceTile();
            String to = userInfo.DefaultReceviceEmail;
            String textBody = title + Environment.NewLine + "附件如下：";

            this._tbEmailTitle.Text = title;
            this._tbRecevicer.Text = to;
            this._tbTextBody.Text = textBody;
        }

        public EmailSendForm(List<EmailAttachmentInfo> attachmentInfos) : this()
        {
            this.AttachmentInfos = attachmentInfos;
            this.Load += LoadAttachmentInfo;
        }

        private void LoadAttachmentInfo(Object sender, EventArgs e)
        {
            this._lbSendAttachments.ShowAttachmentInfo(this.AttachmentInfos);
        }

        protected override void OnLoad(EventArgs e)
        {

            base.OnLoad(e);
            Animator.DebutAnimation(this, DebutEffects.Fade | DebutEffects.Debut, 200);
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {

            base.OnFormClosing(e);
            Animator.DebutAnimation(this, DebutEffects.Fade | DebutEffects.WalkOff, 200);
        }
        private void _btnCancel_Click(Object sender, EventArgs e)
        {
            this.CancelClose();
        }

        private void _btnAddAttachment_Click(Object sender, EventArgs e)
        {
            var result = this.OpenFileDialog.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }
            String filePath = this.OpenFileDialog.FileName;
            EmailAttachmentInfo info = new EmailAttachmentInfo(filePath);
            this._lbSendAttachments.AddFirstAttachmentInfo(info, true);
        }

        private void _btnRemoveAttachment_Click(Object sender, EventArgs e)
        {
            this._lbSendAttachments.RemoveSelectedItem();
        }

        private async void _btnConfirm_Click(Object sender, EventArgs e)
        {
            var info = this.CreateSendEmailInfo();
            if (info == null) return;
            WaitingForm.ShowWaiting("正在发送邮件...");
            info.IsRespectivelySend = this._lbSendAttachments.DrawReceiver;
            await MainForm.Current.EmailDataManager.SendEmailAsync(info);
            WaitingForm.HideWaiting();

            this.ConfirmClose();
        }
        private SendEmailInfo CreateSendEmailInfo()
        {
            SendEmailInfo info = null;
            var userInfo = Config<UserInfoConfig>.Current;

            String from = userInfo.EmailAddress;
            String title = this._tbEmailTitle.Text.Trim();
            String to = this._tbRecevicer.Text.Trim();
            String textBody = this._tbTextBody.Text.Trim();

            if (String.IsNullOrEmpty(from))
            {
                return null;
            }

            if (String.IsNullOrEmpty(title))
            {
                return null;
            }

            if (String.IsNullOrEmpty(to))
            {
                return null;
            }
            var attachmentInfos = this._lbSendAttachments.AttachmentInfos;

            info = new SendEmailInfo();
            info.From = from;
            info.To = to;
            info.Title = title;
            info.TextBody = textBody;
            info.AttachmentInfos = attachmentInfos;

            return info;
        }

        private async void _btnEditPerformance_Click(object sender, EventArgs e)
        {
            var attachInfo = this._lbSendAttachments.SelectedEmailAttachmentInfo;
            if (attachInfo != null)
            {
                await MainForm.Current.EditPerformanceFileAsync(attachInfo.SavePath);
            }
        }

        private void _cbIsRespectivelySend_CheckedChanged(Object sender, EventArgs e)
        {
            this._lbSendAttachments.DrawReceiver = !this._lbSendAttachments.DrawReceiver;
          
            //根据附件名称推断合适的接收人
            var attachInfos = this._lbSendAttachments.AttachmentInfos;
            if (attachInfos.Count > 0)
            {
                var receivers = Config<EmailReceiverConfig>.Current.Items;
                if (receivers.Count > 0)
                {
                    foreach (var attach in attachInfos)
                    {
                        foreach (var receiver in receivers)
                        {
                            if (attach.Name.Contains(receiver.ReceiverName))
                            {
                                attach.ReceiverName = receiver.ReceiverName;
                                attach.ReceiverEmail = receiver.ReceiverEmailAddress;
                                break;
                            }
                        }
                    }
                }
            }
            this._lbSendAttachments.Refresh();
        }

        private void _btnSettingReceiver_Click(Object sender, EventArgs e)
        {
            if (!this._lbSendAttachments.DrawReceiver)
            {
                return;
            }
            var attach = this._lbSendAttachments.SelectedEmailAttachmentInfo;
            if (attach == null) return;
            EmailReceiverForm form = new EmailReceiverForm();
            form.EnableReceiverEdit(false);
            var result = form.ShowDialog();
            if (result != DialogResult.OK) return;

            var receiver = form.SelectedItem;
            if (receiver == null) return;
            attach.ReceiverEmail = receiver.ReceiverEmailAddress;
            attach.ReceiverName = receiver.ReceiverName;
            this._lbSendAttachments.RefreshItemDraw(this._lbSendAttachments.SelectedIndex);
        }
    }
}
