using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace Degage.DataModel.Schema.Toolbox
{
    /// <summary>
    /// 描述数据库类库与 .NET 类型关系映射的配置
    /// </summary>
    [XmlRoot("TypeMap")]
    public class TypeMapConfig
    {
        /// <summary>
        /// 映射配置的名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 映射描述项的集合
        /// </summary>
        [XmlArrayItem(ElementName ="Item")]
        public TypeMapItem[] MapItems { get; set; }

        /// <summary>
        /// 类型映射信息来源文件路径，在从文件中加载映射信息时，此属性会被填充
        /// </summary>
        internal String FromFilePath { get; set; }
    }
    /// <summary>
    ///描述具体数据库类型与 .NET 类型的映射关系的项
    /// </summary>
    public class TypeMapItem
    {
        /// <summary>
        ///类型映射的条件
        /// </summary>
        public MapCondition Condition { get; set; }
        /// <summary>
        /// 表示映射的 .NET 基本类型的名称
        /// </summary>
        public String MapType { get; set; }
    }
    /// <summary>
    /// 表示一组类型映射的条件
    /// </summary>
    public class MapCondition
    {
        /// <summary>
        /// 数据库的源类型
        /// </summary>
        public String DbType { get; set; }
        /// <summary>
        /// 是否可空，Null 表示忽略此条件
        /// </summary>
        public Boolean? IsNullable { get; set; }
        /// <summary>
        /// 列长度，Null 表示忽略此条件，* 表示关心但匹配任意长度
        /// </summary>
        public String Length { get; set; }
    }
}
