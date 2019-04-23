using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAGetMail;
using System.IO;
using System.Diagnostics;


namespace WorkPerformance
{
    /// <summary>
    /// 用于统一管理邮件数据信息
    /// </summary>
    public partial class EmailDataManager
    {
        /// <summary>
        /// 邮件附件文件夹
        /// </summary>
        public String AttachmentFloder { get; private set; }
        /// <summary>
        /// 邮件下载文件夹
        /// </summary>
        public String DownloadFloder { get; private set; }
        /// <summary>
        /// 邮件服务器地址
        /// </summary>
        private readonly static String MailServerAddress = "imap.exmail.qq.com";
        private readonly static String MailFileExt = ".eml";
        private readonly static String MailInfoFileExt = ".minfo";
        /// <summary>
        /// 邮件组件的许可信息，此软件不可用于商用
        /// </summary>
        private readonly static String LicenseCode = "TryIt";
        private readonly static CultureInfo SearchDateCultureInfo = CultureInfo.CreateSpecificCulture("en-us");
        public String User { get; private set; }
        public String Password { get; private set; }

        public EmailDataManager(String user, String password)
        {
            //"wanglangjing@hope-bridge.com"
            //"932444208Wlj-"
            this.User = user;
            this.Password = password;
        }
        /// <summary>
        /// 初始化邮件数据管理器
        /// </summary>
        public void Init()
        {
            this.AttachmentFloder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Attachments", this.User);
            this.DownloadFloder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Downloads", this.User);

            if (!Directory.Exists(this.AttachmentFloder))
            {
                Directory.CreateDirectory(this.AttachmentFloder);
            }
          
            if (!Directory.Exists(this.DownloadFloder))
            {
                Directory.CreateDirectory(this.DownloadFloder);
            }

        }
        private String GetDateString(DateTime date)
        {
            return date.ToString("dd-MMM-yyyy", SearchDateCultureInfo);
        }
        public Task<List<EmailDataInfo>> GetMailDataInfosAsync(DateTime? startDate = null, DateTime? endDate = null, String[] titleKeywords = null)
        {
            return Task.Run(() =>
            {
                return this.GetMailDataInfos(startDate, endDate, titleKeywords);
            });
        }
        public Task<List<EmailDataInfo>> GetDownloadMailDataInfosAsync(DateTime? startDate = null, DateTime? endDate = null, String[] titleKeywords = null, Boolean isDelete = false)
        {
            return Task.Run(() =>
            {
                return this.GetDownloadMailDataInfos(startDate, endDate, titleKeywords, isDelete);
            });
        }
        /// <summary>
        /// 获取本地已下载的邮件信息
        /// </summary>
        /// <param name="startDate">晚于指定的接收日期的邮件</param>
        /// <param name="endDate">早于指定接收日期的邮件</param>
        /// <param name="titleKeywords">邮件标题中的关键词</param>
        /// <param name="isDelete">是否删除不满足条件的本地邮件</param>
        /// <returns></returns>
        public List<EmailDataInfo> GetDownloadMailDataInfos(DateTime? startDate = null, DateTime? endDate = null, String[] titleKeywords = null, Boolean isDelete = false)
        {
            List<EmailDataInfo> dataInfos = new List<EmailDataInfo>();
            if (!Directory.Exists(this.DownloadFloder))
            {
                return dataInfos;
            }
            var fileNames = Directory.GetFiles(this.DownloadFloder, "*" + MailFileExt);
            if (fileNames.Length <= 0)
            {
                return dataInfos;
            }
            foreach (var filename in fileNames)
            {
                Mail mail = new Mail(LicenseCode);
                try
                {
                    mail.Load(filename, true);
                    var infoFilePath = filename + MailInfoFileExt;
                    if (startDate.HasValue)
                    {
                        if (mail.ReceivedDate < startDate)
                        {
                            if (isDelete)
                            {
                                goto DELTE;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }

                    if (endDate.HasValue)
                    {
                        if (mail.ReceivedDate > endDate && isDelete)
                        {
                            if (isDelete)
                            {
                                goto DELTE;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }

                    if (titleKeywords != null && titleKeywords.Length > 0)
                    {
                        if (!this.AccordTitleKeywords(mail.Subject, titleKeywords))
                        {
                            if (isDelete)
                            {
                                goto DELTE;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    MailInfo info = null;
                    if (File.Exists(infoFilePath))
                    {
                        info = DataSerializer.Deserialize<MailInfo>(infoFilePath);
                    }
                    else
                    {
                        info = new MailInfo();
                        var uldl = Path.GetFileNameWithoutExtension(filename);
                        info.UIDL = uldl;
                    }
                    EmailDataInfo dataInfo = new EmailDataInfo();
                    this.BuildEmailDataInfo(dataInfo, mail, info);
                    dataInfo.IsDownloadedMail = true;
                    dataInfos.Add(dataInfo);
                    continue;
                DELTE:
                    this.DeleteDownloadMail(filename, infoFilePath);
                }
                catch
                { }

            }
            return dataInfos;
        }
        public void DeleteDownloadMail(EmailDataInfo info)
        {
            var emlPath = this.GetMailDownloadPath(info.UIDL);
            var infoFilePath = emlPath + MailInfoFileExt;
            this.DeleteDownloadMail(emlPath, infoFilePath);
        }
        private void DeleteDownloadMail(String emlFilePath, String infoFilePath)
        {
            File.Delete(emlFilePath);
            File.Delete(infoFilePath);
        }
        /// <summary>
        /// 获取邮件数据信息，并限定条件
        /// </summary>
        /// <param name="startDate">晚于指定的接收日期的邮件</param>
        /// <param name="endDate">早于指定接收日期的邮件</param>
        /// <param name="titleKeywords">邮件标题中的关键词</param>
        public List<EmailDataInfo> GetMailDataInfos(DateTime? startDate = null, DateTime? endDate = null, String[] titleKeywords = null)
        {
            List<EmailDataInfo> emailDataInfos = new List<EmailDataInfo>();
            List<Mail> mails = new List<Mail>();
            List<MailInfo> mailInfos = new List<MailInfo>();
            MailServer oServer = new MailServer(MailServerAddress,
                      this.User, this.Password, true, ServerAuthType.AuthLogin, ServerProtocol.Imap4);
            oServer.Port = 993;
            MailClient oClient = new MailClient(LicenseCode);
            try
            {
                oClient.Connect(oServer);
                String condition = "ALL";
                if (startDate.HasValue)
                {
                    String startDateStr = this.GetDateString(startDate.Value);
                    condition += " SINCE " + startDateStr;
                }
                if (endDate.HasValue)
                {
                    String endDateStr = this.GetDateString(endDate.Value);
                    condition += " SENTBEFORE " + endDateStr;
                }

                //官网上提供的一系列关键词的条件都无效，暂时使用本地筛选的方法。 https://www.emailarchitect.net/eagetmail/sdk/
                //if (!String.IsNullOrWhiteSpace(titleKeyword))
                //{
                //    condition += $" KEYWORD {titleKeyword}";
                //}

                MailInfo[] result = oClient.SearchMail(condition);
                mailInfos.AddRange(result);
                foreach (var info in mailInfos)
                {
                    //先获取邮件头部信息，此处邮件的信息并不完整，后续需要使用 GetMail 获取完整的邮件信息
                    var headerMailData = oClient.GetMailHeader(info);
                    var headerMail = new Mail(LicenseCode);
                    headerMail.Load(headerMailData);
                    if (this.AccordTitleKeywords(headerMail.Subject, titleKeywords))
                    {
                        EmailDataInfo dataInfo = new EmailDataInfo();
                        this.BuildEmailDataInfo(dataInfo, headerMail, info);
                        emailDataInfos.Add(dataInfo);
                    }
                }
            }
            finally
            {
                oClient.Quit();
                oClient.Close();
            }
            return emailDataInfos;
        }
        /// <summary>
        /// 指定邮件接收时间是否在限定日期内，以及邮件主题是否含有指定关键词
        /// </summary>
        /// <param name="dataInfo"></param>
        /// <param name="receiveDateStart"></param>
        /// <param name="receviceDataEnd"></param>
        /// <param name="titleKeywords"></param>
        /// <returns></returns>
        public Boolean AccordCondition(EmailDataInfo dataInfo, DateTime receiveDateStart, DateTime receviceDataEnd, String[] titleKeywords)
        {
            if (dataInfo.ReceviceTime > receiveDateStart && dataInfo.ReceviceTime < receviceDataEnd)
            {
                if (this.AccordTitleKeywords(dataInfo.Title, titleKeywords))
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 指定标题文本是否含有全部的关键词，当关键词为空时，直接返回 true
        /// </summary>
        /// <param name="title"></param>
        /// <param name="titleKeywords"></param>
        /// <returns></returns>
        public Boolean AccordTitleKeywords(String title, String[] titleKeywords)
        {
            if (titleKeywords != null && titleKeywords.Length > 0)
            {
                foreach (var keyword in titleKeywords)
                {
                    if (!title.Contains(keyword))
                    {
                        return false;
                    }
                }
            }
            else
            {
                return true;
            }
            return true;
        }
        /// <summary>
        /// 下载指定的邮件数据信息到本地
        /// </summary>
        /// <param name="dataInfo"></param>
        public void DownloadEmailInfo(EmailDataInfo dataInfo)
        {
            MailServer oServer = new MailServer(MailServerAddress,
                   this.User, this.Password, true, ServerAuthType.AuthLogin, ServerProtocol.Imap4);
            oServer.Port = 993;
            MailClient oClient = new MailClient(LicenseCode);
            try
            {
                oClient.Connect(oServer);
                var mail = oClient.GetMail(dataInfo.MailInfo);
                this.BuildEmailDataInfo(dataInfo, mail, dataInfo.MailInfo);
                this.SaveMailDataInfo(dataInfo);
                dataInfo.IsDownloadedMail = true;
            }
            finally
            {
                oClient.Quit();
                oClient.Close();
            }
        }
        /// <summary>
        /// 保存邮件信息到本地
        /// </summary>
        /// <param name="info"></param>
        private void SaveMailDataInfo(EmailDataInfo info)
        {
            String path = this.GetMailDownloadPath(info.MailInfo.UIDL);
            info.Mail.SaveAs(path, true);
            path += MailInfoFileExt;
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
            DataSerializer.Serialize(info.MailInfo, path);
        }
        private String GetMailDownloadPath(String uldl)
        {
            String path = Path.Combine(this.DownloadFloder, uldl + MailFileExt);
            return path;
        }
        /// <summary>
        /// 判断指定的标识的邮件是否已被下载到本地
        /// </summary>
        /// <param name="uldl"></param>
        /// <returns></returns>
        private Boolean IsDownloadedMail(String uldl)
        {
            String path = Path.Combine(this.DownloadFloder, uldl + MailFileExt);
            return File.Exists(path);
        }
        public void SaveAttachmentInfo(EmailAttachmentInfo attachmentInfo)
        {
            //层次：  用户-》邮件ID-》文件名称
            String directory = Path.Combine(this.AttachmentFloder, attachmentInfo.EmailDataInfo.UIDL);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            String path = Path.Combine(directory, attachmentInfo.Name);
            if (!File.Exists(path))
            {
                attachmentInfo.Attachment.SaveAs(path, false);
            }
            attachmentInfo.IsSaved = true;
            attachmentInfo.SavePath = path;
        }
        private void BuildEmailDataInfo(EmailDataInfo dataInfo, Mail mail, MailInfo info)
        {
            this.RemoveTrialInfo(mail);
            dataInfo.Mail = mail;
            dataInfo.Title = mail.Subject;
            dataInfo.MailInfo = info;
            dataInfo.Manager = this;

            dataInfo.AttachmentInfos.Clear();
            foreach (var attachment in mail.Attachments)
            {
                var attachInfo = EmailAttachmentInfo.Create(attachment, dataInfo);
                String path = Path.Combine(this.AttachmentFloder, info.UIDL, attachInfo.Name);
                if (File.Exists(path))
                {
                    attachInfo.IsSaved = true;
                    attachInfo.SavePath = path;
                }
                dataInfo.AttachmentInfos.Add(attachInfo);
            }

        }

        /// <summary>
        /// 移除因为组件为试用版本而附加的信息
        /// </summary>
        private void RemoveTrialInfo(Mail mail)
        {
            mail.Subject = mail.Subject.Replace("(Trial Version)", String.Empty);
        }
    }
}
