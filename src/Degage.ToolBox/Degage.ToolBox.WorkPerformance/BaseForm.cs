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
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 因确认操作而执行的窗体关闭
        /// </summary>
        protected void ConfirmClose()
        {
            if (this.Modal)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.Close();
            }
        }
        /// <summary>
        /// 因取消操作而执行的窗体关闭
        /// </summary>
        protected void CancelClose()
        {
            if (this.Modal)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                this.Close();
            }
        }
        #region 窗体点击任意位置拖动
        private Point _currentMousePoint;
        private Boolean _isMoving = false;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (MouseButtons.Left == e.Button)
            {
                this._currentMousePoint = e.Location;
                this._isMoving = true;
            }
            base.OnMouseDown(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (this._isMoving)
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
            this._isMoving = false;
            base.OnMouseUp(e);
        }
        #endregion
    }
}
