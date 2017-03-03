using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MlIB.Reply.Tests.Unit.Features
{
    [TestClass]
    public class static_Reply_Error__errorCode_errorMsg
    {
        // UNIT UNDER TEST:
        //public static IReplyCode<TReturn> Error<TReturn>(Enum errorCode, string errorMessage = null, TReturn value = default(TReturn))

        //I:null
        //O:
        [TestMethod]
        [Ignore]
        public void Reply_Error_code_null()
        {

        }

        //I:valid
        //O:

        //I:null, empty
        //O:

        //I:valid, empty
        //O:
        [TestMethod]
        [Ignore]
        public void Reply_Error_code_valid_msg_empty()
        {

        }

        //I:null, valid
        //O:

        //I:valid, valid
        //O:
      
        //I:null, empty, valid
        //O:
        [TestMethod]
        [Ignore]
        public void Reply_Error_code_null_msg_empty_value_valid()
        {
            //    Enum nullCode = null;
            //    var result = M.Reply.Error(nullCode, anyValue);

            //    Assert.IsFalse(result.HasError);
            //    Assert.IsFalse(result.HasErrorCode);
            //    Assert.IsFalse(result.HasErrorMessage);
            //    Assert.IsNull(result.ErrorCode);
            //    Assert.AreEqual(result.Value, anyValue);
        }


        //I:valid, empty, valid
        //O:
        [TestMethod]
        [Ignore]
        public void Reply_Error_code_valid_msg_empty_value_valid()
        {
            //    var result = M.Reply.Error(MyErrorEnum.ACCESS_DENIED, anyValue);

            //    Assert.IsTrue(result.HasError);
            //    Assert.IsTrue(result.HasErrorCode);
            //    Assert.IsTrue(result.HasErrorMessage);
            //    Assert.AreEqual(result.ErrorCode, MyErrorEnum.ACCESS_DENIED);
            //    Assert.AreEqual(result.Value, anyValue);
        }

        //I:null, valid, valid
        //O:

        //I:valid, valid, valid
        //O:
        
        //I:null, empty, valid exception
        //O:
        [TestMethod]
        [Ignore]
        public void Reply_Error_code_null_msg_empty_value_valid_whenException()
        {

        }

        //I:valid, empty, valid exception
        //O:
        [TestMethod]
        [Ignore]
        public void Reply_Error_code_valid_msg_empty_value_valid_whenException()
        {
            //var result = M.Reply.Error(nullCode, anyValue);

            //Assert.IsFalse(result.HasError);
            //Assert.IsFalse(result.HasErrorCode);
            //Assert.IsFalse(result.HasErrorMessage);
            //Assert.IsNull(result.ErrorCode);
            //Assert.AreEqual(result.Value, anyValue);
        }

        //I:null, valid, valid exception
        //O:

        //I:valid, valid, valid exception
        //O:

    }
}
