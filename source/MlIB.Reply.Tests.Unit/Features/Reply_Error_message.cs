using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MlIB.Reply.Tests.Unit.Features
{
    [TestClass]
    public class Reply_Error_message
    {

        //public static IReplyMsg<TReturn> Error<TReturn>(string errorMessage, TReturn value = default(TReturn))

        //I:null msg
        //O:has error
        //O:default value
        //O:null error details
        [TestMethod]
        public void Reply_Error_message_null()
        {
            string nullMsg = null;
            var result = M.Reply.Error<int>(nullMsg);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");  //O:has error
            Assert.IsFalse(result.HasErrorMessage, "WHY HAVE MSG??");  //O:null error details
            Assert.AreEqual(null, result.ErrorMessage, "WHY NOT NULL MSG??");  //O:null error details
            Assert.AreEqual(default(int), result.Value, "WHY NO DEFAULT VALUE??");  //O:default value
        }

        //I:empty msg
        //O:has error
        //O:default value
        //O:error detail valid empty msg
        [TestMethod]
        public void Reply_Error_message_empty()
        {
            var result = M.Reply.Error<int>("");

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");  //O:has error
            Assert.IsTrue(result.HasErrorMessage, "WHY NO MSG??");    //O:error detail valid empty msg
            Assert.AreEqual(string.Empty, result.ErrorMessage, "WHY NOT EMPTY MSG??");    //O:error detail valid empty msg
            Assert.AreEqual(default(int), result.Value, "WHY NO DEFAULT VALUE??");  //O:default value
        }

        //I:valid msg
        //O:has error
        //O:default value
        //O:error detail valid msg
        [TestMethod]
        public void Reply_Error_message_valid()
        {
            var result = M.Reply.Error<int>(Stubs.Common.MSG_ErrorFound);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??"); //O:has error
            Assert.IsTrue(result.HasErrorMessage, "WHY NO MSG??");  //O:error detail valid msg
            Assert.AreEqual(Stubs.Common.MSG_ErrorFound, result.ErrorMessage, "WHY NOT EXPECTED MSG??");  //O:error detail valid msg
            Assert.AreEqual(default(int), result.Value, "WHY NO DEFAULT VALUE??");  //O:default value
        }

        //I:null msg, valid value
        //O:has error
        //O:expected value
        //O:null error details
        [TestMethod]
        public void Reply_Error_message_null_value_valid()
        {
            string nullMsg = null;
            var result = M.Reply.Error(nullMsg, Stubs.Common.VAL_anyValue);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??"); //O:has error
            Assert.IsFalse(result.HasErrorMessage, "WHY HAVE MSG??");  //O:null error details
            Assert.AreEqual(null, result.ErrorMessage, "WHY NOT NULL MSG??");  //O:null error details
            Assert.AreEqual(Stubs.Common.VAL_anyValue, result.Value, "WHY NOT EXPECTED VALUE??"); //O:expected value
        }

        //I:valid, valid
        //O:has error
        //O:expected value
        //O:error detail valid msg
        [TestMethod]
        public void Reply_Error_message_valid_value_valid()
        {
            var result = M.Reply.Error(Stubs.Common.MSG_ErrorFound, Stubs.Common.VAL_anyValue);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??"); //O:has error
            Assert.IsTrue(result.HasErrorMessage, "WHY NO MSG??");  //O:error detail valid msg
            Assert.AreEqual(Stubs.Common.MSG_ErrorFound, result.ErrorMessage, "WHY NOT EXPECTED MSG??");  //O:error detail valid msg
            Assert.AreEqual(Stubs.Common.VAL_anyValue, result.Value, "WHY NOT EXPECTED VALUE??"); //O:expected value
        }

        //I:empty, valid
        //O:has error
        //O:expected value
        //O:error detail valid empty msg
        [TestMethod]
        public void Reply_Error_message_empty_value_valid()
        {
            var result = M.Reply.Error("", Stubs.Common.VAL_anyValue);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??"); //O:has error
            Assert.IsTrue(result.HasErrorMessage, "WHY NO MSG??");    //O:error detail valid empty msg
            Assert.AreEqual(string.Empty, result.ErrorMessage, "WHY NOT EMPTY MSG??");    //O:error detail valid empty msg
            Assert.AreEqual(Stubs.Common.VAL_anyValue, result.Value, "WHY NOT EXPECTED VALUE??"); //O:expected value
        }

        //I:null, valid exception
        //O:has error
        //O:expected value
        //O:null error details
        //O:dont have exception
        [TestMethod]
        public void Reply_Error_message_null_value_valid_whenException()
        {
            string nullMsg = null;
            var result = M.Reply.Error(nullMsg, Stubs.Common.EXCEPTION);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??"); //O:has error
            Assert.IsFalse(result.HasErrorMessage, "WHY HAVE MSG??");  //O:null error details
            Assert.AreEqual(null, result.ErrorMessage, "WHY NOT NULL MSG??");  //O:null error details
            Assert.AreEqual(Stubs.Common.EXCEPTION, result.Value, "WHY NOT EXPECTED VALUE??"); //O:expected value

            Assert.IsFalse(
                ((M.IReplyEx<InvalidOperationException>)result).HasException
                , "WHY HAS EXCEPTION??"); //O:dont have exception
        }

        //I:empty, valid exception
        //O:has error
        //O:expected value
        //O:error detail valid empty msg
        //O:dont have exception
        [TestMethod]
        public void Reply_Error_message_empty_value_valid_whenException()
        {
            var result = M.Reply.Error("", Stubs.Common.EXCEPTION);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??"); //O:has error
            Assert.IsTrue(result.HasErrorMessage, "WHY NO MSG??");    //O:error detail valid empty msg
            Assert.AreEqual(string.Empty, result.ErrorMessage, "WHY NOT EMPTY MSG??");    //O:error detail valid empty msg
            Assert.AreEqual(Stubs.Common.EXCEPTION, result.Value, "WHY NOT EXPECTED VALUE??"); //O:expected value

            Assert.IsFalse(
                ((M.IReplyEx<InvalidOperationException>)result).HasException
                , "WHY HAS EXCEPTION??"); //O:dont have exception
        }

        //I:valid, valid exception
        //O:has error
        //O:expected value
        //O:error detail valid empty msg
        //O:dont have exception
        [TestMethod]
        public void Reply_Error_message_valid_value_valid_whenException()
        {
            var result = M.Reply.Error(Stubs.Common.MSG_ErrorFound, Stubs.Common.EXCEPTION);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??"); //O:has error
            Assert.IsTrue(result.HasErrorMessage, "WHY NO MSG??");  //O:error detail valid msg
            Assert.AreEqual(Stubs.Common.MSG_ErrorFound, result.ErrorMessage, "WHY NOT EXPECTED MSG??");  //O:error detail valid msg
            Assert.AreEqual(Stubs.Common.EXCEPTION, result.Value, "WHY NOT EXPECTED VALUE??"); //O:expected value

            Assert.IsFalse(
                ((M.IReplyEx<InvalidOperationException>)result).HasException
                , "WHY HAS EXCEPTION??"); //O:dont have exception
        }

    }
}
