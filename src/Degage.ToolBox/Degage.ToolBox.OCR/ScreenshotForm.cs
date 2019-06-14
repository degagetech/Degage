using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Degage.ToolBox.OCR
{
    public partial class ScreenshotForm : Form
    {

        public Rectangle? ScreenhostsRect { get; private set; }
        public ScreenshotForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.DoubleBuffered = true;

        }



        private void ScreenshotForm_Shown(object sender, EventArgs e)
        {

        }

        private Point _recordPoint;
        private Rectangle _screenhostsRect;
        private Boolean _isEnterScreenhosts;

        private void ScreenshotForm_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ScreenshotForm_MouseDown(Object sender, MouseEventArgs e)
        {
            this._recordPoint = e.Location;
            this._isEnterScreenhosts = true;
        }

        private void ScreenshotForm_Paint(Object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            Color tipInfoColor = Color.White;
            String formSizeText = this.Size.ToString();
            TextRenderer.DrawText(g, formSizeText, this.Font, new Point(0, 0), tipInfoColor);
            if (this._isEnterScreenhosts)
            {
                var startPoint = this._recordPoint;
                var currentPoint = Form.MousePosition;

                //绘制起始点
                var formSizeTextSize = TextRenderer.MeasureText(formSizeText, this.Font);
                var startPointText = startPoint.ToString();
                TextRenderer.DrawText(g, startPointText, this.Font, new Point(0, formSizeTextSize.Height+2), tipInfoColor);
                //绘制当前点
                var currentPointText = currentPoint.ToString();
                TextRenderer.DrawText(g, currentPointText, this.Font, new Point(0, formSizeTextSize.Height*2 + 2*2), tipInfoColor);

                Pen pen = new Pen(Color.Black, 3);
                Brush brush = new SolidBrush(this.TransparencyKey);
                Rectangle rect = new Rectangle(startPoint.X, startPoint.Y,
                    currentPoint.X - startPoint.X,
                    currentPoint.Y - startPoint.Y);
                //var scaleFactor = g.DpiX / 96;
                //_screenhostsRect =new Rectangle((Int32)(rect.X* scaleFactor),(Int32)(rect.Y* scaleFactor), (Int32)(scaleFactor *rect.Width), (Int32)(scaleFactor *rect.Height)) ;
                _screenhostsRect = rect;
                g.DrawRectangle(pen, rect);
                g.FillRectangle(brush, rect);
                pen.Dispose();
                brush.Dispose();

            }


            //  g.DrawString();
        }

        private void ScreenshotForm_MouseMove(Object sender, MouseEventArgs e)
        {
            this.Refresh();
        }

        private void ScreenshotForm_Load(Object sender, EventArgs e)
        {

        }

        private void ScreenshotForm_MouseUp(Object sender, MouseEventArgs e)
        {
            this.ScreenhostsRect = this._screenhostsRect;
            this.Close();
        }



     
    }
}
