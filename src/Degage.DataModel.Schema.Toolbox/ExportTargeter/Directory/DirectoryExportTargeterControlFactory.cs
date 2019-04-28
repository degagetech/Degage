using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

namespace Degage.DataModel.Schema.Toolbox
{
    [Export(typeof(IExportTargeterControlFactory))]
    public class DirectoryExportTargeterControlFactory : IExportTargeterControlFactory
    {
        public BaseExportTargeterControl CreateTargeterControl(Object state)
        {
            return new DirectoryExportTargeterControl();
        }
    }
}
