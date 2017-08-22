using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillenniumLove
{
    public class Md5Config
    {
        /// <summary>
        /// 傳入mask的前置詞
        /// </summary>
        public static string InPreFix
        {
            get
            {
                return Config.Application.Get("Mask", "InPreFix", "h2u");
            }
        }

        /// <summary>
        /// 傳入mask的後置詞
        /// </summary>
        public static string InPostFix
        {
            get
            {
                return Config.Application.Get("Mask", "InPostFix", "iHealth");
            }
        }

        /// <summary>
        /// 回傳Mask的前置詞
        /// </summary>
        public static string OutPreFix
        {
            get
            {
                return Config.Application.Get("Mask", "OutPreFix", "love");
            }
        }
        /// <summary>
        /// 回傳Mask的後置詞
        /// </summary>
        public static string OutPostFix
        {
            get
            {
                return Config.Application.Get("Mask", "OutPostFix", "iHealth");
            }
        }
    }
}
