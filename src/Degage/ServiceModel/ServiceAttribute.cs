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
        public String Name { get; set; }
    }
}
