using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Degage.EMS.VersionControl
{
    public enum LoggingEvents : Int32
    {
        FileUpload= 0x000010,
        FileUploadError =0x000011,

        FileDownload = 0x000020,
        FileDownloadError = 0x000021,

        FileDelete = 0x000030,
        FileDeleteError = 0x000031
    }



    public static class LoggingEventsExtension
    {
        public static EventId ToEventId(this LoggingEvents e)
        {
            EventId eventId = new EventId((Int32)e, e.ToString());
            return eventId;
        }
    }
}
