using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Degage.DataModel.Schema.Toolbox
{
    public interface IExportContext
    {
        event Action<Object, IList<TableSchemaExtend>> CheckedTableSchemaChanged;
        IList<TableSchemaExtend> CheckedTableSchemas { get;  set; }
    }
}
