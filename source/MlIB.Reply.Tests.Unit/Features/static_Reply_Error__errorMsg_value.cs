using System;
using M;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MlIB.Reply.Tests.Unit.Features
{
    [TestClass]
    public class static_Reply_Error__errorMsg_value
    {
        // UNIT UNDER TEST:
        // public static IReplyMsg<TReturn> Error<TReturn>(string errorMsg, TReturn value = default(TReturn))


        //I: - errorMsg null - value default
        //O1: HasError true
        //O2: value default
        //O3: HasErrorMessage false
        //O4: ErrorMessage null
        [TestMethod]
        public void static_Reply_Error_errorMsg_null_value_default()
        {
            string nullMsg = null;
            IReplyMsg<int> result = M.Reply.Error<int>(nullMsg);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");    //O1: HasError true
            Assert.IsFalse(result.HasErrorMessage, "WHY HAVE MSG??");        //O3: HasErrorMessage false
            Assert.AreEqual(null, result.ErrorMessage, "WHY NOT NULL MSG??");   //O4: ErrorMessage null
            Assert.AreEqual(default(int), result.Value, "WHY NOT DEFAULT VALUE??");        //O2: value default
        }

        //I: - errorMsg empty - value default
        //O1: HasError true
        //O2: value default
        //O3: HasErrorMessage true
        //O4: ErrorMessage empty
        [TestMethod]
        public void static_Reply_Error_errorMsg_empty_value_default()
        {
            var result = M.Reply.Error<string>("");

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");    //O1: HasError true
            Assert.IsTrue(result.HasErrorMessage, "WHY NO MSG??");           //O3: HasErrorMessage true
            Assert.AreEqual(string.Empty, result.ErrorMessage, "WHY NOT EMPTY MSG??");     //O4: ErrorMessage empty
            Assert.AreEqual(default(string), result.Value, "WHY NOT DEFAULT VALUE??");      //O2: value default
        }

        //I: - errorMsg ok - value default
        //O1: HasError true
        //O2: value default
        //O3: HasErrorMessage true
        //O4: ErrorMessage ok
        [TestMethod]
        public void static_Reply_Error_errorMsg_ok_value_default()
        {
            var result = M.Reply.Error<int>(Stubs.Common.MSG_ErrorFound);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");       //O1: HasError true
            Assert.IsTrue(result.HasErrorMessage, "WHY NO MSG??");      //O3: HasErrorMessage true
            Assert.AreEqual(Stubs.Common.MSG_ErrorFound, result.ErrorMessage, "WHY NOT EXPECTED MSG??");    //O2: value default
            Assert.AreEqual(default(int), result.Value, "WHY NOT DEFAULT VALUE??");     //O4: ErrorMessage ok
        }

        //I: - errorMsg null - value ok
        //O1: HasError true
        //O2: value ok
        //O3: HasErrorMessage false
        //O4: ErrorMessage null
        [TestMethod]
        public void static_Reply_Error_errorMsg_null_value_ok()
        {
            string nullMsg = null;
            var result = M.Reply.Error(nullMsg, Stubs.Common.VAL_anyValue);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");     //O1: HasError true
            Assert.IsFalse(result.HasErrorMessage, "WHY HAVE MSG??");        //O3: HasErrorMessage false
            Assert.AreEqual(null, result.ErrorMessage, "WHY NOT NULL MSG??");     //O4: ErrorMessage null
            Assert.AreEqual(Stubs.Common.VAL_anyValue, result.Value, "WHY NOT EXPECTED VALUE??");       //O2: value ok
        }

        //I: - errorMsg empty - value ok
        //O1: HasError true
        //O2: value ok
        //O3: HasErrorMessage true
        //O4: ErrorMessage empty
        [TestMethod]
        public void static_Reply_Error_errorMsg_empty_value_ok()
        {
            var result = M.Reply.Error("", Stubs.Common.VAL_anyValue);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");   //O1: HasError true
            Assert.IsTrue(result.HasErrorMessage, "WHY NO MSG??");       //O3: HasErrorMessage true
            Assert.AreEqual(string.Empty, result.ErrorMessage, "WHY NOT EMPTY MSG??");           //O4: ErrorMessage empty
            Assert.AreEqual(Stubs.Common.VAL_anyValue, result.Value, "WHY NOT EXPECTED VALUE??");         //O2: value ok
        }

        //I: - errorMsg ok - value ok
        //O1: HasError true
        //O2: value ok
        //O3: HasErrorMessage true
        //O4: ErrorMessage ok
        [TestMethod]
        public void static_Reply_Error_errorMsg_ok_value_ok()
        {
            var result = M.Reply.Error(Stubs.Common.MSG_ErrorFound, Stubs.Common.VAL_anyValue);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");     //O1: HasError true
            Assert.IsTrue(result.HasErrorMessage, "WHY NO MSG??");          //O3: HasErrorMessage true
            Assert.AreEqual(Stubs.Common.MSG_ErrorFound, result.ErrorMessage, "WHY NOT EXPECTED MSG??");         //O4: ErrorMessage ok
            Assert.AreEqual(Stubs.Common.VAL_anyValue, result.Value, "WHY NOT EXPECTED VALUE??");      //O2: value ok
        }

        //I: - errorMsg null - value exception
        //O1: HasError true
        //O2: value exception
        //O3: HasErrorMessage false
        //O4: ErrorMessage null
        //O5: HasException false
        [TestMethod]
        public void static_Reply_Error_errorMsg_null_value_exception()
        {
            string nullMsg = null;
            var result = M.Reply.Error(nullMsg, Stubs.Common.EXCEPTION);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");        //O1: HasError true
            Assert.IsFalse(result.HasErrorMessage, "WHY HAVE MSG??");         //O3: HasErrorMessage false
            Assert.AreEqual(null, result.ErrorMessage, "WHY NOT NULL MSG??");       //O4: ErrorMessage null
            Assert.AreEqual(Stubs.Common.EXCEPTION, result.Value, "WHY NOT EXPECTED VALUE??");        //O2: value exception

            var convertedResult = result as M.IReplyEx<InvalidOperationException>;
            Assert.IsFalse(convertedResult.HasException, "WHY HAS EXCEPTION??");         //O5: HasException false
        }

        //I: - errorMsg empty - value exception
        //O1: HasError true
        //O2: value exception
        //O3: HasErrorMessage true
        //O4: ErrorMessage empty
        //O5: HasException false
        [TestMethod]
        public void static_Reply_Error_errorMsg_empty_value_exception()
        {
            var result = M.Reply.Error("", Stubs.Common.EXCEPTION);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");         //O1: HasError true
            Assert.IsTrue(result.HasErrorMessage, "WHY NO MSG??");           //O3: HasErrorMessage true
            Assert.AreEqual(string.Empty, result.ErrorMessage, "WHY NOT EMPTY MSG??");            //O4: ErrorMessage empty
            Assert.AreEqual(Stubs.Common.EXCEPTION, result.Value, "WHY NOT EXPECTED VALUE??");         //O2: value exception

            var convertedResult = result as M.IReplyEx<InvalidOperationException>;
            Assert.IsFalse(convertedResult.HasException, "WHY HAS EXCEPTION??");         //O5: HasException false
        }

        //I: - errorMsg ok - value exception
        //O1: HasError true
        //O2: value exception
        //O3: HasErrorMessage true
        //O4: ErrorMessage ok
        //O5: HasException false
        [TestMethod]
        public void static_Reply_Error_errorMsg_ok_value_exception()
        {
            var result = M.Reply.Error(Stubs.Common.MSG_ErrorFound, Stubs.Common.EXCEPTION);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");         //O1: HasError true
            Assert.IsTrue(result.HasErrorMessage, "WHY NO MSG??");          //O3: HasErrorMessage true
            Assert.AreEqual(Stubs.Common.MSG_ErrorFound, result.ErrorMessage, "WHY NOT EXPECTED MSG??");          //O4: ErrorMessage ok
            Assert.AreEqual(Stubs.Common.EXCEPTION, result.Value, "WHY NOT EXPECTED VALUE??");        //O2: value exception

            var convertedResult = result as M.IReplyEx<InvalidOperationException>;
            Assert.IsFalse(convertedResult.HasException, "WHY HAS EXCEPTION??");         //O5: HasException false
        }

    }
}
