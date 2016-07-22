using System;
using System.Collections.Generic;
using System.Text;

namespace M
{
    public interface IReplyEx<TReturn> : IReplyFast<TReturn>
    {
        Exception Exception { get; }
        bool HasException { get; }
    }
}
