using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Degage.ToolBox.OCR
{
    /// <summary>
    /// 图像文字识别的结果
    /// </summary>
    public class RecognitionResult
    {

        /// <summary>
        /// 唯一的log id，用于问题定位
        /// </summary>
        [JsonProperty("log_id")]
        public String LogID { get; set; }

        /// <summary>
        /// 识别结果数，表示 words_result 的元素个数
        /// </summary>
        [JsonProperty("words_result_num")]
        public Int32 WordsResultNum { get; set; }

        /// <summary>
        /// 定位和识别结果数组
        /// </summary>
        [JsonProperty("words_result")]
        public RecognitionResultWords[] WordsItems { get; set; }
    }

    /// <summary>
    /// 文本识别的关键词
    /// </summary>
    public class RecognitionResultWords
    {
        /// <summary>
        /// 关键词
        /// </summary>
        [JsonProperty("words")]
        public String Words { get; set; }
    }
}
