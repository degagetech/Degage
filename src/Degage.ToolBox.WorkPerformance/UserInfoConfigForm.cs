using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkPerformance.Properties;

namespace WorkPerformance
{
    public partial class UserInfoConfigForm : BaseForm
    {
        private static readonly Char PasswordChar = '●';

        private static readonly String InitEMailAddressTextInfo = "你的邮箱~";
        private static readonly String InitPasswordTextInfo = "你的密码~";

        public UserInfoConfigForm()
        {
            InitializeComponent();

            this._tbEmailAddress.Text = InitEMailAddressTextInfo;
            this._tbEmailAddress.GotFocus += _tbEmailAddress_GotFocus;
            this._tbEmailAddress.LostFocus += _tbEmailAddress_LostFocus;
            this._tbPassword.Text = InitPasswordTextInfo;
            this._tbPassword.GotFocus += _tbPassword_GotFocus;
            this._tbPassword.LostFocus += _tbPassword_LostFocus;
            this.Load += UserInfoConfigForm_Load;
        }

        private void UserInfoConfigForm_Load(Object sender, EventArgs e)
        {
            this.RenderingUserInfoConfig(Config<UserInfoConfig>.Current);
            this.UpdatePasswordTextState();
        }
        private void RenderingUserInfoConfig(UserInfoConfig config)
        {
            this._tbEmailAddress.Text = config.EmailAddress;
            this._tbPassword.Text = config.Password;
            this._tbDefaultReceviceEmail.Text = config.DefaultReceviceEmail;
            this._tbName.Text = config.Name;
            this._tbDepartment.Text = config.Department;
        }

        private void UpdatePasswordTextState()
        {
            if (String.IsNullOrWhiteSpace(this._tbPassword.Text))
            {
                this._tbPassword.Text = InitPasswordTextInfo;
                this._tbPassword.PasswordChar = Char.MinValue;
                return;
            }
            if (this._tbPassword.Text.Trim() == InitPasswordTextInfo)
            {
                this._tbPassword.Text = null;
                this._tbPassword.PasswordChar = PasswordChar;
            }
            else
            {
                this._tbPassword.PasswordChar = PasswordChar;
            }

        }

        private void UpdateEmailAddressTextState()
        {
            if (String.IsNullOrWhiteSpace(this._tbEmailAddress.Text))
            {
                this._tbEmailAddress.Text = InitEMailAddressTextInfo;
            }
            if (this._tbEmailAddress.Text.Trim() == InitEMailAddressTextInfo)
            {
                this._tbEmailAddress.Text = null;
            }
        }
        private void _tbPassword_LostFocus(Object sender, EventArgs e)
        {
            this.UpdatePasswordTextState();
        }

        private void _tbEmailAddress_LostFocus(Object sender, EventArgs e)
        {
            this.UpdateEmailAddressTextState();
        }

        private void _tbPassword_GotFocus(Object sender, EventArgs e)
        {
            this.UpdatePasswordTextState();
        }

        private void _tbEmailAddress_GotFocus(Object sender, EventArgs e)
        {
            this.UpdateEmailAddressTextState();
        }

        private void _btnDisplayPassword_MouseDown(Object sender, MouseEventArgs e)
        {
            if (this._tbPassword.Text.Trim() != InitPasswordTextInfo)
            {
                this._tbPassword.PasswordChar = Char.MinValue;
                this._btnDisplayPassword.Image = Resources.NoDisplay;
            }

        }

        private void _btnDisplayPassword_MouseUp(Object sender, MouseEventArgs e)
        {
            if (this._tbPassword.Text.Trim() != InitPasswordTextInfo)
            {
                this._tbPassword.PasswordChar = PasswordChar;
                this._btnDisplayPassword.Image = Resources.Display;
            }


        }

        private void _btnCancel_Click(Object sender, EventArgs e)
        {
            this.CancelClose();

        }
        private Boolean SaveUserInfoConfig(UserInfoConfig config)
        {
            String address = this._tbEmailAddress.Text.Trim();
            String password = this._tbPassword.Text.Trim();
            String defaultReceviceEmail = this._tbDefaultReceviceEmail.Text.Trim();
            String name = this._tbName.Text.Trim();
            String department = this._tbDepartment.Text.Trim();
            if (String.IsNullOrEmpty(address)) return false;
            if (String.IsNullOrEmpty(password)) return false;
            config.EmailAddress = address;
            config.Password = password;
            config.DefaultReceviceEmail = defaultReceviceEmail;
            config.Name = name;
            config.Department = department;
            return true;
        }
        private async void _btnConfirm_Click(Object sender, EventArgs e)
        {
            if (!this.SaveUserInfoConfig(Config<UserInfoConfig>.Current))
            {
                return;
            }
            await Config<UserInfoConfig>.SaveAsync();

            this.ConfirmClose();
        }

        private void UserInfoConfigForm_Load_1(object sender, EventArgs e)
        {
            Animator.DebutAnimation(this, DebutEffects.Fade | DebutEffects.Debut, 200);
        }

        private void UserInfoConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Animator.DebutAnimation(this, DebutEffects.Fade | DebutEffects.WalkOff, 200);
        }
    }
}
