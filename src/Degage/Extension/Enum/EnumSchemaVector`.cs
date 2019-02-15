using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Concurrent;
namespace Degage.Extension
{
    public abstract class EnumSchemaVector
    {
        /// <summary>
        ///存储容器使用此对象以为容器填充 <see cref="EnumSchema"/> 信息，此提供器可被所有枚举类型的存储容器使用
        /// </summary>
        public static IEnumSchemaProvider Provider { get; set; } = new AttributeEnumSchemaProvider();
    }
    /// <summary>
    /// 存储 <see cref="EnumSchema"/> 信息的容器
    /// </summary>
    public class EnumSchemaVector<T> : EnumSchemaVector where T : Enum
    {
        /// <summary>
        /// 存储容器使用此对象以为容器填充 <see cref="EnumSchema"/> 信息，此提供器只被指定枚举类型的存储容器使用.
        /// 当此属性为空时，泛型容器会使用通用提供器以获取 Schema 信息
        /// </summary>
        public static IEnumSchemaProvider PrivateProvider { get; set; }

        /// <summary>
        /// Key 表示枚举的名称
        /// </summary>
        private static Dictionary<String, EnumSchema> _EnumSchemaTable;

        /// <summary>
        /// 通过指定的枚举值获取相应的 <see cref="EnumSchema"/> 信息，若无返回空引用。
        /// </summary>
        public static EnumSchema GetSchema(T enumValue)
        {
            EnumSchema schema = null;
            String enumName = enumValue.ToString();
            if (_EnumSchemaTable.ContainsKey(enumName))
            {
                schema = _EnumSchemaTable[enumName];
            }
            return schema;
        }

        static EnumSchemaVector()
        {

            _EnumSchemaTable = new Dictionary<String, EnumSchema>();

            Type enumType = typeof(T);

            IEnumSchemaProvider provider = EnumSchemaVector<T>.PrivateProvider ?? EnumSchemaVector.Provider;

            if (provider == null)
            {
                //TODO:EnumSchemaVector<T> 静态构造执行时，如果没有相应的 Provider ，需要抛出适当的异常信息。
            }

            //获取所有枚举值
            var enumValues = Enum.GetValues(enumType);


            foreach (T enumValue in enumValues)
            {
                String enumName = enumValue.ToString();
                var enumSchema = provider.GetSchema(enumType, enumValue);
                if (enumSchema != null)
                {
                    _EnumSchemaTable.Add(enumName, enumSchema);
                }
            }
        }
    }
}
