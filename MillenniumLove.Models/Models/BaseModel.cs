using System.Reflection;
using MillenniumLove;


namespace MillenniumLove.Models
{
    public abstract class BaseModel:IModel
    {
        public string CallTime { get; set; }
        public string MachineID { get; set; }
        [MaskIgnore]
        public string Mask { get; set; }
        

        public string GetOutMask()
        {
            string mask = "";

            mask = GetAllValue();
            mask = Md5Config.OutPreFix + mask + Md5Config.OutPostFix;
            mask = Md5Utility.Encrypt32(mask);

            return mask;
        }

        public string GetInMask()
        {
            string mask = "";

            mask = GetAllValue();
            mask = Md5Config.InPreFix + mask + Md5Config.InPostFix;
            mask= Md5Utility.Encrypt32(mask);
            return mask;
        }


        public ApiResult<T> IsValid<T>()
        {
            var result = new ApiResult<T>();
            //必要參數不足
            if (this.CallTime.NullOrEmpty()
                || this.MachineID.NullOrEmpty()
                || this.Mask.NullOrEmpty())
            {
                var item=EnumItem.Get(Ref.ErrorCode._002);
                result.ErrorCode = item.FinalValue;
                result.ErrorMessage = item.Description;
                return result;
            }

            var mask = this.GetInMask();
            //mask不符 
            if (mask != this.Mask)
            {
                var item = EnumItem.Get(Ref.ErrorCode._001);
                result.ErrorCode = item.FinalValue;
                result.ErrorMessage = item.Description;
                return result;
            }
            
            return result;
        }
        #region private

        private string GetAllValue()
        {
            var allValue = "";

            var inf = this.GetType().GetProperties();
            foreach (PropertyInfo member in inf)
            {
                var attr = member.GetCustomAttribute(typeof(MaskIgnoreAttribute));
                if (attr != null)
                {
                    continue;
                }
                var obj = member.GetValue(this, null);
                if (obj != null)
                {
                    allValue = allValue + obj.ToString();
                }
            }

            return allValue;
        }
        #endregion

    }
}
