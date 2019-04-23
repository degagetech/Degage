using System;
using System.Collections.Generic;
using System.Text;

namespace Degage.Timers
{
    public class ClockEventArgs : EventArgs
    {
        public DateTime ClockTime { get; internal set; }
    }
}
