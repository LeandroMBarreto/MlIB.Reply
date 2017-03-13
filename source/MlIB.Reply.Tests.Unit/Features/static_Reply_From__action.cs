using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MlIB.Reply.Tests.Unit.Features
{
    [TestClass]
    public class static_Reply_From__action
    {
        // UNIT UNDER TEST:
        // public static IReplyEx<Exception> From(Action action)


        //I: action null
        //O: NullReferenceException
        //O: "ERROR: CANNOT EXECUTE A NULL ACTION!!"
        [TestMethod]
        public void static_Reply_From_action_null()
        {
            try
            {
                M.Action action = null;
                var result = M.Reply.From(action);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(NullReferenceException), "FAIL TYPE");
                Assert.AreEqual("ERROR: CANNOT EXECUTE A NULL ACTION!!", ex.Message, "FAIL Message");
            }
        }

        //I: action ok
        //O: HasError false
        //O: HasException false
        //O: Value null
        //O: Exception null
        [TestMethod]
        public void static_Reply_From_action_ok()
        {
            var result = M.Reply.From(() => Stubs.VoidMethods.PlayStaticSound());

            Assert.IsFalse(result.HasError, "FAIL HasError");
            Assert.IsFalse(result.HasException, "FAIL HasException");
            Assert.IsNull(result.Value, "FAIL Value");
            Assert.IsNull(result.Exception, "FAIL Exception");
        }

        //I: action throwing
        //O: HasError true
        //O: HasException true
        //O: Value exception
        //O: Exception exception
        [TestMethod]
        public void static_Reply_From_action_throwing()
        {
            var result = M.Reply.From(() => Stubs.VoidMethods.PlayInexistentSound());

            Assert.IsTrue(result.HasError, "FAIL HasError");
            Assert.IsTrue(result.HasException, "FAIL HasException");
            Assert.AreSame(Stubs.VoidMethods.EXCEPTION, result.Value, "FAIL Value");
            Assert.AreSame(Stubs.VoidMethods.EXCEPTION, result.Exception, "FAIL Exception");
        }

    }
}
