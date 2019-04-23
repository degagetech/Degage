using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Degage.Native.Windows;
using Degage.ToolBox.ColorPicker.Properties;

namespace Degage.ToolBox.ColorPicker
{

    public partial class ColorPickerForm : Form
    {
        /// <summary>
        /// 选取器状态
        /// </summary>
        public enum ColorPickerState
        {
            /// <summary>
            /// 正常
            /// </summary>
            Normal = 0,
            /// <summary>
            /// 选取颜色中
            /// </summary>
            Picking = 1,
            /// <summary>
            /// 置顶
            /// </summary>
            Top = 2,
            /// <summary>
            /// 最小化
            /// </summary>
            Minimize
        }
        public ColorPickerState PickerState { get; private set; } = ColorPickerState.Normal;


        /// <summary>
        /// 当前选取的颜色
        /// </summary>
        public Color? SelectedColor { get; private set; }
        /// <summary>
        /// 用于将文本转换为颜色信息
        /// </summary>
        public ColorConverter ColorConverter { get; private set; }
        /// <summary>
        /// 当前系统主屏幕的设备上下文句柄，用于与本地 API 交互
        /// </summary>
        internal IntPtr ScreenHDc { get; private set; } = IntPtr.Zero;
        /********************************/
        public ColorPickerForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.Load += Init;
            this.FormClosing += Release;
            this.Shown += ColorPickerForm_Shown;
        }

        private void ColorPickerForm_Shown(Object sender, EventArgs e)
        {
            this.ShowColor(this.BackColor);
        }

        private void Init(Object sender, EventArgs e)
        {
            var invoke = WindowsApi.GetDC(IntPtr.Zero);
            this.ScreenHDc = invoke.Result;
            this.ColorConverter = new ColorConverter();
        }

        private void Release(Object sender, FormClosingEventArgs e)
        {
            if (this.ScreenHDc != IntPtr.Zero)
            {
                WindowsApi.ReleaseDC(this.Handle, this.ScreenHDc);
            }
        }

        private void _timerCursorPoint_Tick(Object sender, EventArgs e)
        {
            this._timerCursorPoint.Enabled = false;

            switch (this.PickerState)
            {
                //当处于选取状态时，才跟随鼠标并获取颜色信息
                case ColorPickerState.Picking:
                    {
                        Point cursorPos = Form.MousePosition;
                        this.ShowMousePoint(cursorPos);
                        if (IntPtr.Zero != this.ScreenHDc)
                        {
                            var invoke = WindowsApi.GetPixel(this.ScreenHDc, cursorPos.X, cursorPos.Y);
                            if (invoke.Success)
                            {
                                Color color = invoke.Result.Value;
                                this.ShowColor(color);
                            }
                        }
                        this._timerCursorPoint.Enabled = true;
                    }
                    break;
                default: break;
            }
        }

        /// <summary>
        /// 显示鼠标当前处于屏幕上的位置
        /// </summary>
        /// <param name="point"></param>
        private void ShowMousePoint(Point point)
        {
            this.Text = $"({point.X.ToString()},{point.Y.ToString()})";
            this._labelPoint.Text = this.Text;
        }


