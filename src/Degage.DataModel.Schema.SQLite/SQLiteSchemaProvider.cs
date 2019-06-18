using System;
using System.Collections.Generic;

using System.Data;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SQLite;
#if NETSTANDARD2_0
using System.Composition;
#endif

#if NET40
using System.ComponentModel.Composition;
#endif

namespace Degage.DataModel.Schema.SQLite
{
#if NET40
    [Export(typeof(ISchemaProvider))]
#endif
#if NETSTANDARD2_0
    [Export(typeof(ISchemaProvider))]
#endif
    public partial class SQLiteSchemaProvider : ISchemaProvider
    {
        public String Name { get; } = "SQLite3";

        public String Explain { get; } = "适用于 SQLite3 数据库，列类型取 EDM_TYPE";

        public String ConnectionString
        {
            get
            {
                return this._connection?.ConnectionString;
            }
        }

        public Boolean Opened { get; private set; }

        // 架构名称用于查询指定架构
        internal const String CollectionNameOfColumn = "Columns";
        internal const String CollectionNameOfTable = "Tables";
        internal const String CollectionNameOfIndex = "Indexes";


        // 辅助字段用于一些条件的判断
        internal const String KeyTypeOfPrimary = "PRI";
        internal const String NullableOfYes = "YES";

        //元数据信息-列架构字段名称
        internal const String ColumnOfName = "COLUMN_NAME";
        internal const String ColumnOfTableName = "TABLE_NAME";
        internal const String ColumnOfDbType = "DATA_TYPE";
        internal const String ColumnOfKey = "COLUMN_KEY";
        internal const String ColumnOfColType = "COLUMN_TYPE";
        internal const String ColumnOfLength = "CHARACTER_MAXIMUM_LENGTH";
        internal const String ColumnOfNullable = "IS_NULLABLE";
        internal const String ColumnOfComment = "COLUMN_COMMENT";


        //元数据信息-表架构字段名称
        internal const String TableOfName = "TABLE_NAME";
        internal const String TableOfDbName = "TABLE_SCHEMA";
        internal const String TableOfComment = "TABLE_COMMENT";




        private SQLiteConnection _connection = null;


        public void Open(String connectionString)
        {
            this._connection = new SQLiteConnection(connectionString);
            try
            {
                this._connection.Open();
                this.Opened = true;
            }
            catch (Exception exc)
            {
                this._connection = null;
                ProviderConnectException exception = new ProviderConnectException(exc);
                exception.ConnectionString = connectionString;
                exception.ErrorExplain = exc.Message;
                this.Opened = false;
                throw exception;
            }
        }

        public void Close()
        {
            if (this._connection != null && _connection.State == ConnectionState.Open)
            {
                this._connection.Close();
            }
            this.Opened = false;
            this._connection = null;
        }

        public void Dispose()
        {
            this.Close();
        }

        private DataTable ExecuteQuery(String sql)
        {
            DataTable table = null;
            if (!String.IsNullOrWhiteSpace(sql))
            {
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = this._connection;
                command.CommandText = sql;
                DbDataReader dbReader = command.ExecuteReader(CommandBehavior.Default);
                table = new DataTable();
                table.Load(dbReader);
            }
            return table;
        }

        public (Boolean success, TableSchemaExtend table, IList<ColumnSchemaExtend> columns) GetTableSchemaTuple(String tableName)
        {
            Boolean success = false;
            TableSchemaExtend tableSchema = null;
            IList<ColumnSchemaExtend> columnSchemas = null;
            if (String.IsNullOrEmpty(tableName))
            {
                throw new ArgumentException(nameof(tableName));
            }

            String dataBase = this.GetDataBaseName();
            DataTable info = this._connection.GetSchema(CollectionNameOfTable, new String[] { null, dataBase, tableName, null });
            if (info.Rows.Count > 0)
            {
                var row = info.Rows[0];
                tableSchema = this.GetTableSchemaFromRow(row);
                columnSchemas = this.LoadColumnSchemaList(tableName);
                success = true;
            }
            return (success, tableSchema, columnSchemas);
        }

        public IList<ColumnSchemaExtend> LoadColumnSchemaList(String tableName)
        {
            List<ColumnSchemaExtend> columnSchemas = new List<ColumnSchemaExtend>();

            String dataBase = this.GetDataBaseName();
            DataTable info = this._connection.GetSchema(CollectionNameOfColumn, new String[] { null, dataBase, tableName, null });
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

        public IList<TableSchemaExtend> LoadTableSchemaList()
        {
            List<TableSchemaExtend> tableSchemas = new List<TableSchemaExtend>();
            String dataBase = this.GetDataBaseName();
            DataTable info = this._connection.GetSchema(CollectionNameOfTable, new String[] { null, dataBase, null, null });
            if (info.Rows.Count > 0)
            {
                foreach (DataRow row in info.Rows)
                {
                    TableSchemaExtend schema = this.GetTableSchemaFromRow(row);
                    tableSchemas.Add(schema);
                }
            }
            return tableSchemas;
        }
        protected ColumnSchemaExtend GetColumnSchemaFromRow(DataRow row)
        {
            ColumnSchemaExtend schema = new ColumnSchemaExtend
            {
                Explain = row["DESCRIPTION"] as String,
                Name = row[ColumnOfName] as String,
                DbTypeString = row["EDM_TYPE"] as String
            };

            //IsNullable
            schema.IsNullable = (Boolean)row[ColumnOfNullable];


            //IsPrimaryKey
            schema.IsPrimaryKey = (Boolean)row["PRIMARY_KEY"];


            //Length
            String columnTypeStr = row[ColumnOfLength].ToString();
            if (Int32.TryParse(columnTypeStr, out Int32 length))
            {
                schema.Length = length;
            }

            return schema;
        }

        protected TableSchemaExtend GetTableSchemaFromRow(DataRow row)
        {
            TableSchemaExtend schema = new TableSchemaExtend
            {
                Name = row[TableOfName] as String
            };

            return schema;
        }

        protected IndexSchema GetIndexSchemaFromRow(DataRow row)
        {
            IndexSchema schema = new IndexSchema
            {
                Name = row["INDEX_NAME"].ToString(),
                ColumnNames = row["COLUMN_NAME"].ToString(),
                Explain = "Sort:" + row["SORT_MODE"].ToString()
            };
            return schema;
        }
        private String GetDataBaseName()
        {
            return this._connection.Database;
        }
        public IList<IndexSchema> LoadIndexSchemaList(String tableName)
        {
            List<IndexSchema> indexSchemas = new List<IndexSchema>();
            var dataBase = this.GetDataBaseName();
            var info = this._connection.GetSchema("IndexColumns", new String[] { null, dataBase, tableName, null });
            if (info.Rows.Count > 0)
            {
                foreach (DataRow row in info.Rows)
                {
                    IndexSchema schema = this.GetIndexSchemaFromRow(row);
                    indexSchemas.Add(schema);
                }
            }
            return indexSchemas;
        }

        public IList<FunctionSchema> LoadFunctionSchemaList()
        {
            return new List<FunctionSchema>();
        }

        public IList<ProcedureSchema> LoadProcedureSchemaList()
        {
            return new List<ProcedureSchema>();
        }
    }
}
