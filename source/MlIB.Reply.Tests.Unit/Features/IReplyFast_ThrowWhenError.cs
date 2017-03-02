using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MlIB.Reply.Tests.Unit.Features
{
    [TestClass]
    public class IReplyFast_ThrowWhenError
    {
        // UNIT UNDER TEST:
        // IReplyFast.ThrowWhenError(string msgPrefix = null)

        //TODO: Reduce implicit parameters to lower complexity?
        //This should be possible by breaking them down into
        // smaller units specialized on exception configuration.
        //Having to configure messages on the fly probably cuts
        // the advantage of speed this library seeks to provide.
        //So best approach would be an one-time configuration
        // set globally with a default setting initialized.
        //Should make sure different configs across assemblies
        // don't conflict though.
        

        #region [ WHEN HasError == false ]

        //I: HasError false, msgPrefix null
        //O:dont throw, do nothing
        //O:keeps showing no error
        [TestMethod]
        public void IReplyFast_ThrowWhenError_WHEN_HasError_false()
        {
            var result = M.Reply.NoError(5);

            Exception assert = null;
            try
            {
                result.ThrowWhenError();
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsNull(assert, "WHY THROWING??");  //O:dont throw, do nothing
            Assert.IsFalse(result.HasError, "WHY HAS ERROR??");  //O:keeps showing no error
        }

        #region [ 36 IGNORED TESTS WHEN HasError == false ] //BECAUSE WE *KNOW* THE *CURRENT* CODE WON'T LET THEM HAPPEN

        // _msgPrefix_null_WHEN_HasError_false_exception_null_errorCode_null_errorMsg_null

        // _msgPrefix_empty_WHEN_HasError_false_exception_null_errorCode_null_errorMsg_null

        // _msgPrefix_ok_WHEN_HasError_false_exception_null_errorCode_null_errorMsg_null

        // _msgPrefix_null_WHEN_HasError_false_exception_ok_errorCode_null_errorMsg_null

        // _msgPrefix_empty_WHEN_HasError_false_exception_ok_errorCode_null_errorMsg_null

        // _msgPrefix_ok_WHEN_HasError_false_exception_ok_errorCode_null_errorMsg_null

        // _msgPrefix_null_WHEN_HasError_false_exception_null_errorCode_ok_errorMsg_null

        // _msgPrefix_empty_WHEN_HasError_false_exception_null_errorCode_ok_errorMsg_null

        // _msgPrefix_ok_WHEN_HasError_false_exception_null_errorCode_ok_errorMsg_null

        // _msgPrefix_null_WHEN_HasError_false_exception_ok_errorCode_ok_errorMsg_null

        // _msgPrefix_empty_WHEN_HasError_false_exception_ok_errorCode_ok_errorMsg_null

        // _msgPrefix_ok_WHEN_HasError_false_exception_ok_errorCode_ok_errorMsg_null

        // _msgPrefix_null_WHEN_HasError_false_exception_null_errorCode_null_errorMsg_empty

        // _msgPrefix_empty_WHEN_HasError_false_exception_null_errorCode_null_errorMsg_empty

        // _msgPrefix_ok_WHEN_HasError_false_exception_null_errorCode_null_errorMsg_empty

        // _msgPrefix_null_WHEN_HasError_false_exception_ok_errorCode_null_errorMsg_empty

        // _msgPrefix_empty_WHEN_HasError_false_exception_ok_errorCode_null_errorMsg_empty

        // _msgPrefix_ok_WHEN_HasError_false_exception_ok_errorCode_null_errorMsg_empty

        // _msgPrefix_null_WHEN_HasError_false_exception_null_errorCode_ok_errorMsg_empty

        // _msgPrefix_empty_WHEN_HasError_false_exception_null_errorCode_ok_errorMsg_empty

        // _msgPrefix_ok_WHEN_HasError_false_exception_null_errorCode_ok_errorMsg_empty

        // _msgPrefix_null_WHEN_HasError_false_exception_ok_errorCode_ok_errorMsg_empty

        // _msgPrefix_empty_WHEN_HasError_false_exception_ok_errorCode_ok_errorMsg_empty

        // _msgPrefix_ok_WHEN_HasError_false_exception_ok_errorCode_ok_errorMsg_empty

        // _msgPrefix_null_WHEN_HasError_false_exception_null_errorCode_null_errorMsg_ok

        // _msgPrefix_empty_WHEN_HasError_false_exception_null_errorCode_null_errorMsg_ok

        // _msgPrefix_ok_WHEN_HasError_false_exception_null_errorCode_null_errorMsg_ok

        // _msgPrefix_null_WHEN_HasError_false_exception_ok_errorCode_null_errorMsg_ok

        // _msgPrefix_empty_WHEN_HasError_false_exception_ok_errorCode_null_errorMsg_ok

        // _msgPrefix_ok_WHEN_HasError_false_exception_ok_errorCode_null_errorMsg_ok

        // _msgPrefix_null_WHEN_HasError_false_exception_null_errorCode_ok_errorMsg_ok

        // _msgPrefix_empty_WHEN_HasError_false_exception_null_errorCode_ok_errorMsg_ok

        // _msgPrefix_ok_WHEN_HasError_false_exception_null_errorCode_ok_errorMsg_ok

        // _msgPrefix_null_WHEN_HasError_false_exception_ok_errorCode_ok_errorMsg_ok

        // _msgPrefix_empty_WHEN_HasError_false_exception_ok_errorCode_ok_errorMsg_ok

        // _msgPrefix_ok_WHEN_HasError_false_exception_ok_errorCode_ok_errorMsg_ok

        #endregion

        #endregion


        // _msgPrefix_null_WHEN_HasError_true_exception_null_errorCode_null_errorMsg_null
        //I: HasError true, msgPrefix null, exception null, errorCode null, errorMsg null
        //O:throw ReplyException 
        //O:generic exception message
        [TestMethod]
        public void IReplyFast_ThrowWhenError_WHEN_exception_null_errorCode_null_errorMsg_null()
        {
            Exception nullEx = null;
            var result = M.Reply.Error<int>(nullEx);

            Exception assert = null;
            try
            {
                result.ThrowWhenError();
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsNotNull(assert, "WHY NOT THROWING??");
            Assert.AreEqual(typeof(ReplyException), assert.GetType(), "WHY NOT EXPECTED TYPE??");
            Assert.IsTrue(assert.Message.Equals("[--]"), "WHY NOT EXPECTED MESSAGE??"); 
            //Assert.IsTrue(assert.Message.Contains("A DEFAULT ERROR WAS THROWN"), "WHY NOT EXPECTED MESSAGE??"); revoked for lower complexity
        }

        // _msgPrefix_null_WHEN_HasError_true_exception_null_errorCode_ok_errorMsg_null
        //I: HasError true, msgPrefix null, exception null, errorCode ok, errorMsg null
        //O:throw ReplyException 
        //O:generic exception message
        [TestMethod][Ignore]
        public void IReplyFast_ThrowWhenError_WHEN_exception_null_errorCode_ok_errorMsg_null()
        {
            //Exception nullEx = null;
            //var result = M.Reply.Error<int>(nullEx); //add errorCode here

            //Exception assert = null;
            //try
            //{
            //    result.ThrowWhenError();
            //}
            //catch (Exception ex)
            //{
            //    assert = ex;
            //}

            //Assert.IsNotNull(assert, "WHY NOT THROWING??");
            //Assert.AreEqual(typeof(ReplyException), assert.GetType(), "WHY NOT EXPECTED TYPE??");
            //Assert.IsTrue(assert.Message.Contains("CODE"), "WHY NOT EXPECTED MESSAGE??"); 
        }

        // _msgPrefix_null_WHEN_HasError_true_exception_null_errorCode_ok_errorMsg_ok
        //I: HasError true, msgPrefix null, exception null, errorCode ok, errorMsg ok
        //O:throw ReplyException 
        //O:generic exception message
        [TestMethod]
        [Ignore]
        public void IReplyFast_ThrowWhenError_WHEN_exception_null_errorCode_ok_errorMsg_ok()
        {
            Exception nullEx = null;
            var result = M.Reply.Error<int>(nullEx); //add errorCode here

            Exception assert = null;
            try
            {
                result.ThrowWhenError();
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsNotNull(assert, "WHY NOT THROWING??");
            Assert.AreEqual(typeof(ReplyException), assert.GetType(), "WHY NOT EXPECTED TYPE??");
            Assert.IsTrue(assert.Message.Contains("CODE"), "WHY NOT EXPECTED MESSAGE??");
        }

        // _msgPrefix_null_WHEN_HasError_true_exception_null_errorCode_null_errorMsg_ok
        //I: HasError true, msgPrefix null, exception null, errorCode null, errorMsg ok
        //O:throw ReplyException 
        //O:error message in exception message
        [TestMethod]
        public void IReplyFast_ThrowWhenError_WHEN_exception_null_errorCode_null_errorMsg_ok()
        {
            Exception nullEx = null;
            var result = M.Reply.Error<int>(nullEx, Stubs.Common.MSG_ErrorFound);

            Exception assert = null;
            try
            {
                result.ThrowWhenError();
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsNotNull(assert, "WHY NOT THROWING??");
            Assert.AreEqual(typeof(ReplyException), assert.GetType(), "WHY NOT EXPECTED TYPE??");
            Assert.IsTrue(assert.Message.Contains(Stubs.Common.MSG_ErrorFound), "WHY NOT EXPECTED MESSAGE??");
        }

        // _msgPrefix_null_WHEN_HasError_true_exception_ok_errorCode_null_errorMsg_null
        //I: HasError true, msgPrefix null, exception ok, errorCode null, errorMsg null
        //O:throw expected exception 
        [TestMethod]
        public void IReplyFast_ThrowWhenError_WHEN_exception_ok_errorCode_null_errorMsg_null()
        {
            var result = M.Reply.Error<int>(Stubs.Common.EXCEPTION);

            Exception assert = null;
            try
            {
                result.ThrowWhenError();
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsNotNull(assert, "WHY NOT THROWING??");
            Assert.AreEqual(typeof(InvalidOperationException), assert.GetType(), "WHY NOT EXPECTED TYPE??");
            Assert.AreEqual(Stubs.Common.EXCEPTION.Message, assert.Message, "WHY NOT EXPECTED MESSAGE??");
        }

        // _msgPrefix_null_WHEN_HasError_true_exception_ok_errorCode_null_errorMsg_ok
        //I: HasError true, msgPrefix null, exception ok, errorCode null, errorMsg ok
        //O:throw ReplyException exception 
        [TestMethod]
        public void IReplyFast_ThrowWhenError_WHEN_exception_ok_errorCode_null_errorMsg_ok()
        {
            var result = M.Reply.Error<int>(Stubs.Common.EXCEPTION, Stubs.Common.MSG_ErrorFound);

            Exception assert = null;
            try
            {
                result.ThrowWhenError();
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsNotNull(assert, "WHY NOT THROWING??");
            Assert.AreEqual(typeof(ReplyException), assert.GetType(), "WHY NOT EXPECTED TYPE??");
            Assert.IsTrue(assert.Message.Contains(Stubs.Common.MSG_ErrorFound), "WHY NOT EXPECTED MESSAGE??");
            Assert.AreEqual(Stubs.Common.EXCEPTION, assert.InnerException, "WHY NOT EXPECTED INNER EXCEPTION??");
            Assert.AreEqual(Stubs.Common.EXCEPTION.Message, assert.InnerException.Message, "WHY NOT EXPECTED MESSAGE??");
        }

        // _msgPrefix_null_WHEN_HasError_true_exception_ok_errorCode_ok_errorMsg_null
        //I: HasError true, msgPrefix null, exception ok, errorCode ok, errorMsg null
        //O:throw ReplyException 
        [TestMethod][Ignore]
        public void IReplyFast_ThrowWhenError_WHEN_exception_ok_errorCode_ok_errorMsg_null()
        {
            //var result = M.Reply.Error<int>(Stubs.Common.EXCEPTION); //add errorCode here

            //Exception assert = null;
            //try
            //{
            //    result.ThrowWhenError();
            //}
            //catch (Exception ex)
            //{
            //    assert = ex;
            //}

            //Assert.IsNotNull(assert, "WHY NOT THROWING??");
            //Assert.AreEqual(typeof(ReplyException), assert.GetType(), "WHY NOT EXPECTED TYPE??");
            ////Assert.AreEqual(Stubs.Common.EXCEPTION.Message, assert.Message, "WHY NOT EXPECTED MESSAGE??"); add code
            //Assert.AreEqual(Stubs.Common.EXCEPTION, assert.InnerException, "WHY NOT EXPECTED INNER EXCEPTION??");
            //Assert.AreEqual(Stubs.Common.EXCEPTION.Message, assert.InnerException.Message, "WHY NOT EXPECTED MESSAGE??");
        }

        // _msgPrefix_null_WHEN_HasError_true_exception_ok_errorCode_ok_errorMsg_ok
        //I: HasError true, msgPrefix null, exception ok, errorCode ok, errorMsg ok
        //O:throw ReplyException 
        [TestMethod]
        [Ignore]
        public void IReplyFast_ThrowWhenError_WHEN_exception_ok_errorCode_ok_errorMsg_ok()
        {
            //var result = M.Reply.Error<int>(Stubs.Common.EXCEPTION); //add errorCode here & msg

            //Exception assert = null;
            //try
            //{
            //    result.ThrowWhenError();
            //}
            //catch (Exception ex)
            //{
            //    assert = ex;
            //}

            //Assert.IsNotNull(assert, "WHY NOT THROWING??");
            //Assert.AreEqual(typeof(ReplyException), assert.GetType(), "WHY NOT EXPECTED TYPE??");
            ////Assert.AreEqual(Stubs.Common.EXCEPTION.Message, assert.Message, "WHY NOT EXPECTED MESSAGE??"); add msg ok
            //Assert.AreEqual(Stubs.Common.EXCEPTION, assert.InnerException, "WHY NOT EXPECTED INNER EXCEPTION??");
            //Assert.AreEqual(Stubs.Common.EXCEPTION.Message, assert.InnerException.Message, "WHY NOT EXPECTED MESSAGE??");
        }

        // _msgPrefix_empty_WHEN_HasError_true_exception_null_errorCode_null_errorMsg_null
        //I: HasError true, msgPrefix ok, exception null, errorCode null, errorMsg null
        //O:throw ReplyException 
        //O:empty message
        [TestMethod]
        public void IReplyFast_ThrowWhenError_msgPrefix_empty_WHEN_exception_null_errorCode_null_errorMsg_null()
        {
            Exception nullEx = null;
            var result = M.Reply.Error<int>(nullEx);

            Exception assert = null;
            try
            {
                result.ThrowWhenError("");
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsNotNull(assert, "WHY NOT THROWING??");
            Assert.AreEqual(typeof(ReplyException), assert.GetType(), "WHY NOT EXPECTED TYPE??");
            Assert.AreEqual("[--]", assert.Message, "WHY NOT EMPTY MESSAGE??");
        }

        // _msgPrefix_empty_WHEN_HasError_true_exception_null_errorCode_ok_errorMsg_null
        //I: HasError true, msgPrefix ok, exception null, errorCode ok, errorMsg null
        //O:throw ReplyException 
        //O:empty message
        [TestMethod][Ignore]
        public void IReplyFast_ThrowWhenError_msgPrefix_empty_WHEN_exception_null_errorCode_ok_errorMsg_null()
        {
            //Exception nullEx = null;
            //var result = M.Reply.Error<int>(nullEx);

            //Exception assert = null;
            //try
            //{
            //    result.ThrowWhenError("");
            //}
            //catch (Exception ex)
            //{
            //    assert = ex;
            //}

            //Assert.IsNotNull(assert, "WHY NOT THROWING??");
            //Assert.AreEqual(typeof(ReplyException), assert.GetType(), "WHY NOT EXPECTED TYPE??");
            //Assert.AreEqual("[--]", assert.Message, "WHY NOT EMPTY MESSAGE??");
            //Assert.AreEqual(Stubs.Common.EXCEPTION, assert.InnerException, "WHY NOT EXPECTED INNER EXCEPTION??");
            //Assert.AreEqual(Stubs.Common.EXCEPTION.Message, assert.InnerException.Message, "WHY NOT EXPECTED MESSAGE??");
        }

        // _msgPrefix_ok_WHEN_HasError_true_exception_null_errorCode_null_errorMsg_ok
        //I: HasError true, msgPrefix ok, exception null, errorCode null, errorMsg ok
        //O:throw ReplyException 
        //O:error message in exception message
        [TestMethod]
        public void IReplyFast_ThrowWhenError_msgPrefix_ok_WHEN_exception_null_errorCode_null_errorMsg_ok()
        {
            Exception nullEx = null;
            var result = M.Reply.Error<int>(nullEx, Stubs.Common.MSG_ErrorFound);

            Exception assert = null;
            try
            {
                result.ThrowWhenError("");
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsNotNull(assert, "WHY NOT THROWING??");
            Assert.AreEqual(typeof(ReplyException), assert.GetType(), "WHY NOT EXPECTED TYPE??");
            Assert.IsTrue(assert.Message.Contains(Stubs.Common.MSG_ErrorFound), "WHY NOT EXPECTED MESSAGE??");
        }

        // _msgPrefix_ok_WHEN_HasError_true_exception_null_errorCode_ok_errorMsg_ok
        //I: HasError true, msgPrefix ok, exception null, errorCode ok, errorMsg ok
        //O:throw ReplyException 
        //O:error message in exception message
        [TestMethod][Ignore]
        public void IReplyFast_ThrowWhenError_msgPrefix_ok_WHEN_exception_null_errorCode_ok_errorMsg_ok()
        {
            //Exception nullEx = null;
            //var result = M.Reply.Error<int>(nullEx, Stubs.Common.MSG_ErrorFound);

            //Exception assert = null;
            //try
            //{
            //    result.ThrowWhenError("");
            //}
            //catch (Exception ex)
            //{
            //    assert = ex;
            //}

            //Assert.IsNotNull(assert, "WHY NOT THROWING??");
            //Assert.AreEqual(typeof(ReplyException), assert.GetType(), "WHY NOT EXPECTED TYPE??");
            //Assert.IsTrue(assert.Message.Contains(Stubs.Common.MSG_ErrorFound), "WHY NOT EXPECTED MESSAGE??");
            //Assert.AreEqual(Stubs.Common.EXCEPTION, assert.InnerException, "WHY NOT EXPECTED INNER EXCEPTION??");
            //Assert.AreEqual(Stubs.Common.EXCEPTION.Message, assert.InnerException.Message, "WHY NOT EXPECTED MESSAGE??");
        }

        // _msgPrefix_ok_WHEN_HasError_true_exception_ok_errorCode_null_errorMsg_null
        //I: HasError true, msgPrefix ok, exception ok, errorCode null, errorMsg null
        //O:throw ReplyException 
        [TestMethod]
        public void IReplyFast_ThrowWhenError_msgPrefix_ok_WHEN_exception_ok_errorCode_null_errorMsg_null()
        {
            var result = M.Reply.Error<int>(Stubs.Common.EXCEPTION);

            Exception assert = null;
            try
            {
                result.ThrowWhenError("");
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsNotNull(assert, "WHY NOT THROWING??");
            Assert.AreEqual(typeof(ReplyException), assert.GetType(), "WHY NOT EXPECTED TYPE??");
            Assert.AreEqual(Stubs.Common.EXCEPTION, assert.InnerException, "WHY NOT EXPECTED INNER EXCEPTION??");
            Assert.AreEqual(Stubs.Common.EXCEPTION.Message, assert.InnerException.Message, "WHY NOT EXPECTED MESSAGE??");
        }

        // _msgPrefix_ok_WHEN_HasError_true_exception_ok_errorCode_null_errorMsg_ok
        //I: HasError true, msgPrefix ok, exception ok, errorCode null, errorMsg ok
        //O:throw ReplyException 
        [TestMethod]
        public void IReplyFast_ThrowWhenError_msgPrefix_ok_WHEN_exception_ok_errorCode_null_errorMsg_ok()
        {
            var result = M.Reply.Error<int>(Stubs.Common.EXCEPTION, Stubs.Common.MSG_ErrorFound);

            Exception assert = null;
            try
            {
                result.ThrowWhenError("");
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsNotNull(assert, "WHY NOT THROWING??");
            Assert.AreEqual(typeof(ReplyException), assert.GetType(), "WHY NOT EXPECTED TYPE??");
            Assert.IsTrue(assert.Message.Contains(Stubs.Common.MSG_ErrorFound), "WHY NOT EXPECTED MESSAGE??");
            Assert.AreEqual(Stubs.Common.EXCEPTION, assert.InnerException, "WHY NOT EXPECTED INNER EXCEPTION??");
            Assert.AreEqual(Stubs.Common.EXCEPTION.Message, assert.InnerException.Message, "WHY NOT EXPECTED MESSAGE??");
        }

        // _msgPrefix_ok_WHEN_HasError_true_exception_ok_errorCode_ok_errorMsg_null
        //I: HasError true, msgPrefix ok, exception ok, errorCode ok, errorMsg null
        //O:throw ReplyException 
        [TestMethod][Ignore]
        public void IReplyFast_ThrowWhenError_msgPrefix_ok_WHEN_exception_ok_errorCode_ok_errorMsg_null()
        {
            //var result = M.Reply.Error<int>(Stubs.Common.EXCEPTION); add code

            //Exception assert = null;
            //try
            //{
            //    result.ThrowWhenError("");
            //}
            //catch (Exception ex)
            //{
            //    assert = ex;
            //}

            //Assert.IsNotNull(assert, "WHY NOT THROWING??");
            //Assert.AreEqual(typeof(ReplyException), assert.GetType(), "WHY NOT EXPECTED TYPE??");
            //Assert.AreEqual(Stubs.Common.EXCEPTION, assert.InnerException, "WHY NOT EXPECTED INNER EXCEPTION??");
            //Assert.AreEqual(Stubs.Common.EXCEPTION.Message, assert.InnerException.Message, "WHY NOT EXPECTED MESSAGE??");
        }

        // _msgPrefix_ok_WHEN_HasError_true_exception_ok_errorCode_ok_errorMsg_ok
        //I: HasError true, msgPrefix ok, exception ok, errorCode ok, errorMsg ok
        //O:throw ReplyException 
        [TestMethod]
        [Ignore]
        public void IReplyFast_ThrowWhenError_msgPrefix_ok_WHEN_exception_ok_errorCode_ok_errorMsg_ok()
        {
            //var result = M.Reply.Error<int>(Stubs.Common.EXCEPTION); add code & msg

            //Exception assert = null;
            //try
            //{
            //    result.ThrowWhenError("");
            //}
            //catch (Exception ex)
            //{
            //    assert = ex;
            //}

            //Assert.IsNotNull(assert, "WHY NOT THROWING??");
            //Assert.AreEqual(typeof(ReplyException), assert.GetType(), "WHY NOT EXPECTED TYPE??");
            //Assert.AreEqual(Stubs.Common.EXCEPTION, assert.InnerException, "WHY NOT EXPECTED INNER EXCEPTION??");
            //Assert.AreEqual(Stubs.Common.EXCEPTION.Message, assert.InnerException.Message, "WHY NOT EXPECTED MESSAGE??");
        }


        #region [ IGNORED TESTS ] //BECAUSE WE DON'T *THINK* IT'S WORTH TESTING THIS MUCH

        // _msgPrefix_ok_WHEN_HasError_true_exception_null_errorCode_null_errorMsg_null

        // _msgPrefix_empty_WHEN_HasError_true_exception_ok_errorCode_null_errorMsg_null

        // _msgPrefix_ok_WHEN_HasError_true_exception_null_errorCode_ok_errorMsg_null

        // _msgPrefix_empty_WHEN_HasError_true_exception_ok_errorCode_ok_errorMsg_null

        // _msgPrefix_null_WHEN_HasError_true_exception_null_errorCode_null_errorMsg_empty

        // _msgPrefix_empty_WHEN_HasError_true_exception_null_errorCode_null_errorMsg_empty

        // _msgPrefix_ok_WHEN_HasError_true_exception_null_errorCode_null_errorMsg_empty

        // _msgPrefix_null_WHEN_HasError_true_exception_ok_errorCode_null_errorMsg_empty

        // _msgPrefix_empty_WHEN_HasError_true_exception_ok_errorCode_null_errorMsg_empty

        // _msgPrefix_ok_WHEN_HasError_true_exception_ok_errorCode_null_errorMsg_empty

        // _msgPrefix_null_WHEN_HasError_true_exception_null_errorCode_ok_errorMsg_empty

        // _msgPrefix_empty_WHEN_HasError_true_exception_null_errorCode_ok_errorMsg_empty

        // _msgPrefix_ok_WHEN_HasError_true_exception_null_errorCode_ok_errorMsg_empty

        // _msgPrefix_null_WHEN_HasError_true_exception_ok_errorCode_ok_errorMsg_empty

        // _msgPrefix_empty_WHEN_HasError_true_exception_ok_errorCode_ok_errorMsg_empty

        // _msgPrefix_ok_WHEN_HasError_true_exception_ok_errorCode_ok_errorMsg_empty

        // _msgPrefix_empty_WHEN_HasError_true_exception_null_errorCode_null_errorMsg_ok

        // _msgPrefix_empty_WHEN_HasError_true_exception_ok_errorCode_null_errorMsg_ok

        // _msgPrefix_empty_WHEN_HasError_true_exception_null_errorCode_ok_errorMsg_ok

        // _msgPrefix_empty_WHEN_HasError_true_exception_ok_errorCode_ok_errorMsg_ok
        
        #endregion
    }
}
