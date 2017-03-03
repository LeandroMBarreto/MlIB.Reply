
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
        , IReplyFull<TReturn>, IReplyCodeMsg<TReturn>
    {

        public TReturn Value { get; protected set; }
        public Enum ErrorCode { get; protected set; }
        public string ErrorMessage { get; protected set; }
        public Exception Exception { get; protected set; }

        public bool HasError { get; protected set; }

        public bool HasErrorCode { get { return this.ErrorCode != null; } }
        public bool HasException { get { return this.Exception != null; } }
        public bool HasErrorMessage { get { return this.ErrorMessage != null; } }

        /// <summary>
        /// Generates a standard message about this Reply object.
        /// Value data is kept hidden to not disclose sensitive data.
        /// Message format:
        /// | ErrorCodeID: n/a | ErrorCodeLabel: n/a | ErrorMessage: n/a |
        /// </summary>
        public string FullStatusMessage
        {
            get
            {
                return string.Format("| ErrorCodeID: {0} | ErrorCodeLabel: {1} | ErrorMessage: {2} |"
                    , "n/a", "n/a", "n/a");
            }
        }

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
            //todo: unit test should require this later
            //this.HasError = true;

            this.Value = value;
            this.ErrorCode = errorCode;
            this.Exception = exception;
            this.ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Does nothing when HasError is false.
        /// When true, throws a ReplyFullException.
        /// The exception message is the same from property FullStatusMessage.
        /// Any exception previously caught by this Reply object is passed in as InnerException.
        /// </summary>
        /// <param name="messagePrefix">An optional prefix to append to the exception message.</param>
        //public void ThrowAnyError(string messagePrefix = "ERROR")
        //{
        //    if (!HasError) return;

        //    throw new ReplyFullException(messagePrefix, this.FullStatusMessage);
        //}

    }
}