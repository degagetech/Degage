using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPerformance
{
    /// <summary>
    /// 发信邮件信息
    /// </summary>
    public class SendEmailInfo
    {
        public String From { get; set; }
        public String To { get; set; }
        public String Title { get; set; }
        public String TextBody { get; set; }
        public List<EmailAttachmentInfo> AttachmentInfos { get; set; } = new List<EmailAttachmentInfo>();

        /// <summary>
        /// 是否启用分别发送
        /// </summary>
        public Boolean IsRespectivelySend { get; set; }
    }
}
