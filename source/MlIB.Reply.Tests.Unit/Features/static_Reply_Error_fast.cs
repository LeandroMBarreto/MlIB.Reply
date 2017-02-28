using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MlIB.Reply.Tests.Unit.Stubs;

namespace MlIB.Reply.Tests.Unit.Features
{
    [TestClass]
    public class static_Reply_Error_fast
    {
        // UNIT UNDER TEST:
        //public static IReplyEx<TReturn> Error<TReturn>(TReturn value = default(TReturn))

        //I:none
        //O:has error
        //O:default value
        //O:null error details
        [TestMethod]
        public void Reply_Error_fast_default()
        {
            var result = M.Reply.Error<int>();

            Assert.IsTrue(result.HasError, "WHY NO ERROR??"); //O:has error
            Assert.AreEqual(default(int), result.Value, "WHY NO DEFAULT VALUE??"); //O:default value

            var convertedResult = result as M.IReplyMsg<int>;
            Assert.IsFalse(convertedResult.HasErrorMessage, "WHY HAVE MSG??");  //O:null error details
            Assert.AreEqual(null, convertedResult.ErrorMessage, "WHY NOT NULL MSG??");  //O:null error details
        }

        //I:valid value
        //O:has error
        //O:passed value
        //O:null error details
        [TestMethod]
        public void Reply_Error_fast_value_valid()
        {
            var result = M.Reply.Error(-1);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");  //O:has error
            Assert.AreEqual(-1, result.Value, "WHY NO EXPECTED VALUE??");  //O:passed value

            var convertedResult = result as M.IReplyMsg<int>;
            Assert.IsFalse(convertedResult.HasErrorMessage, "WHY HAVE MSG??");  //O:null error details
            Assert.AreEqual(null, convertedResult.ErrorMessage, "WHY NOT NULL MSG??");  //O:null error details
        }

    }
}
