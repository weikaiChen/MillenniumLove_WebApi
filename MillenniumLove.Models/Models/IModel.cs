using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillenniumLove.Models
{
    public interface IModel
    {

        ApiResult<T> IsValid<T>();
    }
}
