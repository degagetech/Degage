using System;
using System.Collections.Generic;
using System.Text;

namespace Degage.ServiceModel
{
    public class ServiceParameterAttribute : System.Attribute
    {
        public ServiceParameterAttribute(String name)
        {
            this.Name = name;
        }
        public String Name { get; set; }
        public String Type { get; set; }
    }
}
