using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using WorkPerformance.Properties;
using System.IO;
namespace WorkPerformance
{
    public class SendAttachmentListBox : AttachmentListBox
    {
        /// <summary>
        /// 是否绘制收件人信息，默认 False
        /// </summary>
        public Boolean DrawReceiver { get; set; } = false;
        private readonly String DefaultReceiverText = "[未指定]";
        private Size? DefaultReceiverTextDrawSize;
        public SendAttachmentListBox() : base()
        {
            this.DrawItem += SendAttachmentListBox_DrawItem;
            this.FontChanged += SendAttachmentListBox_FontChanged;
        }

        private void SendAttachmentListBox_FontChanged(Object sender, EventArgs e)
        {
            this.DefaultReceiverTextDrawSize = null;
        }

        private void SendAttachmentListBox_DrawItem(Object sender, DrawItemEventArgs e)
        {
            if (!this.DrawReceiver) return;
            if (e.Index == -1 || this.DesignMode)
            {
                return;
            }
            var obj = this.Items[e.Index];
            EmailAttachmentInfo attachInfo = obj as EmailAttachmentInfo;
            if (attachInfo == null) return;

            String receiver = attachInfo.ReceiverName;
            if (String.IsNullOrEmpty(attachInfo.ReceiverName))
            {
                receiver = this.DefaultReceiverText;
            }
            if (!this.DefaultReceiverTextDrawSize.HasValue)
            {
                this.DefaultReceiverTextDrawSize = TextRenderer.MeasureText(this.DefaultReceiverText, e.Font);
            }
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            var forceColor = e.ForeColor;
            var backgroundColor = e.BackColor;
            Int32 iconWidth = 30;
            Int32 textBeginX = iconWidth;
            Int32 textBeginY = 3;

            var defaultTextSize = this.DefaultReceiverTextDrawSize.Value;
            var backgroudRect = new Rectangle(e.Bounds.X - 1, e.Bounds.Y - 1, e.Bounds.Width + 1, e.Bounds.Height + 2);
            var receiverTextRect = new Rectangle(
                  backgroudRect.Width- defaultTextSize.Width, 
                  textBeginY,
                  defaultTextSize.Width,
                  defaultTextSize.Height);


            //绘制附件名称属性
            TextRenderer.DrawText(g, receiver, e.Font, receiverTextRect, e.ForeColor, TextFormatFlags.EndEllipsis);
        }
    }
}
