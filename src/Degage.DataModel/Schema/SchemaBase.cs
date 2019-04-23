using System;
using System.Collections.Generic;
using System.Text;

namespace Degage.DataModel.Schema
{
    /// <summary>
    /// 映射目标对象的结构信息的基类
    /// </summary>
    [Serializable]
    public abstract class SchemaBase
    {
        /// <summary>
        /// 映射目标的名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 映射源自身的名称
        /// </summary>
        public String SourceName { get; set; }
    }
}
