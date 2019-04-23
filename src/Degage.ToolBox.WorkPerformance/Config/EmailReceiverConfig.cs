using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPerformance
{
    public class EmailReceiverConfig : Config
    {
        public List<EmailReceiverItem> Items { get; set; } = new List<EmailReceiverItem>();
    }
    public class EmailReceiverItem
    {
        public String ReceiverName { get; set; }
        public String ReceiverEmailAddress { get; set; }
    }
}
