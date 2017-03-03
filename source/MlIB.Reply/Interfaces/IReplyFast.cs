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
        /// Does nothing when HasError is false.
        /// When true, throws a ReplyFullException.
        /// The exception message is the same from FullMessage property.
        /// Any exception previously caught by this Reply object is passed in as InnerException.
        /// </summary>
        /// <param name="messagePrefix">An optional prefix to append to the exception message.</param>
        //void ThrowAnyError(string messagePrefix = "ERROR");
    }
}
