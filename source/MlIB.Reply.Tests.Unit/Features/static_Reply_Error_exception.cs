using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MlIB.Reply.Tests.Unit.Features
{
    [TestClass]
    public class static_Reply_Error_exception
    {
        // UNIT UNDER TEST:
        //public static IReplyEx<TReturn> Error<TReturn>(Exception ex, string errorMessage = null, TReturn value = default(TReturn))

        /*
        //I:null exception
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

            Assert.IsFalse(result.HasException);     //O:null exception
            Assert.AreEqual(null, result.Exception);  //O:null error details

            Assert.IsFalse(result.HasErrorMessage, "WHY HAVE MSG??");  //O:null error details
            Assert.AreEqual(null, result.ErrorMessage, "WHY NOT NULL MSG??");  //O:null error details
        }

        //I:valid exception
        //O:has error
        //O:default value
        //O:error details exception
        //O:msg null
        [TestMethod]
        public void Reply_Error_exception_valid()
        {
            var result = M.Reply.Error<int>(Stubs.Common.EXCEPTION);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");  //O:has error
            Assert.AreEqual(default(int), result.Value, "WHY NO DEFAULT VALUE??");  //O:default value

            Assert.IsTrue(result.HasException);     //O:expected exception
            Assert.AreEqual(Stubs.Common.EXCEPTION, result.Exception);  //O:error details exception

            Assert.IsFalse(result.HasErrorMessage, "WHY NO MSG??");         //O:msg null
        }

        //I:null exception, valid msg
        //O:has error
        //O:default value
        //O:null exception
        //O:expected error msg
        [TestMethod]
        public void Reply_Error_exception_null_message_valid()
        {
            Exception nullEx = null;
            var result = M.Reply.Error<int>(nullEx, Stubs.Common.MSG_ErrorFound);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");  //O:has error
            Assert.AreEqual(default(int), result.Value, "WHY NO DEFAULT VALUE??");  //O:default value

            Assert.IsFalse(result.HasException);     //O:null exception
            Assert.AreEqual(nullEx, result.Exception);   //O:null exception

            Assert.IsTrue(result.HasErrorMessage, "WHY NO MSG??");     //O:expected error msg
            Assert.AreEqual(Stubs.Common.MSG_ErrorFound, result.ErrorMessage, "WHY NOT EXPECTED MSG??");    //O:expected error msg
        }

        //I:null exception, empty msg
        //O:has error
        //O:default value
        //O:error details exception
        //O:expected error msg
        [TestMethod]
        public void Reply_Error_exception_null_message_empty()
        {
            Exception nullEx = null;
            var result = M.Reply.Error<int>(nullEx, "");

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");  //O:has error
            Assert.AreEqual(default(int), result.Value, "WHY NO DEFAULT VALUE??");  //O:default value

            Assert.IsFalse(result.HasException);     //O:null exception
            Assert.AreEqual(nullEx, result.Exception);   //O:null exception

            Assert.IsTrue(result.HasErrorMessage, "WHY NO MSG??");   //O:expected error msg
            Assert.AreEqual("", result.ErrorMessage, "WHY NOT EXPECTED MSG??");      //O:expected error msg
        }

        //I:valid exception, empty msg
        //O:has error
        //O:default value
        //O:error details exception
        //O:expected error msg
        [TestMethod]
        public void Reply_Error_exception_valid_message_empty()
        {
            var result = M.Reply.Error<int>(Stubs.Common.EXCEPTION, "");

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");  //O:has error
            Assert.AreEqual(default(int), result.Value, "WHY NO DEFAULT VALUE??");  //O:default value

            Assert.IsTrue(result.HasException);     //O:expected exception
            Assert.AreEqual(Stubs.Common.EXCEPTION, result.Exception);  //O:error details exception

            Assert.IsTrue(result.HasErrorMessage, "WHY NO MSG??");   //O:expected error msg
            Assert.AreEqual("", result.ErrorMessage, "WHY NOT EXPECTED MSG??");      //O:expected error msg
        }

        //I:valid exception, valid msg
        //O:has error
        //O:default value
        //O:error details exception
        //O:expected error msg
        [TestMethod]
        public void Reply_Error_exception_valid_message_valid()
        {
            var result = M.Reply.Error<int>(Stubs.Common.EXCEPTION, Stubs.Common.MSG_ErrorFound);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");  //O:has error
            Assert.AreEqual(default(int), result.Value, "WHY NO DEFAULT VALUE??");  //O:default value

            Assert.IsTrue(result.HasException);     //O:expected exception
            Assert.AreEqual(Stubs.Common.EXCEPTION, result.Exception);  //O:error details exception

            Assert.IsTrue(result.HasErrorMessage, "WHY NO MSG??");   //O:expected error msg
            Assert.AreEqual(Stubs.Common.MSG_ErrorFound, result.ErrorMessage, "WHY NOT EXPECTED MSG??");      //O:expected error msg
        }

        //I:null exception, valid msg, valid value
        //O:has error
        //O:expected value
        //O:null exception
        //O:expected error msg
        [TestMethod]
        public void Reply_Error_exception_null_message_valid_value_valid()
        {
            Exception nullEx = null;
            var result = M.Reply.Error(nullEx, Stubs.Common.MSG_ErrorFound, Stubs.Common.VAL_anyValue);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");  //O:has error
            Assert.AreEqual(Stubs.Common.VAL_anyValue, result.Value, "WHY NO DEFAULT VALUE??");   //O:expected value

            Assert.IsFalse(result.HasException);     //O:null exception
            Assert.AreEqual(nullEx, result.Exception);   //O:null exception

            Assert.IsTrue(result.HasErrorMessage, "WHY NO MSG??");     //O:expected error msg
            Assert.AreEqual(Stubs.Common.MSG_ErrorFound, result.ErrorMessage, "WHY NOT EXPECTED MSG??");    //O:expected error msg
        }

        //I:valid exception, valid msg, valid value
        //O:has error
        //O:expected value
        //O:expected exception
        //O:expected error msg
        [TestMethod]
        public void Reply_Error_exception_valid_message_valid_value_valid()
        {
            var result = M.Reply.Error(Stubs.Common.EXCEPTION, Stubs.Common.MSG_ErrorFound, Stubs.Common.VAL_anyValue);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");  //O:has error
            Assert.AreEqual(Stubs.Common.VAL_anyValue, result.Value, "WHY NO DEFAULT VALUE??");   //O:expected value

            Assert.IsTrue(result.HasException);     //O:expected exception
            Assert.AreEqual(Stubs.Common.EXCEPTION, result.Exception);    //O:expected exception

            Assert.IsTrue(result.HasErrorMessage, "WHY NO MSG??");     //O:expected error msg
            Assert.AreEqual(Stubs.Common.MSG_ErrorFound, result.ErrorMessage, "WHY NOT EXPECTED MSG??");    //O:expected error msg
        }

        //I:null exception, empty msg, valid value
        //O:has error
        //O:expected value
        //O:error details exception
        //O:expected error msg
        [TestMethod]
        public void Reply_Error_exception_null_message_empty_value_valid()
        {
            Exception nullEx = null;
            var result = M.Reply.Error(nullEx, "", Stubs.Common.VAL_anyValue);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");  //O:has error
            Assert.AreEqual(Stubs.Common.VAL_anyValue, result.Value, "WHY NO DEFAULT VALUE??");   //O:expected value

            Assert.IsFalse(result.HasException);     //O:null exception
            Assert.AreEqual(nullEx, result.Exception);   //O:null exception

            Assert.IsTrue(result.HasErrorMessage, "WHY NO MSG??");   //O:expected error msg
            Assert.AreEqual("", result.ErrorMessage, "WHY NOT EXPECTED MSG??");      //O:expected error msg
        }

        //I:valid exception, empty msg, valid value
        //O:has error
        //O:expected value
        //O:expected exception
        //O:empty error msg
        [TestMethod]
        public void Reply_Error_exception_valid_message_empty_value_valid()
        {
            var result = M.Reply.Error(Stubs.Common.EXCEPTION, "", Stubs.Common.VAL_anyValue);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");  //O:has error
            Assert.AreEqual(Stubs.Common.VAL_anyValue, result.Value, "WHY NO DEFAULT VALUE??");   //O:expected value

            Assert.IsTrue(result.HasException);     //O:expected exception
            Assert.AreEqual(Stubs.Common.EXCEPTION, result.Exception);    //O:expected exception

            Assert.IsTrue(result.HasErrorMessage, "WHY NO MSG??");    //O:empty error msg
            Assert.AreEqual("", result.ErrorMessage, "WHY NOT EXPECTED MSG??");        //O:empty error msg
        }

        //I:valid exception, empty msg, valid value exception
        //O:has error
        //O:expected value
        //O:expected exception
        //O:empty error msg
        //O:exception not same as value
        [TestMethod]
        public void Reply_Error_exception_valid_message_empty_value_valid_whenException()
        {
            Exception ex = new Exception("blebleble");
            var result = M.Reply.Error(Stubs.Common.EXCEPTION, "", ex);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");  //O:has error
            Assert.AreEqual(ex, result.Value, "WHY NO DEFAULT VALUE??");   //O:expected value

            Assert.IsTrue(result.HasException);     //O:expected exception
            Assert.AreEqual(Stubs.Common.EXCEPTION, result.Exception);    //O:expected exception

            Assert.IsTrue(result.HasErrorMessage, "WHY NO MSG??");    //O:empty error msg
            Assert.AreEqual("", result.ErrorMessage, "WHY NOT EXPECTED MSG??");       //O:empty error msg

            Assert.AreNotEqual(result.Exception, result.Value); //O:exception not same as value
        }
        
        //I:null exception, empty msg, valid value exception
        //O:has error
        //O:expected value
        //O:null exception
        //O:empty error msg
        [TestMethod]
        public void Reply_Error_exception_null_message_empty_value_valid_whenException()
        {
            Exception nullEx = null;
            Exception ex = new Exception("blebleble");
            var result = M.Reply.Error(nullEx, "", ex);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");  //O:has error
            Assert.AreEqual(ex, result.Value, "WHY NO DEFAULT VALUE??");   //O:expected value

            Assert.IsFalse(result.HasException);     //O:null exception
            Assert.AreEqual(nullEx, result.Exception);    //O:null exception

            Assert.IsTrue(result.HasErrorMessage, "WHY NO MSG??");   //O:empty error msg
            Assert.AreEqual("", result.ErrorMessage, "WHY NOT EXPECTED MSG??");       //O:empty error msg

            Assert.AreNotEqual(result.Exception, result.Value); //O:exception not same as value
        }

        //I:null exception, valid msg, valid value exception
        //O:has error
        //O:expected value
        //O:null exception
        //O:expected error msg
        [TestMethod]
        public void Reply_Error_exception_null_message_valid_value_valid_whenException()
        {
            Exception nullEx = null;
            Exception ex = new Exception("blebleble");
            var result = M.Reply.Error(nullEx, Stubs.Common.MSG_ErrorFound, ex);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");  //O:has error
            Assert.AreEqual(ex, result.Value, "WHY NO DEFAULT VALUE??");   //O:expected value

            Assert.IsFalse(result.HasException);     //O:null exception
            Assert.AreEqual(nullEx, result.Exception);    //O:null exception

            Assert.IsTrue(result.HasErrorMessage, "WHY NO MSG??");   //O:expected error msg
            Assert.AreEqual(Stubs.Common.MSG_ErrorFound, result.ErrorMessage, "WHY NOT EXPECTED MSG??");      //O:expected error msg

            Assert.AreNotEqual(result.Exception, result.Value); //O:exception not same as value
        }

        //I:valid exception, valid msg, valid value exception
        //O:has error
        //O:expected value
        //O:expected exception
        //O:expected error msg
        [TestMethod]
        public void Reply_Error_exception_valid_message_valid_value_valid_whenException()
        {
            Exception ex = new Exception("blebleble");
            var result = M.Reply.Error(Stubs.Common.EXCEPTION, Stubs.Common.MSG_ErrorFound, ex);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");  //O:has error
            Assert.AreEqual(ex, result.Value, "WHY NO DEFAULT VALUE??");   //O:expected value

            Assert.IsTrue(result.HasException);     //O:expected exception
            Assert.AreEqual(Stubs.Common.EXCEPTION, result.Exception);    //O:expected exception

            Assert.IsTrue(result.HasErrorMessage, "WHY NO MSG??");   //O:expected error msg
            Assert.AreEqual(Stubs.Common.MSG_ErrorFound, result.ErrorMessage, "WHY NOT EXPECTED MSG??");      //O:expected error msg

            Assert.AreNotEqual(result.Exception, result.Value); //O:exception not same as value
        }
*/
    }
}
