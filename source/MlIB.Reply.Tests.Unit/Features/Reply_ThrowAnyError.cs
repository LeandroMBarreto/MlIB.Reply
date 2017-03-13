using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MlIB.Reply.Tests.Unit.Features
{
    [TestClass]
    public class Reply_ThrowAnyError
    {
        // UNIT UNDER TEST:
        // void ThrowAnyError(string msgPrefix = null)


        //I: - msgPrefix null - WHEN HasError false
        //O: dont throw, do nothing
        //O: keeps showing no error
        [TestMethod]
        public void Reply_ThrowAnyError_msgPrefix_null_WHEN_HasError_false()
        {
            var result = M.Reply.NoError(5);

            result.ThrowAnyError(null);

            Assert.IsFalse(result.HasError, "WHY HAS ERROR??");
        }

        //I: - msgPrefix empty - WHEN HasError false
        //O: dont throw, do nothing
        //O: keeps showing no error
        [TestMethod]
        public void Reply_ThrowAnyError_msgPrefix_empty_WHEN_HasError_false()
        {
            var result = M.Reply.NoError(5);

            result.ThrowAnyError(string.Empty);

            Assert.IsFalse(result.HasError, "WHY HAS ERROR??");
        }

        //I: - msgPrefix ok - WHEN HasError false
        //O: dont throw, do nothing
        //O: keeps showing no error
        [TestMethod]
        public void Reply_ThrowAnyError_msgPrefix_ok_WHEN_HasError_false()
        {
            var result = M.Reply.NoError(5);

            result.ThrowAnyError("SOME MSG PREFIX");

            Assert.IsFalse(result.HasError, "WHY HAS ERROR??");
        }

        //I: - msgPrefix null - WHEN HasError true
        //O: ReplyFullException
        //O: [] | ErrorCodeID: n/a | ErrorCodeLabel: n/a | ErrorMessage: n/a |
        [TestMethod]
        public void Reply_ThrowAnyError_msgPrefix_null_WHEN_HasError_true()
        {
            var expectedOutput = "[] | ErrorCodeID: n/a | ErrorCodeLabel: n/a | ErrorMessage: n/a |";

            var result = M.Reply.Error(5);

            Exception assert = null;
            try
            {
                result.ThrowAnyError(null);
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsInstanceOfType(assert, typeof(ReplyFullException), "WHY NOT EXPECTED EXCEPTION TYPE??");
            Assert.AreEqual(expectedOutput, assert.Message, "WHY NOT EXPECTED MESSAGE??");
        }

        //I: - msgPrefix empty - WHEN HasError true
        //O: ReplyFullException
        //O: [] | ErrorCodeID: n/a | ErrorCodeLabel: n/a | ErrorMessage: n/a |
        [TestMethod]
        public void Reply_ThrowAnyError_msgPrefix_empty_WHEN_HasError_true()
        {
            var expectedOutput = "[] | ErrorCodeID: n/a | ErrorCodeLabel: n/a | ErrorMessage: n/a |";

            var result = M.Reply.Error(5);

            Exception assert = null;
            try
            {
                result.ThrowAnyError(string.Empty);
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsInstanceOfType(assert, typeof(ReplyFullException), "WHY NOT EXPECTED EXCEPTION TYPE??");
            Assert.AreEqual(expectedOutput, assert.Message, "WHY NOT EXPECTED MESSAGE??");
        }

        //I: - msgPrefix ok - WHEN HasError true
        //O: ReplyFullException
        //O: [msgPrefix] | ErrorCodeID: n/a | ErrorCodeLabel: n/a | ErrorMessage: n/a |
        [TestMethod]
        public void Reply_ThrowAnyError_msgPrefix_ok_WHEN_HasError_true()
        {
            var msgPrefix = "RANDOM MSG PREFIX";
            var expectedOutput = string.Format("[{0}] | ErrorCodeID: n/a | ErrorCodeLabel: n/a | ErrorMessage: n/a |", msgPrefix);

            var result = M.Reply.Error(5);

            Exception assert = null;
            try
            {
                result.ThrowAnyError(msgPrefix);
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsInstanceOfType(assert, typeof(ReplyFullException), "WHY NOT EXPECTED EXCEPTION TYPE??");
            Assert.AreEqual(expectedOutput, assert.Message, "WHY NOT EXPECTED MESSAGE??");
        }

        //I: - msgPrefix ok - WHEN HasError true - HasException true
        //O: ReplyFullException
        //O: [msgPrefix] | ErrorCodeID: n/a | ErrorCodeLabel: n/a | ErrorMessage: n/a |
        //O: InnerExpection exception
        [TestMethod]
        public void Reply_ThrowAnyError_msgPrefix_ok_WHEN_HasException_true()
        {
            var msgPrefix = "RANDOM MSG PREFIX";
            var expectedOutput = string.Format("[{0}] | ErrorCodeID: n/a | ErrorCodeLabel: n/a | ErrorMessage: n/a |", msgPrefix);

            var result = M.Reply.Exception<int>(Stubs.Common.EXCEPTION);

            Exception assert = null;
            try
            {
                result.ThrowAnyError(msgPrefix);
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsInstanceOfType(assert, typeof(ReplyFullException), "WHY NOT EXPECTED EXCEPTION TYPE??");
            Assert.AreEqual(expectedOutput, assert.Message, "WHY NOT EXPECTED MESSAGE??");

            Assert.AreEqual(Stubs.Common.EXCEPTION, assert.InnerException, "FAIL InnerException");        //O: InnerExpection exception
        }

    }
}
