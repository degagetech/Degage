using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Degage.DataModel.Schema.Toolbox
{
    public partial class BaseExportConfigControl : UserControl
    {
        /// <summary>
        /// 获取控件当前关联的 <see cref="ISchemaProvider"/> 接口的实例
        /// </summary>
        public virtual ISchemaExporter SchemaExporter { get; protected set; }
        /// <summary>
        /// 获取控件当前的导出配置信息
        /// </summary>
        public virtual ExportConfig ExportConfig { get; protected set; }

        /// <summary>
        /// 控件当前关联的 <see cref="IExportContext"/> 接口的实例
        /// </summary>
        public IExportContext ExportContext { get; private set; }

        public BaseExportConfigControl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 将包含的导出配置信息的字符串导入至控件，由控件解析其中的配置信息
        /// </summary>
        /// <param name="configString"></param>
        public virtual void ImportConfigInfo(String configString)
        {

        }
        /// <summary>
        /// 通过控件将当前其关联的导出配置导出为字符串信息，以便于保存等操作
        /// </summary>
        /// <returns></returns>
        public virtual String ExportConfigInfo()
        {
            return null;
        }
        /// <summary>
        /// 验证当前控件中的导出配置是否有效，并将验证结果信息写入到输出参数中
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public virtual Boolean IsValidExportConfig(out String errorMessage)
        {
            errorMessage = null;
            return false;
        }
        /// <summary>
        /// 重置控件所表示的导出配置信息
        /// </summary>
        public virtual void ResetConfigInfo()
        {

        }
        /// <summary>
        /// 使用指定的导出上下文初始化控件
        /// </summary>
        /// <param name="context"></param>
        public virtual void Initialize(IExportContext context)
        {
            this.ExportContext = context;
        }
    }
}
