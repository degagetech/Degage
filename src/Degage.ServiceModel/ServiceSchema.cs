using System;
using System.Collections.Generic;
using System.Text;

namespace Degage.ServiceModel
{
    /// <summary>
    /// 表示服务结构的描述信息
    /// </summary>
    public class ServiceSchema : BaseSchema
    {
        /// <summary>
        /// 服务的名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 服务的唯一签名
        /// </summary>
        public String Signature { get; set; }
        /// <summary>
        /// 记录服务包含的所有操作的结构信息
        /// </summary>
        public ServiceOperationSchema[] Operations { get; set; }
    }
    /// <summary>
    /// 表示服务操作的结构信息
    /// </summary>
    public class ServiceOperationSchema : BaseSchema
    {
        public String Name { get; set; }
        /// <summary>
        /// 是否是一个异步操作
        /// </summary>
        public Boolean IsAsync { get; set; }
        /// <summary>
        /// 是否为一个泛型操作
        /// </summary>
        public Boolean IsGeneric { get; set; }
        /// <summary>
        /// 记录操作的所有输入参数的结构信息
        /// </summary>
        public ServiceParameterSchema[] InputParameters { get; set; }
        /// <summary>
        /// 记录操作的所有输出参数的结构信息
        /// </summary>
        public ServiceParameterSchema[] OutputParameter { get; set; }
    }
    /// <summary>
    /// 表示服务参数的结构信息
    /// </summary>
    public class ServiceParameterSchema : BaseSchema
    {
        /// <summary>
        /// 参数的名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 是否为一个泛型参数
        /// </summary>
        public Boolean IsGeneric { get; set; }
        /// <summary>
        /// 参数的数据类型
        /// </summary>
        public ServiceDataTypeSchema DataType { get; set; }
    }
    /// <summary>
    /// 表示服务数据类型的结构信息
    /// </summary>
    public class ServiceDataTypeSchema : BaseSchema
    {
        /// <summary>
        /// 类型的名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 是否为一个基础类型，在 <see cref="ServiceBasicDataType"/> 列表中指出的类型
        /// </summary>
        public Boolean IsBasicType { get; set; }
        /// <summary>
        /// 基础类型的值
        /// </summary>
        public Int32 BasicType { get; set; }
        /// <summary>
        /// 是否可以为空，适用于基础类型
        /// </summary>
        public Boolean IsNullable { get; set; }
        /// <summary>
        /// 当类型为自定义类型时，存储类型的各类属性值
        /// </summary>
        public ServiceDataTypePropertySchema[] Properties { get; set; }
    }
    /// <summary>
    /// 表示自定义服务数据类型的属性信息
    /// </summary>
    public class ServiceDataTypePropertySchema : BaseSchema
    {
        /// <summary>
        /// 属性的名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 属性的数据类型
        /// </summary>
        public ServiceDataTypeSchema TypeSchema { get; set; }
    }
}
