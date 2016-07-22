using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MlIB.Reply.Tests.Unit.Features
{
    [TestClass]
    public class Reply_Error_exception
    {

        //public static IReplyEx<TReturn> Error<TReturn>(Exception ex, string errorMessage = null, TReturn value = default(TReturn))

        //I:null
        //O:has error
        //O:default value
        //O:null error details
        [TestMethod]
        public void Reply_Error_exception_null()
        {
            Exception nullEx = null;
            var result = M.Reply.Error<int>(nullEx);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");  //O:has error
            Assert.AreEqual(default(int), result.Value, "WHY NO DEFAULT VALUE??");  //O:default value
            Assert.AreEqual(null, result.Exception);  //O:null error details

            Assert.IsFalse(result.HasErrorMessage, "WHY HAVE MSG??");  //O:null error details
            Assert.AreEqual(null, result.ErrorMessage, "WHY NOT NULL MSG??");  //O:null error details
        }

        //I:valid
        //O:has error
        //O:default value
        //O:error details exception
        //O:exception msg for msg
        [TestMethod]
        public void Reply_Error_exception_valid()
        {
            var result = M.Reply.Error<int>(Stubs.Common.EXCEPTION);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");  //O:has error
            Assert.AreEqual(default(int), result.Value, "WHY NO DEFAULT VALUE??");  //O:default value
            Assert.AreEqual(Stubs.Common.EXCEPTION, result.Exception);  //O:error details exception

            Assert.IsTrue(result.HasErrorMessage, "WHY NO MSG??");     //O:exception msg for msg
            Assert.AreEqual(Stubs.Common.EXCEPTION.Message, result.ErrorMessage, "WHY NOT EXPECTED MSG??");     //O:exception msg for msg
        }

        //I:null, valid
        //O:has error
        //O:default value
        //O:error details exception
        //O:expected error msg
        [TestMethod]
        public void Reply_Error_exception_null_message_valid()
        {
            var result = M.Reply.Error<int>(Stubs.Common.EXCEPTION, Stubs.Common.MSG_ErrorFound);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");  //O:has error
            Assert.AreEqual(default(int), result.Value, "WHY NO DEFAULT VALUE??");  //O:default value
            Assert.AreEqual(Stubs.Common.EXCEPTION, result.Exception);  //O:error details exception

            Assert.IsTrue(result.HasErrorMessage, "WHY NO MSG??");     //O:exception msg for msg
            Assert.AreEqual(Stubs.Common.MSG_ErrorFound, result.ErrorMessage, "WHY NOT EXPECTED MSG??");     //O:exception msg for msg
        }

        //I:valid, valid
        //O:

        //I:null, empty
        //O:

        //I:valid, empty
        //O:

        //I:null, valid, valid
        //O:

        //I:valid, valid, valid
        //O:

        //I:null, empty, valid
        //O:

        //I:valid, empty, valid
        //O:

        //I:null, valid, valid exception
        //O:

        //I:valid, valid, valid exception
        //O:

        //I:null, empty, valid exception
        //O:

        //I:valid, empty, valid exception
        //O:

    }
}
