using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
namespace Degage.ToolBox.Pdf
{
    public partial class MainForm : Form
    {
        public List<System.Drawing.Image> SelectedImages { get; private set; } = new List<System.Drawing.Image>();
        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(Object sender, EventArgs e)
        {
            this._ofdSelectedImages.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            this._sfSavePdf.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        private async void _btnGenerate_Click(Object sender, EventArgs e)
        {
            if (this.SelectedImages.Count == 0) return;
            var result = this._sfSavePdf.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }
            String outPath = this._sfSavePdf.FileName;
            this.SwitchFunctionState(false);
            try
            {
                this.ShowTipInfo("稍后，正在生成 PDF 文档...");
                await this.GeneratePdfByImagesAsync(this.SelectedImages, outPath);
                this.ShowTipInfo("已保存至 "+ outPath);
            }
            finally
            {
                this.SwitchFunctionState(true);
            }
        }
        private void SwitchFunctionState(Boolean enabled = true)
        {
            this._btnGenerate.Enabled = enabled;
            this._btnSelect.Enabled = enabled;
        }
        public async Task GeneratePdfByImagesAsync(IList<System.Drawing.Image> images, String outPath)
        {
            await Task.Run(() =>
            {
                this.GeneratePdfByImages(images, outPath);
            });
        }
        public void ShowTipInfo(String tipInfo)
        {
            this._lblTipInfo.Text = tipInfo;
        }
        public void GeneratePdfByImages(IList<System.Drawing.Image> images, String outPath)
        {
            Document doc = new Document();
            FileStream stream = null;
            if (!File.Exists(outPath))
            {
                stream = File.Create(outPath);
            }
            else
            {
                stream = File.Open(outPath, FileMode.Open, FileAccess.ReadWrite);
            }

            var pdfWriter = PdfWriter.GetInstance(doc, stream);
            doc.Open();
            foreach (var image in images)
            {
                var textImage = iTextSharp.text.Image.GetInstance(image, image.RawFormat);
                textImage.ScaleToFit(doc.PageSize);
                if (textImage.Height > textImage.Width)
                {
                    //Maximum height is 800 pixels.
                    float percentage = 0.0f;
                    percentage = 700 / textImage.Height;
                    textImage.ScalePercent(percentage * 100);
                }
                else
                {
                    //Maximum width is 600 pixels.
                    float percentage = 0.0f;
                    percentage = 540 / textImage.Width;
                    textImage.ScalePercent(percentage * 100);
                }

                textImage.Border = iTextSharp.text.Rectangle.BOX;
                textImage.BorderColor = iTextSharp.text.BaseColor.BLACK;
                textImage.BorderWidth = 3f;
                doc.Add(textImage);
                doc.NewPage();
            }
            doc.Close();
            stream.Close();
        }

        private void _btnSelecte_Click(Object sender, EventArgs e)
        {
            var result = _ofdSelectedImages.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }
        
            String[] filenames = this._ofdSelectedImages.FileNames;
            this._flpImageContainer.SuspendLayout();
            this._flpImageContainer.Controls.Clear();
            this.SelectedImages.ForEach(t => t.Dispose());
            this.SelectedImages.Clear();
            foreach (var filename in filenames)
            {
                ImageControl control = new ImageControl();
                control.ShowImage(filename);
                this.SelectedImages.Add(control.DisplayImage);
                this._flpImageContainer.Controls.Add(control);
            }
            this._flpImageContainer.ResumeLayout();
        }

        #region 窗体点击任意位置拖动
        private Point _currentMousePoint;
        private Boolean _isMoving = false;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (MouseButtons.Left == e.Button)
            {
                this._currentMousePoint = e.Location;
                this._isMoving = true;
            }
            base.OnMouseDown(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (this._isMoving)
            {
                /**计算Point偏移值*/
                Int32 offsetX = e.Location.X - this._currentMousePoint.X;
                Int32 offsetY = e.Location.Y - this._currentMousePoint.Y;

                this.Location = new Point(this.Location.X + offsetX, this.Location.Y + offsetY);
            }
            base.OnMouseMove(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            this._isMoving = false;
            base.OnMouseUp(e);
        }
        #endregion

        private void _btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
