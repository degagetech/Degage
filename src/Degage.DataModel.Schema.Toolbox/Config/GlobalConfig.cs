using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.DataModel.Schema.Toolbox
{
    public class GlobalConfig : ConfigBase
    {
        [ConfigTag(IsEncrypted = true)]
        public String ConnectionString { get; set; }

        [ConfigTag]
        public String ProviderName { get; set; }

        [ConfigTag]
        public List<String> SelectedSchemaInfo { get; set; } = new List<String>();
        [ConfigTag]
        public String ExcelExportConfigString { get; set; }

        [ConfigTag]
        public ExportType SelectExportType { get; set; }


    }
}
