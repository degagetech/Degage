using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Degage.EMS.VersionControl
{
    public class VersionInfoCondition : PageCondition
    {
        public String ProjectId { get; set; }
        public Boolean? IsEnabled { get; private set; }
        public Boolean IsRemoved { get; set; } = false;
    }
}
