using EAGetMail;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPerformance
{
    /// <summary>
    /// 邮件的附件信息
    /// </summary>
    public class EmailAttachmentInfo
    {
        public String From { get; internal set; }
        /// <summary>
        /// 此字段当发送邮件时，如果 <see cref="SendEmailInfo.IsRespectivelySend"/> 启用时，需要填入
        /// </summary>
        public String ReceiverEmail { get; set; }
        /// <summary>
        ///  描述接收人的名称信息，此字段当发送邮件时，如果 <see cref="SendEmailInfo.IsRespectivelySend"/> 启用时，需要填入
        /// </summary>
        public String ReceiverName { get; set; }
        public static EmailAttachmentInfo Create(Attachment attachment, EmailDataInfo dataInfo = null)
        {
            EmailAttachmentInfo info = new EmailAttachmentInfo(attachment);
            info.EmailDataInfo = dataInfo;
            info.From = dataInfo?.From;
            return info;
        }
        public EmailAttachmentInfo(String filePath)
        {
            String name = Path.GetFileName(filePath);
            this.Name = name;
            this.IsSaved = true;
            this.SavePath = filePath;
        }
        public EmailAttachmentInfo(Attachment attachment)
        {
            this.Attachment = attachment;
            this.Name = attachment.Name;
        }
        /// <summary>
        /// 用于个别情况下的辅助排序
        /// </summary>
        public Int32 Sort { get; set; }
        /// <summary>
        /// 所属的邮件信息
        /// </summary>
        public EmailDataInfo EmailDataInfo { get; internal set; }
        public Attachment Attachment { get; protected set; }

        /// <summary>
        /// 附件的名称
        /// </summary>
        public String Name { get; private set; }

        /// <summary>
        /// 表示此附件是否已保存到本地
        /// </summary>
        public Boolean IsSaved { get; internal set; }
        /// <summary>
        /// 附件本地存储的路径
        /// </summary>
        public String SavePath { get; internal set; }

        /// <summary>
        /// 保存附件信息到本地
        /// </summary>
        /// <returns></returns>
        public async Task SaveAysnc()
        {
            if (this.EmailDataInfo == null) return;
            await Task.Run(() =>
            {
                this.EmailDataInfo.Manager.SaveAttachmentInfo(this);
            });
        }
    }
}
