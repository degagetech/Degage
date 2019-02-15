using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Collections;
using System.Linq;
using System.Drawing;

namespace Degage.Extension
{
    /// <summary>
    /// 提供从附加在枚举值的特性上获取 <see cref="EnumSchema"/> 信息的支持
    /// </summary>
    internal class AttributeEnumSchemaProvider : IEnumSchemaProvider
    {
        /// <summary>
        /// 获取指定枚举类型中指定枚举值的 Schema 信息，若无返回空引用
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <param name="enumValue">枚举值</param>
        /// <returns></returns>
        public virtual EnumSchema GetSchema(Type enumType, System.Enum enumValue)
        {
            EnumSchema schema = null;
            String enumName = enumValue.ToString();
            FieldInfo fieldInfo = enumType.GetField(enumName);

            //获取文本信息
            EnumTextAttribute textAttr = (fieldInfo.GetCustomAttributes(typeof(EnumTextAttribute), false) as EnumTextAttribute[])?.FirstOrDefault();
            if (textAttr != null)
            {
                schema = schema ?? new EnumSchema();
                schema.Text = textAttr.Text;
            }

            //获取颜色信息
            EnumColorAttribute colorAttr = (fieldInfo.GetCustomAttributes(typeof(EnumColorAttribute), false) as EnumColorAttribute[])?.FirstOrDefault();
            if (colorAttr != null)
            {
                schema = schema ?? new EnumSchema();
                schema.Color = colorAttr.Color;
            }

            return schema;
        }
    }
}
