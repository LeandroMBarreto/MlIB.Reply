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
        //O:has error
        //O:default value
        //O:null error details
        [TestMethod]
        public void Reply_Error_default_none()
        {
            var result = M.Reply.Error<int>();

            Assert.IsTrue(result.HasError, "WHY NO ERROR??"); //O:has error
            Assert.IsFalse(result.HasErrorMessage, "WHY HAVE MSG??");  //O:null error details
            Assert.AreEqual(null, result.ErrorMessage, "WHY NOT NULL MSG??");  //O:null error details
            Assert.AreEqual(default(int), result.Value, "WHY NO DEFAULT VALUE??"); //O:default value
        }

        //I:valid value
        //O:has error
        //O:passed value
        //O:null error details
        [TestMethod]
        public void Reply_Error_default_value_valid()
        {
            var result = M.Reply.Error(-1);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");  //O:has error
            Assert.IsFalse(result.HasErrorMessage, "WHY HAVE MSG??");  //O:null error details
            Assert.AreEqual(null, result.ErrorMessage, "WHY NOT NULL MSG??");  //O:null error details
            Assert.AreEqual(-1, result.Value, "WHY NO EXPECTED VALUE??");  //O:passed value
        }

    }
}
