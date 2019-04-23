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
    public class AttachmentListBox : BaseListBox
    {
        public EmailAttachmentInfo SelectedEmailAttachmentInfo
        {
            get
            {
                if (this.SelectedIndex == -1) return null;
                var info = this.Items[this.SelectedIndex] as EmailAttachmentInfo;
                return info;
            }
        }
        /// <summary>
        /// 项：已保存的附件的图标
        /// </summary>
        [Category("项样式")]
        [Description("项：已保存的附件的图标")]
        public Image SavedAttachmentFlagImage { get; set; }
        /// <summary>
        /// 项：默认附件图标
        /// </summary>
        [Category("项样式")]
        [Description("项：默认附件图标")]
        public Image DefaultAttachmentImage { get; set; }

        public List<EmailAttachmentInfo> AttachmentInfos { get; private set; } = new List<EmailAttachmentInfo>();
        public AttachmentListBox() : base()
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
            EmailAttachmentInfo attachInfo = obj as EmailAttachmentInfo;
            if (attachInfo == null) return;
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            var forceColor = e.ForeColor;
            var backgroundColor = e.BackColor;
            Int32 iconWidth = 30;
            Int32 textBeginX = iconWidth;
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

            var nameRect = new Rectangle(textBeginX, textBeginY, e.Bounds.Width - iconWidth, e.Bounds.Height);

            var attachmentFlagImage = attachInfo.IsSaved ? this.SavedAttachmentFlagImage : this.DefaultAttachmentImage;
            if (attachmentFlagImage != null)
            {
                g.DrawImage(attachmentFlagImage, attachmentFlagRect);
            }

            //绘制附件名称属性
            TextRenderer.DrawText(g, attachInfo.Name, e.Font, nameRect, e.ForeColor, TextFormatFlags.EndEllipsis);
        }


        public void ShowAttachmentInfo(List<EmailAttachmentInfo> infos)
        {
            this.Items.Clear();
            this.AttachmentInfos = infos;

            this.Items.AddRange(infos.ToArray());
        }
        /// <summary>
        /// 判断当前控件中是否已经存在相同存储路径的附件信息
        /// </summary>
        /// <param name="savePath"></param>
        /// <returns></returns>
        public Boolean ExistedAttachmentInfoBySavePath(String savePath)
        {
            Boolean isExisted = false;
            if (String.IsNullOrEmpty(savePath)) return isExisted;
            savePath = savePath.ToLower();
            foreach (var info in this.AttachmentInfos)
            {
                if (info.SavePath?.ToLower() == savePath)
                {
                    isExisted = true;
                    break;
                }
            }
            return isExisted;
        }

        /// <summary>
        /// 添加指定附件信息到控件中，并指定对附件是否已保存的检查，开启后相同保存路径的附件或未保存的附件，无法通过此函数添加
        /// </summary>
        /// <param name="info"></param>
        /// <param name="requiredSaved"></param>
        public void AddFirstAttachmentInfo(EmailAttachmentInfo info, Boolean checkSaved = false)
        {
            if (checkSaved)
            {
                if (!info.IsSaved) return;
                if (this.ExistedAttachmentInfoBySavePath(info.SavePath))
                {
                    return;
                }
            }
            this.AttachmentInfos.Insert(0, info);
            this.Items.Insert(0, info);
            this.Refresh();
        }

        public EmailAttachmentInfo RemoveSelectedItem()
        {
            var selected = this.SelectedEmailAttachmentInfo;
            if (selected == null) return null;
            this.Items.Remove(selected);
            this.AttachmentInfos.Remove(selected);
            return selected;
        }
    }
}
