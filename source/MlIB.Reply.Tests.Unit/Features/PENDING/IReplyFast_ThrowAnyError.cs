using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MlIB.Reply.Tests.Unit.Features
{
    [TestClass]
    public class IReplyFast_ThrowAnyError
    {
        // UNIT UNDER TEST:
        // void ThrowAnyError(string messagePrefix = null)

        /*
        //I: - messagePrefix null - WHEN HasError false
        //O: dont throw, do nothing
        //O: keeps showing no error
        [TestMethod]
        public void IReplyFast_ThrowAnyError_messagePrefix_null_WHEN_HasError_false()
        {
            var result = M.Reply.NoError(5);

            result.ThrowAnyError(null);

            Assert.IsFalse(result.HasError, "WHY HAS ERROR??");
        }

        //I: - messagePrefix empty - WHEN HasError false
        //O: dont throw, do nothing
        //O: keeps showing no error
        [TestMethod]
        public void IReplyFast_ThrowAnyError_messagePrefix_empty_WHEN_HasError_false()
        {
            var result = M.Reply.NoError(5);

            result.ThrowAnyError(string.Empty);

            Assert.IsFalse(result.HasError, "WHY HAS ERROR??");
        }

        //I: - messagePrefix ok - WHEN HasError false
        //O: dont throw, do nothing
        //O: keeps showing no error
        [TestMethod]
        public void IReplyFast_ThrowAnyError_messagePrefix_ok_WHEN_HasError_false()
        {
            var result = M.Reply.NoError(5);

            result.ThrowAnyError("SOME MSG PREFIX");

            Assert.IsFalse(result.HasError, "WHY HAS ERROR??");
        }

        //I: - messagePrefix null - WHEN HasError true
        //O: ReplyFullException
        //O: [ERROR] | ErrorCodeID: n/a | ErrorCodeLabel: n/a | ErrorMessage: n/a |
        [TestMethod]
        public void IReplyFast_ThrowAnyError_messagePrefix_null_WHEN_HasError_true()
        {
            var expectedOutput = "[ERROR] | ErrorCodeID: n/a | ErrorCodeLabel: n/a | ErrorMessage: n/a |";

            var result = M.Reply.Error(5);

            try
            {
                result.ThrowAnyError(null);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ReplyFullException), "WHY NOT EXPECTED EXCEPTION TYPE??");
                Assert.AreEqual(expectedOutput, ex.Message, "WHY NOT EXPECTED MESSAGE??");
            }
        }

        //I: - messagePrefix empty - WHEN HasError true
        //O: ReplyFullException
        //O: [ERROR] | ErrorCodeID: n/a | ErrorCodeLabel: n/a | ErrorMessage: n/a |
        [TestMethod]
        public void IReplyFast_ThrowAnyError_messagePrefix_empty_WHEN_HasError_true()
        {
            var expectedOutput = "[ERROR] | ErrorCodeID: n/a | ErrorCodeLabel: n/a | ErrorMessage: n/a |";

            var result = M.Reply.Error(5);

            try
            {
                result.ThrowAnyError(string.Empty);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ReplyFullException), "WHY NOT EXPECTED EXCEPTION TYPE??");
                Assert.AreEqual(expectedOutput, ex.Message, "WHY NOT EXPECTED MESSAGE??");
            }
        }

        //I: - messagePrefix ok - WHEN HasError true
        //O: ReplyFullException
        //O: [messagePrefix] | ErrorCodeID: n/a | ErrorCodeLabel: n/a | ErrorMessage: n/a |
        [TestMethod]
        public void IReplyFast_ThrowAnyError_messagePrefix_ok_WHEN_HasError_true()
        {
            var messagePrefix = "RANDOM MSG PREFIX";
            var expectedOutput = string.Format("[{0}] | ErrorCodeID: n/a | ErrorCodeLabel: n/a | ErrorMessage: n/a |", messagePrefix);

            var result = M.Reply.Error(5);

            try
            {
                result.ThrowAnyError(messagePrefix);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ReplyFullException), "WHY NOT EXPECTED EXCEPTION TYPE??");
                Assert.AreEqual(expectedOutput, ex.Message, "WHY NOT EXPECTED MESSAGE??");
            }
        }
*/        
    }
}
