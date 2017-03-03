using System;
using System.Collections.Generic;
using System.Text;

namespace M
{
    public interface IReplyEx<TReturn> : IReply<TReturn>
    {
        Exception Exception { get; }
        bool HasException { get; }
    }
}
