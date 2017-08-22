using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using MillenniumLove.Models;
using Newtonsoft.Json;

namespace MillenniumLove_WebApi.Tests
{
    [TestClass]
    public class ErrorSecurityControllerTests
    {
        HttpClientTool client = new HttpClientTool();

        [TestMethod()]
        public void  GetTokenTest()
        {

            var v = "";

            var models = new GetTokenModel();
            models.OpMid = "aaaa1bbbb2cccc3dddd4eeee5ffff6ee";
            models.CardNo = "7413159981000227";
            models.CallTime = DateTime.Now.ToString("yyyyMMddhhmmss");
            models.MachineID = "Machine0001";
            models.SetMask();

            var data = JsonConvert.SerializeObject(models);
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("v", data));


            var formContent = new FormUrlEncodedContent(postData);

            var result = client.Post("http://localhost:17805/api/Security/GetToken", formContent);
           //var result=client.p

            //client.BaseAddress = new Uri("http://localhost:17805/");

            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //HttpResponseMessage response = await client.PostAsync("api/Security/GetToken", formContent);
            //response.EnsureSuccessStatusCode();
        }
    }
}
