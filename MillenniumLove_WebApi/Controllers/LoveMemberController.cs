using System;
using System.Web.Http;
using MillenniumLove.Service;
using MillenniumLove;
using Newtonsoft.Json;
using MillenniumLove.Models;

namespace MillenniumLove_WebApi.Controllers
{
    /// <summary>
    /// 使用者基本資料
    /// </summary>
    public class LoveMemberController : ApiController
    {
        /// <summary>
        /// OP取得登入資訊
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public string QueryByOpMid(string v)
        {

            ApiResult apiResult;
            var jsonStr = "";
            var decrypt = AesUtility.Decrypt(v);

            try
            {
                var model = decrypt.FromJson<OpMidModel.Input>();

                var service = new LoveMemberService();

                apiResult = service.Execute(model);

                jsonStr = JsonConvert.SerializeObject(apiResult);
                jsonStr = jsonStr.AesEncrypt();
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


        /// <summary>
        /// 卡號取得登入資訊
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public string QueryByIcash(string v)
        {
            throw new NotImplementedException();
        }
    }
}
