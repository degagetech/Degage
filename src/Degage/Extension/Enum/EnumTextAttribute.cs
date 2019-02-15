using System;
using System.Collections.Generic;
using System.Text;

namespace Degage.Extension
{
    /// <summary>
    /// 存储枚举值相关文本的元数据信息
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class EnumTextAttribute : System.Attribute
    {
        /// <summary>
        /// 枚举值的文本描述信息
        /// </summary>
        public String Text { get; set; }

        public EnumTextAttribute()
        {
        }

        public EnumTextAttribute(String text) : this()
        {
            this.Text = text;
        }
    }

}
