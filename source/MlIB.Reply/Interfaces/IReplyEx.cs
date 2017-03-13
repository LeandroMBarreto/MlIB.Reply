using System;
using System.Collections.Generic;
using System.Text;

namespace M
{
    public interface IReplyEx<TReturn> : IReply<TReturn>
    {
        bool HasException { get; }
        Exception Exception { get; }

        /// <summary>
        /// Does nothing when HasException is false.
        /// When true, throws exactly the same exception from Exception property.
        /// </summary>
        void ThrowCaughtException();
    }
}
