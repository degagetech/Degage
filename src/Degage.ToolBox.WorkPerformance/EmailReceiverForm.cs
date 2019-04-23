using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkPerformance
{
    public partial class EmailReceiverForm : BaseForm
    {
        public Boolean EnabledReceiverEdit { get; internal set; } = true;
        public EmailReceiverItem SelectedItem
        {
            get
            {
                return this._listReceiverItems.SelectedEmailReceiverItem;
            }
        }
        public EmailReceiverForm()
        {
            InitializeComponent();
            this._listReceiverItems.SelectedIndexChanged += _listReceiverItems_SelectedIndexChanged;
            this.Load += EmailReceiverForm_Load;
        }

        private void EmailReceiverForm_Load(object sender, EventArgs e)
        {
            var config = Config<EmailReceiverConfig>.Current;
            this.ShowEmailReceiverItems(config.Items);
        }

        public void ShowEmailReceiverItems(List<EmailReceiverItem> items)
        {
            this._listReceiverItems.ShowReceiverInfo(items);
            if (items.Count > 0)
            {
                this._listReceiverItems.SelectedIndex = this._listReceiverItems.Items.Count - 1;
            }
        }


        private void _listReceiverItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = this._listReceiverItems.SelectedEmailReceiverItem;
            if (item == null) return;
            this._tbName.Text = item.ReceiverName;
            this._tbEmailAddress.Text = item.ReceiverEmailAddress;
        }

        private void _btnCancel_Click(Object sender, EventArgs e)
        {
            this.CancelClose();
        }

        private async void _btnConfirm_Click(Object sender, EventArgs e)
        {
            if (this.EnabledReceiverEdit)
            {
                await Config<EmailReceiverConfig>.SaveAsync();
            }
            this.ConfirmClose();
        }


        public void EnableReceiverEdit(Boolean isEnable = true)
        {
            this.EnabledReceiverEdit = isEnable;
            if (isEnable)
            {
                this.Size = new Size(650, 550);
            }
            else
            {
                this.Size = new Size(650, 430);
            }
            this._lblName.Visible = isEnable;
            this._lblEmailAddress.Visible = isEnable;

            this._btnAddReceiver.Visible = isEnable;
            this._btnRemoveReceiver.Visible = isEnable;

            this._tbEmailAddress.Visible = isEnable;
            this._tbName.Visible = isEnable;
        }

        private void _tbName_TextChanged(object sender, EventArgs e)
        {
            if (this.SelectedItem != null)
            {
                this.SelectedItem.ReceiverName = this._tbName.Text;
                this._listReceiverItems.RefreshItemDraw(this._listReceiverItems.SelectedIndex);
            }
        }

        private void _tbEmailAddress_TextChanged(object sender, EventArgs e)
        {
            if (this.SelectedItem != null)
            {
                this.SelectedItem.ReceiverEmailAddress = this._tbEmailAddress.Text;
                this._listReceiverItems.RefreshItemDraw(this._listReceiverItems.SelectedIndex);
            }
        }

        private void _btnAddReceiver_Click(Object sender, EventArgs e)
        {
            var item = new EmailReceiverItem();
            item.ReceiverName = "请填写";
            item.ReceiverEmailAddress = "请填写";
            this._listReceiverItems.AddEmailReceiverItem(item);
            this._listReceiverItems.SelectedIndex = this._listReceiverItems.Items.Count - 1;
        }

        private void _btnRemoveReceiver_Click(Object sender, EventArgs e)
        {
            this._listReceiverItems.RemoveSelectedItem();
            if (this._listReceiverItems.Items.Count > 0)
            {
                this._listReceiverItems.SelectedIndex = this._listReceiverItems.Items.Count - 1;
            }
            else
            {
                this.SelectedItem.ReceiverName =String.Empty;
                this.SelectedItem.ReceiverEmailAddress = String.Empty;
            }
        }
    }
}
