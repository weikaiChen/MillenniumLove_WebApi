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
        public class Input : BaseModel
        {

            public string OpMid { get; set; }
            public string CardNo { get; set; }
        }

        public class Ouput : BaseModel
        {
            public string Token { get; set; }
        }


    }
}
