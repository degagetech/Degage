using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.DataModel.Schema.Toolbox
{
    [Serializable]
    public class SchemaInfoTuple
    {
        public IObjectSchema ObjectSchema { get; set; }
        public List<ColumnSchemaExtend> ColumnSchemas { get; set; }
        public List<IndexSchema> IndexColumnSchemas { get; set; }

        public SchemaType SchemaType { get; set; }
    }
}
