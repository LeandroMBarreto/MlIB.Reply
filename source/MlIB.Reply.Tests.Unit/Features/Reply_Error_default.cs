using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MlIB.Reply.Tests.Unit.Stubs;

namespace MlIB.Reply.Tests.Unit.Features
{
    [TestClass]
    public class Reply_Error_default
    {

        //public static IReplyEx<TReturn> Error<TReturn>(TReturn value = default(TReturn))

        //I:none
        //O:
        [TestMethod]
        public void Reply_Error_default_none()
        {
            var result = M.Reply.Error<int>();

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");
            Assert.IsFalse(result.HasErrorMessage, "WHY HAVE MSG??");
            Assert.AreEqual(null, result.ErrorMessage, "WHY NOT NULL MSG??");
            Assert.AreEqual(default(int), result.Value, "WHY NO DEFAULT VALUE??");
        }

        //I:valid
        //O:
        [TestMethod]
        public void Reply_Error_default_value_valid()
        {
            var result = M.Reply.Error(-1);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");
            Assert.IsFalse(result.HasErrorMessage, "WHY HAVE MSG??");
            Assert.AreEqual(null, result.ErrorMessage, "WHY NOT NULL MSG??");
            Assert.AreEqual(-1, result.Value, "WHY NO EXPECTED VALUE??");
        }

    }
}
