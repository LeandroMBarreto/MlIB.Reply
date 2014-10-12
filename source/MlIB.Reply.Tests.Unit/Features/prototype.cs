using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MlIB.ReplyProject.Tests.Unit.Stubs;

namespace MlIB.ReplyProject.Tests.Unit.Features
{
    [TestClass]
    public class prototype
    {

        [TestMethod]
        public void Reply_Exception_voidMethod_ok_NotThrowing()
        {
            var res = Reply.CatchingException(VoidMethods.PlayStaticSound);

            Assert.IsFalse(res.HasError);
        }

        [TestMethod]
        public void Reply_Exception_voidMethod_ok_Throwing()
        {
            var res = Reply.CatchingException(VoidMethods.PlayInexistentSound);
            
            var ex = new InvalidOperationException("ain't hear no song at all but buggy noises.");

            Assert.IsTrue(res.HasError);
            Assert.IsTrue(res.HasErrorMessage);
            Assert.AreEqual(ex.Message, res.ErrorMessage);
            Assert.AreEqual(ex.GetType(), res.Value.GetType());
        }

    }
}
