using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MlIB.Reply.Tests.Unit.Features
{
    [TestClass]
    public class static_Reply_NoError
    {
        // UNIT UNDER TEST:
        //public static Reply<T> NoError<T>(T value)


        //I:value nullString
        //O:has no error
        //O:nullString as value
        [TestMethod]
        public void Reply_NoError_value_nullString()
        {
            var result = M.Reply.NoError<string>(null);

            Assert.IsFalse(result.HasError, "WHY HAS ERROR??");
            Assert.AreEqual(null, result.Value, "WHY NOT EXPECTED VALUE??");
        }

        //I:value emptyString
        //O:has no error
        //O:emptyString as value
        [TestMethod]
        public void Reply_NoError_value_emptyString()
        {
            var result = M.Reply.NoError(string.Empty);

            Assert.IsFalse(result.HasError, "WHY HAS ERROR??");
            Assert.AreEqual(string.Empty, result.Value, "WHY NOT EXPECTED VALUE??");
        }

        //I:value ok
        //O:has no error
        //O:expected value is set
        [TestMethod]
        public void Reply_NoError_value_ok()
        {
            var value = "ANY VALUE";

            var result = M.Reply.NoError(value);

            Assert.IsFalse(result.HasError, "WHY HAS ERROR??");
            Assert.AreEqual(value, result.Value, "WHY NOT EXPECTED VALUE??");
        }

        //I:value exception
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
