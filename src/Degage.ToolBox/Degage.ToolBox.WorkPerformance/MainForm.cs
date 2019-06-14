using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EAGetMail;
using System.IO;
using System.Globalization;
namespace WorkPerformance
{
    public partial class MainForm : BaseForm
    {
        public static MainForm Current { get; internal set; }

        public EmailDataManager EmailDataManager { get; private set; }
        public PerformanceTemplateManager TemplateManager { get; private set; }
        public List<PerformanceTemplateInfo> PerformanceTemplateInfos { get; private set; }
        public MainForm()
        {
            InitializeComponent();
            this.Load += InitLoad;
            this.Load += AsyncLoadConfigInfo;

        }

        private async void AsyncLoadConfigInfo(Object sender, EventArgs e)
        {
            WaitingForm.ShowWaiting();
            await Config<UserInfoConfig>.LoadAsync();
            await Config<EmailFilterConfig>.LoadAsync();
            await Config<EmailReceiverConfig>.LoadAsync();

            this.TemplateManager = new PerformanceTemplateManager();
            this.TemplateManager.Init();
            //加载本地的绩效模板信息
            this.PerformanceTemplateInfos = await this.TemplateManager.GetPerformanceTemplateInfosAsync();


            if (Config<UserInfoConfig>.Current.IsVaild())
            {
                this.EmailDataManager = new EmailDataManager(
                    Config<UserInfoConfig>.Current.EmailAddress,
                    Config<UserInfoConfig>.Current.Password);
                this.EmailDataManager.Init();
                var filterConfig = Config<EmailFilterConfig>.Current;
                var currentTime = DateTime.Now;
                //加载本地的邮件信息
                var emailInfos = await this.EmailDataManager.GetDownloadMailDataInfosAsync(
                        currentTime.AddDays(filterConfig.CollectRecentDays * -1),
                        currentTime,
                        filterConfig.TitleKeywords,
                        true
                    );
                this._lbEmails.ShowEmailInfos(emailInfos);
            }
            WaitingForm.HideWaiting();
            this._ofSelectSendAttachment.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            this._sfSavePerformanceFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }



        private void InitLoad(Object sender, EventArgs e)
        {
            Animator.DebutAnimation(this, DebutEffects.Fade | DebutEffects.Debut, 500);
            this.RenderingTime();
            this.RenderingDate();
        }

        private void _btnExit_Click(Object sender, EventArgs e)
        {
            Animator.DebutAnimation(this, DebutEffects.Fade | DebutEffects.WalkOff, 500);
            this.Close();
        }

        private async void _btnGetEmails_Click(Object sender, EventArgs e)
        {
            try
            {
                if (this.EmailDataManager == null) return;
                WaitingForm.ShowWaiting("正在获取邮件信息...");
                var config = Config<EmailFilterConfig>.Current;
                var currenttime = DateTime.Now;
                var result = await this.EmailDataManager.GetMailDataInfosAsync(
                        currenttime.AddDays(config.CollectRecentDays * -1),
                        currenttime,
                        config.TitleKeywords);
                this._lbEmails.AddShowEmailInfos(result);
                WaitingForm.HideWaiting();
            }
            catch
            {
            }
        }



        private void _timerDate_Tick(Object sender, EventArgs e)
        {
            this.RenderingTime();
        }
        private void RenderingTime()
        {
            this._lblTime.Text = DateTime.Now.ToString("HH:mm");

        }
        private void RenderingDate()
        {
            var date = DateTime.Now.Date;
            //XX月XX日 星期X
            String month = date.Month.ToString();
            String day = date.Date.Day.ToString();
            String week = CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(date.DayOfWeek);
            String text = $"{month}月{day}日 {week}";
            this._lblDate.Text = text;
        }

        private void _btnUser_Click(Object sender, EventArgs e)
        {
            UserInfoConfigForm form = new UserInfoConfigForm();
            form.ShowDialog();

            if (Config<UserInfoConfig>.Current.EmailAddress != null)
            {
                this.EmailDataManager = new EmailDataManager(
                    Config<UserInfoConfig>.Current.EmailAddress,
                    Config<UserInfoConfig>.Current.Password);
                this.EmailDataManager.Init();
            }
        }

        private async void _lbEmails_SelectedIndexChanged(Object sender, EventArgs e)
        {
            var dataInfo = this._lbEmails.SelectedEmailDataInfo;
            if (dataInfo == null) return;
            this._lblSubject.Text = dataInfo.Title;
            this._lblSender.Text = dataInfo.From;
            if (!dataInfo.IsDownloadedMail)
            {
                WaitingForm.ShowWaiting("正在下载邮件...");
                await dataInfo.DownloadAsync();
                this._lbEmails.RefreshItemDraw(this._lbEmails.SelectedIndex);
                WaitingForm.HideWaiting();
            }
            this._lbReceviceAttachments.ShowAttachmentInfo(dataInfo.AttachmentInfos);
        }

