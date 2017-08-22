using System;
using System.Web.Http;
using MillenniumLove.Service;
using MillenniumLove;
using Newtonsoft.Json;
using MillenniumLove.Models;

namespace MillenniumLove_WebApi.Controllers
{
   
    public abstract class BaseController: ApiController
    {
        public string ReturnJsonString(ApiResult result)
        {
            var jsonStr = "";
            jsonStr = JsonConvert.SerializeObject(result);
            jsonStr = jsonStr.AesEncrypt();
            return jsonStr;
        }
    }
}