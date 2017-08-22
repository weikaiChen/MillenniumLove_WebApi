using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MillenniumLove.Models;
namespace MillenniumLove.Service
{
    public interface IService
    {
        ApiResult Execute(BaseModel model);
    }
}
