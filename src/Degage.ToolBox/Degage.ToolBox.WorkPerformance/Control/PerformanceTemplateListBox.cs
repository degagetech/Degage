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
    public class PerformanceTemplateListBox : BaseListBox
    {
        public PerformanceTemplateInfo SelectedPerformanceTemplateInfo
        {
            get
            {
                if (this.SelectedIndex == -1) return null;
                var info = this.Items[this.SelectedIndex] as PerformanceTemplateInfo;
                return info;
            }
        }
        /// <summary>
        /// 项：模板文件不存在时的图标
        /// </summary>
        [Category("项样式")]
        [Description("项：模板文件不存在时的图标")]
        public Image NotExistedTemplateFileImage { get; set; }
        /// <summary>
        /// 项：模板文件存在时的图标
        /// </summary>
        [Category("项样式")]
        [Description("项：模板文件存在时的图标")]
        public Image ExistedTemplateFileImage { get; set; }

        public List<PerformanceTemplateInfo> PerformanceTemplateInfos { get; private set; } = new List<PerformanceTemplateInfo>();
        public PerformanceTemplateListBox() : base()
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
            PerformanceTemplateInfo templateInfo = obj as PerformanceTemplateInfo;
            if (templateInfo == null) return;
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            var forceColor = e.ForeColor;
            var backgroundColor = e.BackColor;
            Int32 iconWidth = 30;
            Int32 textBeginX = iconWidth;
            Int32 textBeginY = 3;

            var backgroudRect = new Rectangle(e.Bounds.X - 1, e.Bounds.Y - 1, e.Bounds.Width + 1, e.Bounds.Height + 2);
            var templateFlagRect = new Rectangle(5, 5, 20, 20);
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

            var templateFlagImage = templateInfo.IsExistedTemplateFile ? this.ExistedTemplateFileImage : this.NotExistedTemplateFileImage;
            if (templateFlagImage != null)
            {
                g.DrawImage(templateFlagImage, templateFlagRect);
            }

            //绘制模板名称
            TextRenderer.DrawText(g, templateInfo.Name, e.Font, nameRect, e.ForeColor, TextFormatFlags.EndEllipsis);
        }


        public void ShowPerformanceTemplateInfo(List<PerformanceTemplateInfo> infos)
        {
            this.Items.Clear();
            this.PerformanceTemplateInfos = infos;

            this.Items.AddRange(infos.ToArray());
        }


        /// <summary>
        /// 添加指定模板到控件中
        /// </summary>
        /// <param name="info"></param>
        /// <param name="requiredSaved"></param>
        public void AddFirstPerformanceTemplateInfo(PerformanceTemplateInfo info)
        {

            this.PerformanceTemplateInfos.Insert(0, info);
            this.Items.Insert(0, info);
            this.Refresh();
        }

        public PerformanceTemplateInfo RemoveSelectedItem()
        {
            var selected = this.SelectedPerformanceTemplateInfo;
            if (selected == null) return null;
            this.Items.Remove(selected);
            this.PerformanceTemplateInfos.Remove(selected);
            return selected;
        }
    }
}
