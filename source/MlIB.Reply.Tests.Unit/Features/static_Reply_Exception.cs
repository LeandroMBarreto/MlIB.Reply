using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MlIB.Reply.Tests.Unit.Features
{
    [TestClass]
    public class static_Reply_Exception
    {
        // UNIT UNDER TEST:
        // public static IReplyEx<TReturn> Exception<TReturn>(Exception ex, TReturn value = default(TReturn))


        //I: - ex null - value default
        //O1: HasError true
        //O2: value default 
        //O3: HasException false
        //O4: exception null
        [TestMethod]
        public void static_Reply_Exception_ex_null_value_default()
        {
            Exception nullEx = null;
            var result = M.Reply.Exception<int>(nullEx);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");        //O1: HasError true 
            Assert.AreEqual(default(int), result.Value, "WHY NO DEFAULT VALUE??");          //O2: value default 

            Assert.IsFalse(result.HasException, "FAIL HasException");            //O3: HasException false
            Assert.AreEqual(null, result.Exception, "FAIL Exception");        //O4: exception null
        }

        //I: - ex ok - value default
        //O1: HasError true
        //O2: value default 
        //O3: HasException true
        //O4: exception ok
        [TestMethod]
        public void static_Reply_Exception_ex_ok_value_default()
        {
            Exception nullEx = Stubs.Common.EXCEPTION;
            var result = M.Reply.Exception<int>(nullEx);

            Assert.IsTrue(result.HasError, "WHY NO ERROR??");        //O1: HasError true 
            Assert.AreEqual(default(int), result.Value, "WHY NO DEFAULT VALUE??");          //O2: value default 

            Assert.IsTrue(result.HasException, "FAIL HasException");          //O3: HasException true
            Assert.AreEqual(Stubs.Common.EXCEPTION, result.Exception, "FAIL Exception");        //O4: exception ok
        }
         

        //I: - ex null - value ok
        //O1: HasError true
        //O2: value ok 
        //O3: HasException false
        //O4: exception null
        [TestMethod]
        public void static_Reply_Exception_ex_null_value_ok()
        {
            Exception nullEx = null;
            var result = M.Reply.Exception<int>(nullEx, 5);

            Assert.IsTrue(result.HasError, "FAIL HasError");        //O1: HasError true 
            Assert.AreEqual(5, result.Value, "FAIL Value");          //O2: value ok 

            Assert.IsFalse(result.HasException, "FAIL HasException");            //O3: HasException false
            Assert.AreEqual(null, result.Exception, "FAIL Exception");        //O4: exception null
        }
         

        //I: - ex ok - value ok
        //O1: HasError true
        //O2: value ok 
        //O3: HasException true
        //O4: exception ok
        [TestMethod]
        public void static_Reply_Exception_ex_ok_value_ok()
        {
            Exception nullEx = Stubs.Common.EXCEPTION;
            var result = M.Reply.Exception<int>(nullEx, 5);

            Assert.IsTrue(result.HasError, "FAIL HasError");        //O1: HasError true 
            Assert.AreEqual(5, result.Value, "FAIL Value");          //O2: value ok 

            Assert.IsTrue(result.HasException, "FAIL HasException");          //O3: HasException true
            Assert.AreEqual(Stubs.Common.EXCEPTION, result.Exception, "FAIL Exception");        //O4: exception ok
        }
         

        //I: - ex null - value exception
        //O1: HasError true
        //O2: value exception
        //O3: HasException false
        //O4: exception null
        [TestMethod]
        public void static_Reply_Exception_ex_null_value_exception()
        {
            Exception realEx = null;
            Exception valEx = new Exception("blebleble");
            var result = M.Reply.Exception(realEx, valEx);

            Assert.IsTrue(result.HasError, "FAIL HasError");        //O1: HasError true 
            Assert.AreEqual(valEx, result.Value, "FAIL Value");      //O2: value exception 

            Assert.IsFalse(result.HasException, "FAIL HasException");            //O3: HasException false
            Assert.AreEqual(null, result.Exception, "FAIL Exception");        //O4: exception null
        } 
         

        //I: - ex ok - value exception
        //O1: HasError true
        //O2: value exception 
        //O3: HasException true
        //O4: exception ok
        //O5: exception not same as value
        [TestMethod]
        public void static_Reply_Exception_ex_ok_value_exception()
        {
            Exception realEx = Stubs.Common.EXCEPTION;
            Exception valEx = new Exception("blebleble");
            var result = M.Reply.Exception(realEx, valEx);

            Assert.IsTrue(result.HasError, "FAIL HasError");        //O1: HasError true 
            Assert.AreEqual(valEx, result.Value, "FAIL Value");      //O2: value exception 

            Assert.IsTrue(result.HasException, "FAIL HasException");          //O3: HasException true
            Assert.AreEqual(Stubs.Common.EXCEPTION, result.Exception, "FAIL Exception");        //O4: exception ok

            Assert.AreNotSame(result.Exception, result.Value, "FAIL comparison");  //O5: exception not same as value
        }
         
    }
}