        private void _btnEmailFilter_Click(Object sender, EventArgs e)
        {
            EmailFilterForm form = new EmailFilterForm();
            var result = form.ShowDialog();
            if (result != DialogResult.OK) return;

            //重新过滤信息
            var config = Config<EmailFilterConfig>.Current;
            var receviceDateStart = DateTime.Now.AddDays(
                        config.CollectRecentDays * -1);
            var receviceDateEnd = DateTime.Now;
            var titleKeywords = config.TitleKeywords;

            var dataInfos = this._lbEmails.EmailDataInfos;
            var filterDataInfos = new List<EmailDataInfo>();
            foreach (var info in dataInfos)
            {
                if (this.EmailDataManager.AccordCondition(info, receviceDateStart, receviceDateEnd, titleKeywords))
                {
                    filterDataInfos.Add(info);
                }
            }

            this._lbEmails.ShowEmailInfos(filterDataInfos);
        }

        private async void _lbAttachments_SelectedIndexChanged(Object sender, EventArgs e)
        {
            //如果附件未保存附件信息
            var attachmentInfo = this._lbReceviceAttachments.SelectedEmailAttachmentInfo;
            if (attachmentInfo == null) return;
            if (!attachmentInfo.IsSaved)
            {
                WaitingForm.ShowWaiting("正在保存附件...");
                await attachmentInfo.SaveAysnc();
                this._lbReceviceAttachments.RefreshItemDraw(this._lbReceviceAttachments.SelectedIndex);
                WaitingForm.HideWaiting();
            }
        }

        private async void _btnOpenFile_Click(Object sender, EventArgs e)
        {
            var attachmentInfo = this._lbReceviceAttachments.SelectedEmailAttachmentInfo;
            if (attachmentInfo == null) return;
            WaitingForm.ShowWaiting();
            await ToolBox.OpenFile(attachmentInfo.SavePath);
            WaitingForm.HideWaiting();
        }

        private void _btnAddToSendAttachment_Click(Object sender, EventArgs e)
        {
            var attachmentInfo = this._lbReceviceAttachments.SelectedEmailAttachmentInfo;
            if (attachmentInfo == null) return;
            EmailAttachmentInfo newAttachmentInfo = new EmailAttachmentInfo(attachmentInfo.SavePath);
            this._lbSendAttachments.AddFirstAttachmentInfo(newAttachmentInfo, true);
        }

        private void _btnSendEmail_Click(Object sender, EventArgs e)
        {
            if (this.EmailDataManager == null) return;
            var attachs = this._lbSendAttachments.AttachmentInfos;
            EmailAttachmentInfo[] attachmentInfoArray = new EmailAttachmentInfo[attachs.Count];
            this._lbSendAttachments.AttachmentInfos.CopyTo(attachmentInfoArray);

            EmailSendForm form = new EmailSendForm(attachmentInfoArray.ToList());
            form.OpenFileDialog = this._ofSelectSendAttachment;
            form.ShowDialog();
        }

        private void _btnAddAttachment_Click(Object sender, EventArgs e)
        {
            var result = this._ofSelectSendAttachment.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }
            String filePath = this._ofSelectSendAttachment.FileName;
            EmailAttachmentInfo info = new EmailAttachmentInfo(filePath);
            this._lbSendAttachments.AddFirstAttachmentInfo(info, true);
        }

        private void _btnRemoveAttachment_Click(Object sender, EventArgs e)
        {
            this._lbSendAttachments.RemoveSelectedItem();
        }

        private async void _btnDeleteEmail_Click(Object sender, EventArgs e)
        {
            var info = this._lbEmails.RemoveSelectedItem();
            if (info != null)
            {
                await info.DeleteAsync();
            }

        }



