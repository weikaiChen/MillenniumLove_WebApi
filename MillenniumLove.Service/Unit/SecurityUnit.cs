using System;
using System.Data.Entity;
using MillenniumLove.Dao;
using MillenniumLove.Models;

namespace MillenniumLove.Service
{
    public class SecurityUnit : BaseUnit
    {

        /// <summary>
        /// 儲存token進資料表
        /// </summary>
        /// <param name="cardNo"></param>
        /// <param name="opMid"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static ApiResult<string> TokenSave(GetTokenModel.Input model, string token)
        {
            var entity = new Entities();
            var tokenRecord = new Token_Record();
            tokenRecord.Token_Machine_ID = model.MachineID;
           // tokenRecord.Token_Function_ID;
            tokenRecord.Token = token;

            tokenRecord.Token_Create_User = SystemUser;
            tokenRecord.Token_Update_User = SystemUser;
            tokenRecord.Token_Create_Date = DateTime.Now;
            tokenRecord.Token_Update_Date = DateTime.Now;
            tokenRecord.Token_StartDate = DateTime.Now;
            tokenRecord.Token_ExpireDate = GetTokenExpireDate(tokenRecord.Token_StartDate, AesConfig.Duration);

            using (var db = new Entities())
            {
                db.Token_Record.Add(tokenRecord);
                db.Entry(tokenRecord).State = EntityState.Added;
                var result = db.SaveChanges();
            }
            return new ApiResult<string>();
        }

        private static DateTime GetTokenExpireDate(DateTime startDate,string strDur)
        {
            var duration = 5000;
            var expireDate = DateTime.Now;
            if (int.TryParse(strDur, out duration))
            {
                duration = duration / 1000;
                expireDate = startDate.AddSeconds(duration);
            }

            return expireDate;
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
        public static ApiResult Valid(string token)
        {
            var result = new ApiResult();


            return result;
        }
    }
}
