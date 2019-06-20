
using System;
namespace Degage.EMS.VersionControl
{
    public class ProjectItemInfo
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public String VersionId { get; set; }
        public String ProjectId { get; set; }
        public String Type { get; set; }
        public String Path { get; set; }
        public String FileId { get; set; }
        public String Size { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
