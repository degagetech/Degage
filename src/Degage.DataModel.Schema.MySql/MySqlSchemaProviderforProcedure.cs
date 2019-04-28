using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Degage.DataModel.Schema.MySql
{
    public partial class MySqlSchemaProvider : ISchemaProvider
    {
        public IList<ProcedureSchema> LoadProcedureSchemaList()
        {
            List<ProcedureSchema> procedureSchemas = new List<ProcedureSchema>();
            DataTable info = this._connection.GetSchema("Procedures",
                new String[] {
                    null,
                    this.GetDataBaseName(),
                    null,
                    "PROCEDURE"
                });
            if (info.Rows.Count > 0)
            {
                foreach (DataRow row in info.Rows)
                {
                    ProcedureSchema schema = this.GetProcedureSchemaFromRow(row);
                    procedureSchemas.Add(schema);
                }
            }
            return procedureSchemas;
        }

        protected ProcedureSchema GetProcedureSchemaFromRow(DataRow row)
        {
            ProcedureSchema schema = new ProcedureSchema
            {
                Name = row["ROUTINE_NAME"].ToString(),
                Definition = row["ROUTINE_DEFINITION"].ToString()
            };
            return schema;
        }


    }
}
