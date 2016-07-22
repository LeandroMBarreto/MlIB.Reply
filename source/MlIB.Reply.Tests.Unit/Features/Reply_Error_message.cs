using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MlIB.Reply.Tests.Unit.Features
{
    [TestClass]
    public class Reply_Error_message
    {

        //public static IReplyMsg<TReturn> Error<TReturn>(string errorMessage, TReturn value = default(TReturn))

        //I:null
        //O:
        [TestMethod]
        public void Reply_Error_message_null()
        {
            string nullMsg = null;
            var result = M.Reply.Error<int>(nullMsg);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");
            Assert.IsFalse(result.HasErrorMessage, "WHY HAVE MSG??");
            Assert.AreEqual(null, result.ErrorMessage, "WHY NOT NULL MSG??");
            Assert.AreEqual(default(int), result.Value, "WHY NO DEFAULT VALUE??");
        }

        //I:empty
        //O:
        [TestMethod]
        public void Reply_Error_message_empty()
        {
            var result = M.Reply.Error<int>("");

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");
            Assert.IsFalse(result.HasErrorMessage, "WHY HAVE MSG??");
            Assert.AreEqual(string.Empty, result.ErrorMessage, "WHY NOT EMPTY MSG??");
            Assert.AreEqual(default(int), result.Value, "WHY NO DEFAULT VALUE??");
        }

        //I:valid
        //O:

        //I:null, valid
        //O:

        //I:valid, valid
        //O:

        //I:empty, valid
        //O:

        //I:null, valid exception
        //O:

        //I:valid, valid exception
        //O:

        //I:empty, valid exception
        //O:

    }
}
