using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using EASendMail;

namespace WorkPerformance
{
    /// <summary>
    /// 用于统一管理邮件数据信息
    /// </summary>
    public partial class EmailDataManager
    {
        /// <summary>
        /// 发信邮件服务器的地址
        /// </summary>
        private readonly static String SendMailServerAddress = "smtp.exmail.qq.com";
        public async Task SendEmailAsync(SendEmailInfo emailInfo)
        {
            if (emailInfo == null) return;
            await Task.Run(() =>
            {
                this.SendEmail(emailInfo);
            });
        }
        public void SendEmail(SendEmailInfo emailInfo)
        {

            SmtpClient oSmtp = new SmtpClient();

            SmtpServer oServer = new SmtpServer(SendMailServerAddress);
            oServer.User = this.User;
            oServer.Password = this.Password;
            oServer.Port = 465;
            oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

            if (emailInfo.IsRespectivelySend)
            {
                foreach (var attach in emailInfo.AttachmentInfos)
                {
                    SmtpMail oMail = new SmtpMail(LicenseCode);
                    oMail.From = emailInfo.From;
                    oMail.To = attach.ReceiverEmail;
                    String subject = Path.GetFileNameWithoutExtension(attach.Name);
                    oMail.Subject = subject;
                    oMail.TextBody = subject;
                    oMail.AddAttachment(attach.SavePath);
                    oSmtp.SendMail(oServer, oMail);
                }
            }
            else
            {
                SmtpMail oMail = new SmtpMail(LicenseCode);
                oMail.From = emailInfo.From;
                oMail.To = emailInfo.To;
                oMail.Subject = emailInfo.Title;
                oMail.TextBody = emailInfo.TextBody;
                if (emailInfo.AttachmentInfos.Count > 0)
                {
                    foreach (var info in emailInfo.AttachmentInfos)
                    {
                        oMail.AddAttachment(info.SavePath);
                    }
                }
                oSmtp.SendMail(oServer, oMail);
            }


        }

    }
}
