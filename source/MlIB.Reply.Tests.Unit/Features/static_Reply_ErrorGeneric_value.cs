using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MlIB.Reply.Tests.Unit.Stubs;

namespace MlIB.Reply.Tests.Unit.Features
{
    [TestClass]
    public class static_Reply_ErrorGeneric_value
    {
        // UNIT UNDER TEST:
        // public static IReplyEx<TReturn> Error<TReturn>(TReturn value = default(TReturn))


        //I: value default
        //O: value default
        //O: HasError true
        //O: HasErrorMessage false
        //O: HasErrorCode false
        //O: HasException false
        [TestMethod]
        public void static_Reply_ErrorGeneric_value_default()
        {
            var result = M.Reply.ErrorGeneric<int>();

            Assert.IsTrue(result.HasError, "WHY NO ERROR??"); //O: HasError true
            Assert.AreEqual(default(int), result.Value, "WHY NOT DEFAULT VALUE??"); //O: value default

            var convertedResult = result as M.IReplyFull<int>;
            Assert.IsFalse(convertedResult.HasErrorMessage, "WHY HasErrorMessage??"); //O: HasErrorMessage false
            Assert.IsFalse(convertedResult.HasErrorCode, "WHY HasErrorCode??");       //O: HasErrorCode false
            Assert.IsFalse(convertedResult.HasException, "WHY HHasException??");      //O: HasException false
        }

        //I: value ok
        //O: value ok
        //O: HasError true
        //O: HasErrorMessage false
        //O: HasErrorCode false
        //O: HasException false
        [TestMethod]
        public void static_Reply_ErrorGeneric_value_ok()
        {
            var result = M.Reply.ErrorGeneric(-5);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");  //O: HasError true
            Assert.AreEqual(-5, result.Value, "WHY NOT EXPECTED VALUE??");    //O: value ok

            var convertedResult = result as M.IReplyFull<int>;
            Assert.IsFalse(convertedResult.HasErrorMessage, "WHY HasErrorMessage??"); //O: HasErrorMessage false
            Assert.IsFalse(convertedResult.HasErrorCode, "WHY HasErrorCode??");  //O: HasErrorCode false
            Assert.IsFalse(convertedResult.HasException, "WHY HHasException??");   //O: HasException false
        }

    }
}
