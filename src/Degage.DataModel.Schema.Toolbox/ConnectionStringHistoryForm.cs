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
        public ConnectionHistoryConfig HistoryConfig { get; protected set; }
        public ConnectionStringHistoryForm()
        {
            InitializeComponent();
        }
        public ConnectionStringHistoryForm(ConnectionHistoryConfig config) : this()
        {
            this.HistoryConfig = config;
            this._colProviderName.DataPropertyName = nameof(ConnectionHistoryItem.ProviderName);
            this._colConnectionString.DataPropertyName = nameof(ConnectionHistoryItem.ConnectionString);
            BindingList<ConnectionHistoryItem> list = new BindingList<ConnectionHistoryItem>(config.Historys);
            this._dgvHistory.DataSource = list;
        }

        private void _btnCannel_Click(Object sender, EventArgs e)
        {
            this.CancelClose();
        }

        private void _btnConfirm_Click(Object sender, EventArgs e)
        {
            if (this._dgvHistory.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选中一条记录！");
                return;
            }
            this.SelectedHistoryItem = (ConnectionHistoryItem)this._dgvHistory.SelectedRows[0].DataBoundItem;
            this.ConfirmClose();
        }

        private void _btnRemove_Click(Object sender, EventArgs e)
        {
            if (this._dgvHistory.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选中一条记录！");
                return;
            }
            var selected = this._dgvHistory.SelectedRows[0];
            this._dgvHistory.Rows.RemoveAt(selected.Index);
        }

        private void _btnSaveHistory_Click(Object sender, EventArgs e)
        {
            ConfigManager.SaveConfig<ConnectionHistoryConfig>(this.HistoryConfig, ConnectionHistoryConfig.FilePath);
            MessageBox.Show(this,"已保存！","提示");
        }
    }
}
