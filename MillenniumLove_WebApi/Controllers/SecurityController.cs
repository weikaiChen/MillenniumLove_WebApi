using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MillenniumLove.Service;
using MillenniumLove;
using Newtonsoft.Json;
using MillenniumLove.Models;  

namespace MillenniumLove_WebApi.Controllers
{
    public class SecurityController : ApiController
    {
        [HttpPost]
        public string GetToken(string v)
        {
            var apiResult = new ApiResult<String>();

            var decrypt = AesUtility.Decrypt(v);
            var cardNo = "";
            var opMid = "";
            var token = "";
            try
            {
                var model = decrypt.FromJson<GetTokenModel>();

                if (!model.isValid())
                {
                    apiResult.ErrorCode = "";
                    apiResult.ErrorMessage = "";
                }
                token = SecurityService.TokenGenerate();
                var result = SecurityService.TokenSave(cardNo, opMid, token);

                apiResult.ErrorCode = result.ErrorCode;
                apiResult.ErrorMessage = result.ErrorMessage;
                apiResult.Data = token;

                var jsonStr = JsonConvert.SerializeObject(apiResult);
            }
            catch (Exception ex)
            {

                throw;
            }
            
            return token;
        }
    }
}
