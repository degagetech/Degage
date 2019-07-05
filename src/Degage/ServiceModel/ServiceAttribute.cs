using System;
using System.Collections.Generic;
using System.Text;

namespace Degage.ServiceModel
{
    /// <summary>
    /// 为类或接口提供描述服务结构信息的能力
    /// </summary>
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Interface, AllowMultiple = false)]
    public class ServiceAttribute : System.Attribute
    {
        /// <summary>
        /// 服务的名称
        /// </summary>
        public String Name { get; set; }
    }
}
