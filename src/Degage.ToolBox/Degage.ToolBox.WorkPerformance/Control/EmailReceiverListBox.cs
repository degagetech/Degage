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
    public class EmailReceiverListBox : BaseListBox
    {
        public EmailReceiverItem SelectedEmailReceiverItem
        {
            get
            {
                if (this.SelectedIndex == -1) return null;
                var info = this.Items[this.SelectedIndex] as EmailReceiverItem;
                return info;
            }
        }


        public List<EmailReceiverItem> EmailReceiverItems { get; private set; } = new List<EmailReceiverItem>();
        public EmailReceiverListBox() : base()
        {
            this.BackColor = Color.FromArgb(((Int32)(((Byte)(231)))), ((Int32)(((Byte)(242)))), ((Int32)(((Byte)(238)))));
            this.ForeColor = Color.White;
            this.ItemHeight = 30;
            this.Margin = new Padding(0);
            this.Font = new System.Drawing.Font("微软雅黑 Light", 12F);
            this.DrawItem += CustomDrawItem; ;
        }




        private void CustomDrawItem(Object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1 || this.DesignMode)
            {
                return;
            }
            var obj = this.Items[e.Index];
            EmailReceiverItem receiverInfo = obj as EmailReceiverItem;
            if (receiverInfo == null) return;
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            var forceColor = e.ForeColor;
            var backgroundColor = e.BackColor;
            Int32 textBeginX = 5;
            Int32 textBeginY = 3;

            var backgroudRect = new Rectangle(e.Bounds.X - 1, e.Bounds.Y - 1, e.Bounds.Width + 1, e.Bounds.Height + 2);
            var attachmentFlagRect = new Rectangle(5, 5, 20, 20);
            if (this.MouseHoverItemIndex == e.Index)
            {
                backgroundColor = Color.FromArgb(190, 190, 190);
            }
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                backgroundColor = Color.FromArgb(175, 175, 175);
            }
            Brush backBrush = new SolidBrush(backgroundColor);
            g.FillRectangle(backBrush, backgroudRect);

            var nameRect = new Rectangle(textBeginX, textBeginY, e.Bounds.Width - textBeginX, e.Bounds.Height);
            //绘制接收人名称
            TextRenderer.DrawText(g, receiverInfo.ReceiverName, e.Font, nameRect, e.ForeColor, TextFormatFlags.EndEllipsis);
            //计算名称占用大小
            var nameDrawSize = TextRenderer.MeasureText(receiverInfo.ReceiverName, e.Font);
            textBeginX += nameDrawSize.Width;
            //间隔
            textBeginX += 20;
            var addressRect = new Rectangle(textBeginX, textBeginY, e.Bounds.Width - textBeginX, e.Bounds.Height);
            //绘制接收人邮件地址
            TextRenderer.DrawText(g, receiverInfo.ReceiverEmailAddress, e.Font, addressRect, e.ForeColor, TextFormatFlags.EndEllipsis);
        }


        public void ShowReceiverInfo(List<EmailReceiverItem> infos)
        {
            this.Items.Clear();
            this.EmailReceiverItems = infos;

            this.Items.AddRange(infos.ToArray());
        }

        public void AddEmailReceiverItem(EmailReceiverItem info)
        {
            this.EmailReceiverItems.Add(info);
            this.Items.Add(info);
            this.Refresh();
        }


        public EmailReceiverItem RemoveSelectedItem()
        {
            var selected = this.SelectedEmailReceiverItem;
            if (selected == null) return null;
            this.Items.Remove(selected);
            this.EmailReceiverItems.Remove(selected);
            return selected;
        }
    }
}
