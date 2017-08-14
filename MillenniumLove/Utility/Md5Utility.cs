using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MillenniumLove
{
    public class Md5Utility
    {
        public static string Encrypt16(string source)
        {
            var transferSource = Md5Config.PreFix + source + Md5Config.PostFix;
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string encryptContent = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(transferSource)), 4, 8);
            var test= BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(transferSource)));
            encryptContent = encryptContent.Replace("-", "");
            return encryptContent;
        }


        public static string Encrypt32(string source)
        {
            var transferSource = Md5Config.PreFix + source + Md5Config.PostFix;

            try
            {    
                MD5 md5 = MD5.Create();

                //注意編碼UTF8/Unicode等的選擇
                byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(transferSource));
                for (int i = 0; i < s.Length; i++)
                {
                    // 得到的字串是16進制格式。格式化后的字串是小寫，如果用(X)則大寫
                    transferSource = transferSource + s[i].ToString("X");
                }
            }
            catch (Exception ex)
            {
                LogRecord
                    .Create("Encrypt32加密")
                    .SetMessage(ex.Message)
                    .Error();
            }
           
            return transferSource;
        }


    }
}
