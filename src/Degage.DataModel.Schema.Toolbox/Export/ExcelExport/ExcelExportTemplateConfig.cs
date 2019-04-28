using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.DataModel.Schema.Toolbox
{
    public class ExcelExportTemplateConfig : ConfigBase
    {
        [ConfigTag(Name = "模板项集合", Description = "模板项集合", IsFindable = true)]
        public ExcelExportTemplateItem[] TemplateItems { get; set; }
    }
    public class ExcelExportTemplateItem : ConfigBase
    {
        /// <summary>
        /// 模板名称
        /// </summary>
        [ConfigTag(Name = "名称", Description = "模板的名称", IsFindable = true)]
        public String Name { get; set; }
        /// <summary>
        /// 模板路径，此路径应该是一个相对于模板配置文件的相对路径
        /// </summary>
        [ConfigTag(Name = "路径", Description = "模板文件的相对路径", IsFindable = true)]
        public String Path { get; set; }

    }
}
