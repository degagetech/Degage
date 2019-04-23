using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Spire.Doc;
using Spire.Doc.Interface;

namespace WorkPerformance
{
    public class PerformanceTemplateManager
    {
        /// <summary>
        /// 模板信息文件的后缀名
        /// </summary>
        public static String TemplateInfoFileExt { get; private set; } = ".ptl.json";
        /// <summary>
        /// 绩效模板的存储文件夹
        /// </summary>
        public String TemplateFloder { get; private set; }

        /// <summary>
        /// 初始化绩效模板管理
        /// </summary>
        public void Init()
        {
            this.TemplateFloder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PerformanceTemplates");

            if (!Directory.Exists(TemplateFloder))
            {
                Directory.CreateDirectory(TemplateFloder);
            }
        }
        public Task<List<PerformanceTemplateInfo>> GetPerformanceTemplateInfosAsync()
        {
            return Task.Run(() =>
            {
                return this.GetPerformanceTemplateInfos();
            });
        }
        /// <summary>
        /// 加载本地存储的绩效模板信息
        /// </summary>
        /// <returns></returns>
        public List<PerformanceTemplateInfo> GetPerformanceTemplateInfos()
        {
            List<PerformanceTemplateInfo> templateInfos = new List<PerformanceTemplateInfo>();
            var ptlFileNames = Directory.GetFiles(this.TemplateFloder, "*" + TemplateInfoFileExt);
            if (ptlFileNames.Length > 0)
            {
                foreach (var fileName in ptlFileNames)
                {
                    var template = DataSerializer.Deserialize<PerformanceTemplate>(fileName);
                    if (!this.CheckTemplateVaild(template))
                    {
                        continue;
                    }
                    PerformanceTemplateInfo templateInfo = this.CreateTemplateInfo(template);
                    templateInfos.Add(templateInfo);
                }
            }
            return templateInfos;
        }
        public PerformanceTemplateInfo CreateTemplateInfo(PerformanceTemplate template)
        {
            PerformanceTemplateInfo templateInfo = new PerformanceTemplateInfo(template);
            templateInfo.IsExistedTemplateFile = this.ExistingTemplateFile(template);
            templateInfo.Manager = this;
            return templateInfo;
        }
        /// <summary>
        /// 保存绩效模板信息，若存在则覆盖，若未指定文件名称，则使用模板名称作为文件名称
        /// </summary>
        /// <param name="template"></param>
        public void SavePerformanceTemplate(PerformanceTemplate template, String fileName = null)
        {
            if (fileName == null)
            {
                fileName = template.Name + TemplateInfoFileExt;
            }
            String filePath = Path.Combine(this.TemplateFloder, fileName);
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();
            }
            DataSerializer.Serialize(template, filePath);
        }
        public Boolean CheckTemplateVaild(PerformanceTemplate template)
        {
            if (template == null || template.SchemaItems == null || template.SchemaItems.Length == 0)
            {
                return false;
            }

            var tableSchemaItems = template.SchemaItems.Where(t => t.ItemType == TemplateSchemaItemType.Table);
            foreach (var tableSchemaItem in tableSchemaItems)
            {
                if (!tableSchemaItem.TableIndex.HasValue) return false;
                if (tableSchemaItem.TableIndex < 0) return false;

                if (tableSchemaItem.FillSchema != null)
                {
                    if (!tableSchemaItem.FillSchema.RowIndex.HasValue || tableSchemaItem.FillSchema.RowIndex.Value < 0) return false;
                }

                if (tableSchemaItem.ExtractSchema != null)
                {
                    if (!tableSchemaItem.ExtractSchema.RowIndex.HasValue) return false;
                }

            }
            return true;
        }
        public Task FillDataItemsAsync(PerformanceTemplateInfo templateInfo, IList<DataItem> dataItems, String outPath, Boolean isOverride = false)
        {
            return Task.Run(() =>
            {
                this.FillDataItems(templateInfo, dataItems, outPath, isOverride);
            });
        }
        public Task<List<DataItem>> ExtractDataItemsAsync(PerformanceTemplateInfo templateInfo, String filePath)
        {
            return Task.Run(() =>
            {
                return this.ExtractDataItems(templateInfo, filePath);
            });
        }
        /// <summary>
        /// 使用指定的绩效模板信息从限定路径的绩效文件中提取数据
        /// </summary>
        /// <param name="templateInfo"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<DataItem> ExtractDataItems(PerformanceTemplateInfo templateInfo, String filePath)
        {
            List<DataItem> dataItems = new List<DataItem>();
            //加载绩效文件到内存
            Document document = new Document();
            document.LoadFromFile(filePath);

            //获取所有 Text 类型的结构项
            var textSchemaItems = templateInfo.Template.SchemaItems.Where(t => t.ItemType == TemplateSchemaItemType.Text);
            //获取文档中的所有文本信息
            String docText = document.GetText();

            //提取文本结构项对应的数据项
            foreach (var textSchemaItem in textSchemaItems)
            {
                var extractSchema = textSchemaItem.ExtractSchema;
                //使用正则匹配，例如，正则： '(?<=部门：)[\S]+'  会匹配 '部门：技术支持一部 '  中的 '技术支持一部'
                var match = Regex.Match(docText, extractSchema.ExtractRegex, RegexOptions.Multiline);
                if (match.Success)
                {
                    DataItem dataItem = new DataItem();
                    dataItem.Name = textSchemaItem.Name;
                    dataItem.TextData = match.Value.Trim().Trim('\r', '\n');
                    dataItems.Add(dataItem);
                }
            }


            //获取所有 Table 类型的结构项
            var tableSchemaItems = templateInfo.Template.SchemaItems.Where(t => t.ItemType == TemplateSchemaItemType.Table);

            //按操作表分组，
            var tsigroups = tableSchemaItems.GroupBy(t => t.TableIndex.Value);

            //Key 为表索引，表示操作同一个表的结构项成组
            var tsiOrderedCollections = new Dictionary<Int32, IOrderedEnumerable<TemplateSchemaItem>>();
            //按操作行排序
            foreach (var group in tsigroups)
            {
                var orderedItemCollection = group.OrderBy(t => t.FillSchema.RowIndex);
                tsiOrderedCollections.Add(group.Key, orderedItemCollection);
            }
            if (tsiOrderedCollections.Count == 0)
            {
                return dataItems;
            }
            //开始提供 Table 中的行数据项
            var documentSection = document.Sections[0];
            foreach (var orderedItemCollection in tsiOrderedCollections)
            {
                //获取操作的表
                var documentTable = documentSection.Tables[orderedItemCollection.Key];

                Int32 lastExtractRowIndex = 0;
                //此处排序后提取项行起始索引的大小总是由上到下的
                foreach (var tableSchemaItem in orderedItemCollection.Value)
                {
                    if (tableSchemaItem.TableIndex >= documentSection.Tables.Count)
                    {
                        continue;
                    }
                    var extractSchema = tableSchemaItem.ExtractSchema;
                    if (extractSchema == null) continue;
                    //创建数据表
                    DataTable dataTable = this.CreateDataTable(tableSchemaItem);
                    DataItem dataItem = new DataItem
                    {
                        Name = tableSchemaItem.Name,
                        TableData = dataTable
                    };

                    var rowIndex = extractSchema.RowIndex.Value + lastExtractRowIndex;

                    //循环获取行数据，直到遇见列数目不匹配的行
                    while (true)
                    {
                        var docRow = documentTable.Rows[rowIndex];
                        if (docRow.Cells.Count != tableSchemaItem.TableSchemaItemColumns.Length)
                        {
                            rowIndex--;
                            break;
                        }

                        var dataRow = dataTable.NewRow();
                        for (int i = 0; i < docRow.Cells.Count; i++)
                        {
                            var docCell = docRow.Cells[i];
                            dataRow[i] = this.GetCellText(docCell);
                        }
                        dataTable.Rows.Add(dataRow);
                        rowIndex++;
                    }
                    lastExtractRowIndex = rowIndex;
                    dataItems.Add(dataItem);
                }
            }

            return dataItems;
        }

