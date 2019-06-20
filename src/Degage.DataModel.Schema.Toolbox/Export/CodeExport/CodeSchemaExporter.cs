using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Degage.DataModel.Schema.Toolbox
{
    /// <summary>
    /// 提供将 Schema 信息导出为代码文件的功能
    /// </summary>
    public class CodeSchemaExporter : ISchemaExporter
    {
        /// <summary>
        /// 类型映射文件的存储目录
        /// </summary>
        public String TypeMapConfigDirectory { get; private set; }
        /// <summary>
        /// 类型映射文件的后缀名-JSON 格式
        /// </summary>
        public String TypeMapConfigJsonFileExt { get; private set; } = ".tm.json";
        /// <summary>
        /// 类型映射文件的后缀名-XML 格式
        /// </summary>
        public String TypeMapConfigXmlFileExt { get; private set; } = ".tm.xml";

        /// <summary>
        /// 代码模板文件的存储目录
        /// </summary>
        public String CodeTemplateConfigDirectory { get; private set; }
        /// <summary>
        ///  代码模板文件的后缀名-JSON 格式
        /// </summary>
        public String CodeTemplateConfigJsonFileExt { get; private set; } = ".ct.json";
        /// <summary>
        ///  代码模板文件的后缀名-XML 格式
        /// </summary>
        public String CodeTemplateConfigXmlFileExt { get; private set; } = ".ct.xml";

        private Regex ContentSymbolExtracter { get; set; } = new Regex(@"\$[\w]+\$");
        private Regex PropertyContentSymbolExtracter { get; set; } = new Regex(@"#[\w]+#");

        public event Action<Object, SchemaExportEventArgs> ExportProgressChanged;

        public CodeSchemaExporter()
        {
            this.TypeMapConfigDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "Code", "TypeMaps");
            this.CodeTemplateConfigDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "Code", "CodeTemplates");
        }

        public void Export(IList<IExportTargeter> exportTargeters, IList<SchemaInfoTuple> schemas, ExportConfig config)
        {
            var codeExportConfig = config as CodeExportConfig;
            List<CodeExportInfo> exportInfos = new List<CodeExportInfo>();
            SchemaExportEventArgs exportEventArgs = new SchemaExportEventArgs();
            var contentSymbolTable = codeExportConfig.ContentSymbolTable;
            // 只处理表和视图
            var exportSchemaTupleInfos = schemas.Where(t => t.SchemaType == SchemaType.Table || t.SchemaType == SchemaType.View);
            exportEventArgs.Total = exportSchemaTupleInfos.Count();

            CodeBuildContext context = new CodeBuildContext();
            context.NameSpace = codeExportConfig.CodeNameSpace;
            context.Location = BuildLocationType.Main;
            context.SymbolModifier = codeExportConfig.SymbolModifier;
            context.TypeMapConfig = codeExportConfig.TypeMapConfig;

            foreach (var tupleInfo in exportSchemaTupleInfos)
            {
                exportEventArgs.SchemaInfo = tupleInfo;
                CodeExportInfo exportInfo = new CodeExportInfo();
                //Key 符号信息，Value 符号解析的结果
                var symbolAnalysisTable = new Dictionary<String, String>();
                var tableSchema = tupleInfo.ObjectSchema as TableSchemaExtend;
                var bodyCodeTemplate = codeExportConfig.CodeTemplateConfig.Body;
                var codeStringBuilder = new StringBuilder(codeExportConfig.CodeTemplateConfig.Body);
                context.TableSchema = tableSchema;
                context.ColumnSchema = null;

                //提取内容符号
                var matchCollection = this.ContentSymbolExtracter.Matches(bodyCodeTemplate);

                foreach (Match match in matchCollection)
                {
                    var matchValue = match.Value;
                    var symbol = this.ExtractSymbol(matchValue);
                    if (!contentSymbolTable.ContainsKey(symbol)) continue;

                    IContentSymbol contentSymbol = contentSymbolTable[symbol];
                    //如果符号未解析过，或者内容符号的定义表明需要重复解析
                    if (!symbolAnalysisTable.ContainsKey(matchValue) || contentSymbol.WhetherNeedRepetition)
                    {
                        var analysisResult = contentSymbol.Analysing(context);
                        symbolAnalysisTable[matchValue] = analysisResult;
                    }
                }

                //使用符号分析结果填充主模板
                foreach (var analysisResult in symbolAnalysisTable)
                {
                    if (analysisResult.Value != null)
                    {
                        codeStringBuilder.Replace(analysisResult.Key, analysisResult.Value);
                    }
                }


                var propertyCodeTemplates = codeExportConfig.CodeTemplateConfig.PropertyCodeTemplates;
                if (propertyCodeTemplates.Length > 0)
                {
                    //提取属性内容符号
                    var propertyMatchCollection = this.PropertyContentSymbolExtracter.Matches(bodyCodeTemplate);
                    if (propertyMatchCollection.Count > 0)
                    {
                        //改变上下文位置
                        context.Location = BuildLocationType.Property;
                        //遍历提取到的属性内容符号
                        foreach (Match match in propertyMatchCollection)
                        {
                            var propertySymbol = this.ExtractPrpertySymbol(match.Value);
                            var propertyCodeTemplate = propertyCodeTemplates.Where(t => t.Name == propertySymbol).FirstOrDefault();
                            if (propertyCodeTemplate == null) continue;
                            //提取属性代码模板中的内容符号
                            var propMatchCollection = this.ContentSymbolExtracter.Matches(propertyCodeTemplate.Content);
                            var propertyCode = new StringBuilder();
                            //提取所有的内容符号
                            foreach (var schema in tupleInfo.ColumnSchemas)
                            {
                                var propertyCodeStringBuilder = new StringBuilder(propertyCodeTemplate.Content);
                                var propertySymbolAnalysisTable = new Dictionary<String, String>();
                                context.ColumnSchema = schema;
                                if (propMatchCollection.Count > 0)
                                {
                                    foreach (Match psymbolMatch in propMatchCollection)
                                    {
                                        var matchValue = psymbolMatch.Value;
                                        var symbol = this.ExtractSymbol(matchValue);
                                        if (!contentSymbolTable.ContainsKey(symbol)) continue;

                                        IContentSymbol contentSymbol = contentSymbolTable[symbol];
                                        //如果符号未解析过，或者内容符号的定义表明需要重复解析
                                        if (!propertySymbolAnalysisTable.ContainsKey(matchValue) || contentSymbol.WhetherNeedRepetition)
                                        {
                                            var analysisResult = contentSymbol.Analysing(context);
                                            propertySymbolAnalysisTable[matchValue] = analysisResult;
                                        }
                                    }
                                }
                                //组合当前 ColumnSchema 的代码
                                foreach (var analysisResult in propertySymbolAnalysisTable)
                                {
                                    if (analysisResult.Value != null)
                                    {
                                        propertyCodeStringBuilder.Replace(analysisResult.Key, analysisResult.Value);
                                    }
                                }
                                //将代码添加到属性模板代码中
                                propertyCode.Append(propertyCodeStringBuilder);
                            }

                            codeStringBuilder.Replace(match.Value, propertyCode.ToString());
                        }
                    }
                }

                exportInfo.Code = codeStringBuilder.ToString();
                exportInfo.FileName = codeExportConfig.SymbolModifier.Modify(tableSchema.Name, SymbolModifyType.ClassName) + codeExportConfig.CodeTemplateConfig.ExtensionName;
                exportInfos.Add(exportInfo);
                exportEventArgs.Current += 1;
                this.ExportProgressChanged?.Invoke(this, exportEventArgs);
            }


            //将 Code 信息写入到临时文件中
            String directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            var directoryInfo = Directory.CreateDirectory(directory);
            foreach (var exportInfo in exportInfos)
            {
                String path = Path.Combine(directory, exportInfo.FileName);
                File.WriteAllText(path, exportInfo.Code);
                exportInfo.FilePath = path;
            }
            String[] exportFiles = exportInfos.Select(t => t.FilePath).ToArray();
            foreach (var targeter in exportTargeters)
            {
                targeter.PointTo(exportFiles);
            }
            //删除临时目录
            Directory.Delete(directory,true);
        }
        private String ExtractPrpertySymbol(String match)
        {
            return match.Trim('#').Trim();
        }
        private String ExtractSymbol(String match)
        {
            return match.Trim('$').Trim();
        }
        internal class CodeExportInfo
        {
            public String FilePath { get; set; }
            public String Code { get; set; }
            public String FileName { get; set; }
        }
    }

}
