using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace Degage.Concision.Windows
{
    public class Direct2DGraphics : IDeviceContext, IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IntPtr GetHdc()
        {
            throw new NotImplementedException();
        }

        public void ReleaseHdc()
        {
            throw new NotImplementedException();
        }
    }
}
