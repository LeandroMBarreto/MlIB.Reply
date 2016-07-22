using System;
using System.Collections.Generic;
using System.Text;

namespace M
{
    public interface IReplyFull<TReturn> : IReplyFast<TReturn>, IReplyEx<TReturn>, IReplyMsg<TReturn>, IReplyCode<TReturn>
    {
    }
}
