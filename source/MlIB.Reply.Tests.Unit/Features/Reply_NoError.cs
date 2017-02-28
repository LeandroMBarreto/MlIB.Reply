using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MlIB.Reply.Tests.Unit.Features
{
    [TestClass]
    public class Reply_NoError
    {
        // UNIT UNDER TEST:
        //public static Reply<T> NoError<T>(T value)

        //I:null value
        //O:has no error
        //O:null as value
        [TestMethod]
        public void Reply_NoError_value_null()
        {
            var result = M.Reply.NoError<string>(null);

            Assert.IsFalse(result.HasError, "WHY HAS ERROR??");
            Assert.AreEqual(null, result.Value, "WHY NOT EXPECTED VALUE??");
        }

        //I:valid value
        //O:has no error
        //O:expected valid value
        [TestMethod]
        public void Reply_NoError_value_valid()
        {
            var result = M.Reply.NoError(Stubs.Common.VAL_anyValue);

            Assert.IsFalse(result.HasError, "WHY HAS ERROR??");
            Assert.AreEqual(Stubs.Common.VAL_anyValue, result.Value, "WHY NOT EXPECTED VALUE??");
        }

        //I:valid exception value
        //O:has no error
        //O:exception as value
        [TestMethod]
        public void Reply_NoError_value_exception()
        {
            var result = M.Reply.NoError(Stubs.Common.EXCEPTION);

            Assert.IsFalse(result.HasError, "WHY HAS ERROR??");
            Assert.AreEqual(Stubs.Common.EXCEPTION, result.Value, "WHY NOT EXPECTED VALUE??");
        }

    }
}
