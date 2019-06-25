
using System;
namespace Degage.EMS.VersionControl
{
    public class ProjectVersionInfo
    {
        public String Id { get; set; }
        public String ProjectId { get; set; }
        public Int32 Major { get; set; }
        public Int32 Minor { get; set; }
        public Int32 Revised { get; set; }
        public String Type { get; set; }
        public String Description { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastAccessTime { get; set; }
        public Boolean IsEnabled { get; set; }
        public Boolean IsRemoved { get; set; }
    }
}
