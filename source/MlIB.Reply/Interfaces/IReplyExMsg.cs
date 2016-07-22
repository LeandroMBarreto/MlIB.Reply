using System;
using System.Collections.Generic;
using System.Text;

namespace M
{
    public interface IReplyExMsg<TReturn> : IReplyFast<TReturn>, IReplyEx<TReturn>, IReplyMsg<TReturn>
    {
    }
}
