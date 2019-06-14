using EAGetMail;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPerformance
{
    /// <summary>
    /// 存放与邮件相关的数据
    /// </summary>
    public class EmailDataInfo
    {
        /// <summary>
        /// 邮件的唯一标识符
        /// </summary>
        public String UIDL
        {
            get
            {
                return this.MailInfo.UIDL;
            }
        }
        public List<EmailAttachmentInfo> AttachmentInfos { get; internal set; } = new List<EmailAttachmentInfo>();
        /// <summary>
        /// 邮件信息当前从属的管理器
        /// </summary>
        public EmailDataManager Manager { get; internal set; }
        /// <summary>
        /// 是否已完整下载邮件信息
        /// </summary>
        public Boolean IsDownloadedMail { get; set; }
        /// <summary>
        /// 邮件是否已读
        /// </summary>
        public Boolean IsRead
        {
            get
            {
                return this.MailInfo.Read;
            }
        }
        /// <summary>
        /// 是否已下载邮件包含的附件信息
        /// </summary>
        public Boolean IsDownloadAttachment
        {
            get
            {
                Boolean downloaded = true;
                foreach (var attach in this.AttachmentInfos)
                {
                    downloaded &= attach.IsSaved;
                }
                return downloaded;
            }
        }

        /// <summary>
        /// 是否包含附件
        /// </summary>
        public Boolean HadAttachment
        {
            get
            {
                return this.Mail.Attachments.Length > 0;
            }
        }
        /// <summary>
        /// 邮件的接收时间
        /// </summary>
        public DateTime ReceviceTime
        {
            get
            {
                return this.Mail.ReceivedDate;
            }
        }
        /// <summary>
        /// 邮件的标题信息
        /// </summary>
        public String Title { get; internal set; }

        public String TextBody
        {
            get
            {
                return this.Mail.TextBody;
            }
        }
        /// <summary>
        /// 邮件的来源
        /// </summary>
        public String From
        {
            get
            {
                return this.Mail.From.Name + " " + this.Mail.From.Address;
            }
        }

        /// <summary>
        /// 对邮件的信息标识
        /// </summary>
        public MailInfo MailInfo { get; set; }
        /// <summary>
        /// 邮件信息本身
        /// </summary>
        public Mail Mail { get; set; }

        /// <summary>
        /// 下载邮件
        /// </summary>
        public async Task DownloadAsync()
        {
            if (this.Manager == null)
            {
                return;
            }
            await Task.Run(() =>
           {
               this.Manager.DownloadEmailInfo(this);
           });
        }

        /// <summary>
        /// 删除邮件的本地副本
        /// </summary>
        public async Task DeleteAsync()
        {
            if (this.Manager == null)
            {
                return;
            }
            await Task.Run(() =>
            {
                this.Manager.DeleteDownloadMail(this);
            });
        }
        /// <summary>
        /// 根据邮件标识将相应邮件信息加载到 <see cref="EmailDataInfo.Mail"/> 属性中
        /// </summary>
        //public void Load()
        //{
        //    MailClient oClient = null;

        //}
    }

}
