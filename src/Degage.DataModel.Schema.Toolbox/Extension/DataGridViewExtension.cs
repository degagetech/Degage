using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Degage.DataModel.Schema.Toolbox
{
    public static class DataGridViewExtension
    {
        public static T GetSelectedRowModel<T>(this DataGridView view) where T : class
        {
            T obj = null;
            if (view.SelectedRows.Count > 0)
            {
                obj = view.SelectedRows[0].DataBoundItem as T;
            }
      

            return obj;
        }
    }
}
