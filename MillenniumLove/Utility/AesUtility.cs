using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace MillenniumLove
{
    public class AesUtility
    {

        /// <summary>
        /// AES256加密
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string Encrypt(string source)
        {
            LogRecord
                  .Create("Encrypt32加密")
                  .SetMessage("test")
                  .Debug();

            StringBuilder sb = new StringBuilder();

            var strKey = AesConfig.Key;
            var strIv = AesConfig.IV;

            byte[] key = Encoding.UTF8.GetBytes(strKey);
            byte[] iv = Encoding.UTF8.GetBytes(strIv);

            byte[] dataByteArray = Encoding.UTF8.GetBytes(source);

            string encrypt = "";

            try
            {
                using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
                {
                    aes.KeySize = key.Length * 8; //key長度 byte*8=bit
                    aes.BlockSize = iv.Length * 8;//iv長度 

                    aes.Key = key;
                    aes.IV = iv;

                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(dataByteArray, 0, dataByteArray.Length);
                            cs.FlushFinalBlock();

                            foreach (byte b in ms.ToArray())
                            {
                                sb.AppendFormat("{0:X2}", b);
                            }
                            encrypt = sb.ToString();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                LogRecord
                   .Create("AesUtility.Encrypt")
                   .SetMessage(ex.Message)
                   .Error();
            }
            
            return encrypt;
        }

        /// <summary>
        /// AES256解密
        /// </summary>
        /// <param name="encryptText"></param>
        /// <returns></returns>
        public static string Decrypt(string encryptText)
        {
            byte[] dataByteArray = new byte[encryptText.Length / 2];
            for (int x = 0; x < encryptText.Length / 2; x++)
            {
                int i = (Convert.ToInt32(encryptText.Substring(x * 2, 2), 16));
                dataByteArray[x] = (byte)i;
            }

            var strKey = AesConfig.Key;
            var strIv = AesConfig.IV;

            byte[] key = Encoding.UTF8.GetBytes(strKey);
            byte[] iv = Encoding.UTF8.GetBytes(strIv);

            var decrypt = "";
            try
            {
                using (AesCryptoServiceProvider des = new AesCryptoServiceProvider())
                {
                    des.KeySize = key.Length * 8; //key長度 byte*8=bit
                    des.BlockSize = iv.Length * 8;//iv長度 

                    des.Key = key;
                    des.IV = iv;

                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(dataByteArray, 0, dataByteArray.Length);
                            cs.FlushFinalBlock();
                            decrypt = Encoding.UTF8.GetString(ms.ToArray());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogRecord
                 .Create("AesUtility.Decrypt")
                 .SetMessage(ex.Message)
                 .Error();
            }
           
            return decrypt;
        }


    }
}
