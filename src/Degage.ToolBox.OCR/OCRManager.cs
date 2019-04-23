using Baidu.Aip.Ocr;
using Degage.OCR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace Degage.ToolBox.OCR
{
    public class OCRManager : IDisposable
    {

        /// <summary>
        /// 用于网络识别的客户端对象
        /// </summary>
        private Ocr _ocrNetworkClient;
        private TesseractEngine _ocrLocalClient;
        public OCRManager()
        {

        }
        public async Task InitAsync()
        {
            await Task.Run(() =>
            {
                this.Init();
            });
        }
        public void Init()
        {

            String langDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tessdata");
            _ocrLocalClient = new TesseractEngine(langDataPath, "chi_sim", EngineMode.Default);//设置语言   中文



            //初始化网络识别对象
            var apiKey = "V2DIVPIpL9tu0ETmzoiLuzlX";
            var secretKey = "z3ggwpvVEQFlVbHfeBL2GC94l2K72rKR";

            _ocrNetworkClient = new Ocr(apiKey, secretKey);
            _ocrNetworkClient.Timeout = 5000;  // 修改超时时间
        }
        /// <summary>
        /// 通过本地计算识别图像中的文本
        /// </summary>
        /// <returns></returns>
        public String GetImageTextByLocal(Bitmap image)
        {
            String result = null;
            var page = this._ocrLocalClient.Process(image);
            result = page.GetText();
            page.Dispose();
            return result;
        }
        /// <summary>
        /// 通过本地计算识别图像中的文本信息单词组，若无则返回一个包含零个元素的列表
        /// </summary>
        /// <returns></returns>
        public List<String> GetImageStringsByLocal(Bitmap image)
        {
            List<String> result = new List<String>();
            var page = this._ocrLocalClient.Process(image);

            var ri = page.GetIterator();
            var level = PageIteratorLevel.Word;
            while (ri.Next(level))
            {
                var text = ri.GetText(level);
                if (String.IsNullOrEmpty(text))
                {
                    continue;
                }
                result.Add(text);
            }
            page.Dispose();
            return result;
        }
        public Task<List<String>> GetImageStringsByLocalAsync(
        Bitmap image)
        {
            return Task.Run<List<String>>(() =>
            {
                return this.GetImageStringsByLocal(image);
            });
        }

        public Task<String> GetImageTextLocalAsync(
                Bitmap image)
        {
            return Task.Run<String>(() =>
              {
                  return this.GetImageTextByLocal(image);
              });
        }
        /// <summary>
        /// 异步以获取图像文本识别的结果
        /// </summary>
        /// <param name="imageBytes"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<RecognitionResult> GetImageTextResusltAsync(
             Byte[] imageBytes,
            Dictionary<String, Object> options = null)
        {
            Task<RecognitionResult> task = Task.Run<RecognitionResult>(() =>
            {
                return this.GetImageTextResuslt(imageBytes, options);
            });
            return task;
        }
        /// <summary>
        /// 获取图像文本识别的结果
        /// </summary>
        /// <param name="imageBytes"></param>
        /// <returns></returns>
        public RecognitionResult GetImageTextResuslt(
            Byte[] imageBytes,
            Dictionary<String, Object> options = null)
        {

            var reponse = this._ocrNetworkClient.GeneralBasic(imageBytes, options);
            var recognitionResult = reponse.ToObject<RecognitionResult>();
            return recognitionResult;
        }

        internal Task<Bitmap> SharpenImage(Bitmap image)
        {
            return Task.Run<Bitmap>(()=>GetSharpenImage(image));
        }

        private Bitmap GetSharpenImage(Bitmap image)
        {
            int height = image.Height;
            int width = image.Width;
            Bitmap newbmp = new Bitmap(width, height);

            Color pixel;
            //拉普拉斯模板
            int[] Laplacian = { -1, -1, -1, -1, 9, -1, -1, -1, -1 };
            for (int x = 1; x < width - 1; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    int r = 0, g = 0, b = 0;
                    int Index = 0;
                    for (int col = -1; col <= 1; col++)
                    {
                        for (int row = -1; row <= 1; row++)
                        {
                            pixel = image.GetPixel(x + row, y + col); r += pixel.R * Laplacian[Index];
                            g += pixel.G * Laplacian[Index];
                            b += pixel.B * Laplacian[Index];
                            Index++;
                        }
                    }
                    //处理颜色值溢出
                    r = r > 255 ? 255 : r;
                    r = r < 0 ? 0 : r;
                    g = g > 255 ? 255 : g;
                    g = g < 0 ? 0 : g;
                    b = b > 255 ? 255 : b;
                    b = b < 0 ? 0 : b;
                    newbmp.SetPixel(x - 1, y - 1, Color.FromArgb(r, g, b));
                }
            }
            return newbmp;
        }

        /// <summary>
        /// 获取图像识别所得的文本信息
        /// </summary>
        /// <param name="imageBytes"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<String> GetImageTextAsync(
             Byte[] imageBytes,
            Dictionary<String, Object> options = null)
        {
            Task<String> task = Task.Run<String>(() =>
            {
                return this.GetImageText(imageBytes, options);
            });
            return task;
        }

        internal Task<Bitmap> ZoomImage(Bitmap image, decimal value)
        {
            return Task.Run<Bitmap>(() =>
            {
                return this.GetZoomImage(image, value);
            });
        }

        private Bitmap GetZoomImage(Bitmap image, decimal value)
        {
            int sizeWidth =(int)(image.Width * (1 + value / 100));
            int sizeHeight = (int)(image.Height * (1 + value / 100));
            Bitmap newbmp = new Bitmap(sizeWidth, sizeHeight);
            using (Graphics g = Graphics.FromImage(newbmp))
            {
                g.DrawImage(image, new Rectangle(0,0,sizeWidth,sizeHeight));
            }
            return newbmp;
        }

        internal Task<Bitmap> BinaryzationImage(Bitmap image, int type)
        {
            return Task.Run<Bitmap>(() =>
            {
                return this.GetBinaryzationImage(image, type);
            });
        }

        private Bitmap GetBinaryzationImage(Bitmap image, int type)
        {
            int height = image.Height;
            int width = image.Width;
            Bitmap newbmp = new Bitmap(width, height);

            Color pixel;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    pixel = image.GetPixel(x, y);
                    int r, g, b, Result = 0;
                    r = pixel.R;
                    g = pixel.G;
                    b = pixel.B;
                    switch (type)
                    {
                        case 0://平均值法
                            Result = ((r + g + b) / 3);
                            break;
                        case 1://最大值法
                            Result = r > g ? r : g;
                            Result = Result > b ? Result : b;
                            break;
                        case 2://加权平均值法
                            Result = ((int)(0.3 * r) + (int)(0.59 * g) + (int)(0.11 * b));
                            break;
                    }
                    newbmp.SetPixel(x, y, Color.FromArgb(Result, Result, Result));
                }
            }
            return newbmp;
        }


        /// <summary>
        /// 获取图像识别所得的文本信息
        /// </summary>
        /// <param name="imageBytes">图像原始内容的字节</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public String GetImageText(
            Byte[] imageBytes,
            Dictionary<String, Object> options = null)
        {
            var recognitionResult = this.GetImageTextResuslt(imageBytes, options);
            StringBuilder builder = new StringBuilder();
            foreach (var wordsItem in recognitionResult.WordsItems)
            {
                if (wordsItem.Words != null)
                {
                    builder.Append(wordsItem.Words);
                }

            }
            return builder.ToString();
        }


        /// <summary>
        /// 异步以获取图像文本识别的结果
        /// </summary>
        /// <param name="imageBytes"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<RecognitionResult> GetImageTextAccurateResusltAsync(
             Byte[] imageBytes,
            Dictionary<String, Object> options = null)
        {
            Task<RecognitionResult> task = Task.Run<RecognitionResult>(() =>
            {
                return this.GetImageTextAccurateResuslt(imageBytes, options);
            });
            return task;
        }
        /// <summary>
        /// 获取图像文本识别的结果
        /// </summary>
        /// <param name="imageBytes"></param>
        /// <returns></returns>
        public RecognitionResult GetImageTextAccurateResuslt(
            Byte[] imageBytes,
            Dictionary<String, Object> options = null)
        {

            var reponse = this._ocrNetworkClient.AccurateBasic(imageBytes, options);
            var recognitionResult = reponse.ToObject<RecognitionResult>();
            return recognitionResult;
        }



        /// <summary>
        /// 获取图像识别所得的文本信息
        /// </summary>
        /// <param name="imageBytes"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<String> GetImageAccurateTextAsync(
             Byte[] imageBytes,
            Dictionary<String, Object> options = null)
        {
            Task<String> task = Task.Run<String>(() =>
            {
                return this.GetImageAccurateText(imageBytes, options);
            });
            return task;
        }


        /// <summary>
        /// 获取图像识别所得的文本信息
        /// </summary>
        /// <param name="imageBytes">图像原始内容的字节</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public String GetImageAccurateText(
            Byte[] imageBytes,
            Dictionary<String, Object> options = null)
        {
            var recognitionResult = this.GetImageTextAccurateResuslt(imageBytes, options);
            StringBuilder builder = new StringBuilder();
            foreach (var wordsItem in recognitionResult.WordsItems)
            {
                if (wordsItem.Words != null)
                {
                    builder.Append(wordsItem.Words);
                }

            }
            return builder.ToString();
        }

        public void Dispose()
        {
            _ocrLocalClient?.Dispose();
        }
    }
}
