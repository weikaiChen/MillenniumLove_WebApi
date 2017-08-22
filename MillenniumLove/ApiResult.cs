using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
namespace MillenniumLove
{
    public class ApiResult
    {
        public string RequestID { get; set; }
        public string ErrorCode { get; set; } = "000";
        public string ErrorMessage { get; set; }

    }




    public class ApiResult<T> : ApiResult
    {
        public T Data { get; set; }
        public ApiResult() : base()
        {
            if (
                typeof(T).Is<IDynamicMetaObjectProvider>())
            {
                dynamic d = new ExpandoObject();
                this.Data = d;
            }
            else
            {
                this.Data = default(T);
            }
        }


    }
}
