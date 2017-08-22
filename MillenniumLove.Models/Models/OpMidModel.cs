using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillenniumLove.Models
{
    public class OpMidModel
    {
        public class Input : BaseModel
        {
            public string OpMid { get; set; }



            //public override void SetMask()
            //{
            //    var all = this.OpMid + this.CallTime + this.MachineID + this.OpMid;
            //    var selfMask = Md5Utility.Encrypt32(all);

            //    this.Mask = selfMask;
            //}

            //public Boolean IsValid()
            //{
            //    var isValid = false;

            //    //var checkMask = this.GetMask();
            //    //if (checkMask != this.Mask)
            //    //{
            //    //    return false;
            //    //}
            //    return isValid;
            //}

        }


    }
}
