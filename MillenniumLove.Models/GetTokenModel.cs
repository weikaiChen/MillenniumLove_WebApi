using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace MillenniumLove.Models
{
    public class GetTokenModel
    {
        public string OpMid { get; set; }
        public string CardNo { get; set; }
        public string CallTime { get; set; }
        public string MachineID { get; set; }
        public string Mask { get; set; }

        public Boolean isValid()
        {
            if (this.CallTime.NullOrEmpty()
               || this.MachineID.NullOrEmpty()
               || this.Mask.NullOrEmpty())
            {
                return false;
            }

            return true;
        }

        public string GetMask()
        {
            var all = this.OpMid + this.CardNo + this.CallTime + this.MachineID;
            var selfMask = Md5Utility.Encrypt16(all);

            return selfMask;

        }

        public void SetMask()
        {
            var all = this.OpMid + this.CardNo + this.CallTime + this.MachineID;
            var selfMask = Md5Utility.Encrypt16(all);

            this.Mask=selfMask;
        }

    }
}
