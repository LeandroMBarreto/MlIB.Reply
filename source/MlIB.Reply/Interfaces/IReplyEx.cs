using System;
using System.Collections.Generic;
using System.Text;

namespace M
{
    public interface IReplyEx<TReturn> : IReply<TReturn>
    {
        bool HasException { get; }
        Exception Exception { get; }
    }
}
