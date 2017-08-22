using System;
using System.Web.Http;
using MillenniumLove.Service;
using MillenniumLove;
using Newtonsoft.Json;
using MillenniumLove.Models;

namespace MillenniumLove_WebApi.Controllers
{
    [LogFilter]
    public class SecurityController : BaseController
    {
        [HttpPost]
        public string GetToken(string v)
        {

            ApiResult apiResult;
            var jsonStr = "";
            var decrypt = AesUtility.Decrypt(v);

            try
            {
                var model = decrypt.FromJson<GetTokenModel.Input>();
                var checkResult = model.IsValid<string>();
                if (checkResult.ErrorCode != EnumItem.Get(Ref.ErrorCode._000).FinalValue)
                {
                    jsonStr = ReturnJsonString(checkResult);
                    return jsonStr;
                }
                var service = new SecurityService();

                apiResult = service.Execute(model);

                jsonStr = ReturnJsonString(apiResult);
            }
            catch (Exception ex)
            {
                LogRecord.Create()
                    .SetMessage(ex.Message)
                    .Error()
                    ;
            }

            return jsonStr;
        }
    }
}
