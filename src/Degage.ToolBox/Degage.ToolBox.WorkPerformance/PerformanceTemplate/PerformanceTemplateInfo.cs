using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPerformance
{
    /// <summary>
    /// 对绩效模板信息的封装
    /// </summary>
    public class PerformanceTemplateInfo
    {
        internal PerformanceTemplateManager Manager { get; set; }
        public PerformanceTemplateInfo()
        {

        }
        public async Task SaveAsync(String fileName = null)
        {
            if (this.Manager == null) return;
            await Task.Run(() =>
             {
                 this.Manager.SavePerformanceTemplate(this.Template, fileName);
             });
        }
        public PerformanceTemplateInfo(PerformanceTemplate template) : this()
        {
            this.Template = template;
        }
        /// <summary>
        /// 模板的名称
        /// </summary>
        public String Name
        {
            get
            {
                return this.Template.Name;
            }
        }
        /// <summary>
        /// 表示绩效模板对应的模板文件是否存在
        /// </summary>
        public Boolean IsExistedTemplateFile { get; set; }
        /// <summary>
        /// 对应模板
        /// </summary>
        public PerformanceTemplate Template { get; set; }
    }
}
