using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using Spire.Doc;

namespace WorkPerformance
{
    public static class ToolBox
    {
        public static async Task OpenFile(String filePath)
        {
            await Task.Run(() =>
            {
                Process.Start(filePath);
            });
        }
        public static Boolean IsDebugMode()
        {
            return Debugger.IsAttached;
        }
        public static void Export(String templateFilePath, String outPath, Dictionary<String, String> data)
        {
            Document doc = new Document();
            doc.LoadFromFile(templateFilePath);
            Table table = doc.Sections[0].Tables[0] as Table;
            TableRow row = table.Rows[3];
            var newRow = row.Clone();
            //TableRow row = table.AddRow();
            //table.Rows.Insert(2, row);
            newRow.Cells[0].Paragraphs[0].Text = "新增行";
            table.Rows.Insert(2, newRow);
            //  table.AddRow(newRow, 2);
            //  table.AddRow(false, 2);
            doc.SaveToFile(outPath, FileFormat.Docx);

        }

        //private void CopyCellStyle(XWPFTableCell source, XWPFTableCell dest)
        //{

        //    dest.SetBorderBottom();
        //}
        /// <summary>
        /// 输出模板docx文档(使用字典)
        /// </summary>
        /// <param name="templateFilePath">模板 docx 文件的路径</param>
        /// <param name="outPath">输出文件路径</param>
        /// <param name="data">字典数据源</param>
        //public static void Export(String templateFilePath, String outPath, Dictionary<String, String> data)
        //{
        //    using (FileStream stream = File.OpenRead(templateFilePath))
        //    {
        //        XWPFDocument doc = new XWPFDocument(stream);
        //        //遍历段落                  
        //        foreach (var para in doc.Paragraphs)
        //        {
        //            if (para.ParagraphText.Contains("绩效"))
        //            {
        //                para.ReplaceText("绩效", "TEST");
        //            }
        //        }
        //        //遍历表格     
        //        Boolean flag = false;
        //        foreach (var table in doc.Tables)
        //        {
        //            Int32 currentRowIndex = 0;
        //            //table.ins();
        //            foreach (var row in table.Rows)
        //            {

        //                var cells = row.GetTableCells();
        //                if (cells.Count == 5 && !flag)
        //                {

        //                    table.AddRow(row,4);

        //                    var newRow = table.GetRow(4);
        //                    newRow.c
        //                    var newCells = newRow.GetTableCells();
        //                    XWPFTableRow row = table.c
        //                    //table.AddRow(newRow);

        //                    for (int i = 0; i < newCells.Count; i++)
        //                    {
        //                        var cell = newCells[i];
        //                        cell.SetText("test");
        //                    }

        //                    flag = true;
        //                    goto Save;
        //                }
        //                foreach (var cell in cells)
        //                {

        //                    foreach (var para in cell.Paragraphs)
        //                    {
        //                        if (para.ParagraphText.Contains("绩效"))
        //                        {
        //                            para.ReplaceText("绩效", "TEST");
        //                        }
        //                    }
        //                }
        //                currentRowIndex++;
        //            }
        //        }
        //        //写文件
        //        Save:
        //        FileStream outFile = new FileStream(outPath, FileMode.Create);
        //        doc.Write(outFile);
        //        outFile.Close();
        //    }
        //}
    }
}
