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
    public partial class WaitingForm : BaseForm
    {
        public static WaitingForm Current { get; internal set; }
        public static ShadeForm Shade { get; internal set; }

        public static Boolean ShowingErrorState { get; internal set; }

        public static void ShowErrorInfo(String errorInfo)
        {
            if (Current == null || !Current.Visible)
            {
                ShowWaiting(errorInfo);
            }
            else
            {
                Current.TipInfo = errorInfo;
            }
            ShowingErrorState = true;
        }
        /// <summary>
        /// 使等待框显示指定的提示文本，此函数要求等待框正在运行
        /// </summary>
        /// <param name="tipInfo"></param>
        public static void ShowTipInfo(String tipInfo)
        {
            if (Current == null || !Current.Visible) return;
            ShowingErrorState = false;
            Current.TipInfo = tipInfo;
        }
        public static void ShowWaiting(String tipInfo = null)
        {
            if (Current == null)
            {
                Current = new WaitingForm();
                Current.Click += Current_Click;
                Shade = new ShadeForm();
                Shade.Click += Shade_Click;
            }
            ShowingErrorState = false;
            if (!Current.Visible)
            {
                Shade.TopMost = true;
                Current.TopMost = true;
                Current.Size = MainForm.Current.Size;
                Shade.Size = MainForm.Current.Size;
                Current.TipInfo = tipInfo;
                Current.DesktopLocation = MainForm.Current.DesktopLocation;
                Shade.DesktopLocation = Current.DesktopLocation;
                if (!ToolBox.IsDebugMode())
                {
                    Shade.Show();
                }
                Current.Show();
            }
        }

        private static void Shade_Click(Object sender, EventArgs e)
        {
            if (ShowingErrorState)
            {
                HideWaiting();
            }
        }

        private static void Current_Click(Object sender, EventArgs e)
        {
            if (ShowingErrorState)
            {
                HideWaiting();
            }
        }

        public static void HideWaiting()
        {
            if (Current == null)
            {
                return;
            }
            ShowingErrorState = false;
            if (Current.Visible)
            {

                Current.TipInfo = null;
                if (!ToolBox.IsDebugMode())
                {
                    Shade.Hide();
                }
                Current.Hide();
            }
        }
        public String TipInfo
        {
            get
            {
                return this._lblTipInfo.Text;
            }
            set
            {
                this._lblTipInfo.Text = value;
                if (String.IsNullOrWhiteSpace(this._lblTipInfo.Text))
                {
                    this._lblTipInfo.Visible = false;
                }
                else
                {
                    this._lblTipInfo.Visible = true;
                }
            }
        }

        public WaitingForm()
        {
            InitializeComponent();

        }

        private void CenterPicturebox()
        {
            var localtion = this._plContainer.Location;
            var partentSize = this.Size;
            var pbSize = this._plContainer.Size;
            //X 居中
            Int32 newXLocaltion = (partentSize.Width - pbSize.Width) / 2;
            //Y 居中
            Int32 newYLocaltion = (partentSize.Height - pbSize.Height) / 2;

            this._plContainer.Location = new Point(newXLocaltion, newYLocaltion);
        }

        private void WaitingForm_Resize(Object sender, EventArgs e)
        {
            this.CenterPicturebox();
        }


    }
}
