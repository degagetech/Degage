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
    public class BaseListBox : ListBox
    {
        /// <summary>
        /// 鼠标当前悬停项的索引
        /// </summary>
        public Int32 MouseHoverItemIndex { get; protected set; } = -1;
        /// <summary>
        /// 上一次选中项的索引
        /// </summary>
        public Int32 OldSelectedIndex { get; protected set; } = -1;

        public BaseListBox() : base()
        {
            this.BorderStyle = BorderStyle.None;
            this.DrawMode = DrawMode.OwnerDrawVariable;
            this.FormattingEnabled = true;
        }
        /// <summary>
        /// 重置各项由 <see cref="BaseListBox"/> 维护的索引信息
        /// </summary>
        public void ResetIndex()
        {
            this.MouseHoverItemIndex = -1;
            this.OldSelectedIndex = -1;
        }
        /// <summary>
        /// 刷新指定索引项的绘制
        /// </summary>
        /// <param name="itemIndex">项的索引</param>
        public void RefreshItemDraw(Int32 itemIndex)
        {
            if (itemIndex == -1 || itemIndex == UInt16.MaxValue || itemIndex > this.Items.Count)
            {
                return;
            }
            //重绘指定索引的项
            var rect = this.GetItemRectangle(itemIndex);
            this.Invalidate(rect);
        }
        private void MouseHotTracking(Point p)
        {
            if (!this.DesignMode)
            {
                var index = this.IndexFromPoint(p);

                if (index != this.MouseHoverItemIndex)
                {
                    this.RefreshItemDraw(this.MouseHoverItemIndex);
                    this.RefreshItemDraw(index);
                    this.MouseHoverItemIndex = index;
                }
            }
        }
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            this.OldSelectedIndex = this.SelectedIndex;
            base.OnSelectedIndexChanged(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (this.MouseHoverItemIndex > -1)
            {
                this.RefreshItemDraw(this.MouseHoverItemIndex);
                this.MouseHoverItemIndex = -1;
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            this.MouseHotTracking(e.Location);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (this.DesignMode)
            {
                base.OnDrawItem(e);
                return;
            }


            BufferedGraphicsContext currentContext = BufferedGraphicsManager.Current;

            Rectangle newBounds = new Rectangle(0, 0, e.Bounds.Width, e.Bounds.Height);
            using (BufferedGraphics bufferedGraphics = currentContext.Allocate(e.Graphics, newBounds))
            {
                DrawItemEventArgs newArgs = new DrawItemEventArgs(
                    bufferedGraphics.Graphics, e.Font, newBounds, e.Index, e.State, e.ForeColor, e.BackColor);
                base.OnDrawItem(newArgs);

                // 通过GDI复制图形数据
                GDI.CopyGraphics(e.Graphics, e.Bounds, bufferedGraphics.Graphics, new Point(0, 0));
            }
        }
    }
}
