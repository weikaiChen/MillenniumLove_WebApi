using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using MillenniumLove.Models;
using Newtonsoft.Json;
using MillenniumLove_WebApi.Controllers;
using MillenniumLove;

namespace MillenniumLove_WebApi.Test
{
    [TestClass]
    public class SecurityControllerTests
    {
        [TestMethod]
        public void GetTokenTest()
        {
            var v = "";

            var models = new GetTokenModel.Input();
            models.OpMid = "aaaa1bbbb2cccc3dddd4eeee5ffff6ee";
            models.CardNo = "7413159981000227";
            models.CallTime = DateTime.Now.ToString("yyyyMMddhhmmss");
            models.MachineID = "Machine0001";
            models.Mask = models.GetInMask();

            v = JsonConvert.SerializeObject(models);

            var controller = new SecurityController();

            var result = controller.GetToken(AesUtility.Encrypt(v));
            result = result.AesDecrypt();

            var resultObj = result.FromJson<ApiResult>();
            if (resultObj.ErrorCode == "000")
            {
                Assert.IsTrue(true, "errorCode為000");
            }

            Assert.IsFalse(true, resultObj.ErrorMessage);
        }
    }
}
