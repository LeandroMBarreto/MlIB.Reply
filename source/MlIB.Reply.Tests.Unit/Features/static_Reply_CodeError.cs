using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MlIB.Reply.Tests.Unit.Stubs;

namespace MlIB.Reply.Tests.Unit.Features
{
    [TestClass]
    public class static_Reply_CodeError
    {
        // UNIT UNDER TEST:
        //  public static IReplyCode<TReturn> CodeError<TReturn>(Enum errorCode, TReturn value = default(TReturn))


        //I: - errorCode null - value default
        //O1: HasError true
        //O2: HasErrorCode false
        //O3: ErrorCode null
        //O4: ErrorCodeID null
        //O5: ErrorCodeLabel null
        //O6: value default
        [TestMethod]
        public void static_Reply_CodeError_errorCode_null_value_default()
        {
            Enum myEnum = null;

            var result = M.Reply.CodeError<int>(myEnum);

            //O1: HasError true
            Assert.IsTrue(result.HasError, "FAIL HasError");

            //O2: HasErrorCode false
            Assert.IsFalse(result.HasErrorCode, "FAIL HasErrorCode");

            //O3: ErrorCode null
            Assert.IsNull(result.ErrorCode, "FAIL ErrorCode");

            //O4: ErrorCodeID null
            Assert.AreEqual(null, result.ErrorCodeID, "FAIL ErrorCodeID");

            //O5: ErrorCodeLabel null
            Assert.AreEqual(null, result.ErrorCodeLabel, "FAIL ErrorCodeLabel");

            //O6: value default
            Assert.AreEqual(default(int), result.Value);
        }

        //I: - errorCode ok - value default
        //O1: HasError true
        //O2: HasErrorCode true
        //O3: ErrorCode ok
        //O4: ErrorCodeID ok
        //O5: ErrorCodeLabel ok
        //O6: value default
        [TestMethod]
        public void static_Reply_CodeError_errorCode_ok_value_default()
        {
            Enum myEnum = MyErrorEnum.ACCESS_DENIED;

            var result = M.Reply.CodeError<float>(myEnum);

            //O1: HasError true
            Assert.IsTrue(result.HasError, "FAIL HasError");

            //O2: HasErrorCode true
            Assert.IsTrue(result.HasErrorCode, "FAIL HasErrorCode");

            //O3: ErrorCode ok
            Assert.AreEqual(myEnum, result.ErrorCode, "FAIL ErrorCode");

            //O4: ErrorCodeID ok
            Assert.AreEqual("3", result.ErrorCodeID, "FAIL ErrorCodeID");

            //O5: ErrorCodeLabel ok
            Assert.AreEqual("ACCESS_DENIED", result.ErrorCodeLabel, "FAIL ErrorCodeLabel");

            //O6: value default
            Assert.AreEqual(default(float), result.Value);
        }

        //I: - errorCode null - value ok
        //O1: HasError true
        //O2: HasErrorCode false
        //O3: ErrorCode null
        //O4: ErrorCodeID null
        //O5: ErrorCodeLabel null
        [TestMethod]
        public void static_Reply_CodeError_errorCode_null_value_ok()
        {
            int value = 5;
            Enum myEnum = null;

            var result = M.Reply.CodeError<int>(myEnum, value);

            //O1: HasError true
            Assert.IsTrue(result.HasError, "FAIL HasError");

            //O2: HasErrorCode false
            Assert.IsFalse(result.HasErrorCode, "FAIL HasErrorCode");

            //O3: ErrorCode null
            Assert.IsNull(result.ErrorCode, "FAIL ErrorCode");

            //O4: ErrorCodeID null
            Assert.AreEqual(null, result.ErrorCodeID, "FAIL ErrorCodeID");

            //O5: ErrorCodeLabel null
            Assert.AreEqual(null, result.ErrorCodeLabel, "FAIL ErrorCodeLabel");

            //O6: value ok
            Assert.AreEqual(value, result.Value);
        }

        //I: - errorCode ok - value ok
        //O1: HasError true
        //O2: HasErrorCode true
        //O3: ErrorCode ok
        //O4: ErrorCodeID ok
        //O5: ErrorCodeLabel ok
        //O6: value ok
        [TestMethod]
        public void static_Reply_CodeError_errorCode_ok_value_ok()
        {
            int value = 5;
            Enum myEnum = MyErrorEnum.ACCESS_DENIED;

            var result = M.Reply.CodeError<float>(myEnum, value);

            //O1: HasError true
            Assert.IsTrue(result.HasError, "FAIL HasError");

            //O2: HasErrorCode true
            Assert.IsTrue(result.HasErrorCode, "FAIL HasErrorCode");

            //O3: ErrorCode ok
            Assert.AreEqual(myEnum, result.ErrorCode, "FAIL ErrorCode");

            //O4: ErrorCodeID ok
            Assert.AreEqual("3", result.ErrorCodeID, "FAIL ErrorCodeID");

            //O5: ErrorCodeLabel ok
            Assert.AreEqual("ACCESS_DENIED", result.ErrorCodeLabel, "FAIL ErrorCodeLabel");

            //O6: value ok
            Assert.AreEqual(value, result.Value);
        }

    }
}
