using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillenniumLove
{
    public static class Extender
    {
        public static bool NullOrEmpty(this string str)
        {
            return null == str || string.IsNullOrEmpty(str);
        }

    }
}
