using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.DataModel.Schema.Toolbox
{
    public static class SchemaAssistor
    {
        static Dictionary<Type, SchemaEqualizer> ObjectSchemaEqualizerTable;
        static SchemaAssistor()
        {
            ObjectSchemaEqualizerTable = new Dictionary<Type, SchemaEqualizer>();

            ObjectSchemaEqualizerTable.Add(
                typeof(FunctionSchema),
                new SchemaEqualizer((s, t) =>
             {
                 return (s.Name == t.Name) && ((FunctionSchema)t).Definition == ((FunctionSchema)s).Definition;
             }));



            ObjectSchemaEqualizerTable.Add(
                typeof(ProcedureSchema),
                new SchemaEqualizer((s, t) =>
            {
                return (s.Name == t.Name) && ((ProcedureSchema)t).Definition == ((ProcedureSchema)s).Definition;
            }));


            ObjectSchemaEqualizerTable.Add(
                typeof(ColumnSchemaExtend),
                new SchemaEqualizer((s, t) =>
           {
               var source = s as ColumnSchemaExtend;
               var target = t as ColumnSchemaExtend;
               var lengthCompare = source.Length== target.Length;

               var result= ((s.Name == t.Name) &&
               (source.IsNullable == target.IsNullable) &&
               (source.DbTypeString == target.DbTypeString));

               result &= lengthCompare;
               return result;
           }));


            ObjectSchemaEqualizerTable.Add(
                typeof(IndexSchema),
                new SchemaEqualizer((s, t) =>
            {
                var source = s as IndexSchema;
                var target = t as IndexSchema;
                return (s.Name == t.Name) &&
                 source.ColumnNames == source.ColumnNames;
            }));

        }
        public static SchemaEqualizer GetSchemaEqualizer(Type type)
        {
            if (ObjectSchemaEqualizerTable.ContainsKey(type))
            {
                return ObjectSchemaEqualizerTable[type];
            }
            else
            {
                return new SchemaEqualizer((s, t) => s.Name == t.Name);
            }
        }
        /// <summary>
        /// 比较两个结构信息集合，并返回之间的差异（包含相同的信息项）
        /// </summary>
        /// <remarks>两个集合中的信息的 <see cref="SchemaInfoTuple.SchemaType"/> 值需要相同 </remarks>
        /// <param name="sourceSchemas"></param>
        /// <param name="targetSchemas"></param>
        /// <returns></returns>
        public static List<SchemaDifferenceInfo> CompareSchemaInfo(IEnumerable<SchemaInfoTuple> sourceSchemas, IEnumerable<SchemaInfoTuple> targetSchemas)
        {
            List<SchemaDifferenceInfo> differenceInfos = new List<SchemaDifferenceInfo>();

            //层1：表、视图、函数、存储过程
            //层2：列、索引


            //比较层1
            var sourceTopSchemas = sourceSchemas.Select(t => t.ObjectSchema).ToList();
            var targetTopSchemas = targetSchemas.Select(t => t.ObjectSchema).ToList();

            var topSchemaDifferenceInfos = CompareObjectSchemas(sourceTopSchemas, targetTopSchemas, out var topChangeFlag);
            var topSchemaDifferenceTypeTable = topSchemaDifferenceInfos.ToDictionary(t => t.Schema);

            differenceInfos.AddRange(topSchemaDifferenceInfos);

            Dictionary<String, SchemaInfoTuple> targetSchemaInfoTable = new Dictionary<String, SchemaInfoTuple>();
            foreach (var schema in targetSchemas)
            {
                targetSchemaInfoTable.Add(schema.ObjectSchema.Name, schema);
            }

            //比较层2
            foreach (var sourceSchema in sourceSchemas)
            {
                SchemaInfoTuple targetSchema = null;
                if (targetSchemaInfoTable.ContainsKey(sourceSchema.ObjectSchema.Name))
                {
                    targetSchema = targetSchemaInfoTable[sourceSchema.ObjectSchema.Name];
                }
                switch (sourceSchema.SchemaType)
                {
                    case SchemaType.Table:
                        {
                            //比较列
                            var columnDifferenceInfos = SchemaAssistor.CompareObjectSchemas(
                                sourceSchema.ColumnSchemas.Cast<IObjectSchema>(),
                                targetSchema?.ColumnSchemas.Cast<IObjectSchema>(), out var changeFlag);
                            differenceInfos.AddRange(columnDifferenceInfos);
                            //将变化中删除的列添加至目标结构中
                            var deletedColumnSchemas = columnDifferenceInfos.Where(t => t.DifferenceType == SchemaDifferenceType.Delete).Select(t => t.Schema).Cast<ColumnSchemaExtend>();
                            targetSchema?.ColumnSchemas.AddRange(deletedColumnSchemas);
                            //如果第二层的信息发生了变化，则信息所属的父结点也应该被标记为变化
                            //改变可能是删除、新增、修改。当改变是新增与修改时，表中一定会存在
                            if (changeFlag)
                            {
                                if (topSchemaDifferenceTypeTable[targetSchema.ObjectSchema].DifferenceType != SchemaDifferenceType.Delete)
                                {
                                    topSchemaDifferenceTypeTable[targetSchema.ObjectSchema].DifferenceType = SchemaDifferenceType.Modify;
                                }
                            }
                            //比较索引
                            var indexDifferenceInfos = SchemaAssistor.CompareObjectSchemas(
                               sourceSchema.IndexColumnSchemas.Cast<IObjectSchema>(),
                               targetSchema?.IndexColumnSchemas.Cast<IObjectSchema>(), out changeFlag);
                            differenceInfos.AddRange(indexDifferenceInfos);
                            //将变化中删除的索引添加至目标结构中
                            var deletedIndexColumnSchemas = indexDifferenceInfos.Where(t => t.DifferenceType == SchemaDifferenceType.Delete).Select(t => t.Schema).Cast<IndexSchema>();
                            targetSchema?.IndexColumnSchemas.AddRange(deletedIndexColumnSchemas);
                            //如果第二层的信息发生了变化
                            if (changeFlag)
                            {
                                if (topSchemaDifferenceTypeTable[targetSchema.ObjectSchema].DifferenceType != SchemaDifferenceType.Delete)
                                {
                                    topSchemaDifferenceTypeTable[targetSchema.ObjectSchema].DifferenceType = SchemaDifferenceType.Modify;
                                }
                            }
                        }
                        break;
                    case SchemaType.View:
                        {
                            //比较列
                            var columnDifferenceInfos = SchemaAssistor.CompareObjectSchemas(
                                sourceSchema.ColumnSchemas.Cast<IObjectSchema>(),
                                targetSchema?.ColumnSchemas.Cast<IObjectSchema>(), out var changeFlag);
                            differenceInfos.AddRange(columnDifferenceInfos);
                            //将变化中删除的列添加至目标结构中
                            var deletedIndexColumnSchemas = columnDifferenceInfos.Where(t => t.DifferenceType == SchemaDifferenceType.Delete).Select(t => t.Schema).Cast<ColumnSchemaExtend>();
                            targetSchema?.ColumnSchemas.AddRange(deletedIndexColumnSchemas);
                            //如果第二层的信息发生了变化
                            if (changeFlag)
                            {
                                if (topSchemaDifferenceTypeTable[targetSchema.ObjectSchema].DifferenceType != SchemaDifferenceType.Delete)
                                {
                                    topSchemaDifferenceTypeTable[targetSchema.ObjectSchema].DifferenceType = SchemaDifferenceType.Modify;
                                }
                            }
                        }
                        break;
                    case SchemaType.Procedure:
                        {

                        }
                        break;
                    case SchemaType.Function:
                        {

                        }
                        break;

                }
            }

            //获取新增的结构信息，上面的遍历是以源结构为集合的，所以目标结构新增的信息是遍历不到的
            var addSchemaInfos = topSchemaDifferenceInfos.Where(t => t.DifferenceType == SchemaDifferenceType.Add);
            foreach (var addSchema in addSchemaInfos)
            {
                var targetSchema = targetSchemaInfoTable[addSchema.Schema.Name];
                switch (targetSchema.SchemaType)
                {
                    case SchemaType.Table:
                        {
                            //新增列
                            var columnDifferenceInfos = SchemaAssistor.CompareObjectSchemas(
                                null,
                                targetSchema?.ColumnSchemas.Cast<IObjectSchema>(), out var changeFlag);
                            differenceInfos.AddRange(columnDifferenceInfos);

                            //新增索引
                            var indexDifferenceInfos = SchemaAssistor.CompareObjectSchemas(
                               null,
                               targetSchema?.IndexColumnSchemas.Cast<IObjectSchema>(), out changeFlag);
                            differenceInfos.AddRange(indexDifferenceInfos);
                        }
                        break;
                    case SchemaType.View:
                        {
                            //新增列
                            var columnDifferenceInfos = SchemaAssistor.CompareObjectSchemas(
                                null,
                                targetSchema?.ColumnSchemas.Cast<IObjectSchema>(), out var changeFlag);
                            differenceInfos.AddRange(columnDifferenceInfos);
                        }
                        break;
                    case SchemaType.Procedure:
                        {
                            //
                        }
                        break;
                    case SchemaType.Function:
                        {
                            //
                        }
                        break;
                }

            }
            return differenceInfos;
        }
        /// <summary>
        /// 比较两个集合的结构信息，并指示两个集合中结构信息整体上是否有差异
        /// </summary>
        /// <param name="sourceSchemas"></param>
        /// <param name="targetSchemas"></param>
        /// <param name="changeFlag">结构信息整体上是否有差异</param>
        /// <returns></returns>
        private static List<SchemaDifferenceInfo> CompareObjectSchemas(IEnumerable<IObjectSchema> sourceSchemas, IEnumerable<IObjectSchema> targetSchemas, out Boolean changeFlag)
        {
            List<SchemaDifferenceInfo> differenceInfos = new List<SchemaDifferenceInfo>();
            changeFlag = false;
            sourceSchemas = sourceSchemas ?? new List<IObjectSchema>();
            targetSchemas = targetSchemas ?? new List<IObjectSchema>();

            Dictionary<String, IObjectSchema> targetSchemaInfoTable = new Dictionary<String, IObjectSchema>();
            foreach (var schema in targetSchemas)
            {
                targetSchemaInfoTable.Add(schema.Name, schema);
            }

            foreach (var sourceSchema in sourceSchemas)
            {
                //此结构在比较目标中不存在，则标记为删除
                if (!targetSchemaInfoTable.ContainsKey(sourceSchema.Name))
                {
                    SchemaDifferenceInfo deletedInfo = new SchemaDifferenceInfo
                    {
                        Schema = sourceSchema,
                        DifferenceType = SchemaDifferenceType.Delete
                    };
                    changeFlag = true;
                    differenceInfos.Add(deletedInfo);
                    continue;
                }
                //如果存在
                else
                {
                    var targetSchema = targetSchemaInfoTable[sourceSchema.Name];
                    Type type = sourceSchema.GetType();
                    SchemaDifferenceInfo differenceInfo = new SchemaDifferenceInfo();

                    differenceInfo.Schema = targetSchema;
                    differenceInfo.DifferenceType = SchemaDifferenceType.None;

                    var equalizer = SchemaAssistor.GetSchemaEqualizer(type);

                    //若不相等则就是修改的
                    if (!equalizer.Equal(sourceSchema, targetSchema))
                    {
                        changeFlag = true;
                        differenceInfo.DifferenceType = SchemaDifferenceType.Modify;
                    }
                    differenceInfos.Add(differenceInfo);
                    targetSchemaInfoTable.Remove(targetSchema.Name);
                }
            }
            //剩余的都是新增的
            foreach (var schemaItem in targetSchemaInfoTable)
            {
                SchemaDifferenceInfo addInfo = new SchemaDifferenceInfo();
                addInfo.DifferenceType = SchemaDifferenceType.Add;
                addInfo.Schema = schemaItem.Value;
                differenceInfos.Add(addInfo);
                changeFlag = true;
            }
            return differenceInfos;
        }


        public static void SaveSchemaInfos(String path, List<SchemaInfoTuple> schemaInfos)
        {
            BinarySerializer.SerializeToFile(path, schemaInfos);
        }

        public static List<SchemaInfoTuple> LoadSchemaInfos(String path)
        {
            return BinarySerializer.DeserializeFromFile<List<SchemaInfoTuple>>(path);
        }
        /// <summary>
        /// 是否需要补全结构信息
        /// </summary>
        /// <param name="schemaInfo"></param>
        /// <returns></returns>
        public static Boolean IsRequiredCompleteSchema(SchemaInfoTuple schemaInfo)
        {
            return ((schemaInfo.SchemaType == SchemaType.Table || schemaInfo.SchemaType == SchemaType.View) && schemaInfo.ColumnSchemas == null);
        }
        /// <summary>
        /// 判断指定的结构集合是否需要补全细节信息,若需要则给出那些需要
        /// </summary>
        /// <param name="schemaInfos"></param>
        /// <returns>返回一个二元组，如果需要则第二组件中包含需要补全明细的结构集合</returns>
        public static (Boolean requried, List<SchemaInfoTuple> requiredSchemas) IsRequiredCompleteSchema(List<SchemaInfoTuple> schemaInfos)
        {
            Boolean required = false;
            var requiredSchemas = schemaInfos.Where(t => IsRequiredCompleteSchema(t)).ToList();
            if (requiredSchemas.Count > 0)
            {
                required = true;
            }
            return (required, requiredSchemas);
        }
        public static void CompleteSchema(ISchemaProvider provider, SchemaInfoTuple schemaInfo)
        {
            switch (schemaInfo.SchemaType)
            {
                case SchemaType.Table:
                    {
                        var columnSchemas = provider.LoadColumnSchemaList(schemaInfo.ObjectSchema.Name);
                        schemaInfo.ColumnSchemas = new List<ColumnSchemaExtend>(columnSchemas);
                        var indexSchemas = provider.LoadIndexSchemaList(schemaInfo.ObjectSchema.Name);
                        schemaInfo.IndexColumnSchemas = new List<IndexSchema>(indexSchemas);

                    }
                    break;
                case SchemaType.View:
                    {
                        var columnSchems = provider.LoadViewColumnSchemaList(schemaInfo.ObjectSchema.Name);
                        schemaInfo.ColumnSchemas = new List<ColumnSchemaExtend>(columnSchems);
                    }
                    break;
                case SchemaType.Procedure:
                    {
                    }
                    break;
                case SchemaType.Function:
                    {

                    }
                    break;
            }
        }
    }
}
