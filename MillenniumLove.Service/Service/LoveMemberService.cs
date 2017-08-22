using MillenniumLove.Models;

namespace MillenniumLove.Service
{
    public class LoveMemberService : BaseService, IService
    {

        public ApiResult Execute(BaseModel model)
        {
            var modelObj = (OpMidModel.Input)model;
            var result = new ApiResult<string>();


            return result;
        }
    }
}