        private void DrawColorBoard(Color color)
        {
            this._panelColorBoard.BackColor = color;
            //计算灰度值，当颜色较浅时，背景色应该为黑色（深色），当颜色较深时背景色应该为白色（浅色），以更好突显颜色
            //灰度值计算公式： Gray = R*0.299 + G*0.587 + B*0.114
        }
        protected override Boolean ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        #region<<点击窗体任意位置拖动>>
        private Point _currentMousePoint;
        private Boolean _isMove = false;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (MouseButtons.Left == e.Button)
            {
                this._currentMousePoint = e.Location;
                this._isMove = true;
            }
            base.OnMouseDown(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (this._isMove)
            {
                /**计算Point偏移值*/
                Int32 offsetX = e.Location.X - this._currentMousePoint.X;
                Int32 offsetY = e.Location.Y - this._currentMousePoint.Y;

                this.Location = new Point(this.Location.X + offsetX, this.Location.Y + offsetY);
            }
            base.OnMouseMove(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            this._isMove = false;
            base.OnMouseUp(e);
        }
        #endregion

        private void _labelClose_Click(Object sender, EventArgs e)
        {
            this.Close();
        }

        private void _labelMin_Click(Object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.PickerState = ColorPickerState.Minimize;
        }

        private void ColorPickerForm_Activated(Object sender, EventArgs e)
        {
            this.PickerState = ColorPickerState.Normal;
        }
        /// <summary>
        /// 选取颜色
        /// </summary>
        public void PickingColor()
        {
            //进入选取状态
            //避免重复进入
            if (this.PickerState == ColorPickerState.Picking) return;
            this.PickerState = ColorPickerState.Picking;
            this._timerCursorPoint.Enabled = true;
            this._btnPickingColor.Image = Resources.AimedAt;
            PickingForm form = new PickingForm();
            form.ShowDialog();
            //如果选取了点，而不是按下 ESC 取消选取
            if (form.SelectedPoint.HasValue)
            {
                //恢复到正常状态
                this.PickerState = ColorPickerState.Normal;
            }
            else
            {
                //如果放弃选取，则显示上一次选取的颜色
                if (this.SelectedColor.HasValue)
                {
                    this.ShowColor(this.SelectedColor.Value);
                }
            }
            this._timerCursorPoint.Enabled = false;
            this._btnPickingColor.Image = Resources.Collimation;
        }
        /// <summary>
        /// 显示指定的颜色信息，并指示是否设置为选取色
        /// </summary>
        /// <param name="color">颜色信息</param>
        /// <param name="selected">设定标识</param>
        public void ShowColor(Color color, Boolean selected = false)
        {
            var r = color.R;
            var g = color.G;

            var b = color.B;
            String hexFormat = "X2";
            this._tbRGBColor.Text = $"{r.ToString()},{g.ToString()},{b.ToString()}";
            this._tbHEXColor.Text = $"{r.ToString(hexFormat)}{g.ToString(hexFormat)}{b.ToString(hexFormat)}";
            this.DrawColorBoard(color);
            if (selected)
            {
                this.SelectedColor = color;
            }
        }

        private void _btnCollimationColor_Click(Object sender, EventArgs e)
        {
            this.PickingColor();
        }

        private void _btnCopyRGB_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this._tbRGBColor.Text);
        }

        private void _btnCopyHEX_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this._tbHEXColor.Text);
        }


        public void ShowColor(String colorStr, Boolean selected = false)
        {
            var color = this.ConvertToColor(colorStr);
            if (color.HasValue)
            {
                this.ShowColor(color.Value, selected);
            }
        }
        private Color? ConvertToColor(String colorText)
        {
            Color? color = null;
            if (String.IsNullOrWhiteSpace(colorText))
            {
                return color;
            }
            try
            {
                var result = this.ColorConverter.ConvertFromString(colorText);
                if (result != null)
                {
                    color = (Color)result;
                }
            }
            catch
            {

            }

            return color;
        }
        private void _tbRGBColor_TextChanged(Object sender, EventArgs e)
        {
            if (this.PickerState != ColorPickerState.Picking && this._tbRGBColor.Focused)
            {
                String colorText = this._tbRGBColor.Text.Trim();
                if (String.IsNullOrWhiteSpace(colorText)) return;
                if (Regex.IsMatch(colorText, "[\\d]{1,},[\\d]{1,},[\\d]{1,}"))
                {
                    this.ShowColor(colorText, true);
                }

            }
        }
        private void _tbHEXColor_TextChanged(Object sender, EventArgs e)
        {
            if (this.PickerState != ColorPickerState.Picking && this._tbHEXColor.Focused)
            {
                String colorText = this._tbHEXColor.Text.Trim();
                if (String.IsNullOrWhiteSpace(colorText)) return;
                colorText = colorText.TrimStart('#');
                if (Regex.IsMatch(colorText, "[0-9a-fA-F]{6}"))
                {
                    this.ShowColor("#" + colorText, true);
                }
            }
        }

        private void SelectedFixedColor(Object sender, EventArgs e)
        {
            var control = sender as Control;
            if (control != null)
            {
                this.ShowColor(control.BackColor, true);
            }
        }

        private void _btnTop_Click(object sender, EventArgs e)
        {
            switch (this.PickerState)
            {
                case ColorPickerState.Normal:
                    {
                        this.TopMost = true;
                        this.PickerState = ColorPickerState.Top;
                        this._btnTop.Image = Resources.Pin;
                    }
                    break;
                case ColorPickerState.Top:
                    {
                        this.TopMost = false;
                        this.PickerState = ColorPickerState.Normal;
                        this._btnTop.Image = Resources.NoPin;
                    }
                    break;
            }

        }
    }
}
