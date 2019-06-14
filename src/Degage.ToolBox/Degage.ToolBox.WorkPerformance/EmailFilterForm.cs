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
    public partial class EmailFilterForm : BaseForm
    {
        public Int32 CollectRecentDays { get; private set; }
        public EmailFilterForm()
        {
            InitializeComponent();

        }



        private void _btnCancel_Click(Object sender, EventArgs e)
        {
            this.CancelClose();
        }

        private void EmailFilterForm_Load(Object sender, EventArgs e)
        {
            Animator.DebutAnimation(this, DebutEffects.Fade | DebutEffects.Debut, 200);
            this.RenderingEmailFilterConfig(Config<EmailFilterConfig>.Current);

        }
        private void RenderingEmailFilterConfig(EmailFilterConfig config)
        {
            this._tbRcentDays.Text = config.CollectRecentDays.ToString();
            this._tbKeywords.Text = config.GetTitleKeywordsString();
        }
        private void EmailFilterForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            Animator.DebutAnimation(this, DebutEffects.Fade | DebutEffects.WalkOff, 200);
        }
        private Boolean SaveEmailFilterConfig(EmailFilterConfig config)
        {
            var str = this._tbRcentDays.Text.Trim();
            if (Int32.TryParse(str, out var days) && days > 0)
            {
                this.CollectRecentDays = days;
            }
            else
            {
                return false;
            }
            String keywords = this._tbKeywords.Text.Trim();

            if (String.IsNullOrWhiteSpace(keywords))
            {
                return false;
            }

            config.CollectRecentDays = this.CollectRecentDays;
            config.TitleKeywords = config.SplitKeywords(keywords);
            return true;
        }
        private async void _btnConfirm_Click(Object sender, EventArgs e)
        {
            if (!this.SaveEmailFilterConfig(Config<EmailFilterConfig>.Current))
            {
                return;
            }
            await Config<EmailFilterConfig>.SaveAsync();

            this.ConfirmClose();
        }



    }
}
