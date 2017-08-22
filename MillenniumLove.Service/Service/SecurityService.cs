using MillenniumLove.Models;

namespace MillenniumLove.Service
{
    public class SecurityService : BaseService,IService
    {
        public ApiResult Execute(BaseModel model)
        {
            var modelObj = (GetTokenModel.Input)model;
            var result = new ApiResult<string>();
            var token = "";
            token = SecurityUnit.TokenGenerate();
            result = SecurityUnit.TokenSave(modelObj, token);
            modelObj.Mask = modelObj.GetOutMask();
            return result;
        }



      
    }
}
