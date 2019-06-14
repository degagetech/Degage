using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkPerformance
{
    public class PenetrablePanel : Panel
    {
        [Description("开启鼠标穿透")]
        public Boolean EnabledMousePierce { get; set; } = false;
        protected override void WndProc(ref Message m)
        {
            if (!this.DesignMode && this.EnabledMousePierce)
            {
                switch (m.Msg)
                {
                    case WinMessageConstants.WM_MOUSEACTIVATE:
                    case WinMessageConstants.WM_MOUSEFIRST:
                    case WinMessageConstants.WM_MOUSEHOVER:
                    case WinMessageConstants.WM_MOUSELAST:
                    case WinMessageConstants.WM_MOUSELEAVE:
                    case WinMessageConstants.WM_LBUTTONDOWN:
                    case WinMessageConstants.WM_LBUTTONUP:
                    case WinMessageConstants.WM_LBUTTONDBLCLK:
                    case WinMessageConstants.WM_RBUTTONDOWN:
                    case WinMessageConstants.WM_RBUTTONUP:
                    case WinMessageConstants.WM_RBUTTONDBLCLK:
                    case WinMessageConstants.WM_MBUTTONDOWN:
                    case WinMessageConstants.WM_MBUTTONUP:
                    case WinMessageConstants.WM_MBUTTONDBLCLK:
                    case WinMessageConstants.WM_NCHITTEST:
                        {
                            //将返回值置为 -1 表示交由父控件处理
                            m.Result = (IntPtr)(-1);
                        }
                        break;
                    default:
                        {
                            base.WndProc(ref m);
                        }
                        break;
                }
            }
            else
            {
                base.WndProc(ref m);
            }
        }
    }
}
