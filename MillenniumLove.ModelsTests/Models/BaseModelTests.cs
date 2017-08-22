using Microsoft.VisualStudio.TestTools.UnitTesting;
using MillenniumLove.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MillenniumLove;
namespace MillenniumLove.Models.Tests
{
    [TestClass()]
    public class BaseModelTests
    {
      
        [TestMethod()]
        public void IsValidTest()
        {

            GetTokenModel model1 = new GetTokenModel();
            var result1 = model1.IsValid<ApiResult>();
            var expected = EnumItem.Get(Ref.ErrorCode._002).FinalValue;
            var actual = result1.ErrorCode;
            Assert.AreEqual(expected, actual);
        }
    }
}