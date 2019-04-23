using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Degage.Timers
{
    public static class TextRes
    {
        public static String GetString(String name)
        {
            String text = null;
            if (!String.IsNullOrEmpty(name))
            {
                text = TextResource.ResourceManager.GetString(name);
            }
            return text;
        }
    }
}
