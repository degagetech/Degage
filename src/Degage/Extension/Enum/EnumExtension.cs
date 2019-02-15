using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections.Concurrent;

namespace Degage.Extension
{
    /// <summary>
    /// 为枚举类型提供一些扩展方法
    /// </summary>
    public static class EnumExtension
    {

        /// <summary>
        /// 获取与指定枚举值关联的文本描述信息，此方法获取附加在枚举值上的 <see cref="EnumTextAttribute"/> 特性对象包含的值，若无附加返回空引用
        /// </summary>
        /// <param name="enumValue">枚举值</param>
        /// <returns></returns>
        public static String EnumText<T>(this T enumValue) where T : Enum
        {
            return EnumSchemaVector<T>.GetSchema(enumValue)?.Text;

        }

        /// <summary>
        /// 获取与指定枚举值关联的颜色描述信息，此方法获取附加在枚举值上的 <see cref="EnumColorAttribute"/> 特性对象包含的值，若无附加返回空引用
        /// </summary>
        /// <param name="enumValue">枚举值</param>
        /// <returns></returns>
        public static Color? EnumColor<T>(this T enumValue) where T : Enum
        {
            return EnumSchemaVector<T>.GetSchema(enumValue)?.Color;
        }


    }
}
