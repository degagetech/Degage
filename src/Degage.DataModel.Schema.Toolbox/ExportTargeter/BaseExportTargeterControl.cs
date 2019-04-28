using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Degage.DataModel.Schema.Toolbox
{
    public partial class BaseExportTargeterControl : UserControl
    {


        /// <summary>
        /// 控件当前关联的导出定向器
        /// </summary>
        public IExportTargeter ExportTargeter { get; protected set; }
        public BaseExportTargeterControl()
        {
            InitializeComponent();
        }

        public virtual (Boolean isValid, String message) VerifyTargeterSetting()
        {
            Boolean isvalid = false;
            String message = null;

            return (isvalid, message);
        }
    }
}
