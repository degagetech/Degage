using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Degage.DataModel.Schema.Toolbox
{
    /// <summary>
    /// 表示一种帕斯卡风格的符号修饰器
    /// </summary>
    public class PascalSymbolModifier : ISymbolModifier
    {
        /// <summary>
        /// 实现 <see cref="ISymbolModifier.Modify(String, SymbolModifyType)"/>
        /// </summary>
        /// <param name="sourceSymbol"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public String Modify(String sourceSymbol, SymbolModifyType type)
        {
            String result = String.Empty;
            switch (type)
            {
                case SymbolModifyType.ClassName:
                    {
                        //ac_bc=> AcBc, ac bc=>AcBc，ac-ba=>AcBc
                        //首先进行分词操作
                        var splitResult = this.SplitSymbol(sourceSymbol);
                        //将每个单词的首字母大写
                        foreach (var word in splitResult)
                        {
                            result += this.FirstWordUpperOrLower(word);
                        }
                    }
                    break;
                case SymbolModifyType.FieldName:
                    {
                        //ac_bc=>_acBc，ac bc=>_acBc
                        var splitResult = this.SplitSymbol(sourceSymbol);
                        var firstWord = splitResult.Take(1).FirstOrDefault();
                        if (firstWord != null)
                        {
                            result += ("_" + this.FirstWordUpperOrLower(firstWord, false));
                        }
                        if (splitResult.Length > 1)
                        {
                            foreach (var word in splitResult.Skip(1))
                            {
                                result += this.FirstWordUpperOrLower(word);
                            }
                        }
                    }
                    break;
                case SymbolModifyType.PropertyName:
                    {
                        //ac_bc=> AcBc, ac bc=>AcBc，ac-ba=>AcBc
                        var splitResult = this.SplitSymbol(sourceSymbol);
                        foreach (var word in splitResult)
                        {
                            result += this.FirstWordUpperOrLower(word);
                        }
                    }
                    break;
                case SymbolModifyType.Other:
                default:
                    {
                        result = sourceSymbol;
                    }
                    break;
            }
            return result;
        }
        private String[] SplitSymbol(String symbol)
        {
            var result = symbol.Split('_', '-', ' ').ToList();
            return result.Where(t => !String.IsNullOrWhiteSpace(t)).ToArray();
        }

        private String FirstWordUpperOrLower(String word, Boolean upper = true)
        {
            String result = word;
            if (result.Length < 1)
            {
                return String.Empty;
            }
            if (upper)
            {
                result = result.Substring(0, 1).ToUpper() + result.Substring(1);
            }
            else
            {
                result = result.Substring(0, 1).ToLower() + result.Substring(1);
            }
            return result;
        }
    }

}
