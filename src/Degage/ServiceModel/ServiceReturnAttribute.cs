using System;
using System.Collections.Generic;
using System.Text;

namespace Degage.ServiceModel
{
    public class ServiceReturnAttribute:System.Attribute
    {
        public String Type { get; set; }
    }
}
