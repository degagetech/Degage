using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Degage.DataModel.Schema.MySql
{
    public partial class MySqlSchemaProvider : ISchemaProvider
    {

        public IList<FunctionSchema> LoadFunctionSchemaList()
        {
            List<FunctionSchema> functionSchemas = new List<FunctionSchema>();
            DataTable info = this._connection.GetSchema("Procedures",
                new String[] {
                    null,
                    this.GetDataBaseName(),
                    null,
                    "FUNCTION"
                });
            if (info.Rows.Count > 0)
            {
                foreach (DataRow row in info.Rows)
                {
                    FunctionSchema schema = this.GetFunctionSchemaFromRow(row);
                    functionSchemas.Add(schema);
                }
            }
            return functionSchemas;
        }

        protected FunctionSchema GetFunctionSchemaFromRow(DataRow row)
        {
            FunctionSchema schema = new FunctionSchema
            {
                Name = row["ROUTINE_NAME"].ToString(),
                Definition = row["ROUTINE_DEFINITION"].ToString()
            };
            return schema;
        }
    }
}
