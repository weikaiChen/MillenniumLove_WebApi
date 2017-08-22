using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillenniumLove.Service
{
    public  class BaseUnit
    {
        protected const string SystemUser = "ServiceUser";

        protected static string GetUserName(string cardNo, string opMid)
        {
            string userName = SystemUser;

            if (!opMid.NullOrEmpty())
            {
                return opMid;
            }

            if (!cardNo.NullOrEmpty())
            {
                return opMid;
            }

            return userName;
        }

    }
}