        /// <summary>
        /// 根据指定结构项创建对于的数据项的数据存储表，结构项类型必须为 <see cref="TemplateSchemaItemType.Table"/>，否则返回空 
        /// </summary>
        /// <param name="schemaItem"></param>
        /// <returns></returns>
        public DataTable CreateDataTable(TemplateSchemaItem schemaItem)
        {
            if (schemaItem.ItemType != TemplateSchemaItemType.Table) return null;
            DataTable table = new DataTable();
            table.TableName = schemaItem.Name;
            foreach (var columnNames in schemaItem.TableSchemaItemColumns)
            {
                table.Columns.Add(columnNames, typeof(String));
            }
            return table;
        }
        /// <summary>
        /// 使用指定的数据项填充到绩效模板对应的模板文件中，并将结果保存至指定路径
        /// </summary>
        /// <param name="templateInfo">模板信息</param>
        /// <param name="dataItems">数据项集合</param>
        /// <param name="outPath">保存路径</param>
        /// <param name="isOverride">是否覆盖，若否，则当文件存在时，放弃填充结果</param>
        public void FillDataItems(PerformanceTemplateInfo templateInfo, IList<DataItem> dataItems, String outPath, Boolean isOverride = false)
        {
            String templateFilePath = this.GetTemplateFilePath(templateInfo.Template);

            var template = templateInfo.Template;

            //加载模板文件到内存
            Document document = new Document();
            document.LoadFromFile(templateFilePath);

            //构建数据项字典
            var dataItemDict = dataItems.ToDictionary(t => t.Name);

            //获取所有 Text 类型的结构项
            var textSchemaItems = templateInfo.Template.SchemaItems.Where(t => t.ItemType == TemplateSchemaItemType.Text);

            //开始 Text 类型的结构项的数据填充
            foreach (var textSchemaItem in textSchemaItems)
            {
                //获取结构项对应的数据项，若无则跳过此次填充操作
                if (!dataItemDict.ContainsKey(textSchemaItem.Name))
                {
                    continue;
                }
                var dataItem = dataItemDict[textSchemaItem.Name];
                String placeholderStr = String.Format(template.PlaceholderFormat, textSchemaItem.FillSchema.Id);
                var effect = document.Replace(placeholderStr, dataItem.TextData, true, true);
            }
            /*--------------------------------------------*/
            //获取所有 Table 类型的结构项
            var tableSchemaItems = templateInfo.Template.SchemaItems.Where(t => t.ItemType == TemplateSchemaItemType.Table);
            //按操作表分组，
            var tsigroups = tableSchemaItems.GroupBy(t => t.TableIndex.Value);

            //Key 为表索引，表示操作同一个表的结构项成组
            var tsiOrderedCollections = new Dictionary<Int32, IOrderedEnumerable<TemplateSchemaItem>>();
            //按操作行排序
            foreach (var group in tsigroups)
            {
                var orderedItemCollection = group.OrderBy(t => t.FillSchema.RowIndex);
                tsiOrderedCollections.Add(group.Key, orderedItemCollection);
            }


            var documentSection = document.Sections[0];
            foreach (var orderedItemCollection in tsiOrderedCollections)
            {
                //获取操作的表
                var documentTable = documentSection.Tables[orderedItemCollection.Key];
                //记录填充数据后，原有行索引的偏移
                Int32 rowIndexOffset = 0;
                //此处排序后填充项行起始索引的大小总是由上到下的
                foreach (var tableSchemaItem in orderedItemCollection.Value)
                {
                    if (tableSchemaItem.TableIndex >= documentSection.Tables.Count)
                    {
                        continue;
                    }
                    var fillSchema = tableSchemaItem.FillSchema;
                    if (fillSchema == null) continue;
                    //获取对应的数据项
                    if (!dataItemDict.ContainsKey(tableSchemaItem.Name))
                    {
                        continue;
                    }


                    var dataItem = dataItemDict[tableSchemaItem.Name];
                    var dataTable = dataItem.TableData;


                    //当前插入行的位置
                    Int32 currentRowIndex = rowIndexOffset + fillSchema.RowIndex.Value;
                    //循环插入行数据
                    var columnCount = dataTable.Columns.Count;
                    Int32 insertCount = 0;
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        TableRow docRow = documentTable.Rows[currentRowIndex];
                        var newDocRow = docRow.Clone();
                        //循环填充单元格数据
                        for (Int32 i = 0; i < columnCount; i++)
                        {
                            if (i >= docRow.Cells.Count)
                            {
                                break;
                            }
                            docRow.Cells[i].FirstParagraph.Text = dataRow[i].ToString();
                        }
                        insertCount++;
                        if (insertCount < dataTable.Rows.Count)
                        {
                            documentTable.Rows.Insert(++currentRowIndex, newDocRow);
                            ///每填充一行，行偏移量递增
                            rowIndexOffset++;
                        }
                    }

                }
            }

            document.SaveToFile(outPath, FileFormat.Docx);
            document.Dispose();
        }
        private String GetCellText(TableCell cell)
        {
            String result = String.Empty;
            if (cell.Paragraphs.Count == 1)
            {
                result = cell.FirstParagraph.Text;
            }
            else
            {
                foreach (IParagraph para in cell.Paragraphs)
                {
                    if (!String.IsNullOrEmpty(para.Text))
                    {
                        result += para.Text;
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 判断指定绩效模板对应的模板文件是否存在
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        public Boolean ExistingTemplateFile(PerformanceTemplate template)
        {
            Boolean existed = false;
            String path = template.TemplateFilePath;
            path = Path.Combine(this.TemplateFloder, path);

            existed = File.Exists(path);
            return existed;
        }
        public String GetTemplateFilePath(PerformanceTemplate template)
        {
            String path = template.TemplateFilePath;
            path = Path.Combine(this.TemplateFloder, path);
            return path;
        }
    }
}
