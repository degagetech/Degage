using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Degage.DataModel.Schema.Toolbox
{
    public partial class ConnectionStringHistoryForm : BaseForm
    {
        public ConnectionHistoryItem SelectedHistoryItem { get; protected set; }
        public ConnectionStringHistoryForm()
        {
            InitializeComponent();
        }
        public ConnectionStringHistoryForm(ConnectionHistoryConfig config) : this()
        {
            this._lbHistory.DataSource = config.Historys;
        }

        private void _btnCannel_Click(Object sender, EventArgs e)
        {
            this.CancelClose();
        }

        private void _btnConfirm_Click(Object sender, EventArgs e)
        {
            this.SelectedHistoryItem = (ConnectionHistoryItem)this._lbHistory.SelectedItem;
            this.ConfirmClose();
        }

        private void _lbHistory_DoubleClick(Object sender, EventArgs e)
        {
            if (this._lbHistory.SelectedValue != null)
            {
                this.SelectedHistoryItem = (ConnectionHistoryItem)this._lbHistory.SelectedItem;
            }
            else
            {
                this.SelectedHistoryItem = null;
            }
            this.ConfirmClose();
        }
    }
}
