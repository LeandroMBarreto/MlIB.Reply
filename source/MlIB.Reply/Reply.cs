
/* MlIB.Reply
 * https://github.com/LeandroMBarreto
 * http://www.codeproject.com/Members/LeandroMBarreto
 * 
 The MIT License (MIT)

Copyright (c) 2014-2016 Leandro M Barreto

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
 */

using System;
using System.Collections.Generic;
using M;

namespace MlIB
{
    /// <summary>
    /// Use this class to return valuable error information from methods instead of ambiguous null, false or default values.
    /// </summary>
    /// <typeparam name="TReturn">The type of the returned value</typeparam>
    public class Reply<TReturn>
        : IReplyFast<TReturn>, IReplyEx<TReturn>, IReplyCode<TReturn>, IReplyMsg<TReturn>
        , IReplyFull<TReturn>, IReplyExMsg<TReturn>, IReplyCodeMsg<TReturn>
    {

        public TReturn Value { get; protected set; }
        public Enum ErrorCode { get; protected set; }
        public string ErrorMessage { get; protected set; }
        public Exception Exception { get; protected set; }

        public bool HasError { get; protected set; }

        public bool HasErrorCode { get { return this.ErrorCode != null; } }
        public bool HasException { get { return this.Exception != null; } }
        public bool HasErrorMessage { get { return this.ErrorMessage != null; } }


        internal Reply(TReturn value, bool hasError = false)
        {
            this.HasError = hasError;

            this.Value = value;
            this.Exception = null;
            this.ErrorCode = null;
            this.ErrorMessage = null;
        }

        internal Reply(TReturn value, string errorMessage)
        {
            this.HasError = true;

            this.Value = value;
            this.Exception = null;
            this.ErrorCode = null;
            this.ErrorMessage = errorMessage;
        }

        internal Reply(TReturn value, Exception exception, string errorMessage = null)
        {
            this.HasError = true;

            this.Value = value;
            this.ErrorCode = null;
            this.Exception = exception;
            this.ErrorMessage = errorMessage;
        }

        internal Reply(TReturn value, Enum errorCode, string errorMessage = null)
        {
            this.HasError = true;

            this.Value = value;
            this.Exception = null;
            this.ErrorCode = errorCode;

            this.ErrorMessage = errorMessage != null ? errorMessage
              : errorCode != null ? Enum.GetName(errorCode.GetType(), errorCode)
              : null;
        }

        internal Reply(TReturn value, Enum errorCode, Exception exception, string errorMessage = null)
        {
            this.Value = value;
            this.ErrorCode = errorCode;
            this.Exception = exception;
            this.ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Does nothing when it has no error.
        /// When the only error is an exception, it just throws that exception.
        /// If any additional error data is provided (ie. msgPrefix), it throws a ReplyException passing any caught exception as InnerException.
        /// The text message of ReplyException is formatted as [{msgPrefix}-{ErrorCode}-{ErrorMessage}].
        /// # Reply library provides fast error messaging for methods and functions #
        /// </summary>
        /// <param name="msgPrefix">An optional prefix to append to the exception message.</param>
        public void ThrowWhenError(string msgPrefix = null)
        {
            if (!HasError) return;

            if (msgPrefix == null && this.ErrorMessage == null && ErrorCode == null)
                if (HasException) throw this.Exception;

            throw new ReplyException(msgPrefix, this.ErrorCode, this.ErrorMessage, this.Exception);
        }

    }
}