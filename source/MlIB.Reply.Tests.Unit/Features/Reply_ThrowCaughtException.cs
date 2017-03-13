using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MlIB.Reply.Tests.Unit.Features
{
    [TestClass]
    public class Reply_ThrowCaughtException
    {
        // UNIT UNDER TEST:
        // public void ThrowCaughtException()


        //I: - HasException true - HasError false
        //O: dont throw, do nothing
        // _HasException_true_HasError_false
        // [IMPOSSIBLE]


        //I: - HasException false - HasError false
        //O: dont throw, do nothing
        //O: keeps showing NO error
        [TestMethod]
        public void Reply_ThrowCaughtException_HasException_false_HasError_false()
        {
            var result = M.Reply.From(() => Stubs.VoidMethods.PlayStaticSound());

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

        //I: - HasException false - HasError true
        //O: dont throw, do nothing
        //O: keeps showing error
        [TestMethod]
        public void Reply_ThrowCaughtException_HasException_false_HasError_true()
        {
            var result = M.Reply.Error(5) as M.IReplyEx<int>;

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
        public void Reply_ThrowCaughtException_HasException_true_HasError_true()
        {
            var caughtException = Stubs.VoidMethods.EXCEPTION;

            var result = M.Reply.From(() => Stubs.VoidMethods.PlayInexistentSound());

            Exception assert = null;
            try
            {
                result.ThrowCaughtException();
            }
            catch (Exception ex)
            {
                assert = ex;
            }

            Assert.AreSame(caughtException, assert, "WHY NOT EXPECTED EXCEPTION??");
        }

    }
}
