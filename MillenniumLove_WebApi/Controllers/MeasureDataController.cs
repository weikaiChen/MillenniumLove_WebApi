using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using log4net;
using MillenniumLove;
namespace MillenniumLove_WebApi.Controllers
{
    /// <summary>
    /// 量測資料
    /// </summary>
    public class MeasureDataController : ApiController
    {
      
        [HttpPost, ActionName("Save")]
        /// <summary>
        /// 儲存量測資料(單筆)
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public string Save(string v)
        {

            throw new NotImplementedException();
        }
        [HttpPost,ActionName("QueryList")]
        /// <summary>
        /// 查詢量測資料
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public string QueryList(string v)
        {
            throw new NotImplementedException();
        }
    }
}
