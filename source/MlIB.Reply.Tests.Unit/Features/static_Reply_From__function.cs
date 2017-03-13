using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MlIB.Reply.Tests.Unit.Features
{
    [TestClass]
    public class static_Reply_From__function
    {
        // UNIT UNDER TEST:
        // public static IReplyEx<TReturn> From<TReturn>(Func<TReturn> function)


        //I: - function null
        //O: NullReferenceException
        [TestMethod]
        public void static_Reply_From_function_null()
        {
            try
            {
                M.Func<int> function = null;
                var result = M.Reply.From(function);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(NullReferenceException), "FAIL TYPE");
                Assert.AreEqual("ERROR: CANNOT EXECUTE A NULL FUNCTION!!", ex.Message, "FAIL Message");
            }
        } 

        //I: - function ok
        //O: HasError false
        //O: HasException false
        //O: Exception null
        [TestMethod]
        public void static_Reply_From_function_ok()
        {
            var result = M.Reply.From(() => Stubs.FunctionMethods.Authenticate("LeandroMBarreto", 777));

            Assert.IsFalse(result.HasError, "FAIL HasError");
            Assert.IsFalse(result.HasException, "FAIL HasException");
            Assert.IsNull(result.Exception, "FAIL Exception");
            Assert.IsTrue(result.Value, "FAIL Value");
        } 

        //I: - function returningException
        //O: HasError false
        //O: HasException false
        //O: Exception null
        //O: Value Exception
        [TestMethod]
        public void static_Reply_From_function_returningException()
        {
            var result = M.Reply.From(() => Stubs.FunctionMethods.GetSomething());

            Assert.IsFalse(result.HasError, "FAIL HasError");
            Assert.IsFalse(result.HasException, "FAIL HasException");
            Assert.IsNull(result.Exception, "FAIL Exception");
            Assert.IsInstanceOfType(result.Value, typeof(Exception), "FAIL Value");
        }

        //I: - function throwingException
        //O: HasError true
        //O: HasException true
        //O: Exception ok
        //O: Value default
        [TestMethod]
        public void static_Reply_From_function_throwingException()
        {
            var result = M.Reply.From(() => Stubs.FunctionMethods.TryQuerySomething());

            Assert.IsTrue(result.HasError, "FAIL HasError");
            Assert.IsTrue(result.HasException, "FAIL HasException");
            Assert.IsNotNull(result.Exception, "FAIL Exception");
            Assert.AreEqual(default(int), result.Value, "FAIL Value");
        }

    }
}
