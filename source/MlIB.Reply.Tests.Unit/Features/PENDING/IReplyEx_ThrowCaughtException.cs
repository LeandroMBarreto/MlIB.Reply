using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MlIB.Reply.Tests.Unit.Features
{
    [TestClass]
    public class IReplyEx_ThrowCaughtException
    {
        // UNIT UNDER TEST:
        // void ThrowCaughtException();

        /*
        //I: - HasException false - HasError false
        //O: dont throw, do nothing
        //O: keeps showing NO error
        [TestMethod]
        public void IReplyEx_ThrowCaughtException_HasException_false_HasError_false()
        {
            var result = M.Reply.NoError(5);

            Exception assert = null;
            try
            {
                result.ThrowCaughtException();
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsNull(assert, "WHY THROWING??");  //O: dont throw, do nothing
            Assert.IsFalse(result.HasError, "WHY HAS ERROR??");  //O: keeps showing NO error
        }

        //I: - HasException true - HasError false
        //O: dont throw, do nothing
        // _HasException_true_HasError_false
        // [IMPOSSIBLE]

        //I: - HasException false - HasError true
        //O: dont throw, do nothing
        //O: keeps showing error
        [TestMethod]
        public void IReplyEx_ThrowCaughtException_HasException_false_HasError_true()
        {
            var result = M.Reply.Error(5);

            Exception assert = null;
            try
            {
                result.ThrowCaughtException();
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsNull(assert, "WHY THROWING??");  //O:dont throw, do nothing
            Assert.IsTrue(result.HasError, "WHY HAS ERROR??");  //O:keeps showing error
        }

        //I: - HasException true - HasError true
        //O: throws exception
        [TestMethod]
        public void IReplyEx_ThrowCaughtException_HasException_true_HasError_true()
        {
            var caughtException = new MethodAccessException("CAUGHT EXCEPTION!");
            var result = M.Reply.Error(caughtException);

            Exception assert = null;
            try
            {
                result.ThrowCaughtException();
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsInstanceOfType(assert, typeof(MethodAccessException), "WHY NOT EXPECTED EXCEPTION??");
        }




        */








        //DESIGN:
        
//When the only error is an exception, it just throws that exception.
//ThrowCaughtException()

//it throws a ReplyException passing any caught exception as InnerException.
//ThrowAnyError(string messagePrefix = "ERROR")

//The error message is ALWAYS formatted as 
//[ERROR] | ErrorCodeID: n/a | ErrorCodeLabel: n/a | ErrorMessage: n/a |



        //I: - HasError false - Exception null
        //O: 
        // _HasError_false_Exception_null

        //I: - HasError true - Exception null
        //O: 
        // _HasError_true_Exception_null

        //I: - HasError false - Exception ok
        //O: 
        // _HasError_false_Exception_ok

        //I: - HasError true - Exception ok
        //O: 
        // _HasError_true_Exception_ok



        /*
        //I: exception null
        //O:dont throw, do nothing
        [TestMethod]
        public void IReplyFast_ThrowCaughtException_WHEN_HasError_false_exception_null()
        {
            var result = M.Reply.NoError(5);

            Exception assert = null;
            try
            {
                result.ThrowAnyError();
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsNull(assert, "WHY THROWING??");  //O:dont throw, do nothing
            Assert.IsFalse(result.HasError, "WHY HAS ERROR??");  //O:keeps showing no error
        }
        */
    }
}
