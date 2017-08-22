using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MillenniumLove.Models;
using MillenniumLove;
namespace MillenniumLove_WebApi.Tests
{
    [TestClass]
    public class BaseModelTests
    {
        [TestMethod]
        public void IsValidTest()
        {

            GetTokenModel.Input model1 = new GetTokenModel.Input();
            var result1 = model1.IsValid<GetTokenModel.Ouput>();
            var expected = EnumItem.Get(Ref.ErrorCode._002).FinalValue;
            var actual = result1.ErrorCode;
            Assert.AreEqual(expected, actual);

            GetTokenModel.Input model2 = new GetTokenModel.Input();

            model2.CallTime = DateTime.Now.ToString("yyyyMMddhhmmss");
            model2.MachineID = "machineA";
            model2.Mask = model1.GetInMask();
            model2.CallTime = DateTime.Now.ToString("yyyyMMddhhmmss");
            var result2 = model2.IsValid<GetTokenModel.Ouput>();
            var exp = EnumItem.Get(Ref.ErrorCode._001).FinalValue;
            var act = result2.ErrorCode;

            Assert.AreEqual(exp, act);

        }
    }
}
