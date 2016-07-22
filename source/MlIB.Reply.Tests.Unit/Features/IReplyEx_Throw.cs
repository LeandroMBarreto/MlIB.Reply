using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MlIB.Reply.Tests.Unit.Features
{
    [TestClass]
    public class IReplyEx_Throw
    {

        // IReplyEx.Throw()

        //I:having null exception
        //O:throw warning exception 
        //O:generic exception message
        [TestMethod]
        public void IReplyEx_Throw_havingNullException()
        {
            Exception nullEx = null;
            var result = M.Reply.Error<int>(nullEx);

            Exception assert = null;
            try
            {
                result.Throw();
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsNotNull(assert, "WHY NOT THROWING??");
            Assert.AreEqual(typeof(ReplyException), assert.GetType(), "WHY NOT EXPECTED TYPE??");
            Assert.IsTrue(assert.Message.Contains("A DEFAULT ERROR WAS THROWN"), "WHY NOT EXPECTED MESSAGE??");
        }

        //I:having null exception, valid message
        //O:throw warning exception 
        //O:error message in exception message
        [TestMethod]
        public void IReplyEx_Throw_havingNullException_havingValidMessage()
        {
            Exception nullEx = null;
            var result = M.Reply.Error<int>(nullEx, Stubs.Common.MSG_ErrorFound);

            Exception assert = null;
            try
            {
                result.Throw();
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsNotNull(assert, "WHY NOT THROWING??");
            Assert.AreEqual(typeof(ReplyException), assert.GetType(), "WHY NOT EXPECTED TYPE??");
            Assert.IsTrue(assert.Message.Contains(Stubs.Common.MSG_ErrorFound), "WHY NOT EXPECTED MESSAGE??");
        }

        //I:having null exception, value exception
        //O:throw warning exception 
        //O:error message in exception message
        [TestMethod]
        public void IReplyEx_Throw_havingNullException_havingEmptyMessage_whenValueException()
        {
            Exception nullEx = null;
            var result = M.Reply.Error(nullEx, "", Stubs.Common.EXCEPTION);

            Exception assert = null;
            try
            {
                result.Throw();
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsNotNull(assert, "WHY NOT THROWING??");
            Assert.AreEqual(typeof(ReplyException), assert.GetType(), "WHY NOT EXPECTED TYPE??");
            Assert.AreEqual("[--]", assert.Message, "WHY NOT EXPECTED MESSAGE??");
        }

        //I:valid exception
        //O:throw expected exception 
        [TestMethod]
        public void IReplyEx_Throw_havingValidException()
        {
            var result = M.Reply.Error<int>(Stubs.Common.EXCEPTION);

            Exception assert = null;
            try
            {
                result.Throw();
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsNotNull(assert, "WHY NOT THROWING??");
            Assert.AreEqual(typeof(InvalidOperationException), assert.GetType(), "WHY NOT EXPECTED TYPE??");
            Assert.AreEqual(Stubs.Common.EXCEPTION.Message, assert.Message, "WHY NOT EXPECTED MESSAGE??");
        }

    }
}
