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
    public class EmailListBox : BaseListBox
    {
        /// <summary>
        /// 项：邮件已读标识图片
        /// </summary>
        [Category("项样式")]
        [Description("项：邮件已读标识图片")]
        public Image ItemReadFlagImage { get; set; }
        /// <summary>
        /// 项：邮件未读标识图片
        /// </summary>
        [Category("项样式")]
        [Description("项：邮件未读标识图片")]
        public Image ItemNotReadFlagImage { get; set; }

        /// <summary>
        /// 项：邮件含有附件信息标识
        /// </summary>
        [Category("项样式")]
        [Description("项：邮件含有附件信息标识图片")]
        public Image ItemAttachmentFlagImage { get; set; }
        /// <summary>
        /// 项：邮件含有附件信息需要下载标识图片
        /// </summary>
        [Category("项样式")]
        [Description("项：邮件含有附件信息已下载标识图片")]
        public Image ItemAttachmentDownloadFlagImage { get; set; }

        /// <summary>
        /// 项：接收时间绘制的字体
        /// </summary>
        [Category("项样式")]
        [Description("项：接收时间绘制的字体")]
        public Font ItemReceiveTimeFont { get; private set; }
        /// <summary>
        /// 项：标题绘制的字体
        /// </summary>
        [Category("项样式")]
        [Description("项：标题绘制的字体")]
        public Font ItemTitleFont { get; private set; }

        /// <summary>
        ///项：发送人绘制的字体
        /// </summary>
        [Category("项样式")]
        [Description("项：发送人绘制的字体")]
        public Font ItemSenderFont { get; private set; }


        public EmailDataInfo SelectedEmailDataInfo
        {
            get
            {
                if (this.SelectedIndex == -1) return null;
                var info = this.Items[this.SelectedIndex] as EmailDataInfo;
                return info;
            }
        }
        public List<EmailDataInfo> EmailDataInfos { get; private set; } = new List<EmailDataInfo>();
        /// <summary>
        /// 邮件
        /// </summary>
        public EmailListBox() : base()
        {
            this.BackColor = Color.FromArgb(((Int32)(((Byte)(231)))), ((Int32)(((Byte)(242)))), ((Int32)(((Byte)(238)))));
            this.ForeColor = Color.FromArgb(((Int32)(((Byte)(70)))), ((Int32)(((Byte)(70)))), ((Int32)(((Byte)(70)))));
            this.ItemHeight = 64;
            this.Margin = new Padding(0);
            this.Size = new Size(230, 768);
            this.DrawItem += CustomDrawItem;
            this.ItemReceiveTimeFont = new System.Drawing.Font("微软雅黑 Light", 7F);
            this.ItemSenderFont = new System.Drawing.Font("微软雅黑 Light", 12F);
            this.ItemTitleFont = new System.Drawing.Font("微软雅黑 Light", 12F);
        }

        /// <summary>
        /// 与控件已有的邮件信息合并显示
        /// </summary>
        /// <param name="dataInfos"></param>
        public void AddShowEmailInfos(List<EmailDataInfo> dataInfos)
        {
            var table = this.EmailDataInfos.ToDictionary(t => t.UIDL);
            foreach (var info in dataInfos)
            {
                if (!String.IsNullOrEmpty(info.UIDL))
                {
                    table[info.UIDL] = info;
                }
            }
            this.ShowEmailInfos(table.Values.ToList());
        }
        /// <summary>
        /// 清除当前的邮件信息，并设置为指定的邮件信息
        /// </summary>
        public void ShowEmailInfos(List<EmailDataInfo> dataInfos)
        {
            dataInfos.Sort((t1, t2) =>
            {
                if (t1.ReceviceTime > t2.ReceviceTime) return -1;
                if (t1.ReceviceTime == t2.ReceviceTime) return 0;
                return 1;
            });
            this.ResetIndex();
            this.EmailDataInfos = dataInfos;
            this.Items.Clear();
            this.Items.AddRange(dataInfos.ToArray());
        }

        /// <summary>
        ///  绘制邮件信息项
        /// </summary>
        private void CustomDrawItem(Object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1 || this.DesignMode)
            {
                return;
            }
            var obj = this.Items[e.Index];
            EmailDataInfo dataInfo = obj as EmailDataInfo;
            if (dataInfo == null) return;
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            var forceColor = e.ForeColor;
            var backgroundColor = e.BackColor;
            var titleFont = e.Font;
            var formFont = e.Font;
            Int32 iconWidth = 30;
            var backgroudRect = new Rectangle(e.Bounds.X - 1, e.Bounds.Y - 1, e.Bounds.Width + 1, e.Bounds.Height + 2);

            Int32 textBeginX = e.Bounds.X + iconWidth;
            Int32 textBeginY = e.Bounds.Y + 3;

            var titleRect = new Rectangle(textBeginX, textBeginY, e.Bounds.Width - iconWidth, e.Bounds.Height);
            var fromRect = new Rectangle(textBeginX, textBeginY + 22, e.Bounds.Width - iconWidth, e.Bounds.Height);
            var timeRect = new Rectangle(e.Bounds.Width - 110, textBeginY + 24 + 20, e.Bounds.Width - iconWidth, e.Bounds.Height);
            var readFlagRect = new Rectangle(5, 7, 20, 20);
            var attachmentFlagRect = new Rectangle(5, 30, 20, 20);
            if (this.MouseHoverItemIndex == e.Index)
            {
                backgroundColor = Color.FromArgb(224, 224, 224);
            }
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                backgroundColor = Color.FromArgb(200, 200, 200);
            }

            Brush backBrush = new SolidBrush(backgroundColor);


            g.FillRectangle(backBrush, backgroudRect);

            //左上边绘制邮件阅读标识
            var readFlagImage = dataInfo.IsRead ? this.ItemReadFlagImage : this.ItemNotReadFlagImage;
            if (readFlagImage != null)
            {
                g.DrawImage(readFlagImage, readFlagRect);
            }

            //左下绘制附件标识
            if (dataInfo.HadAttachment)
            {
                var attachmentFlagImage = this.ItemAttachmentFlagImage;
                if (dataInfo.IsDownloadAttachment)
                {
                    attachmentFlagImage = this.ItemAttachmentDownloadFlagImage;
                }
                if (attachmentFlagImage != null)
                {
                    g.DrawImage(attachmentFlagImage, attachmentFlagRect);
                }
            }

            //绘制邮件标题 Title 属性
            TextRenderer.DrawText(g, dataInfo.Title, this.ItemTitleFont, titleRect, forceColor, TextFormatFlags.EndEllipsis);
            //绘制邮件来源 From 属性
            TextRenderer.DrawText(g, "By:" + dataInfo.From, this.ItemSenderFont, fromRect, forceColor, TextFormatFlags.EndEllipsis);
            //绘制接收时间
            String receiveTime = dataInfo.ReceviceTime.ToString("yyyy-MM-dd HH:mm");
            TextRenderer.DrawText(g, receiveTime, this.ItemReceiveTimeFont, timeRect, forceColor, TextFormatFlags.EndEllipsis);

            backBrush.Dispose();

        }
        public EmailDataInfo RemoveSelectedItem()
        {
            var selected = this.SelectedEmailDataInfo;
            if (selected == null) return null;
            this.Items.Remove(selected);
            this.EmailDataInfos.Remove(selected);
            return selected;
        }
    }

}
