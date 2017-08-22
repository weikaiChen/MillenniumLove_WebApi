using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillenniumLove
{
    public class AesConfig
    {
        public static string Key
        {
            get {

                return Config.Application.Get("Token","Key", "MillenniumLovelyMillenniumLovely");
            }
        }

        public static string IV
        {
            get
            {
                return Config.Application.Get("Token", "IV", "MillenniumLoveIV");
            }
        }

        public static string Duration
        {
            get
            {
                return Config.Application.Get("Token", "Duration", "5000");
            }
        }
    }
}
