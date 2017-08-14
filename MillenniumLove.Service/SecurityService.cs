using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MillenniumLove;

namespace MillenniumLove.Service
{
    public class SecurityService
    {
        /// <summary>
        /// 儲存token進資料表
        /// </summary>
        /// <param name="cardNo"></param>
        /// <param name="opMid"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static ApiResult TokenSave(string cardNo, string opMid, string token)
        {
            //Todo:存入tokenTable
            throw new NotImplementedException();
        }

        /// <summary>
        /// 產生token
        /// </summary>
        /// <returns></returns>
        public static string TokenGenerate()
        {
            var guidCode = Guid.NewGuid();
            var token = guidCode.ToString("N") + DateTime.Now.ToString("yyyyMMddhhmmss");
            return token;
        }

        /// <summary>
        /// 驗證token是否有效
        /// </summary>
        /// <param name="cardNo"></param>
        /// <param name="opMid"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public ApiResult Valid(string token)
        {
            var result = new ApiResult();


            return result;
        }
    }
}
