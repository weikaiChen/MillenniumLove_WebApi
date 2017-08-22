using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillenniumLove
{
    public static class EncryptExtender
    {
        public static string AesEncrypt(this string value)
        {
            var encrypt = AesUtility.Encrypt(value);

            return encrypt;
        }

        public static string AesDecrypt(this string value)
        {
            var encrypt = AesUtility.Decrypt(value);
            return encrypt;
        }
    }
}
