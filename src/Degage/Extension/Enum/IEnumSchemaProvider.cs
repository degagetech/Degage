using System;
using System.Collections.Generic;
using System.Text;

namespace Degage.Extension
{
    /// <summary>
    /// 提供一组方法以获取相应的 <see cref="EnumSchema"/> 信息
    /// </summary>
    public interface IEnumSchemaProvider
    {
        /// <summary>
        /// 获取指定枚举类型中指定枚举值的 Schema 信息，若无返回空引用
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <param name="enumValue">枚举值</param>
        /// <returns></returns>
        EnumSchema GetSchema(Type enumType, System.Enum enumValue);
    }
}
