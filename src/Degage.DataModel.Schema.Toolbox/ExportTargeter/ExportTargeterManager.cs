using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;

namespace Degage.DataModel.Schema.Toolbox
{
    public class ExportTargeterManager
    {
        /// <summary>
        /// 最后一次缓存的 <see cref="IExportTargeterControlFactory"/> 对象的列表
        /// </summary>
        public IList<IExportTargeterControlFactory> ExportTargeterControlFactorys { get; private set; }

        /// <summary>
        ///搜索包含实现 <see cref="IExportTargeterControlFactory"/> 接口的类的程序集的名称格式 
        /// </summary>
        internal const String SearchPattern = "Degage.DataModel.Schema.Toolbox*";
        /// <summary>
        /// 从当前目录下的所有程序集中加载所有实现 <see cref="IExportTargeterControlFactory"/> 接口的实例
        /// </summary>
        public IList<IExportTargeterControlFactory> LoadIExportTargeterControlFactorys()
        {
            var providers = new List<IExportTargeterControlFactory>();

            String directory =Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            DirectoryCatalog catalog = new DirectoryCatalog(directory, SearchPattern);
            using (CatalogExportProvider exportProvider = new CatalogExportProvider(catalog))
            {
                exportProvider.SourceProvider = exportProvider;
                var exports= exportProvider.GetExportedValues<IExportTargeterControlFactory>();
                providers.AddRange(exports);
            }

            this.ExportTargeterControlFactorys = providers;
            return providers;
        }

    }
}