        /// <summary>
        /// 获取一个绩效模板信息，当已有模板数目为一时，直接返回，有多个时，此函数要求用户选择
        /// </summary>
        /// <returns></returns>
        internal PerformanceTemplateInfo GetPerformanceTemplateInfo()
        {
            PerformanceTemplateInfo info = null;
            if (this.PerformanceTemplateInfos.Count == 0)
            {
                return null;
            }
            if (this.PerformanceTemplateInfos.Count > 1)
            {
                PerformanceTemplateSelectForm form = new PerformanceTemplateSelectForm(this.PerformanceTemplateInfos);
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    info = form.SelectedPerformanceTemplateInfo;
                }
            }
            else
            {
                info = this.PerformanceTemplateInfos.First();
            }
            return info;
        }

        private async void _btnDownloadAllAttacment_Click(Object sender, EventArgs e)
        {
            var dataInfos = this._lbEmails.EmailDataInfos;
            if (dataInfos.Count == 0) return;

            WaitingForm.ShowWaiting();
            foreach (var info in dataInfos)
            {
                //若邮件未下载，则先下载
                if (!info.IsDownloadedMail)
                {
                    WaitingForm.ShowTipInfo($"正在下载邮件：{info.Title} ...");
                    await info.DownloadAsync();
                }
                if (info.AttachmentInfos.Count == 0)
                {
                    continue;
                }

                foreach (var attachInfo in info.AttachmentInfos)
                {
                    //若附件未保存则先保存
                    if (!attachInfo.IsSaved)
                    {
                        WaitingForm.ShowTipInfo($"正在保存附件：{attachInfo.Name} ...");
                        await attachInfo.SaveAysnc();
                    }
                    this._lbSendAttachments.AddFirstAttachmentInfo(attachInfo, true);
                }

            }
            WaitingForm.HideWaiting();

        }

        private void _btnEditPerformanceTemplate_Click(Object sender, EventArgs e)
        {


        }

        private async void _btnAddPerformance_Click(Object sender, EventArgs e)
        {
            var templateInfo = this.GetPerformanceTemplateInfo();
            if (templateInfo == null) return;
            var dataItems = this.BuildPerformanceDataItems(templateInfo);
            if (dataItems != null && dataItems.Count > 0)
            {
                this._sfSavePerformanceFile.FileName = Config<UserInfoConfig>.Current.GetDefaultPerformanceTile();
                var result = this._sfSavePerformanceFile.ShowDialog();
                String savePath = this._sfSavePerformanceFile.FileName;
                WaitingForm.ShowWaiting("正在保存绩效文件...");
                await this.TemplateManager.FillDataItemsAsync(templateInfo, dataItems, savePath, true);

                //添加至发信附件
                EmailAttachmentInfo attachmentInfo = new EmailAttachmentInfo(savePath);
                this._lbSendAttachments.AddFirstAttachmentInfo(attachmentInfo);
                WaitingForm.HideWaiting();
            }
        }

        public IList<DataItem> BuildPerformanceDataItems(PerformanceTemplateInfo templateInfo, IList<DataItem> dataItems = null)
        {
            if (String.IsNullOrEmpty(templateInfo.Template.DataEditorType)) return null;
            Type type = Type.GetType(templateInfo.Template.DataEditorType);
            if (!type.IsSubclassOf(typeof(Form)))
            {
                return null;
            }
            if (!typeof(IDataEditor).IsAssignableFrom(type))
            {
                return null;
            }

            var dataEditorInstance = Activator.CreateInstance(type);
            var dataEditorForm = dataEditorInstance as Form;
            var dataEditor = dataEditorInstance as IDataEditor;
            dataEditor.Init(templateInfo.Template);
            if (dataItems != null)
            {
                dataEditor.LoadDataItems(dataItems);
            }
            var result = dataEditorForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                return dataEditor.GetDataItems();
            }
            return null;
        }

        private async void _btnEditPerformance_Click(Object sender, EventArgs e)
        {
            var attachInfo = this._lbSendAttachments.SelectedEmailAttachmentInfo;
            if (attachInfo != null)
            {
                await this.EditPerformanceFileAsync(attachInfo.SavePath);
            }

        }
        internal async Task EditPerformanceFileAsync(String filePath)
        {
            String ext = Path.GetExtension(filePath).ToLower();
            if (ext != ".docx")
            {
                WaitingForm.ShowErrorInfo("请选择 .docx 类型的文件！");
                return;
            }
            var templateInfo = this.GetPerformanceTemplateInfo();
            if (templateInfo == null)
            {
                WaitingForm.ShowErrorInfo("没有可用的绩效模板！");
                return;
            }
            WaitingForm.ShowWaiting("正在提取绩效信息...");
            var dataItems = await this.TemplateManager.ExtractDataItemsAsync(templateInfo, filePath);
            if (dataItems.Count == 0)
            {
                WaitingForm.ShowErrorInfo("未能从文件中提取到数据！");
                return;
            }
            WaitingForm.HideWaiting();
            var newDataItems = this.BuildPerformanceDataItems(templateInfo, dataItems);
            if (newDataItems == null)
            {
                return;
            }
            WaitingForm.ShowWaiting("正在保存编辑信息...");
            await this.TemplateManager.FillDataItemsAsync(templateInfo, newDataItems, filePath, true);
            WaitingForm.HideWaiting();
        }

        private void _btnSetReceivers_Click(object sender, EventArgs e)
        {
            EmailReceiverForm form = new EmailReceiverForm();
            form.ShowDialog();
        }
    }


}
