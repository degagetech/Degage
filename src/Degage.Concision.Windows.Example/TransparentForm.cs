using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Degage.Native.Windows;
namespace Degage.Concision.Windows.Example
{
    public partial class TransparentForm : Form
    {
        public TransparentForm()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var getReuslt = WindowsApi.GetWindowsLong(this.Handle, WindowsLongType.ExStyle);
            if (getReuslt.Success)
            {
                var setResult = WindowsApi.SetWindowLong(this.Handle, WindowsLongType.ExStyle,
                     getReuslt.Result | (Int32)WindowsStyleType.ExTransparent | (Int32)WindowsStyleType.ExLayered);
                if (!setResult.Success)
                {
                    MessageBox.Show("设置失败！" + setResult.ErrorCodeValue);
                }
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            var pen = new Pen(Color.Black, 5);
            var brush = new SolidBrush(Color.Black);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.FillEllipse(brush, new RectangleF(10, 10, 1000, 200));
            brush.Dispose();
            pen.Dispose();
        }
    }
}
