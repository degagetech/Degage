using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Degage.DataModel.Schema.Toolbox
{
    public class ConnectionHistoryConfig : ConfigBase
    {
        public static String FilePath { get;private set; }
        static ConnectionHistoryConfig()
        {
            FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Config", "ConnectionHistory.json");
        }
        [ConfigTag]
        public List<ConnectionHistoryItem> Historys { get; set; } = new List<ConnectionHistoryItem>();
    }
    public class ConnectionHistoryItem : ConfigBase
    {
        [ConfigTag(IsEncrypted =true)]
        public String ConnectionString { get; set; }
        [ConfigTag]
        public String ProviderName { get; set; }

        public override string ToString()
        {
            return $"{this.ProviderName}:{this.ConnectionString}";
        }
    }
}
