using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Degage.EMS.VersionControl
{
    public class ProjectInfo
    {
        public String Id { get; set; }
        public String CurrentVersionId { get; set; }
        public String CurrentVersionDesc { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String IconFileId { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastAccessTime { get; set; }
        public Boolean IsRemoved { get; set; }
    }
}
