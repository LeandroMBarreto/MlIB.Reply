using System;
using System.Collections.Generic;
using System.Text;

namespace M
{
    public interface IReplyFast<TReturn>
    {
        TReturn Value { get; }
        bool HasError { get; }

        /// <summary>
        /// Does nothing when it has no error.
        /// When the only error is an exception, it just throws that exception.
        /// If any additional error data is provided (ie. msgPrefix), it throws a ReplyException passing any caught exception as InnerException.
        /// The text message of ReplyException is formatted as [{msgPrefix}-{ErrorCode}-{ErrorMessage}].
        /// # Reply library provides fast error messaging for methods and functions #
        /// </summary>
        /// <param name="msgPrefix">An optional prefix to append to the exception message.</param>
        void ThrowWhenError(string msgPrefix = null);
    }
}
