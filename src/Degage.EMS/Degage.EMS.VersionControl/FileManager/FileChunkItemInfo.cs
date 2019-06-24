using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Degage.EMS.VersionControl
{
    public class FileChunkItemInfo
    {
        public String ItemId { get; internal set; }
        public Int64 Length { get; internal set; }

    }
}
