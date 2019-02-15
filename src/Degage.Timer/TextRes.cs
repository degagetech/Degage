using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.Timer
{
    public static class TextRes
    {
        public static String GetString(String name)
        {
            return TextResource.ResourceManager.GetString(name);
        }
    }
}
