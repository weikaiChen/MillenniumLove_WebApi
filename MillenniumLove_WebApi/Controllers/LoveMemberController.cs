using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using log4net;

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
            
            throw new NotImplementedException();
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
