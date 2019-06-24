using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Degage.EMS.VersionControl
{
    public class ProjectInfoCondition:PageCondition
    {
        public String Id { get; set; }
        public DateTime? LastAccessTimeStart { get; set; }
        public DateTime? LastAccessTimeEnd { get; set; }
    }
}
