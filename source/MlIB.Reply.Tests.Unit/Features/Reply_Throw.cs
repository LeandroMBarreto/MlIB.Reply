using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MlIB.Reply.Tests.Unit.Features
{
    [TestClass]
    public class Reply_Throw
    {
        // UNIT UNDER TEST:
        //public static void Throw(Enum errorCode, string errorMessage = null)

        //I:null code
        //O:throw ReplyException 
        //O:generic exception message
        [TestMethod]
        public void Reply_Throw_errorCode_null()
        {
            Enum nullCode = null;

            Exception assert = null;
            try
            {
                M.Reply.Throw(nullCode);
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsNotNull(assert, "WHY NOT THROWING??");
            Assert.AreEqual(typeof(ReplyException), assert.GetType(), "WHY NOT EXPECTED TYPE??");
            Assert.IsTrue(assert.Message.Contains("A DEFAULT ERROR WAS THROWN"), "WHY NOT EXPECTED MESSAGE??");
        }

        //I:null code, empty msg
        //O:throw ReplyException 
        //O:empty exception message
        [TestMethod]
        public void Reply_Throw_errorCode_null_message_empty()
        {
            Enum nullCode = null;

            Exception assert = null;
            try
            {
                M.Reply.Throw(nullCode, "");
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsNotNull(assert, "WHY NOT THROWING??");
            Assert.AreEqual(typeof(ReplyException), assert.GetType(), "WHY NOT EXPECTED TYPE??");
            Assert.AreEqual("[--]", assert.Message, "WHY NOT EXPECTED MESSAGE??");
        }

        //I:null code, valid msg
        //O:throw ReplyException 
        //O:expected exception message
        [TestMethod]
        public void Reply_Throw_errorCode_null_message_valid()
        {
            Enum nullCode = null;

            Exception assert = null;
            try
            {
                M.Reply.Throw(nullCode, Stubs.Common.MSG_ErrorFound);
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.IsNotNull(assert, "WHY NOT THROWING??");
            Assert.AreEqual(typeof(ReplyException), assert.GetType(), "WHY NOT EXPECTED TYPE??");
            Assert.IsTrue(assert.Message.Contains(Stubs.Common.MSG_ErrorFound), "WHY NOT EXPECTED MESSAGE??");
        }

        //I:valid code
        //O:
        [TestMethod]
        [Ignore]
        public void Reply_Throw_errorCode_valid()
        {
           
        }

        //I:valid code, empty msg
        //O:
        [TestMethod]
        [Ignore]
        public void Reply_Throw_errorCode_valid_message_empty()
        {

        }

        //I:valid code, valid msg
        //O:
        [TestMethod]
        [Ignore]
        public void Reply_Throw_errorCode_valid_message_valid()
        {

        }

    }
}
