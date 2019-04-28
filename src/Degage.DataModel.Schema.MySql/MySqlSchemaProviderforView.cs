using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Data.Common;


namespace Degage.DataModel.Schema.MySql
{

    public partial class MySqlSchemaProvider : ISchemaProvider
    {


        public IList<TableSchemaExtend> LoadViewSchemaList()
        {
            List<TableSchemaExtend> viewSchemas = new List<TableSchemaExtend>();
            DataTable info = this._connection.GetSchema("Views", new String[] { null, this.GetDataBaseName(), null, null });
            if (info.Rows.Count > 0)
            {
                foreach (DataRow row in info.Rows)
                {
                    TableSchemaExtend schema = this.GetViewSchemaFromRow(row);
                    viewSchemas.Add(schema);
                }
            }
            return viewSchemas;
        }

        protected TableSchemaExtend GetViewSchemaFromRow(DataRow row)
        {
            TableSchemaExtend schema = new TableSchemaExtend
            {
                Name = row[TableOfName] as String
            };

            return schema;
        }

        public IList<ColumnSchemaExtend> LoadViewColumnSchemaList(String viewName)
        {
            List<ColumnSchemaExtend> columnSchemas = new List<ColumnSchemaExtend>();

            String dataBase = this.GetDataBaseName();
            DataTable info = this._connection.GetSchema("ViewColumns", new String[] { null, dataBase, viewName, null });
            if (info.Rows.Count > 0)
            {
                foreach (DataRow row in info.Rows)
                {
                    ColumnSchemaExtend schema = this.GetColumnSchemaFromRow(row);
                    columnSchemas.Add(schema);
                }
            }
            return columnSchemas;
        }

        public (Boolean success, TableSchemaExtend view, IList<ColumnSchemaExtend> columns) GetViewSchemaTuple(String viewName)
        {
            Boolean success = false;
            TableSchemaExtend viewSchema = null;
            IList<ColumnSchemaExtend> columnSchemas = null;
            if (String.IsNullOrEmpty(viewName))
            {
                throw new ArgumentException(nameof(viewName));
            }

            DataTable info = this._connection.GetSchema("Views", new String[] { null, this.GetDataBaseName(), viewName, null });
            if (info.Rows.Count > 0)
            {
                var row = info.Rows[0];
                viewSchema = this.GetTableSchemaFromRow(row);
                columnSchemas = this.LoadViewColumnSchemaList(viewName);
                success = true;
            }
            return (success, viewSchema, columnSchemas);
        }
    }
}
