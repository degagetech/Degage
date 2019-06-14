using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPerformance
{
    public class EmailFilterConfig : Config
    {
        static readonly Char SplitSymbol = ';';
        public EmailFilterConfig()
        {
        }
        /// <summary>
        /// 采集最近的天数
        /// </summary>
        public Int32 CollectRecentDays { get; set; } = 30;
        /// <summary>
        /// 采集邮件标题含有的关键词集合
        /// </summary>
        public String[] TitleKeywords { get; set; } = new[] { "绩效" };

        /// <summary>
        /// 将指定字符串拆分为关键词
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public String[] SplitKeywords(String str)
        {
            var keywords = str.Split(SplitSymbol);
            var vaildKeywords = new List<String>();
            foreach (String word in keywords)
            {
                if (String.IsNullOrWhiteSpace(word))
                {
                    continue;
                }
                vaildKeywords.Add(word);
            }
            return vaildKeywords.ToArray();
        }
        public String GetTitleKeywordsString()
        {
            String result = String.Empty;
            foreach (var str in this.TitleKeywords)
            {
                result += str + SplitSymbol;
            }
            result = result.TrimEnd(SplitSymbol);
            return result;
        }
    }
}
