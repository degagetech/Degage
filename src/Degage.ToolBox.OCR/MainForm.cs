using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Imaging;
namespace Degage.ToolBox.OCR
{
    public partial class MainForm : Form
    {
        private OCRManager _ocrManager;
        public MainForm()
        {
            InitializeComponent();
            this.Shown += MainForm_Shown;
        }

        private async void MainForm_Shown(object sender, EventArgs e)
        {
            this._ocrManager = new OCRManager();
            await this._ocrManager.InitAsync();
        }



        private void _btnSelectLocal_Click(Object sender, EventArgs e)
        {
            var result = this._ofdSelectImage.ShowDialog();
            if (result == DialogResult.OK)
            {
                String selectedImagePath = this._ofdSelectImage.FileName;
                this._pbImage.ImageLocation = selectedImagePath;
            }
        }
        public Byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private void _btnScreenHost_Click(object sender, EventArgs e)
        {
            ScreenshotForm form = new ScreenshotForm();

            form.ShowDialog();
            if (form.ScreenhostsRect != null)
            {

                var rect = form.ScreenhostsRect.Value;

                Bitmap bitmap =
                    new Bitmap(
                        rect.Width,
                    rect.Height);
                Graphics g = Graphics.FromImage(bitmap);
                g.CopyFromScreen(rect.X, rect.Y, 0, 0, rect.Size);

                this._pbImage.Image = bitmap;
                g.Dispose();
            }
        }

        private async void _btnRecognition_Click(object sender, EventArgs e)
        {
            Byte[] imageBytes = this.ImageToByteArray(this._pbImage.Image);
            if (this._chbProcessAfter.Checked)
            {
                imageBytes = this.ImageToByteArray(this._disposePbImage.Image);
            }
            this._tbRecognitionResult.Text = "网络识别中....";
            this._tbRecognitionResult.Text = await this._ocrManager.GetImageAccurateTextAsync(imageBytes);
            imageBytes = null;
        }

        private async void _btnLocalRecognition_Click(object sender, EventArgs e)
        {
            Bitmap image = (Bitmap)this._pbImage.Image;
            if (this._chbProcessAfter.Checked)
            {
                image = (Bitmap)this._disposePbImage.Image; 
            }
            if (image == null)
            {
                return;
            }
            this._tbRecognitionResult.Text = "本地识别中....";
            this._tbRecognitionResult.Text = await this._ocrManager.GetImageTextLocalAsync(image);
            if (String.IsNullOrEmpty(this._tbRecognitionResult.Text))
            {
                this._tbRecognitionResult.Text = "未识别到文字信息！";
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._ocrManager?.Dispose();
        }

        private async void  _btnBinaryzation_ClickAsync(object sender, EventArgs e)
        {
            Bitmap image = (Bitmap)this._disposePbImage.Image;
            if (image == null)
            {
                image = (Bitmap)this._pbImage.Image;
            }
            
            if (image == null)
            {
                return;
            }
            this._tbRecognitionResult.Text = "正在进行图片二进化....";
            var resultImage= await this._ocrManager.BinaryzationImage(image,2);
            this._tbRecognitionResult.Text = String.Empty;
            _disposePbImage.Image = resultImage;
        }

        private async void _btnSharpening_Click(object sender, EventArgs e)
        {
            Bitmap image = (Bitmap)this._disposePbImage.Image;
            if (image == null)
            {
                image = (Bitmap)this._pbImage.Image;
            }

            if (image == null)
            {
                return;
            }
            this._tbRecognitionResult.Text = "正在进行图片锐化....";
            var resultImage = await this._ocrManager.SharpenImage(image);
            this._tbRecognitionResult.Text = String.Empty;
            _disposePbImage.Image = resultImage;
        }

        private async void _btnLocalRecognition1_Click(object sender, EventArgs e)
        {
            Bitmap image = (Bitmap)this._pbImage.Image;
            if (this._chbProcessAfter.Checked)
            {
                image = (Bitmap)this._disposePbImage.Image;
            }
            if (image == null)
            {
                return;
            }
            this._tbRecognitionResult.Text = "本地识别中....";
            var result = await this._ocrManager.GetImageStringsByLocalAsync(image);
            this._tbRecognitionResult.Text = String.Empty;
            foreach (var text in result)
            {
                this._tbRecognitionResult.Text += text;
            }

            if (String.IsNullOrEmpty(this._tbRecognitionResult.Text))
            {
                this._tbRecognitionResult.Text = "未识别到文字信息！";
            }
        }

        private async void _numScale_ValueChanged(object sender, EventArgs e)
        {
            Bitmap image = (Bitmap)this._pbImage.Image;

            if (image == null)
            {
                return;
            }
            this._tbRecognitionResult.Text = "正在进行图片缩放....";
            var resultImage = await this._ocrManager.ZoomImage(image,this._numScale.Value);
            this._tbRecognitionResult.Text = String.Empty;
            _disposePbImage.Image = resultImage;
        }
    }
}
