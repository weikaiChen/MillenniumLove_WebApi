using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MillenniumLove;
using MillenniumLove.Models;
using MillenniumLove.Service;
using System.Collections.Generic;
namespace MillenniumLove_WebApi.Tests
{
    [TestClass]
    public class UnitTestAesUtility
    {
        [TestMethod]
        public void EncryptAndDecrypt()
        {

            var inputList = new List<string>();
            inputList.Add("test123456789");
            inputList.Add("abcdefg");
            inputList.Add(Guid.NewGuid().ToString("N") + DateTime.Now.ToString("yyyyMMddhhmmss"));
            inputList.Add(Guid.NewGuid().ToString("N") + DateTime.Now.ToString("yyyyMMddhhmmss"));


            foreach (var item in inputList)
            {
                var encrypt = AesUtility.Encrypt(item);
                var decrypt = AesUtility.Decrypt(encrypt);
                var actual = item;
                var expected = decrypt;
                Assert.AreEqual(expected, actual);
            }

        }
    }
}
